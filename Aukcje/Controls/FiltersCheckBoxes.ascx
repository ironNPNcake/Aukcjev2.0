<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FiltersCheckBoxes.ascx.cs" Inherits="Aukcje.Controls.FiltersCheckBoxes" %>


<div>
    <h4>Color: </h4>
    <asp:CheckBoxList runat="server" ID="checkBoxFilteringSet">
        <asp:ListItem>Black</asp:ListItem>
        <asp:ListItem>Rose</asp:ListItem>
        <asp:ListItem>White</asp:ListItem>
    </asp:CheckBoxList>
</div>
