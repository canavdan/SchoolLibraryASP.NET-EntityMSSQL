<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="LibraryProject.pages.moderator.modmain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntntHead" runat="server">
    <title>Moderator Index</title>
    <script type="text/javascript" src="../../Template/layout/scripts/jquery-1.12.4.js" ></script>
    <script type="text/javascript" src="../../Template/layout/scripts/jquery-ui.js"></script>
    
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" type="text/css"/>
   <script type="text/javascript">
       $(function () {
           $("#tabs").tabs();
       });
       function functionx(evt) {
           if (evt.charCode > 31 && (evt.charCode < 48 || evt.charCode > 57)) {
               alert("Allow Only Numbers");
               return false;
           }
       }
  </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntntBody" runat="server">
    <div id="tabs">
  <ul>
     <li><a href="#tabs-1" style="background-color:darkred">User Operations</a></li>
    <li><a href="#tabs-2" style="background-color:darkred">Add Material</a></li>
    <li><a href="#tabs-3" style="background-color:darkred">My Profile</a></li>
  </ul>
  <div id="tabs-1">

      Search member:<asp:TextBox ID="txtboxSearchMember" TextMode="Number" MaxLength="10" runat="server"></asp:TextBox>
    <asp:LinkButton ID="searchMember" runat="server" CausesValidation="false" OnClick="searchMember_Click">Search</asp:LinkButton>
  </div>
  <div id="tabs-2">
       <table>
        <tr>
            <td>Book ID:</td>
            <td><asp:TextBox ID="txtboxBookId" runat="server"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldBookID" runat="server" ControlToValidate="txtboxBookId" ErrorMessage="Can not be empty"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Book Name:</td>
            <td><asp:TextBox ID="txtboxBookName" runat="server"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldBookname" runat="server" ControlToValidate="txtboxBookName" ErrorMessage="Can not be empty"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Title:</td>
            <td><asp:TextBox ID="txtboxTitle" runat="server"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldTitle" runat="server" ControlToValidate="txtboxTitle" ErrorMessage="Can not be empty"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Description:</td>
            <td><asp:TextBox ID="txtboxDescription" runat="server"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieildDescription" runat="server" ControlToValidate="txtboxDescription" ErrorMessage="Can not be empty"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Price:</td>
            <td><asp:TextBox ID="txtboxPrice" onkeypress="return functionx(event)" runat="server"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldPrice" runat="server" ControlToValidate="txtboxPrice" ErrorMessage="Can not be empty"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Publisher:</td>
            <td>
                <asp:DropDownList ID="DropDownListPublisher" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldPublisher" runat="server" ControlToValidate="DropDownListPublisher" ErrorMessage="Can not be empty"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Page No:</td>
            <td><asp:TextBox ID="txtbxPageNo" onkeypress="return functionx(event)" runat="server"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredPageNo" runat="server" ControlToValidate="txtbxPageNo" ErrorMessage="Can not be empty"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Catalog:</td>
            <td><asp:DropDownList ID="dropCatalog" runat="server"></asp:DropDownList></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldCatalog" runat="server" ControlToValidate="dropCatalog" ErrorMessage="Can not be empty"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Language:</td>
            <td><asp:DropDownList ID="droLang" runat="server"></asp:DropDownList></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldLanguage" runat="server" ControlToValidate="droLang" ErrorMessage="Can not be empty"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Branch:</td>
            <td><asp:DropDownList ID="droBranch" runat="server"></asp:DropDownList></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldBranch" runat="server" ControlToValidate="droBranch" ErrorMessage="Can not be empty"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Categories:</td>
            <td><asp:DropDownList ID="droCategories" runat="server"></asp:DropDownList></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldCateg" runat="server" ControlToValidate="droCategories" ErrorMessage="Can not be empty"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2"> <asp:Button ID="ButtonAdd" runat="server" Text="ADD" OnClick="ButtonAdd_Click" /></td>
            <td> <asp:Button ID="ButtonReset" runat="server"  CausesValidation="false" Text="Reset" OnClick="ButtonReset_Click" /></td>
        </tr>
    </table>
  </div>
  <div id="tabs-3">
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



</asp:Content>
