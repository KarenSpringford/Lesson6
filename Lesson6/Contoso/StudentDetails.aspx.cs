using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//using statements required for EF DB access
using Lesson6.Models;
using System.Web.ModelBinding;
using System.Linq.Dynamic;

namespace Lesson6
{
    public partial class StudentDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if((!IsPostBack)&&(Request.QueryString.Count > 0))
            {
                this.GetStudent();
            }
        }

        protected void GetStudent()
        {
            //populate the form with existing data from the database
            int StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);

            // connect to the EF DB
            using (ContosoConnection db = new ContosoConnection())
            {
                // populate a student object instance with the StudentID from the URL Parameter
                Student updatedStudent = (from student in db.Students
                                          where student.StudentID == StudentID
                                          select student).FirstOrDefault();

                //map the student properties to the form
                if (updatedStudent != null)
                {
                    LastNameTextBox.Text = updatedStudent.LastName;
                    FirstNameTextBox.Text = updatedStudent.FirstMidName;
                    EnrollmentDateTextBox.Text = updatedStudent.EnrollmentDate.ToString("yyyy-MM-dd");
                }
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            //redirect back to Students page
            Response.Redirect("~/Students.aspx");
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {

            //use EF to connect to the server
            using (ContosoConnection db = new ContosoConnection())
            {
                //use the Student model to create a new student object and 
                //save a new record
                Student newStudent = new Student();

                int StudentID = 0;

                if(Request.QueryString.Count > 0) //our URL has a student ID in it
                {
                    //get the id from the url
                    StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);

                    //get the current student from the EF DB
                    newStudent = (from student in db.Students
                                  where student.StudentID == StudentID
                                  select student).FirstOrDefault();
                }
                //add form data to the new student record
                newStudent.LastName = LastNameTextBox.Text;
                newStudent.FirstMidName = FirstNameTextBox.Text;
                newStudent.EnrollmentDate = Convert.ToDateTime(EnrollmentDateTextBox.Text);

                //use LINQ to ADO.NET to add / insert new student
                if(StudentID == 0)
                {
                    db.Students.Add(newStudent);
                }

                //save our changes
                db.SaveChanges();

                //redirect back to the updated Students page
                Response.Redirect("~/Contoso/Students.aspx");
            }
        }
    }
}