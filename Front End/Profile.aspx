<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="Front_End_Landing_Page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="profile.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="userContainer">
            <asp:TextBox ID="txtUsername" CssClass="txtUsername" runat="server" ReadOnly="True"></asp:TextBox>
            <asp:TextBox ID="txtAccountType" CssClass="txtAccountType" runat="server" ReadOnly="True"></asp:TextBox>
            <asp:TextBox ID="txtFirstName" CssClass="txtFirstName" runat="server" ReadOnly="True"></asp:TextBox>
            <asp:TextBox ID="txtLastName" CssClass="txtLastName" runat="server" ReadOnly="True"></asp:TextBox>
            <asp:TextBox ID="txtGender" CssClass="txtGender" runat="server" ReadOnly="True"></asp:TextBox>
            <asp:TextBox ID="txtEmail" CssClass="txtEmail" runat="server" ReadOnly="True"></asp:TextBox>
            <asp:Button ID="btnLogOut" CssClass="btnLogOut" runat="server" Text="Log Out" OnClick="btnLogOut_Click" />
        </div>
    </form>
</body>
</html>
