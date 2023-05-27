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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            reportViewer1.LocalReport.ReportEmbeddedResource = "Report1.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
