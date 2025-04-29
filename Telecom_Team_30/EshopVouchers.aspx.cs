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
    public partial class EshopVouchers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["SYN"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand E_shopVouchers = new SqlCommand("SELECT * FROM dbo.E_shopVouchers", conn);

            conn.Open();
            SqlDataReader readerE = E_shopVouchers.ExecuteReader(CommandBehavior.CloseConnection);



            TableRow RowE = new TableRow();
            RowE.Cells.Add(new TableHeaderCell() { Text = "shopID" });
            RowE.Cells.Add(new TableHeaderCell() { Text = "URL" });
            RowE.Cells.Add(new TableHeaderCell() { Text = "Rating" });
            RowE.Cells.Add(new TableHeaderCell() { Text = "voucherID" });
            RowE.Cells.Add(new TableHeaderCell() { Text = "Value" });
            Table1.Rows.Add(RowE);
            while (readerE.Read())
            {
                TableRow rowE = new TableRow();

                TableCell shopID1 = new TableCell();
                shopID1.Text = readerE.GetInt32(readerE.GetOrdinal("shopID")).ToString();
                rowE.Cells.Add(shopID1);

                TableCell URL1 = new TableCell();
                URL1.Text = readerE.GetString(readerE.GetOrdinal("URL"));
                rowE.Cells.Add(URL1);
                TableCell rating1 = new TableCell();
                rating1.Text = readerE.GetInt32(readerE.GetOrdinal("rating")).ToString();
                rowE.Cells.Add(rating1);

                TableCell voucherID1 = new TableCell();
                voucherID1.Text = readerE.GetInt32(readerE.GetOrdinal("voucherID")).ToString();
                rowE.Cells.Add(voucherID1);

                TableCell value1 = new TableCell();
                value1.Text = readerE.GetInt32(readerE.GetOrdinal("value")).ToString();
                rowE.Cells.Add(value1);

                Table1.Rows.Add(rowE);


            }
         


        }
        protected void GoBack(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}