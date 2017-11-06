<%@ Page Title="" Language="C#" MasterPageFile="~/SitePoor.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="Aukcje.Membership.SignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="styles/Styles.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-top: 70px;"></div>
    <div class="content-container">
        <asp:createuserwizard runat="server" ID="ctl00" BackColor="#FFFBD6" BorderColor="#FFDFAD" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="Medium" Height="345px" Width="394px" FinishDestinationPageUrl="~/Default.aspx">
            <ContinueButtonStyle BackColor="White" BorderColor="#CC9966" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" ForeColor="#990000" />
            <CreateUserButtonStyle BackColor="White" BorderColor="#CC9966" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" ForeColor="#990000" />
            <TitleTextStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <WizardSteps>
                <asp:CreateUserWizardStep runat="server">
                  
                </asp:CreateUserWizardStep>
                <asp:CompleteWizardStep runat="server">
                  
                </asp:CompleteWizardStep>
            </WizardSteps>
            <HeaderStyle BackColor="#FFCC66" BorderColor="#FFFBD6" BorderStyle="Solid" BorderWidth="2px" Font-Bold="True" Font-Size="0.9em" ForeColor="#333333" HorizontalAlign="Center" />
            <NavigationButtonStyle BackColor="White" BorderColor="#CC9966" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" ForeColor="#990000" />
            <SideBarButtonStyle ForeColor="White" />
            <SideBarStyle BackColor="#990000" Font-Size="0.9em" VerticalAlign="Top" />
        </asp:createuserwizard>
    </div>
</asp:Content>
