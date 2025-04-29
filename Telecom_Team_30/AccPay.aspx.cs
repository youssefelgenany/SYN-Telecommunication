using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.Remoting.Messaging;

namespace Telecom_Team_30
{
    public partial class AccPay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["SYN"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand AccountPaymentPoints = new SqlCommand("Account_Payment_Points", conn);
            AccountPaymentPoints.CommandType = CommandType.StoredProcedure;
            AccountPaymentPoints.Parameters.Add(new SqlParameter("@mobile_num", Session["mob1"]));

           conn.Open();
            SqlDataReader reader = AccountPaymentPoints.ExecuteReader();
                        
                if (reader.Read()) 
                {
                   
                    int paymentsValue = reader.GetInt32(0); 
                    int pointsValue = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);

                   
                    Label1.Text = paymentsValue.ToString();
                    Label2.Text = pointsValue.ToString();
                }
                else
                {
                    Label1.Text = "No records found.";
                    Label2.Text = "No records found.";
                }



            conn.Close();



        }
        protected void GoBack(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}