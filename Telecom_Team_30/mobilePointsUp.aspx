<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mobilePointsUp.aspx.cs" Inherits="Telecom_Team_30.mobilePointsUp" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Update Account Points</title>
  <meta charset="utf-8" /><meta name="viewport" content="width=device-width, initial-scale=1" />
  <link href="https://fonts.googleapis.com/css2?family=Lato&display=swap" rel="stylesheet" />
  <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
  <style>
    body { background: #011638; font-family:'Lato'; color:#364156; }
    .container-custom { max-width:500px; margin:60px auto; padding:30px; background:#E0E0E2; border-radius:8px; box-shadow:0 4px 8px rgba(0,0,0,0.1);}
    h2 { text-align:center; margin-bottom:20px; }
  </style>
</head>
<body>
  <form runat="server">
    <div class="container container-custom text-center">
      <h2>Update Account Points</h2>
      <asp:Label ID="Label1" runat="server" CssClass="alert" />
      <asp:Button runat="server" Text="← Back to Dashboard" OnClick="GoBack" CssClass="btn btn-secondary btn-block mt-4" />
    </div>
  </form>
  <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
  <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.2/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
