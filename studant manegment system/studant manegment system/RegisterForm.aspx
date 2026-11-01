<%@ Page Language="C#" AutoEventWireup="true" Async="true" CodeBehind="RegisterForm.aspx.cs" Inherits="studant_manegment_system.RegisterForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <p>
            <asp:Label ID="Label1" runat="server" Text="Name "></asp:Label>
            <input id="Text1" type="text" runat="server" /></p>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Age"></asp:Label>
            <input id="Text2" type="text" runat="server" /></p>
        <p>
            <asp:Label ID="Label3" runat="server" Text="Email"></asp:Label>
            <input id="Text3" type="text" runat="server"/></p>
        <p>
            <asp:Label ID="Label4" runat="server" Text="Password"></asp:Label>
            <input id="Password1" type="password" runat="server" /></p>
        <p>
            <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                <asp:ListItem>student</asp:ListItem>
                <asp:ListItem>teacher</asp:ListItem>
            </asp:DropDownList>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        </p>
    </form>
</body>
</html>
