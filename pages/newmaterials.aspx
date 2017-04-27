<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="newmaterials.aspx.cs" Inherits="LibraryProject.pages.newmaterials" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntntHead" runat="server">
    <title>New Materials</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntntBody" runat="server">
    <asp:GridView ID="gridLatestMaterial" runat="server"></asp:GridView>
</asp:Content>
