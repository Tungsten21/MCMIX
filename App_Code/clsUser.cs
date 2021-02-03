using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for clsUser
/// </summary>
public class clsUser
    {
    //variables
    private string connStr = "Server=tcp:mcmixserver.database.windows.net,1433;Initial Catalog=mcmix;Persist Security Info=False;User ID=mcmixross;Password=Gamerfl123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    private int userId;
    private string username;
    private string password;
    private string accountType;
    private string firstName;
    private string lastName;
    private string emailAddress;
    private DateTime dateOfBirth;
    private string gender;

        //constructor
    
    public clsUser(string usern)
    {
        username = usern;
    }

    public clsUser(int uId)
    {
        userId = uId;
        
        SqlConnection con = new SqlConnection(connStr);
        SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM dbo.Users WHERE userID ='" + uId + "'", con);
        DataTable dt = new DataTable();
        sda.Fill(dt);

        if(dt.Rows[0][0] != null)
        {
            firstName = dt.Rows[0][1].ToString();
            lastName = dt.Rows[0][2].ToString();
            username = dt.Rows[0][3].ToString();
            emailAddress = dt.Rows[0][4].ToString();
            password = dt.Rows[0][5].ToString();
            gender = dt.Rows[0][6].ToString();
            //if statement for account type
            if(dt.Rows[0][7].ToString() == "1")
            {
                accountType = "Rapper";
            }else if (dt.Rows[0][7].ToString() == "2")
            {
                accountType = "Producer";
            }
            else
            {
                accountType = "Error";
            }

           
        }
        else
        {
            Console.WriteLine("didnt work");
        }
    }

    public clsUser(string usern, string pass)
    {
        username = usern;
        password = pass;
    }

    //methods
    //get methods
    public int getUserId()
    {
    return userId;
        }

    public String getUsername()
    {
        return username;
    }

    public String getPassword()
{
    return password;
}

    public String getAccountType()
    {
        return accountType;
    }

    public string getFirstName()
    {
        return firstName;
    }

    public string getLastName()
    {
        return lastName;
    }

    public string getEmail()
    {
        return emailAddress;
    }

    public DateTime getDateOfBirth()
    {
        return dateOfBirth;
    }

    public string getGender()
    {
        return gender;
    }

    //set methods

    public void setUserId(int id)
    {
        userId = id;
    }

    public void setUsername(String name)
    {
        username = name;
    }

    public void setAccountType(String type)
    {
        accountType = type;
    }

    public void setFirstName(String fName)
    {
        firstName = fName;
    }

    public void setLastName(String lName)
    {
        lastName = lName;
    }

    public void setEmail(String email)
    {
        emailAddress = email;
    }

    public void setGender(String gndr)
    {
        gender = gndr;
    }

    //method to validate login
    public Boolean validateUser(string uN, string p)
{

    SqlConnection con = new SqlConnection(connStr);
    SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM dbo.Users WHERE userName ='" + uN + "' AND " +
        "password ='" + p + "'", con);
    DataTable dt = new DataTable();
    sda.Fill(dt);
    if (dt.Rows[0][0].ToString() == "1")
    {

        return true;
    } else
    {
        return false;
    }
    }

    public Boolean validateUsername(string Username)
    {
        SqlConnection con = new SqlConnection(connStr);
        SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM dbo.Users WHERE userName ='" + Username + "'", con);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        if (dt.Rows[0][0].ToString() == "1")
        {

            return false;
        }
        else
        {
            return true;
        }
    }
    }