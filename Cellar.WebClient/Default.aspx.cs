using Bills.Auth;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cellar.WebClient
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindById(this.Context.User.Identity.GetUserId());

            if (user != null)
            {
                this.Context.Response.Redirect("Models/Home.aspx");
            }
            else
            {
                //this.User.InnerText = string.Empty;
                this.Context.Response.Redirect("Account/pages-login.aspx");
            }

        }
    }
}