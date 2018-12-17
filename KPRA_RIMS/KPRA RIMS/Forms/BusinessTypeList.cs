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
    public partial class BusinessTypeList :Form
    {
        Panel p1;
        public BusinessTypeList(Panel p)
        {
            InitializeComponent();
            p1 = p;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         

            dataGridView1.DataSource = ConnectionClass.Selectcommand("select * from Business_Type");

          

           
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

        public void delete()
        {
            DialogResult result = MessageBox.Show("Do you really want to Delete this Business Type", "Confirm product Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                ConnectionClass.DeleteCommand("Delete from Business_Type where BusinessType_id=" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                MessageBox.Show("Business Type Deleted Successfully!");
                dataGridView1.DataSource = ConnectionClass.Selectcommand("select * from Business_Type");
               
            }
        }

        public void update()
        {
            try
            {
                Update_Business_Type objForm = new Update_Business_Type(p1, dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), dataGridView1);
                objForm.TopLevel = false;
                p1.Controls.Add(objForm);
                objForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                objForm.Dock = DockStyle.Fill;
                this.Close();
                objForm.Show();
            }
            catch
            {
                MessageBox.Show("sorry no row found");
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            update();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            delete();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            update();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            delete();
        }

        private void roundButton1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
