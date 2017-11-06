<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AccountDetails.ascx.cs" Inherits="Aukcje.Controls.AccountDetails" %>

<asp:ListView ID="ListViewAccountDetails" runat="server" SelectMethod="SelectUser" ItemType="Aukcje.UserWithRating" OnDataBound="ListViewAccountDetails_DataBound">
    <ItemTemplate>
        <div class="PersonalInfoContainer">
            <div class="UserBigPicture">
                <asp:Image runat="server" ID="UserPicture" />
            </div>
            <div class="PersonalInfoDetails">
                <asp:Label runat="server" Text='<%$Resources:Resource,UserName %>'></asp:Label>
                &nbsp;
                <asp:Label runat="server" Text='<%# Eval("currentUser.UserName") %>'></asp:Label> 
                <br />
                <br />
                <asp:Label runat="server" Text='<%$Resources:Resource,UserRate %>'></asp:Label>
                &nbsp;
                <asp:Label runat="server" Text='<%# Eval("rate") %>'></asp:Label>
            </div>
        </div>
    </ItemTemplate>
</asp:ListView>
