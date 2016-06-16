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

namespace COMP2007_GameTracker_Emma
{
    public partial class Default : System.Web.UI.Page
    {
        SqlConnection db = new SqlConnection("user id = EmmaH; data source = comp2007emma.database.windows.net; initial catalog = comp2007emma; persist security info = True; user id = EmmaH; password = Emma1031");
        SqlDataReader reader;
        DataTable gamesData = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.GetGames();
                this.GetTeams();
            }
        }

        protected void GetGames()
        {
            
            int weekNum = 24;
            bool loggedIn = true;

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
                    while(reader.Read())
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

        protected void GetTeams()
        { 
            /*
             * var Teams = (from allTeams in db.TeamTables
                         select allTeams);
            TeamsGridView.DataSource = Teams.AsQueryable().ToList();
            TeamsGridView.DataBind();
            */
        }
    }
}