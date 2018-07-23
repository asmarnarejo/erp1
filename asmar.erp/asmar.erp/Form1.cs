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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.label1.Text = "LOGIN PAGE";
            this.label2.Text = "USER NAME";
            this.label3.Text = "PASSWORD";
            this.button1.Text = "LOGIN";
            this.textBox1.Text = "USER NAME";
            this.textBox2.Text = "PASSWORD";
            this.button1.Visible = false;
            this.AcceptButton = button1;
            this.button1.BackColor = Color.Aqua;
            this.button1.ForeColor = Color.White;
            this.label1.ForeColor = Color.Aqua;
            this.label2.ForeColor = Color.White;
            this.label3.ForeColor = Color.White;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "hira" &&textBox2.Text == "hira")
            {
                Form2 f2 = new Form2();
                f2.Show();
                this.Hide();
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            this.textBox2.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "z")
            {
                this.button1.Visible = true;
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            this.panel1.BackColor = Color.Teal;
        }
    }
}