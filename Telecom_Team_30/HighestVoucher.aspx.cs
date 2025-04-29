using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Telecom_Team_30
{
    public partial class HighestVoucher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["SYN"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand Account_Highest_Voucher = new SqlCommand("Account_Highest_Voucher", conn);
            Account_Highest_Voucher.CommandType = CommandType.StoredProcedure;
            Account_Highest_Voucher.Parameters.Add(new SqlParameter("@mobile_num", Session["CustomerMobile"]));

            conn.Open();
            SqlDataReader reader = Account_Highest_Voucher.ExecuteReader();

            if (reader.Read())
            {

                int MAX = reader.GetInt32(0);


                Label1.Text = MAX.ToString();
            }
            else
            {
                Label1.Text = "No records found.";
            }



            conn.Close();


        }
        protected void GoBack(object sender, EventArgs e)
        {
            Response.Redirect("CustomerHome.aspx");
        }
    }
}