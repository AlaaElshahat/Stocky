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
    public partial class CustomerForm : Form
    {
        StockEntities stockEntities = new StockEntities();
        int customerID;
        public CustomerForm()
        {
            InitializeComponent();
            Update.Enabled = false;
        }

        private void Update_Click(object sender, EventArgs e)
        {
             Customer customer = stockEntities.Customers.Find(customerID);
            customer.name = textBox1.Text;
            customer.tel = textBox2.Text;
            customer.email = textBox3.Text;
            
            if(textBox1.Text !=""&&textBox2.Text!=""&&textBox3.Text!="")
            {
                stockEntities.SaveChanges();
                MessageBox.Show("UPDATED SUCCESSFULLY ^_^");
                refPage();
                Update.Enabled = false;
            }
            else
            {
                MessageBox.Show("Please,Enter valid Data");
            }
            
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            refPage();
        }
       void refPage()
        {
            textBox1.Text = textBox2.Text = textBox3.Text  = "";
            var customer = from customers in stockEntities.Customers
                           select customers;
            List<Customer> customersList = new List<Customer>();
            foreach (var item in customer)
            {
                customersList.Add(new  Customer
                {
                    id = item.id,
                    name = item.name,
                    tel = item.tel,
                    email =item.email,
                  
                });
            }
            dataGridView1.DataSource = customersList;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = new DataGridView();
            Update.Enabled = true;
            dgv = dataGridView1;
            customerID = int.Parse(dgv.CurrentRow.Cells[0].Value.ToString());
            Customer customer = stockEntities.Customers.Find(customerID);
            if (customer != null)
            {
                textBox1.Text = customer.name;
                textBox2.Text = customer.tel;
                textBox3.Text = customer.email;
                
            }
        }

        private void ADD_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                stockEntities.Customers.Add(new Customer
                {
                    name = textBox1.Text,
                    tel = textBox2.Text,
                    email = textBox3.Text


                });
                stockEntities.SaveChanges();
                MessageBox.Show("ADDED SUCCESSFULLY ^_^");
                refPage();

            }
            else
            {
                MessageBox.Show("Please,Enter valid data");
            }

        }
           
    }
}
