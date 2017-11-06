<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BrandFilter.ascx.cs" Inherits="Aukcje.Controls.BrandFilter" %>

<div>
    <h4>Brands: </h4>
    <asp:CheckBoxList runat="server" ID="checkBoxBrandsSet" SelectMethod="SelectBrands">
    </asp:CheckBoxList>


</div>