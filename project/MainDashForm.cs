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
    public partial class MainDashForm : Form
    {
        public MainDashForm()
        {
            InitializeComponent();
        }

        private void MainDashForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StockForm stockForm = new StockForm();
            stockForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CustomerForm customerForm = new CustomerForm();
            customerForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProdForm prodForm = new ProdForm();
            prodForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SupplierForm supplierForm = new SupplierForm();
            supplierForm.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            ReportForm reportForm = new ReportForm();
            reportForm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PermissionsForm permissionsForm = new PermissionsForm();
            permissionsForm.Show();
        }
    }
}
