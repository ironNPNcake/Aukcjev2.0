<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Aukcje.Default" %>

<%@ Register TagPrefix="uc" TagName="CategoriesMenu" Src="~/Controls/LeftSideMenu.ascx" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
    <link href="styles/Styles.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="main" ContentPlaceHolderID="MainContent" runat="server">
    <div class="top-container">
        <div class="top-container-content">
            <div class="categories-bar">
                <asp:LinkButton runat="server" ID="ButtonCategories" PostBackUrl="CategoriesPage.aspx"><br/><asp:Literal runat="server" Text="<%$Resources: Resource,Categories %>"></asp:Literal></asp:LinkButton>
            </div>
            <div class="Hot-offerts">
                <ul>
                    <li>Elektryka prad nie tyka</li>
                    <li>10 year promotions</li>
                    <li>promotionadasd</li>
                </ul>
            </div>
        </div>
    </div>
    <div class="content-container">

        <uc:CategoriesMenu runat="server" />
        <div class="Gallery">
            <asp:ImageButton runat="server" ImageUrl="~/Pictures/promo.jpg" />
        </div>
        <div style="float: none"></div>
        <div class="Promotions">
            <div class="Promotions-Bar">
                <p>Promotions</p>
            </div>
            <div class="Promotions-Container">
            </div>
        </div>

    </div>
</asp:Content>

