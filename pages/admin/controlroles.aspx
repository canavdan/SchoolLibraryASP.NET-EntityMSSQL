<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="controlroles.aspx.cs" Inherits="LibraryProject.pages.admin.controlroles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntntHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntntBody" runat="server">
    <asp:DropDownList ID="DropDownMembers" runat="server"></asp:DropDownList><br /><br />
    <asp:DropDownList ID="DropDownRoles" runat="server"></asp:DropDownList><br /><br />

    <asp:LinkButton ID="LinkButtonGive" runat="server" OnClick="LinkButtonGive_Click">Give auth.</asp:LinkButton>
</asp:Content>
