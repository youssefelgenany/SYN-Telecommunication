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
    public partial class AllWallets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["SYN"].ToString();
            SqlConnection conn = new SqlConnection(connStr);











            SqlCommand CustomerWallet = new SqlCommand("SELECT * FROM CustomerWallet", conn);

            conn.Open();
            SqlDataReader readerCW = CustomerWallet.ExecuteReader(CommandBehavior.CloseConnection);



            TableRow RowCW = new TableRow();
            RowCW.Cells.Add(new TableHeaderCell() { Text = "walletID" });
            RowCW.Cells.Add(new TableHeaderCell() { Text = "current_balance" });
            RowCW.Cells.Add(new TableHeaderCell() { Text = "currency" });
            RowCW.Cells.Add(new TableHeaderCell() { Text = "last_modified_date" });
            RowCW.Cells.Add(new TableHeaderCell() { Text = "nationalID" });
            RowCW.Cells.Add(new TableHeaderCell() { Text = "mobileNo" });
            RowCW.Cells.Add(new TableHeaderCell() { Text = "first_name" });
            RowCW.Cells.Add(new TableHeaderCell() { Text = "last_name" });
            Table1.Rows.Add(RowCW);
            while (readerCW.Read())
            {
                TableRow rowCW = new TableRow();

                TableCell walletID1 = new TableCell();
                walletID1.Text = readerCW.GetInt32(readerCW.GetOrdinal("walletID")).ToString();
                rowCW.Cells.Add(walletID1);

                TableCell current_balance1 = new TableCell();
                current_balance1.Text = readerCW.GetDecimal(readerCW.GetOrdinal("current_balance")).ToString();
                rowCW.Cells.Add(current_balance1);

                TableCell currency1 = new TableCell();
                currency1.Text = readerCW.GetString(readerCW.GetOrdinal("currency"));
                rowCW.Cells.Add(currency1);

                TableCell last_modified_date1 = new TableCell();
                last_modified_date1.Text = readerCW.GetDateTime(readerCW.GetOrdinal("last_modified_date")).ToString();
                rowCW.Cells.Add(last_modified_date1);

                TableCell nationalID1 = new TableCell();
                nationalID1.Text = readerCW.GetInt32(readerCW.GetOrdinal("nationalID")).ToString();
                rowCW.Cells.Add(nationalID1);

                TableCell mobileNo1 = new TableCell();
                mobileNo1.Text = readerCW.GetString(readerCW.GetOrdinal("mobileNo"));
                rowCW.Cells.Add(mobileNo1);

                TableCell first_name1 = new TableCell();
                first_name1.Text = readerCW.GetString(readerCW.GetOrdinal("first_name"));
                rowCW.Cells.Add(first_name1);
                TableCell last_name1 = new TableCell();
                last_name1.Text = readerCW.GetString(readerCW.GetOrdinal("last_name"));
                rowCW.Cells.Add(last_name1);


                Table1.Rows.Add(rowCW);


            }
            conn.Close();



        }
        protected void GoBack(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}