<%@ Page Title="" Language="C#" MasterPageFile="~/My.Master" AutoEventWireup="true" CodeBehind="InLineCode.aspx.cs" Inherits="EmptyWebForms.InLineCode" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
Inline code
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">
    <%= DateTime.Now.ToString() %>
    <%= SomethingForThePage %>
    <div>
    <select>
        <%foreach (var str in listofstrings)
            { %>
            <option value="<%= str %>"><%= str %></option>
        <% } %>
    </select>
    </div>
</asp:Content>
