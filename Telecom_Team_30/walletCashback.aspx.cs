using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Telecom_Team_30
{
    public partial class walletCashback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["SYN"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand WalletCashbackAmount = new SqlCommand("SELECT dbo.Wallet_Cashback_Amount(@walletID, @planID)", conn);
            WalletCashbackAmount.CommandType=System.Data.CommandType.Text;
            WalletCashbackAmount.Parameters.Add(new SqlParameter("@walletID", Session["wallet"]));
            WalletCashbackAmount.Parameters.Add(new SqlParameter("@planID", Session["planid"]));
            conn.Open();
           
                Label1.Text = WalletCashbackAmount.ExecuteScalar().ToString();


            if (Label1.Text == null)
            {
                Response.Write("No Cashback for entered Wallet and/ plan please make sure that you entered valid numbers");
            }
            conn.Close();



        }
        protected void GoBack(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}