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
    public partial class PhysicalVouchers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["SYN"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand PhysicalStoreVouchers = new SqlCommand("SELECT * FROM PhysicalStoreVouchers", conn);
            PhysicalStoreVouchers.CommandType = System.Data.CommandType.Text;
            conn.Open();

            SqlDataReader readerP = PhysicalStoreVouchers.ExecuteReader(CommandBehavior.CloseConnection);




            TableRow RowP = new TableRow();
            RowP.Cells.Add(new TableHeaderCell() { Text = "Shop ID" });
            RowP.Cells.Add(new TableHeaderCell() { Text = "Address" });
            RowP.Cells.Add(new TableHeaderCell() { Text = "Working Hours" });
            RowP.Cells.Add(new TableHeaderCell() { Text = "Value" });
            RowP.Cells.Add(new TableHeaderCell() { Text = "VoucherID" });
            Table1.Rows.Add(RowP);

            while (readerP.Read())
            {
                TableRow rowP = new TableRow();
                TableCell shopID1 = new TableCell();
                shopID1.Text = readerP.GetInt32(readerP.GetOrdinal("shopID")).ToString();
                rowP.Cells.Add(shopID1);

                TableCell address1 = new TableCell();
                address1.Text = readerP.GetString(readerP.GetOrdinal("address"));
                rowP.Cells.Add(address1);

                TableCell working_hours1 = new TableCell();
                working_hours1.Text = readerP.GetString(readerP.GetOrdinal("working_hours"));
                rowP.Cells.Add(working_hours1);

                TableCell voucher = new TableCell();
                voucher.Text = readerP.GetInt32(readerP.GetOrdinal("voucherID")).ToString();
                rowP.Cells.Add(voucher);

                TableCell value = new TableCell();
                value.Text = readerP.GetInt32(readerP.GetOrdinal("value")).ToString();
                rowP.Cells.Add(value);

                Table1.Rows.Add(rowP);

            }
            readerP.Close();
            conn.Close();
        }

        protected void GoBack(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}