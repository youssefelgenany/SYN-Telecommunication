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
    public partial class successfulPayments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["SYN"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand Top_Successful_Payments = new SqlCommand("Top_Successful_Payments", conn);
            Top_Successful_Payments.CommandType = CommandType.StoredProcedure;
            Top_Successful_Payments.Parameters.Add(new SqlParameter("@mobile_num", Session["CustomerMobile"]));
            conn.Open();
            SqlDataReader re = Top_Successful_Payments.ExecuteReader(CommandBehavior.CloseConnection);

            TableRow tableRow = new TableRow();


            tableRow.Cells.Add(new TableHeaderCell() { Text = "paymentID" });
            tableRow.Cells.Add(new TableHeaderCell() { Text = "amount" });
            tableRow.Cells.Add(new TableHeaderCell() { Text = "date_of_payment" });
            tableRow.Cells.Add(new TableHeaderCell() { Text = "payment_method" });
            tableRow.Cells.Add(new TableHeaderCell() { Text = "status" });
            tableRow.Cells.Add(new TableHeaderCell() { Text = "mobileNo" });
            Table1.Rows.Add(tableRow);
            while (re.Read())
            {
             
                TableRow rowA = new TableRow();
                TableCell paymentID = new TableCell();
                paymentID.Text = re.GetInt32(re.GetOrdinal("paymentID")).ToString();
                rowA.Cells.Add(paymentID);

                TableCell amount = new TableCell();
                amount.Text = re.GetDecimal(re.GetOrdinal("amount")).ToString();
                rowA.Cells.Add(amount);

                TableCell date_of_payment = new TableCell();
                date_of_payment.Text = re.GetDateTime(re.GetOrdinal("date_of_payment")).ToString();
                rowA.Cells.Add(date_of_payment);

                TableCell payment_method = new TableCell();
                payment_method.Text = re.GetString(re.GetOrdinal("payment_method"));
                rowA.Cells.Add(payment_method);

                TableCell status = new TableCell();
                status.Text = re.GetString(re.GetOrdinal("status"));
                rowA.Cells.Add(status);


                TableCell mobileNo = new TableCell();
                mobileNo.Text = re.GetString(re.GetOrdinal("MobileNo"));
                rowA.Cells.Add(mobileNo);

                Table1.Rows.Add(rowA);

            }
            re.Close();
            conn.Close();

            if (Table1.Rows.Count == 1)
            {
                Response.Write(s: "No valid account with benefits on this planID Please enter a valid planID or Mobile Number");

            }

        }
        protected void GoBack(object sender, EventArgs e)
        {
            Response.Redirect("CustomerHome.aspx");
        }
    }
}