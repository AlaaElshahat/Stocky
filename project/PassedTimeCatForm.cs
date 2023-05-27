using Microsoft.Reporting.WinForms;
using Newtonsoft.Json;
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
    public partial class PassedTimeCatForm : Form
    {
        StockEntities stockEntities = new StockEntities();
        DataTable pDt;
        public PassedTimeCatForm()
        {
            InitializeComponent();
        }

        private void PassedTimeCatForm_Load(object sender, EventArgs e)
        {
     
            
            List<int> number = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            comboBox1.DataSource = number;
            List<String> periodtime = new List<String>() { "Month", "Year" };
            comboBox2.DataSource = periodtime;
            /* ReportViewer reportViewer1 = new ReportViewer();
             reportViewer1.LocalReport.ReportEmbeddedResource = "passReport.rdlc";
             reportViewer1.LocalReport.DataSources.Clear();
             ReportDataSource rds = new ReportDataSource("reportDs", pDt);
             reportViewer1.LocalReport.DataSources.Add(rds);

             reportViewer1.LocalReport.Refresh();

             this.reportViewer1.RefreshReport();*/
          
       
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int period = int.Parse(comboBox1.Text);
            int passedTime = 
                comboBox2.Text == "Month" ? period * 30 : (period * 30 * 12)+5;
            Console.WriteLine(passedTime);
            var products = from  prod in stockEntities.Products
                             select prod;
            var productList = new List<Object>();
            foreach(var item in products)
            {
                Console.WriteLine(item.addedat);
                Console.WriteLine((DateTime.Now - ((DateTime)item.addedat)).Days);
                if((DateTime.Now-((DateTime)item.addedat)).Days==passedTime)
                {
                    productList.Add(new { productName = item.product_name, price = item.price, quantity = item.quantity,code=item.code });
                }

               
            }
            dataGridView1.DataSource = productList;
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(productList);
           pDt = JsonConvert.DeserializeObject<DataTable>(json);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {

            // BindingSource bs = (BindingSource)dataGridView1.DataSource;
            //reportViewer1.LocalReport.ReportPath = @"E:\iti courses\programmingdata\project\passReport.rdlc";

            //DataSet dataSet = new DataSet();
            //dataSet = (DataSet)dataGridView1.DataSource;
            //DataTable dt  =((DataView)dataGridView1.DataSource).Table;
            //(DataTable)bs.DataSource;
            Console.WriteLine("hi");
            Form2 form = new Form2();
            form.Show();
           
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
