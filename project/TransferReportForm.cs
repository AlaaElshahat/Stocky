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
    public partial class TransferReportForm : Form
    {
        StockEntities stockEntities = new StockEntities();
        public TransferReportForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void TransferReportForm_Load(object sender, EventArgs e)
        {
            var exchangePermission = from exp in stockEntities.stockpermissions
                                     where
                                      exp.type_id == 3
                                     select exp;
            var permList = new List<Object>();
            foreach (var item in exchangePermission)
            {
 
                foreach (var i in item.Categories)
                {
                 
                    foreach (var p in i.Products)
                    {
                        permList.Add(new { Permissiondate = item.date, catname = i.category1, productname = p.product_name, price = p.price, quantity = p.quantity,productindate=p.production_date
                        ,expirein=p.expire_in});
                    }
                }
            }
            dataGridView1.DataSource = permList;
        }
    }
}
