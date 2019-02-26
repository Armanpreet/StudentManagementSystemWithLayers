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
    public partial class Teachers : System.Web.UI.Page
    {
        DataLayer.Teacher model = new DataLayer.Teacher();
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
            model.TeacherName = txtTeacherName.Text;
            model.Qualification = txtQualification.Text;
            TeacherService.Insert(model);
            lblError.Text = "Teacher Successfully Inserted.";
            Clear();
            DataGvProperties();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            model.Id = Convert.ToInt32(txtId.Text);
            model.TeacherName = txtTeacherName.Text;
            model.Qualification = txtQualification.Text;
            TeacherService.Update(model);
         
            lblError.Text = "Teacher Successfully Updated.";
            Clear();
            DataGvProperties();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txtId.Text);

            TeacherService.Delete(Id);
            lblError.Text = "Course Deleted.";
            DataGvProperties();
            Clear();
        }
        void Clear()
        {
            txtTeacherName.Text = txtQualification.Text = "";
            BtnDelete.Enabled = false;
        }
        void DataGvProperties()
        {
            GridViewTeacher.DataSource = TeacherService.GetAll();
            GridViewTeacher.DataBind();
        }

        protected void GridViewTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GridViewTeacher.SelectedRow.RowIndex != -1)
            {


                GridViewRow row = GridViewTeacher.SelectedRow;

                txtId.Text = row.Cells[1].Text;
                txtTeacherName.Text = row.Cells[2].Text;
                txtQualification.Text = row.Cells[3].Text;
                //txtTime.Text = row.Cells[4].Text;


                BtnDelete.Enabled = true;

            }
        }
    }
}