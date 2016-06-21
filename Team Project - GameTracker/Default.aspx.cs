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
 * @version: 0.0.2 - Setup GetGames() method, and initialized the calendar week selector on page load
 */

namespace Team_Project___GameTracker
{
    public partial class Default : System.Web.UI.Page
    {
        DateTime week;

        protected void Page_Load(object sender, EventArgs e)
        {

            // set asp calendar to select by week instead of day
            Calendar1.SelectionMode = CalendarSelectionMode.DayWeek;
            ArrayList selectedDates = new ArrayList();
            DateTime today = DateTime.Now;
            DateTime firstDay = today.AddDays(-(double)(today.DayOfWeek));
            for (int loop = 0; loop < 7; loop++)
                Calendar1.SelectedDates.Add(firstDay.AddDays(loop));

            // set global week variable to first day of current week
            DateTime s = firstDay;
            TimeSpan ts = new TimeSpan(24, 0, 0);
            s = s.Date + ts;
            this.week = s;
            System.Diagnostics.Debug.WriteLine(this.week);

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
                System.Diagnostics.Debug.WriteLine(Games);
                // bind the result to the DataList
                GameDataList.DataSource = Games.ToList();
                GameDataList.DataBind();
            }
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
            System.Diagnostics.Debug.WriteLine(this.week);
            // run GetGames to refresh DataList
            this.GetGames();
        }
    }
}