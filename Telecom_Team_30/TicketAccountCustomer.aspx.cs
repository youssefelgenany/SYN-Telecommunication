using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection.Emit;

namespace Telecom_Team_30
{
    public partial class TicketAccountCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["SYN"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand Ticket_Account_Customer = new SqlCommand("Ticket_Account_Customer", conn);
            Ticket_Account_Customer.CommandType = CommandType.StoredProcedure;
            Ticket_Account_Customer.Parameters.Add(new SqlParameter("@NID", Session["NID"]));
            conn.Open();
            

            
            
          
            SqlDataReader reader = Ticket_Account_Customer.ExecuteReader();

            if (reader.Read())
            {

                int Value = reader.GetInt32(0);
               


                Label1.Text = Value.ToString();
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