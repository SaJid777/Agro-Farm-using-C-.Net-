﻿using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace AgroFarm
{
    public partial class FoodReport : Form
    {
        
        SqlConnection m = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=farm;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public FoodReport()
        {
            InitializeComponent();
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Home h1 = new Home();
            this.Hide();
            h1.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Dashboard d1 = new Dashboard();
            this.Hide();
            d1.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Profile p1 = new Profile();
            this.Hide();
            p1.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (Login.pos.Equals("Owner"))
            {
                this.Hide();
                Reports_Owner r1 = new Reports_Owner();
                r1.Show();
            }
            else
            {
                Reports r1 = new Reports();
                this.Hide();
                r1.Show();
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            ChangePassword c1 = new ChangePassword();
            this.Hide();
            c1.Show();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            Login l1 = new Login();
            this.Hide();
            l1.Show();
        }

        private void FoodReport_Load(object sender, EventArgs e)
        {
            try
            {
                m.Close();
                m.Open();
                SqlDataAdapter cmd=new SqlDataAdapter("select * from [dbo].[food]", m);
                DataTable dt = new DataTable();
                cmd.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    int a = dataGridView1.Rows.Add();
                    dataGridView1.Rows[a].Cells[0].Value = item[0];
                    dataGridView1.Rows[a].Cells[1].Value = item[1];
                    dataGridView1.Rows[a].Cells[2].Value = item[2];
                    dataGridView1.Rows[a].Cells[3].Value = item[3];
                    dataGridView1.Rows[a].Cells[4].Value = item[4];
                    dataGridView1.Rows[a].Cells[5].Value = item[5];
                }
                m.Close();
            }

            catch
            {
                
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                textBox6.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();

            }
            catch
            {
                
            }
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            try
            {
                m.Close();
                m.Open();
                SqlCommand cmd = new SqlCommand("delete from [dbo].[food] where Fid='"+textBox1.Text+"'",m);
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Deleted");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();

                    this.Hide();
                    FoodReport f1 = new FoodReport();
                    f1.Show();
                }
                else
                {
                    MessageBox.Show("Invalid");
                }
                m.Close();
            }
            catch
            {
                
            }
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            try
            {
                m.Close();
                m.Open();
                SqlCommand cmd = new SqlCommand("update [dbo].[food] set Fname = '" + textBox2.Text + "', Quantity = '" + textBox3.Text + "', Type = '" + textBox4.Text + "', PRate = '" + textBox5.Text + "', SRate = '" + textBox6.Text + "'  where Fid='" + textBox1.Text + "'", m);
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Updated");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();

                    this.Hide();
                    FoodReport f1 = new FoodReport();
                    f1.Show();
                }
                else
                {
                    MessageBox.Show("Invalid");
                }
                m.Close();
            }
            catch
            {
                MessageBox.Show("Error!!");
            }
        }
    }
}
