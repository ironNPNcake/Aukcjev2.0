<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FiltersCheckBoxes.ascx.cs" Inherits="Aukcje.Controls.FiltersCheckBoxes" %>


<div>
    <h4>Color: </h4>
    <asp:CheckBoxList runat="server" ID="checkBoxFilteringSet" DataSourceID="ObjectDataSource4ColorFilters" DataTextField="FilterResourceName" DataValueField="ID" >
    </asp:CheckBoxList>

    <asp:ObjectDataSource ID="ObjectDataSource4ColorFilters" runat="server" SelectMethod="ReturnFiltersList" TypeName="Aukcje.Filters"></asp:ObjectDataSource>


</div>
