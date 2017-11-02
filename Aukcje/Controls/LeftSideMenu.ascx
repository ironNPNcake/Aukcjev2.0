<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LeftSideMenu.ascx.cs" Inherits="Aukcje.Controls.LeftSideMenu" %>



<div class="Categories-Section SideBar">
    <%--   <ul>
        <li>
            <asp:LinkButton runat="server" PostBackUrl="~/AuctionsList.aspx?category=0">
                <asp:Literal runat="server" ID="literal1" Text="<%$Resources:Resource, Electronics %>"></asp:Literal>
            </asp:LinkButton>
        </li>
        <li>
            <asp:LinkButton runat="server" PostBackUrl="~/AuctionsList.aspx?category=1"><asp:Literal runat="server" Text='<%$Resources: Resource, Clothes %>'></asp:Literal></asp:LinkButton></li>
        <li>
            <asp:LinkButton runat="server" PostBackUrl="~/AuctionsList.aspx?category=2"><asp:Literal runat="server" Text="<%$Resources: Resource, HomeAndGarden %>" ></asp:Literal></asp:LinkButton></li>
    </ul>--%>
    <asp:ListView runat="server" ItemType="Aukcje.CategoriesTable" ID="ListViewSideCategoriesMenu" SelectMethod="OnSelectingCategories">
        <LayoutTemplate>
            <ul>
                <li id="ItemPlaceHolder" runat="server"></li>
            </ul>
        </LayoutTemplate>
        <ItemTemplate>
            <li>
                <asp:LinkButton runat="server" PostBackUrl='<%#String.Format($"~/AuctionsList.aspx?category={Convert.ToInt32(Eval("ID"))}") %>'>
                    <asp:Literal runat="server" ID="literal1" Text='<%#Eval("CategoryResourceName") %>'></asp:Literal>
                </asp:LinkButton>
            </li>
        </ItemTemplate>
    </asp:ListView>
</div>
