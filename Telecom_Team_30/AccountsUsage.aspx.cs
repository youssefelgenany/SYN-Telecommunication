using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

namespace Telecom_Team_30
{
    public partial class AccountsUsage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["SYN"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand AccountUsagePlan = new SqlCommand("SELECT * FROM dbo.Account_Usage_Plan(@mobile_num,@start_date)", conn);
            AccountUsagePlan.CommandType = CommandType.Text;
            AccountUsagePlan.Parameters.Add(new SqlParameter("@mobile_num", Session["mobileNo"]));
            AccountUsagePlan.Parameters.Add(new SqlParameter("@start_date", Session["start"]));
            conn.Open();
            SqlDataReader readerA = AccountUsagePlan.ExecuteReader(CommandBehavior.CloseConnection);
         


            TableRow RowA = new TableRow();
            RowA.Cells.Add(new TableHeaderCell() { Text = "planID" });
            RowA.Cells.Add(new TableHeaderCell() { Text = "total data" });
            RowA.Cells.Add(new TableHeaderCell() { Text = "total mins" });
            RowA.Cells.Add(new TableHeaderCell() { Text = "total SMS" });
            Table1.Rows.Add(RowA);
            while (readerA.Read())
            {
                TableRow rowA = new TableRow();

                TableCell planID1 = new TableCell();
                planID1.Text = readerA.GetInt32(readerA.GetOrdinal("planID")).ToString();
                rowA.Cells.Add(planID1);

                TableCell total_data1 = new TableCell();
                total_data1.Text = readerA.GetInt32(readerA.GetOrdinal("total data")).ToString();
                rowA.Cells.Add(total_data1);

                TableCell total1 = new TableCell();
                total1.Text = readerA.GetInt32(readerA.GetOrdinal("total mins")).ToString();
                rowA.Cells.Add(total1);

                TableCell totalSMS1 = new TableCell();
                totalSMS1.Text = readerA.GetInt32(readerA.GetOrdinal("total SMS")).ToString();
                rowA.Cells.Add(totalSMS1);





                Table1.Rows.Add(rowA);


            }
            readerA.Close();
           conn.Close();

            if (Table1.Rows.Count == 1)
            {
                Response.Write("No Usage for entered Mobile Number / from this start date" + "br /" +
                    "please make sure you entered a valid mobileNo/date");
            }

        }
        protected void GoBack(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}