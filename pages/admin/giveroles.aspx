<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="giveroles.aspx.cs" Inherits="LibraryProject.pages.admin.giveroles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntntHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntntBody" runat="server">
    <asp:TextBox ID="TextBoxRole" runat="server" Width="229px"></asp:TextBox><br /><br />
    <asp:LinkButton ID="LinkButtonRole" runat="server" OnClick="LinkButtonRole_Click">Add Role</asp:LinkButton>
</asp:Content>
