<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerHome.aspx.cs" Inherits="Telecom_Team_30.CustomerHome" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>SYN Customer Home</title>
  <meta charset="utf-8" /><meta name="viewport" content="width=device-width, initial-scale=1" />
  <link href="https://fonts.googleapis.com/css2?family=Lato&display=swap" rel="stylesheet" />
  <link rel="stylesheet"
        href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"
        crossorigin="anonymous" />
  <style>
    body {
      background-color: #011638;
      font-family: 'Lato', sans-serif;
      color: #364156;
      padding: 20px;
    }
    .container-custom {
      background: #E0E0E2;
      border-radius: 8px;
      padding: 30px;
      max-width: 1000px;
      margin: 20px auto;
      box-shadow: 0 4px 8px rgba(0,0,0,0.1);
    }
    h2.section {
      color: #364156;
      border-bottom: 2px solid #364156;
      padding-bottom: 5px;
      margin-top: 30px;
    }
    .table thead { background: #D6D6D6; }
    .btn-block + .btn-block { margin-top: 8px; }
    .btn-back {
      background: #364156;
      color: #fff;
      border: none;
      width: 100%;
      padding: 12px;
      margin-top: 10px;
      border-radius: 4px;
    }
    .form-inline {
      display: flex;
      flex-wrap: wrap;
      gap: 10px;
      margin-bottom: 15px;
    }
    .form-inline .form-control { flex: 1; }
    .form-inline .btn-block { flex: 1; }
  </style>
</head>
<body>
  <form runat="server">
    <div class="container-custom">

      <h2 class="section">Service Plan Offers</h2>
      <div class="table-responsive">
        <asp:Table ID="Table1" runat="server"
                   CssClass="table table-striped table-bordered table-hover" />
      </div>

      <h2 class="section">Account Management</h2>
      <asp:Button runat="server" Text="View All Shops" OnClick="allShops"
                  CssClass="btn btn-primary btn-block" />
      <asp:Button runat="server" Text="Subscribed Plans (Last 5 Months)"
                  OnClick="Subscribed5" CssClass="btn btn-primary btn-block" />

      <h2 class="section">Renew Subscription</h2>
      <div class="form-inline">
        <asp:TextBox ID="planid1" runat="server" CssClass="form-control" Placeholder="Plan ID" />
        <asp:TextBox ID="amount1" runat="server" CssClass="form-control" Placeholder="Amount" />
        <asp:TextBox ID="method" runat="server" CssClass="form-control" Placeholder="Method" />
        <asp:Button runat="server" Text="Renew" OnClick="RenewSub" CssClass="btn btn-secondary btn-block" />
      </div>

      <h2 class="section">Payments & Cashback</h2>
      <div class="form-inline">
        <asp:TextBox ID="Paymentid1" runat="server" CssClass="form-control" Placeholder="Payment ID" />
        <asp:TextBox ID="benefitid1" runat="server" CssClass="form-control" Placeholder="Benefit ID" />
        <asp:Button runat="server" Text="Check Cashback" OnClick="CashbackCustomer"
                    CssClass="btn btn-secondary btn-block" />
      </div>
      <asp:Button runat="server" Text="Top 10 Successful Payments"
                  OnClick="successfulPayments" CssClass="btn btn-primary btn-block" />

      <h2 class="section">Recharge Balance</h2>
      <div class="form-inline">
        <asp:TextBox ID="method2" runat="server" CssClass="form-control" Placeholder="Method" />
        <asp:TextBox ID="amount2" runat="server" CssClass="form-control" Placeholder="Amount" />
        <asp:Button runat="server" Text="Pay" OnClick="Recharge" CssClass="btn btn-secondary btn-block" />
      </div>

      <h2 class="section">Voucher & Extra Checks</h2>
      <div class="form-inline">
        <asp:TextBox ID="Voucher5" runat="server" CssClass="form-control" Placeholder="Voucher ID" />
        <asp:Button runat="server" Text="Redeem" OnClick="RedeemV"  
                    CssClass="btn btn-secondary btn-block" />
      </div>
      <div class="form-inline">
        <asp:TextBox ID="Planid5" runat="server" CssClass="form-control" Placeholder="Plan ID" />
        <asp:Button runat="server" Text="Check Extra Amount" OnClick="ExtraAmount"
                    CssClass="btn btn-secondary btn-block" />
      </div>
      <div class="form-inline">
        <asp:TextBox ID="plan9" runat="server" CssClass="form-control" Placeholder="Plan ID" />
        <asp:Button runat="server" Text="Check Remaining Amount" OnClick="RemainingAmount"
                    CssClass="btn btn-secondary btn-block" />
      </div>

      <h2 class="section">Technical Support Tickets</h2>
      <div class="form-inline">
        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" Placeholder="National ID" />
        <asp:Button runat="server" Text="Check Tickets" OnClick="TechnicalTickets"
                    CssClass="btn btn-secondary btn-block" />
      </div>


  <h2 class="section">Unsubscribed Plans</h2>
  <asp:Button runat="server"
              Text="View Unsubscribed Plans"
              OnClick="Unsubscribed"
              CssClass="btn btn-secondary btn-block" />


      <h2 class="section">Wallet Cashback</h2>
      <div class="form-inline">
        <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control" Placeholder="National ID" />
        <asp:Button runat="server" Text="Check Cashback" OnClick="CashbackNat"
                    CssClass="btn btn-secondary btn-block" />
      </div>

      <asp:Button runat="server" Text="All Active Benefits" OnClick="AllBenefits"
                  CssClass="btn btn-primary btn-block mt-2" />

      <h2 class="section">Usage & Consumption</h2>
      <div class="form-inline">
        <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" Placeholder="Plan Name" />
        <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" Placeholder="Start Date" />
        <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" Placeholder="End Date" />
        <asp:Button runat="server" Text="Check total sms" OnClick="TotalSMS" CssClass="btn btn-secondary btn-block" />
      </div>
      <asp:Button runat="server" Text="Current Month Usage" OnClick="UsageAcM"
                  CssClass="btn btn-primary btn-block mt-2" />

      <asp:Button runat="server" Text="Log Out" OnClick="LogOut"
                  CssClass="btn btn-danger btn-block mt-4" />

    </div>
  </form>

  <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
  <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.2/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
