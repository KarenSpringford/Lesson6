using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//required for EF DB Access
using Lesson6.Models;
using System.Web.ModelBinding;

//required for Identity and Owin Security
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace Lesson6.Admin
{
    public partial class UserDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Request.QueryString.Count > 0)
                {
                    PasswordPlaceHolder.Visible = false;
                    this.GetUser();
                }
                else
                {
                    PasswordPlaceHolder.Visible = true;
                }
            }
        }

        protected void GetUser()
        {
            string UserID = Request.QueryString["Id"].ToString();

            using(userConnection db = new userConnection())
            {
                AspNetUser updatedUser = (from user in db.AspNetUsers
                                         where user.Id == UserID
                                         select user).FirstOrDefault();

                if(updatedUser != null)
                {
                    UserNameTextBox.Text = updatedUser.UserName;
                    PhoneNumberTextBox.Text = updatedUser.PhoneNumber;
                    EmailTextBox.Text = updatedUser.Email;
                }
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            //redirect to the users page
            Response.Redirect("~/Admin/Users.aspx");
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            string UserID = "";

            //if I'm updating a new user
            if(Request.QueryString.Count > 0)
            {
                using (userConnection db = new userConnection())
                {
                    AspNetUser newUser = new AspNetUser();

                    UserID = Request.QueryString["Id"].ToString();

                    newUser = (from user in db.AspNetUsers
                               where user.Id == UserID
                               select user).FirstOrDefault();

                    newUser.UserName = UserNameTextBox.Text;
                    newUser.PhoneNumber = PhoneNumberTextBox.Text;
                    newUser.Email = EmailTextBox.Text;

                    db.SaveChanges();

                    //redirect to the users list
                    Response.Redirect("~/Admin/Users.aspx");
                }
            }
            //if creating a new user than do the following
            if(UserID == "")
            {
                //create a new userStore and userManager objects
                var userStore = new UserStore<IdentityUser>();
                var userManager = new UserManager<IdentityUser>(userStore);

                //create a new user object
                var user = new IdentityUser()
                {
                    UserName = UserNameTextBox.Text,
                    PhoneNumber = PhoneNumberTextBox.Text,
                    Email = EmailTextBox.Text,
                    // ID is auto generated so it is unnecessary
                };

                //create new user in the DB and store result in the the following result object
                IdentityResult result = userManager.Create(user, PasswordTextBox.Text);

                if (result.Succeeded)
                {
                    Response.Redirect("~/Admin?Users.aspx");
                }
                else
                {
                    StatusLabel.Text = result.Errors.FirstOrDefault();
                    AlertFlash.Visible = true;
                }

            }
        }
    }
}