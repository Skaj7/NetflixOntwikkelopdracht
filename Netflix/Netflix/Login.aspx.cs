using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Netflix
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
            Session["loggedIn"] = false;//auto uitloggen als je op de inlogpagina komt
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            bool result = Login();//checkt je inloggegevens
            if (!result)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Inloggen is gefaald')</script>");
            }
            else
            {
                Response.Redirect("http://localhost:10187/Profile.aspx");
            }
        }
        //returned bool voor geslaagd of niet
        public bool Login()
        {
            var mail = user.Text;
            var pass = password.Text;
            var con1 = DbCon.GetOracleConnection();
            var cmd1 = con1.CreateCommand();
            cmd1.CommandText = "SELECT COUNT(ACCOUNTID) FROM account WHERE email = :mail AND wachtwoord = :pass";

            cmd1.Parameters.Add(DbCon.GetParameter(mail.ToString()));
            cmd1.Parameters.Add(DbCon.GetParameter(pass.ToString()));

            var count = (decimal)cmd1.ExecuteScalar(); //kijkt of jouw account bestaat

            if (count == 0)
            {
                return false;
            }
            var con = DbCon.GetOracleConnection();
            var cmd = con.CreateCommand();

            cmd.CommandText = "SELECT ACCOUNTID FROM account WHERE email = :mail AND wachtwoord = :pass";

            cmd.Parameters.Add(DbCon.GetParameter(mail.ToString()));
            cmd.Parameters.Add(DbCon.GetParameter(pass.ToString()));

            long connect = (long)cmd.ExecuteScalar();

            if (connect > 0)
            {
                Session["loggedIn"] = true;//onthoud ingelog
                Session["account"] = connect;//onthoud accountId

                return true;
            }
            else
            {
                Session.Clear();
                Session["loggedIn"] = false;     
                return false;
            }
        }
    }
}