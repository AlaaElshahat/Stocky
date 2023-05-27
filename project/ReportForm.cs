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
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            StockReportForm stockReport = new StockReportForm();
            stockReport.Show();
            
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            CatProdReportForm catProdReportForm = new CatProdReportForm();
            catProdReportForm.Show();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            PassedTimeCatForm passedTimeCatForm = new PassedTimeCatForm();
            passedTimeCatForm.Show();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            ExpireDateProductForm expireDateProductForm = new ExpireDateProductForm();
            expireDateProductForm.Show();
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            TransferReportForm transferReportForm = new TransferReportForm();
            transferReportForm.Show();
        }
    }
}
