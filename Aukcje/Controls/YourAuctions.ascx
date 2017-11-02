<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="YourAuctions.ascx.cs" Inherits="Aukcje.Controls.YourAuctions" %>

<asp:ListView runat="server" ID="ListViewAuctions" SelectMethod="Select" ItemType="Aukcje.Auction" UpdateMethod="Update" OnItemUpdating="ListViewAuctions_OnItemUpdating" >
    <LayoutTemplate>
        <asp:Label runat="server" Font-Size="X-Large" Text="Your Auctions" Font-Bold="True"></asp:Label>
        <table style="width: 100%; text-align: center" runat="server">
            <tr>
                <th style="text-align: center; width: 50px;" >ID</th>
                <th style="text-align: center" colspan="2">Auction name:</th>
                <th style="text-align: center; width: 300px" >Description</th>
                <th style="width: 150px; text-align: center">Price: </th>
                <th style="width: 100px; text-align: center">status:</th>
                <th style="width: 100px; text-align: center"></th>
            </tr>
            <tr runat="server" id="ItemPlaceHolder"></tr>
        </table>
    </LayoutTemplate>
    <ItemTemplate>
        <tr runat="server">
            <td>
                <asp:Label runat="server" Text='<%#Eval("ID") %>'></asp:Label>
            </td>
            <td style="width: 200px">
                <asp:Image runat="server" ID="AuctionPicture" ImageUrl='<%# "~/PicturesHandler.ashx?ID="  + Eval("ID") %>' CssClass="AuctionImage" Height="50px" Width="50px" />
            </td>
            <td runat="server">
                <%-- Data-bound content. --%>
                <asp:LinkButton runat="server" ID="SingleAuctionRow" OnCommand="Auction_OnClick" CommandName="id" CommandArgument='<%#Eval("ID") %>'>
                    <asp:Label ID="NameLabel" runat="server" Text='<%#Eval("Title") %>' />
                </asp:LinkButton>
            </td>
            <td>
                <asp:TextBox TextMode="MultiLine" ReadOnly="True" runat="server" Text='<%# Eval("Description") %>'   ></asp:TextBox>
            </td>
            <td>
                <asp:Label runat="server" Text='<%# String.Format("{0:C}",Eval("Price")) %>' />
            </td>
            <td>
                <asp:Label runat="server" Text='<%# Eval("status") %>'></asp:Label>
            </td>
            <td>
                <asp:LinkButton ID="EditButton" runat="Server" Text="Edit" CommandName="Edit"></asp:LinkButton>
            </td>
        </tr>
    </ItemTemplate>
    <EditItemTemplate>
        <tr style="height: 50px; background-color: #a5a5a5; ">
            <td>
                <asp:Label runat="server" ID="labelID" Text='<%#Bind("ID") %>'></asp:Label>
            </td>
            <td style="width: 200px">
                <asp:FileUpload runat="server" ID="FileUploadUpdate"  />
            </td>
            <td>
                <asp:TextBox ID="textTitle" Width="200px" runat="server" text='<%# Bind("Title") %>'></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="textDescription" runat="server" TextMode="MultiLine" Text='<%#Bind("Description") %>'></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBoxPrice" runat="server" text='<%#Bind("Price") %>'></asp:TextBox>
            </td>
            <td colspan="2">
                <asp:LinkButton runat="server" text="Save" CommandName="Update" ></asp:LinkButton>&nbsp;
                <asp:LinkButton runat="server" ID="CancelButton" Text="Cancel" CommandName="Cancel"></asp:LinkButton>&nbsp;
                <asp:LinkButton runat="server" Text="Delete" ID="btnDelete" OnCommand="BtnDelete_OnCommandOnClick" CommandArgument='<%#Bind("ID") %>'></asp:LinkButton>
            </td>
        </tr>


    </EditItemTemplate>
</asp:ListView>
