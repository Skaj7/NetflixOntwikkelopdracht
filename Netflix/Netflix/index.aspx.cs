using System;
using System.Collections.Generic;
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
            if (Session["loggedIn"] is bool && (bool)Session["loggedIn"])
            {
                Response.Redirect("http://localhost:10187/Login.aspx");
            }     
            for (int i = 1; i <= 3; i++)
            {
                LoadVideo(i);
            }
        }

        private void LoadVideo(int id)
        {
            var con = DbCon.GetOracleConnection();
            var com = con.CreateCommand();
            com.CommandText = "SELECT videolink, image, titel from video where videoid='"+id+"'";

            var r = com.ExecuteReader();

            while (r.Read())
            {
                var uc = (video)Page.LoadControl("~/video.ascx");
                uc.VideoLink = r["videolink"].ToString();
                uc.id = id.ToString(); //r["videoid"].ToString();
                uc.PhotoLink = r["image"].ToString();
                uc.Name = r["titel"].ToString();

                innerContent.Controls.Add(uc);
                uc.loadData();
            } 
        }
        private void LoadSearch(int id)
        {
            var con = DbCon.GetOracleConnection();
            var com = con.CreateCommand();
            com.CommandText = "SELECT videolink, image, titel from video where videoid='" + id + "' AND UPPER(titel) LIKE UPPER('%lo%')";

            var r = com.ExecuteReader();

            while (r.Read())
            {
                var uc = (video)Page.LoadControl("~/video.ascx");
                uc.VideoLink = r["videolink"].ToString();
                uc.id = id.ToString(); //r["videoid"].ToString();
                uc.PhotoLink = r["image"].ToString();
                uc.Name = r["titel"].ToString();

                innerContent.Controls.Add(uc);
                uc.loadData();
            } 
        }

        protected void Search_TextChanged(object sender, EventArgs e)
        {
            foreach (Control c in )
            for (int i = 1; i <= 3; i++)
            {
                LoadSearch(i);
            }
        }
    }
}