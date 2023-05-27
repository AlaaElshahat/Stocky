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
    public partial class StockReportForm : Form
    {
        StockEntities stockEntities = new StockEntities();
        
        List<Category> categoryList = new List<Category>();
        public StockReportForm()
        {
            InitializeComponent();
        }

        private void StockReportForm_Load(object sender, EventArgs e)
        {
            var stocks = from st in stockEntities.Stocks select st;
            List<Stock> stockList = new List<Stock>();
            foreach (var stock in stocks)
            {
              
                
                Console.WriteLine();
                Console.WriteLine("========================");
                stockList.Add(new Stock { id = stock.id, name = stock.name, address = stock.address, Categories = stock.Categories });
            }
            comboBox1.DataSource = stockList;
            comboBox1.DisplayMember = "name";
            Console.WriteLine(dateTimePicker1.Value);
            Console.WriteLine(dateTimePicker1.Value);



        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            Stock stock = (Stock)comboBox1.SelectedItem;

            var categoriesDetailsList = new List<Object>();
            foreach (Category i in stock.Categories)
            {

                if (i.added_date >= dateTimePicker1.Value && i.added_date < dateTimePicker2.Value)
                {
                    foreach (Product p in i.Products)
                    {
                        var categoryDetails = new
                        {
                            categoryname = i.category1,
                            categoryaddeddate = i.added_date,
                            productname = p.product_name,
                            productquantity = p.quantity
                            ,
                            productADDeddate = p.addedat
                        };
                        categoriesDetailsList.Add(categoryDetails);
                    }

                }



            }

            dataGridView1.DataSource = categoriesDetailsList;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }
    }
}
