using System;
using System.Collections.Generic;

using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace LearnHighCharts.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            SetUpDatabase();

            var fileName = Path.Combine(Environment.CurrentDirectory, "MyDatabase.sqlite");

            if (System.IO.File.Exists(fileName))
            {

            }
            else
            {
                System.IO.File.Create(fileName);
                SetUpDatabase();
            }
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void SetUpDatabase()
        {

            System.Data.SQLite.SQLiteConnection.CreateFile("MyDatabase.sqlite");

            System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection("Data Source = MyDatabase.sqlite; Version = 3;");

            string strCommandText = "CREATE TABLE records (Anxiety REAL, Fear REAL, Depression REAL, DateTime TEXT)";
            SQLiteCommand cmd = new SQLiteCommand(strCommandText, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

        }
    }
}
