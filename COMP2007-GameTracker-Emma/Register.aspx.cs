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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /**
         * <summary>
         * This event handler redirects the user to the main games page if they cancel registration
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
         * This event handler attempts to register the user, showing them an error message if unsuccessful, or logging them
         * in and returning them to the main games page if succesful
         * </summary>
         * 
         * @method RegisterButton_Click
         * @param {object} sender
         * @param {EventArgs} e
         * @returns {void}
         */
        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);

            var user = new IdentityUser()
            {
                UserName = UserNameTextBox.Text,
                Email = EmailTextBox.Text
            };
            
            IdentityResult result = userManager.Create(user, PasswordTextBox.Text);

            //If user registers succesfully, bring back to main details page - if not, show error
            if (result.Succeeded)
            {
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authenticationManager.SignIn(new AuthenticationProperties() { }, userIdentity);
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                registerErrorMessage.Text = result.Errors.FirstOrDefault();
                registerErrorMessage.Visible = true;
            }
        }
    }
}