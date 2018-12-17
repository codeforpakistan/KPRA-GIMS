namespace KPRA_RIMS_API.Controllers
{
    using KPRA_RIMS.Classes;
    using KPRA_RIMS_API.Classes;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Net;
    using System.Net.Http;
    using System.Web.Configuration;
    using System.Web.Http;

    [BasicAuthentication]
    public class SalesController : ApiController
    {
        private string connString = WebConfigurationManager.ConnectionStrings["kpra_db_connection"].ConnectionString;
        private HttpResponseMessage resp;

        //[HttpGet]
        //public HttpResponseMessage RetrieveSalesDetails() => 
        //    new HttpResponseMessage();

        [HttpGet]
        public HttpResponseMessage RetrieveSalesInvoice()
        {
            List<string> list = new List<string>();
            HttpRequestMessage request = base.Request;
            list.Add(request.RequestUri.ToString());
            list.Add(request.Headers.Host);
            list.Add(request.Headers.Accept.ToString());
            list.Add(request.Headers.IfNoneMatch.ToString());
            foreach (string local1 in list)
            {
                this.resp = base.Request.CreateResponse<List<string>>(HttpStatusCode.OK, list);
            }
            return this.resp;
        }

        //[HttpGet]
        //public HttpResponseMessage RetrieveSalesOfflineInvoice() => 
        //    new HttpResponseMessage();

        [HttpPost]
        public HttpResponseMessage SalesDetail([FromBody] KPRA_RIMS.Classes.SalesDetail salesDetail)
        {
            SqlConnection connection = new SqlConnection(this.connString);
            try
            {
                SqlCommand stateObject = new SqlCommand("sp_InsertSalesDetailsKPRA", connection) {
                    CommandType = CommandType.StoredProcedure
                };
                stateObject.Parameters.AddWithValue("@ProductID", salesDetail.ProductID);
                stateObject.Parameters.AddWithValue("@ProductName", salesDetail.ProductName);
                stateObject.Parameters.AddWithValue("@Quantity", salesDetail.Quantity);
                stateObject.Parameters.AddWithValue("@UnitPrice", salesDetail.UnitPrice);
                stateObject.Parameters.AddWithValue("@TotalPrice", salesDetail.TotalPrice);
                stateObject.Parameters.AddWithValue("@SalesMaster_Id", salesDetail.SalesMasterIDLocal);
                stateObject.Parameters.AddWithValue("@businessIDLocal", salesDetail.BusinessIDLocal);
                stateObject.Parameters.AddWithValue("@businessCode", salesDetail.BusinessCode);
                connection.Open();
                IAsyncResult result = stateObject.BeginExecuteNonQuery(new AsyncCallback(AsynchSql.CallBack), stateObject);
                while (!result.IsCompleted)
                {
                    this.resp = base.Request.CreateResponse<KPRA_RIMS.Classes.SalesDetail>(HttpStatusCode.Created, salesDetail);
                }
            }
            catch (SqlException)
            {
            }
            catch (Exception)
            {
            }
            finally
            {
                if (connection != null)
                {
                    connection.Dispose();
                }
            }
            return this.resp;
        }

        [HttpPost]
        public HttpResponseMessage SalesDetailOfflineInvoice([FromBody] List<KPRA_RIMS.Classes.SalesDetail> salesDetail)
        {
            using (SqlConnection connection = new SqlConnection(this.connString))
            {
                SqlCommand stateObject = new SqlCommand("INSERT INTO Sales_Details(ProductID,ProductName,Quantity,UnitPrice,TotalPrice,salesMasterIDLocal,businessIDLocal,businessCode) VALUES(@ProductID,@ProductName,@Quantity,@UnitPrice,@TotalPrice,@salesMasterIDLocal,@businessIDLocal,@businessCode)", connection);
                stateObject.Parameters.Add("@ProductID", SqlDbType.BigInt);
                stateObject.Parameters.Add("@ProductName", SqlDbType.NVarChar);
                stateObject.Parameters.Add("@Quantity", SqlDbType.BigInt);
                stateObject.Parameters.Add("@UnitPrice", SqlDbType.Decimal);
                stateObject.Parameters.Add("@TotalPrice", SqlDbType.Decimal);
                stateObject.Parameters.Add("@salesMasterIDLocal", SqlDbType.BigInt);
                stateObject.Parameters.Add("@businessIDLocal", SqlDbType.BigInt);
                stateObject.Parameters.Add("@businessCode", SqlDbType.VarChar);
                if (salesDetail != null)
                {
                    foreach (KPRA_RIMS.Classes.SalesDetail detail in salesDetail)
                    {
                        stateObject.Parameters[0].Value = detail.ProductID;
                        stateObject.Parameters[1].Value = detail.ProductName;
                        stateObject.Parameters[2].Value = detail.Quantity;
                        stateObject.Parameters[3].Value = detail.UnitPrice;
                        stateObject.Parameters[4].Value = detail.TotalPrice;
                        stateObject.Parameters[5].Value = detail.SalesMasterIDLocal;
                        stateObject.Parameters[6].Value = detail.BusinessIDLocal;
                        stateObject.Parameters[7].Value = detail.BusinessCode;
                        connection.Open();
                        AsyncCallback callback = new AsyncCallback(AsynchSql.CallBack);
                        IAsyncResult result = stateObject.BeginExecuteNonQuery(callback, stateObject);
                        while (true)
                        {
                            if (result.IsCompleted)
                            {
                                connection.Close();
                                break;
                            }
                            this.resp = base.Request.CreateResponse<List<KPRA_RIMS.Classes.SalesDetail>>(HttpStatusCode.Created, salesDetail);
                        }
                    }
                }
            }
            return this.resp;
        }

        [HttpPost]
        public HttpResponseMessage SalesInvoice([FromBody] Sales sales)
        {
            SqlConnection connection = new SqlConnection(this.connString);
            try
            {
                SqlCommand stateObject = new SqlCommand("INSERT INTO sales_master(totalAmount,discount,salesTaxRate,salesTax,netAmount,Paid,salesDate,description,otherCharges,salesMasterIDLocal,businessIDLocal,businessCode) VALUES(@totalAmount,@Discount,@salesTaxRate,@salesTax,@netAmount,@Paid,@salesDate,@description,@otherCharges,@salesMasterIDLocal,@businessIDLocal,@businessCode)", connection);
                stateObject.Parameters.AddWithValue("@totalAmount", sales.TotalAmount);
                stateObject.Parameters.AddWithValue("@Discount", sales.Discount);
                stateObject.Parameters.AddWithValue("@salesTaxRate", sales.SalesTaxRate);
                stateObject.Parameters.AddWithValue("@salesTax", sales.SalesTax);
                stateObject.Parameters.AddWithValue("@netAmount", sales.NetAmount);
                stateObject.Parameters.AddWithValue("@Paid", sales.Paid);
                stateObject.Parameters.AddWithValue("@salesDate", DateTime.Parse(sales.TodayTime.ToString()));
                stateObject.Parameters.AddWithValue("@description", sales.Description);
                stateObject.Parameters.AddWithValue("@otherCharges", sales.OtherCharges);
                stateObject.Parameters.AddWithValue("@salesMasterIDLocal", sales.SalesMasterIDLocal);
                stateObject.Parameters.AddWithValue("@businessIDLocal", sales.BusinessIDLocal);
                stateObject.Parameters.AddWithValue("@businessCode", sales.BusinessCode);
                connection.Open();
                IAsyncResult result = stateObject.BeginExecuteNonQuery(new AsyncCallback(AsynchSql.CallBack), stateObject);
                while (!result.IsCompleted)
                {
                    this.resp = base.Request.CreateResponse<Sales>(HttpStatusCode.Created, sales);
                }
            }
            catch (SqlException)
            {
            }
            catch (Exception)
            {
            }
            finally
            {
                if (connection != null)
                {
                    connection.Dispose();
                }
            }
            return this.resp;
        }

        [HttpPost]
        public HttpResponseMessage SalesOfflineInvoice([FromBody] List<Sales> sales)
        {
            SqlConnection connection = new SqlConnection(this.connString);
            SqlCommand command = new SqlCommand("INSERT INTO sales_master(totalAmount,Discount,SalesTaxRate,NetAmount,Paid,salesDate,salesTax,salesMasterIDLocal,businessIDLocal,businessCode) VALUES(@totalAmount,@discount,@salesTaxRate,@netAmount,@Paid,@salesDate,@salesTax,@SalesMasterIDLocal,@businessIDLocal,@businessCode)", connection);
            connection.Open();
            command.Parameters.Add("@totalAmount", SqlDbType.Decimal);
            command.Parameters.Add("@discount", SqlDbType.Decimal);
            command.Parameters.Add("@salesTaxRate", SqlDbType.Decimal);
            command.Parameters.Add("@netAmount", SqlDbType.Decimal);
            command.Parameters.Add("@Paid", SqlDbType.Decimal);
            command.Parameters.Add("@salesDate", SqlDbType.DateTimeOffset);
            command.Parameters.Add("@salesTax", SqlDbType.Decimal);
            command.Parameters.Add("@salesMasterIDLocal", SqlDbType.BigInt);
            command.Parameters.Add("@businessIDLocal", SqlDbType.BigInt);
            command.Parameters.Add("@businessCode", SqlDbType.VarChar);
            if (sales != null)
            {
                foreach (Sales sales2 in sales)
                {
                    command.Parameters[0].Value = sales2.TotalAmount;
                    command.Parameters[1].Value = sales2.Discount;
                    command.Parameters[2].Value = sales2.SalesTaxRate;
                    command.Parameters[3].Value = sales2.NetAmount;
                    command.Parameters[4].Value = sales2.Paid;
                    command.Parameters[5].Value = DateTime.Parse(sales2.TodayTime.ToString());
                    command.Parameters[6].Value = sales2.SalesTax;
                    command.Parameters[7].Value = sales2.SalesMasterIDLocal;
                    command.Parameters[8].Value = sales2.BusinessIDLocal;
                    command.Parameters[9].Value = sales2.BusinessCode;
                    command.ExecuteNonQuery();
                }
            }
            connection.Close();
            this.resp = base.Request.CreateResponse<List<Sales>>(HttpStatusCode.OK, sales);
            return this.resp;
        }
    }
}

