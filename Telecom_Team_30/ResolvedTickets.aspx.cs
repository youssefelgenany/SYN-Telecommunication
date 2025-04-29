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
    public partial class PhysicalStVoucher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["SYN"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand allResolvedTickets = new SqlCommand("SELECT * FROM dbo.allResolvedTickets", conn);
            allResolvedTickets.CommandType= System.Data.CommandType.Text;
            conn.Open();
            SqlDataReader readerT = allResolvedTickets.ExecuteReader(CommandBehavior.CloseConnection);




            TableRow RowT = new TableRow();
            RowT.Cells.Add(new TableHeaderCell() { Text = "ticketID" });
            RowT.Cells.Add(new TableHeaderCell() { Text = "mobileNo" });
            RowT.Cells.Add(new TableHeaderCell() { Text = "issue_description" });
            RowT.Cells.Add(new TableHeaderCell() { Text = "priority_level" });
            RowT.Cells.Add(new TableHeaderCell() { Text = "status" });
            PhysicalV.Rows.Add(RowT);
            while (readerT.Read())
            {
                TableRow rowT = new TableRow();

                TableCell ticketID1 = new TableCell();
                ticketID1.Text = readerT.GetInt32(readerT.GetOrdinal("ticketID")).ToString();
                rowT.Cells.Add(ticketID1);

                TableCell mobileNo1 = new TableCell();
                mobileNo1.Text = readerT.GetString(readerT.GetOrdinal("mobileNo"));
                rowT.Cells.Add(mobileNo1);

                TableCell issue_description1 = new TableCell();
                issue_description1.Text = readerT.GetString(readerT.GetOrdinal("issue_description"));
                rowT.Cells.Add(issue_description1);

                TableCell priority_level1 = new TableCell();
                priority_level1.Text = readerT.GetInt32(readerT.GetOrdinal("priority_level")).ToString();
                rowT.Cells.Add(priority_level1);

                TableCell status1 = new TableCell();
                status1.Text = readerT.GetString(readerT.GetOrdinal("status"));
                rowT.Cells.Add(status1);




                PhysicalV.Rows.Add(rowT);


            }
            conn.Close();


        }
        protected void GoBack(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}