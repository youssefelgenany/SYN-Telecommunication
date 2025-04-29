using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;

namespace Telecom_Team_30
{
    public partial class CashbackCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var mobileObj = Session["CustomerMobile"];
                var payObj = Session["payment3"];
                var benefitObj = Session["amount3"]; 

                if (mobileObj == null || payObj == null || benefitObj == null)
                {
                    errorLabel.Text = "Missing session data. Please log in and try again.";
                    errorLabel.Visible = true;
                    return;
                }

                string mobile = mobileObj as string;
                int paymentId = Convert.ToInt32(payObj);
                int benefitId = Convert.ToInt32(benefitObj);

                try
                {
                    string connStr = WebConfigurationManager.ConnectionStrings["SYN"].ToString();
                    using (var conn = new SqlConnection(connStr))
                    using (var cmd = new SqlCommand("Payment_wallet_cashback", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@mobile_num", mobile);
                        cmd.Parameters.AddWithValue("@payment_id", paymentId);
                        cmd.Parameters.AddWithValue("@benefit_id", benefitId);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }

                    successLabel.Text = "Cashback applied successfully!";
                    successLabel.Visible = true;
                }
                catch (Exception ex)
                {
                    errorLabel.Text = "Error applying cashback: " + ex.Message;
                    errorLabel.Visible = true;
                }
            }
        }

        protected void GoBack(object sender, EventArgs e)
        {
            Response.Redirect("CustomerHome.aspx");
        }
    }
}
