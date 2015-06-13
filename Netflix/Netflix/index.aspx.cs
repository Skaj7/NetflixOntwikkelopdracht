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
            if (Session["loggedIn"] is bool && (bool)Session["loggedIn"])
            {
                Response.Redirect("http://localhost:10187/Login.aspx");
            }
            if (text == "")
            {
                for (int i = 1; i <= 3; i++)
                {
                    LoadVideo(i);
                }
            }
        }

        private void LoadVideo(int id)
        {
            var con = DbCon.GetOracleConnection();
            var cmd = con.CreateCommand();
            cmd.CommandText = "SELECT videolink, image, titel from video where videoid= :id";

            var paraId = cmd.CreateParameter();
            paraId.DbType = DbType.String;
            paraId.Value = id.ToString();
            paraId.ParameterName = "id";
            paraId.Direction = ParameterDirection.Input;

            cmd.Parameters.Add(paraId);

            var r = cmd.ExecuteReader();

            while (r.Read())
            {
                var uc = (video)Page.LoadControl("~/video.ascx");
                uc.VideoLink = r["videolink"].ToString();
                uc.id = id.ToString(); 
                uc.PhotoLink = r["image"].ToString();
                uc.Name = r["titel"].ToString();

                innerContent.Controls.Add(uc);
                uc.loadData();
            } 
        }
        private void LoadSearch(int id, string search)
        {
            var con = DbCon.GetOracleConnection();
            var cmd = con.CreateCommand();
            cmd.CommandText = "SELECT videolink, image, titel FROM video where videoid= :id AND UPPER(titel) LIKE UPPER('%'||:search||'%')";

            var paraId1 = cmd.CreateParameter();
            paraId1.DbType = DbType.String;
            paraId1.Value = id.ToString();
            paraId1.ParameterName = "id";
            paraId1.Direction = ParameterDirection.Input;

            var paraSearch = cmd.CreateParameter();
            paraSearch.DbType = DbType.String;
            paraSearch.Value = search;
            paraSearch.ParameterName = "search";
            paraSearch.Direction = ParameterDirection.Input;

            cmd.Parameters.Add(paraId1);
            cmd.Parameters.Add(paraSearch);

            var r = cmd.ExecuteReader();

            while (r.Read())
            {
                var uc = (video)Page.LoadControl("~/video.ascx");
                uc.VideoLink = r["videolink"].ToString();
                uc.id = id.ToString(); 
                uc.PhotoLink = r["image"].ToString();
                uc.Name = r["titel"].ToString();

                innerContent.Controls.Add(uc);
                uc.loadData();
            } 
        }

        protected void Search_TextChanged(object sender, EventArgs e)
        {

            for (int i = 1; i <= 3; i++)
            {
                LoadSearch(i, Search.Text.ToString());
            }
        }
    }
}