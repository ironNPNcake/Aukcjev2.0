<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SellerPage.aspx.cs" Inherits="Aukcje.SellerPage" %>

<%@ Register TagPrefix="uc" TagName="Comments" Src="~/Controls/CommentsSection.ascx" %>
<%@ Register TagPrefix="uc" TagName="AccountDetails" Src="~/Controls/AccountDetails.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="styles/SingleUser.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-container">


        <uc:AccountDetails runat="server"/>

        <uc:Comments runat="server" />

    </div>


</asp:Content>
