<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CashbackCustomer.aspx.cs" Inherits="Telecom_Team_30.CashbackCustomer" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Claim Cashback</title>
  <meta charset="utf-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1" />
  <link href="https://fonts.googleapis.com/css2?family=Lato&display=swap" rel="stylesheet" />
  <link rel="stylesheet"
        href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"
        crossorigin="anonymous" />
  <style>
    body {
      background: #011638;
      font-family: 'Lato', sans-serif;
      display: flex;
      align-items: center;
      justify-content: center;
      height: 100vh;
      margin: 0;
    }
    .container-custom {
      background: #E0E0E2;
      padding: 30px;
      border-radius: 8px;
      max-width: 400px;
      width: 100%;
      box-shadow: 0 4px 8px rgba(0,0,0,0.1);
      border-top: 5px solid #364156;
      text-align: center;
    }
    .alert { margin-top: 20px; }
    .btn-back {
      background: #364156;
      color: #fff;
      border: none;
      width: 100%;
      padding: 12px;
      margin-top: 20px;
      border-radius: 4px;
    }
  </style>
</head>
<body>
  <form id="form1" runat="server">
    <div class="container-custom">
      <h2>Claim Cashback</h2>
      <asp:Label ID="errorLabel" runat="server" CssClass="alert alert-danger" Visible="false" />
      <asp:Label ID="successLabel" runat="server" CssClass="alert alert-success" Visible="false" />
      <asp:Button ID="btnBack" runat="server" Text="← Back to Dashboard"
                  OnClick="GoBack" CssClass="btn-back" />
    </div>
  </form>
  <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
  <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.2/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
