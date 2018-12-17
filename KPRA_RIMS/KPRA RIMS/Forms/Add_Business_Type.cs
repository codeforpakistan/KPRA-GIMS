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
    public partial class Add_Business_Type :MetroFramework.Forms.MetroForm
    {
        public Add_Business_Type()
        {
            InitializeComponent();
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (BusinessName.Text == "" || BusinessName.Text == null )
                {
                    MessageBox.Show("Please Fill the TextBox First", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ConnectionClass.InsertCommand("insert into Business_type Values('" + BusinessName.Text + "','" + Description.Text + "')");
                    MessageBox.Show("Successfully Added", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                    BusinessName.Text = Description.Text = "";
                }
            }
            catch
            {

            }
     
            
        }
        string pid;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BusinessTypeList obj = new BusinessTypeList(panel1);
            obj.Show();
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
