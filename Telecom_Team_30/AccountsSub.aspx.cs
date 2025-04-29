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
    public partial class AccountsSub : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["SYN"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
           
            SqlCommand AccounPlanfunc = new SqlCommand("Select * from dbo.Account_Plan_date(@sub_date, @planID)", conn);
            AccounPlanfunc.Parameters.Add(new SqlParameter("@sub_date", Session["sub_date"]));
            AccounPlanfunc.Parameters.Add(new SqlParameter("@planID", Session["planID"]));
            conn.Open();
            SqlDataReader read = AccounPlanfunc.ExecuteReader(CommandBehavior.CloseConnection);


            
            TableRow header = new TableRow();
            header.Cells.Add(new TableHeaderCell() { Text = "MobileNo" });
            header.Cells.Add(new TableHeaderCell() { Text = "planID" });
            header.Cells.Add(new TableHeaderCell() { Text = "name" });
            Table1.Rows.Add(header);
            while (read.Read())
            {

                TableRow r = new TableRow();

                TableCell mobileNo = new TableCell();
                mobileNo.Text = read.GetString(read.GetOrdinal("mobileNo"));
                r.Cells.Add(mobileNo);

                TableCell planID1 = new TableCell();
                planID1.Text = read.GetInt32(read.GetOrdinal("planID")).ToString();
                r.Cells.Add(planID1);

                TableCell name = new TableCell();
                name.Text = read.GetString(read.GetOrdinal("name"));
                r.Cells.Add(name);

                Table1.Rows.Add(r);


            }
            read.Close();

            if (Table1.Rows.Count == 1)
            {
                Response.Write("No servive Plans for entered MobileNo");
            }
           
        }
        protected void GoBack(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

    }
    }
