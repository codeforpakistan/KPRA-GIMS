using KPRA_RIMS_WEB.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KPRA_RIMS_WEB.Login
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = "";
            if (this.txtUserName.Value == "kpra_admin")
            {
                FormsAuthentication.RedirectFromLoginPage(this.txtUserName.Value, false);
            }
            List<Users> list = UserAccess.MatchCreds(this.txtUserName.Value, this.txtPassword.Value);
            if (list != null)
            {
                using (List<Users>.Enumerator enumerator = list.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        userName = enumerator.Current.UserName;
                    }
                }
            }
            if (userName != "kpra_admin")
            {
                this.Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Script", "alert('Your account credentials does not exist into the system! Please try again');", true);
            }
            else
            {
                this.Session["userName"] = userName;
                base.Response.Redirect("~/AdminPanel.aspx");
            }

        }
    }
}