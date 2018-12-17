using CrystalDecisions.CrystalReports.Engine;
using KPRA_RIMS.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Configuration;
using System.Web.Configuration;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;

namespace KPRA_RIMS
{
    public partial class Sale_Invoice :MetroFramework.Forms.MetroForm
    {
        string serverIP = ConfigurationManager.AppSettings["server_ip"].ToString();
        private static string connStaticString = ConfigurationManager.ConnectionStrings["kpra_db_connString"].ConnectionString;
        private ListViewHitTestInfo hitinfo;
        private TextBox editbox = new TextBox();
        private int quantity;
        private double totalAmount;
        private decimal discount;
        private double salesTaxRate;
        private double salesTax;
        private double netAmount;
        private double paid;
        private long businessId;
        private long stationId;
        private DateTime? todayTime;
        private string description;
        private double otherCharges;
        private string businessCode;
        //sales details
        //private long pId;
        //private string pName;
        //private long pQuantity;
        //private decimal pUnitPrice;
        //private decimal pTotalPrice;
        //private long salesMasterID;


        #region Sale API milestone
        Panel p1;
       
        public Sale_Invoice(Panel p)
        {
            InitializeComponent();
            
            p1 = p;

            editbox.Parent = listView1;
            editbox.Hide();
            editbox.LostFocus += new EventHandler(editbox_LostFocus);
            listView1.MouseDoubleClick += new MouseEventHandler(listView1_MouseDoubleClick);
            listView1.FullRowSelect = true;
      
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             InitializeTimer();
            //if (InternetConnection.IsConnectedToInternet())
            //{
            //    List<SalesDetail> lst = new List<SalesDetail>();
            //    businessCode = DatabaseActivities.GetBusinessCode();
            //    lst = OnlineActivities.GetOnlineSalesDetailDB();
            //    foreach (var items in lst)
            //    {
            //        OnlineActivities.SendOnlineSalesDetail(items.ProductID, items.ProductName, Convert.ToInt32(items.Quantity), items.UnitPrice, items.TotalPrice, items.SalesMasterIDLocal, 1, businessCode);

            //    }
            //    OnlineActivities.UpdateSalesDetailConnection();
            //}
            //else
            //{
            //    lblResponse.Text = "Offline So not Sales Details to be inserted";
            //}
            editbox.Visible = false;
            autoCompleteMethod();
            //DataTable   dt = ConnectionClass.Selectcommand("select type from language");
            //if (dt.Rows[0][0].ToString() == "English")
            //{
            //    English();
            //}
            //else
            //{
            //    Urdu();
            //}
            
             DataTable dt11 = ConnectionClass.Selectcommand("select CategoryName from Category");
             foreach (DataRow row in dt11.Rows)
             {
                 AddNewButton(row[0].ToString());
             }
        }
        int B = 1;
        private void materialDivider1_Click(object sender, EventArgs e)
        {

        }
        public void calcuation()
        {

            decimal totalprice = 0;
            foreach (ListViewItem item in listView1.Items)
            {

                totalprice += Convert.ToDecimal(item.SubItems[4].Text.ToString());

            }

         LbTotal.Text = totalprice.ToString();
          

            Lbsuntotal.Text = (totalprice - Convert.ToDecimal(LbDiscount.Text)).ToString();

        }
        public System.Windows.Forms.Button AddNewButton(string abc)
        {
            System.Windows.Forms.Button btn = new System.Windows.Forms.Button();
             panel3.Controls.Add(btn);
                btn.Top = B * 40;
             btn.Margin = new Padding(15, 0, 0, 0);
            
            btn.Click += new System.EventHandler(this.MouseClick);
                btn.Text = abc;
                btn.Height = 45;
                btn.Width = 260;
                int newSize = 14;
                btn.Font = new System.Drawing.Font("Arial", 08F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                btn.Font = new Font(btn.Font.FontFamily, newSize);
                btn.ForeColor = Color.White;
                btn.BackColor = Color.FromArgb(55, 154, 59);
               
                B = B + 1;
               
            
            return btn;
    }

        public void autoCompleteMethod()
        {
            DataTable dt = ConnectionClass.Selectcommand("Select ProductName from Product");

            AutoCompleteStringCollection autoName = new AutoCompleteStringCollection();



            foreach (DataRow row in dt.Rows)
            {
                autoName.Add(row[0].ToString());

            }

            TBPName.AutoCompleteCustomSource = autoName;
        }
           
        
       public void MouseClick(object sender,EventArgs e)
        {
            Button bt = (Button)sender;
            flowLayoutPanel1.Controls.Clear();
            DataTable dt = ConnectionClass.Selectcommand("select category_id from Category where CategoryName='" + bt.Text + "'");
            try
            {
                DataTable dt11 = ConnectionClass.Selectcommand("select ProductName from Product where Category_id='" + dt.Rows[0][0].ToString() + "'");
                foreach (DataRow row in dt11.Rows)
                {
                    AddNewSubButton(row[0].ToString());
                }
            }
            catch { }

        }

        void MouseClick2(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            int a = 1;
            DataTable dt = ConnectionClass.Selectcommand("select ProductId,SalePrice from Product where ProductName='" + bt.Text + "'");

            foreach (ListViewItem item1 in listView1.Items)
            {

                if (dt.Rows[0][0].ToString() == item1.SubItems[0].Text.ToString())
                {

                    a = 0;
                    decimal qt = Convert.ToDecimal(item1.SubItems[2].Text.ToString());
                    decimal up = Convert.ToDecimal(item1.SubItems[3].Text.ToString());

                    qt += 1;
                    item1.SubItems[2].Text = qt.ToString();
                    item1.SubItems[4].Text = (up * qt).ToString();
                    calcuation();


                }
            }
                if (a == 1)
                {
                    string[] str = { dt.Rows[0][0].ToString(), bt.Text, "1", dt.Rows[0][1].ToString(), dt.Rows[0][1].ToString() };
                    ListViewItem item = new ListViewItem(str);

                    listView1.Items.Insert(0, item);
                    calcuation();
                }
            }
        
        public System.Windows.Forms.Button AddNewSubButton(string abc)
        {
            
            System.Windows.Forms.Button btn = new System.Windows.Forms.Button();
            flowLayoutPanel1.Controls.Add(btn);
            btn.Top = B * 50;
            btn.Click += new System.EventHandler(this.MouseClick2);
            btn.Text = abc;
            btn.Height = 45;
            btn.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btn.Width = 230;
            int newSize = 11;
            btn.Font = new Font(btn.Font.FontFamily, newSize);
            btn.ForeColor = Color.White;
            btn.BackColor = Color.FromArgb(55, 154, 59);

            B = B + 1;


            return btn;
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

       

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void roundButton1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void TBPName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.P)
            {
                Keyboard obj = new Keyboard(LbPayable,TBPaid,button1);
                obj.Show();
               

            }
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    DataTable dt;
                    int a = 1;
                    try
                    {
                      dt = ConnectionClass.Selectcommand("select ProductId,ProductName,SalePrice from Product where ProductName='" + TBPName.Text + "' or productid='" + TBPName.Text + "'");
                    }
                    
                catch{
                    dt = ConnectionClass.Selectcommand("select ProductId,ProductName,SalePrice from Product where ProductName='" + TBPName.Text + "'");

                }

                    foreach (ListViewItem item1 in listView1.Items)
                    {

                        if (dt.Rows[0][0].ToString() == item1.SubItems[0].Text.ToString())
                        {

                            a = 0;
                            decimal qt = Convert.ToDecimal(item1.SubItems[2].Text.ToString());
                            decimal up = Convert.ToDecimal(item1.SubItems[3].Text.ToString());

                            qt += 1;
                            item1.SubItems[2].Text = qt.ToString();
                            item1.SubItems[4].Text = (up * qt).ToString();
                            calcuation();
                            TBPName.Text = "";

                        }
                    }
                    if (a == 1)
                    {
                        string[] str = { dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), "1", dt.Rows[0][2].ToString(), dt.Rows[0][2].ToString() };
                        ListViewItem item = new ListViewItem(str);

                        listView1.Items.Insert(0, item);
                        calcuation();
                        TBPName.Text = "";
                    }
                }
                catch { }
            }
           
        }
        public void QtChange()
        {
            try
            {
                foreach (ListViewItem item1 in listView1.Items)
                {

                    item1.SubItems[4].Text = ((Convert.ToDecimal(editbox.Text.ToString()) * (Convert.ToDecimal(item1.SubItems[3].Text.ToString()))).ToString());

                    value = 0;
                    calcuation();
                }
            }
            catch { }
        }

        public void UPChange()
        {
         
          
            foreach (ListViewItem item1 in listView1.Items)
            {
                try
                {
                    item1.SubItems[4].Text = ((Convert.ToInt32(editbox.Text.ToString()) * (Convert.ToInt32(item1.SubItems[2].Text.ToString()))).ToString());
                    value = 0;
                    calcuation();
                }
                catch { }
            }
         
        }
        int value;
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            hitinfo = listView1.HitTest(e.X, e.Y);
            editbox.Bounds = hitinfo.SubItem.Bounds;
           editbox.Text = hitinfo.SubItem.Text;
        //    string abc = hitinfo.SubItem.Bounds.ToString();
            if (editbox.Text == Qty)
            {
                value = 1;
            }
            else
            {
                value = 2;
            }
            editbox.Focus();
            editbox.Show();
        }
        void editbox_LostFocus(object sender, EventArgs e)
        {
            if (editbox.Text != "" && editbox.Text != null)
            {
                hitinfo.SubItem.Text = editbox.Text;
               
                editbox.Hide();
                foreach (ListViewItem item in listView1.Items)
                {

                    item.SubItems[4].Text = (Convert.ToDecimal(item.SubItems[2].Text.ToString()) * Convert.ToDecimal(item.SubItems[3].Text.ToString())).ToString();

                }
                calcuation();
                editbox.Text = "";
            }
            else
            {
                hitinfo.SubItem.Text = hitinfo.SubItem.Text;
               
                editbox.Hide();
            
            }
        }

        private void listView1_Leave(object sender, EventArgs e)
        {
            if (value == 1)
            {
                QtChange();
            }
            else
            {
                UPChange();
            }
        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
          
        }
        string Qty;
        string UP;
        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewItem selectedItem = listView1.SelectedItems[0];
             Qty = selectedItem.SubItems[2].Text;
           UP = selectedItem.SubItems[3].Text;
           
        }

        private void lbDiscount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Lbsuntotal.Text = Convert.ToString(Convert.ToDecimal(LbTotal.Text) - Convert.ToDecimal(LbDiscount.Text));
            }
            catch
            {
                Lbsuntotal.Text = LbTotal.Text;
            }
        }

        private void Lbsuntotal_Click(object sender, EventArgs e)
        {
    
        }

        private void Lbsuntotal_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = ConnectionClass.Selectcommand("select Tax from Tax");
                decimal kp=((Convert.ToDecimal(dt.Rows[0][0].ToString())) * Convert.ToDecimal(Lbsuntotal.Text))/100;
                LBKpra.Text = kp.ToString();
            }
            catch
            {
                LBKpra.Text = "0";
            }
        }

        private void LBKpra_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LbPayable.Text = Convert.ToString(Convert.ToDecimal(LBKpra.Text) + Convert.ToDecimal(Lbsuntotal.Text));
            }
            catch
            {
                LbPayable.Text = "0";
            }
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        private void Sale_Invoice_Activated(object sender, EventArgs e)
        {

            string httpResponseMessage = "";
            Thread thSalesOffline = new Thread(() =>
            {
                if (InternetConnection.IsConnectedToInternet()
                )
                {
                    //lblResponse.Text += "\n" + 
                    
                    string s = OfflineActivities.SendVendorOfflineSalesDetail();
                    

                }
                else
                {

                    //   httpResponseMessage = "not connected to internet! No offline sale invoice upload!";
                }
            });
            thSalesOffline.Start();
            thSalesOffline.Name = "SalesDetailThread";
            thSalesOffline.IsBackground = true;
            //Task task1 = Task.Factory.StartNew(() =>
            //{

            //    if(!InternetConnection.IsConnectedToInternet() 
            //    && WebAPIResource.CheckHttpStatusCode()==true)
            //    {
            //        //lblResponse.Text += "\n" + 
            //        string s = OfflineActivities.SendVendorOfflineSalesDetail();
            //    }
            //    else
            //    {

            //        httpResponseMessage = "not connected to internet! No offline sale invoice upload!";
            //    }

            //});
            Thread thDetailOffline = new Thread(() =>
            {
                if (InternetConnection.IsConnectedToInternet()
                   )
                {
                    // lblResponse.Text += "\n" + 
                    string s2 = OfflineActivities.SendVendorOfflineInvoices();
                }
                else
                {
                    //  httpResponseMessage += "not connected to internet! No offline sale detail upload!";
                }
            });
            thDetailOffline.Start();
            thDetailOffline.Name = "SalesInvoiceThread";
            thDetailOffline.IsBackground = true;
           

            //Task task2 = task1.ContinueWith(antTask =>
            //    {
            //        if (!InternetConnection.IsConnectedToInternet()
            //             && WebAPIResource.CheckHttpStatusCode() == true)
            //        {
            //            // lblResponse.Text += "\n" + 
            //            string s2 = OfflineActivities.SendVendorOfflineInvoices();
            //        }
            //        else
            //        {
            //            httpResponseMessage += "not connected to internet! No offline sale detail upload!";
            //        }

            //    });
            //  lblHttpResponse.Text += httpResponseMessage.ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string message = "";
            #region var initialisation
            long salesMasterID;
            totalAmount = Convert.ToDouble(LbTotal.Text);
            discount = Convert.ToDecimal(LbDiscount.Text);
            salesTaxRate = 15.00;
            salesTax = Convert.ToDouble(LBKpra.Text);
            netAmount = Convert.ToDouble(LbPayable.Text);
            paid = Convert.ToDouble(TBPaid.Text);
            todayTime = DateTime.Parse(System.DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff"), CultureInfo.InvariantCulture);
            // todayTime = DateTime.Parse("2018-18-9 03:05.000");
            description = "Signed by Vendor";
            otherCharges = 10.00;
            businessId = 1;
            businessCode = DatabaseActivities.GetBusinessCode();
            stationId = 0;
            // salesMasterID = OnlineActivities.GetLastMasterIDLocal();
            #endregion end calculations
            #region Local Data Store Operation
            Thread threadSalesLocal = new Thread(() =>
            {
                ConnectionClass.InsertCommand("insert into sales_Master2 values('" + Convert.ToDecimal(totalAmount) + "','" + discount + "','15','" + salesTax + "','" + Convert.ToDecimal(netAmount) + "','" + Convert.ToDecimal(paid) + "','" + InternetConnection.GetBusinessCode() + "','1','" + System.DateTime.Today.ToString("yyyy-MM-dd") + "','1','" + DateTime.Parse(System.DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff")) + "')");
            });
            threadSalesLocal.Start();
            threadSalesLocal.Join();
            //detail list for local
            List<SalesDetail> salesDetailLstLocal = new List<SalesDetail>();

            foreach (ListViewItem item in listView1.Items)
            {
                DataTable dt = ConnectionClass.Selectcommand("select max(salesMasterID) from Sales_Master2");
                SalesDetail salesDetail = new SalesDetail();
                salesDetail.ProductID = Convert.ToInt64(item.SubItems[0].Text);
                salesDetail.ProductName = item.SubItems[1].Text.ToString();
                salesDetail.Quantity = Convert.ToInt32(item.SubItems[2].Text.ToString());
                salesDetail.UnitPrice = Convert.ToDecimal(item.SubItems[3].Text.ToString());
                salesDetail.TotalPrice = Convert.ToDecimal(item.SubItems[4].Text.ToString());
                salesDetail.SalesMasterIDLocal = Convert.ToInt64(dt.Rows[0][0].ToString());
                salesDetailLstLocal.Add(salesDetail);
            }


            Thread threadDetailLocal = new Thread(() =>
            {
                foreach (var item in salesDetailLstLocal)
                {

                    SalesDetail salesDetail = new SalesDetail();
                    DataTable dt = ConnectionClass.Selectcommand("select max(salesMasterID) from Sales_Master2");
                    ConnectionClass.InsertCommand("insert into Sales_Details2 " +
                    " values ('" +
                       item.ProductID + "','" +
                       item.ProductName + "','" +
                       item.Quantity + "','" +
                       item.UnitPrice + "','" +
                       item.TotalPrice + "','" +
                       dt.Rows[0][0].ToString() + "','True')");
                }
            });
            threadDetailLocal.Start();
            threadDetailLocal.Join();
            PrintReport();
            ClearItems();
            
            lblHttpResponse.Text += "items cleared";
            #endregion
            Thread t = new Thread(() =>
            {

                if (InternetConnection.IsConnectedToInternet())
                {

                    // MessageBox.Show(WebAPIResource.statusCodes);
                    //    lblHttpResponse.Text += WebAPIResource.statusCodes.ToString();
                    //message = WebAPIResource.statusCodes.ToString();
                    ConnectionClass.InsertCommand("insert into sales_Master values('" + Convert.ToDecimal(totalAmount) + "','" + discount + "','15','" + salesTax + "','" + Convert.ToDecimal(netAmount) + "','" + Convert.ToDecimal(paid) + "','" + InternetConnection.GetBusinessCode() + "','1','" + System.DateTime.Today.ToString("yyyy-MM-dd") + "','1','" + DateTime.Parse(System.DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff")) + "')");

                    #region comments
                    //List<SalesMasterForLocal> listLocalSalesMaster = new List<SalesMasterForLocal>();
                    //OnlineActivities.StoreSalesMasterDataOnline(Convert.ToDecimal(LbTotal.Text), Convert.ToDecimal(LbDiscount.Text),
                    //     Convert.ToDecimal(ConfigurationManager.AppSettings["sales_tax"]), Convert.ToDecimal(LBKpra.Text),
                    //     Convert.ToDecimal(LbPayable.Text), Convert.ToDecimal(TBPaid.Text),true,
                    //     InternetConnection.GetBusinessCode(),1,System.DateTime.Today.ToString("yyyy-MM-dd"),
                    //     DateTime.Parse(System.DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff")));
                    // //SalesMasterForLocal salesMasterLocalStorage = new SalesMasterForLocal();
                    //salesMasterLocalStorage.TotalAmount = Convert.ToDecimal(LbTotal.Text);
                    //salesMasterLocalStorage.Discount = Convert.ToDecimal(LbDiscount.Text);
                    //salesMasterLocalStorage.SalesTaxRate = Convert.ToDecimal(ConfigurationManager.AppSettings["sales_tax"]);
                    //salesMasterLocalStorage.SalesTax = Convert.ToDecimal(LBKpra.Text);
                    //salesMasterLocalStorage.NetAmount = Convert.ToDecimal(LbPayable.Text);
                    //salesMasterLocalStorage.Paid = Convert.ToDecimal(TBPaid.Text);
                    //salesMasterLocalStorage.isConnected = true;
                    //salesMasterLocalStorage.BusinessCode = InternetConnection.GetBusinessCode();
                    //salesMasterLocalStorage.StationID = 1;
                    //salesMasterLocalStorage.SalesDate = System.DateTime.Today.ToString("yyyy-MM-dd");
                    //salesMasterLocalStorage.SalesDate2 = DateTime.Parse(System.DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff"));
                    //listLocalSalesMaster.Add(salesMasterLocalStorage);
                    #endregion

                }
                else
                {
                    // MessageBox.Show(WebAPIResource.statusCodes);
                    //  lblHttpResponse.Text += WebAPIResource.statusCodes.ToString();
                    ConnectionClass.InsertCommand("insert into sales_Master values('" + Convert.ToDecimal(totalAmount) + "','" + discount + "','15','" + salesTax + "','" + Convert.ToDecimal(netAmount) + "','" + Convert.ToDecimal(paid) + "','" + InternetConnection.GetBusinessCode() + "','1','" + System.DateTime.Today.ToString("yyyy-MM-dd") + "','0','" + DateTime.Parse(System.DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff")) + "')");

                    // lblResponse.Text += "\nSales Master DATA TRANSFER FAILS!";
                }
            }
            );
            t.Start();
            t.IsBackground = true;
            t.Join();

            //lblHttpResponse.Text += message.ToString();
            Thread threadSales = new Thread(() =>
            {
                if (InternetConnection.IsConnectedToInternet())
                {
                    DataTable dt = ConnectionClass.Selectcommand("select max(salesMasterID) from Sales_Master");
                    OnlineActivities.SendOnlineInvoice(totalAmount, discount,
                        salesTaxRate, salesTax, netAmount, paid,
                        todayTime, description,
                        otherCharges, Convert.ToInt64(dt.Rows[0][0].ToString()), InternetConnection.GetBusinessID(), InternetConnection.GetBusinessCode());
                    Thread.Sleep(3000);
                }
                else
                {
                    //update isConnected value to 0 in sales_master table where isConnected Value happened to be 1 recently
                    SqlConnection conn = new SqlConnection(connStaticString);
                    SqlCommand cmd = new SqlCommand("sp_InvertClientUpdateConnectionStatusInSales_Master", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

            });
            threadSales.Start();
            threadSales.IsBackground = true;

            #region lll
            //    foreach (ListViewItem item in listView1.Items)
            //    {
            //        DataTable dt = ConnectionClass.Selectcommand("select max(salesMasterID) from Sales_Master");

            //        //Stopwatch stopwatch = new Stopwatch();
            //        //stopwatch.Start();
            //        Task t1 = Task.Factory.StartNew(() =>
            //        {

            //            ConnectionClass.InsertCommand("insert into Sales_Details " +
            //            " values ('" +
            //               item.SubItems[0].Text + "','" +
            //               item.SubItems[1].Text + "','" +
            //               item.SubItems[2].Text + "','" +
            //               item.SubItems[3].Text + "','" +
            //               item.SubItems[4].Text + "','" +
            //               dt.Rows[0][0].ToString() + "','True')");
            //        });
            //    }//end foreach

            //    if (InternetConnection.IsConnectedToInternet() && InternetConnection.CheckServerConnectivity(serverIP) == true)
            //    {

            //                 foreach (ListViewItem item in listView1.Items)
            //    {
            //        DataTable dt = ConnectionClass.Selectcommand("select max(salesMasterID) from Sales_Master");
            //                   OnlineActivities.SendOnlineSalesDetail(Convert.ToInt64(item.SubItems[0].Text), item.SubItems[1].Text.ToString()
            //           , Convert.ToInt32(item.SubItems[2].Text),
            //           Convert.ToDecimal(item.SubItems[3].Text),
            //           Convert.ToDecimal(item.SubItems[4].Text),
            //           Convert.ToInt64(dt.Rows[0][0].ToString()),
            //           InternetConnection.GetBusinessID(), InternetConnection.GetBusinessCode());
            //            }

            //}//end if
            //else
            //{
            //    foreach (ListViewItem item in listView1.Items)
            //    {
            //        DataTable dt = ConnectionClass.Selectcommand("select max(salesMasterID) from Sales_Master");
            //        ConnectionClass.InsertCommand("insert into Sales_Details " +
            //       " values ('" +
            //          item.SubItems[0].Text + "','" +
            //          item.SubItems[1].Text + "','" +
            //          item.SubItems[2].Text + "','" +
            //          item.SubItems[3].Text + "','" +
            //          item.SubItems[4].Text + "','" +
            //          dt.Rows[0][0].ToString() + "','True')");
            //        lblResponse.Text += "\nSales Detial Data Transfer Fails!";
            //    }//end foreach
            //    PrintReport();
            //}//end else
            #endregion

            #region internet status check was checked per item

            //detail list for transfer
            List<SalesDetail> salesDetailLst = new List<SalesDetail>();

            foreach (var item in salesDetailLstLocal)
            {
                DataTable dt = ConnectionClass.Selectcommand("select max(salesMasterID) from Sales_Master");
                SalesDetail salesDetail = new SalesDetail();
                salesDetail.ProductID = item.ProductID;
                salesDetail.ProductName = item.ProductName;
                salesDetail.Quantity = item.Quantity;
                salesDetail.UnitPrice = item.UnitPrice;
                salesDetail.TotalPrice = item.TotalPrice;
                salesDetail.SalesMasterIDLocal = Convert.ToInt64(dt.Rows[0][0].ToString());
                salesDetailLst.Add(salesDetail);
            }
            //  MessageBox.Show(WebAPIResource.statusCodes);
            // lblHttpResponse.Text += WebAPIResource.statusCodes.ToString();
            // List<SalesDetail> salesDetailList = new List<SalesDetail>();
            Thread t1 = new Thread(() =>
            {
                if (InternetConnection.IsConnectedToInternet())
                {
                    foreach (var item in salesDetailLst)
                    {

                        SalesDetail salesDetail = new SalesDetail();
                        DataTable dt = ConnectionClass.Selectcommand("select max(salesMasterID) from Sales_Master");
                        ConnectionClass.InsertCommand("insert into Sales_Details " +
                        " values ('" +
                           item.ProductID + "','" +
                           item.ProductName + "','" +
                           item.Quantity + "','" +
                           item.UnitPrice + "','" +
                           item.TotalPrice + "','" +
                           dt.Rows[0][0].ToString() + "','True')");
                    }
                }
                else
                {
                    foreach (var item in salesDetailLst)
                    {

                        SalesDetail salesDetail = new SalesDetail();
                        DataTable dt = ConnectionClass.Selectcommand("select max(salesMasterID) from Sales_Master");
                        ConnectionClass.InsertCommand("insert into Sales_Details " +
                        " values ('" +
                           item.ProductID + "','" +
                           item.ProductName + "','" +
                           item.Quantity + "','" +
                           item.UnitPrice + "','" +
                           item.TotalPrice + "','" +
                           dt.Rows[0][0].ToString() + "','False')");
                    }
                    /// PrintReport();
                    ////ClearItems();
                    //  lblHttpResponse.Text += "not connected!";
                }
            });
            t1.Start();
            t1.IsBackground = true;
            t1.Join();
            //PrintReport();


            ////Thread t2 = new Thread(() =>
            ////{
            ////    PrintReport();

            ////});
            ////t2.Start();
            ////t2.Join();
            Thread t3 = new Thread(() =>
            {
                if (InternetConnection.IsConnectedToInternet())
                {
                    foreach (var item in salesDetailLst)
                    {
                        OnlineActivities.SendOnlineSalesDetail(item.ProductID, item.ProductName,
                           Convert.ToInt32(item.Quantity), item.UnitPrice, item.TotalPrice,
                           item.SalesMasterIDLocal,
                           InternetConnection.GetBusinessID(),
                           InternetConnection.GetBusinessCode());
                    }
                }
                else
                {
                    //update isconnected value to 0 in sales_details table where isConnected is equal to 1 recently
                    SqlConnection conn = new SqlConnection(connStaticString);
                    SqlCommand cmd = new SqlCommand("sp_InvertClientUpdateConnectionStatusInSales_Details", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    //   lblHttpResponse.Text += "not connected to internet";
                }
            });
            t3.Start();
            t3.IsBackground = true;
            #endregion
            #region original
            //foreach (ListViewItem item in listView1.Items)
            //{
            //    if (InternetConnection.IsConnectedToInternet() && InternetConnection.CheckServerConnectivity(serverIP) == true)
            //    {
            //        DataTable dt = ConnectionClass.Selectcommand("select max(salesMasterID) from Sales_Master");

            //        //Stopwatch stopwatch = new Stopwatch();
            //        //stopwatch.Start();
            //        Task t1 = Task.Factory.StartNew(() =>
            //        {

            //            ConnectionClass.InsertCommand("insert into Sales_Details " +
            //            " values ('" +
            //               item.SubItems[0].Text + "','" +
            //               item.SubItems[1].Text + "','" +
            //               item.SubItems[2].Text + "','" +
            //               item.SubItems[3].Text + "','" +
            //               item.SubItems[4].Text + "','" +
            //               dt.Rows[0][0].ToString() + "','True')");
            //        });



            //        //stopwatch.Stop();
            //        ////long ts = stopwatch.Elapsed.Seconds;
            //        ////lblTimeElapsed.Text = ts.ToString();
            //        Task t2 = t1.ContinueWith(antTask =>
            //        {


            //            OnlineActivities.SendOnlineSalesDetail(Convert.ToInt64(item.SubItems[0].Text), item.SubItems[1].Text.ToString()
            //               , Convert.ToInt32(item.SubItems[2].Text),
            //               Convert.ToDecimal(item.SubItems[3].Text),
            //               Convert.ToDecimal(item.SubItems[4].Text),
            //               Convert.ToInt64(dt.Rows[0][0].ToString()),
            //               InternetConnection.GetBusinessID(), InternetConnection.GetBusinessCode()

            //               );
            //        });

            //    }

            //    else
            //    {
            //        DataTable dt = ConnectionClass.Selectcommand("select max(salesMasterID) from Sales_Master");
            //        ConnectionClass.InsertCommand("insert into Sales_Details " +
            //       " values ('" +
            //          item.SubItems[0].Text + "','" +
            //          item.SubItems[1].Text + "','" +
            //          item.SubItems[2].Text + "','" +
            //          item.SubItems[3].Text + "','" +
            //          item.SubItems[4].Text + "','" +
            //          dt.Rows[0][0].ToString() + "','True')");
            //        lblResponse.Text += "\nSales Detial Data Transfer Fails!";

            //    }
            //}
            #endregion

        }
        private void ClearItems()
        {
                listView1.Items.Clear();
                LbTotal.Text = LbDiscount.Text = LBKpra.Text = Lbsuntotal.Text = LbPayable.Text = "0";
        }
        private void PrintReport()
        {
            DataTable dt2 = ConnectionClass.Selectcommand("select max(salesMasterID) from sales_Master2");
            ReportDocument rd = new KPRA_RIMS.Reports.Bill();

            rd.RecordSelectionFormula = "{sales_Master2.salesMasterID}=" + dt2.Rows[0][0].ToString();
            ReportViewer obj = new ReportViewer(rd);
            obj.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
/// <summary>
/// THIS EVENT FUNCTION IS USED TO CHECK INTERNET AVAILABILITY. IF THE INTERNET IS AVAILABLE TO THE VENDOR SIDE THIS FUNCTION WILL SEND THE UPDATE INTERNET
/// STATUS TO THE WEB SERVICE ALONG WITH WHO IS USING THE INTERNET....
/// </summary>
/// <param name="sender">THIS PARAM INDICATES WHO IS THE SENDER OF THE EVENT</param>
/// <param name="e">THIS PARAM SHOWS WHAT ARE THE EVENT ARGS</param>
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

        private void LbDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.P)
            {
                Keyboard obj = new Keyboard(LbPayable, TBPaid, button1);
                obj.Show();


            }
        }

        private void lblResponse_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show(lblResponse.Text);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {
           
    }

        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                B = 1;
                DataTable dt = ConnectionClass.Selectcommand("select CategoryName from Category where CategoryName like '%" + metroTextBox1.Text + "%'");
                panel3.Controls.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    AddNewButton(row[0].ToString());
                }
            }
            catch { }
        }

        private void metroTextBox2_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                B = 1;
                DataTable dt11 = ConnectionClass.Selectcommand("select ProductName from Product where ProductName like '%" +metroTextBox2.Text+ "%'");
                flowLayoutPanel1.Controls.Clear();
                foreach (DataRow row in dt11.Rows)
                {
                    AddNewSubButton(row[0].ToString());
                }
            }
            catch { }
        }
        }
}
