﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/*
 * @Author: Emma Hilborn - 200282755
 */

namespace COMP2007_GameTracker_Emma
{
    public partial class Navbar : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SetActivePage();
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
            }
        }
    }
}