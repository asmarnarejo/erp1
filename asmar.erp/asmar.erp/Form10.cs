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
    public partial class Form10 : Form
    {
        Form3 f3 = new Form3();
        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            this.button1.BackColor = Color.Teal;
           
            this.button1.ForeColor = Color.White;
 
            this.label10.Text = "DisApproval";
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
            this.button1.Text = "Send For Approval";
  

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
            OleDbCommand cmd = new OleDbCommand("update vendor set vname=@vname,vcode=@vcode,vcity=@vcity,ph1=@ph1,vaddress=@vaddress,cpname=@cpname,vgroup=@vgroup,vstatus=@vstatus where vid=@vid ", f3.oleDbConnection1);
           
            cmd.Parameters.AddWithValue("@vname", textBox1.Text);
            cmd.Parameters.AddWithValue("@vcode", textBox2.Text);
            cmd.Parameters.AddWithValue("@vcity", textBox3.Text);
            cmd.Parameters.AddWithValue("@ph1", textBox4.Text);
            cmd.Parameters.AddWithValue("@vaddress", textBox5.Text);
            cmd.Parameters.AddWithValue("@cpname", textBox6.Text);
            cmd.Parameters.AddWithValue("@vgroup", textBox7.Text);
            cmd.Parameters.AddWithValue("@vstatus",textBox8.Text);
            cmd.Parameters.AddWithValue("@vid", comboBox1.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record has been updated");
            Form6 f6 = new Form6();
            f6.Show();
            this.Hide();
            f3.oleDbConnection1.Close();
          
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
