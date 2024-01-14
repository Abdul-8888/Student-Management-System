using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CRUD_Operations
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into Table_1 values (@ID, @Name, @Department)", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textbox1.Text));
            cmd.Parameters.AddWithValue("@Name", textbox2.Text);
            cmd.Parameters.AddWithValue("@Department", textbox3.Text);
            cmd.ExecuteNonQuery();
            //MessageBox.Show("Successfully saved");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Table_1", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            string id = textbox1.Text;
            SqlCommand cmd = new SqlCommand("Update Table_1 Set Name = @Name, Department = @Department Where ID = " + id, con);
            cmd.Parameters.AddWithValue("@Name", textbox2.Text);
            cmd.Parameters.AddWithValue("@Department", textbox3.Text);
            cmd.ExecuteNonQuery();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            string id = textbox1.Text;
            SqlCommand cmd = new SqlCommand("Delete From Table_1 Where ID = "+ id , con);
            cmd.ExecuteNonQuery();
            //MessageBox.Show("Done");
        }
    }
}
