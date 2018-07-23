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
    public partial class Delivery_Challan : Form
    {
        Form3 f3 = new Form3();
        public Delivery_Challan()
        {
            InitializeComponent();
        }

        private void Delivery_Challan_Load(object sender, EventArgs e)
        {
            {

                int c = 0;
                f3.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("select count(DCID) from DC", f3.oleDbConnection1);
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    c = Convert.ToInt32(dr[0].ToString());
                    c++;
                }


                textBox5.Text = "DC-00" + c.ToString() + "_" + System.DateTime.Today.Year;
            }
            {
                f3.oleDbConnection1.Close();
                this.dataGridView1.BackgroundColor = Color.Teal;
                this.BackColor = Color.White;
                f3.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("select SOID from SO where status ='OPen'", f3.oleDbConnection1);
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["SOID"].ToString());
                }

                f3.oleDbConnection1.Close();
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            

            {

                f3.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("select * from SO where SOID='" + comboBox1.Text + "'", f3.oleDbConnection1);
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    textBox1.Text = dr["CID"].ToString();
                    textBox2.Text = dr["Cname"].ToString();
                    textBox3.Text = dr["Cdept"].ToString();
                    textBox4.Text = dr["TotalAmount"].ToString();

                }
                f3.oleDbConnection1.Close();
            }
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            {
                f3.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("insert into DCPRODUCTS(DCID,Cname,Cqty)values(@DCID,@Cname,@Cqty)", f3.oleDbConnection1);
                cmd.Parameters.AddWithValue("@DCID", this.textBox5.Text);
                cmd.Parameters.AddWithValue("@Cname", this.textBox2.Text);
                cmd.Parameters.AddWithValue("@Cqty", this.textBox6.Text);
                cmd.ExecuteNonQuery();
                f3.oleDbConnection1.Close();
                MessageBox.Show("Data Of GRN Products");
            }
            {

                {
                    f3.oleDbConnection1.Open();
                    OleDbCommand cmd = new OleDbCommand("insert into DC(DCID,SOID,Cname,CID,TotalAmount,CDept,Status)values(@DCID,@SOID,@Cname,@CID,@TotalAmount,@CDept,@Status)", f3.oleDbConnection1);
                    cmd.Parameters.AddWithValue("@DCID", this.textBox5.Text);
                    cmd.Parameters.AddWithValue("@SOID", this.comboBox1.Text);
                    cmd.Parameters.AddWithValue("@Cname", this.textBox2.Text);
                    cmd.Parameters.AddWithValue("@CID", this.textBox1.Text);
                    cmd.Parameters.AddWithValue("@TotalAmount", this.textBox4.Text);
                    cmd.Parameters.AddWithValue("@CDept", this.textBox3.Text);
                    cmd.Parameters.AddWithValue("@status=", "Open");
                    cmd.ExecuteNonQuery();
                    f3.oleDbConnection1.Close();

                    MessageBox.Show("Delivery Challan has been created");


                }
              
                {
                    f3.oleDbConnection1.Open();
                    OleDbCommand cmd = new OleDbCommand("Update SO set Status='Close' where SOID='" + comboBox1.Text + "'", f3.oleDbConnection1);
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

        private void button4_Click(object sender, EventArgs e)
        {
            f3.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select * from DCPRODUCTS", f3.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            f3.oleDbConnection1.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            f3.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select * from DC", f3.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            f3.oleDbConnection1.Close();
        }
    }
}
