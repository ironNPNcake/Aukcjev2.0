<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoryTree.ascx.cs" Inherits="Aukcje.Controls.CategoryTree" %>

<asp:Menu ID="CategoryMenu" runat="server" Orientation="Horizontal" Height="40px" BackColor="#D0D0D0" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="Medium" ForeColor="#666666" StaticSubMenuIndent="10px" OnMenuItemClick="Menu1_MenuItemClick" Font-Bold="True" ><%--DataSourceID="SiteMapDataSource" >--%>
    <DynamicHoverStyle BackColor="#e0e0e0" ForeColor="White" />
    <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
    <DynamicMenuStyle BackColor="#E3EAEB" />
    <DynamicSelectedStyle BackColor="#606060" ForeColor="White" />
    <Items>
    </Items>
    <StaticHoverStyle BackColor="#666666" ForeColor="White" />
    <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
    <StaticSelectedStyle BackColor="#1C5E55" />
</asp:Menu>
<asp:SiteMapDataSource ID="SiteMapDataSource" runat="server" SiteMapProvider="" />

    <asp:ObjectDataSource ID="ObjectDataSource4ColorFilters" runat="server" SelectMethod="ReturnFiltersList" TypeName="Aukcje.Filters"></asp:ObjectDataSource>