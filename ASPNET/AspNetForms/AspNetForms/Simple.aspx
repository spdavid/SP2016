<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Simple.aspx.cs" Inherits="AspNetForms.Simple" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Hey Web Forms
            <asp:Label ID="lbSomeText" CssClass="MyCssClass" runat="server" Text=""></asp:Label>
            <div id="SomeDiv" runat="server"></div>
            <asp:TextBox ID="txtSomeText" runat="server"></asp:TextBox>
            <asp:Button ID="btnButton" runat="server" Text="DoSomething" OnClick="btnButton_Click" />
            <asp:DropDownList ID="ddlColors" runat="server">
            
            </asp:DropDownList>
            <asp:Label ID="lbResult" runat="server" Text="Label"></asp:Label>  
            
        </div>
    </form>
</body>
</html>
