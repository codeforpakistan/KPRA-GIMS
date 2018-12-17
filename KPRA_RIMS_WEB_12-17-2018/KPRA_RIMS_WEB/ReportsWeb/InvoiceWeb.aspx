<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="InvoiceWeb.aspx.cs" Inherits="KPRA_RIMS_WEB.ReportsWeb.InvoiceWeb" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
  <%--   <link href="../css/style.css" rel="stylesheet" />
    <link href="../jquery-ui-1.11.4/jquery-ui.css" rel="stylesheet" />
    <script src="../jquery-ui-1.11.4/jquery-ui.min.js"></script>--%>
      <script type="text/javascript">
          $(function () {
              $("#<%=txtFromDate.ClientID%>").datepicker();
            $("#<%=txtToDate.ClientID%>").datepicker();
        });
        $(document).ready(function () {

            $("#<%=txtBusinessName2.ClientID%>").hide();
            $("#<%=txtFromDate.ClientID%>").prop("disabled", true);
            $("#<%=txtToDate.ClientID%>").prop("disabled", true);
            $("#<%=txtBusinessCode.ClientID%>").prop("disabled", true);
            $("#<%=txtBusinessName.ClientID%>").prop("disabled", true);
            $("#<%=txtBusinessName2.ClientID%>").prop("disabled", true);
            $("#<%=chkDates.ClientID%>").change(function () {
                $("#<%=txtFromDate.ClientID%>").prop("disabled", !$(this).is(':checked'));
                $("#<%=txtToDate.ClientID%>").prop("disabled", !$(this).is(':checked'));
                $("#<%=txtBusinessName.ClientID%>").prop("disabled", !$(this).is(':checked'));
            }
            );
            $("#<%=chkBusinessCode.ClientID%>").change(function () {
                $("#<%=txtBusinessCode.ClientID%>").prop("disabled", !$(this).is(':checked'));
             }
            );
            $("#<%=chkBusinessName.ClientID%>").change(function () {
                $("#<%=txtBusinessName.ClientID%>").prop("disabled", !$(this).is(':checked'));
             }
            );

            //    $("#<%=btnBusinessName.ClientID%>").hide();

          <%--  $("#<%=txtFromDate.ClientID%>").hide();
            $("#<%=txtToDate.ClientID%>").hide();--%>
            //$("#spanDate").hide();
            SearchTextBusinessCode();
            SearchTextBusinessName();
            //  SearchTextBusinessName2();

        });
        function SearchTextBusinessName() {
            $("#<%=txtBusinessName.ClientID%>").autocomplete({
                 source: function (request, response) {
                     $.ajax({
                         type: "POST",
                         contentType: "application/json; charset=utf-8",
                         url: "InvoiceWeb.aspx/GetBusinessName",
                         data: "{'businessName':'" + $("#<%=txtBusinessName.ClientID%>").val() + "'}",
                        dataType: "json",
                        success: function (data) {
                            if ($("#<%=btnBusinessName.ClientID%>").is(":hidden"))
                                $("#<%=btnBusinessName.ClientID%>").show();
                            response(data.d);
                        },
                        error: function (result) {
                            alert("No Match");
                        }
                    });
                }
            });
        }
        function SearchTextBusinessName2() {
            $("#<%=txtBusinessName2.ClientID%>").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            url: "InvoiceWeb.aspx/GetBusinessName",
                            data: "{'businessName':'" + $("#<%=txtBusinessName2.ClientID%>").val() + "'}",
                        dataType: "json",
                        success: function (data) {

                            response(data.d);
                        },
                        error: function (result) {
                            alert("No Match");
                        }
                    });
                }
            });
        }
        function SearchTextBusinessCode() {
            $("#<%=txtBusinessCode.ClientID%>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "InvoiceWeb.aspx/GetBusinessCode",
                        data: "{'businessCode':'" + $("#<%=txtBusinessCode.ClientID%>").val() + "'}",
                        dataType: "json",
                        success: function (data) {

                            response(data.d);
                        },
                        error: function (result) {
                            alert("No Match");
                        }
                    });
                }
            });
        }
    </script>
    <style type="text/css">
        .row-highlight {
            background-color: Yellow;
        }
        .row-select {
            background-color: red;
        }
    </style>
        <script type="text/javascript">
            $(function () {
                var td = $("#tbl").find('td');
                td.find(':checkbox').each(function () {
                    if ($(this).is(':checked')) {
                    <%--  $("#<%=txtFromDate.ClientID%>").show();
                    $("#<%=txtToDate.ClientID%>").show();
                    $("#<%=btnSearchByDates.ClientID%>").show();
                    $("#<%=btnDates.ClientID%>").show();
                    $("#spanDate").show();--%>
                }
                });
                <%--  var tr = $('#<%=gvBusiness.ClientID %>').find('tr');

            tr.hover(
                 function () {  // mouseover
                     $(this).addClass('row-highlight');
                 },
                 function () {  // mouseout
                     $(this).removeClass('row-highlight');
                 }
            );
            tr.click(function () { //click
                $(this).addClass('row-select');
                $("#<%=txtFromDate.ClientID%>").show();
                $("#<%=txtToDate.ClientID%>").show();
            }

            );--%>

            });
    </script>
    <script type="text/javascript">
        $(function () {
            $("#<%=btnBusinessName.ClientID%>").click(function (e) {
                $("#<%=btnBusinessName.ClientID%>").hide();

            });
        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
    <div class="well form-inline">
        <%--<asp:TextBox ID="txtBusinessID" CssClass="form-control"  runat="server"></asp:TextBox>--%>
        <br /><br />
        <table id="tbl">
         <tr>
               
              <td><span style="font-weight: bold; font-size: 9pt;">Business Name:</span>
                  <br /><asp:TextBox ID="txtBusinessName" CssClass="input-sm" runat="server" Width="150px" /></td>

              <td>
                  <span style="font-weight: bold; font-size: 9pt;">Business Code:</span><br />
                  <asp:TextBox ID="txtBusinessCode" CssClass="input-sm" runat="server" Width="150px" /></td>
                <td>
                    <span id="spanDate" style= "font-weight: bold; font-size: 9pt;">From Date:</span><br />
                <asp:TextBox ID="txtFromDate" CssClass="input-sm" runat="server" Width="90px" /></td>
             <td>
                 <span id="spanDate2" style= "font-weight: bold; font-size: 9pt;">To Date:</span><br />
                <asp:TextBox ID="txtToDate" CssClass="input-sm" runat="server" Width="90px" /></td>
              <td><asp:TextBox ID="txtBusinessName2" CssClass="input-sm" runat="server" Width="150px" /></td>
         </tr>
         
    </table>
      <label class="checkbox" style="font-weight: bold; font-size: 9pt;">
               <asp:CheckBox ID="chkBusinessName" runat="server" />Search By Business Name
               <asp:CheckBox ID="chkBusinessCode" runat="server" />Search By Business Code
               <asp:CheckBox ID="chkDates" runat="server" />Search Between Dates
       </label><br />
        
              <asp:Button ID="btnBusinessName" CssClass="btn btn-info" runat="server" Text="GENERATE REPORT" OnClick="btnBusinessName_Click" />
          <br />
          <div id="alertDanger" runat="server" class="alert alert-danger alert-dismissible">
        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
        <asp:Label ID="lblDanger" runat="server" Text=""></asp:Label>
    </div>
        </div>
   <%--  <table>
            
         <tr>
             <td><asp:DropDownList ID="ddlBusinessName" CssClass="dropdown" AutoPostBack="true" OnSelectedIndexChanged="ddlBusinessName_SelectedIndexChanged" runat="server"></asp:DropDownList></td>
             <td> <asp:Label ID="lblParameter" runat="server" Text=""></asp:Label></td>
         </tr>
      
            <tr>
             <td>
            <asp:GridView ID="gvBusiness" OnSelectedIndexChanged="gvBusiness_SelectedIndexChanged"  OnRowDataBound="gvBusiness_RowDataBound" OnRowCommand="gvBusiness_RowCommand" ShowFooter="true" DataKeyNames="businessID" AutoGenerateColumns="false" runat="server">
            <SelectedRowStyle BackColor="SaddleBrown" />
            <Columns>
                <asp:BoundField DataField="businessID" HeaderText="Business ID" />
                <asp:BoundField DataField="businessCode" HeaderText="Business Code" />
                <asp:BoundField DataField="businessName" HeaderText="Business Name" />
                <asp:BoundField DataField="address" HeaderText="Address" />  
                <asp:BoundField DataField="contact" HeaderText="Contact" />
                <asp:BoundField DataField="email" HeaderText="email" />
                <asp:TemplateField HeaderText="Clear">
                   <ItemTemplate>
                        <asp:Button ID="btnGenReport" CausesValidation="false"  CssClass="btn btn-default" runat="server" Text="Generate" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="generate" />
                   </ItemTemplate>
                    
                </asp:TemplateField>

            </Columns>
        </asp:GridView> 
             </td>
         </tr>
     </table>  --%>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <rsweb:ReportViewer ID="ReportViewerInvoice" Width="100%" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
        
    </rsweb:ReportViewer>
        </div>
</asp:Content>
