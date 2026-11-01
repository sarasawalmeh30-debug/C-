<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="page1.aspx.cs" Inherits="first.page1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="Label1" runat="server" Text="Studant name"></asp:Label>
        <asp:CheckBoxList ID="CheckBoxList1" runat="server" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged">
            <asp:ListItem>sara</asp:ListItem>
            <asp:ListItem>ahmad</asp:ListItem>
            <asp:ListItem>emran</asp:ListItem>
            <asp:ListItem>saja</asp:ListItem>
            <asp:ListItem>dana</asp:ListItem>
            <asp:ListItem>nada</asp:ListItem>
            <asp:ListItem>jana</asp:ListItem>
            <asp:ListItem>lojuin</asp:ListItem>
            <asp:ListItem>samaher</asp:ListItem>
        </asp:CheckBoxList>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
    </form>
</body>
</html>
