using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime;
using System.Runtime.InteropServices;

namespace KPRA_RIMS
{
   
    public partial class Home :MetroFramework.Forms.MetroForm
    {

        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description,int ReservedValue);
        

        public Home()
        {
            InitializeComponent();
          
           
           
         
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = System.DateTime.Now.ToString();
            int Desc;
            string abc = InternetGetConnectedState(out Desc, 0).ToString();
            if (abc == "True")
            {

                radioButton1.ForeColor = Color.Green;
                radioButton1.Text = "Online";
                radioButton1.Checked = true;
           //    metroButton2.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.man_user));
                metroButton2.BackgroundImageLayout = ImageLayout.Zoom;
            }
            else
            {
                radioButton1.ForeColor = Color.Red;
                radioButton1.Text = "Offline";
                radioButton1.Checked = false;
            }
           
        }

        private void materialDivider1_Click(object sender, EventArgs e)
        {

        }


        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
          
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
           
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {

        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
          
        }

        private void metroButton9_Click(object sender, EventArgs e)
        {
            Type obj = new Type();
            obj.Show();
        }
    }
}

