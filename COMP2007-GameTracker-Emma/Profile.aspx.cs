using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using COMP2007_GameTracker_Emma.Models;
using System.Web.ModelBinding;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace COMP2007_GameTracker_Emma
{
    public partial class Profile : System.Web.UI.Page
    {

        string UserID = HttpContext.Current.User.Identity.GetUserId();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.GetUser();
        }

        protected void GetUser()
        {
            using (UserConnection db = new UserConnection())
            {
                AspNetUser userToEdit = (from user in db.AspNetUsers
                                          where user.Id == UserID
                                          select user).FirstOrDefault();
                    userNameTextBox.Text = userToEdit.UserName;
                    emailTextBox.Text = userToEdit.Email;
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            using (UserConnection db = new UserConnection())
            {
                AspNetUser updatedUser = new AspNetUser();

                UserID = HttpContext.Current.User.Identity.GetUserId();

                updatedUser = (from users in db.AspNetUsers
                               where users.Id == UserID
                               select users).FirstOrDefault();

                updatedUser.UserName = userNameTextBox.Text;
                updatedUser.Email = emailTextBox.Text;

                db.SaveChanges();

                Response.Redirect("~/Default.aspx");
            }

        }
    }
}