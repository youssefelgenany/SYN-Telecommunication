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
    public partial class sms : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["SYN"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand AccountSMSOffers = new SqlCommand("Select * from dbo.Account_SMS_Offers(@mobile_num)", conn);
            AccountSMSOffers.CommandType = CommandType.Text;
            AccountSMSOffers.Parameters.Add(new SqlParameter("@mobile_num", Session["mob"]));
            conn.Open();
            SqlDataReader re = AccountSMSOffers.ExecuteReader(CommandBehavior.CloseConnection);


            
            TableRow tableRow = new TableRow();

            tableRow.Cells.Add(new TableHeaderCell() { Text = "offerID" });
            tableRow.Cells.Add(new TableHeaderCell() { Text = "benefitID" });
            tableRow.Cells.Add(new TableHeaderCell() { Text = "internet_offered" });
            tableRow.Cells.Add(new TableHeaderCell() { Text = "SMS_offered" });
            tableRow.Cells.Add(new TableHeaderCell() { Text = "minutes_offered" });
            Table1.Rows.Add(tableRow);
            while (re.Read())
            {

                TableRow rowA = new TableRow();

                TableCell offerID = new TableCell();
                offerID.Text = re.GetInt32(re.GetOrdinal("offerID")).ToString();
                rowA.Cells.Add(offerID);

                TableCell benefitID = new TableCell();
                benefitID.Text = re.GetInt32(re.GetOrdinal("benefitID")).ToString();
                rowA.Cells.Add(benefitID);

                TableCell internet_offered = new TableCell();
                internet_offered.Text = re.GetInt32(re.GetOrdinal("internet_offered")).ToString();
                rowA.Cells.Add(internet_offered);

                TableCell SMS_offered = new TableCell();
                SMS_offered.Text = re.GetInt32(re.GetOrdinal("SMS_offered")).ToString();
                rowA.Cells.Add(SMS_offered);

                TableCell minutes_offered = new TableCell();
                minutes_offered.Text = re.GetInt32(re.GetOrdinal("minutes_offered")).ToString();
                rowA.Cells.Add(minutes_offered);

                Table1.Rows.Add(rowA);

            }
            re.Close();


            if (Table1.Rows.Count == 1)
            {
                Response.Write("No Sms offered for input Account " + "br /" + "Follow the following" + "br /" + "make sure entered number is valid");
            }
        }
        protected void GoBack(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}