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
    public partial class ProdForm : Form
    {
        StockEntities stockEntities = new StockEntities();
       int productID;
       
        public ProdForm()
        {
            InitializeComponent();
            textBox6.Enabled = true;
            textBox7.Enabled = true;
        }

        private void ProdForm_Load(object sender, EventArgs e)
        {
            var categories = from c in stockEntities.Categories select c;
            List<Category> categoryList = new List<Category>();
            foreach(var cat in categories)
            {
                categoryList.Add(new Category { id=cat.id,category1=cat.category1});
            }
            comboBox1.DataSource = categoryList;
            comboBox1.DisplayMember = "category1";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text= textBox5.Text = textBox6.Text = textBox7.Text = "";
            bunifuThinButton21.Enabled = false;
            textBox6.Enabled = true;
            textBox7.Enabled = true;
            var catitem = (Category)comboBox1.SelectedItem;
            var Products = from p in stockEntities.Products
                           where  p.Category_id==catitem.id
                           select p;
            
            List<Product> productList = new List<Product>();
            foreach(var pro in Products)
            {
                productList.Add(
                    new Product
                    {
                        product_id = pro.product_id,
                        product_name = pro.product_name,
                        price = pro.price,
                        production_date = pro.production_date,
                        expire_in = pro.expire_in,
                        quantity = pro.quantity,
                        discount = pro.discount,
                        addedat=pro.addedat,
                        code=pro.code,

                    })  ;
            }
            dataGridView1.DataSource = productList;
           
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {

            var catitem = (Category)comboBox1.SelectedItem;
            
            textBox6.Enabled = true;
            textBox7.Enabled = true;
            try
            {
                string proddate = textBox6.Text + "";

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
            }
            catch(System.FormatException exc)
            {
                MessageBox.Show("Please enter date in this format dd/MM/yyyy ");
            }
          
            
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text=textBox5.Text =textBox6.Text=textBox7.Text= "";
            textBox6.Enabled = false;
            textBox7.Enabled = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = new DataGridView();
            dgv = dataGridView1;
           productID = int.Parse(dgv.CurrentRow.Cells[0].Value.ToString());
            bunifuThinButton21.Enabled = true;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            Product product = stockEntities.Products.Find(productID);
                if (product != null)
                {
                  
                    textBox1.Text = product.product_name;
                    textBox2.Text = product.price;
                    textBox3.Text = product.code;
                    textBox4.Text = product.discount;
                    textBox5.Text = product.quantity;
                    product.product_name = textBox1.Text;
                    product.price=textBox2.Text;
                    product.code = textBox3.Text;
                    product.quantity = textBox4.Text;




            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            Product product = stockEntities.Products.Find(productID);
            if (product != null)
            {

              if(textBox1.Text!=""&&textBox2.Text!=""&&textBox3.Text!="")
                {
                    product.product_name = textBox1.Text;
                    product.price = textBox2.Text;
                    product.code = textBox3.Text;
                    product.discount = textBox4.Text;
                    product.quantity = textBox5.Text;
                }
               else
                {
                    MessageBox.Show("Please,Enter valid data");
                }




            }
            stockEntities.SaveChanges();
            MessageBox.Show("Updated Successfully ^_^");
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = "";
            bunifuThinButton21.Enabled = false;
            textBox6.Enabled = true;
            textBox7.Enabled = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

    
    }
}
