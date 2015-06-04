using System.Linq;
using System.Net;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;

namespace Netflix
{
    public class DatabaseQuery
    {
        private Database dbConnector;

         public DatabaseQuery()
        {
            dbConnector = new Database("dbi331665", "LHMcvT4XD1");
        }

         public int example()
         {
             var nonquery = string.Format("UPDATE APPARAAT SET Naam = '{0}' WHERE APPARAATID = '1'", "hoi hoi");
             return dbConnector.QueryNoResult(nonquery);
         }
    }
}