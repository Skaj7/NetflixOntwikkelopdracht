using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Netflix
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["loggedIn"] = false;
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            var mail = "kaj.suiker@hotmail.com";//user.Text;
            var pass = "hoihoi";//password.Text;
            var con = DbCon.GetOracleConnection();
            var cmd = con.CreateCommand();
            cmd.CommandText = "SELECT ACCOUNTID FROM account WHERE email = :mail AND wachtwoord = :pass";

            cmd.Parameters.Add(DbCon.GetParameter(mail.ToString()));
            cmd.Parameters.Add(DbCon.GetParameter(pass.ToString()));

            long connect = (long)cmd.ExecuteScalar();
            if (connect > 0)
            {
                Session["loggedIn"] = true;
                Session["account"] = connect;
            }
            else
            {
                Session.Clear();
                Session["loggedIn"] = false;
            }
        }
    }
}