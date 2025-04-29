<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountsUsage.aspx.cs" Inherits="Telecom_Team_30.AccountsUsage" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Account Usage Details</title>
  <meta charset="utf-8" /><meta name="viewport" content="width=device-width, initial-scale=1" />
  <link href="https://fonts.googleapis.com/css2?family=Lato&display=swap" rel="stylesheet" />
  <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
  <style>
    body { background: #011638; font-family:'Lato'; color:#364156; padding:20px; }
    .container-custom { background:#E0E0E2; padding:20px; border-radius:8px; box-shadow:0 4px 8px rgba(0,0,0,0.1); margin-top:20px; }
    h2 { text-align:center; margin-bottom:20px; }
    .btn-back { margin-top:15px; }
  </style>
</head>
<body>
  <form runat="server">
    <div class="container container-custom">
      <h2>Usage for Active Plans</h2>
      <div class="table-responsive">
        <asp:Table ID="Table1" runat="server" CssClass="table table-bordered table-striped table-hover"></asp:Table>
      </div>
      <asp:Button runat="server" Text="← Back to Dashboard" OnClick="GoBack" CssClass="btn btn-secondary btn-block btn-back" />
    </div>
  </form>
  <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
  <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.2/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
