<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/KPRAMasterPage.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="KPRA_RIMS_WEB.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function GetConnectivityStatusImage(statusParam)
        {
            var b = [];
            if (statusParam < 0) {
                b = statusParam = "<center><img src='Images/fullofflinestatus.png' width='50px' height='50px'/></center>";
            }
            else if (statusParam >= 60 && statusParam < 1440) {
                b = (statusParam / 60);
                b = statusParam = "<center><img src='Images/hourstatus.png' width='50px' height='50px'/></center>";
            }
            else if (statusParam >= 1440) {
                b = statusParam / 1440;
                b = statusParam = "<center><img src='Images/daystatus2.png' width='50px' height='50px'/></center>";
            }

            else if (statusParam >= 2) {
                b = statusParam - 2;
                b = statusParam = "<center><img src='Images/minutestatus2.png' width='50px' height='50px'/></center>";
            }
            else if (statusParam <= 2) {
                b = statusParam = "<center><img src='Images/nowonlinestatus2.png' width='50px' height='50px'/></center>";
            }

            return b;
        }
        function GetConnectivityStatus(statusParam) {
            var b=[];
            if (statusParam <0) {
                b = statusParam = "Never Connected";
            }
            else if(statusParam>=60 && statusParam<1440) {
                b = (statusParam / 60);
                b ="Offline Since " + b.toFixed() + " Hours";
            }
            else if (statusParam >= 1440) {
                b = statusParam/1440;
                b = statusParam = "Offline Since " + b.toPrecision(1) + " Days";
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
               a = timeparam = "<img src='Images/offlinestatus.png' width='50px' height='50px'/>";
           }
           else {
               a = eval("new "+timeparam.substring(1, timeparam.length - 1));
           }
           return a;
       }
       $(document).ready(function () {
           
          setInterval(function () {
                   $.ajax(
                    {

                 type: "POST",
                 url: "WebForm1.aspx/GetNetworkUsers",
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
                             "<td>" +b[i] + "</td>" +
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
    <div class="container">
    
    <div id="load_post">
            <table id="tbl" class="table table-responsive">
               <tr>
                   
               </tr>
            </table>
            
            <asp:Label ID="lblIP" runat="server" Text=""></asp:Label>
            <%--<input type="button" value="Refresh Status" id="btnStatus" runat="server" />--%>
        </div>
        </div>
</asp:Content>
