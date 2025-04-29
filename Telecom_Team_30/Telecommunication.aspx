<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Telecommunication.aspx.cs" Inherits="Telecom_Team_30.Telecommunication" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>SYN Admin Login</title>
   <meta charset="utf-8" />
   <meta name="viewport" content="width=device-width, initial-scale=1" />
   <link href="https://fonts.googleapis.com/css2?family=Lato&display=swap" rel="stylesheet">
   <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"
         crossorigin="anonymous" />
   <style>
      body {
         background-color: #011638;
         font-family: 'Lato', sans-serif;
         height: 100vh;
         margin: 0;
         display: flex;
         justify-content: center;
         align-items: center;
      }
      .login-container {
         width: 100%;
         max-width: 400px;
         padding: 30px;
         background-color: #E0E0E2;
         border-radius: 8px;
         box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
         border-top: 5px solid #364156;
      }
      .login-title {
         text-align: center;
         color: #364156;
         font-weight: 600;
         margin-bottom: 20px;
         font-size: 1.5em;
      }
      .form-label {
         font-weight: bold;
         color: #364156;
      }
      .form-control {
         border: 1px solid #364156;
         border-radius: 4px;
      }
      .error-message {
         color: #cc0000;
         text-align: center;
         margin-top: 10px;
      }
      .btn-custom {
         display: block;
         width: 100%;
         padding: 10px 0;
         margin-top: 15px;
         background-color: #364156;
         border: 1px solid #364156;
         color: #ffffff;
         border-radius: 4px;
         font-size: 1em;
         font-weight: 600;
      }
      .btn-custom:hover {
         background-color: #2a3443;
         border-color: #2a3443;
      }
   </style>
</head>
<body>
   <div class="login-container">
      <h2 class="login-title">Admin Login</h2>
      <asp:Label ID="ErrorMessage" runat="server" CssClass="error-message"></asp:Label>
      <form id="form1" runat="server">
         <div class="form-group">
            <label for="adminID" class="form-label">Admin ID:</label>
            <asp:TextBox ID="adminID" runat="server" CssClass="form-control" placeholder="Enter your Admin ID"></asp:TextBox>
         </div>
         <div class="form-group">
            <label for="Password" class="form-label">Password:</label>
            <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="form-control" placeholder="Enter your password"></asp:TextBox>
         </div>
         <asp:Button runat="server" Text="Login" OnClick="Login" CssClass="btn-custom" />
      </form>
   </div>
   <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" crossorigin="anonymous"></script>
   <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.2/dist/js/bootstrap.bundle.min.js" crossorigin="anonymous"></script>
</body>
</html>
