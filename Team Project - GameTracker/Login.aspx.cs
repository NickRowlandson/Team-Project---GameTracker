using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Using statements required for EF DB access
using Team_Project___GameTracker.Models;
using System.Web.ModelBinding;

namespace Team_Project___GameTracker
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            // Use Ef to connect to the server
            using (DefaultConnection db = new DefaultConnection())
            {
               
                // get the id from the URL
                int UserID = 1;

                // get the user from the EF database
                var adminUser = (from user in db.AdminUsers
                                where user.UserID == UserID
                                select user).FirstOrDefault();

                // 
                var email = adminUser.Email;
                var password = adminUser.Password;

                if((email == EmailTextBox.Text) && (password == PasswordTextBox.Text ))
                {
                    // redirect back to the manage games page
                    Response.Redirect("~/ManageGames.aspx");
                }
                else
                {

                }
            }
        }
    }
}