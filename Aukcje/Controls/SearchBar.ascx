<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchBar.ascx.cs" Inherits="Aukcje.Controls.SearchBar" %>
<div class="search-bar">
    <asp:TextBox runat="server" ID="textSearchBar" placeholder="I'm looking for..."></asp:TextBox>
    <asp:DropDownList runat="server" ID="DropDownCategories" SelectMethod="SelectCategories">
    </asp:DropDownList>
    <asp:ImageButton runat="server" ID="ImageButtonSearch" ImageUrl="~/Pictures/magnifying-glass.png" Height="27px" OnClick="ImageButtonSearch_OnClick" />
</div>