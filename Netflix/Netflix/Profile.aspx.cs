using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Netflix
{
    public partial class Profile : System.Web.UI.Page
    {
        private string leeftijd1;
        private string leeftijd2;
        private string leeftijd3;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedIn"] is bool && !(bool)Session["loggedIn"])//check of je bent ingelogd
            {
                Response.Redirect("http://localhost:10187/Login.aspx");//anders terug naar loginpagina
            }
            long id = (long)Session["account"];
            GetProfile(id);
        }
        //maakt alle beschibare profielen aan
        private void GetProfile(long id)
        {
            var con = DbCon.GetOracleConnection();
            var cmd = con.CreateCommand();
            cmd.CommandText = "SELECT afbeelding, naam, profielid FROM profiel where accountid = :id";

            cmd.Parameters.Add(DbCon.GetParameter(id.ToString()));

            var r = cmd.ExecuteReader();
            int i = 1;
            while (r.Read())
            {
                
                if (i == 1)
                {
                    lbl1.Text = r["naam"].ToString();
                    leeftijd1 = r["profielid"].ToString();
                    image1.Src = r["afbeelding"].ToString();
                }
                if (i == 2)
                {
                    lbl2.Text = r["naam"].ToString();
                    leeftijd2 = r["profielid"].ToString();
                    image2.Src = r["afbeelding"].ToString();
                }
                if (i == 3)
                {
                    lbl3.Text = r["naam"].ToString();
                    leeftijd3 = r["profielid"].ToString();
                    image3.Src = r["afbeelding"].ToString();
                }

                i++;
            }

        }

        protected void profiel1_Click(object sender, EventArgs e)
        {
            Session["profiel"] = leeftijd1;//session voor de leeftijd
        }

        protected void profiel2_Click(object sender, EventArgs e)
        {
            Session["profiel"] = leeftijd2;
        }

        protected void newprofile_Click(object sender, EventArgs e)
        {
            long id = (long)Session["account"];
            string accountid = id.ToString();//creart een nieuw profiel.
            bool result = DbCon.InsertProfile(tbafbeelding.Text, tbnaam.Text, tbleeftijd.Text, tbtaal.Text, accountid);
            if (!result)
            {
                newprofile.Text = "failed to insert";
            }
        }

        protected void profile3_Click(object sender, EventArgs e)
        {
            Session["profiel"] = leeftijd3;
        }
    }
}