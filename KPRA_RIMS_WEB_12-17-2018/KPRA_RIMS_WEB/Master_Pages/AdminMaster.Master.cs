using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KPRA_RIMS_WEB.Master_Pages
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
            
            }
          
                if (base.Session["userName"] == null)
                {
                    this.btnSignout.Visible = false;
                    Response.Redirect("~/Login/AdminLogin.aspx");
                }
                else
                {
                    this.btnSignout.Visible = true;
                    username1.InnerText = (string)Session["userName"].ToString().Trim();
                    username2.InnerText = (string)Session["userName"].ToString().Trim();
                }
         
           
        }

        protected void btnSignout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            base.Session.Clear();
            base.Response.Redirect("~/Login/AdminLogin.aspx");
        }
    }
}