using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

// Using statements required for EF DB access
using Team_Project___GameTracker.Models;
using System.Web.ModelBinding;
using System.Reflection;

/**
 * @author: Nick Rowlandson & Tim Harasym
 * @date: June 15 2016
 * @version: 0.0.2 - Setup calendar week selection for form.
 */

namespace Team_Project___GameTracker
{
    public partial class GameDetails : System.Web.UI.Page
    {
        DateTime week;
        protected void Page_Load(object sender, EventArgs e)
        {
            // set asp calendar to select by week instead of day
            Calendar2.SelectionMode = CalendarSelectionMode.DayWeek;
            ArrayList selectedDates = new ArrayList();
            DateTime today = DateTime.Now;
            DateTime firstDay = today.AddDays(-(double)(today.DayOfWeek));
            for (int loop = 0; loop < 7; loop++)
                Calendar2.SelectedDates.Add(firstDay.AddDays(loop));

            // set global week variable to first day of current week
            this.week = Calendar2.SelectedDate;

            // convert week to string and format to display as MM/dd/yyyy
            var formatWeek = week.ToString("MM/dd/yyyy");

            // if post back and querystring then run GetGame.
            if ((!IsPostBack) && (Request.QueryString.Count > 0))
            {
                this.GetGame();
            }
            int errorID = Convert.ToInt32(Request.QueryString["error"]);
            if (errorID == 1)
            {
                // throw an error to the AlertFlash div
                StatusLabel.Text = "Error: There are already 4 games in this calendar week. Please select another week.";
                AlertFlash.Visible = true;

                PropertyInfo isreadonly =
                  typeof(System.Collections.Specialized.NameValueCollection).GetProperty(
                  "IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
                // make collection editable
                isreadonly.SetValue(this.Request.QueryString, false, null);
                // remove
                this.Request.QueryString.Remove("error");
            }else
            {
                AlertFlash.Visible = false;
            }
        }

        /**
         * <summary>
         * This method gets the Games from the DB depending on selected calendar week and handles edit functionality.
         * </summary>
         * 
         * @method GetGame
         * @return {void}
         */
        protected void GetGame()
        {
            // populate the form with existing data from the database
            int GameID = Convert.ToInt32(Request.QueryString["GameID"]);

            // connect to the EF DB
            using (GameTrackConnection db = new GameTrackConnection())
            {
                // populate a game object instance with the gameID from the URL parameter
                Game updatedGame = (from game in db.Games
                                          where game.GameID == GameID
                                          select game).FirstOrDefault();

                // map the game properties to the form controls
                if (updatedGame != null)
                {
                    GameNameTextBox.Text = updatedGame.GameName;
                    TeamOneTextBox.Text = updatedGame.TeamOne;
                    TeamOneScoreTextBox.Text = updatedGame.TeamOneScore;
                    TeamTwoTextBox.Text = updatedGame.TeamTwo;
                    TeamTwoScoreTextBox.Text = updatedGame.TeamTwoScore;
                    GameResultTextBox.Text = updatedGame.GameResult;
                    CalendarWeekTextBox.Text = updatedGame.CalendarWeek.ToString("yyyy-MM-dd");
                }
            }
        }

        /**
         * <summary>
         * This method
         * </summary>
         * 
         * @method SaveButton_Click
         * @return {void}
         */
        protected void SaveButton_Click(object sender, EventArgs e)
        {
            // Use Ef to connect to the server
            using (GameTrackConnection db = new GameTrackConnection())
            {
                // Use the game model to create a new game object and also save a new record
                Game newGame = new Game();

                int GameID = 0;

                if (Request.QueryString.Count > 0) // our URL has a GameID in it
                {
                    // get the id from the URL
                    GameID = Convert.ToInt32(Request.QueryString["GameID"]);

                    // get the current game from the EF database
                    newGame = (from game in db.Games
                                  where game.GameID == GameID
                                  select game).FirstOrDefault();
                }

                // add data to the new game record
                newGame.GameName = GameNameTextBox.Text;
                newGame.TeamOne = TeamOneTextBox.Text;
                newGame.TeamOneScore = TeamOneScoreTextBox.Text;
                newGame.TeamTwo = TeamTwoTextBox.Text;
                newGame.TeamTwoScore = TeamTwoScoreTextBox.Text;
                newGame.GameResult = GameResultTextBox.Text;
                newGame.CalendarWeek = Convert.ToDateTime(CalendarWeekTextBox.Text);

                //Check if more than 4 records for selected week.
                this.checkGame(CalendarWeekTextBox.Text);

                // use LINQ to ADO.NET to add / insert new game into the database

                if (GameID == 0)
                {
                    db.Games.Add(newGame);
                }

                // save our changes
                db.SaveChanges();
                
                // redirect back to the updated manage games page
                Response.Redirect("~/GameTrack/ManageGames.aspx");
            }
        }

        /**
         * <summary>
         * This method sets the week DateTime variable to the selected calendar week.
         * </summary>
         * 
         * @method Calendar2_SelectionChanged
         * @return {void}
         */
        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            // set week global variable to selected calendar week
            this.week = Calendar2.SelectedDate;

            // convert week to string and format to display as MM/dd/yyyy
            var formatWeek = week.ToString("MM/dd/yyyy");

            // set CalendarWeekTextBox equal to selected calendar week
            CalendarWeekTextBox.Text = formatWeek;
        }

        /**
         * <summary>
         * This method renders each day shown in the calendar as non-selectable.
         * </summary>
         * 
         * @method Calendar2_DayRender
         * @return {void}
         */
        protected void Calendar2_DayRender(object sender, DayRenderEventArgs e)
        {
            // sets days in calendar to non-selectable
            e.Day.IsSelectable = false;
        }

         /**
         * <summary>
         * This method gets checks if there are 4 games in the selected calendar week. If yes then redirect.
         * </summary>
         * 
         * @method checkGAme
         * @return {void}
         */
 
        protected void checkGame(String selectedWeek)
        {
            DateTime formattedWeek = Convert.ToDateTime(selectedWeek);
            // connect to EF
            using (GameTrackConnection db = new GameTrackConnection())
            {
                // query the games table using EF and LINQ
                var gameCount = (from allGames in db.Games
                             where allGames.CalendarWeek == formattedWeek
                             select allGames).Count();

                System.Diagnostics.Debug.WriteLine(gameCount);
                if(gameCount >= 4)
                {
                    // redirect back to the updated manage games page
                    Response.Redirect("~/GameTrack/GameDetails.aspx?error=1");
                }
            }
        }
        
    }
}
