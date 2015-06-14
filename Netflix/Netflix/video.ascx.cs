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
        public string PhotoLink { get; set; }
        public string  Name { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void loadData()
        {
            videoname.InnerText = Name;

            photo.Src = PhotoLink;//toont foto
            Toevideo.HRef = "http://localhost:10187/video1.aspx?id="+id;//onthoud id van film voor de informatiepagina
            Toevideo.Name = id;
            videotoe.HRef = VideoLink;
        }
    }
}