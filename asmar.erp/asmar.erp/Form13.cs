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
    public partial class Form13 : Form
    {
        Form3 f3 = new Form3();
        public Form13()
        {
            InitializeComponent();
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            
            int c = 0;

            f3.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select Count(CID) from Customer", f3.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0].ToString());
                c++;

            }
            textBox1.Text = "C00" + c.ToString();
            f3.oleDbConnection1.Close();
            this.dataGridView1.BackgroundColor = Color.Teal;
            this.label3.Text = "Data Table Show";
            this.label10.Text = "CUSTOMER INSERTION";
            this.label10.ForeColor = Color.Teal;
            this.textBox8.ReadOnly = true;
            this.BackColor = Color.White;
            this.button1.ForeColor = Color.White;
            this.button2.ForeColor = Color.White;
            this.button4.ForeColor = Color.White;
            this.button3.ForeColor = Color.White;
            this.button1.BackColor = Color.Aqua;
            this.button3.BackColor = Color.Aqua;
            this.button2.BackColor = Color.Aqua;
            this.button4.BackColor = Color.Aqua;
            this.label1.ForeColor = Color.Aqua;
            this.label2.ForeColor = Color.Aqua;
            this.label3.ForeColor = Color.Aqua;
            this.button3.Text = "Disapprove";
            
            this.label4.ForeColor = Color.Aqua;
            this.label5.ForeColor = Color.Aqua;
            this.label6.ForeColor = Color.Aqua;
            this.label6.ForeColor = Color.Aqua;
            this.label7.ForeColor = Color.Aqua;
            this.label8.ForeColor = Color.Aqua;
            this.label9.ForeColor = Color.Aqua;

            this.label9.Text = "Customer Status";
            this.label1.Text = "Customer ID";
            this.label2.Text = "Customer Name";
          
            this.label4.Text = "Customer City";
            this.label5.Text = "Phone No";
            this.label6.Text = "Customer Address";
            this.label7.Text = "Company Name";
            this.label8.Text = "Customer Group";
            this.button1.Text = "Insert Customer Data";
            this.button2.Text = "Send For Approval";

            this.button4.Text = "Back";


            this.Text = "";
            string[] Ccity = { "Islamabad", "Lahore", "Karachi", "Peshawar", "GUjranwwala", "Sukkur" };
            this.comboBox1.Items.AddRange(Ccity);

            string[] Cgroup = { "HR", "Sales", "Consumer","Marketing" };
            this.comboBox2.Items.AddRange(Cgroup);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string st = "inactive";
            f3.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("insert into customer(CID,Cname,Ccity,ph1,Caddress,Ccpname,Cgroup,Cstatus) values(@CID,@Cname,@Ccity,@ph1,@Caddress,@Ccpname,@Cgroup,@Cstatus)", f3.oleDbConnection1);
            cmd.Parameters.AddWithValue("@CID", textBox1.Text);
            cmd.Parameters.AddWithValue("@Cname", textBox2.Text);

            cmd.Parameters.AddWithValue("@Ccity", comboBox1.Text);
            cmd.Parameters.AddWithValue("@ph1", textBox4.Text);
            cmd.Parameters.AddWithValue("@Caddress", textBox5.Text);
            cmd.Parameters.AddWithValue("@Ccpname", textBox6.Text);
            cmd.Parameters.AddWithValue("@Cgroup", comboBox2.Text);
            cmd.Parameters.AddWithValue("@Cstatus", st);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Record has been inserted");

            f3.oleDbConnection1.Close();
            {
                {
                    f3.oleDbConnection1.Open();
                    OleDbCommand cnd = new OleDbCommand("select * from customer", f3.oleDbConnection1);
                    OleDbDataReader dr = cnd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;
                    f3.oleDbConnection1.Close();
                }
            }

            this.textBox8.Text += "Customer ID :" + textBox1.Text + Environment.NewLine;
            this.textBox8.Text += "Customer Name :" + textBox2.Text + Environment.NewLine;

            this.textBox8.Text += "Customer City :" + comboBox1.Text + Environment.NewLine;
            this.textBox8.Text += "Phone No :" + textBox4.Text + Environment.NewLine;
            this.textBox8.Text += "Customer Address :" + textBox5.Text + Environment.NewLine;
            this.textBox8.Text += "Company Name :" + textBox6.Text + Environment.NewLine;
            this.textBox8.Text += "Customer Group :" + comboBox2.Text + Environment.NewLine;
            this.textBox8.Text += "Customer Status : Inactive " + Environment.NewLine;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form14 f14 = new Form14();
            f14.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form15 f15 = new Form15();
            f15.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
