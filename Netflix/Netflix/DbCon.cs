using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Netflix
{
    public static class DbCon
    {
        public static DbConnection GetOracleConnection()
        {
            var con = OracleClientFactory.Instance.CreateConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["OracleConnection"].ConnectionString;
            con.Open();
            return con;
        }

        public static DbParameter GetParameter(string name)
        {
            var con = DbCon.GetOracleConnection();
            var cmd = con.CreateCommand();

            var para = cmd.CreateParameter();
            para.DbType = DbType.String;
            para.Value = name.ToString();
            para.ParameterName = name.ToString();
            para.Direction = ParameterDirection.Input;

            return para;
        }
    }
}