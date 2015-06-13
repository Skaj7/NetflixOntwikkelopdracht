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
            var email = "kaj.suiker@hotmail.com";//user.Text;
            var pass = "hoihoi";//password.Text;
            var con = DbCon.GetOracleConnection();
            var cmd = con.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM account WHERE email = :mail AND wachtwoord = :pass";

            var paraEmail = cmd.CreateParameter();
            paraEmail.DbType = DbType.String;
            paraEmail.Value = email;
            paraEmail.ParameterName = "mail";
            paraEmail.Direction = ParameterDirection.Input;

            var paraPass = cmd.CreateParameter();
            paraPass.DbType = DbType.String;
            paraPass.Value = pass;
            paraPass.ParameterName = "pass";
            paraPass.Direction = ParameterDirection.Input;

            cmd.Parameters.Add(paraEmail);
            cmd.Parameters.Add(paraPass);

            var connect = (decimal)cmd.ExecuteScalar();
            if (connect == 1)
            {
                Session["loggedIn"] = true;
                Session["Email"] = email;
            }
            else
            {
                Session.Clear();
                Session["loggedIn"] = false;
            }
        }
    }
}