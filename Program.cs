using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using log4net;
using log4net.Appender;
using log4net.Repository.Hierarchy;

namespace TestLogging
{
    internal class Program
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static void Main(string[] args)
        {
            //get file name of appender from log4net config in App.config
            var rootAppender = ((Hierarchy)LogManager.GetRepository())
                .Root.Appenders.OfType<FileAppender>()
                .FirstOrDefault();

            //assign the above found appender name to filename if it is not null
            string filename = rootAppender != null ? rootAppender.File : string.Empty;

            Logger.InfoFormat("Running as {0}", WindowsIdentity.GetCurrent().Name);
            Logger.Error("Error Written to file");
            Logger.Info("Info Written to file");
            Logger.Debug("Debug Written to file");
            Logger.Fatal("Fatal Written to file");
            Logger.Warn("Warn Written to file");
            //print out User and File name that logs are printed to
            Console.WriteLine("Running as {0} to file {1}", WindowsIdentity.GetCurrent().Name, filename);
            Console.WriteLine("Check Log file for output.");
            Console.ReadKey();
        }
    }
}
