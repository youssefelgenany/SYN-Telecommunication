<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="paymentsAccounts.aspx.cs"
    Inherits="Telecom_Team_30.paymentsAccounts" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Payments Accounts</title>
  <meta charset="utf-8" /><meta name="viewport" content="width=device-width, initial-scale=1" />
  <link href="https://fonts.googleapis.com/css2?family=Lato&display=swap" rel="stylesheet" />
  <link rel="stylesheet"
        href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"
        crossorigin="anonymous" />
  <style>
    body { background:#011638; font-family:'Lato'; color:#364156; padding:20px; }
    .container-custom {
      background:#E0E0E2; border-radius:8px; padding:30px;
      margin:40px auto; max-width:800px; box-shadow:0 4px 8px rgba(0,0,0,0.1);
    }
    h2 { text-align:center; margin-bottom:20px; }
    .table thead { background-color:#D6D6D6; }
    .btn-back {
      background:#364156; color:white; border:none;
      width:100%; padding:12px; margin-top:20px; border-radius:4px;
    }
  </style>
</head>
<body>
  <form runat="server">
    <div class="container-custom">
      <h2>Payments Accounts Details</h2>
      <div class="table-responsive">
        <asp:Table ID="Table1" runat="server"
                   CssClass="table table-striped table-bordered table-hover" />
      </div>
      <asp:Button runat="server" Text="← Back to Dashboard" OnClick="GoBack"
                  CssClass="btn-back" />
    </div>
  </form>
  <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
  <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.2/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
