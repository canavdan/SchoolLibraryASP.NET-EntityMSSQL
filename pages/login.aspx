<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="LibraryProject.pages.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntntHead" runat="server">
    <title>Login</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntntBody" runat="server">   
    <asp:Login ID="Login2" runat="server"  OnLoggedIn="Login2_LoggedIn">
    </asp:Login>


   <!-- <table border="1">
        <tr>
            <td>Username:</td>
            <td>
                <asp:TextBox runat="server"  ID="txtUsername"/></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsername" ErrorMessage="Can not be empty"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Password</td>
            <td>
                <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxPassword" ErrorMessage="Can not be empty"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:LinkButton ID="LinkButtonLogin" runat="server" OnClick="LinkButtonLogin_Click">Login</asp:LinkButton>
            </td>
            <td></td>
        </tr>
    </table>-->
</asp:Content>
