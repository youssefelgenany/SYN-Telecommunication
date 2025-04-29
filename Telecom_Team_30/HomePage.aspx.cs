using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Security;
using System.Web;
using System.Web.Configuration;
using System.Web.Management;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace Telecom_Team_30
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void toAccountPlan(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["SYN"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            int planID = Int16.Parse(PlanID.Text);
            String sub_date = Date.Text;
            DateTime parsedDate;
            Session["planID"] = planID;
            Session["sub_date"] = sub_date;

            if (sub_date == null || !DateTime.TryParse(sub_date, out parsedDate) || planID <= 0)
            {
                Response.Write("please enter a valid date / planID");
                return;
            }

            else
            {
                Response.Redirect("AccountsSub.aspx");
            }
        }
        protected void Benefit(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["SYN"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            String mobile = mob.Text;
            int planid = Int16.Parse(Plan.Text);
            Session["mobile"] = mobile;
            Session["planid"] = planid;

            if (planid <= 0 || mobile == null)
            {
                Response.Write("Please enter a valid planid/mobile Number");
                return;
            }
            else
            {
                Response.Redirect("BenefitsRemove.aspx");
            }
        }
        protected void UsageButton(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["SYN"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            String mobileNo = MobileNo.Text;
            String start_date = StartDate.Text;
            Session["mobileNo"] = mobileNo;
            Session["start"] = start_date;

            if (start_date == null || mobileNo == null)
            {
                Response.Write("Please enter a mobile_No and startDate");

            }
            else
            {
                Response.Redirect("AccountsUsage.aspx");

            }
        }
        protected void Sms(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["SYN"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            String mob = mobileN.Text;
            Session["mob"] = mob;
            if (mob == null)
            {
                Response.Write("Please enter a mobile Number ");
            }
            else
            {
                Response.Redirect("sms.aspx");


            }
        }
        protected void AllActive(object sender, EventArgs e)
        {
            Response.Redirect("AllCustomerActiveAcc.aspx");
        }
        protected void ResolvedT(object sender, EventArgs e)
        {
            Response.Redirect("ResolvedTickets.aspx");
        }
        protected void PhysicalS(object sender, EventArgs e)
        {
            Response.Redirect("PhysicalVouchers.aspx");
        }
        protected void AllAccountPlans(object sender, EventArgs e)
        {
            Response.Redirect("Allaccountsplans.aspx");
        }
        protected void allWallets(object sender, EventArgs e)
        {
            Response.Redirect("AllWallets.aspx");
        }
        protected void EshopVouchers(object sender, EventArgs e)
        {
            Response.Redirect("EshopVouchers.aspx");
        }
        protected void AllPayments(object sender, EventArgs e)
        {
            Response.Redirect("paymentsAccounts.aspx");
        }
        protected void CashbackWallet(object sender, EventArgs e)
        {
            Response.Redirect("CashBackWallet.aspx");
        }
        protected void PaymentsAcc(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["SYN"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            String mob1 = Mobilen1.Text;
            Session["mob1"] = mob1;
            if (mob == null)
            {
                Response.Write("Please enter a mobile Number ");
            }
            else
            {
                Response.Redirect("AccPay.aspx");


            }
        }
        protected void AmountCashback(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["SYN"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            String wallet = TextWallet.Text;
            String planid = TextPlan.Text;
            Session["wallet"] = wallet;
            Session["planid"] = planid;
            if (wallet == null || planid == null)
            {
                Response.Write("Please enter a wallet id and/ plan id");
            }
            else
            {
                Response.Redirect("walletCashback.aspx");
            }
        }
        protected void WalletDuration(object sender, EventArgs e)
        {
            
            String tempwall = Walletid2.Text;
            String SDtemp = StartDate2.Text;
            String EDtemp = EndDate2.Text;
           
           
            DateTime parsedDate;
            if (tempwall == null || SDtemp== null || !DateTime.TryParse(SDtemp, out parsedDate) || !DateTime.TryParse(EDtemp, out parsedDate))
            {

                Response.Write("Please Enter a Valid Wallet id/ Start Date/ End Date");
            }
            else
            {   DateTime SD=DateTime.Parse(SDtemp);
                DateTime ED=DateTime.Parse(EDtemp); 
                int wall = Int16.Parse(tempwall);
                Session["wall"] = wall;
                Session["SD"] = SD;
                Session["ED"] = ED;
                Response.Redirect("WalletDuration.aspx");
            }

        }
        protected void WalletLinked(object sender, EventArgs e)
        {
            String w = mobile3.Text;
            if (w == null)
            {
                Response.Write("Please enter a valid Mobile Number");
            }
            else
            {
                int wallet3=Int32.Parse(w);
                Session["wallet3"]= wallet3;
                Response.Redirect("WalletLinked.aspx");
            }
        }
        protected void mobilePoints(object sender, EventArgs e)
        {
            String mob4 = mobile4.Text;
            if (mob4==null)
            {
                Response.Write("Please enter a valid Mobile Number");
            }
            else
            {
                Session["mob4"] = mob4;
                Response.Redirect("mobilePointsUp.aspx");
            }

        }
        protected void LogOut(object sender, EventArgs e)
        {
            Response.Redirect("Telecommunication.aspx");
        }
    }


    
    
   



}