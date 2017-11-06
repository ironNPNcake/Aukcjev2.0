<%@ Page Title="" Language="C#" MasterPageFile="~/SitePoor.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Aukcje.Membership.Login" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="MyLogin" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-top: 70px;"></div>
    <div class="content-container">
        <asp:Login ID="LoginLayout" runat="server" DestinationPageUrl="~/Default.aspx" BackColor="#FFFBD6" BorderColor="#FFDFAD" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" CreateUserText="<%$Resources: Resource,DontHaveAccountText %>" Font-Names="Verdana" Font-Size="Medium" ForeColor="#333333" Height="242px" TextLayout="TextOnTop" Width="354px" CreateUserUrl="~/Membership/SignUp.aspx" UserNameLabelText="<%$Resources: Resource,UserName %>" PasswordLabelText="<%$Resources:Resource,Password %>" RememberMeText="<%$Resources: Resource,RememberMeText %>" TitleText="<%$Resources: Resource,SignInText %>" LoginButtonText="<%$Resources: Resource,Login %>" >
            <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
            <LoginButtonStyle BackColor="White" BorderColor="#CC9966" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000" />
            <TextBoxStyle Font-Size="0.8em" />
            <TitleTextStyle BackColor="#990000" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
        </asp:Login>
    </div>
</asp:Content>
