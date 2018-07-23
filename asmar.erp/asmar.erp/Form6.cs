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
    public partial class Form6 : Form
    {
        Form3 f3 = new Form3();

        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            int c = 0;

            f3.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select Count(VID) from Vendor",f3.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0].ToString());
                c++;

            }
            textBox1.Text = "V00"+c.ToString();
            f3.oleDbConnection1.Close();
            
            this.label10.Text = "VENDER INSERTION";
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
            this.label4.ForeColor = Color.Aqua;
            this.label5.ForeColor = Color.Aqua;
            this.label6.ForeColor = Color.Aqua;
            this.label6.ForeColor = Color.Aqua;
            this.label7.ForeColor = Color.Aqua;
            this.label8.ForeColor = Color.Aqua;
            this.label9.ForeColor = Color.Aqua;
            this.label11.ForeColor = Color.Aqua;
            this.dataGridView1.BackgroundColor = Color.Aqua;
            this.label11.Text = "Show Table Data";
            this.label9.Text = "Vendor Status";
            this.label1.Text = "Vendor ID";
            this.label2.Text = "Vendor Name";
            this.label3.Text = "Vendor Code";
            this.label4.Text = "Vendor City";
            this.label5.Text = "Phone No";
            this.label6.Text = "Vendor Address";
            this.label7.Text = "Company Name";
            this.label8.Text = "Vendor Group";
            this.button1.Text = "Insert Vendor";
            this.button2.Text = "Send For Approval";
            this.button3.Text = "Disaprove";
            
            this.button4.Text = "Back";


            this.Text = "INSERT VENDOR";
            string[] Vcity = { "Islamabad", "Lahore", "Karachi", "Peshawar","GUjranwwala","Sukkur" };
            this.comboBox1.Items.AddRange(Vcity);

            string[] Vgroup = { "HR", "Sales", "Consumer" };
            this.comboBox2.Items.AddRange(Vgroup);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                {
                    {

                        string st = "inactive";
                        f3.oleDbConnection1.Open();
                        OleDbCommand cmd = new OleDbCommand("insert into vendor(vid,vname,vcode,vcity,ph1,vaddress,cpname,vgroup,vstatus) values(@vid,@vname,@vcode,@vcity,@ph1,@vaddress,@cpname,@vgroup,@vstatus)", f3.oleDbConnection1);
                        cmd.Parameters.AddWithValue("@vid", textBox1.Text);
                        cmd.Parameters.AddWithValue("@vname", textBox2.Text);
                        cmd.Parameters.AddWithValue("@vcode", textBox3.Text);
                        cmd.Parameters.AddWithValue("@vcity", comboBox1.Text);
                        cmd.Parameters.AddWithValue("@ph1", textBox4.Text);
                        cmd.Parameters.AddWithValue("@vaddress", textBox5.Text);
                        cmd.Parameters.AddWithValue("@cpname", textBox6.Text);
                        cmd.Parameters.AddWithValue("@vgroup", comboBox2.Text);
                        cmd.Parameters.AddWithValue("@vstatus", st);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Record has been inserted");

                        f3.oleDbConnection1.Close();
                        {
                            f3.oleDbConnection1.Open();
                            OleDbCommand cnd = new OleDbCommand("select * from Vendor", f3.oleDbConnection1);
                            OleDbDataReader dr = cnd.ExecuteReader();
                            DataTable dt = new DataTable();
                            dt.Load(dr);
                            dataGridView1.DataSource = dt;
                            f3.oleDbConnection1.Close();
                        }

                        this.textBox8.Text += "Vendor ID :" + textBox1.Text + Environment.NewLine;
                        this.textBox8.Text += "Vendor Name :" + textBox2.Text + Environment.NewLine;
                        this.textBox8.Text += "Vendor Code :" + textBox3.Text + Environment.NewLine;
                        this.textBox8.Text += "Vendor City :" + comboBox1.Text + Environment.NewLine;
                        this.textBox8.Text += "Phone No :" + textBox4.Text + Environment.NewLine;
                        this.textBox8.Text += "Vendor Address :" + textBox5.Text + Environment.NewLine;
                        this.textBox8.Text += "Company Name :" + textBox6.Text + Environment.NewLine;
                        this.textBox8.Text += "Vendor Group :" + comboBox2.Text + Environment.NewLine;
                        this.textBox8.Text += "Vendor Status : Inactive " + Environment.NewLine;



                    }
            }
        }
    }
       private void button2_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form10 f10 = new Form10();
            f10.Show();
            this.Hide();
        }
    }
}
