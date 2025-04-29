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
    public partial class TotalSMS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["SYN"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand Consumption = new SqlCommand("Select * from dbo.Consumption(@Plan_name, @start_date, @end_date)", conn);
            Consumption.Parameters.Add(new SqlParameter("@Plan_name", Session["n"]));
            Consumption.Parameters.Add(new SqlParameter("@start_date", Session["r"]));
            Consumption.Parameters.Add(new SqlParameter("@end_date", Session["r2"]));
            conn.Open();
            SqlDataReader read = Consumption.ExecuteReader(CommandBehavior.CloseConnection);


            TableRow header = new TableRow();
            header.Cells.Add(new TableHeaderCell() { Text = "data_consumption" });
            header.Cells.Add(new TableHeaderCell() { Text = "minutes_used" });
            header.Cells.Add(new TableHeaderCell() { Text = "SMS_sent" });
            Table1.Rows.Add(header);
            while (read.Read())
            {

                TableRow r = new TableRow();

                TableCell data_consumption = new TableCell();
                data_consumption.Text = read.GetInt32(read.GetOrdinal("data_consumption")).ToString() ;
                r.Cells.Add(data_consumption);

                TableCell minutes_used = new TableCell();
                minutes_used.Text = read.GetInt32(read.GetOrdinal("minutes_used")).ToString();
                r.Cells.Add(minutes_used);

                TableCell SMS_sent = new TableCell();
                SMS_sent.Text = read.GetInt32(read.GetOrdinal("SMS_sent")).ToString() ;
                r.Cells.Add(SMS_sent);

                Table1.Rows.Add(r);


            }
            read.Close();

            if (Table1.Rows.Count == 1)
            {
                Response.Write("No servive Plans for entered MobileNo");
            }


        }
        protected void GoBack(object sender, EventArgs e)
        {
            Response.Redirect("CustomerHome.aspx");
        }
    }
}