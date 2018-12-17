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
    public partial class Form1 : Form
    {
        string check;
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            language();
     

        }
        DataTable dt;
        public void language()
        {
            try
            {
                dt = ConnectionClass.Selectcommand("select type from language");
                if (dt.Rows[0][0].ToString() == "English")
                {



                    //metroTextBox1.WaterMark = "Username";
                    //metroTextBox2.WaterMark = "Password";
                    //label1.Text = "Please Login to Continue";
                    //metroTextBox1.TextAlign = HorizontalAlignment.Left;
                    //metroTextBox2.TextAlign = HorizontalAlignment.Left;
                    //materialRaisedButton1.Text = "Login";
                    //groupBox1.Text = "Language";
                    //metroRadioButton1.Checked = true;

                }
                else
                {

                    //metroTextBox1.WaterMark = "صارف کا نام";
                    //metroTextBox2.WaterMark = "پاس ورڈ";
                    //label1.Text = "جاری رکھنے کے لئے لاگ ان کریں";
                    //metroTextBox1.TextAlign = HorizontalAlignment.Right;
                    //metroTextBox2.TextAlign = HorizontalAlignment.Right;
                    //materialRaisedButton1.Text = "لاگ ان";
                    //groupBox1.Text = "زبان";
                    //metroRadioButton2.Checked = true;

                }
            }
            catch { }
        }

        public void english()
        {


            //metroTextBox1.WaterMark = "Username";
            //metroTextBox2.WaterMark = "Password";
            //label1.Text = "Please Login to Continue";
            //metroTextBox1.TextAlign = HorizontalAlignment.Left;
            //metroTextBox2.TextAlign = HorizontalAlignment.Left;
            //materialRaisedButton1.Text = "Login";
            //groupBox1.Text = "Language";

        }

        public void Urdu()
        {
            //metroTextBox1.WaterMark = "صارف کا نام";
            //metroTextBox2.WaterMark = "پاس ورڈ";
            //label1.Text = "جاری رکھنے کے لئے لاگ ان کریں";
            //metroTextBox1.TextAlign = HorizontalAlignment.Right;
            //metroTextBox2.TextAlign = HorizontalAlignment.Right;
            //materialRaisedButton1.Text = "لاگ ان";
            //groupBox1.Text = "زبان";


        }

        private void materialDivider1_Click(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
           

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void metroRadioButton1_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void metroRadioButton2_CheckedChanged(object sender, EventArgs e)
        {

            //if (metroRadioButton1.Checked = true)
            //{

            //    ConnectionClass.UpdateCommand("Update language set Type='English'");
            //    english();
            //}
            //else
            //{
            //    ConnectionClass.UpdateCommand("Update language set Type='Urdu'");
            //    Urdu();

            //}
        }

        private void metroTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //metroTextBox2.Focus();
            }
        }

        private void metroTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
               // metroTextBox1.Focus();
            }
            if (e.KeyCode == Keys.Enter)
            {
              //  materialRaisedButton1.PerformClick();
            }
        }

        private void metroRadioButton2_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void metroRadioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            //if (metroRadioButton1.Checked == true)
            //{

            //    ConnectionClass.UpdateCommand("Update language set Type='English'");
            //    english();
            //}
            //else if (metroRadioButton2.Checked == true)
            //{
            //    ConnectionClass.UpdateCommand("Update language set Type='Urdu'");
            //    Urdu();
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = ConnectionClass.Selectcommand("Select * from Login where Username = '" + textBox1.Text + "' and Password='" + textBox2.Text + "' ");
                if (dt.Rows.Count > 0)
                {
                    string userType = dt.Rows[0][1].ToString();
                    if (userType == "Admin" || userType=="admin")
                    {
                        AdminHome obj = new AdminHome();
                        this.Hide();
                        obj.Show();
                      
                    }
                    else
                    {
                        Home2 obj = new Home2(dt.Rows[0][2].ToString());
                        this.Hide();
                        obj.Show();
                    }
                }
                else
                {

                    MessageBox.Show("Invalid username or password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {

                MessageBox.Show("Server is not respondin!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();

            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
