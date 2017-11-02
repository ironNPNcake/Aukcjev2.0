<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserAccountPage.aspx.cs" Inherits="Aukcje.UserAccountPage" %>


<%@ Register TagPrefix="uc" TagName="AccountDetails" Src="~/Controls/AccountDetails.ascx" %>
<%@ Register TagPrefix="uc" TagName="YourAuctions" Src="~/Controls/YourAuctions.ascx" %>
<%@ Register TagPrefix="uc" TagName="Comments" Src="~/Controls/CommentsSection.ascx" %>
<%@ Register Src="~/Controls/FavouritesList.ascx" TagPrefix="uc" TagName="FavouritesList" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="styles/SingleUser.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-container">
        
        <uc:AccountDetails runat="server"/>

        <uc:YourAuctions runat="server" />

        <uc:Comments runat="server" />

        <uc:FavouritesList runat="server" id="FavouritesList" />
    </div>

</asp:Content>
