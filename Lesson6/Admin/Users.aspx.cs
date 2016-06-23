using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//required for EF DB Access
using Lesson6.Models;
using System.Web.ModelBinding;

namespace Lesson6.Admin
{
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.GetUsers();
            }
        }

        protected void GetUsers()
        {
            //connect to the EF DB
            using (userConnection db = new userConnection())
            {
                //pull the user query from the db
                var Users = (from users in db.AspNetUsers
                             select users);

                //convert to a list
                UsersGridView.DataSource = Users.ToList();

                //bind it to the grid
                UsersGridView.DataBind();
            }
        }

        protected void UsersGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
            int selectedRow = e.RowIndex;

            //converting to a string with the student id to fill in the data
            string UsersID = UsersGridView.DataKeys[selectedRow].Values["Id"].ToString();

            using (userConnection db = new userConnection())
            {
                AspNetUser deletedUser = (from users in db.AspNetUsers
                                          where users.Id == UsersID
                                          select users).FirstOrDefault();

                db.AspNetUsers.Remove(deletedUser);
                db.SaveChanges();
            }

            //refresh the user grid
            this.GetUsers();
        }
    }
}