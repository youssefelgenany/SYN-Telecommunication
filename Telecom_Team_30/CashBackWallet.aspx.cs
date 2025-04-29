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
    public partial class CashBackWallet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["SYN"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand Num_of_cashback = new SqlCommand("SELECT * FROM Num_of_cashback", conn);

            conn.Open();
            SqlDataReader readerNC = Num_of_cashback.ExecuteReader(CommandBehavior.CloseConnection);
            


             TableRow RowNC = new TableRow();
            RowNC.Cells.Add(new TableHeaderCell() { Text = "walletID" });
            RowNC.Cells.Add(new TableHeaderCell() { Text = "count of transactions" });
            Table1.Rows.Add(RowNC);
            while (readerNC.Read())
            {
                TableRow rowNC = new TableRow();

                TableCell walletID1 = new TableCell();
                walletID1.Text = readerNC.GetInt32(readerNC.GetOrdinal("walletID")).ToString();
                rowNC.Cells.Add(walletID1);

                TableCell count = new TableCell();
                count.Text = readerNC.GetInt32(readerNC.GetOrdinal("count of transactions")).ToString();
                rowNC.Cells.Add(count);

                Table1.Rows.Add(rowNC);


            }
            conn.Close();

        }
        protected void GoBack(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}