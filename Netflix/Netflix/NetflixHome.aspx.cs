using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Netflix
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private DatabaseQuery dq;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            dq = new DatabaseQuery();
            int a = dq.example();
        }
    }
}