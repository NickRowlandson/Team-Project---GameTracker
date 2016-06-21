using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//required for Identity and OWIN security
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace Team_Project___GameTracker
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // store session info and authentication methods in the authenticationManager object
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

            // perform sign out
            authenticationManager.SignOut();

            // redirect to login page
            Response.Redirect("~/Login.aspx");
        }
    }
}