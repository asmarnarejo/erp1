using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace zunaiberp
{
    public partial class Form14 : Form
    {
        Form3 f3 = new Form3();
        public Form14()
        {
            InitializeComponent();
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            this.button1.BackColor = Color.Aqua;
            this.button2.BackColor = Color.Aqua;
            this.button1.ForeColor = Color.White;
            this.button2.ForeColor = Color.White;
            this.label10.Text = "Customer Approval";
            this.label10.ForeColor = Color.Aqua;
            this.label1.ForeColor = Color.Aqua;
            this.label2.ForeColor = Color.Aqua;
           
            this.label4.ForeColor = Color.Aqua;
            this.label5.ForeColor = Color.Aqua;
            this.label6.ForeColor = Color.Aqua;
            this.label7.ForeColor = Color.Aqua;
            this.label8.ForeColor = Color.Aqua;
            this.label9.ForeColor = Color.Aqua;
            this.label1.Text = "Customer ID";
            this.label2.Text = "Customer Name";
            
            this.label4.Text = "Customer City";
            this.label5.Text = "Phone no";
            this.label6.Text = "Customer Address";
            this.label7.Text = "Company Name";
            this.label8.Text = "Customer Group";
            this.label9.Text = "Customer Status";
            this.button1.Text = "Approve";
            this.button2.Text = "DisApprove";

            f3.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select CID from Customer where Cstatus= 'InActive'", f3.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["CID"].ToString());

            }
            f3.oleDbConnection1.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            f3.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select * from Customer where CID='" + comboBox1.Text + "'", f3.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr["Cname"].ToString();
               
                textBox3.Text = dr["Ccity"].ToString();
                textBox4.Text = dr["Ph1"].ToString();
                textBox5.Text = dr["Caddress"].ToString();
                textBox6.Text = dr["Ccpname"].ToString();
                textBox7.Text = dr["Cgroup"].ToString();
                textBox8.Text = dr["Cstatus"].ToString();
            }
            f3.oleDbConnection1.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            f3.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Update Customer set Cstatus='Active' where CID ='" + comboBox1.Text + "'", f3.oleDbConnection1);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Customer Data has been approved");
            f3.oleDbConnection1.Close();


            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form15 f15 = new Form15();
            f15.Show();
            this.Hide();
        }
    }
}
