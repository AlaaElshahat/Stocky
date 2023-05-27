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
    public partial class Form1 : Form
    {
        StockEntities stockEntity = new StockEntities();
        public Form1()
        {
            InitializeComponent();
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainDashForm mainDashForm = new MainDashForm();
            mainDashForm.Show();
            Form1 form1 = new Form1();
            form1.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
