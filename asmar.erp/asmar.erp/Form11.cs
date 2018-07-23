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
    public partial class Form11 : Form
    {
        Form3 f3 = new Form3();
        public Form11()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Form11_Load(object sender, EventArgs e)
        {

            {
                
                    int c = 0;
                    f3.oleDbConnection1.Open();
                    OleDbCommand cmd = new OleDbCommand("Select count(grnid) from grn", f3.oleDbConnection1);
                    OleDbDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        c = Convert.ToInt32(dr[0].ToString());
                        c++;
                    }
                    
                        textBox5.Text = "GRN-00" + c.ToString() + "_" + System.DateTime.Today.Year;
                    
                    f3.oleDbConnection1.Close();
                }
            {
                this.dataGridView1.BackgroundColor = Color.Teal;
                this.BackColor = Color.White;
                this.Text = "";
                f3.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("select POID from PO where status ='OPen'", f3.oleDbConnection1);
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["POID"].ToString());
                }

                f3.oleDbConnection1.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            {
                f3.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("select * from PO where POID='" + comboBox1.Text + "'", f3.oleDbConnection1);
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    textBox1.Text = dr["vid"].ToString();
                    textBox2.Text = dr["vname"].ToString();
                    textBox3.Text = dr["vdept"].ToString();
                    textBox4.Text = dr["TotalAmount"].ToString();

                }
                f3.oleDbConnection1.Close();
            }
            
               
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            {
                f3.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("insert into GRNProducts(grnid,Vname,pqty)values(@grnid,@Vname,@pqty)", f3.oleDbConnection1);
                cmd.Parameters.AddWithValue("@grnid", this.textBox5.Text);
                cmd.Parameters.AddWithValue("@Vname", this.textBox2.Text);
                cmd.Parameters.AddWithValue("@pqty", this.textBox6.Text);
                cmd.ExecuteNonQuery();
                f3.oleDbConnection1.Close();
                MessageBox.Show("Data Of GRN Products");
            }
            {
               
                {
                    f3.oleDbConnection1.Open();
                    OleDbCommand cmd = new OleDbCommand("insert into GRN(GRNID,POID,VName,VID,TotalAmount,VDept,status)values(@GRNID,@POID,@VName,@VID,@TotalAmount,@VDept,@status)", f3.oleDbConnection1);
                    cmd.Parameters.AddWithValue("@GRNID", this.textBox5.Text);
                    cmd.Parameters.AddWithValue("@POID", this.comboBox1.Text);
                    cmd.Parameters.AddWithValue("@Vname", this.textBox2.Text);
                    cmd.Parameters.AddWithValue("@VID", this.textBox1.Text);
                    cmd.Parameters.AddWithValue("@TotalAmount", this.textBox4.Text);
                    cmd.Parameters.AddWithValue("@VDept", this.textBox3.Text);
                    cmd.Parameters.AddWithValue("@status=", "Open");
                    cmd.ExecuteNonQuery();
                    f3.oleDbConnection1.Close();

                    MessageBox.Show("GRN has been created");


                }
                {
                    f3.oleDbConnection1.Open();
                    OleDbCommand cmd = new OleDbCommand("Update po set Status='Close' where POID='" + comboBox1.Text + "'", f3.oleDbConnection1);
                    cmd.ExecuteNonQuery();
                    f3.oleDbConnection1.Close();
                    
                }  
               
               
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            f3.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select * from GRN", f3.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            f3.oleDbConnection1.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            f3.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select * from GRNProducts", f3.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            f3.oleDbConnection1.Close();

        }
    }
}