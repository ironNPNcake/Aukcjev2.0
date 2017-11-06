<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LeftSideMenu.ascx.cs" Inherits="Aukcje.Controls.LeftSideMenu" %>



<div class="Categories-Section SideBar">
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
