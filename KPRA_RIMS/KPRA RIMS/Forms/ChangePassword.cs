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
    public partial class ChangePassword : Form
    {
        string username;
        public ChangePassword(string usrname)
        {
             username = usrname;
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Textbox2.Text == textBox3.Text)
            {
                int a = ConnectionClass.UpdateCommand("update login " +
                          "set Password='" + Textbox2.Text +
                         "' where username='" + username + "' and Password='" + Textbox1.Text + "'");
                if (a > 0)
                {
                    MessageBox.Show("Successfully Changed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Textbox1.Text = "";
                    Textbox2.Text = "";
                    textBox3.Text = "";
                    label3.Text = "";
                    label6.Text = "";
                    label2.Text = "";
                }
                else
                {
                    MessageBox.Show("Old Password is not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    label2.Text = "Error";
                }
            }
            else
            {
                
                MessageBox.Show("New Password does not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                label3.Text = "Error";
                label6.Text = "Error";


            }
 }

        private void ChangePassword_Load(object sender, EventArgs e)
        {

        }
    }
}
