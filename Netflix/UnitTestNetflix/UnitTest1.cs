using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;



namespace UnitTestNetflix
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetOracleConnection()//controle of database connectie werkt
        {
            var con = Netflix.DbCon.GetOracleConnection();
            var cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM dual";
            var r = cmd.ExecuteReader();

            r.Read();

        }
        [TestMethod]
        public void TestGetNextProfileid()//controle of profielid goed wordt teruggegeven
        {
            var con = Netflix.DbCon.GetOracleConnection();
            var cmd = con.CreateCommand();
            cmd.CommandText = "SELECT MAX(profielid) from profiel";

            var p = (decimal)cmd.ExecuteScalar();

            Assert.AreEqual(p+1, Netflix.DbCon.GetNextProfileid());
            Assert.AreEqual(Netflix.DbCon.GetNextProfileid(), Netflix.DbCon.GetNextProfileid());
        }
        [TestMethod]
        public void TestGetParameter()//test voor parameters
        {
            string a = "";
            string b = "aaaaa";
            Assert.AreNotEqual(Netflix.DbCon.GetParameter(a), Netflix.DbCon.GetParameter(a));
            Assert.AreNotEqual(Netflix.DbCon.GetParameter(b), Netflix.DbCon.GetParameter(b));
            Assert.AreNotEqual(Netflix.DbCon.GetParameter(a), Netflix.DbCon.GetParameter(b));
        }
        [TestMethod]
        public void TestInsertProfile()//test voor insert errors
        {
            Assert.AreEqual(false, Netflix.DbCon.InsertProfile("", "", "", "", "1"));
            Assert.AreEqual(false, Netflix.DbCon.InsertProfile("dasd", "sad", "Volwassenen", "", "1"));
            Assert.AreEqual(false, Netflix.DbCon.InsertProfile("sdasd", "sda", "asfsa", "sfasfas", "1"));
        }

    }
}
