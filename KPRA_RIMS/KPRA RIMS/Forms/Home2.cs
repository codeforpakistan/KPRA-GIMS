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
using KPRA_RIMS.Classes;
using System.Threading;


namespace KPRA_RIMS
{
   
    public partial class Home2 :Form
    {
        string username;
        public Home2()
        {
            InitializeComponent();
            InitializeTimer();
        }
        public Home2(string USERNAME)
        {
            

            InitializeComponent();
            InitializeTimer();
            username = USERNAME;

           
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Thread worker = new Thread(new ThreadStart(SendClientStatusViaTimer));
            worker.Name = "ClientStatus";
            worker.IsBackground = true;
            worker.Start();
        }
        private void SendClientStatusViaTimer()
        {
            string message = "";
            if (InternetConnection.IsConnectedToInternet())
            {
                InternetConnection.SendClientStatus();
            }
            else
            {
                message += "\nVendor status: offline!";
            }
        }
        /// <summary>
        /// CODE BY SYED SAJID
        /// THIS IS THE TIMER INITIALIATION FUNCTION THAT SETS AND INITIALISE VALUES OF THE VARIOUS PROPERTIES OF TIMER.
        /// THIS CODE CONTAINS THE TICK EVENT THAT IS DRIVEN WHEN THE TIME INTERVAL REACHES TO THE ENDPOINT
        /// </summary>
        private void InitializeTimer()
        {
            // Run this procedure in an appropriate event.

            timer1.Interval = (1 * 60 * 1000);
            timer1.Enabled = true;
            // Hook up timer's tick event handler.
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {

          
            calculation();
        }

        public void calculation()
        {

            DataTable dt = ConnectionClass.Selectcommand("select count(SalesMasterID),sum(TotalAmount),sum(SalesTax),sum(NetAmount) from Sales_Master");
            TotalInvoice.Text = dt.Rows[0][0].ToString();
            TotalSale.Text = dt.Rows[0][1].ToString();
            TotalTax.Text = dt.Rows[0][2].ToString();
            TotalReport.Text = dt.Rows[0][3].ToString();
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
          
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ChangePassword obj = new ChangePassword(username);
            obj.Show();
        }

        private void Purchase_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Enter(object sender, EventArgs e)
        {
            panel9.Visible = panel10.Visible = panel11.Visible = panel12.Visible = true;
            calculation();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReportsForm obj = new ReportsForm();
            obj.Show();
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(55, 154, 59);
            button6.Visible = true;
            button5.Visible = true;
            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
            button11.Visible = false;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(96, 96, 96);
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(55, 154, 59);
            button6.Visible = false;
            button5.Visible = false;
            button10.Visible = false;
            button11.Visible = false;
            button8.Visible = true;
            button9.Visible = true;

        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(96, 96, 96);

        }

        private void Purchase_MouseEnter(object sender, EventArgs e)
        {
            Purchase.BackColor = Color.FromArgb(55, 154, 59);
            button6.Visible = false;
            button5.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
           
            button10.Visible = true;
            button11.Visible = true;

        }

        private void Purchase_MouseLeave(object sender, EventArgs e)
        {
            Purchase.BackColor = Color.FromArgb(96, 96, 96);

        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(55, 154, 59);
            button6.Visible = false;
            button5.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
            button11.Visible = false;

        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(96, 96, 96);

        }

        private void button7_MouseEnter(object sender, EventArgs e)
        {
            button7.BackColor = Color.FromArgb(55, 154, 59);
            button6.Visible = false;
            button5.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
            button11.Visible = false;

        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            button7.BackColor = Color.FromArgb(96, 96, 96);

        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.BackColor = Color.FromArgb(55, 154, 59);
            button6.Visible = false;
            button5.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
            button11.Visible = false;

        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.FromArgb(96, 96, 96);

        }

        private void button5_Enter(object sender, EventArgs e)
        {
          
        }

        private void button1_Enter(object sender, EventArgs e)
        {
           
        }

        private void Purchase_Enter(object sender, EventArgs e)
        {
          
        }

        private void button2_Enter(object sender, EventArgs e)
        {
           
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
       {
            button6.Visible = false;
            button5.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
            button11.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                AddCatagory objForm = new AddCatagory();
                objForm.Show();
            }
            catch { }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CategoryList obj = new CategoryList();
            obj.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {

                AddProduct objForm = new AddProduct(panel1);
                objForm.Show();
            }
            catch { }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                ProductList objForm = new ProductList();

                objForm.Show();


            }
            catch { }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Sale_Invoice obj = new Sale_Invoice(panel1);
            obj.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Sales obj = new Sales();
            obj.Show();
        }

        private void button13_Click(object sender, EventArgs e)
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

        private void button12_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TotalInvoice_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DataTable dt = ConnectionClass.Selectcommand("select count(SalesMasterID),sum(TotalAmount),sum(SalesTax),sum(NetAmount) from Sales_Master where SalesDate between '"+dateTimePicker1.Text+"' and '"+dateTimePicker2.Text+"'");
            TotalInvoice.Text = dt.Rows[0][0].ToString();
            TotalSale.Text = dt.Rows[0][1].ToString();
            TotalTax.Text = dt.Rows[0][2].ToString();
            TotalReport.Text = dt.Rows[0][3].ToString();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DataTable dt = ConnectionClass.Selectcommand("select count(SalesMasterID),sum(TotalAmount),sum(SalesTax),sum(NetAmount) from Sales_Master where SalesDate between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'");
            TotalInvoice.Text = dt.Rows[0][0].ToString();
            TotalSale.Text = dt.Rows[0][1].ToString();
            TotalTax.Text = dt.Rows[0][2].ToString();
            TotalReport.Text = dt.Rows[0][3].ToString();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            this.Close();

            obj.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            About obj = new About(panel1);
            obj.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
           
        }

        private void Home2_Activated(object sender, EventArgs e)
        {
            calculation();
        }
    }
}

