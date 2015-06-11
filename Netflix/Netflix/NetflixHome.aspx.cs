using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI.HtmlControls;
using System.Web.SessionState;
using System.ComponentModel;
using System.IO;

namespace Netflix
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected System.Web.UI.WebControls.DropDownList drpIds;
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (true)
            {
                CreateImage(Request["id"]);
            }

            if(true)
			{
				
				try
				{
					for(int i = 1; i<=5;i++)
					{
						drpIds.Items.Add(i.ToString());
					}

				}
				catch
				{
				}
				finally
				{

				}
			}
			
		}

        protected void Button1_Click(object sender, EventArgs e)
        {
        using (DbConnection con = OracleClientFactory.Instance.CreateConnection())
                {
                    if (con == null)
                    {
                        //return "Error! No Connection";
                    }
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["OracleConnection"].ConnectionString;
                    con.Open();
                    DbCommand com = OracleClientFactory.Instance.CreateCommand();
                    if (com == null)
                    {
                        //return "Error! No Command";
                    }
                    com.Connection = con;
                    com.CommandText = "Select Apparaatid FROM account_apparaat";
                    //AddParameterWithValue(com, "barc", (string)tbBarcode.Text);
                    DbDataReader reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                         //= Label2.Text + reader[1].ToString();

                        if ((short)reader[0] == 41)
                    {
                        Label1.Text = "Niet betaald";
                    }
                    }
                }
        }
        void CreateImage(string id)
        {
            // Connectoin string is taken from web.config file.
           // SqlConnection _con = new SqlConnection(
              //System.Configuration.ConfigurationSettings.AppSettings["DB"]);
            using (DbConnection con = OracleClientFactory.Instance.CreateConnection())
                try
                {
                    
                    byte[] blobId;
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["OracleConnection"].ConnectionString;
                    con.Open();
                    DbCommand com = OracleClientFactory.Instance.CreateCommand();

                    com.Connection = con;
                    com.CommandText = "SELECT image FROM video where videoid ='1'";// +id + "'";

                    blobId = (byte[])com.ExecuteScalar();
                    
                    //com.CommandText = "SELECT image FROM video where videoid ='"+id+"'";
                    //byte[] _buf = (byte[])com.ExecuteScalar();

                    // This is optional
                    Response.ContentType = "imgs";

                    //stream it back in the HTTP response
                    Response.BinaryWrite(blobId);


                }
                catch
                { }
                finally
                {
                    con.Close();

                }
        }
        private void drpIds_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            Page.DataBind();
        }
        private void InitializeComponent()
        {
            this.drpIds.SelectedIndexChanged += new System.EventHandler(this.drpIds_SelectedIndexChanged);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }
    }
}
    

