using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Telecom_Team_30
{
    public partial class RedeemVo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["SYN"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand Redeem_voucher_points = new SqlCommand("dbo.Redeem_voucher_points", conn);
            Redeem_voucher_points.CommandType = System.Data.CommandType.StoredProcedure;
            Redeem_voucher_points.Parameters.Add(new SqlParameter("@mobile_num", Session["CustomerMobile"]));
            Redeem_voucher_points.Parameters.Add(new SqlParameter("@voucher_id", Session["voucherid"]));
            conn.Open();
            int rowsAffected = Redeem_voucher_points.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                Label1.Text = "The Voucheer was redeemed succesfully.";
            }
            else
            {
                Label1.Text = "There was a problem in redeeming the voucher.";
            }

        }
        protected void GoBack(object sender, EventArgs e)
        {
            Response.Redirect("CustomerHome.aspx");
        }
    }
}