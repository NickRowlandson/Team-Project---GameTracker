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
 * @version: 0.0.2 - Setup LoginButton_Click() method.
 */

namespace Team_Project___GameTracker
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { 
            /*
             * USE THIS TO REGISTER ADMIN
             * 
            // create new userStore and userManager objects
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);

            // create a new user object
            var user = new IdentityUser()
            {
                UserName = "admin",
                PhoneNumber = "1234567879",
                Email = "admin@gametrack.com"
            };

            // create a new user in the db and store the result
            IdentityResult result = userManager.Create(user, "gametrackadmin");

            if (result.Succeeded)
            {
                StatusLabel.Text = "should be good";
                AlertFlash.Visible = true;
            }
            else
            {
                // display error in the AlertFlash div
                StatusLabel.Text = result.Errors.FirstOrDefault();
                AlertFlash.Visible = true;
            }
            */
        }

        /**
         * <summary>
         * This method takes login credentials from form and runs them against the database.(NEEDS WORK. *AUTHENTICATION* *PASSWORDHASH*)
         * </summary>
         * 
         * @method LoginButton_Click
         * @return {void}
         */
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            // create new userStore and userManager objects
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);

            // search for and create a new user object
            var user = userManager.Find(UserNameTextBox.Text, PasswordTextBox.Text);

            // if a match is a found for the user
            if (user != null)
            {
                // authenticate and login our new user
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                // sign in user
                authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, userIdentity);

                // redirect to main menu
                Response.Redirect("~/GameTrack/ManageGames.aspx");
            }
            else
            {
                // throw an error to the AlertFlash div
                StatusLabel.Text = "Invalid Username or Password";
                AlertFlash.Visible = true;
            }
        }
    }
}