using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;


namespace COMP2007_GameTracker_Emma
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /**
         * <summary>
         * This event handler attempts to log the user in, showing an error message if it fails
         * or logging them in to the main games page if it succeeds
         * </summary>
         * 
         * @method RegisterButton_Click
         * @param {object} sender
         * @param {EventArgs} e
         * @returns {void}
         */
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);
            var user = userManager.Find(UserNameTextBox.Text, PasswordTextBox.Text);
            //If a user is found, log in - if not, display error message
            if (user != null)
            {
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, userIdentity);
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                loginErrorMessage.Text = "Invalid username or password!";
                loginErrorMessage.Visible = true;
            }
        }


        /**
         * <summary>
         * This event handler redirects the user to the main games page if they cancel logging in
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
    }
}