<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="useroperations.aspx.cs" Inherits="LibraryProject.pages.moderator.useroperations" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntntHead" runat="server">
    <title>User Operations</title>
     <script type="text/javascript" src="../../Template/layout/scripts/jquery-1.12.4.js" ></script>
    <script type="text/javascript" src="../../Template/layout/scripts/jquery-ui.js"></script>
    
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" type="text/css"/>
   <script type="text/javascript">
       $(function () {
           $("#tabs").tabs();
       });
  </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntntBody" runat="server">

     <div id="tabs">
  <ul>
     <li><a href="#tabs-1" style="background-color:darkred" >Member Profile</a></li>
    <li><a href="#tabs-2" style="background-color:darkred">Change Password</a></li>
    <li><a href="#tabs-3" style="background-color:darkred">Take Debt</a></li>
  </ul>
  <div id="tabs-1">
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
  <div id="tabs-2">
      <table>
          <tr>
              <td>New Password:</td>
              <td>
                  <asp:TextBox ID="txtboxPassword" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
              </td>
              <td></td>
          </tr>
          <tr>
              <td>Write Again:</td>
              <td>
                  <asp:TextBox ID="txtboxPassword2" runat="server" TextMode="Password" Width="198px"></asp:TextBox>
              </td>
              <td>
                  <asp:CompareValidator ID="CompareValidatorPass" runat="server" ControlToCompare="txtboxPassword" ControlToValidate="txtboxPassword2" ErrorMessage="Password can not match"></asp:CompareValidator>
              </td>
          </tr>
          <tr>
              <td colspan="2">
                  <asp:LinkButton ID="LinkButtonChange" runat="server">Change</asp:LinkButton></td>
              <td><asp:LinkButton ID="LinkButtonReset" CausesValidation="false" runat="server">Reset</asp:LinkButton></td>
          </tr>
      </table>
      
     
  </div>
  <div id="tabs-3">
      
  </div>
         User has <asp:Label ID="labelMoney" runat="server" Text="Label"></asp:Label> debt.<br /><br />
         <asp:LinkButton ID="LinkButtonTake" runat="server" OnClick="LinkButtonTake_Click">Take Debt</asp:LinkButton>
     </div>
</asp:Content>
