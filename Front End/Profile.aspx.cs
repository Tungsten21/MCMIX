using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Front_End_Landing_Page : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER"] != null) {
            clsUser user = (clsUser)Session["USER"];
            txtUsername.Text = user.getUsername();
            txtAccountType.Text = user.getAccountType();
            txtFirstName.Text = user.getFirstName();
            txtLastName.Text = user.getLastName();
            txtGender.Text = user.getGender();
            txtEmail.Text = user.getEmail();
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
       



    }

    protected void btnLogOut_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("Login.aspx");
    }
}