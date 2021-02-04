using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SecurityLab1_Starter
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        
        protected void Application_Error(object sender, EventArgs e)
        {
            var ex = Server.GetLastError();

            if (ex is HttpException && ((HttpException)ex).GetHttpCode() == 500)
            {
                Response.Redirect("~/Error/ServerError");

                using (EventLog eventLog = new EventLog("Application"))
                {
                    eventLog.Source = "Application";
                    eventLog.WriteEntry(ex.ToString(), EventLogEntryType.Information, 101, 1);
                }

                using (StreamWriter w = File.AppendText(HttpRuntime.AppDomainAppPath + "/log.txt"))
                {
                    Log(ex.ToString(), w);
                }
                using (StreamReader r = File.OpenText(HttpRuntime.AppDomainAppPath + "/log.txt"))
                {
                    DumpLog(r);
                }
            }
            // To read
            //var appSettings = ConfigurationManager.AppSettings;
            //string filepath = appSettings["Setting1"] ?? "Not Found";
        }
        
        private static void Log(string logMessage, TextWriter w)
        {
            w.WriteLine("\r\nLogEntry : ");
            w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
            w.WriteLine(" :");
            w.WriteLine($" :{logMessage}");
            w.WriteLine("-------------------------------");
        }

        private static void DumpLog(StreamReader r)
        {
            string line;
            while ((line = r.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
    }
}
