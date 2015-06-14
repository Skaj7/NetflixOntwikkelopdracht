using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Netflix
{
    public partial class video1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string videoid = Request.QueryString["id"];
            GetInfo(videoid);
        }
        //haald alle informatie op van uit het database
        private void GetInfo(string videoid)
        {
            string stringGenre = GetGenre(videoid);//Get genre via een andere query
            var con = DbCon.GetOracleConnection();
            var cmd = con.CreateCommand();
            //pakt alle informatie via het doorgestuurde video id
            cmd.CommandText = "SELECT Regisseur, videocast, sfeer, streamingdetails, image from video WHERE videoid = :videoid";

            cmd.Parameters.Add(DbCon.GetParameter(videoid));

            var r = cmd.ExecuteReader();

            r.Read();

            maker.Text = r["Regisseur"].ToString();
            cast.Text = r["videocast"].ToString();
            genre.Text = stringGenre;
            imageVideo.Src = r["image"].ToString();
            serieIs.Text = r["sfeer"].ToString();
            details.Text = r["streamingdetails"].ToString();
        }
        // haalt alle genre op die de film/serie bezit
        string GetGenre(string videoid)
        {
            var con = DbCon.GetOracleConnection();
            var cmd = con.CreateCommand();

            cmd.CommandText = "SELECT g.naam from video v, genre g, video_genre vg where v.videoid=vg.videoid AND g.naam = vg.naam AND v.videoid = :videoid";

            cmd.Parameters.Add(DbCon.GetParameter(videoid));

            var r = cmd.ExecuteReader();
            string genre = "";

            while (r.Read())
            {
                genre = genre + r["naam"].ToString() +", ";
            }
            return genre;
        }
    }
}