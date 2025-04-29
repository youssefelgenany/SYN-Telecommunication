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
    public partial class WalletDuration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {  
            String connStr = WebConfigurationManager.ConnectionStrings["SYN"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand WalletTransferAmount = new SqlCommand("Select dbo.Wallet_Transfer_Amount(@walletID,@start_date,@end_date)", conn);
            WalletTransferAmount.CommandType = System.Data.CommandType.Text;
            WalletTransferAmount.Parameters.Add(new SqlParameter("@walletID",(int) Session["wall"]));
            WalletTransferAmount.Parameters.Add(new SqlParameter("@start_date",(DateTime)Session["SD"]));
            WalletTransferAmount.Parameters.Add(new SqlParameter("@end_date", (DateTime)Session["ED"]));
            conn.Open();
            Object result = WalletTransferAmount.ExecuteScalar();
           


            if (result == null)
            {
                Response.Write("No Transefer Amounts for entered Wallet id please make sure that you entered a valid one or that you entered a valid duration .Please go back and try again");
           }
            else
            {
                Label1.Text = result.ToString();
            }
            conn.Close();

        }
        protected void GoBack(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}