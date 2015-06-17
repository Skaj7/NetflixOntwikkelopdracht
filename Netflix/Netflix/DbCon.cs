using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace Netflix
{
    public static class DbCon
    {
        //openend de oracle database connectie
        //return dbconnectie
        public static DbConnection GetOracleConnection()
        {
            try
            {
                var con = OracleClientFactory.Instance.CreateConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["OracleConnection"].ConnectionString;//connection string van web.config
                con.Open();
                return con;
            }
            catch (Exception)
            {
                return null;
            }
        }
        //returned een parameter
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
        //maakt de insert door eerst het volgende profielid optehalen, daarna de profiel insert
        //return bool, check of het gelukt is
        public static bool InsertProfile(string afbeelding, string naam, string leeftijd, string taal, string accountid)
        {

            if (afbeelding == "" || naam == "" || leeftijd == "" || taal == "")//check null
            {
                return false;
            }
            if (leeftijd != "Kleine kinderen" && leeftijd != "Oudere kinderen" && leeftijd != "Tieners" && leeftijd != "Volwassenen")//check constraint
            {
                return false;
            }

            var con = DbCon.GetOracleConnection();
            var cmd = con.CreateCommand();

            cmd.CommandText = "INSERT INTO profiel VALUES(:profielid, :afbeelding, :naam, :leeftijd, :taal, 'Auto', null, :accountid ,null)";

            int profielid = GetNextProfileid();

            var paraPro = cmd.CreateParameter();
            paraPro.DbType = DbType.Int32;
            paraPro.Value = profielid;
            paraPro.ParameterName = "profielid";
            paraPro.Direction = ParameterDirection.Input;

            var paraAcc = cmd.CreateParameter();
            paraAcc.DbType = DbType.Int32;
            paraAcc.Value =  Convert.ToInt32(accountid);
            paraAcc.ParameterName = "accountid";
            paraAcc.Direction = ParameterDirection.Input;

            cmd.Parameters.Add(paraPro);
            cmd.Parameters.Add(DbCon.GetParameter(afbeelding));
            cmd.Parameters.Add(DbCon.GetParameter(naam));
            cmd.Parameters.Add(DbCon.GetParameter(leeftijd));
            cmd.Parameters.Add(DbCon.GetParameter(taal));
            cmd.Parameters.Add(paraAcc);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }

            string[] arr = new string[5];


            if (leeftijd == "Kleine kinderen")
            {
                arr = new string[1];
                arr[0] = "3";
            }

            if (leeftijd == "Oudere kinderen")
            {
                arr = new string[2];
                arr[0] = "3";
                arr[1] = "4";
            }

            if (leeftijd == "Tieners")
            {
                arr = new string[4];
                arr[0] = "3";
                arr[1] = "4";
                arr[2] = "1";
                arr[3] = "2";
            }

            if (leeftijd == "Volwassenen")
            {
                arr = new string[5];
                arr[0] = "3";
                arr[1] = "4";
                arr[2] = "1";
                arr[3] = "2";
                arr[4] = "5";
            }


            foreach (string s in arr)
            {
                var con1 = DbCon.GetOracleConnection();
                var cmd1 = con.CreateCommand();

                cmd1.CommandText = "INSERT INTO profiel_video (PROFIELID, VIDEOID, STERREN) VALUES(:profielid, :VIDEOID, null)";

                var paraProId = cmd.CreateParameter();
                paraProId.DbType = DbType.Int32;
                paraProId.Value = profielid;
                paraProId.ParameterName = "profielid";
                paraProId.Direction = ParameterDirection.Input;

                var paraV = cmd.CreateParameter();
                paraV.DbType = DbType.Int32;
                paraV.Value = Convert.ToInt32(s);
                paraV.ParameterName = "VIDEOID";
                paraV.Direction = ParameterDirection.Input;

                cmd1.Parameters.Add(paraProId);
                cmd1.Parameters.Add(paraV);

                try
                {
                    cmd1.ExecuteNonQuery();
                }
                catch (Exception)
                {

                    return false;
                }
                

            }
           
            return true;
        }
        //return volgende profielid(max+1)
        public static int GetNextProfileid()
        {
            var con = DbCon.GetOracleConnection();
            var cmd = con.CreateCommand();
            cmd.CommandText = "SELECT MAX(profielid) from profiel";

            var p = (decimal)cmd.ExecuteScalar();

            int profielid = (int)p;

            profielid++;

            return profielid;
        }
    }
}