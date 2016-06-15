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

namespace Team_Project___GameTracker
{
    public partial class GameDetails : System.Web.UI.Page
    {
        DateTime week;
        protected void Page_Load(object sender, EventArgs e)
        {
            Calendar2.SelectionMode = CalendarSelectionMode.DayWeek;
            ArrayList selectedDates = new ArrayList();
            DateTime today = DateTime.Now;
            DateTime firstDay = today.AddDays(-(double)(today.DayOfWeek));
            for (int loop = 0; loop < 7; loop++)
                Calendar2.SelectedDates.Add(firstDay.AddDays(loop));
            this.week = firstDay;

            if ((!IsPostBack) && (Request.QueryString.Count > 0))
            {
                this.GetGame();
            }
        }

        protected void GetGame()
        {
            // populate the form with existing data from the database
            int GameID = Convert.ToInt32(Request.QueryString["GameID"]);

            // connect to the EF DB
            using (DefaultConnection db = new DefaultConnection())
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

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            // Use Ef to connect to the server
            using (DefaultConnection db = new DefaultConnection())
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

                // use LINQ to ADO.NET to add / insert new game into the database

                if (GameID == 0)
                {
                    db.Games.Add(newGame);
                }

                // save our changes
                db.SaveChanges();

                // redirect back to the updated manage games page
                Response.Redirect("~/ManageGames.aspx");
            }
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            this.week = Calendar2.SelectedDate;

            var formatWeek = week.ToString("MM/dd/yyyy");

            CalendarWeekTextBox.Text = formatWeek;
        }

        protected void Calendar2_DayRender(object sender, DayRenderEventArgs e)
        {
            e.Day.IsSelectable = false;
        }
    }
}
