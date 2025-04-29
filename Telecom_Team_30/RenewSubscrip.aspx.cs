using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;

namespace Telecom_Team_30
{
    public partial class RenewSubscrip : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string mobile = Session["CustomerMobile"] as string;
                object amtObj = Session["amount"];
                object pidObj = Session["planid"];
                string method = Session["method"] as string;

                if (mobile == null || amtObj == null || pidObj == null || method == null)
                {
                    errorLabel.Text = "Session expired or missing data. Please log in and try again.";
                    errorLabel.Visible = true;
                    return;
                }

                decimal amount;
                int planId;
                try
                {
                    amount = Convert.ToDecimal(amtObj);
                    planId = Convert.ToInt32(pidObj);
                }
                catch
                {
                    errorLabel.Text = "Invalid session data for amount or plan ID.";
                    errorLabel.Visible = true;
                    return;
                }

                try
                {
                    string connStr = WebConfigurationManager.ConnectionStrings["SYN"].ToString();
                    using (SqlConnection conn = new SqlConnection(connStr))
                    {
                        using (SqlCommand cmd = new SqlCommand("Initiate_plan_payment", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@mobile_num", mobile);
                            cmd.Parameters.AddWithValue("@amount", amount);
                            cmd.Parameters.AddWithValue("@payment_method", method);
                            cmd.Parameters.AddWithValue("@plan_id", planId);

                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }

                    successLabel.Text = "Subscription renewed successfully!";
                    successLabel.Visible = true;
                }
                catch (Exception ex)
                {
                    errorLabel.Text = "Error renewing subscription: " + ex.Message;
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
