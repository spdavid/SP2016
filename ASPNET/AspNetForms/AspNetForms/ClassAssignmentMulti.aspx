<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClassAssignmentMulti.aspx.cs" Inherits="AspNetForms.ClassAssignmentMulti" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        #Container > Div {
            float: left;
            padding:5px;
        }
        #Container select {
        min-width:200px;
        
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="Container">
            <div>
                <asp:ListBox ID="lbLeft" SelectionMode="Multiple" runat="server"></asp:ListBox>
            </div>
            <div>
                <div>
                    <asp:Button ID="btnMoveToRight" runat="server" Text="-->" OnClick="btnMoveToRight_Click" />
                </div>
                <div>
                    <asp:Button ID="btnMoveToLeft" runat="server" Text="<--" OnClick="btnMoveToLeft_Click" />
                </div>
            </div>
            <div>
                <asp:ListBox ID="lbRighjt" SelectionMode="Multiple" runat="server"></asp:ListBox>
            </div>
        </div>
    </form>
</body>
</html>
