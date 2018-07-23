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
    public partial class Form9 : Form
    {
        Form3 f3 = new Form3();


        string[] prds = new string[50];
        string[] pname = new string[50];
        int[] pqty = new int[50];
        int[] pprice = new int[50];
        int counter = 0;


        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            this.button1.Text = "ADD Products";
            this.button2.Text = "Create Purchase Order";
            this.label1.Text = "Purchase Order";
            this.BackColor = Color.White;
            this.label1.ForeColor = Color.Aqua;
            this.groupBox1.Text = "DEPART";
            this.groupBox2.Text = "VENDOR DETAIL";
            this.groupBox3.Text = "PRODUCT DETAIL";
            this.button1.BackColor = Color.Aqua;
            this.button2.BackColor = Color.Aqua;
            this.button3.BackColor = Color.Aqua;
            this.button2.ForeColor = Color.White;
            this.button1.ForeColor = Color.White;
            this.button3.ForeColor = Color.White;
            this.button3.Text = "BACK";

            this.label2.Text = "Choose Department";
            this.label3.Text = "POID";
            this.label4.Text = "PO Creation Date";
            this.label5.Text = "Delivery Date";
            this.label6.Text = "Vendor ID";
            this.label7.Text = "Vendor Name";
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
                OleDbCommand cmd = new OleDbCommand("Select vgroup from vendor", f3.oleDbConnection1);
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["vgroup"].ToString());
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

        private void textBox6_TextChanged(object sender, EventArgs e)
        {


        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                int c = 0;
                f3.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("select count(poid) from po where vdept='" + comboBox1.Text + "'", f3.oleDbConnection1);
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
                OleDbCommand cmd = new OleDbCommand("select vid from vendor where (vgroup=@vgroup) AND (vstatus='Active')", f3.oleDbConnection1);
                cmd.Parameters.AddWithValue("@vgroup", comboBox1.Text);
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    this.comboBox2.Items.Clear();
                    comboBox2.Items.Add(dr["vid"].ToString());
                }
                f3.oleDbConnection1.Close();
            }
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

            this.textBox9.Text += "***Purchase order***" + Environment.NewLine;
            this.textBox9.Text += "Department:"+comboBox1.Text + Environment.NewLine;
            this.textBox9.Text += "POID:"+textBox1.Text+  Environment.NewLine;
            this.textBox9.Text += "PO Creation Date:" + dateTimePicker1+ Environment.NewLine;
            this.textBox9.Text += "Delivery Date:" +dateTimePicker2+ Environment.NewLine;


            this.textBox9.Text += "***Vendor Detsils***" + Environment.NewLine;
            this.textBox9.Text += "Vendor ID:"+comboBox2.Text + Environment.NewLine;
            this.textBox9.Text += "Vendor Name:"+ textBox2.Text + Environment.NewLine;
            this.textBox9.Text += "Company Name:"+textBox3.Text + Environment.NewLine;
            this.textBox9.Text += "Phone No:" +textBox4.Text+ Environment.NewLine;


            this.textBox9.Text += "***Product Details***" + Environment.NewLine;
            this.textBox9.Text += "Product ID:"+ comboBox3.Text+ Environment.NewLine;
            this.textBox9.Text += "Product Name:" +textBox5.Text+ Environment.NewLine;
            this.textBox9.Text += "Product Price:"+textBox6.Text + Environment.NewLine;
            this.textBox9.Text += "Product Quantity"+textBox7.Text + Environment.NewLine;
            this.textBox9.Text += "Total Amount"+textBox8.Text + Environment.NewLine;

            MessageBox.Show("Value edit");
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            f3.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select * from vendor where vid='" + comboBox2.Text + "'", f3.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox2.Text = dr["vname"].ToString();
                textBox3.Text = dr["cpname"].ToString();
                textBox4.Text = dr["ph1"].ToString();

            }
            f3.oleDbConnection1.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            {
                f3.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("insert into PO(poid,vdept,vname,vid,vcpph,podate,ddate,TotalAmount,Status)values(@poid,@vdept,@vname,@vid,@vcpph,@podate,@ddate,@TotalAmount,@Status)", f3.oleDbConnection1);
                cmd.Parameters.AddWithValue("@poid", this.textBox1.Text);
                cmd.Parameters.AddWithValue("@vdept", this.comboBox1.Text);
                cmd.Parameters.AddWithValue("@vname", this.textBox2.Text);
                cmd.Parameters.AddWithValue("@vid", this.comboBox2.Text);
                cmd.Parameters.AddWithValue("@vcpph", this.textBox4.Text);

                cmd.Parameters.AddWithValue("@podate", this.dateTimePicker1);
                cmd.Parameters.AddWithValue("@ddate", this.dateTimePicker2);
                cmd.Parameters.AddWithValue("@TotalAmount", this.textBox8.Text);
                cmd.Parameters.AddWithValue("@status=", "Open");
                cmd.ExecuteNonQuery();
                f3.oleDbConnection1.Close();
                MessageBox.Show("Transaction Done!");
            }

            {
                {
                    try{
                        for (int counter = 0; counter < prds.Length; counter++)
                        {

                            f3.oleDbConnection1.Open();
                            OleDbCommand cmd = new OleDbCommand("insert into POProducts(POID,Pid,Pname,PQty)values (@POID,@Pid,@Pname,@PQty)", f3.oleDbConnection1);
                            cmd.Parameters.AddWithValue("@POID", this.textBox1.Text);
                            cmd.Parameters.AddWithValue("@Pid", prds[counter]);

                            cmd.Parameters.AddWithValue("@Pname", pname[counter]);
                            cmd.Parameters.AddWithValue("@PQty", pqty[counter]);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Multiple Products Added");
                        Form2 f2 = new Form2();
                        f2.Show();
                            f3.oleDbConnection1.Close();
                        }
                    }
                        catch(OleDbException ex)
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }
            
        }

    }
               
     
        





