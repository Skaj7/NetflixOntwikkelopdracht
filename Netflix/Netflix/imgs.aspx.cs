//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;

//namespace Netflix
//{
//    public partial class imgs : System.Web.UI.Page
//    {
//        protected void Page_Load(object sender, EventArgs e)
//        {

//        }
//    }
//}
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

namespace Netflix
{
	/// <summary>
	/// Summary description for imgs.
	/// </summary>
	public partial class imgs : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				CreateImage(Request["id"]);
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	
	
		void  CreateImage(string id)
		{
			// Connectoin string is taken from web.config file.
			SqlConnection _con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["DB"]);
		
			try
			{
				_con.Open();
				SqlCommand _cmd = _con.CreateCommand();
				_cmd.CommandText = "select logo from pub_info where pub_id='" + id + "'";
				byte[] _buf = (byte[])_cmd.ExecuteScalar();
		
				// This is optional
				Response.ContentType = "image/gif";
				//stream it back in the HTTP response
				Response.BinaryWrite(_buf);
				
				
			}
			catch
			{
			}
			finally
			{
				_con.Close();
				
			}
		}

	}


}
