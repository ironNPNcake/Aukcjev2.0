<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FavouritesList.ascx.cs" Inherits="Aukcje.Controls.FavouritesList" %>

<asp:ListView runat="server" ItemType="Aukcje.Auction" id="LstVwFavouritesAuctions" SelectMethod="LstVwFavouritesAuctions_GetData">
    <LayoutTemplate>
        <asp:Label runat="server" Text="Items you Added to favourites"  Font-Size="X-Large" Font-Italic="False" Font-Bold="True" />
        <table>
            <tr>
                <th style="width:600px; text-align:center;" colspan="2">Auction Name</th>
                <th style="width: 200px; text-align: center;">Price</th>
                <th style="width: 300px;">status</th>
            </tr>
            <tr runat="server" id="itemPlaceholder"> </tr>
        </table>
    </LayoutTemplate>
    <ItemTemplate>
        <tr runat="server">
            <td style="width: 200px">
                <asp:Image runat="server" ID="AuctionPicture" ImageUrl='<%# "~/PicturesHandler.ashx?ID="  + Eval("ID") %>' CssClass="AuctionImage" Height="50px" Width="50px" />
            </td>
            <td runat="server" style="width:300px; text-align:center;">
                <%-- Data-bound content. --%>
                <asp:LinkButton runat="server" ID="SingleAuctionRow" OnCommand="Auction_OnClick" CommandName="id" CommandArgument='<%#Eval("ID") %>'>
                    <asp:Label ID="NameLabel" runat="server" Text='<%#Eval("Title") %>' />
                </asp:LinkButton>
            </td>
            <td style="width:200px; text-align:center;">
                <asp:Label runat="server" Text ='<%#Eval("Price") %>' />
            </td>
            <td style="width:300px; text-align:center;">
                <asp:Label runat="server" Text='<%#Eval("Status") %>' />
            </td>
        </tr>
    </ItemTemplate>
</asp:ListView>
