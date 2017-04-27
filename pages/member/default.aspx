<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="LibraryProject.pages.member.membermain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntntHead" runat="server">
    <title>Member Index</title>
    
    <script type="text/javascript" src="../../Template/layout/scripts/jquery-1.12.4.js" ></script>
    <script type="text/javascript" src="../../Template/layout/scripts/jquery-ui.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#tabs").tabs();
        });
    </script>
    <style type="text/css">
        .auto-style2 {
            width: 96px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntntBody" runat="server">
    <div id="tabs">
  <ul style="display:inline">
    <li><a href="#tabs-1">My Profile</a></li>
    <li><a href="#tabs-2">Take Book</a></li>
    <li><a href="#tabs-3">Return Book</a></li>
     <li><a href="#tabs-4">Book History</a></li>
  </ul>
  <div id="tabs-1">
      <div id="myprofile">
          <table border="1">
              <tr>
                  <td class="auto-style2">Number:</td>
                   <td>
                       <asp:Label ID="LabelNumber" runat="server"></asp:Label>
                  </td>
              </tr>
               <tr>
                  <td class="auto-style2">Name:</td>
                   <td>
                       <asp:Label ID="LabelName" runat="server"></asp:Label>
                   </td>
              </tr>
               <tr>
                  <td class="auto-style2">Surname:</td>
                   <td>
                       <asp:Label ID="LabelSurname" runat="server"></asp:Label>
                   </td>
              </tr>
               <tr>
                  <td class="auto-style2">Mail:</td>
                   <td>
                       <asp:Label ID="LabelMail" runat="server"></asp:Label>
                   </td>
              </tr>
               <tr>
                  <td class="auto-style2">Departmant</td>
                   <td>
                       <asp:Label ID="LabelDepart" runat="server"></asp:Label>
                   </td>
              </tr>
              <tr>
                  <td class="auto-style2">Faculty</td>
                   <td>
                       <asp:Label ID="LabelFaculty" runat="server"></asp:Label>
                  </td>
              </tr>
               <tr>
                  <td class="auto-style2">Mail:</td>
                   <td>
                       <asp:Label ID="LabelMa" runat="server"></asp:Label>
                   </td>
              </tr>
               <tr>
                  <td class="auto-style2">Number:</td>
                   <td>
                       <asp:Label ID="LabelNo" runat="server"></asp:Label>
                   </td>
              </tr>
               <tr>
                  <td class="auto-style2">Adress:</td>
                   <td>
                       <asp:Label ID="LabelAddr" runat="server"></asp:Label>
                   </td>
              </tr>

          </table>



      </div>
  </div>
  <div id="tabs-2">
      <div id="search">
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
                 <asp:LinkButton id="linkButtonReset" Text="Reset" runat="server" />
             </td>
        </tr>
    </table>


      </div>
  </div>
  <div id="tabs-3">
      
      <asp:GridView ID="GridViewLoans" runat="server" AutoGenerateColumns="false" OnRowCommand="GridViewLoans_RowCommand">
          <Columns>
              <asp:BoundField DataField="LoanID" HeaderText="LoanID" />
          </Columns>
          <Columns>
              <asp:BoundField DataField="Name" HeaderText="Name" />
          </Columns>
          <Columns>
              <asp:BoundField DataField="outdate" HeaderText="Due" />
          </Columns>
          <Columns>
              <asp:BoundField DataField="duedate" HeaderText="Out" />
             
          </Columns>
          <Columns>
              <asp:BoundField DataField="extends" HeaderText="Extends Time" />
             
          </Columns>
          <Columns>

           <asp:ButtonField ButtonType="Button" CommandName="Extend" HeaderText="Extend Material" ShowHeader="True" Text="Extend" />
          
          </Columns>
          <Columns>
           <asp:ButtonField ButtonType="Button" CommandName="Return" HeaderText="Return Material" ShowHeader="True" Text="Return" />

          </Columns>
      </asp:GridView>
      
  </div>
         <div id="tabs-4">
      
             <asp:GridView ID="GridViewLoanHistory" runat="server">

             </asp:GridView>
      
  </div>
</div>

</asp:Content>
