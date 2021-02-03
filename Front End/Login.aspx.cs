using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Front_End_Login : System.Web.UI.Page
{
    private string connStr = "Server=tcp:mcmixserver.database.windows.net,1433;Initial Catalog=mcmix;Persist Security Info=False;User ID=mcmixross;Password=Gamerfl123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    protected void Page_Load(object sender, EventArgs e)
    {



    }

    protected void btnSignIn_Click(object sender, EventArgs e)
    {
        clsUser tempUser = new clsUser(txtUsername.Text.ToString(), txtPassword.Text.ToString());

        if (tempUser.validateUser(tempUser.getUsername(), tempUser.getPassword()) == true)
        {
            SqlConnection con = new SqlConnection(connStr);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT userID FROM dbo.Users WHERE userName ='" + txtUsername.Text.ToString() + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            int id = (int)dt.Rows[0][0];
            clsUser user = new clsUser(id);

            Session["USER"] = user;
            Response.Redirect("Profile.aspx");
        }
        else
        { 


            lblStatus.Text = "User details do not exist.";
        }
    }

    protected void btnSignUp_Click(object sender, EventArgs e)
    {
        if(IsFormComplete(txtFirstName, txtLastName, txtEmail, txtInputUsername, txtInputPassword1, txtInputPassword2) == true)
        {
            SqlConnection con = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Users (firstName, lastName, userName, emailAddress, password, gender, accountType, dateOfBirth) " +
                "VALUES (@firstName, @lastName, @userName, @emailAddress, @password, @gender, @accountType, @dateOfBirth)", con);
            cmd.Parameters.Add("@firstName", SqlDbType.VarChar);
            cmd.Parameters.Add("@lastName", SqlDbType.VarChar);
            cmd.Parameters.Add("@userName", SqlDbType.VarChar);
            cmd.Parameters.Add("@emailAddress", SqlDbType.VarChar);
            cmd.Parameters.Add("@password", SqlDbType.VarChar);
            cmd.Parameters.Add("@gender", SqlDbType.VarChar);
            cmd.Parameters.Add("@accountType", SqlDbType.Int);
            cmd.Parameters.Add("@dateOfBirth", SqlDbType.Date);

            cmd.Parameters["@firstName"].Value = txtFirstName.Text;
            cmd.Parameters["@lastName"].Value = txtLastName.Text;
            cmd.Parameters["@userName"].Value = txtInputUsername.Text;
            cmd.Parameters["@emailAddress"].Value = txtEmail.Text;
            cmd.Parameters["@password"].Value = txtInputPassword2.Text;
            cmd.Parameters["@gender"].Value = lbxGender.SelectedValue;
            cmd.Parameters["@accountType"].Value = radioList1.SelectedValue;
            cmd.Parameters["@dateOfBirth"].Value = DateTime.Parse(txtDOB.Text).ToShortDateString();

            con.Open();

            cmd.ExecuteNonQuery();

            con.Close();
            
        }
    }

    public Boolean IsFormComplete(TextBox first, TextBox last, TextBox email, TextBox user, TextBox pass1, TextBox pass2)
    {
        if(first.Text != "" && last.Text != "" && email.Text != "" && user.Text != "" && pass1.Text != "" && pass2.Text != "" && lbxGender.SelectedValue != "" && radioList1.SelectedValue != "")
        {
            //if passwords match
            if (pass1.Text != pass2.Text)
            {
                lblReg.Text = "Passwords don't match";
                return false;
                //if email is valid
            } else if (email.Text.Contains("@") && email.Text.Contains(".com"))
            {
                //if username is unique
                clsUser tempUser = new clsUser(txtInputUsername.Text);
                if(tempUser.validateUsername(tempUser.getUsername()) == true)
                {
                    
                    lblReg.Text = "All good username does not exist.";
                    return true;
                }
                else
                {
                    
                    lblReg.Text = "username already exists";
                    return false;
                }
               
            }
            else
            {
                lblReg.Text = "Enter valid email";
                return false;
            }
        }
        else
        {
         
            lblReg.Text = "Enter all fields...";
            return false;
        }
    }

}
  