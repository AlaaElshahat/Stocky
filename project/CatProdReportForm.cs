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
    public partial class CatProdReportForm : Form
    {
        StockEntities stockEntities = new StockEntities();
        public CatProdReportForm()
        {
            InitializeComponent();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void CatProdReportForm_Load(object sender, EventArgs e)
        {
            var stocks = from st in stockEntities.Stocks select st;
            var categories = from cat in stockEntities.Categories select cat;
            List<Category> categoriesList = new List<Category>();
            List<Stock> stockList = new List<Stock>();
            foreach (var item in stocks)
            {
                stockList.Add(new Stock { id = item.id, name = item.name, address = item.address, Categories = item.Categories });
                
            }
            checkedListBox1.DataSource = stockList;
            checkedListBox1.DisplayMember = "name";
            foreach (var item in categories)
            {
                categoriesList.Add(new Category { id = item.id, category1 = item.category1, added_date = item.added_date ,Products=item.Products});
            }
            comboBox1.DisplayMember = "category1";
            comboBox1.DataSource = categoriesList;
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
             Category cat= (Category)comboBox1.SelectedItem;
             List<Stock> stockList = (checkedListBox1.CheckedItems).OfType<Stock>().ToList();
            var category = new List<Object>();
            foreach (var item in stockList)
            {
                 foreach(var categ in  item.Categories)
                {
                    if(cat.id==categ.id)
                    {

                      
                      
                        foreach (Product p in cat.Products)
                        {
                            if (p.addedat >= dateTimePicker1.Value && p.addedat < dateTimePicker2.Value)
                            {
                                category.Add(new
                                {

                                    productname = p.product_name,
                                    productquantity = p.quantity
                                   , productcode = p.code,
                                     price=p.price,
                                    discount = p.discount, 
                                }) ;
                            }
                                
                        }
                      
                    }
                }
            }

            dataGridView1.DataSource = category;

        }
      
    }
}
