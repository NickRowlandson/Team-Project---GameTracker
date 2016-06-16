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

namespace Team_Project___GameTracker.User_Controls
{
    public partial class Jumbotron : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            JumbotronH1.InnerText = "Welcome to Game-Tracker!";
            JumbotronH3.InnerText = "Select a calendar week...";
        }
    }
}