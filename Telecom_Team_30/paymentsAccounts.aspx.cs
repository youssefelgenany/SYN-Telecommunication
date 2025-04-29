using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Telecom_Team_30
{
    public partial class paymentsAccounts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["SYN"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand AccountPayments = new SqlCommand("SELECT * FROM AccountPayments", conn);

            conn.Open();
            SqlDataReader readerAP = AccountPayments.ExecuteReader(CommandBehavior.CloseConnection);
            


            TableRow RowAP = new TableRow();
            RowAP.Cells.Add(new TableHeaderCell() { Text = "paymentID" });
            RowAP.Cells.Add(new TableHeaderCell() { Text = "amount" });
            RowAP.Cells.Add(new TableHeaderCell() { Text = "date_of_payment" });
            RowAP.Cells.Add(new TableHeaderCell() { Text = "payment_method" });
            RowAP.Cells.Add(new TableHeaderCell() { Text = "status" });
            Table1.Rows.Add(RowAP); 
            while (readerAP.Read())
            {
                TableRow rowAP = new TableRow();

                TableCell paymentID1 = new TableCell();
                paymentID1.Text = readerAP.GetInt32(readerAP.GetOrdinal("paymentID")).ToString();
                rowAP.Cells.Add(paymentID1);

                TableCell amount1 = new TableCell();
                amount1.Text = readerAP.GetDecimal(readerAP.GetOrdinal("amount")).ToString();
                rowAP.Cells.Add(amount1);
                TableCell date_of_payment1 = new TableCell();
                date_of_payment1.Text = readerAP.GetDateTime(readerAP.GetOrdinal("date_of_payment")).ToString();
                rowAP.Cells.Add(date_of_payment1);

                TableCell payment_method1 = new TableCell();
                payment_method1.Text = readerAP.GetString(readerAP.GetOrdinal("payment_method"));
                rowAP.Cells.Add(payment_method1);

                TableCell status1 = new TableCell();
                status1.Text = readerAP.GetString(readerAP.GetOrdinal("status"));
                rowAP.Cells.Add(status1);

                TableCell mobileNo1 = new TableCell();
                mobileNo1.Text = readerAP.GetString(readerAP.GetOrdinal("mobileNo"));
                rowAP.Cells.Add(mobileNo1);

                Table1.Rows.Add(rowAP);


            }
           conn.Close();


        }
        protected void GoBack(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

    }
}