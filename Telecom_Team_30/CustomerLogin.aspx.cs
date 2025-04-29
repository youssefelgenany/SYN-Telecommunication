using System;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;

namespace Telecom_Team_30
{
    public partial class CustomerLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Login(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["SYN"].ToString();
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                string mobileNo = TextBox1.Text.Trim();
                string pass = TextBox2.Text;
                if (string.IsNullOrEmpty(mobileNo) || mobileNo.Length != 11)
                {
                    errorLabel.Text = "Please enter a valid 11-digit mobile number.";
                    return;
                }
                if (string.IsNullOrEmpty(pass))
                {
                    errorLabel.Text = "Password cannot be empty.";
                    return;
                }

                var cmd = new SqlCommand(
                  "SELECT dbo.AccountLoginValidation(@mobile, @pass)", conn);
                cmd.Parameters.AddWithValue("@mobile", mobileNo);
                cmd.Parameters.AddWithValue("@pass", pass);

                var result = cmd.ExecuteScalar();
                if (result != null && (bool)result)
                {
                    Session["CustomerMobile"] = mobileNo;
                    Response.Redirect("CustomerHome.aspx");
                }
                else
                {
                    errorLabel.Text = "Invalid mobile number or password.";
                }
            }
        }

        protected void RedirectToAdmin(object sender, EventArgs e)
            => Response.Redirect("Telecommunication.aspx");
    }
}
