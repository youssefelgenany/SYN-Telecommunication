<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerLogin.aspx.cs" Inherits="Telecom_Team_30.CustomerLogin" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>SYN Customer Login</title>
  <meta charset="utf-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1" />
  <link href="https://fonts.googleapis.com/css2?family=Lato&display=swap" rel="stylesheet" />
  <link rel="stylesheet"
        href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"
        crossorigin="anonymous" />
  <style>
    body {
      background-color: #011638;
      font-family: 'Lato', sans-serif;
      display: flex;
      align-items: center;
      justify-content: center;
      height: 100vh;
      margin: 0;
    }
    .login-container {
      background-color: #E0E0E2;
      padding: 30px;
      border-radius: 8px;
      max-width: 400px;
      width: 100%;
      box-shadow: 0 4px 8px rgba(0,0,0,0.1);
      border-top: 5px solid #364156;
    }
    .login-container h2,
    .login-container .welcome {
      text-align: center;
      color: #364156;
      margin-bottom: 20px;
    }
    .login-container .welcome {
      font-size: 1.1em;
      font-weight: 600;
    }
    .form-control {
      border: 1px solid #364156;
      border-radius: 4px;
    }
    .btn-primary {
      background-color: #364156;
      border-color: #364156;
      width: 100%;
      margin-top: 10px;
    }
    .btn-secondary {
      background-color: #011638;
      border-color: #011638;
      color: #E0E0E2;
      width: 100%;
      margin-top: 10px;
    }
    .error {
      color: #cc0000;
      text-align: center;
      margin-top: 10px;
    }
  </style>
</head>
<body>
  <form id="form1" runat="server" class="login-container">
    <div class="welcome">Welcome to SYN: Where Connection Meets Innovation</div>
    <h2>Customer Login</h2>
    <asp:Label ID="errorLabel" runat="server" CssClass="error" />
    <div class="form-group">
      <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"
                   Placeholder="Mobile Number" />
    </div>
    <div class="form-group">
      <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"
                   CssClass="form-control" Placeholder="Password" />
    </div>
    <asp:Button runat="server" Text="Login" OnClick="Login" CssClass="btn btn-primary" />
    <asp:Button runat="server" Text="Admin Login" OnClick="RedirectToAdmin"
                CssClass="btn btn-secondary" />
  </form>

  <script src="https://code.jquery.com/jquery-
