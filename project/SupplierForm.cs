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
    public partial class SupplierForm : Form
    {
        StockEntities stockEntities = new StockEntities();
        int supplierId;
        public SupplierForm()
        {
            InitializeComponent();
            bunifuThinButton22.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SupplierForm_Load(object sender, EventArgs e)
        {
            refPage();

        }

        public void refPage()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
            var supplier = from supply in stockEntities.Suppliers
                           select supply;
            List<Supplier> supplierList = new List<Supplier>();
            foreach (var sypluieritem in supplier)
            {
                supplierList.Add(new Supplier
                {
                    id = sypluieritem.id,
                    name = sypluieritem.name,
                    tel = sypluieritem.tel,
                    email = sypluieritem.email,
                    Fax = sypluieritem.Fax
                });
            }
            dataGridView1.DataSource = supplierList;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = new DataGridView();
            bunifuThinButton22.Enabled = true;
            dgv = dataGridView1;
            supplierId = int.Parse(dgv.CurrentRow.Cells[0].Value.ToString());
            Supplier supplierperson = stockEntities.Suppliers.Find(supplierId);
            if(supplierperson!=null)
            {
               
                
                    textBox1.Text = supplierperson.name;
                    textBox2.Text = supplierperson.tel;
                    textBox3.Text = supplierperson.email;
                    textBox4.Text = supplierperson.Fax;
             
               
            }
            
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            Supplier supplier = stockEntities.Suppliers.Find(supplierId);
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                supplier.name = textBox1.Text;
                supplier.tel = textBox1.Text;
                supplier.email = textBox3.Text;
                supplier.Fax = textBox4.Text;
                stockEntities.SaveChanges();
                MessageBox.Show("UPDATED SUCCESSFULLY ^_^");
                refPage();
                bunifuThinButton22.Enabled = false;
            }
            else
            {
                MessageBox.Show("Please ,Enter Valid Data");
            }
           
         


        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                stockEntities.Suppliers.Add(new Supplier
                {
                    name = textBox1.Text,
                    tel = textBox2.Text,
                    email = textBox3.Text
        ,
                    Fax = textBox4.Text
                });
                stockEntities.SaveChanges();
                MessageBox.Show("ADDED SUCCESSFULLY ^_^");
                refPage();
            }
            else
            {
                MessageBox.Show("Please, Enter Valid data");
            }


            
           
        }
    }
}
