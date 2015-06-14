using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Netflix
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var text = Search.Text;
            if (Session["loggedIn"] is bool && !(bool)Session["loggedIn"])
            {
                Response.Redirect("http://localhost:10187/Login.aspx");
            }
            string profile = (string)Session["profiel"];
            if (profile == "" || profile == null)
            {
                Response.Redirect("http://localhost:10187/Profile.aspx");
            }
            if (text == "")
            {
                //for (int i = 1; i <= 3; i++)
                //{
                    LoadVideo((string)Session["profiel"]);
                //}
            }
        }

        private void LoadVideo(string profileid)
        {
            var con = DbCon.GetOracleConnection();
            var cmd = con.CreateCommand();
            cmd.CommandText = "SELECT videolink, v.videoid, image, titel from video v, profiel_video pv WHERE v.videoid = pv.videoid AND profielid = :profileid";
                //SELECT videolink, image, titel from video where videoid= :id";

            var paraId = DbCon.GetParameter(profileid.ToString());

            cmd.Parameters.Add(paraId);

            var r = cmd.ExecuteReader();

            while (r.Read())
            {
                var uc = (video)Page.LoadControl("~/video.ascx");
                uc.VideoLink = r["videolink"].ToString();
                uc.id = r["videoid"].ToString(); 
                uc.PhotoLink = r["image"].ToString();
                uc.Name = r["titel"].ToString();

                innerContent.Controls.Add(uc);
                uc.loadData();
            } 
        }
        private void LoadSearch(string profileid, string search)
        {
            var con = DbCon.GetOracleConnection();
            var cmd = con.CreateCommand();
            cmd.CommandText = "SELECT videolink, v.videoid, image, titel from video v, profiel_video pv WHERE v.videoid = pv.videoid AND profielid = :profileid AND UPPER(titel) LIKE UPPER('%'||:search||'%')";

            cmd.Parameters.Add(DbCon.GetParameter(profileid.ToString()));
            cmd.Parameters.Add(DbCon.GetParameter(search.ToString()));

            var r = cmd.ExecuteReader();

            while (r.Read())
            {
                var uc = (video)Page.LoadControl("~/video.ascx");
                uc.VideoLink = r["videolink"].ToString();
                uc.id = r["videoid"].ToString();
                uc.PhotoLink = r["image"].ToString();
                uc.Name = r["titel"].ToString();

                innerContent.Controls.Add(uc);
                uc.loadData();
            } 
        }

        protected void Search_TextChanged(object sender, EventArgs e)
        {
            LoadSearch((string)Session["profiel"], Search.Text.ToString());
        }
    }
}