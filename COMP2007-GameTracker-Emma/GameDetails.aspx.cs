﻿using System;
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
    public partial class GameDetails : System.Web.UI.Page
    {

        SqlConnection db = new SqlConnection("user id = EmmaH; data source = comp2007emma.database.windows.net; initial catalog = comp2007emma; persist security info = True; user id = EmmaH; password = Emma1031");
        DataTable dropDownData = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.FillDropdowns();
            this.GetGame();
        }

        protected void FillDropdowns()
        {
            SqlDataAdapter adpt = new SqlDataAdapter("SELECT TeamID, TeamName FROM TeamTable", db);
            adpt.Fill(dropDownData);
            TeamOneDropDown.DataSource = dropDownData;
            TeamOneDropDown.DataBind();
            TeamOneDropDown.DataTextField = "TeamName";
            TeamOneDropDown.DataValueField = "TeamID";
            TeamOneDropDown.DataBind();

            TeamTwoDropDown.DataSource = dropDownData;
            TeamTwoDropDown.DataBind();
            TeamTwoDropDown.DataTextField = "TeamName";
            TeamTwoDropDown.DataValueField = "TeamID";
            TeamTwoDropDown.DataBind();
        }

        protected void GetGame()
        {
            int GameID = Convert.ToInt32(Request.QueryString["GameID"]);

            using (DefaultConnection db = new DefaultConnection())
            {
                //Populate student object instance with Student ID from URL parameter
                GamesTable updatedGame = (from game in db.GamesTables
                                          where game.GameID == GameID
                                          select game).FirstOrDefault();

                //Map student properties to form controls
                if (updatedGame != null)
                {
                    TeamOneDropDown.SelectedValue = updatedGame.TeamOneID.ToString();
                    TeamTwoDropDown.SelectedValue = updatedGame.TeamTwoID.ToString();
                    TeamOnePointsTextBox.Text = updatedGame.TeamOnePoints.ToString();
                    TeamTwoPointsTextBox.Text = updatedGame.TeamTwoPoints.ToString();
                    SpectatorsTextBox.Text = updatedGame.Spectators.ToString();
                }
            }
        }
    }
}