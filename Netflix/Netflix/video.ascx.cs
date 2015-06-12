using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Netflix
{
    public partial class video : System.Web.UI.UserControl
    {
        public string VideoLink { get; set; }
        public string id { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void loadData()
        {
            videolinks.InnerText = VideoLink;
            videoid.InnerText = id;
            Toevideo.HRef = "http://localhost:10187/video" + id + ".aspx";
            videotoe.HRef = VideoLink;
        }
    }
}