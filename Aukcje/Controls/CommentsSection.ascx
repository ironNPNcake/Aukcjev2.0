<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CommentsSection.ascx.cs" Inherits="Aukcje.Controls.CommentsSection" %>
<div class="CommentsContainer">
    
    <asp:ListView runat="server" ItemType="Aukcje.Models.CommentWithAuction" ID="ListViewComments" SelectMethod="SelectComment" >
        <LayoutTemplate>
            <div class="CommentsContainer">
                <p>Closed Transactions</p>
                <table border="1" runat="server" style="width: 100%; text-align: center">
                    <tr style="background-color: #c5c5c5" runat="server">
                        <th style="width: 100px">Auction ID</th>
                        <th style="width: 400px">Auction Name</th>
                        <th style="width: 100px">Price</th>
                        <th style="width: 200px">Buyer</th>
                        <th style="width: 100px">Rate</th>
                        <th>Comment</th>
                    </tr>
                    <tr id="ItemPlaceHolder" runat="server" />
                </table>
            </div>
        </LayoutTemplate>
        <EmptyDataTemplate>
            <tr>
                <p>This User has no completed auctions</p>
            </tr>
        </EmptyDataTemplate>
        <ItemTemplate>


            <tr runat="server">
                <td>
                    <asp:Label runat="server" Text='<%#Eval("aukcja.ID") %>'></asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" Text='<%#Eval("aukcja.Title") %>'></asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" Text='<%#Eval("aukcja.Price") %>'></asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" Text='<%#Eval("ConsumerName") %>'></asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" Text='<%#Eval("Comment.rating") %>'></asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" Text='<%#Eval("Comment.Comment_Content") %>'></asp:Label>
                </td>
            </tr>


            <asp:Label runat="server" ID="labelka"></asp:Label>
        </ItemTemplate>
    </asp:ListView>

            
            
</div> 