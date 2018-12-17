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
    public partial class Update_Product :MetroFramework.Forms.MetroForm
    {
        Panel p1;
        DataGridView dgv;
        string pid;

        public Update_Product(Panel p,string PID,DataGridView DGV)
        {
            InitializeComponent();
            p1=p;
            pid = PID;
            dgv = DGV;
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


            DataTable dt1 = ConnectionClass.Selectcommand("select categoryName from Category");
            foreach (DataRow row in dt1.Rows)
            {

                comboBox1.Items.Add(row[0].ToString());


            }

            DataTable dt2 = ConnectionClass.Selectcommand("select ProductCode,ProductName,CostPrice,SalePrice,Description from Product where productid='" + pid + "'");
            ProductCode.Text = dt2.Rows[0][0].ToString();
            ProductName.Text = dt2.Rows[0][1].ToString();
            CostPrice.Text = dt2.Rows[0][2].ToString();
            SalePrice.Text = dt2.Rows[0][3].ToString();
            Description.Text = dt2.Rows[0][4].ToString();

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
            ConnectionClass.UpdateCommand("update product set ProductCode='" + ProductCode.Text + "',ProductName='" + ProductName.Text + "',CostPrice='" + CostPrice.Text + "',SalePrice='" + SalePrice.Text + "',Description='" + Description.Text + "' where productid='"+pid+"'");
            MessageBox.Show("Sucessfully Added !", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dgv.DataSource = ConnectionClass.Selectcommand("select * from Product");
            this.Close();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {

            try
            {
                ProductList objForm = new ProductList();
                objForm.TopLevel = false;
                p1.Controls.Add(objForm);
                objForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                objForm.Dock = DockStyle.Fill;
                objForm.Show();
                this.Close();

            }
            catch { }
        }

        private void button1_Click_1(object sender, EventArgs e)
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
 