using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

namespace Telecom_Team_30
{
    public partial class BenefitsRemove : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["SYN"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand BenefitsAccount = new SqlCommand("Benefits_Account", conn);
            BenefitsAccount.CommandType = CommandType.StoredProcedure;
            BenefitsAccount.Parameters.Add(new SqlParameter("@mobile_num", Session["mobile"]));
            BenefitsAccount.Parameters.Add(new SqlParameter("@plan_id", Session["planid"]));
            conn.Open();
            SqlDataReader re = BenefitsAccount.ExecuteReader(CommandBehavior.CloseConnection);

            TableRow tableRow = new TableRow();


            tableRow.Cells.Add(new TableHeaderCell() { Text = "benefitID" });
            tableRow.Cells.Add(new TableHeaderCell() { Text = "Description" });
            tableRow.Cells.Add(new TableHeaderCell() { Text = "Validity_date" });
            tableRow.Cells.Add(new TableHeaderCell() { Text = "status" });
            tableRow.Cells.Add(new TableHeaderCell() { Text = "mobileNo" });
            Table1.Rows.Add(tableRow);
            while (re.Read())
            {
                TableRow rowA = new TableRow();
                TableCell benefitID = new TableCell();
                benefitID.Text = re.GetInt32(re.GetOrdinal("benefitID")).ToString();
                rowA.Cells.Add(benefitID);

                TableCell Description = new TableCell();
                Description.Text = re.GetString(re.GetOrdinal("description"));
                rowA.Cells.Add(Description);

                TableCell ValidityDate = new TableCell();
                ValidityDate.Text = re.GetDateTime(re.GetOrdinal("validity_date")).ToString();
                rowA.Cells.Add(ValidityDate);

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
                Response.Write(s: "No valid account with benefits on this planID Please enter a valid planID or Mobile Number");

            }
        }

    
        protected void GoBack(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}