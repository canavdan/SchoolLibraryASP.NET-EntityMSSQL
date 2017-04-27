<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="LibraryProject.pages.search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntntHead" runat="server">
    <title>Search</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntntBody" runat="server">
    <table border="1">
        <tr>
            <td>Query:</td>
            <td colspan="3">
                <asp:textbox Width="500" ID="txtboxQuery" runat="server"></asp:textbox>
            &nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Can not be empty" ControlToValidate="txtboxQuery"></asp:RequiredFieldValidator>
            </td>
            
        </tr>
        
        <tr>
             <td>Catalog</td>
             <td>
                 <asp:DropDownList ID="dropDownListCatalog" runat="server">
                 </asp:DropDownList>
             </td>
             <td>Branch</td>
             <td>
                 <asp:DropDownList ID="dropDownListBranch" runat="server">
                 </asp:DropDownList>
             </td>
        </tr>
        <tr>
             <td>Index</td>
             <td>
                 <asp:DropDownList ID="dropDownListIndex" runat="server">
                 </asp:DropDownList>
             </td>
             <td>Language</td>
             <td>
                 <asp:DropDownList ID="dropDownListLanguage" runat="server">
                 </asp:DropDownList>
             </td>
        </tr>
        <tr>
             <td colspan="2" style="position:center">
                 <asp:LinkButton id="linkButtonSearch" Text="Search" runat="server" OnClick="linkButtonSearch_Click" /></td>
             <td colspan="2" style="position:center">
                 <asp:LinkButton id="linkButtonReset" Text="Reset" runat="server" OnClick="linkButtonReset_Click" />
             </td>
        </tr>
    </table>
</asp:Content>
