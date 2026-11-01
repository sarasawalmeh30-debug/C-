<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsersForm.aspx.cs" async="true" Inherits="studant_manegment_system.UsersForm" %>

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
            <asp:Label ID="Label1" runat="server" Text="Email"></asp:Label>
            <input id="Email" type="text" runat="server"/></p>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
            <input id="Password2" type="password" runat="server" /></p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Login" />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="delete" />
        <p>
            <asp:Label ID="Label3" runat="server"></asp:Label>
        </p>
        <p>
            <asp:Label ID="Label4" runat="server" Text="Edit User"></asp:Label>
        </p>
        <p>
            <asp:Label ID="Label5" runat="server" Text=" Email of user:"></asp:Label>
            <input id="Text2" type="text" runat="server"/></p>
        <asp:Label ID="Label6" runat="server" Text="New Name:"></asp:Label>
        <input id="EditName" type="text" runat="server"/><p>
            <asp:Label ID="Label7" runat="server" Text="New Age:"></asp:Label>
            <input id="EditAge" type="text" runat="server"/></p>
        <p>
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Update" />
        </p>
    </form>
</body>
</html>
