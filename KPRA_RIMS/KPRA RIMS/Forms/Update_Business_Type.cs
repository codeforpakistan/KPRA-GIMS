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
    public partial class Update_Business_Type :MetroFramework.Forms.MetroForm
    {
        Panel p1;
        DataGridView dgv;
        string pidM;

        public Update_Business_Type(Panel p, string PID, DataGridView DGV)
        {
            InitializeComponent();
            p1 = p;
            pidM = PID;
            dgv = DGV;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            DataTable dt2 = ConnectionClass.Selectcommand("select BusinessTypeName,Description from Business_type where BusinessType_ID='" + pidM + "'");
           BusinessName.Text = dt2.Rows[0][0].ToString();
         
           Description.Text = dt2.Rows[0][1].ToString();
         
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
            ConnectionClass.UpdateCommand("update product set BusinessTypeName='" + BusinessName.Text + "',Description='" + Description.Text + "' where  BusinessType_ID='" + pidM + "'");
            MessageBox.Show("Successfully Added");
            dgv.DataSource = ConnectionClass.Selectcommand("select * from Product");
            this.Close();
     
            
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
    }
}
