using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLayer;

namespace StudentManagementSystemWithLayers
{
    public partial class Login : System.Web.UI.Page
    {
        User user = new User();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            StudentMgtSystemEntities db = new StudentMgtSystemEntities();
            var query = from u in db.Users
                        where u.UserName == txtName.Text
                        && u.Password == txtPassword.Text
                        select u;
            if (query.Any())
            {
                Session["id"] = user.Id;
                Response.Redirect("StudentMaster.aspx");
                lblError.Text = "Login Success";
            }
            else
            {
                lblError.Text = "Login Failed";
            }
        }
    }
}