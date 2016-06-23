using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

/*
 * @Author: Emma Hilborn - 200282755
 */

namespace COMP2007_GameTracker_Emma
{
    public partial class Navbar : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Check if a user is logged in and display the right navbar areas based on that
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    RegisteredUser.Visible = true;
                    PublicUser.Visible = false;
                    greeting.InnerText = "Welcome, " + HttpContext.Current.User.Identity.GetUserName() + "!";
                    GreetUser.Visible = true;
                }
                else
                {
                    RegisteredUser.Visible = false;
                    PublicUser.Visible = true;
                    GreetUser.Visible = false;
                }
                SetActivePage();
            }
        }


        /**
         * This method adds the "active" CSS class to the list items
         * on the nav bar on each page
         * 
         * @method SetActivePage
         * @return (void)
         */
        private void SetActivePage()
        {
            switch (Page.Title)
            {
                case "Home Page":
                    home.Attributes.Add("class", "active");
                    break;
                case "Login":
                    login.Attributes.Add("class", "active");
                    break;
                case "Register":
                    register.Attributes.Add("class", "active");
                    break;
                case "Profile":
                    profile.Attributes.Add("class", "active");
                    break;
            }
        }
    }
}