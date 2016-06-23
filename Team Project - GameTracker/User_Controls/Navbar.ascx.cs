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

/**
 * @author: Nick Rowlandson & Tim Harasym
 * @date: June 15 2016
 * @version: 0.0.1 - added the SetActivePage method.
 */
namespace Team_Project___GameTracker
{
    public partial class Navbar : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // check is a user is logged in
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    PrivatePlaceHolder.Visible = true;
                    PublicPlaceHolder.Visible = false;

                    if (HttpContext.Current.User.Identity.GetUserName() == "admin")
                    {
                        UserPlaceHolder.Visible = true;
                    }
                    else
                    {
                        UserPlaceHolder.Visible = false;
                    }
                }
                else 
                {
                    PrivatePlaceHolder.Visible = false;
                    PublicPlaceHolder.Visible = true;
                    UserPlaceHolder.Visible = false;
                }
            }

            addActiveClass();
        }

        /**
         * This method sets the class 'active' to list items 
         * in navigation links
         * 
         * @method addActiveClass
         * @return {string}
         */
        private string addActiveClass()
        {
            Object activeNode = (System.Web.UI.HtmlControls.HtmlGenericControl)FindControl(Page.Title.ToString().ToLower().Replace(" ", String.Empty));
            if (activeNode != null)
            {
                ((System.Web.UI.HtmlControls.HtmlGenericControl)activeNode).Attributes.Add("class", "active");
            }
            return (Page.Title.ToString().ToLower().Replace(" ", String.Empty));
        }
    }
}