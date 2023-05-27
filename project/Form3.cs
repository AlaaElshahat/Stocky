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
    public partial class Form3 : Form
    {
        StockEntities stockEntities = new StockEntities();
        int ProductId;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            var premmisions = from prem in stockEntities.stockpermissions select prem;
            foreach(var item in premmisions)
            {
                comboBox1.Items.Add(item.id);
            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int premId = int.Parse(comboBox1.Text);
            var prem = stockEntities.stockpermissions.Find(premId);
            textBox1.Text = prem.date.ToString();
            var typeprem = stockEntities.premissionTypes.Find(prem.type_id);
            textBox2.Text = typeprem.type.ToString();
            var exchangePermission = from exp in stockEntities.stockpermissions
                                     where
                                      exp.type_id == premId
                                     select exp;
            var permList = new List<Object>();
            foreach (var item in exchangePermission)
            {

                foreach (var i in item.Categories)
                {

                    foreach (var p in i.Products)
                    {
                        permList.Add(new
                        {
                            Permissiondate = item.date,
                            catname = i.category1,
                            productid = p.product_id,
                            productname = p.product_name,
                            price = p.price,
                            quantity = p.quantity,
                            productindate = p.production_date
                        ,
                            expirein = p.expire_in
                        }) ;
                    }
                }
            }
            dataGridView1.DataSource = permList;

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            int premId = int.Parse(comboBox1.Text);
            var prem = stockEntities.stockpermissions.Find(premId);
            if(prem!=null)
            {
                Product product = stockEntities.Products.Find(ProductId);
                if (product != null)
                { 
                    if(textBox3.Text!=""&&textBox4.Text!="")
                    {
                        textBox3.Text = product.product_name;
                        textBox4.Text = product.quantity;
                        stockEntities.SaveChanges();
                        MessageBox.Show("updated Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Please ,Enter Valid data");
                    }
                   

                }
                
               
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = new DataGridView();
           
            dgv = dataGridView1;
             ProductId = int.Parse(dgv.CurrentRow.Cells[2].Value.ToString());
            Product product = stockEntities.Products.Find(ProductId);
            if (product != null)
            {
                textBox3.Text = product.product_name;
                textBox4.Text = product.quantity;
                 

            }
        }
    }
}
