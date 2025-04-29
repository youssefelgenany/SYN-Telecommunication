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
    public partial class AllBenefits : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["SYN"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand allBenefits = new SqlCommand("SELECT * FROM allBenefits", conn);

            conn.Open();
            SqlDataReader readerT = allBenefits.ExecuteReader(CommandBehavior.CloseConnection);



            TableRow RowT = new TableRow();
            RowT.Cells.Add(new TableHeaderCell() { Text = "benefitID" });
            RowT.Cells.Add(new TableHeaderCell() { Text = "description" });
            RowT.Cells.Add(new TableHeaderCell() { Text = "validity_date" });
            RowT.Cells.Add(new TableHeaderCell() { Text = "mobileNo" });
            RowT.Cells.Add(new TableHeaderCell() { Text = "status" });
            Table1.Rows.Add(RowT);
            while (readerT.Read())
            {
                TableRow rowT = new TableRow();

                TableCell benefitID = new TableCell();
                benefitID.Text = readerT.GetInt32(readerT.GetOrdinal("benefitID")).ToString();
                rowT.Cells.Add(benefitID);

                TableCell description = new TableCell();
                description.Text = readerT.GetString(readerT.GetOrdinal("description"));
                rowT.Cells.Add(description);

                TableCell validity_date = new TableCell();
                validity_date.Text = readerT.GetDateTime(readerT.GetOrdinal("validity_date")).ToString();
                rowT.Cells.Add(validity_date);

                TableCell mobileNo = new TableCell();
                mobileNo.Text = readerT.GetString(readerT.GetOrdinal("mobileNo"));
                rowT.Cells.Add(mobileNo);

                TableCell status1 = new TableCell();
                status1.Text = readerT.GetString(readerT.GetOrdinal("status"));
                rowT.Cells.Add(status1);




                Table1.Rows.Add(rowT);


            }
            conn.Close();


        }
        protected void GoBack(object sender, EventArgs e)
        {
            Response.Redirect("CustomerHome.aspx");
        }

    }
}