using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Netflix
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var search1 = SearchTitle.Text;//kijkt of er naar iets gezocht wordt
            var search2 = SearchGenre.Text;
            if (Session["loggedIn"] is bool && !(bool)Session["loggedIn"])// check of je bent ingelogd
            {
                Response.Redirect("http://localhost:10187/Login.aspx");//anders terug naar inlogpagina
            }
            string profile = (string)Session["profiel"];
            if (profile == "" || profile == null)//check of je een profiel gekozen heb
            {
                Response.Redirect("http://localhost:10187/Profile.aspx");//anders terug naar profielpagina
            }
            if (search1 == "" && search2 == "")//als er naar niks gezocht woord, load alle videos
            {
                LoadVideo((string)Session["profiel"]);
            }
        }
        //load alle video die beschikbaar zijn voor zijn profiel
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
        //load alle video die beschikbaar zijn voor zijn profiel en een gedeelte van de search gegevens bezit
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
        //load alle video die beschikbaar zijn voor zijn profiel en de naam van de genre bevatten
        private void LoadGenreSearch(string profileid, string search)
        {
            var con = DbCon.GetOracleConnection();
            var cmd = con.CreateCommand();
            cmd.CommandText = "SELECT videolink, v.videoid, image, titel from video v, genre g, video_genre vg, profiel_video pv WHERE v.videoid = vg.videoid AND v.videoid = pv.videoid AND g.naam = vg.naam AND UPPER(g.naam) = UPPER(:search) AND profielid = :profileid";

            cmd.Parameters.Add(DbCon.GetParameter(search.ToString()));
            cmd.Parameters.Add(DbCon.GetParameter(profileid.ToString()));    

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
        //triggerd na text invoer in genretextbox
        protected void SearchGenre_TextChanged(object sender, EventArgs e)
        {
            LoadGenreSearch((string)Session["profiel"], SearchGenre.Text.ToString());
        }
        //triggerd na text invoer in titeltextbox
        protected void SearchTitle_TextChanged(object sender, EventArgs e)
        {
            LoadSearch((string)Session["profiel"], SearchTitle.Text.ToString());
        }
    }
}