using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class PermissionsForm : Form
    {
        StockEntities stockEntities= new StockEntities();
        List<Object> catList = new List<Object>();
        List<Product> productList = new List<Product>();
        List<Product> viewProduct = new List<Product>();
        String permissionMode=String.Empty;
        public PermissionsForm()
        {
            InitializeComponent();
            comboBox3.Enabled = false;
            panel1.Enabled = false;
        }

        private void PermissionsForm_Load(object sender, EventArgs e)
        {
            var permissions = from prem in stockEntities.premissionTypes
                              select prem;
            List<premissionType> permisiionList = new List<premissionType>();
            foreach(premissionType prem in permissions)
            {
               
                permisiionList.Add(new premissionType { id =prem.id,type=prem.type});
               
            }
            comboBox1.DataSource = permisiionList;
            comboBox1.DisplayMember = "type";
            comboBox1.ValueMember = "id";
            var stockList = from st in stockEntities.Stocks select st;
            List<Stock> Fromstocks=new List<Stock>();
            List<Stock> tostocks = new List<Stock>();

            foreach (var st in stockList)
            {
                Fromstocks.Add(st);
                tostocks.Add(st);


            }
            comboBox2.DataSource = Fromstocks;
            comboBox2.DisplayMember = "name";
            comboBox3.DataSource = tostocks;
            comboBox3.DisplayMember = "name";



        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            var catItem = (Category)comboBox4.SelectedItem;
            if (permissionMode == "existance"||permissionMode== "exchange")
            {
                Console.WriteLine();
                var products = from pr in stockEntities.Products
                               where pr.Category_id == catItem.id
                               select pr;

                foreach (var item in products)
                {
                    productList.Add(new Product { product_id = item.product_id, product_name = item.product_name, quantity = item.quantity, Category_id = catItem.id });
                }
                dataGridView1.DataSource = productList;

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            premissionType premission = (premissionType)comboBox1.SelectedItem;
          
            viewProduct.Clear();
            dataGridView1.DataSource = dataGridView2.DataSource = null;
             if(premission.type== "supply")
            {
                panel1.Enabled = true;
                comboBox3.Enabled =false;
                permissionMode = "supply";
            }
             else if(premission.type== "exchange")
            {
                comboBox3.Enabled =true;
                panel1.Enabled = false;
                permissionMode = "exchange";
            }
             else if(premission.type == "existance")
            {
                panel1.Enabled =false;
                comboBox3.Enabled = false;
               
                permissionMode = "existance";
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Text = "";
            var stock = (Stock)comboBox2.SelectedItem;
            var categories = from cat in stockEntities.Categories
                             where cat.id == stock.id
                             select cat;
            List<Category> categoryList = new List<Category>();
            Console.WriteLine("=========");
            foreach(var item in categories)
            {
                
               categoryList.Add(new Category {id=item.id,category1=item.category1,Supplier=item.Supplier });
            }
            comboBox4.DisplayMember = "category1";
            comboBox4.DataSource = categoryList;
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            
            try {
                var catitem = (Category)comboBox4.SelectedItem;
               
                DateTime productiondate = DateTime.ParseExact(textBox6.Text, "dd/MM/yyyy",
                                             CultureInfo.InvariantCulture);
                Console.WriteLine("===========");
                Console.WriteLine(productiondate);


                DateTime expiredate = DateTime.ParseExact(textBox7.Text, "dd/MM/yyyy",
                                        CultureInfo.InvariantCulture);
                Console.WriteLine("===========");
                Console.WriteLine(expiredate);
                stockEntities.Products.Add(new Product
                {
                    product_name = textBox1.Text,
                    price = textBox2.Text,
                    code = textBox3.Text,
                    discount = textBox4.Text,
                    quantity = textBox5.Text,
                    production_date = productiondate,


                    expire_in = expiredate,
                    Category_id = catitem.id,
                    addedat = DateTime.Now
                });
                stockEntities.SaveChanges();
                MessageBox.Show("ADDED SUCCESSFULLY ^_^");
                dataGridView1.DataSource = null;
                catList.Add(new
                {
                    product_name = textBox1.Text,
                    price = textBox2.Text,
                    code = textBox3.Text,
                    discount = textBox4.Text,
                    quantity = textBox5.Text,
                    production_date = productiondate,


                    expire_in = expiredate,
                    Category_id = catitem.id,
                    addedat = DateTime.Now
                });
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text =textBox6.Text=textBox7.Text="";
               
                dataGridView1.DataSource = catList;



            }
            catch(System.FormatException exce)
            {
                MessageBox.Show("Enter Date in THIS Format dd/MM/yyyy");
            }
           
        }
       

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            var catItem = (Category)comboBox4.SelectedItem;

            premissionType premission = (premissionType)comboBox1.SelectedItem;
            var cat = new List<Category>();
                cat.Add(catItem);
            stockEntities.stockpermissions.Add(new stockpermission
            {
                date = DateTime.Now,
                type_id = premission.id,
                    Categories = cat

            }) ;
                stockEntities.SaveChanges();
                MessageBox.Show("New  Permission ADDEd Sucessfully ^_^");
                dataGridView1.DataSource = null;
                dataGridView2.DataSource = null;
            
            
            
        
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
            DataGridView dgv = new DataGridView();
            dgv = dataGridView1;
            int productId = int.Parse(dgv.CurrentRow.Cells[0].Value.ToString());
            dataGridView1.DataSource=dataGridView2.DataSource = null;
            
            Product product = stockEntities.Products.Find(productId);
            if(permissionMode== "exchange")
            {
                stockEntities.Products.Add(product);
                stockEntities.SaveChanges();
            }
            viewProduct.Add(product);
            stockEntities.Products.Remove(product);
            stockEntities.SaveChanges();
            Console.WriteLine(productList.Count);
            productList.RemoveAll(x=>x.product_id==productId);
            Console.WriteLine(productList.Count);

         
            dataGridView1.DataSource = productList;
            dataGridView2.DataSource = viewProduct;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }
    }
}
