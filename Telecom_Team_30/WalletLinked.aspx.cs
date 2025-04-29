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
    public partial class WalletLinked : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["SYN"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand WalletMobileno= new SqlCommand("SELECT dbo.Wallet_MobileNo(@mobile_num)", conn);
            WalletMobileno.CommandType = System.Data.CommandType.Text;
            WalletMobileno.Parameters.Add(new SqlParameter("@mobile_num", Session["wallet3"]));
            conn.Open();
            Object result= WalletMobileno.ExecuteScalar();
            if (result != DBNull.Value)
            {
                bool exists = Convert.ToBoolean(result);
                if (exists)
                {
                    Label1.Text = "This mobile number is linked to a wallet.";
                }
                else
                {
                    Label1.Text = "This mobile number isn't linked to any wallet.";
                }
            }
            else
            {
                Label1.Text = "Mobile Number not found please make sure that you entered a valid one";
            }

        }
        protected void GoBack(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}