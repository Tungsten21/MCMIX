<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Front_End_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="mainStyle.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1 class="heading">Welcome to MCMIX</h1>
           <div class="regCon">
                <asp:TextBox ID="txtFirstName" placeholder="First Name" CssClass="txtFirstName" runat="server"></asp:TextBox>
                <asp:TextBox ID="txtLastName" placeholder="Last Name" CssClass="txtLastName" runat="server"></asp:TextBox>
                <asp:TextBox ID="txtEmail" placeholder="Email Address" CssClass="txtEmail" runat="server"></asp:TextBox>
                <asp:TextBox ID="txtInputUsername" placeholder="Username" CssClass="txtInputUsername" runat="server"></asp:TextBox>
                <asp:TextBox ID="txtInputPassword1" TextMode="Password" placeholder="Password" CssClass="txtInputPassword1" runat="server"></asp:TextBox>
                <asp:TextBox ID="txtInputPassword2" TextMode="Password" placeholder="Confirm Password" CssClass="txtInputPassword2" runat="server"></asp:TextBox>
                 <asp:ListBox ID="lbxGender" CssClass ="lbxGender" runat="server">
                     <asp:ListItem Selected="True">Male</asp:ListItem>
                     <asp:ListItem>Female</asp:ListItem>
                </asp:ListBox>
                <asp:TextBox ID="txtDOB" TextMode="Date" placeholder="D.O.B (dd/mm/yyyy)" CssClass="txtDOB" runat="server"></asp:TextBox>
                <div class="radioCon">
                <asp:RadioButtonList ID="radioList1" runat="server">
                    <asp:ListItem Text="Rapper" Value="1" />
                    <asp:ListItem Text="Producer" Value="2" />   
                </asp:RadioButtonList>
                </div>
               <asp:Button ID="btnSignUp" CssClass="btnSignUp" runat="server" Text="Sign-Up" OnClick="btnSignUp_Click" />
               <asp:Label ID="lblReg" CssClass="lblReg" runat="server" Text="Register to the site."></asp:Label>
            </div>
            <div class="loginCon">
                <asp:TextBox ID="txtUsername" CssClass="txtUsername" placeholder="Username" runat="server"></asp:TextBox>
                <asp:TextBox ID="txtPassword" TextMode="Password" placeholder="Password" CssClass="txtPassword" runat="server"></asp:TextBox>
                <asp:Button ID="btnSignIn" CssClass="btnSignIn" runat="server" Text="Sign-In" OnClick="btnSignIn_Click" />
                <asp:Label ID="lblStatus" CssClass="lblStatus" runat="server" Text=""></asp:Label>
               
            </div>
       </div>
    </form>
</body>
</html>
