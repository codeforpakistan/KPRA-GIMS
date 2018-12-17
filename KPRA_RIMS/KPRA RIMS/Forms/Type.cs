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
    public partial class Type :MetroFramework.Forms.MetroForm
    {
        public Type()
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
          
            
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            AddCatagory obj = new AddCatagory();
            obj.Show();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            AddProduct obj = new AddProduct(panel1);
            obj.Show();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            AddSubCatagory obj = new AddSubCatagory();
            obj.Show();
        }
    }
}
