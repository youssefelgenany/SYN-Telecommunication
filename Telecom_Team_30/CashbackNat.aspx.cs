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
    public partial class CashbackNat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["SYN"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand Cashback_Wallet_Customer = new SqlCommand("Select * from dbo.Cashback_Wallet_Customer(@NID)", conn);
            Cashback_Wallet_Customer.Parameters.Add(new SqlParameter("@NID", Session["NID1"]));
            conn.Open();
            SqlDataReader read = Cashback_Wallet_Customer.ExecuteReader(CommandBehavior.CloseConnection);


            TableRow header = new TableRow();
            header.Cells.Add(new TableHeaderCell() { Text = "cashbackID" });
            header.Cells.Add(new TableHeaderCell() { Text = "benefitID" });
            header.Cells.Add(new TableHeaderCell() { Text = "walletID" });
            header.Cells.Add(new TableHeaderCell() { Text = "amount" });
            header.Cells.Add(new TableHeaderCell() { Text = "credit_date" });
            Table1.Rows.Add(header);
            while (read.Read())
            {

                TableRow r = new TableRow();

                TableCell cashbackID = new TableCell();
                cashbackID.Text = read.GetInt32(read.GetOrdinal("cashbackID")).ToString();
                r.Cells.Add(cashbackID);

                TableCell benefitID = new TableCell();
                benefitID.Text = read.GetInt32(read.GetOrdinal("benefitID")).ToString();
                r.Cells.Add(benefitID);

                TableCell walletID = new TableCell();
                walletID.Text = read.GetInt32(read.GetOrdinal("walletID")).ToString();
                r.Cells.Add(walletID);

                TableCell amount = new TableCell();
                amount.Text = read.GetInt32(read.GetOrdinal("amount")).ToString();
                r.Cells.Add(amount);

                TableCell credit_date = new TableCell();
                credit_date.Text = read.GetDateTime(read.GetOrdinal("credit_date")).ToString();
                r.Cells.Add(credit_date);

                Table1.Rows.Add(r);


            }
            read.Close();
            conn.Close();
            if (Table1.Rows.Count == 1)
            {
                Response.Write("No servive Plans for entered MobileNo");
            }


        }
        protected void GoBack(object sender, EventArgs e)
        {
            Response.Redirect("CustomerHome.aspx");
        }
    }
}