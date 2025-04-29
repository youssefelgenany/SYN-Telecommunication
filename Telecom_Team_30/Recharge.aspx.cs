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
    public partial class Recharge : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["SYN"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand Initiate_balance_payment = new SqlCommand("dbo.Initiate_balance_payment", conn);
            Initiate_balance_payment.CommandType = System.Data.CommandType.StoredProcedure;
            Initiate_balance_payment.Parameters.Add(new SqlParameter("@mobile_num", Session["CustomerMobile"]));
            Initiate_balance_payment.Parameters.Add(new SqlParameter("@amount", Session["amountpay"]));
            Initiate_balance_payment.Parameters.Add(new SqlParameter("@payment_method ", Session["methodpay"]));
            conn.Open(); 
            int rowsAffected = Initiate_balance_payment.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                Label1.Text = "The balance was recharged succesfully.";
            }
            else
            {
                Label1.Text = "There was a problem in recharging the balance.";
            }

        }
        protected void GoBack(object sender, EventArgs e)
        {
            Response.Redirect("CustomerHome.aspx");
        }
    }
}