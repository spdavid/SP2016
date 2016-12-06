<%@ Page Title="" Language="C#" MasterPageFile="~/My.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="EmptyWebForms.ContactUs" %>

<%@ Register Src="~/UserControls/ContactUsControl.ascx" TagPrefix="uc1" TagName="ContactUsControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageTitle" runat="server">
   Contact us

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
  Bacon ipsum dolor amet ham tenderloin bacon meatball ribeye jowl. 
       <uc1:ContactUsControl Title="David" Address="Göteborg" Phone="0722695586" runat="server" id="ContactUsControl" />
</asp:Content>
