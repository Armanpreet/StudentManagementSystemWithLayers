using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLayer;
using BussinessLayer;

namespace StudentManagementSystemWithLayers
{
    public partial class Course : System.Web.UI.Page
    {
        Cours model = new Cours();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //dropdownlistData();
                // dropdownlistDataforTeacher();

                if (Session["id"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    DataGvProperties();
                    //dropdownlistData();
                    //dropdownlistDataforTeacher();
                }


            }
            else
            {

            }
           
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            model.CourseName = txtCourseName.Text;
            model.CourseFees = Convert.ToDecimal(txtFees.Text);
            model.CourseDuration = txtTime.Text;
            CourseService.Insert(model);
            Clear();
            DataGvProperties();
            lblError.Text = "Record Inserted.";
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            model.Id = Convert.ToInt32(txtCourseId.Text);
            
            model.CourseName = txtCourseName.Text;
            model.CourseFees = Convert.ToDecimal(txtFees.Text);
            model.CourseDuration = txtTime.Text;
            CourseService.Update(model);
            
            lblError.Text = "Course Successfully Updated.";
            Clear();
            DataGvProperties();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txtCourseId.Text);

            CourseService.Delete(Id);
            lblError.Text = "Course Deleted.";
            DataGvProperties();
            Clear();
        }
        void Clear()
        {
            txtCourseName.Text = txtFees.Text = txtTime.Text = "";
            BtnDelete.Enabled = false;
        }
        void DataGvProperties()
        {
            GridViewCourse.DataSource = CourseService.GetAll();
            GridViewCourse.DataBind();
        }

        protected void GridViewCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GridViewCourse.SelectedRow.RowIndex != -1)
            {


                GridViewRow row = GridViewCourse.SelectedRow;

                txtCourseId.Text = row.Cells[1].Text;
                txtCourseName.Text = row.Cells[2].Text;
                txtFees.Text = row.Cells[3].Text;
                txtTime.Text = row.Cells[4].Text;


                BtnDelete.Enabled = true;

            }
        }
    }
}