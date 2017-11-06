<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AuctionsList.aspx.cs" Inherits="Aukcje.AuctionsList" %>

<%@ Register TagPrefix="uc" TagName="Categories" Src="~/Controls/LeftSideMenu.ascx" %>
<%@ Register Src="~/Controls/CategoryTree.ascx" TagPrefix="uc" TagName="CategoryTree" %>
<%@ Register Src="~/Controls/FiltersCheckBoxes.ascx" TagPrefix="uc" TagName="FiltersCheckBoxes" %>
<%@ Register Src="~/Controls/BrandFilter.ascx" TagPrefix="uc" TagName="BrandFilter" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="styles/Styles.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-container">

        <div class="SideBar">

            <uc:Categories runat="server" />

            <div runat="server" style="float: left" class="SideBar">
                <div style="display: inline-block;">
                    <h4>Price</h4>
                    <asp:TextBox runat="server" ID="textLowPrice" Width="40px"></asp:TextBox>- 
                    <asp:TextBox runat="server" ID="textHighPrice" Width="40px"></asp:TextBox>
                </div>
                <%-- Filtering checkboxes --%>
                <uc:FiltersCheckBoxes runat="server" id="FiltersCheckBoxes" />
                <uc:BrandFilter runat="server" id="BrandFilter" />

                <asp:Button runat="server" ID="FilteringButton" Text="Filter" />
            </div>
        </div>


        <div class="TreeViewer">
            <div class="TreeViewerContent" style="height: 40px !important;">
                <uc:CategoryTree runat="server" ID="CategoryTree" />
            </div>
        </div>


        <div class="displayingAuctions">
            <asp:ListView ID="ListViewAuctionsList" runat="server" SelectMethod="Select" ItemType="Aukcje.Auction">
                <LayoutTemplate>
                    <table runat="server" id="table1">
                        <tr>
                            <th style="width: 800px; text-align: center;" colspan="2">Auction Name</th>
                            <th style="width: 200px; text-align: center;">Actual Price</th>
                        </tr>
                        <tr runat="server" id="itemPlaceholder">
                        </tr>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>

                    <tr runat="server">

                        <td style="border-top: dashed gray 1px;">
                            <asp:ImageButton runat="server" ID="AuctionPicture" ImageUrl='<%# "PicturesHandler.ashx?ID=" + Eval("ID") %>' CssClass="AuctionImage" Height="50px" Width="50px" OnCommand="Auction_OnClick" CommandName="id" CommandArgument='<%#Eval("ID") %>' />
                        </td>
                        <td runat="server" style="border-top: dashed gray 1px;">
                            <%-- Data-bound content. --%>
                            <asp:LinkButton runat="server" ID="SingleAuctionRow" OnCommand="Auction_OnClick" CommandName="id" CommandArgument='<%#Eval("ID") %>'>
                                <asp:Label ID="NameLabel" runat="server" Text='<%#Eval("Title") %>' />
                            </asp:LinkButton></td>
                        <td style="border-top: dashed gray 1px;">
                            <asp:Label runat="server" Text='<%# String.Format("{0:C}",Eval("Price")) %>' />
                        </td>
                    </tr>

                </ItemTemplate>
                <EmptyDataTemplate>
                    <asp:Label runat="server" Text="We are Sorry there is no auctions that match to your Filters."></asp:Label>
                </EmptyDataTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
