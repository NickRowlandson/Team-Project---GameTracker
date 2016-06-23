using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// using statements that are required to connnect to EF DB
using Team_Project___GameTracker.Models;
using System.Web.ModelBinding;

/**
 * @author: Nick Rowlandson & Tim Harasym
 * @date: June 22 2016
 * @version: 0.0.1 - Setup delete function.
 */

namespace Team_Project___GameTracker.Admin
{
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                this.GetUsers();
            }
        }

        /**
         * <summary>
         * This method gets all users from the DB.
         * </summary>
         * 
         * @method GetUsers
         * @return {void}
         */
        protected void GetUsers()
        {
            using (UserConnection db = new UserConnection())
            {
                var Users = (from users in db.AspNetUsers
                             select users);

                UsersGridView.DataSource = Users.ToList();
                UsersGridView.DataBind();
            }
        }

        /**
         * <summary>
         * This method deletes selected user from the DB.
         * </summary>
         * 
         * @method UsersGridView_RowDeleting
         * @return {void}
         */
        protected void UsersGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int selectedRow = e.RowIndex;

            string userID = UsersGridView.DataKeys[selectedRow].Values["Id"].ToString();

            using (UserConnection db = new UserConnection())
            {
                AspNetUser deletedUser = (from users in db.AspNetUsers
                                          where users.Id == userID
                                          select users).FirstOrDefault();

                db.AspNetUsers.Remove(deletedUser);
                db.SaveChanges();
            }
        }
    }
}