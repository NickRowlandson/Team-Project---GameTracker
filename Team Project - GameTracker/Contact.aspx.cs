using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/**
 * @author: Nick Rowlandson & Tim Harasym
 * @date: June 15 2016
 * @version: 0.0.1  
 */

namespace Team_Project___GameTracker
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SendButton_Click(object sender, EventArgs e)
        {
            //replace this with email processing code
            Response.Redirect("Default.aspx");
        }
    }
}