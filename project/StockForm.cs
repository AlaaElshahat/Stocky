using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class StockForm : Form
    {
        StockEntities stockEntities = new StockEntities();
        public StockForm()
        {
            InitializeComponent();
            bunifuThinButton22.Enabled = false;
        }


        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox2.Text != "")
            {
              
                stockEntities.Stocks.Add(new Stock { name = textBox1.Text, address = textBox2.Text });
                stockEntities.SaveChanges();
                MessageBox.Show("Added Successfully ^_^");
                RefreshPage();
            }
            else
            {
                MessageBox.Show("Please,Enter Valid Data");
            }
          
                
        }

       

        private void bunifuThinButton22_Click_1(object sender, EventArgs e)
        {
            var stockitem = (Stock)comboBox1.SelectedItem;
             Stock stock = stockEntities.Stocks.Find(stockitem.id);
            if(stock!=null)
            {
                if(textBox1.Text != "" &&textBox2.Text != "")
                {

                    stock.name = textBox1.Text;
                    stock.address = textBox2.Text;
                    stockEntities.SaveChanges();
                    MessageBox.Show("UPDATED SUCCESSFULLY ^_^");
                   
                    RefreshPage();
                    bunifuThinButton22.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Please,Enter Valid Data");
                }
            }
            else
            {
                MessageBox.Show("INVALID DATA");
            }
        }

        private void StockForm_Load(object sender, EventArgs e)
        {

            RefreshPage();



        }
        void RefreshPage()
        {
            textBox1.Text = textBox2.Text = " ";
            var stock = from st in stockEntities.Stocks
                        select st;
            List<Stock> stockList = new List<Stock>();

            foreach (var item in stock)
            {
                stockList.Add(new Stock { id = item.id, name = item.name, address = item.address });

            }
            comboBox1.DataSource = stockList;
            comboBox1.DisplayMember = "name";
            var employees = from emp in stockEntities.Users select emp;
            List<User>employeeList=new List<User>();
            foreach(var emp in employees)
            {
                employeeList.Add(new User {user_id=emp.user_id,user_name=emp.user_name,user_role=emp.user_role,user_password=emp.user_password});
            }

            comboBox2.DataSource = employeeList;
           
            comboBox2.DisplayMember = "user_name";
        
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = "";
            var stockitem = (Stock)comboBox1.SelectedItem;

            
            Category categories = stockEntities.Categories.First(c => c.id == stockitem.id);
            Console.WriteLine(categories.id);
            var category = from p in stockEntities.Products
                           where p.Category_id == categories.id
                           select p;
            List<Product> productList = new List<Product>();
            foreach (var pro in category)
            {

                productList.Add(new Product { product_id=pro.product_id,product_name = pro.product_name ,price=pro.price,production_date=pro.production_date,expire_in=pro.expire_in,quantity=pro.quantity,code=pro.code,discount=pro.discount});   

            }
            dataGridView1.DataSource = productList;




        }

       

      

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            bunifuThinButton22.Enabled = true;
            var stockitem = (Stock)comboBox1.SelectedItem;
            Stock stock = stockEntities.Stocks.Find(stockitem.id);
            textBox1.Text = stock.name;
            textBox2.Text = stock.address;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
