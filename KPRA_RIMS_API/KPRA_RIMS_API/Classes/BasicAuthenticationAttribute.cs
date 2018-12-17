namespace KPRA_RIMS_API.Classes
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Security.Principal;
    using System.Text;
    using System.Threading;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;

    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                string parameter = actionContext.Request.Headers.Authorization.Parameter;
                char[] separator = new char[] { ':' };
                //string[] decodedAuthenticationToken = Encoding.UTF8.GetString(Convert.FromBase64String(parameter)).Split(separator);
                //string ntnNumber = creds[0];
                //string businessCode = creds[1];
                string authenticationToken = actionContext.Request.Headers
                                           .Authorization.Parameter;
                string decodedAuthenticationToken = Encoding.UTF8.GetString(
                    Convert.FromBase64String(authenticationToken));
                string[] usernamePasswordArray = decodedAuthenticationToken.Split(':');
                string username = usernamePasswordArray[0];
                string password = usernamePasswordArray[1];
               
                if (VendorSecurity.AuthenticateBusiness(username,password))
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(username), null);
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
        }
    }
}

