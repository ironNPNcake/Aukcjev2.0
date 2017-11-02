<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchBar.ascx.cs" Inherits="Aukcje.Controls.SearchBar" %>
<div class="search-bar">
    <asp:TextBox runat="server" ID="textSearchBar" placeholder="Szukam..."></asp:TextBox>
    <asp:DropDownList runat="server" ID="DropDownCategories">
        <asp:ListItem Text="<%$Resources:Resource,Electronics %>"></asp:ListItem>
        <asp:ListItem Text="<%$Resources:Resource,Clothes %>"></asp:ListItem>
        <asp:ListItem Text="<%$Resources:Resource,HomeAndGarden %>"></asp:ListItem>
        <asp:ListItem Selected="True" Text="<%$Resources:Resource,AllCategories %>"></asp:ListItem>
    </asp:DropDownList>
    <asp:ImageButton runat="server" ID="ImageButtonSearch" ImageUrl="~/Pictures/magnifying-glass.png" Height="27px" OnClick="ImageButtonSearch_OnClick" />
</div>