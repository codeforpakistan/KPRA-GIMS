<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminPanel.aspx.cs" Inherits="KPRA_RIMS_WEB.AdminPanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            setInterval(function () {
                $.ajax(
                 {

                     type: "POST",
                     url: "AdminPanel.aspx/GetNumberOfOnlineUsers",
                     contentType: "application/json; charset=utf-8",
                     datatype: "json",
                     success: function (r) {
                         $("#numberOfOnlineUsers").empty();
                         $("#numberOfOnlineUsers").append(r.d);
                     }
                 }
          );

            }, 5000);

            setInterval(function () {
                $.ajax(
                 {

                     type: "POST",
                     url: "AdminPanel.aspx/GetNumberOfTransactionsToday",
                     contentType: "application/json; charset=utf-8",
                     datatype: "json",
                     success: function (r) {
                         $("#numberOfTransactionsToday").empty();
                         $("#numberOfTransactionsToday").append(r.d);
                     }
                 }
          );

            }, 5000);
            setInterval(function () {
                $.ajax(
                 {

                     type: "POST",
                     url: "AdminPanel.aspx/GetTotalSalesToday",
                     contentType: "application/json; charset=utf-8",
                     datatype: "json",
                     success: function (r) {
                         $("#totalSalesToday").empty();
                         $("#totalSalesToday").append(r.d);
                     }
                 }
          );

            }, 5000);
            setInterval(function () {
                $.ajax(
                 {

                     type: "POST",
                     url: "AdminPanel.aspx/GetTotalTaxToday",
                     contentType: "application/json; charset=utf-8",
                     datatype: "json",
                     success: function (r) {
                         $("#totalTaxToday").empty();
                         $("#totalTaxToday").append(r.d);
                     }
                 }
          );

            }, 5000);

            setInterval(function () {
                $.ajax(
                 {

                     type: "POST",
                     url: "AdminPanel.aspx/GetNumberOfTransactionsThisMonth",
                     contentType: "application/json; charset=utf-8",
                     datatype: "json",
                     success: function (r) {
                         $("#numberOfTransactionsThisMonth").empty();
                         $("#numberOfTransactionsThisMonth").append(r.d);
                     }
                 }
          );

            }, 5000);
            setInterval(function () {
                $.ajax(
                 {

                     type: "POST",
                     url: "AdminPanel.aspx/GetTotalSalesThisMonth",
                     contentType: "application/json; charset=utf-8",
                     datatype: "json",
                     success: function (r) {
                         $("#totalSalesThisMonth").empty();
                         $("#totalSalesThisMonth").append(r.d);
                     }
                 }
          );

            }, 5000);
            setInterval(function () {
                $.ajax(
                 {

                     type: "POST",
                     url: "AdminPanel.aspx/GetTotalTaxThisMonth",
                     contentType: "application/json; charset=utf-8",
                     datatype: "json",
                     success: function (r) {
                         $("#totalTaxThisMonth").empty();
                         $("#totalTaxThisMonth").append(r.d);
                     }
                 }
          );

            }, 5000);



        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <h1>
        Dashboard
        <small>Control panel</small>
      </h1>
      <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
        <li class="active">Dashboard</li>
      </ol>
    </section>

    <!-- Main content -->
    <section class="content">
      <!-- Small boxes (Stat box) -->
        <div class="row">
 <div class="col-lg-4 col-xs-6">
          <!-- small box -->
          <div class="small-box bg-aqua">
            <div class="inner">
              <h3 id="numberOfOnlineUsers"></h3>

              <p>Number of online users</p>
            </div>
          </div>
        </div>
        </div>
      <div class="row">
       
        <!-- ./col -->
        <div class="col-lg-4 col-xs-6">
          <!-- small box -->
          <div class="small-box bg-green">
            <div class="inner">
              <h3 id="numberOfTransactionsToday"></h3>

              <p>No of TRX</p>
            </div>
          </div>
        </div>
        <!-- ./col -->
        <div class="col-lg-4 col-xs-6">
          <!-- small box -->
          <div class="small-box bg-yellow">
            <div class="inner">
              <h3 id="totalSalesToday"></h3>

              <p>Total Sales</p>
            </div>
            
          </div>
        </div>
        <!-- ./col -->
        <div class="col-lg-4 col-xs-6">
          <!-- small box -->
          <div class="small-box bg-red">
            <div class="inner">
              <h3 id="totalTaxToday"></h3>

              <p>Total Tax</p>
            </div>
          </div>
        </div>
        <!-- ./col -->
      </div>
      <!-- /.row -->
     <div class="row">
       
        <!-- ./col -->
        <div class="col-lg-4 col-xs-6">
          <!-- small box -->
          <div class="small-box bg-green">
            <div class="inner">
              <h3 id="numberOfTransactionsThisMonth"></h3>

              <p>No of TRX</p>
            </div>
          </div>
        </div>
        <!-- ./col -->
        <div class="col-lg-4 col-xs-6">
          <!-- small box -->
          <div class="small-box bg-yellow">
            <div class="inner">
              <h3 id="totalSalesThisMonth"></h3>

              <p>Total Sales</p>
            </div>
            
          </div>
        </div>
        <!-- ./col -->
        <div class="col-lg-4 col-xs-6">
          <!-- small box -->
          <div class="small-box bg-red">
            <div class="inner">
              <h3 id="totalTaxThisMonth"></h3>

              <p>Total Tax</p>
            </div>
          </div>
        </div>
        <!-- ./col -->
      </div>
     

    </section>
    <!-- /.content -->
  </div>

</asp:Content>
