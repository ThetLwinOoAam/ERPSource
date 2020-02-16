using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace CustomerWebApi
{
    public class BasicAuthorizationFilterAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                return;
            }
            string token = actionContext.Request.Headers.Authorization.Parameter;
            string dcdToken = Encoding.UTF8.GetString(Convert.FromBase64String(token));
            string[] values = dcdToken.Split(';');
            if (values[0] != "a@gmail.com")
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                return;
            }
            Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(values[0]), null);
        }
    }

}