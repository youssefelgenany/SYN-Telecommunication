<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Telecom_Team_30.HomePage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>SYN Admin Dashboard</title>
  <meta charset="utf-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1" />
  
  <link href="https://fonts.googleapis.com/css2?family=Lato&display=swap" rel="stylesheet">
  <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" crossorigin="anonymous"/>

  <style>
    body {
      background-color: #011638;
      font-family: 'Lato', sans-serif;
      margin: 0;
      padding-top: 20px;
    }
    .dashboard-container {
      background-color: #E0E0E2;
      border-radius: 8px;
      padding: 30px;
      box-shadow: 0 4px 8px rgba(0,0,0,0.1);
      margin-bottom: 30px;
    }
    .dashboard-header {
      color: #364156;
      text-align: center;
      margin-bottom: 30px;
      font-weight: bold;
      font-size: 1.8em;
    }
    .section-title {
      color: #364156;
      margin-bottom: 15px;
      font-weight: 600;
      border-bottom: 2px solid #364156;
      padding-bottom: 5px;
      font-size: 1.2em;
    }
    .form-label {
      color: #364156;
      font-weight: 600;
      margin-top: 10px;
    }
    .btn-custom {
      display: block;
      width: 100%;
      padding: 10px 0;
      margin: 10px 0;
      background-color: #364156;
      border: 1px solid #364156;
      color: #ffffff;
      border-radius: 4px;
      font-size: 1em;
      font-weight: 600;
      text-align: center;
    }
    .btn-custom:hover {
      background-color: #2a3443;
      border-color: #2a3443;
    }
  </style>
</head>

