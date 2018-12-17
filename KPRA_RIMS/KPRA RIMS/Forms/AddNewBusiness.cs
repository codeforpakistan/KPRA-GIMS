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
    public partial class AddNewBusiness :MetroFramework.Forms.MetroForm
    {
        Panel p1;
        public AddNewBusiness(Panel p)
        {
            InitializeComponent();
            p1=p;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            DataTable   dt = ConnectionClass.Selectcommand("select type from language");
            if (dt.Rows[0][0].ToString() == "English")
            {
                English();
            }
            else
            {
                Urdu();
            }


            DataTable dtBname = ConnectionClass.Selectcommand("select BusinessTypeName from Business_type");
            foreach (DataRow row in dtBname.Rows)
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

        private void metroTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
          
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
         
        }

        private void ProductCode_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                Description.Focus();
            }
        }

        private void ProductName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                Contact.Focus();
            }
        }

        private void CostPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               
                Email.Focus();
            }
        }

        private void SalePrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                Address.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
         

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            try
            {
              
                

            }
            catch { }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        string bid;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            BusinessList objForm = new BusinessList(p1);
            objForm.Show();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            DataTable dt = ConnectionClass.Selectcommand("select BusinessType_Id from Business_Type where BusinessTypeName='" + comboBox1.Text + "'");
            bid
                = dt.Rows[0][0].ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
 