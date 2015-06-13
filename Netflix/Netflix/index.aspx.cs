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

            for (int i = 1; i <= 3; i++)
            {
                LoadVideo(i);
            }
        }

        private void LoadVideo(int id)
        {
            var con = DbCon.GetOracleConnection();
            var com = con.CreateCommand();
            com.CommandText = "SELECT videolink, videoid from video where videoid='"+id+"'";

            var r = com.ExecuteReader();

            while (r.Read())
            {
                var uc = (video)Page.LoadControl("~/video.ascx");
                uc.VideoLink = r["videolink"].ToString();
                uc.id = r["videoid"].ToString();

                innerContent.Controls.Add(uc);
                uc.loadData();
            } 
        }
    }
}