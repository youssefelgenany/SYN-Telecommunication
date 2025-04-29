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
    public partial class Unsubscribed : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["SYN"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand Unsubscribed_Plans = new SqlCommand("Unsubscribed_Plans", conn);
            Unsubscribed_Plans.CommandType = CommandType.StoredProcedure;
            Unsubscribed_Plans.Parameters.Add(new SqlParameter("@mobile_num", Session["CustomerMobile"]));

            conn.Open();

            SqlDataReader readerT = Unsubscribed_Plans.ExecuteReader(CommandBehavior.CloseConnection);

            TableRow RowT = new TableRow();
            RowT.Cells.Add(new TableHeaderCell() { Text = "planID" });
            RowT.Cells.Add(new TableHeaderCell() { Text = "name" });
            RowT.Cells.Add(new TableHeaderCell() { Text = "price" });
            RowT.Cells.Add(new TableHeaderCell() { Text = "SMS_offered" });
            RowT.Cells.Add(new TableHeaderCell() { Text = "minutes_offered" });
            RowT.Cells.Add(new TableHeaderCell() { Text = "data_offered" });
            RowT.Cells.Add(new TableHeaderCell() { Text = "description" });
            Table1.Rows.Add(RowT);
            while (readerT.Read())
            {
                TableRow rowT = new TableRow();
                TableCell planID = new TableCell();
                planID.Text = readerT.GetInt32(readerT.GetOrdinal("planID")).ToString();
                rowT.Cells.Add(planID);

                TableCell name = new TableCell();
                name.Text = readerT.GetString(readerT.GetOrdinal("name"));
                rowT.Cells.Add(name);

                TableCell price = new TableCell();
                price.Text = readerT.GetInt32(readerT.GetOrdinal("price")).ToString();
                rowT.Cells.Add(price);

                TableCell SMS_offered = new TableCell();
                SMS_offered.Text = readerT.GetInt32(readerT.GetOrdinal("SMS_offered")).ToString();
                rowT.Cells.Add(SMS_offered);

                TableCell minutes_offered = new TableCell();
                minutes_offered.Text = readerT.GetInt32(readerT.GetOrdinal("minutes_offered")).ToString();
                rowT.Cells.Add(minutes_offered);

                TableCell data_offered = new TableCell();
                data_offered.Text = readerT.GetInt32(readerT.GetOrdinal("data_offered")).ToString();
                rowT.Cells.Add(data_offered);

                TableCell description = new TableCell();
                description.Text = readerT.GetString(readerT.GetOrdinal("description"));
                rowT.Cells.Add(description);




                Table1.Rows.Add(rowT);


            }
            readerT.Close();
            conn.Close();

            if (Table1.Rows.Count == 1)
            {
                Response.Write(s: "No valid account with benefits on this planID Please enter a valid planID or Mobile Number");

            }
        }
        protected void GoBack(object sender, EventArgs e)
        {
            Response.Redirect("CustomerHome.aspx");
        }
    }
}