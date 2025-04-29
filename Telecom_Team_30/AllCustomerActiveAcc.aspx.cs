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
    public partial class AllCustomerActiveAcc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["SYN"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand customerAcc = new SqlCommand("SELECT * FROM dbo.allCustomerAccounts", conn);
            customerAcc.CommandType = System.Data.CommandType.Text;

            conn.Open();
            SqlDataReader reader = customerAcc.ExecuteReader(CommandBehavior.CloseConnection);



            TableRow Row = new TableRow();
            Row.Cells.Add(new TableHeaderCell() { Text = "National ID" });
            Row.Cells.Add(new TableHeaderCell() { Text = "First Name" });
            Row.Cells.Add(new TableHeaderCell() { Text = "Last Name" });
            Row.Cells.Add(new TableHeaderCell() { Text = "Email" });
            Row.Cells.Add(new TableHeaderCell() { Text = "Address" });
            Row.Cells.Add(new TableHeaderCell() { Text = "Date of Birth" });
            Row.Cells.Add(new TableHeaderCell() { Text = "mobileNo" });
            Row.Cells.Add(new TableHeaderCell() { Text = "Account Type" });
            Row.Cells.Add(new TableHeaderCell() { Text = "Status" });
            Row.Cells.Add(new TableHeaderCell() { Text = "Start Date" });
            Row.Cells.Add(new TableHeaderCell() { Text = "Balance" });
            Row.Cells.Add(new TableHeaderCell() { Text = "Points" });
            CustomerActive.Rows.Add(Row);

            while (reader.Read())
            {
                TableRow row = new TableRow();

                TableCell nationalID1 = new TableCell();
                nationalID1.Text = reader.GetInt32(reader.GetOrdinal("nationalID")).ToString();
                row.Cells.Add(nationalID1);

                TableCell firstname1 = new TableCell();
                firstname1.Text = reader.GetString(reader.GetOrdinal("first_name"));
                row.Cells.Add(firstname1);

                TableCell lastname1 = new TableCell();
                lastname1.Text = reader.GetString(reader.GetOrdinal("last_name"));
                row.Cells.Add(lastname1);

                TableCell email1 = new TableCell();
                email1.Text = reader.GetString(reader.GetOrdinal("email"));
                row.Cells.Add(email1);

                TableCell address1 = new TableCell();
                address1.Text = reader.GetString(reader.GetOrdinal("address"));
                row.Cells.Add(address1);


                TableCell DateOfBirth = new TableCell();
                DateOfBirth.Text = reader.GetDateTime(reader.GetOrdinal("date_of_birth")).ToString();
                row.Cells.Add(DateOfBirth);

                TableCell MobileNo = new TableCell();
                MobileNo.Text = reader.GetString(reader.GetOrdinal("MobileNo"));
                row.Cells.Add(MobileNo);


                TableCell accountType = new TableCell();
                accountType.Text = reader.GetString(reader.GetOrdinal("account_type"));
                row.Cells.Add(accountType);


                TableCell status = new TableCell();
                status.Text = reader.GetString(reader.GetOrdinal("status"));
                row.Cells.Add(status);

                TableCell StartDate = new TableCell();
                StartDate.Text = reader.GetDateTime(reader.GetOrdinal("start_date")).ToString();
                row.Cells.Add(StartDate);



                TableCell balance1 = new TableCell();
                balance1.Text = reader.GetDecimal(reader.GetOrdinal("balance")).ToString();
                row.Cells.Add(balance1);

                TableCell point1 = new TableCell();
                if (reader.IsDBNull(reader.GetOrdinal("points")))
                {
                    point1.Text = "0";
                }
                else
                {
                    point1.Text = reader.GetInt32(reader.GetOrdinal("points")).ToString();
                }
                row.Cells.Add(point1);


                CustomerActive.Rows.Add(row);
            }

        }
        protected void GoBack(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }


    }
}