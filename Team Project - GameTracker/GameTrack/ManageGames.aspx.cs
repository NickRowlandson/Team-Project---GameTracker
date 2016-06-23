using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

// using statements that are required to connnect to EF DB
using Team_Project___GameTracker.Models;
using System.Web.ModelBinding;

/**
 * @author: Nick Rowlandson & Tim Harasym
 * @date: June 15 2016
 * @version: 0.0.2 - Setup GameDataList_DeleteCommand() method.
 */

namespace Team_Project___GameTracker
{
    public partial class ManageGames : System.Web.UI.Page
    {
        DateTime week;
        protected void Page_Load(object sender, EventArgs e)
        {
            Calendar1.SelectionMode = CalendarSelectionMode.DayWeek;
            ArrayList selectedDates = new ArrayList();

            this.week = Calendar1.SelectedDate;

            this.GetGames();
        }

        /**
         * <summary>
         * This method gets the Games from the DB depending on selected calendar week.
         * </summary>
         * 
         * @method GetGames
         * @return {void}
         */
        protected void GetGames()
        {
            // connect to EF
            using (GameTrackConnection db = new GameTrackConnection())
            {
                // query the games table using EF and LINQ
                var Games = (from allGames in db.Games
                             where allGames.CalendarWeek == this.week
                                select allGames);

                //Count SQL Row results
                var gameCount = (from allGames in db.Games
                                 where allGames.CalendarWeek == this.week
                                 select allGames).Count();

                //Shows warning if week selection contains no data.
                String thisWeek = Convert.ToString(this.week);
                if((gameCount < 1) && (thisWeek != "1/1/0001 12:00:00 AM"))
                {
                    StatusLabel.Text = "There is nothing in this week!";
                    AlertFlash.Visible = true;
                }
                else
                {
                    AlertFlash.Visible = false;
                }

                // bind the result to the DataList
                GameDataList.DataSource = Games.ToList();
                GameDataList.DataBind();
            }
        }

        /**
         * <summary>
         * This method sets the week DateTime variable to the selected calendar week then runs the GetGames method to refresh the DataList.
         * </summary>
         * 
         * @method Calendar1_SelectionChanged
         * @return {void}
         */
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            // set week global variable to selected calendar week
            this.week = Calendar1.SelectedDate;
            
            // run GetGames to refresh DataList
            this.GetGames();
        }

        /**
         * <summary>
         * This method renders each day shown in the calendar as non-selectable. 
         * </summary>
         * 
         * @method Calendar1_DayRender
         * @return {void}
         */
        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            // sets days in calendar to non-selectable
            e.Day.IsSelectable = false;
        }

        /**
         * <summary>
         * This method processes the game delete functionality.
         * </summary>
         * 
         * @method GameDataList_DeleteCommand
         * @return {void}
         */
        protected void GameDataList_DeleteCommand(object source, DataListCommandEventArgs e)
        {

            int GameID = Convert.ToInt32(GameDataList.DataKeys[e.Item.ItemIndex]);

            using (GameTrackConnection db = new GameTrackConnection())
            {
                // create object of the game class and store the query string inside of it
                Game deletedGame = (from gameRecords in db.Games
                                          where gameRecords.GameID == GameID
                                          select gameRecords).FirstOrDefault();

                // remove the selected game from the db
                db.Games.Remove(deletedGame);

                // save changes back to the db
                db.SaveChanges();

                // refresh the grid
                this.GetGames();
            }
        }
    }
}