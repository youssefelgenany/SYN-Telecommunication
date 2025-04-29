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
    public partial class UsageAcM : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["SYN"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand Usage_Plan_CurrentMonth = new SqlCommand("Select * from dbo.Usage_Plan_CurrentMonth(@mobile_num)", conn);
            Usage_Plan_CurrentMonth.Parameters.Add(new SqlParameter("@mobile_num", Session["CustomerMobile"]));
            conn.Open();
            SqlDataReader read = Usage_Plan_CurrentMonth.ExecuteReader(CommandBehavior.CloseConnection);


            TableRow header = new TableRow();
            header.Cells.Add(new TableHeaderCell() { Text = "data_consumption" });
            header.Cells.Add(new TableHeaderCell() { Text = "minutes_used" });
            header.Cells.Add(new TableHeaderCell() { Text = "SMS_sent" });
            Table1.Rows.Add(header);
            while (read.Read())
            {

                TableRow r = new TableRow();

                TableCell data_consumption = new TableCell();
                data_consumption.Text = read.GetString(read.GetOrdinal("data_consumption"));
                r.Cells.Add(data_consumption);

                TableCell minutes_used = new TableCell();
                minutes_used.Text = read.GetInt32(read.GetOrdinal("minutes_used")).ToString();
                r.Cells.Add(minutes_used);

                TableCell SMS_sent = new TableCell();
                SMS_sent.Text = read.GetString(read.GetOrdinal("SMS_sent"));
                r.Cells.Add(SMS_sent);

                Table1.Rows.Add(r);


            }
            read.Close();
            conn.Close();
            


        }


        protected void GoBack(object sender, EventArgs e)
        {
            Response.Redirect("CustomerHome.aspx");
        }
    }

}
    
