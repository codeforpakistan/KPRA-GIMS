<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AllBusinessDateReportWeb.aspx.cs" Inherits="KPRA_RIMS_WEB.ReportsWeb.AllBusinessDateReportWeb" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/style.css" rel="stylesheet" />
    <link href="../jquery-ui-1.11.4/jquery-ui.css" rel="stylesheet" />
    <script src="../jquery-ui-1.11.4/jquery-ui.min.js"></script>
   <script type="text/javascript">
       $(function () {
           $("#<%=txtFromDate.ClientID%>").datepicker();
           $("#<%=txtToDate.ClientID%>").datepicker();
       });
   </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
     <div class="well form-inline">
        <table>
            <tr>
                
                <td>FROM DATE:<br /><asp:TextBox ID="txtFromDate" CssClass="input-sm" runat="server"></asp:TextBox></td>
                <td>TO DATE:<br /><asp:TextBox ID="txtToDate" CssClass="input-sm" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnGetReportBetweenDates" CssClass="btn btn-info" runat="server" Text="GENERATE REPORT" OnClick="btnGetReportBetweenDates_Click" /></td>
            </tr>
        </table><br />
        <div id="alertDanger" runat="server" class="alert alert-danger alert-dismissible">
        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
        <asp:Label ID="lblDanger" runat="server" Text=""></asp:Label>
    </div>
    </div>
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <rsweb:ReportViewer ID="ReportViewerDates" Width="100%" runat="server"></rsweb:ReportViewer>
   </div>
</asp:Content>
