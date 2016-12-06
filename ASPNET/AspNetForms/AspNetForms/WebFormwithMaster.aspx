<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebFormwithMaster.aspx.cs" Inherits="AspNetForms.WebFormwithMaster" %>

<%@ Register Src="~/UserControls/HelloFolkis.ascx" TagPrefix="FU" TagName="HelloFolkis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    hello world
      <FU:HelloFolkis runat="server" id="HelloFolkis" />
   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="placeHolderAppName" runat="server">
   App Name from Sub Page
  

</asp:Content>


