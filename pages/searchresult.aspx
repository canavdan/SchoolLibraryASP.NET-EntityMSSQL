<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="searchresult.aspx.cs" Inherits="LibraryProject.pages.searchresult" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntntHead" runat="server">
    <title>Search Result</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntntBody" runat="server">  
        <asp:GridView ID="gridsearchResult" runat="server" AutoGenerateColumns="False" OnRowCommand="gridsearchResult_RowCommand" >    
      <Columns>
          <asp:BoundField DataField="SSN" HeaderText="ID" />
      </Columns>
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" />
      </Columns>
        <Columns>
            <asp:BoundField DataField="Title" HeaderText="Title" />
      </Columns>
        <Columns>
            <asp:BoundField DataField="TypeB" HeaderText="Type" />
      </Columns>
        <Columns>
            <asp:BoundField DataField="Category" HeaderText="Category" />
      </Columns>
        <Columns>
            <asp:BoundField DataField="Authors" HeaderText="Authors" />
      </Columns>  
         <Columns>
            <asp:CheckBoxField DataField="Avaible" HeaderText="Avaible" />
      </Columns>           
          <Columns>
            <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Take Material" ShowHeader="True" Text="Take Material" />
        </Columns>
    </asp:GridView>

  
</asp:Content>
