<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Recharge.aspx.cs" Inherits="Telecom_Team_30.Recharge" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Recharge Balance</title>
  <meta charset="utf-8" /><meta name="viewport" content="width=device-width, initial-scale=1" />
  <link href="https://fonts.googleapis.com/css2?family=Lato&display=swap" rel="stylesheet" />
  <link rel="stylesheet"
        href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"
        crossorigin="anonymous" />
  <style>
    body { background:#011638; font-family:'Lato',sans-serif; color:#364156; margin:0; }
    .container-custom { background:#E0E0E2; padding:30px; border-radius:8px;
      max-width:400px; margin:100px auto; box-shadow:0 4px 8px rgba(0,0,0,0.1);
      text-align:center; border-top:5px solid #364156;
    }
    .alert { margin-top:20px; }
    .btn-back {
      background:#364156; color:#fff; border:none;
      padding:10px 20px; border-radius:4px; margin-top:20px;
    }
  </style>
</head>
<body>
  <form runat="server">
    <div class="container-custom">
      <h2>Recharge Balance</h2>
      <asp:Label ID="Label1" runat="server" CssClass="alert alert-info" />
      <asp:Button runat="server" Text="← Back to Dashboard" OnClick="GoBack" CssClass="btn-back" />
    </div>
  </form>
</body>
</html>
