using System;
using System.Collections.Generic;

using System.Data.SQLite;
using System.Diagnostics;
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

            //Debug.WriteLine(Environment.CurrentDirectory);
            //Debug.WriteLine(Environment.SpecialFolder.ApplicationData);
            //Debug.WriteLine(Environment.SpecialFolder.CommonApplicationData);
            //Debug.WriteLine(Environment.SpecialFolder.Resources);


            Measure.DataModel.DatabaseTools.SetUpDatabase();



            var fileName = Path.Combine(Environment.CurrentDirectory, "MyDatabase.sqlite");

            if (System.IO.File.Exists(fileName))
            {

            }
            else
            {
                System.IO.File.Create(fileName);
                Measure.DataModel.DatabaseTools.SetUpDatabase();
            }
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

       
    }
}
