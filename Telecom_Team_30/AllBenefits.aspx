<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllBenefits.aspx.cs" Inherits="Telecom_Team_30.AllBenefits" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>All Active Benefits</title>
  <meta charset="utf-8" /><meta name="viewport" content="width=device-width, initial-scale=1" />
  <link href="https://fonts.googleapis.com/css2?family=Lato&display=swap" rel="stylesheet" />
  <link rel="stylesheet"
        href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"
        crossorigin="anonymous" />
  <style>
    body { background:#011638; font-family:'Lato',sans-serif; color:#364156; margin:0; }
    .container-custom { background:#E0E0E2; padding:30px; border-radius:8px;
      max-width:900px; margin:40px auto; box-shadow:0 4px 8px rgba(0,0,0,0.1); }
    h2.section { color:#364156; border-bottom:2px solid #364156;
      padding-bottom:5px; margin-bottom:20px; }
    .table-responsive { margin-top:20px; }
    .btn-back { background:#364156; color:#fff; border:none;
      padding:10px 20px; border-radius:4px; margin-top:20px; }
  </style>
</head>
<body>
  <form runat="server">
    <div class="container-custom">
      <h2 class="section">All Active Benefits</h2>
      <div class="table-responsive">
        <asp:Table ID="Table1" runat="server" CssClass="table table-striped table-bordered" />
      </div>
      <asp:Button runat="server" Text="← Back to Dashboard" OnClick="GoBack" CssClass="btn-back" />
    </div>
  </form>
</body>
</html>
