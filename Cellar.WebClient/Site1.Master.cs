using Bills.Auth;
using Cellar.WebClient.Models;
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
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindById(this.Context.User.Identity.GetUserId());

            if (user != null)
            {
                this.User.InnerText = user.Name;
            }
            else
            {
                
                
            }

        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            this.Context.Response.Redirect("~/Account/pages-logout.aspx");
        }
    }
}