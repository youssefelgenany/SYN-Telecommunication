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
    public partial class Allaccountsplans : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["SYN"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand AccountPlanProc = new SqlCommand("Account_Plan", conn);
            AccountPlanProc.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataReader rdr = AccountPlanProc.ExecuteReader(CommandBehavior.CloseConnection);


            TableRow Arow = new TableRow();
            Arow.Cells.Add(new TableHeaderCell() { Text = "MobileNo" });
            Arow.Cells.Add(new TableHeaderCell() { Text = "pass" });
            Arow.Cells.Add(new TableHeaderCell() { Text = "balance" });
            Arow.Cells.Add(new TableHeaderCell() { Text = "account_type" });
            Arow.Cells.Add(new TableHeaderCell() { Text = "start_date" });
            Arow.Cells.Add(new TableHeaderCell() { Text = "status" });
            Arow.Cells.Add(new TableHeaderCell() { Text = "points" });
            Arow.Cells.Add(new TableHeaderCell() { Text = "nationalID" });
            Arow.Cells.Add(new TableHeaderCell() { Text = "planID" });
            Arow.Cells.Add(new TableHeaderCell() { Text = "name" });
            Arow.Cells.Add(new TableHeaderCell() { Text = "price" });
            Arow.Cells.Add(new TableHeaderCell() { Text = "SMS_offered" });
            Arow.Cells.Add(new TableHeaderCell() { Text = "minutes_offered" });
            Arow.Cells.Add(new TableHeaderCell() { Text = "data_offered" });
            Arow.Cells.Add(new TableHeaderCell() { Text = "description" });
            Table1.Rows.Add(Arow);

            while (rdr.Read())
            {
                TableRow r = new TableRow();

                TableCell mobileNo = new TableCell();
                mobileNo.Text = rdr.GetString(rdr.GetOrdinal("MobileNo"));
                r.Cells.Add(mobileNo);


                TableCell pass = new TableCell();
                pass.Text = rdr.GetString(rdr.GetOrdinal("pass"));
                r.Cells.Add(pass);


                TableCell balance = new TableCell();
                balance.Text = rdr.GetDecimal(rdr.GetOrdinal("balance")).ToString();
                r.Cells.Add(balance);

                TableCell account_type = new TableCell();
                account_type.Text = rdr.GetString(rdr.GetOrdinal("account_type"));
                r.Cells.Add(account_type);

                TableCell start_date = new TableCell();
                start_date.Text = rdr.GetDateTime(rdr.GetOrdinal("start_date")).ToString();
                r.Cells.Add(start_date);

                TableCell status = new TableCell();
                status.Text = rdr.GetString(rdr.GetOrdinal("status"));
                r.Cells.Add(status);

                TableCell points = new TableCell();
                points.Text = rdr.GetInt32(rdr.GetOrdinal("points")).ToString();
                r.Cells.Add(points);

                TableCell nationalID = new TableCell();
                nationalID.Text = rdr.GetInt32(rdr.GetOrdinal("nationalID")).ToString();
                r.Cells.Add(nationalID);

                TableCell planID = new TableCell();
                planID.Text = rdr.GetInt32(rdr.GetOrdinal("planID")).ToString();
                r.Cells.Add(planID);

                TableCell name = new TableCell();
                name.Text = rdr.GetString(rdr.GetOrdinal("name"));
                r.Cells.Add(name);

                TableCell price = new TableCell();
                price.Text = rdr.GetInt32(rdr.GetOrdinal("price")).ToString();
                r.Cells.Add(price);

                TableCell SMS_offered = new TableCell();
                SMS_offered.Text = rdr.GetInt32(rdr.GetOrdinal("SMS_offered")).ToString();
                r.Cells.Add(SMS_offered);

                TableCell minutes_offered = new TableCell();
                minutes_offered.Text = rdr.GetInt32(rdr.GetOrdinal("minutes_offered")).ToString();
                r.Cells.Add(minutes_offered);

                TableCell data_offered = new TableCell();
                data_offered.Text = rdr.GetInt32(rdr.GetOrdinal("data_offered")).ToString();
                r.Cells.Add(data_offered);

                TableCell description = new TableCell();
                pass.Text = rdr.GetString(rdr.GetOrdinal("description"));
                r.Cells.Add(description);
                Table1.Rows.Add(r);
            }
            conn.Close();




        }
        protected void GoBack(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}