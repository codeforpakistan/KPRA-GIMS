using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KPRA_RIMS
{
    public partial class AddCatagory : Form
    {
        public AddCatagory()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            


            DataTable dt1 = ConnectionClass.Selectcommand("select CategoryName from Category");
            foreach (DataRow row in dt1.Rows)
            {

                comboBox1.Items.Add(row[0].ToString());


            }
        }

        private void materialDivider1_Click(object sender, EventArgs e)
        {

        }

        public void Urdu()
        {
          
        }

        public void English()
        {
           
        }
        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        string pid;
        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
           

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = ConnectionClass.Selectcommand("select Category_id from Category where CategoryName='" + comboBox1.Text + "'");
            pid = dt.Rows[0][0].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked = true)
            {
                try
                {
                    DataTable dt = ConnectionClass.Selectcommand("select max(id) from Category");

                    int sno = Convert.ToInt32(dt.Rows[0][0].ToString()) + 1;
                    ConnectionClass.InsertCommand("insert into Category Values('" + sno + "','','" + metroTextBox1.Text + "','','','" + pid + "')");


                }
                catch
                {
                    ConnectionClass.InsertCommand("insert into Category Values('1','','" + metroTextBox1.Text + "','','','" + pid + "')");


                }
                MessageBox.Show("Sucessfully Added !", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                metroTextBox1.Text = "";
            }
            else
            {
                try
                {
                    DataTable dt = ConnectionClass.Selectcommand("select max(sno) from Category");

                    int sno = Convert.ToInt32(dt.Rows[0][0].ToString()) + 1;
                    ConnectionClass.InsertCommand("insert into Category Values('" + sno + "','','" + metroTextBox1.Text + "','','','')");

                }
                catch
                {
                    ConnectionClass.InsertCommand("insert into Category Values('1','','" + metroTextBox1.Text + "','','','')");

                }

            }
            MessageBox.Show("Successfully Message", "Successfully Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
            metroTextBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                comboBox1.Enabled = true;

            }
            else
            {
                comboBox1.Enabled = false;
                comboBox1.Text = "Select Category";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }
    }
}

