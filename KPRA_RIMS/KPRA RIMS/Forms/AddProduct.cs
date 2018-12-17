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
    public partial class AddProduct :MetroFramework.Forms.MetroForm
    {
        Panel p1;
        public AddProduct(Panel p)
        {
            InitializeComponent();
            p1=p;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           


            DataTable dt1 = ConnectionClass.Selectcommand("select categoryName from Category");
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
                ProductName.Focus();
            }
        }

        private void ProductName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                CostPrice.Focus();
            }
        }

        private void CostPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               
                SalePrice.Focus();
            }
        }

        private void SalePrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                Description.Focus();
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

          
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = ConnectionClass.Selectcommand("select category_id from category where categoryName='" + comboBox1.Text + "'");

                ConnectionClass.InsertCommand("insert into Product values('" + dt.Rows[0][0].ToString() + "','" + ProductCode.Text + "','" + ProductName.Text + "','" + Description.Text + "','" + CostPrice.Text + "','" + SalePrice.Text + "')");
                MessageBox.Show("Sucessfully Added !", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ProductCode.Text = ProductName.Text = Description.Text = CostPrice.Text = SalePrice.Text = "";
            }
            catch { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ProductList obj = new ProductList();
            obj.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }

        private void CostPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

         

        }

        private void SalePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

           
        }
    }
}
 