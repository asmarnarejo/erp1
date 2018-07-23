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
    public partial class Form7 : Form
    {
        Form3 f3 = new Form3();
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            this.button1.BackColor = Color.Aqua;
            this.button2.BackColor = Color.Aqua;
            this.button1.ForeColor = Color.White;
            this.button2.ForeColor = Color.White;
            this.label10.Text = "Approval";
            this.label10.ForeColor = Color.Aqua;
            this.label1.ForeColor = Color.Aqua;
            this.label2.ForeColor = Color.Aqua;
            this.label3.ForeColor = Color.Aqua;
            this.label4.ForeColor = Color.Aqua;
            this.label5.ForeColor = Color.Aqua;
            this.label6.ForeColor = Color.Aqua;
            this.label7.ForeColor = Color.Aqua;
            this.label8.ForeColor = Color.Aqua;
            this.label9.ForeColor = Color.Aqua;
            this.label1.Text = "Vendor ID";
            this.label2.Text = "Vendor Name";
            this.label3.Text = "Vendor Code";
            this.label4.Text = "Vendor City";
            this.label5.Text = "Phone no";
            this.label6.Text = "Vendor Address";
            this.label7.Text = "Company Name";
            this.label8.Text = "Vendor Group";
            this.label9.Text = "Vendor Status";
            this.button1.Text = "Approve";
            this.button2.Text = "DisApprove";

            f3.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select vid from vendor where vstatus= 'InActive'", f3.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["vid"].ToString());

            }
            f3.oleDbConnection1.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            f3.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select * from vendor where vid='" + comboBox1.Text + "'", f3.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr["Vname"].ToString();
                textBox2.Text = dr["Vcode"].ToString();
                textBox3.Text = dr["Vcity"].ToString();
                textBox4.Text = dr["Ph1"].ToString();
                textBox5.Text = dr["vaddress"].ToString();
                textBox6.Text = dr["Cpname"].ToString();
                textBox7.Text = dr["Vgroup"].ToString();
                textBox8.Text = dr["Vstatus"].ToString();
            }
            f3.oleDbConnection1.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            f3.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Update vendor set vstatus='Active' where vid ='" + comboBox1.Text + "'", f3.oleDbConnection1);
            cmd.ExecuteNonQuery();
            MessageBox.Show("vendor has been approved");
            f3.oleDbConnection1.Close();


            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
           ;
        }

    private void button2_Click(object sender, EventArgs e)
        {
      
            MessageBox.Show("Vender DisApproved" + Environment.NewLine);
            Form6 f6 = new Form6();
            f6.Show();
            this.Hide();
        }

    private void button2_Click_1(object sender, EventArgs e)
    {
        Form10 f10 = new Form10();
        f10.Show();
        this.Hide();
    }
    }
}

