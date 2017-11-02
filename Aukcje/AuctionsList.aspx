<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AuctionsList.aspx.cs" Inherits="Aukcje.AuctionsList" %>

<%@ Register TagPrefix="uc" TagName="Categories" Src="~/Controls/LeftSideMenu.ascx" %>
<%@ Register Src="~/Controls/CategoryTree.ascx" TagPrefix="uc" TagName="CategoryTree" %>
<%@ Register Src="~/Controls/FiltersCheckBoxes.ascx" TagPrefix="uc" TagName="FiltersCheckBoxes" %>



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
                <uc:FiltersCheckBoxes runat="server" id="FiltersCheckBoxes" />

                <asp:Button runat="server" ID="FilteringButton" Text="Filter" />
            </div>
        </div>


        <div class="TreeViewer">
            <div class="TreeViewerContent" style="height: 40px !important;">
                <%--<asp:TreeView runat="server"  Font-Size="Large" Font-Bold="True">
                    <Nodes>
                        <asp:TreeNode Text="Categories" Value="Categories">
                            <asp:TreeNode Text="Electronics" Value="Electronics" NavigateUrl="AuctionsList.aspx?category=0"></asp:TreeNode>
                            <asp:TreeNode Text="Clothes" Value="Clothes" NavigateUrl="AuctionsList.aspx?category=1"></asp:TreeNode>
                            <asp:TreeNode Text="Home &amp; Garden" Value="Home &amp; Garden" NavigateUrl="AuctionsList.aspx?category=2"></asp:TreeNode>
                        </asp:TreeNode>
                    </Nodes>
                </asp:TreeView>
                <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />--%>

                <uc:CategoryTree runat="server" ID="CategoryTree" />
            </div>
        </div>


        <div class="displayingAuctions">
            <asp:ListView ID="ListView1" runat="server" SelectMethod="Select" ItemType="Aukcje.Auction">
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
            </asp:ListView>
        </div>
    </div>
</asp:Content>
