using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using COMP2007_GameTracker_Emma.Models;
using System.Web.ModelBinding;
using System.Data.SqlClient;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace COMP2007_GameTracker_Emma
{
    public partial class Default : System.Web.UI.Page
    {
        /**
         * Load some variables in globally to be used numerous times
         */

        SqlConnection db = new SqlConnection("user id = EmmaH; data source = comp2007emma.database.windows.net; initial catalog = comp2007emma; persist security info = True; user id = EmmaH; password = Emma1031");
        SqlDataReader reader;
        DataTable gamesData = new DataTable();
        DataTable teamsData = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.showOrHideEdit();
                this.GetGames();
                this.GetTeams();
                this.GetWeeks();
            }
        }

        protected void showOrHideEdit()
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                this.GamesGridView.Columns[8].Visible = true;
            }
            else
            {
                this.GamesGridView.Columns[8].Visible = false;
            }
        }

        /**
         * <summary>
         * This function will get the games from the database and bind them to the gridview
         * </summary>
         * 
         * @method GetGames
         * @returns {void}
         */
        protected void GetGames()
        {

            int weekNum = 24;

            SqlCommand getGames = new SqlCommand("SELECT *, (TeamOnePoints+TeamTwoPoints) AS TotalPoints FROM GamesTable WHERE Week = @Week", db);
            getGames.Parameters.AddWithValue("@Week", weekNum);
            db.Open();
            reader = getGames.ExecuteReader();
            gamesData.Load(reader);
            db.Close();

            gamesData.Columns.Add(new DataColumn("TeamOne", typeof(string)));
            gamesData.Columns.Add(new DataColumn("TeamTwo", typeof(string)));
            gamesData.Columns.Add(new DataColumn("GameWinner", typeof(string)));
            gamesData.Columns.Add(new DataColumn("GameNum", typeof(string)));

            int gameNum = 1;

            foreach (DataRow row in gamesData.Rows)
            {
                row["GameNum"] = "Game #" + gameNum;
                gameNum++;

                if (Int32.Parse(row["TeamOneID"].ToString()) == 0)
                {
                    row["TeamOne"] = "";
                }
                else
                {
                    SqlCommand getTeamNames = new SqlCommand("SELECT TeamName FROM TeamTable WHERE TeamID = @ID", db);
                    getTeamNames.Parameters.AddWithValue("@ID", row["TeamOneID"].ToString());
                    db.Open();
                    reader = getTeamNames.ExecuteReader();
                    while (reader.Read())
                    {
                        row["TeamOne"] = (String)reader["TeamName"];
                    }
                    db.Close();
                }

                if (Int32.Parse(row["TeamTwoID"].ToString()) == 0)
                {
                    row["TeamTwo"] = "";
                }
                else
                {
                    SqlCommand getTeamNames = new SqlCommand("SELECT TeamName FROM TeamTable WHERE TeamID = @ID", db);
                    getTeamNames.Parameters.AddWithValue("@ID", row["TeamTwoID"].ToString());
                    db.Open();
                    reader = getTeamNames.ExecuteReader();
                    while (reader.Read())
                    {
                        row["TeamTwo"] = (String)reader["TeamName"];
                    }
                    db.Close();
                }

                if (Int32.Parse(row["Winner"].ToString()) == 0)
                {
                    row["GameWinner"] = "";
                }
                else if (Int32.Parse(row["Winner"].ToString()) == 5)
                {
                    row["GameWinner"] = "Tie";
                }
                else
                {
                    SqlCommand getWinner = new SqlCommand("SELECT TeamName FROM TeamTable WHERE TeamID = @winID", db);
                    getWinner.Parameters.AddWithValue("@winID", row["Winner"].ToString());
                    db.Open();
                    reader = getWinner.ExecuteReader();
                    while (reader.Read())
                    {
                        row["GameWinner"] = (String)reader["TeamName"];
                    }
                    db.Close();
                }
            }


            GamesGridView.DataSource = gamesData.DefaultView;
            GamesGridView.DataBind();

        }

        /**
         * <summary>
         * This function will get the teams from the database, as well as the applicable data (scores) from the database and bind the data to the gridview
         * </summary>
         * 
         * @method GetTeams
         * @returns {void}
         */
        protected void GetTeams()
        {
            SqlCommand getTeams = new SqlCommand("SELECT * FROM TeamTable", db);
            db.Open();
            reader = getTeams.ExecuteReader();
            teamsData.Load(reader);
            db.Close();

            teamsData.Columns.Add(new DataColumn("GameOneScores", typeof(string)));
            teamsData.Columns.Add(new DataColumn("GameTwoScores", typeof(string)));
            teamsData.Columns.Add(new DataColumn("GameThreeScores", typeof(string)));
            teamsData.Columns.Add(new DataColumn("GameFourScores", typeof(string)));

            foreach (DataRow teamsRow in teamsData.Rows)
            {
                foreach (DataRow gameRow in gamesData.Rows)
                {
                    if (teamsRow["TeamID"].ToString() != gameRow["TeamOneID"].ToString() && teamsRow["TeamID"].ToString() != gameRow["TeamTwoID"].ToString())
                    {
                        if (gameRow["GameNum"].ToString() == "Game #1")
                        {
                            teamsRow["GameOneScores"] = "N/A";
                        }
                        else if (gameRow["GameNum"].ToString() == "Game #2")
                        {
                            teamsRow["GameTwoScores"] = "N/A";
                        }
                        else if (gameRow["GameNum"].ToString() == "Game #3")
                        {
                            teamsRow["GameThreeScores"] = "N/A";
                        }
                        else
                        {
                            teamsRow["GameFourScores"] = "N/A";
                        }
                    }
                    else if (teamsRow["TeamID"].ToString() == gameRow["TeamOneID"].ToString())
                    {
                        if (gameRow["GameNum"].ToString() == "Game #1")
                        {
                            teamsRow["GameOneScores"] = "Won " + gameRow["TeamOnePoints"] + " / Lost " + gameRow["TeamTwoPoints"];
                        }
                        else if (gameRow["GameNum"].ToString() == "Game #2")
                        {
                            teamsRow["GameTwoScores"] = "Won " + gameRow["TeamOnePoints"] + " / Lost " + gameRow["TeamTwoPoints"];
                        }
                        else if (gameRow["GameNum"].ToString() == "Game #3")
                        {
                            teamsRow["GameThreeScores"] = "Won " + gameRow["TeamOnePoints"] + " / Lost " + gameRow["TeamTwoPoints"];
                        }
                        else
                        {
                            teamsRow["GameFourScores"] = "Won " + gameRow["TeamOnePoints"] + " / Lost " + gameRow["TeamTwoPoints"];
                        }
                    }
                    else
                    {
                        if (gameRow["GameNum"].ToString() == "Game #1")
                        {
                            teamsRow["GameOneScores"] = "Won " + gameRow["TeamTwoPoints"] + " / Lost " + gameRow["TeamOnePoints"];
                        }
                        else if (gameRow["GameNum"].ToString() == "Game #2")
                        {
                            teamsRow["GameTwoScores"] = "Won " + gameRow["TeamTwoPoints"] + " / Lost " + gameRow["TeamOnePoints"];
                        }
                        else if (gameRow["GameNum"].ToString() == "Game #3")
                        {
                            teamsRow["GameThreeScores"] = "Won " + gameRow["TeamTwoPoints"] + " / Lost " + gameRow["TeamOnePoints"];
                        }
                        else
                        {
                            teamsRow["GameFourScores"] = "Won " + gameRow["TeamTwoPoints"] + " / Lost " + gameRow["TeamOnePoints"];
                        }
                    }
                }
            }

            TeamsGridView.DataSource = teamsData.DefaultView;
            TeamsGridView.DataBind();
        }
        /**
         * <summary>
         * This function will populate the weeks table with 52 weeks (1 for each of the year)
         * </summary>
         * 
         * @method GetWeeks
         * @returns {void}
         */
        protected void GetWeeks()
        {
            for (int week = 1; week <= 52; week++)
            {
                ListItem newWeek = new ListItem(week.ToString(), week.ToString());
                WeekDropDown.Items.Add(newWeek);
            }
        }

        protected void WeekButton_Click(object sender, EventArgs e)
        {

        }
    }
}