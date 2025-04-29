using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace Telecom_Team_30
{
    public partial class Subscribedpast5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            String connStr = WebConfigurationManager.ConnectionStrings["SYN"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand Subscribedplans5Months = new SqlCommand("SELECT * FROM dbo.Subscribed_plans_5_Months(@MobileNo)", conn);
            Subscribedplans5Months.CommandType = CommandType.Text;
            Subscribedplans5Months.Parameters.Add(new SqlParameter("@MobileNo", Session["CustomerMobile"]));

            conn.Open();
            SqlDataReader readerA = Subscribedplans5Months.ExecuteReader(CommandBehavior.CloseConnection);
            

            TableRow RowA = new TableRow();
            RowA.Cells.Add(new TableHeaderCell() { Text = "planID" });
            RowA.Cells.Add(new TableHeaderCell() { Text = "name" });
            RowA.Cells.Add(new TableHeaderCell() { Text = "price" });
            RowA.Cells.Add(new TableHeaderCell() { Text = "shopID" });
            RowA.Cells.Add(new TableHeaderCell() { Text = "SMS_offered" });
            RowA.Cells.Add(new TableHeaderCell() { Text = "minutes_offered" });
            RowA.Cells.Add(new TableHeaderCell() { Text = "data_offered" });
            RowA.Cells.Add(new TableHeaderCell() { Text = "description" });
            Table1.Rows.Add(RowA);
            while (readerA.Read())
            {

                TableRow rowA = new TableRow();

                TableCell planID1 = new TableCell();
                planID1.Text = readerA.GetInt32(readerA.GetOrdinal("planID")).ToString();
                rowA.Cells.Add(planID1);

                TableCell name = new TableCell();
                name.Text = readerA.GetString(readerA.GetOrdinal("name"));
                rowA.Cells.Add(name);

                TableCell price = new TableCell();
                price.Text = readerA.GetInt32(readerA.GetOrdinal("price")).ToString();
                rowA.Cells.Add(price);

                TableCell shopID = new TableCell();
                shopID.Text = readerA.GetInt32(readerA.GetOrdinal("shopID")).ToString();
                rowA.Cells.Add(shopID);

                TableCell SMSoffered = new TableCell();
                SMSoffered.Text = readerA.GetInt32(readerA.GetOrdinal("SMS_offered")).ToString();
                rowA.Cells.Add(SMSoffered);

                TableCell minutesoffered = new TableCell();
                minutesoffered.Text = readerA.GetInt32(readerA.GetOrdinal("minutes_offered")).ToString();
                rowA.Cells.Add(minutesoffered);


                TableCell dataoffered = new TableCell();
                dataoffered.Text = readerA.GetInt32(readerA.GetOrdinal("data_offered")).ToString();
                rowA.Cells.Add(dataoffered);

                TableCell description = new TableCell();
                description.Text = readerA.GetString(readerA.GetOrdinal("description"));
                rowA.Cells.Add(description);







                Table1.Rows.Add(rowA);
            }
            conn.Close();
        }
        protected void GoBack(object sender, EventArgs e)
        {
            Response.Redirect("CustomerHome.aspx");
        }
    }
}