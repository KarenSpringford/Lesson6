using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//required for Identity and Owin Security
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;


/**
 * @author Karen Springford
 * @date June 12, 2016
 * @version 2.2 - Updated set active page method to include new links
 * */


namespace Lesson6
{
    public partial class Navbar : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //check to see if the user is logged in
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    //show the Contoso Context area
                    ContosoPlaceholder.Visible = true;
                    PublicPlaceholder.Visible = false;
                }
                else
                {
                    //only show login and register
                    ContosoPlaceholder.Visible = false;
                    PublicPlaceholder.Visible = true;
                }

                SetActivePage();
            }
            
        }

        /**
         * This method as a css class of active to list items to 
         * navigation links
         * @method SetActivePage
         * @return (void)
         * 
         * */

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
                case "Main Menu":
                    mainmenu.Attributes.Add("class", "active");
                    break;
                case "Students":
                    students.Attributes.Add("class", "active");
                    break;
                case "Courses":
                    courses.Attributes.Add("class", "active");
                    break;
                case "Departments":
                    departments.Attributes.Add("class", "active");
                    break;
                case "Logout":
                    logout.Attributes.Add("class", "active");
                    break;
                case "Contact":
                    contact.Attributes.Add("class", "active");
                    break;
            }
        }
    }
}