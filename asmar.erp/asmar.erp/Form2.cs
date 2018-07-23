using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace zunaiberp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.label1.Text = "WELCOME";
            this.label1.ForeColor = Color.Aqua;
            this.label2.ForeColor = Color.Aqua;
            this.label3.ForeColor = Color.Aqua;
            this.BackColor = Color.White;
            this.label2.Text = "PURCHASING";
            this.label3.Text = "SELLING";
            this.button1.BackColor = Color.Aqua;
            this.button2.BackColor = Color.Aqua;
            this.button3.BackColor = Color.Aqua;
            this.button4.BackColor = Color.Aqua;
            this.button5.BackColor = Color.Aqua;
            this.button6.BackColor = Color.Aqua;
            this.button7.BackColor = Color.Aqua;
            this.button8.BackColor = Color.Aqua;
            this.button1.ForeColor = Color.White;
            this.button2.ForeColor = Color.White;
            this.button3.ForeColor = Color.White;
            this.button4.ForeColor = Color.White;
            this.button5.ForeColor = Color.White;
            this.button6.ForeColor = Color.White;
            this.button7.ForeColor = Color.White;
            this.button8.ForeColor = Color.White;
            this.button1.Text = "VENDOR";
            this.button2.Text = "PURCHASE ORDER";
            this.button3.Text = "GRN";
            this.button4.Text = "INVOICE PAYABLE";
            this.button5.Text = "CUSTOMER";

            this.button6.Text = "SALES ORDER";
            this.button7.Text = "DELIVER CHALLAN";

            this.button8.Text = "INVOICE RECEIVABLE";




        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form9 f9 = new Form9();
            f9.Show();
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form11 f11 = new Form11();
            f11.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form12 f12 = new Form12();
            f12.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form13 f13 = new Form13();
            f13.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SO so = new SO();
            so.Show();
            this.Hide();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Delivery_Challan dc = new Delivery_Challan();
            dc.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Invoice_Receivable ir = new Invoice_Receivable();
            ir.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
