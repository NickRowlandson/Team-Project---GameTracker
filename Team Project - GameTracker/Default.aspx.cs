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

namespace Team_Project___GameTracker
{
    public partial class Default : System.Web.UI.Page
    {
        DateTime week;
        protected void Page_Load(object sender, EventArgs e)
        {
            Calendar1.SelectionMode = CalendarSelectionMode.DayWeek;
            ArrayList selectedDates = new ArrayList();
            DateTime today = DateTime.Now;
            DateTime firstDay = today.AddDays(-(double)(today.DayOfWeek));
            for (int loop = 0; loop < 7; loop++)
                Calendar1.SelectedDates.Add(firstDay.AddDays(loop));
            this.week = firstDay;
        }

        protected void GetGames()
        {
            // connect to EF
            using (DefaultConnection db = new DefaultConnection())
            {

                // query the games table using EF and LINQ
                var Games = (from allGames in db.Games
                             where allGames.CalendarWeek == week
                             select allGames);

                // bind the result to the GridView
                GameDataList.DataSource = Games.ToList();
                GameDataList.DataBind();
            }
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            e.Day.IsSelectable = false;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            this.week = Calendar1.SelectedDate;

            this.GetGames();
        }
    }
}