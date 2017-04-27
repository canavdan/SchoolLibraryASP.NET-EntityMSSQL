<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="librarycolletion.aspx.cs" Inherits="LibraryProject.pages.librarycolletion" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntntHead" runat="server">
    <title>Library Colletion</title>
  
    <link rel="stylesheet" href="Template/layout/scripts/jquery.min.js" type="text/javascript"/>
    <link rel="stylesheet" href="Template/layout/scripts/jquery.ui.min.js"  type="text/javascript"/>
   <script src="https://code.jquery.com/jquery-1.12.4.js"  type="text/javascript"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#tabs").tabs();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntntBody" runat="server">

    <div id="tabs" style="border:dotted">
        <ul style="display:inline">
            <li><a href="#tabs-1">By material types</a></li>
            <li><a href="#tabs-2">By languages</a></li>
            <li><a href="#tabs-3">By Categories</a></li>
            <li><a href="#tabs-4">By Branches</a></li>
        </ul>
        <div id="tabs-1">
            <asp:Chart ID="ChartMaterial" runat="server" DataSourceID="SqlDataSource1" OnLoad="ChartMaterial_Load" Width="881px" >
                <Series>
                    <asp:Series Name="Series1" ChartType="Pie" XValueMember="typeName" YValueMembers="c"></asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:librarydbConnectionString %>" SelectCommand="SELECT t.typeName, COUNT(*) AS c FROM material AS m INNER JOIN type AS t ON t.typeID = m.typeID GROUP BY t.typeName"></asp:SqlDataSource>
        </div>
        <div id="tabs-2">
            <asp:Chart ID="ChartLanguage" runat="server" DataSourceID="SqlDataSourceByLang" Width="818px">
                <Series>
                    <asp:Series Name="Series1" ChartType="Pie" XValueMember="langName" YValueMembers="c"></asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
            <asp:SqlDataSource ID="SqlDataSourceByLang" runat="server" ConnectionString="<%$ ConnectionStrings:librarydbConnectionString %>" SelectCommand="select l.langName,COUNT(*) AS c
from material m
INNER JOIN language l ON l.langID=m.langID
group by l.langName"></asp:SqlDataSource>
        </div>
        <div id="tabs-3">
            <asp:Chart ID="ChartCategory" runat="server" DataSourceID="SqlDataSourceCategory" Width="767px">
                <Series>
                    <asp:Series Name="Series1" ChartType="Pie" XValueMember="catName" YValueMembers="c"></asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
            <asp:SqlDataSource ID="SqlDataSourceCategory" runat="server" ConnectionString="<%$ ConnectionStrings:librarydbConnectionString %>" SelectCommand="select c.catName,COUNT(*) AS c
from material m
INNER JOIN category c ON c.catID=m.catID
group by c.catName"></asp:SqlDataSource>
        </div>
        <div id="tabs-4">
            <asp:Chart ID="ChartBranch" runat="server" DataSourceID="SqlDataSourceByBranch" Width="874px">
                <Series>
                    <asp:Series Name="Series1" ChartType="Pie" XValueMember="branchName" YValueMembers="c"></asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
            <asp:SqlDataSource ID="SqlDataSourceByBranch" runat="server" ConnectionString="<%$ ConnectionStrings:librarydbConnectionString %>" SelectCommand="select b.branchName,COUNT(*) AS c
from material m
INNER JOIN branch b ON b.branchID=m.branchID
group by b.branchName"></asp:SqlDataSource>
        </div>
    </div>

</asp:Content>
