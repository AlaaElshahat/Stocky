
namespace project
{
    partial class CustomerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerForm));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.ADD = new Bunifu.Framework.UI.BunifuThinButton2();
            this.Update = new Bunifu.Framework.UI.BunifuThinButton2();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(436, 50);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(336, 356);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(43, 113);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(284, 22);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(43, 202);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(284, 22);
            this.textBox2.TabIndex = 2;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(43, 276);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(284, 22);
            this.textBox3.TabIndex = 3;
            // 
            // ADD
            // 
            this.ADD.ActiveBorderThickness = 1;
            this.ADD.ActiveCornerRadius = 20;
            this.ADD.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.ADD.ActiveForecolor = System.Drawing.Color.White;
            this.ADD.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.ADD.BackColor = System.Drawing.SystemColors.Control;
            this.ADD.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ADD.BackgroundImage")));
            this.ADD.ButtonText = "ADD";
            this.ADD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ADD.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ADD.ForeColor = System.Drawing.Color.SeaGreen;
            this.ADD.IdleBorderThickness = 1;
            this.ADD.IdleCornerRadius = 20;
            this.ADD.IdleFillColor = System.Drawing.Color.White;
            this.ADD.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.ADD.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.ADD.Location = new System.Drawing.Point(14, 335);
            this.ADD.Margin = new System.Windows.Forms.Padding(5);
            this.ADD.Name = "ADD";
            this.ADD.Size = new System.Drawing.Size(181, 71);
            this.ADD.TabIndex = 4;
            this.ADD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ADD.Click += new System.EventHandler(this.ADD_Click);
            // 
            // Update
            // 
            this.Update.ActiveBorderThickness = 1;
            this.Update.ActiveCornerRadius = 20;
            this.Update.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.Update.ActiveForecolor = System.Drawing.Color.White;
            this.Update.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.Update.BackColor = System.Drawing.SystemColors.Control;
            this.Update.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Update.BackgroundImage")));
            this.Update.ButtonText = "Update";
            this.Update.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Update.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Update.ForeColor = System.Drawing.Color.SeaGreen;
            this.Update.IdleBorderThickness = 1;
            this.Update.IdleCornerRadius = 20;
            this.Update.IdleFillColor = System.Drawing.Color.White;
            this.Update.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.Update.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.Update.Location = new System.Drawing.Point(222, 335);
            this.Update.Margin = new System.Windows.Forms.Padding(5);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(181, 71);
            this.Update.TabIndex = 5;
            this.Update.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Update.Click += new System.EventHandler(this.Update_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tel";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Email";
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Update);
            this.Controls.Add(this.ADD);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "CustomerForm";
            this.Text = "CustomerForm";
            this.Load += new System.EventHandler(this.CustomerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private Bunifu.Framework.UI.BunifuThinButton2 ADD;
        private Bunifu.Framework.UI.BunifuThinButton2 Update;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}