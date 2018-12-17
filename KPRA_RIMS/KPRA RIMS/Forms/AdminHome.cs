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
using System.Net.NetworkInformation;
using System.Data.SqlClient;
using System.Net.Http.Formatting;
using System.Web.Script.Serialization;
using System.Net.Http;


namespace KPRA_RIMS
{
   
    public partial class AdminHome :Form
    {
         

        public AdminHome()
        {

            InitializeComponent();
          
           
        }

        private void NetworkChange_NetworkAvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
        {

          
        }
        private void Form1_Load(object sender, EventArgs e)
        {

          
     
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

        private void BtnSlide_Click(object sender, EventArgs e)
        {

            if (MenuVertical.Width == 250)
            {
                MenuVertical.Width = 70;
            }
            else
            {
                MenuVertical.Width = 250;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try{

                AddNewBusiness obj = new AddNewBusiness(panel1);
                obj.Show();
            }
            catch{}
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            this.Close();
         
            obj.Show();
        }

        private void Purchase_Click(object sender, EventArgs e)
        {
            BusinessList obj = new BusinessList(panel1);
            obj.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Add_Business_Type obj = new Add_Business_Type();
            obj.Show();
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Enter(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
         
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
         //   button3.BackColor = Color.FromArgb(55, 154, 59);
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
          //  button3.BackColor = Color.FromArgb(243, 245, 246);
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(55, 154, 59);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(96, 96, 96);
        }

        private void Purchase_MouseEnter(object sender, EventArgs e)
        {
            Purchase.BackColor = Color.FromArgb(55, 154, 59);

        }

        private void Purchase_MouseLeave(object sender, EventArgs e)
        {
            Purchase.BackColor = Color.FromArgb(96, 96, 96);

        }

        private void button7_MouseEnter(object sender, EventArgs e)
        {
            button7.BackColor = Color.FromArgb(55, 154, 59);

        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            button7.BackColor = Color.FromArgb(96, 96, 96);

        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.BackColor = Color.FromArgb(55, 154, 59);

        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.FromArgb(96, 96, 96);

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            try
            {
                foreach (Form f in Application.OpenForms)
                {
                    f.Close();
                    this.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}

