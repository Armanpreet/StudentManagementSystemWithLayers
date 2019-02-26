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
    public partial class StudentMaster : System.Web.UI.Page
    {
        Student model = new Student();
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
                    dropdownlistData();
                    dropdownlistDataforTeacher();
                }


            }
            else
            {

            }
            DataGvProperties();
            //dropdownlistData();
            //dropdownlistDataforTeacher();
            //DataGvProperties();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            model.StdName = txtStdName.Text;
            model.FatherName = txtFather.Text;
            model.Address = txtAddress.Text;
            model.Mobile = txtMobile.Text;
            if(radioBtnMale.Checked)
            {
                model.Gender = radioBtnMale.Text;
            }
            if(radioButtonFemale.Checked)
            {
                model.Gender = radioButtonFemale.Text;
            }
            model.CourseId = Convert.ToInt32(ddCourse.SelectedItem.Value);
            model.TeacherId = Convert.ToInt32(ddTeacher.SelectedItem.Value);
            model.Email = txtEmail.Text;
            
            StudentService.Insert(model);
            lblError.Text = "Student Successfully Added.";
            DataGvProperties();
            Clear();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            model.Id = Convert.ToInt32(txtId.Text);

            model.StdName = txtStdName.Text;
            model.FatherName = txtFather.Text;
            model.CourseId = Convert.ToInt32(ddCourse.SelectedItem.Value);
            model.TeacherId = Convert.ToInt32(ddTeacher.SelectedItem.Value);
            model.Address = txtAddress.Text;
            model.Mobile = txtMobile.Text;
            model.Email = txtEmail.Text;
            StudentService.Update(model);

            lblError.Text = "Student Successfully Updated.";
            Clear();
            DataGvProperties();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txtId.Text);

            StudentService.Delete(Id);
            lblError.Text = "Course Deleted.";
            DataGvProperties();
            Clear();
        }
        void dropdownlistData()
        {
            //Teacher teacher = new Teacher();
            StudentMgtSystemEntities db = new StudentMgtSystemEntities();
            ddCourse.DataSource = db.Courses.ToList();

            ddCourse.DataTextField = "CourseName";
            ddCourse.DataValueField = "Id";
            ddCourse.DataBind();
        }
        void dropdownlistDataforTeacher()
        {
            //Teacher teacher = new Teacher();
            StudentMgtSystemEntities db = new StudentMgtSystemEntities();
            ddTeacher.DataSource = db.Teachers.ToList();

            ddTeacher.DataTextField = "TeacherName";
            ddTeacher.DataValueField = "Id";
            ddTeacher.DataBind();
        }
        void DataGvProperties()
        {
            StudentMgtSystemEntities db = new StudentMgtSystemEntities();
            var test1 = (from s in db.Students
                         join c in db.Courses
                             on s.CourseId equals c.Id
                         join t in db.Teachers
                         on s.TeacherId equals t.Id

                         select new
                         {
                             Id = s.Id,
                             Name = s.StdName,
                             Fname=s.FatherName,
                             Add = s.Address,
                             mob = s.Mobile,
                             Gender = s.Gender,
                             CourseName = c.CourseName,
                             TeacherName = t.TeacherName,
                             EmailId = s.Email,

                         }).ToList();
            //GridView1.DataSource = StudentServices.GetAll();
            GridView1.DataSource = test1;
            GridView1.DataBind();
        }
        void Clear()
        {
            txtStdName.Text = txtAddress.Text = txtFather.Text = txtEmail.Text = txtMobile.Text = " ";
            BtnDelete.Enabled = false;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GridView1.SelectedRow.RowIndex != -1)
            {

                

                GridViewRow row = GridView1.SelectedRow;
                
                txtId.Text = row.Cells[1].Text;
                txtStdName.Text = row.Cells[2].Text;
               txtFather.Text= row.Cells[3].Text;
                txtAddress.Text = row.Cells[4].Text;
                txtMobile.Text= row.Cells[5].Text;
                txtEmail.Text= row.Cells[9].Text;
                //ddCourse.Items.Clear();
                //ddCourse.Items.Add(GridView1.SelectedRow.Cells[5].Text);
                //ddTeacher.Items.Clear();
                //ddTeacher.Items.Add(GridView1.SelectedRow.Cells[6].Text);
                // ddCourse.Text = row.Cells[5].Text;
                // ddTeacher.Text = row.Cells[6].Text;

                BtnDelete.Enabled = true;

            }
        }
    }
}