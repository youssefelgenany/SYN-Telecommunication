using System;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Telecom_Team_30
{
    public partial class CustomerHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateServicePlans();
            }
        }

        private void PopulateServicePlans()
        {
            string connStr = WebConfigurationManager.ConnectionStrings["SYN"].ToString();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM allServicePlans", conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                TableRow headerRow = new TableRow();
                headerRow.Cells.Add(new TableHeaderCell() { Text = "Plan ID" });
                headerRow.Cells.Add(new TableHeaderCell() { Text = "Name" });
                headerRow.Cells.Add(new TableHeaderCell() { Text = "Price" });
                headerRow.Cells.Add(new TableHeaderCell() { Text = "SMS Offered" });
                headerRow.Cells.Add(new TableHeaderCell() { Text = "Minutes Offered" });
                headerRow.Cells.Add(new TableHeaderCell() { Text = "Data Offered" });
                headerRow.Cells.Add(new TableHeaderCell() { Text = "Description" });
                Table1.Rows.Add(headerRow);

                while (reader.Read())
                {
                    TableRow row = new TableRow();

                    TableCell cellPlanID = new TableCell();
                    cellPlanID.Text = reader["planID"].ToString();
                    row.Cells.Add(cellPlanID);

                    TableCell cellName = new TableCell();
                    cellName.Text = reader["name"].ToString();
                    row.Cells.Add(cellName);

                    TableCell cellPrice = new TableCell();
                    cellPrice.Text = reader["price"].ToString();
                    row.Cells.Add(cellPrice);

                    TableCell cellSMS = new TableCell();
                    cellSMS.Text = reader["SMS_offered"].ToString();
                    row.Cells.Add(cellSMS);

                    TableCell cellMinutes = new TableCell();
                    cellMinutes.Text = reader["minutes_offered"].ToString();
                    row.Cells.Add(cellMinutes);

                    TableCell cellData = new TableCell();
                    cellData.Text = reader["data_offered"].ToString();
                    row.Cells.Add(cellData);

                    TableCell cellDesc = new TableCell();
                    cellDesc.Text = reader["description"].ToString();
                    row.Cells.Add(cellDesc);

                    Table1.Rows.Add(row);
                }
                conn.Close();
            }
        }

        protected void allShops(object sender, EventArgs e)
        {
            Response.Redirect("allshops.aspx");
        }

        protected void Subscribed5(object sender, EventArgs e)
        {
            Response.Redirect("Subscribedpast5.aspx");
        }

        protected void RenewSub(object sender, EventArgs e)
        {
            Object Planid1 = planid1.Text;
            Object amount2 = amount1.Text;
            Object method1 = method.Text;

            if (Planid1 == null || amount2 == null || method1 == null)
            {
                Response.Write("Please enter a valid Plan ID, amount, and method");
                return;
            }
            else
            {
                int planid = int.Parse((String)Planid1);
                Decimal amount = Convert.ToDecimal(amount2);
                String methodPay = (String)method1;
                Session["planid"] = planid;
                Session["amount"] = amount;
                Session["method"] = methodPay;
                Response.Redirect("RenewSubscrip.aspx");
            }
        }

        protected void CashbackCustomer(object sender, EventArgs e)
        {
            Object P = Paymentid1.Text;
            Object B = benefitid1.Text;
            if (P == null || B == null)
            {
                Response.Write("Enter a valid payment ID or Benefit ID");
            }
            else
            {
                int payment3 = Int16.Parse(P.ToString());
                int amount3 = Int16.Parse(B.ToString());
                Session["payment3"] = payment3;
                Session["amount3"] = amount3;
                Response.Redirect("CashbackCustomer.aspx");
            }
        }

        protected void Recharge(object sender, EventArgs e)
        {
            Object m = method2.Text;
            Object a = amount2.Text;
            if (m == null || a == null)
            {
                Response.Write("Enter a valid payment method and amount");
            }
            else
            {
                String methodPay = m.ToString();
                Decimal amountPay = Convert.ToDecimal(a);
                Session["methodpay"] = methodPay;
                Session["amountpay"] = amountPay;
                Response.Redirect("Recharge.aspx");
            }
        }

        protected void RedeemV(object sender, EventArgs e)
        {
            Object v = Voucher5.Text;
            if (v == null)
            {
                Response.Write("Please enter a valid voucher ID");
            }
            else
            {
                int voucherid = Int32.Parse(v.ToString());
                Session["voucherid"] = voucherid;
                Response.Redirect("RedeemVo.aspx");
            }
        }

        protected void successfulPayments(object sender, EventArgs e)
        {
            Response.Redirect("successfulPayments.aspx");
        }

        protected void ExtraAmount(object sender, EventArgs e)
        {
            Object p = Planid5.Text;
            if (p == null)
            {
                Response.Write("Please enter a valid Plan ID");
            }
            else
            {
                int planid7 = Int32.Parse(p.ToString());
                Session["planid7"] = planid7;
                Response.Redirect("ExtraAmount.aspx");
            }
        }

        protected void RemainingAmount(object sender, EventArgs e)
        {
            Object p = plan9.Text;
            if (p == null)
            {
                Response.Write("Please enter a valid Plan ID");
            }
            else
            {
                int plan77 = Int32.Parse(p.ToString());
                Session["plan77"] = plan77;
                Response.Redirect("RemainingAmount.aspx");
            }
        }

        protected void HighestVoucher(object sender, EventArgs e)
        {
            Response.Redirect("HighestVoucher.aspx");
        }

        protected void TechnicalTickets(object sender, EventArgs e)
        {
            Object r = TextBox1.Text;
            if (r == null)
            {
                Response.Write("Enter a valid national ID");
            }
            else
            {
                int NID = Int32.Parse(r.ToString());
                Session["NID"] = NID;
                Response.Redirect("TicketAccountCustomer.aspx");
            }
        }

        protected void AllBenefits(object sender, EventArgs e)
        {
            Response.Redirect("AllBenefits.aspx");
        }

        protected void TotalSMS(object sender, EventArgs e)
        {
            Object i = TextBox2.Text;
            Object s = TextBox3.Text;
            Object e1 = TextBox4.Text;

            if (i == null || s == null || e1 == null)
            {
                Response.Write("Enter a valid plan name, start date, and end date");
            }
            else
            {
                String n = (String)i;
                DateTime r = Convert.ToDateTime(s);
                DateTime r2 = Convert.ToDateTime(e1);
                Session["n"] = n;
                Session["r"] = r;
                Session["r2"] = r2;
                Response.Redirect("TotalSMS.aspx");
            }
        }

        protected void Unsubscribed(object sender, EventArgs e)
        {
            var mobile = Session["CustomerMobile"] as string;
            if (string.IsNullOrEmpty(mobile))
            {
                Response.Write("Session expired. Please log in again.");
                return;
            }
            Session["mobile"] = mobile;
            Response.Redirect("Unsubscribed.aspx");
        }

        protected void UsageAcM(object sender, EventArgs e)
        {
            Response.Redirect("UsageAcM.aspx");
        }

        protected void CashbackNat(object sender, EventArgs e)
        {
            Object r = TextBox6.Text;
            if (r == null)
            {
                Response.Write("Enter a valid national ID");
            }
            else
            {
                int NID1 = Int32.Parse(r.ToString());
                Session["NID1"] = NID1;
                Response.Redirect("CashbackNat.aspx");
            }
        }

        protected void LogOut(object sender, EventArgs e)
        {
            Response.Redirect("CustomerLogin.aspx");
        }
    }
}
