<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoryTree.ascx.cs" Inherits="Aukcje.Controls.CategoryTree" %>

<asp:Menu ID="Menu1" runat="server" Orientation="Horizontal" Height="40px" BackColor="#D0D0D0" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="Medium" ForeColor="#666666" StaticSubMenuIndent="10px" OnMenuItemClick="Menu1_MenuItemClick" Font-Bold="True" DataSourceID="SiteMapDataSource1" >
    <DynamicHoverStyle BackColor="#e0e0e0" ForeColor="White" />
    <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
    <DynamicMenuStyle BackColor="#E3EAEB" />
    <DynamicSelectedStyle BackColor="#606060" ForeColor="White" />
    <Items>
        <asp:MenuItem Text="<%$Resources: Resource, Categories %>" Value="Categories" >
            <asp:MenuItem Text="<%$Resources: Resource, Electronics %>" Value="0" NavigateUrl="~/AuctionsList.aspx?category=0"></asp:MenuItem>
            <asp:MenuItem Text="<%$Resources: Resource, Clothes %>" Value="1" NavigateUrl="~/AuctionsList.aspx?category=1"></asp:MenuItem>
            <asp:MenuItem Text="<%$Resources: Resource, HomeAndGarden %>" Value="2" NavigateUrl="~/AuctionsList.aspx?category=2"></asp:MenuItem>
        </asp:MenuItem>
      <%--  <asp:MenuItem Text="New Itemwww" Value="New Itemwww"></asp:MenuItem>--%>
    </Items>
    <StaticHoverStyle BackColor="#666666" ForeColor="White" />
    <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
    <StaticSelectedStyle BackColor="#1C5E55" />
</asp:Menu>
<asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />

