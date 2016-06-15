using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using COMP2007_GameTracker_Emma.Models;
using System.Web.ModelBinding;

namespace COMP2007_GameTracker_Emma
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.GetGames();
            }
        }

        protected void GetGames()
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                int weekNum = 24;
                var Games = (from allGames in db.GamesTables
                             where allGames.Week == weekNum
                                select allGames);

                GamesGridView.DataSource = Games.AsQueryable().ToList();
                GamesGridView.DataBind();

                var Teams = (from allTeams in db.TeamTables
                             select allTeams);
                TeamsGridView.DataSource = Teams.AsQueryable().ToList();
                TeamsGridView.DataBind();
            }

        }
    }
}