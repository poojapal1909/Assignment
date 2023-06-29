<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="APIassignment.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        
           <div>
               <center>
               <h1>....LOGIN PAGE.....</h1>
                   <br />
                   <br />
                   <br />
            <asp:Label ID="Label1" runat="server" Text="Enter Email"></asp:Label>
&nbsp;
            <asp:TextBox ID="TextBox1" runat="server" Height="39px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Enter Password"></asp:Label>
&nbsp;
            <asp:TextBox ID="TextBox2" runat="server" Height="38px"></asp:TextBox>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Login" BackColor="#CC66FF" Height="47px" Width="118px" />
            <br />
            <br />
&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label3" runat="server"></asp:Label>
                   </center>
        </div>
    </form>
</body>
</html>
