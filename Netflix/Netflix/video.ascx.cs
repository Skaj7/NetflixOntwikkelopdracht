﻿using System;
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
            //foreach (Control c in (Control)video)
        }

        public void loadData()
        {
            videoname.InnerText = Name;
            //videoid.InnerText = id;
            photo.Src = PhotoLink;
            Toevideo.HRef = "http://localhost:10187/video" + id + ".aspx";
            videotoe.HRef = VideoLink;
        }
    }
}