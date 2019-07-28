<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchInGrid.aspx.cs" Inherits="WebApplication1.SearchInGrid" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text="SEARCH"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server" Width="159px"></asp:TextBox> &nbsp;&nbsp;&nbsp; <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="OnChange"></asp:DropDownList>   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   <asp:Button ID="Button1" runat="server" Text="Search" OnClick="Button1_Click" Width="124px" />

        <br />
        <br />

        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        <br />
    </div>
    </form>
</body>
</html>
