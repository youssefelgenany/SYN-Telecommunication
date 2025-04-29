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
    public partial class RemainingAmount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["SYN"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand Remaining_plan_amount = new SqlCommand("SELECT dbo.Remaining_plan_amount(@MobileNo, @plan_name)", conn);
            Remaining_plan_amount.CommandType = System.Data.CommandType.Text;
            Remaining_plan_amount.Parameters.Add(new SqlParameter("@MobileNo", Session["CustomerMobile"]));
            Remaining_plan_amount.Parameters.Add(new SqlParameter("@plan_name", Session["plan77"]));
            conn.Open();

            Label1.Text = Remaining_plan_amount.ExecuteScalar().ToString();


            if (Label1.Text == null)
            {
                Response.Write("No extra amount for entered account and/or plan please make sure that you entered valid info");
            }
            conn.Close();


        }
        protected void GoBack(object sender, EventArgs e)
        {
            Response.Redirect("CustomerHome.aspx");
        }
    }
}