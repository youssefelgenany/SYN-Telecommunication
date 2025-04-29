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
    public partial class mobilePointsUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["SYN"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand TotalPointsAccount = new SqlCommand("dbo.Total_Points_Account", conn);
            TotalPointsAccount.CommandType = System.Data.CommandType.StoredProcedure;
            TotalPointsAccount.Parameters.Add(new SqlParameter("@mobile_num", Session["mob4"]));
            conn.Open();
           int rowsAffected= TotalPointsAccount.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                Label1.Text = "Points updated successfully";
            }
            else
            {
                Label1.Text = "no accounts updated please make sure you entered a valid number";
            }
        }
        protected void GoBack(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
    
}