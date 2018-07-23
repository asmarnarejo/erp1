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

    public partial class SO : Form
    {
        Form3 f3 = new Form3();

        string[] prds = new string[50];
        string[] pname = new string[50];
        int[] pqty = new int[50];
        int[] pprice = new int[50];
        int counter = 0;

        public SO()
        {
            InitializeComponent();
        }


        private void SO_Load(object sender, EventArgs e)
        {
            this.button1.Text = "ADD Products";
            this.button2.Text = "Create Sales Order";
            this.label1.Text = "Sales Order";
            this.BackColor = Color.White;
            this.label1.ForeColor = Color.Aqua;
            this.groupBox1.Text = "DEPART";
            this.groupBox2.Text = "Customer DETAIL";
            this.groupBox3.Text = "PRODUCT DETAIL";
            this.button1.BackColor = Color.Aqua;
            this.button2.BackColor = Color.Aqua;
            this.button2.ForeColor = Color.White;
            this.button1.ForeColor = Color.White;
            this.button3.Text = "Back";
            this.button3.BackColor = Color.Aqua;
            this.button3.ForeColor = Color.White;

            this.label2.Text = "Choose Department";
            this.label3.Text = "SOID";
            this.label4.Text = "SO Creation Date";
            this.label5.Text = "Delivery Date";
            this.label6.Text = "Customer ID";
            this.label7.Text = "Customer Name";
            this.label8.Text = "Company Name";
            this.label9.Text = "Phone NO";
            this.label10.Text = "Product ID";
            this.label11.Text = "Product Name";
            this.label12.Text = "Product Price";
            this.label13.Text = "Product Quantity";
            this.label14.Text = "Total Amount";
            this.label15.Text = "Show Total Product";
            {
                f3.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("Select Cgroup from Customer", f3.oleDbConnection1);
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["Cgroup"].ToString());
                }
                f3.oleDbConnection1.Close();

            }
            {
                f3.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("select pid from products", f3.oleDbConnection1);
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox3.Items.Add(dr["pid"].ToString());

                }
                f3.oleDbConnection1.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                int c = 0;
                f3.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("select count(SOID) from So where CDept='" + comboBox1.Text + "'", f3.oleDbConnection1);
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    c = Convert.ToInt32(dr[0]); c++;
                }
                if (comboBox1.Text == "Consumer")
                {
                    textBox1.Text = "Con-00" + c.ToString() + "-" + System.DateTime.Today.Year;
                }
                else if (comboBox1.Text == "Marketing")
                {
                    textBox1.Text = "MR-00" + c.ToString() + "-" + System.DateTime.Today.Year;
                }
                else if (comboBox1.Text == "HR")
                {
                    textBox1.Text = "HR-00" + c.ToString() + "-" + System.DateTime.Today.Year;
                }
                else if (comboBox1.Text == "Sales")
                {
                    textBox1.Text = "SALES-00" + c.ToString() + "-" + System.DateTime.Today.Year;
                }
                f3.oleDbConnection1.Close();
            }
            {
                f3.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("select CID from Customer where (Cgroup=@Cgroup) AND (Cstatus='Active')", f3.oleDbConnection1);
                cmd.Parameters.AddWithValue("@Cgroup", comboBox1.Text);
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    this.comboBox2.Items.Clear();
                    comboBox2.Items.Add(dr["CID"].ToString());
                }
                f3.oleDbConnection1.Close();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            f3.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select * from Customer where CID='" + comboBox2.Text + "'", f3.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox2.Text = dr["Cname"].ToString();
                textBox3.Text = dr["Ccpname"].ToString();
                textBox4.Text = dr["ph1"].ToString();

            }
            f3.oleDbConnection1.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            f3.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select * from products where pid='" + comboBox3.Text + "'", f3.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox5.Text = dr["pname"].ToString();
                textBox6.Text = dr["baseprice"].ToString();

            }
            f3.oleDbConnection1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int basprice = 0;
            int productqty = 0;

            basprice = Convert.ToInt32(textBox6.Text);
            productqty = Convert.ToInt32(textBox7.Text);
            this.textBox8.Text = Convert.ToString(basprice * productqty);
            prds[counter] = comboBox3.Text;
            pqty[counter] = Convert.ToInt32(textBox7.Text);
            pprice[counter] = Convert.ToInt32(textBox8.Text);
            counter++;

            this.textBox9.Text += "***Sales order Details***" + Environment.NewLine;
            this.textBox9.Text += "Department:" + comboBox1.Text + Environment.NewLine;
            this.textBox9.Text += "SOID:" + textBox1.Text + Environment.NewLine;
            this.textBox9.Text += "SO Creation Date:" + dateTimePicker1 + Environment.NewLine;
            this.textBox9.Text += "Delivery Date:" + dateTimePicker2 + Environment.NewLine;


            this.textBox9.Text += "***Customer Detsils***" + Environment.NewLine;
            this.textBox9.Text += "Customer ID:" + comboBox2.Text + Environment.NewLine;
            this.textBox9.Text += "Customer Name:" + textBox2.Text + Environment.NewLine;
            this.textBox9.Text += "Company Name:" + textBox3.Text + Environment.NewLine;
            this.textBox9.Text += "Phone No:" + textBox4.Text + Environment.NewLine;


            this.textBox9.Text += "***Product Details***" + Environment.NewLine;
            this.textBox9.Text += "Product ID:" + comboBox3.Text + Environment.NewLine;
            this.textBox9.Text += "Product Name:" + textBox5.Text + Environment.NewLine;
            this.textBox9.Text += "Product Price:" + textBox6.Text + Environment.NewLine;
            this.textBox9.Text += "Product Quantity" + textBox7.Text + Environment.NewLine;
            this.textBox9.Text += "Total Amount" + textBox8.Text + Environment.NewLine;

            MessageBox.Show("Value edit");
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
                f3.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("insert into SO(SOID,CDept,Cname,CID,Ccpph,SOdate,ddate,TotalAmount,Approve,status)values(@SOID,@Cdept,@Cname,@CID,@Ccpph,@SOdate,@ddate,@TotalAmount,@Approve,@status)", f3.oleDbConnection1);
                cmd.Parameters.AddWithValue("@SOID", this.textBox1.Text);
                cmd.Parameters.AddWithValue("@Cdept", this.comboBox1.Text);
                cmd.Parameters.AddWithValue("@Cname", this.textBox2.Text);
                cmd.Parameters.AddWithValue("@CID", this.comboBox2.Text);
                cmd.Parameters.AddWithValue("@Ccpph", this.textBox4.Text);

                cmd.Parameters.AddWithValue("@SOdate", this.dateTimePicker1);
                cmd.Parameters.AddWithValue("@ddate", this.dateTimePicker2);
                cmd.Parameters.AddWithValue("@TotalAmount", this.textBox8.Text);
                cmd.Parameters.AddWithValue("@Approve=", "Approved");
                cmd.Parameters.AddWithValue("@Status", "Open");


                cmd.ExecuteNonQuery();
                f3.oleDbConnection1.Close();
                MessageBox.Show("Transaction Done!");
            }

            {
                {
                    try
                    {
                        for (int counter = 0; counter < prds.Length; counter++)
                        {

                            f3.oleDbConnection1.Open();
                            OleDbCommand cmd = new OleDbCommand("insert into SO Products(SOID,Sid,Sname,SQty)values (@SOID,@Sid,@Sname,@SQty)", f3.oleDbConnection1);
                            cmd.Parameters.AddWithValue("@SOID", this.textBox1.Text);
                            cmd.Parameters.AddWithValue("@Sid", prds[counter]);

                            cmd.Parameters.AddWithValue("@Sname", pname[counter]);
                            cmd.Parameters.AddWithValue("@SQty", pqty[counter]);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Multiple Products Added");
                            Form2 f2 = new Form2();
                            f2.Show();
                            f3.oleDbConnection1.Close();
                        }
                    }
                    catch (OleDbException ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }
    }
}