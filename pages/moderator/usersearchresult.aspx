<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="usersearchresult.aspx.cs" Inherits="LibraryProject.pages.moderator.usersearchresult" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntntHead" runat="server">
    <title>User Search Result</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntntBody" runat="server">

    <asp:GridView ID="gridViewUsers" runat="server" AutoGenerateColumns="false" OnRowCommand="gridViewUsers_RowCommand">
        <Columns>
            <asp:BoundField DataField="MemID" HeaderText="MemID" />
        </Columns>
        
        <Columns>
             <asp:BoundField DataField="Name" HeaderText="Name" />
        </Columns>

        <Columns>
             <asp:BoundField DataField="Surname" HeaderText="Surname" />
        </Columns>

        <Columns>
             <asp:BoundField DataField="Faculty" HeaderText="Faculty" />
        </Columns>
        <Columns>
            <asp:ButtonField ButtonType="Link" HeaderText="Choose" Text="Choose" ShowHeader="True" CommandName="Select"/>
        </Columns>
    </asp:GridView>

</asp:Content>