<body>
  <form id="form1" runat="server">
    <div class="container">
      <div class="dashboard-container">
        <h2 class="dashboard-header">Admin Dashboard</h2>

        <div class="section-title">Quick Views</div>
        <asp:Button runat="server" Text="View All Customer Profiles and Their Active Accounts"
                    OnClick="AllActive" CssClass="btn-custom" />
        <asp:Button runat="server" Text="View All Resolved Tickets Details"
                    OnClick="ResolvedT" CssClass="btn-custom" />
        <asp:Button runat="server" Text="View All Physical Stores & Vouchers"
                    OnClick="PhysicalS" CssClass="btn-custom" />
        <asp:Button runat="server" Text="View Customer Accounts with Subscribed Plans"
                    OnClick="AllAccountPlans" CssClass="btn-custom" />
        <asp:Button runat="server" Text="View All E-shop Vouchers"
                    OnClick="EshopVouchers" CssClass="btn-custom" />
        <asp:Button runat="server" Text="View Wallets & Customer Names"
                    OnClick="allWallets" CssClass="btn-custom" />
        <asp:Button runat="server" Text="View All Payments & Accounts"
                    OnClick="AllPayments" CssClass="btn-custom" />
        <asp:Button runat="server" Text="View Cashback Counts per Wallet"
                    OnClick="CashbackWallet" CssClass="btn-custom" />

        <div class="section-title">Wallet &amp; Payment Operations</div>
        <label class="form-label">Check if a Mobile Is Linked to a Wallet:</label>
        <asp:TextBox ID="mobile3" runat="server" CssClass="form-control" placeholder="Mobile Number"></asp:TextBox>
        <asp:Button runat="server" Text="Check Linkage" OnClick="WalletLinked" CssClass="btn-custom" />

        <label class="form-label">Update Account Points:</label>
        <asp:TextBox ID="mobile4" runat="server" CssClass="form-control" placeholder="Mobile Number"></asp:TextBox>
        <asp:Button runat="server" Text="Update Points" OnClick="mobilePoints" CssClass="btn-custom" />

        <label class="form-label">Accepted Payments by Mobile:</label>
        <asp:TextBox ID="Mobilen1" runat="server" CssClass="form-control" placeholder="Mobile Number"></asp:TextBox>
        <asp:Button runat="server" Text="Search Payments" OnClick="PaymentsAcc" CssClass="btn-custom" />

        <label class="form-label">Cashback Amount (Wallet &amp; Plan):</label>
        <asp:TextBox ID="TextWallet" runat="server" CssClass="form-control" placeholder="Wallet ID"></asp:TextBox>
        <asp:TextBox ID="TextPlan" runat="server" CssClass="form-control" placeholder="Plan ID"></asp:TextBox>
        <asp:Button runat="server" Text="Get Cashback" OnClick="AmountCashback" CssClass="btn-custom" />

        <label class="form-label">Average Transaction (Wallet over Dates):</label>
        <asp:TextBox ID="Walletid2" runat="server" CssClass="form-control" placeholder="Wallet ID"></asp:TextBox>
        <asp:TextBox ID="StartDate2" runat="server" CssClass="form-control" placeholder="Start Date"></asp:TextBox>
        <asp:TextBox ID="EndDate2" runat="server" CssClass="form-control" placeholder="End Date"></asp:TextBox>
        <asp:Button runat="server" Text="Compute Average" OnClick="WalletDuration" CssClass="btn-custom" />

        <!-- Subscription & Usage -->
        <div class="section-title">Subscription &amp; Usage</div>
        <label class="form-label">Accounts Subscribed to Plan on Date:</label>
        <asp:TextBox ID="PlanID" runat="server" CssClass="form-control" placeholder="Plan ID"></asp:TextBox>
        <asp:TextBox ID="Date" runat="server" CssClass="form-control" placeholder="Date (YYYY-MM-DD)"></asp:TextBox>
        <asp:Button runat="server" Text="View Subscriptions" OnClick="toAccountPlan" CssClass="btn-custom" />
        <asp:Label ID="ErrorMessage" runat="server" CssClass="text-danger"></asp:Label>
        <asp:PlaceHolder ID="AccounPlaDate" runat="server"></asp:PlaceHolder>

        <label class="form-label">Usage Since Date for Account:</label>
        <asp:TextBox ID="MobileNo" runat="server" CssClass="form-control" placeholder="Mobile Number"></asp:TextBox>
        <asp:TextBox ID="StartDate" runat="server" CssClass="form-control" placeholder="Start Date (YYYY-MM-DD)"></asp:TextBox>
        <asp:Button runat="server" Text="View Usage" OnClick="UsageButton" CssClass="btn-custom" />
        <asp:Label ID="UsageError" runat="server" CssClass="text-danger"></asp:Label>
        <asp:PlaceHolder ID="AccountUsagePla" runat="server"></asp:PlaceHolder>

        <!-- SMS & Benefits -->
        <div class="section-title">SMS &amp; Benefits</div>
        <label class="form-label">List SMS Offers:</label>
        <asp:TextBox ID="mobileN" runat="server" CssClass="form-control" placeholder="Mobile Number"></asp:TextBox>
        <asp:Button runat="server" Text="List Offers" OnClick="Sms" CssClass="btn-custom" />
        <asp:PlaceHolder ID="Account_SMS" runat="server"></asp:PlaceHolder>

        <label class="form-label">Remove Benefits:</label>
        <asp:TextBox ID="mob" runat="server" CssClass="form-control" placeholder="Mobile Number"></asp:TextBox>
        <asp:TextBox ID="Plan" runat="server" CssClass="form-control" placeholder="Plan ID"></asp:TextBox>
        <asp:Button runat="server" Text="Remove Benefits" OnClick="Benefit" CssClass="btn-custom" />
        <asp:PlaceHolder ID="BenefitAcc" runat="server"></asp:PlaceHolder>

        <asp:Button runat="server" Text="Log Out" OnClick="LogOut" CssClass="btn btn-danger btn-block mt-4" />
      </div>
    </div>
  </form>

  <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" crossorigin="anonymous"></script>
  <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.2/dist/js/bootstrap.bundle.min.js" crossorigin="anonymous"></script>
</body>
</html>
