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
    public partial class AddSubCatagory :MetroFramework.Forms.MetroForm
    {
        public AddSubCatagory()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt1 = ConnectionClass.Selectcommand("select Type from Category");
            foreach (DataRow row in dt1.Rows)
            {

                comboBox1.Items.Add(row[0].ToString());


            }

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
                DataTable dt = ConnectionClass.Selectcommand("select max(id) from Category");
               
                    int sno = Convert.ToInt32(dt.Rows[0][0].ToString())+1;
                    ConnectionClass.InsertCommand("insert into Category Values('" + sno + "','','','" + metroTextBox1.Text + "','','" + pid + "')");
                
            }
            catch
            {
                ConnectionClass.InsertCommand("insert into Category Values('1','" + metroTextBox1.Text + "','"+pid+"')");

            }
            metroTextBox1.Text = "";
            
        }
        string pid;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = ConnectionClass.Selectcommand("select id from Category where Type='" + comboBox1.Text + "'");
            pid = dt.Rows[0][0].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
