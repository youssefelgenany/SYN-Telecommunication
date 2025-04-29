using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace Telecom_Team_30
{
    public partial class allshops : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["SYN"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand allShops = new SqlCommand("SELECT * FROM dbo.allShops", conn);
            allShops.CommandType = CommandType.Text;
            conn.Open();
            SqlDataReader readerA = allShops.ExecuteReader(CommandBehavior.CloseConnection);


            TableRow RowA = new TableRow();
            RowA.Cells.Add(new TableHeaderCell() { Text = "shopID" });
            RowA.Cells.Add(new TableHeaderCell() { Text = "name" });
            RowA.Cells.Add(new TableHeaderCell() { Text = "Category" });
            Table1.Rows.Add(RowA);
            while (readerA.Read())
            {

                TableRow rowA = new TableRow();

                TableCell planID1 = new TableCell();
                planID1.Text = readerA.GetInt32(readerA.GetOrdinal("shopID")).ToString();
                rowA.Cells.Add(planID1);

                TableCell total_data1 = new TableCell();
                total_data1.Text = readerA.GetString(readerA.GetOrdinal("name")).ToString();
                rowA.Cells.Add(total_data1);

                TableCell Category = new TableCell();
                Category.Text = readerA.GetString(readerA.GetOrdinal("Category")).ToString();
                rowA.Cells.Add(Category);

                Table1.Rows.Add(rowA);
            }
            readerA.Close();
            conn.Close();
            if (Table1.Rows.Count == 1)
            {
                Response.Write("No Usage for entered Mobile Number / from this start date" + "br /" +
                    "please make sure you entered a valid mobileNo/date");
            }
        }
        protected void GoBack(object sender, EventArgs e)
        {
            Response.Redirect("CustomerHome.aspx");
        }

    }
}