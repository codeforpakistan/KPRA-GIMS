<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="NetworkUser.aspx.cs" Inherits="KPRA_RIMS_WEB.ConnectivityWeb.NetworkUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<link href="../css/style.css" rel="stylesheet" />--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script type="text/javascript">
         function GetConnectivityStatusImage(statusParam) {
             var b = [];
             if (statusParam < 0) {
                 b = statusParam = "<center><img src='../Images/fullofflinestatus.png' width='25px' height='25px'/></center>";
             }
             else if (statusParam >= 60 && statusParam < 1440) {
                 b = (statusParam / 60);
                 b = statusParam = "<center><img src='../Images/hourstatus.png' width='25px' height='25px'/></center>";
             }
             else if (statusParam >= 1440) {
                 b = statusParam / 1440;
                 b = statusParam = "<center><img src='../Images/daystatus.png' width='25px' height='25px'/></center>";
             }

             else if (statusParam >= 2) {
                 b = statusParam - 2;
                 b = statusParam = "<center><img src='../Images/minutestatus.png' width='25px' height='25px'/></center>";
             }
             else if (statusParam <= 2) {
                 b = statusParam = "<center><img src='../Images/nowonlinestatus2.png' width='25px' height='25px'/></center>";
             }

             return b;
         }
         function GetConnectivityStatus(statusParam) {
             var b = [];
             if (statusParam < 0) {
                 b = statusParam = "Never Connected";
             }
             else if (statusParam >= 60 && statusParam < 1440) {
                 b = (statusParam / 60);
                 b = "Offline Since " + b.toFixed() + " Hours";
             }
             else if (statusParam >= 1440) {
                 b = statusParam / 1440;
                 b = statusParam = "Offline Since " + b.toFixed() + " Days";
             }

             else if (statusParam >= 2) {
                 b = statusParam - 2;
                 b = statusParam = "Offline Since " + b + " Minutes!";
             }
             else if (statusParam <= 2) {
                 b = statusParam = "Online";
             }

             return b;
         }
         function GetConnectTime(timeparam) {
             var a = [];

             if (timeparam == null) {
                 a = timeparam = "<img src='../Images/offlinestatus.png' width='25px' height='25px'/>";
             }
             else {
                 a = eval("new " + timeparam.substring(1, timeparam.length - 1));
             }
             return a;
         }
         $(document).ready(function () {

             setInterval(function () {
                 $.ajax(
                  {

                      type: "POST",
                      url: "/ConnectivityWeb/NetworkUser.aspx/GetNetworkUsers",
                      contentType: "application/json; charset=utf-8",
                      datatype: "json",
                      success: function (r) {
                          var a = [];
                          var b = [];
                          var c = [];
                          $("#tbl").empty();
                          $("#tbl").append("<tr><td>USER ID</td><td>Business Name</td><td>Business Address</td><td>LOGIN TIME</td><td>Connected Since</td><td>CONNECTIVITY STATUS</td></tr>");
                          for (var i = 0; i < r.d.length; i++) {
                              a[i] = GetConnectTime(r.d[i].NowTime);
                              b[i] = GetConnectivityStatus(r.d[i].ConnectedSince);
                              c[i] = GetConnectivityStatusImage(r.d[i].ConnectedSince);
                              $("#tbl").append(
                                  "<tr><td>" + r.d[i].UserID + "</td>" +
                                   "<td>" + r.d[i].BusinessName + "</td>" +
                                   "<td>" + r.d[i].Address + "</td>" +
                                  "<td>" + a[i] + "</td>" +
                                  "<td>" + b[i] + "</td>" +
                                 // "<td>" + eval(r.d[4].NowTime.substring(1, r.d[4].NowTime.length-1)) + "</td>" +
                               // "<td>"+r.d[i].NowTime==null?r.d[i].NowTime=null:eval(r.d[i].NowTime.substring(1, r.d[i].NowTime.length - 1))+"</td>"+
              //    "<td>" +eval("new " + r.d[i].NowTime.substring(1, r.d[i].NowTime.length - 1))  + "</td>" +
                                  "<td>" + c[i] + "</td>"
                                  //"<td><img src='"+r.d[i].StatusImage+"' width='50px' height='50px'/></td></tr>"
                                  );
                          }
                      }
                  }
           );

             }, 1000);

         });
   </script>

    <div class="content-wrapper">
    <div id="load_post" style="margin-left: 5%; margin-bottom:0px;line-height:40px;padding-top: 2%;">
            <table id="tbl" class="table">
               <tr>
                   
               </tr>
            </table>
            
            <asp:Label ID="lblIP" runat="server" Text=""></asp:Label>
            <%--<input type="button" value="Refresh Status" id="btnStatus" runat="server" />--%>
        </div>
        </div>
       
</asp:Content>
