<%@ Page Title="" Language="C#" MasterPageFile="~/My.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EmptyWebForms.Default" %>

<%@ Register Src="~/UserControls/ContactUsControl.ascx" TagPrefix="uc1" TagName="ContactUsControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageTitle" runat="server">
   Start Page

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
  Bacon ipsum dolor amet ham tenderloin <span style="position:relative">asdfasf<div style="position:absolute; top:10px; left:10px;">bacon</div></span> meatball ribeye jowl. Drumstick cow sirloin, picanha pork loin tri-tip turkey andouille shank ham hock hamburger cupim pork belly prosciutto. Ham sausage rump, frankfurter pork loin burgdoggen picanha chicken drumstick beef kielbasa boudin. Shoulder turducken pork loin boudin.
  Turducken hamburger tri-tip landjaeger shank cow spare ribs swine short ribs andouille t-bone chicken jerky fatback. Tail jerky chuck, ribeye spare ribs flank shoulder tri-tip short ribs ground round capicola. Kevin meatball pancetta ribeye sausage bacon fatback. Shank turducken spare ribs ground round.
    <uc1:ContactUsControl Title="David" Address="Göteborg" Phone="0722695586" runat="server" id="ContactUsControl" />
</asp:Content>
