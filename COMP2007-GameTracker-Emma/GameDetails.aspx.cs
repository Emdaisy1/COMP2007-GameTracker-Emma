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
    public partial class GameDetails : System.Web.UI.Page
    {

        SqlConnection db = new SqlConnection("user id = EmmaH; data source = comp2007emma.database.windows.net; initial catalog = comp2007emma; persist security info = True; user id = EmmaH; password = Emma1031");
        DataTable dropDownData = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.FillDropdowns();
                this.GetGame();
            }
            errorMessage.Text = "";

        }

        /**
         * <summary>
         * This event handler fills the teams dropdowns with the teams in the database
         * </summary>
         * 
         * @method FillDropdowns
         * @returns {void}
         */
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

        /**
         * <summary>
         * This event handler grabs the data for the game being edited and displays it on the page
         * </summary>
         * 
         * @method GetGame
         * @returns {void}
         */
        protected void GetGame()
        {
            int GameID = Convert.ToInt32(Request.QueryString["GameID"]);

            using (GamesConnection db = new GamesConnection())
            {
                //Populate student object instance with Student ID from URL parameter
                GamesTable updatedGame = (from game in db.GamesTables
                                          where game.GameID == GameID
                                          select game).FirstOrDefault();

                //Map student properties to form controls
                if (updatedGame != null)
                {
                    DescriptionTextBox.Text = updatedGame.Description.ToString();
                    TeamOneDropDown.SelectedValue = updatedGame.TeamOneID.ToString();
                    TeamTwoDropDown.SelectedValue = updatedGame.TeamTwoID.ToString();
                    TeamOnePointsTextBox.Text = updatedGame.TeamOnePoints.ToString();
                    TeamTwoPointsTextBox.Text = updatedGame.TeamTwoPoints.ToString();
                    SpectatorsTextBox.Text = updatedGame.Spectators.ToString();
                }
            }
        }

        /**
         * <summary>
         * This event handler saves the updated game data to the database, updating the game's previous data
         * </summary>
         * 
         * @method SaveButton_Click
         * @param {object} sender
         * @param {EventArgs} e
         * @returns {void}
         */
        protected void SaveButton_Click(object sender, EventArgs e)
        {
            int GameID = Convert.ToInt32(Request.QueryString["GameID"]);

            using (GamesConnection db = new GamesConnection())
            {
                // use the student model to save a new record
                GamesTable updatedGameSave = new GamesTable();


                updatedGameSave = (from game in db.GamesTables
                                   where game.GameID == GameID
                                   select game).FirstOrDefault();

                updatedGameSave.Description = DescriptionTextBox.Text;
                updatedGameSave.TeamOneID = Convert.ToInt32(TeamOneDropDown.SelectedValue);
                updatedGameSave.TeamTwoID = Convert.ToInt32(TeamTwoDropDown.SelectedValue);
                updatedGameSave.TeamOnePoints = Convert.ToInt32(TeamOnePointsTextBox.Text);
                updatedGameSave.TeamTwoPoints = Convert.ToInt32(TeamTwoPointsTextBox.Text);
                updatedGameSave.Spectators = Convert.ToInt32(SpectatorsTextBox.Text);

                if(TeamOnePointsTextBox.Text == TeamTwoPointsTextBox.Text)
                {
                    updatedGameSave.Winner = 5;
                }
                else if(Convert.ToInt32(TeamOnePointsTextBox.Text) > Convert.ToInt32(TeamTwoPointsTextBox.Text))
                {
                    updatedGameSave.Winner = Convert.ToInt32(TeamOneDropDown.SelectedValue);
                }
                else
                {
                    updatedGameSave.Winner = Convert.ToInt32(TeamTwoDropDown.SelectedValue);
                }

                // run insert in DB
                db.SaveChanges();

                // redirect to the updated students page
                Response.Redirect("~/Default.aspx?week=" + updatedGameSave.Week);
            }
        }

        /**
         * <summary>
         * This event handler returns the user to the main page if they cancel editing
         * </summary>
         * 
         * @method CancelButton_Click
         * @param {object} sender
         * @param {EventArgs} e
         * @returns {void}
         */
        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        /**
         * <summary>
         * This event handler adds or removes a warning and enables or disables the save button based on if the user has 
         * selected two different teams (as required) or not
         * </summary>
         * 
         * @method DropDownCheck
         * @param {object} sender
         * @param {EventArgs} e
         * @returns {void}
         */
        protected void DropDownCheck(object sender, EventArgs e)
        {
            if (TeamOneDropDown.SelectedValue == TeamTwoDropDown.SelectedValue)
            {
                errorMessage.Text = "Team one and two cannot be the same team! Please choose 2 different teams!";
                SaveButton.Enabled = false;
            }
            else
            {
                SaveButton.Enabled = true;
            }
        }
    }
}