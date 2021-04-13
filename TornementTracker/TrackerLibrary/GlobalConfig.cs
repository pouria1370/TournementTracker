using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.DataAccess;

namespace TrackerLibrary
{
   public static class GlobalConfig
    {
        public static IDataConnection Connection { private set; get; }
        public static void IniitializeConnection(DatabaseType db)
        {
            switch (db)
            {
                case DatabaseType.Sql:
                    SqlConnector sql = new SqlConnector();
                    Connection =(sql); break;
                case DatabaseType.TextFile:
                    TextConnector txt = new TextConnector();
                    Connection=txt; break;
                default:
                    break;
            }
            //if(database)
            //{
            //    // 1000-set up sql connector properly

            //    SqlConnector sql = new SqlConnector();
            //    Connection.Add(sql);
            //}
            //if(text)
            //{
            //    TextConnector txt = new TextConnector();
            //    Connection.Add(txt);
            //}

        }
        public static string CnnString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
