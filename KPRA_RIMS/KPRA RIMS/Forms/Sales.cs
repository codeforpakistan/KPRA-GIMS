using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;

namespace KPRA_RIMS
{
    public partial class Sales : Form
    {
        string Usr;
        public Sales(string username)
        {
          
            InitializeComponent();
          
        }
        public Sales()
        {
            
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //try
            
                //ConnectionClass.InsertCommand("insert into boards (location,size,costprice,saleprice,status,Owner)" +
                //    " values ('" + TBLocatoin.Text + "','" + TBSizeL.Text + " X "+TBBoardSizeW.Text+"'," + TBCostPrice.Text + "," + TBSalePrice.Text + ",'Free','Me')");
                //MessageBox.Show("Added Successfully!");

         
        }

        private void BoardReg_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ConnectionClass.Selectcommand("select * from sales_Master");
            calculation();
        }


        public void calculation() {
            decimal totalValue = 0;
            try
            {
           
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {

                    totalValue += Convert.ToDecimal(row.Cells[5].Value.ToString());

                }
            }
            catch {
                TBTotalSale.Text = totalValue.ToString();
            }

        }

       // foreach( ){}

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2.DataSource = ConnectionClass.Selectcommand("select * from sales_details where salesMaster_id='"+dataGridView1.SelectedRows[0].Cells[0].Value.ToString()+"'");
        }

        string param = "";
        private void TBCustomerName_TextChanged(object sender, EventArgs e)
        {
            param = "Sales Report for Searching of keywords ' "+TBCustomerName.Text+" '";
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("searchingtext",TBCustomerName.Text);
           dataGridView1.DataSource= ConnectionClass.proc_Select("Bills_Search",dic);

           calculation();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

          

        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                dataGridView2.DataSource = ConnectionClass.Selectcommand("select * from sales_details where salesMaster_id='" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "'");

            }
            catch { }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
              
          
            DialogResult result = MessageBox.Show("Do you really want to Delete this Bill", "Confirm Bill Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
           


              
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ConnectionClass.Selectcommand("select * from sales_Master where Salesdate between '" + DTP1.Text + "' and '" + DTP2.Text + "'");
            calculation();
        }

        private void DTIssuingDate_ValueChanged(object sender, EventArgs e)
        {
            param = "Sales List for Date Between "+DTP1.Text+" and "+DTP2.Text;
            dataGridView1.DataSource = ConnectionClass.Selectcommand("select * from sales_Master where Salesdate between '" + DTP1.Text + "' and '" + DTP2.Text + "'");
            calculation();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
         
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
           // UpdateInvoice obj = new UpdateInvoice(dataGridView1);
           // obj.InvoiceID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
           // obj.TBCID.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
           // obj.TBCNAME.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
           // obj.TBGrandTotalPrice.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
           // obj.TBDiscount.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
           // obj.TBGrandNetPrice.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
           // obj.TBpaid.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString(); 
           // obj.TBBalance.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
           //// DataTable dt1 = ConnectionClass.Selectcommand("select balance from Customer")
           
           // DataTable dt = ConnectionClass.Selectcommand("select productname,unitprice,quantity,totalprice,Discount,Total_ADiscount from sales_details where SaleID='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'");

           // obj.dtb.Columns.Add("Name", typeof(string));
           // obj.dtb.Columns.Add("Qty", typeof(string));
           // foreach (DataRow row in dt.Rows)
           // {
           //     obj.dtb.Rows.Add(row[0].ToString(), row[2].ToString());
           //     string[] str = { row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString() };
           // ListViewItem item=new ListViewItem(str);
           // obj.listView1.Items.Add(item);
           //     //for (int i = 0; i < dt.Rows.Count;i++ )
           //     //{
           //     //    string[] str = { dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString(), dt.Rows[i][3].ToString() };
           //     //    ListViewItem item = new ListViewItem(str);

           //     //    obj.listView1.Items.Insert(0, item);
           //   //  }
           // }
          
           // obj.Show();
           
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        DataTable dtcr;
        private void button3_Click_1(object sender, EventArgs e)
        {


        }
    }
}
