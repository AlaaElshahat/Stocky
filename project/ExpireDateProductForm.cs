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
    public partial class ExpireDateProductForm : Form
    {
        StockEntities stockEntities = new StockEntities();
        public ExpireDateProductForm()
        {
            InitializeComponent();
        }

        private void ExpireDateProductForm_Load(object sender, EventArgs e)
        {
            List<int> number = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            comboBox1.DataSource = number;
            List<String> periodtime = new List<String>() { "Month", "Year" };
            comboBox2.DataSource = periodtime;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int period = int.Parse(comboBox1.Text);
            Console.WriteLine(period);
            int passedTime=  comboBox2.Text == "Month" ? period * 30 : period * 30 * 12;
            Console.WriteLine(passedTime);
            var products = from prod in stockEntities.Products
                           select prod;
            var productList = new List<Object>();
            foreach (var item in products)
            {
                Console.WriteLine(item.product_name);
                Console.WriteLine(item.expire_in);
                Console.WriteLine(( ((DateTime)item.expire_in)-DateTime.Now).Days);
                if (( ((DateTime)item.expire_in)-DateTime.Now).Days == passedTime)
                {
                    productList.Add(new { productName = item.product_name, price = item.price, quantity = item.quantity, code = item.code });
                }


            }
            dataGridView1.DataSource = productList;
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

        }
    }
}
