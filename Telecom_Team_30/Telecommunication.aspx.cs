using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Telecom_Team_30
{
    public partial class Telecommunication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void Login(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["SYN"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            int adminId = Int16.Parse(adminID.Text);
            String pass = Password.Text;
            if ((adminId == 1202 && pass == "Salma!1202") || (adminId == 2305 && pass == "Noura@2503") || (adminId == 1212 && pass == "Joe&1212"))
            {
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                ErrorMessage.Text = "The password or ID entered is incorrect.";
            }
            conn.Close();




        }
        protected void CustomerHome(object sender, EventArgs e)
        {
            Response.Redirect("CustomerLogin.aspx");
        }
    }
}