using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using log4net;

namespace TestLogging
{
    class Program
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static void Main(string[] args)
        {
            Logger.InfoFormat("Running as {0}", WindowsIdentity.GetCurrent().Name);
            Logger.Error("Error Written to file");
            Logger.Info("Info Written to file");
            Logger.Debug("Debug Written to file");
            Logger.Fatal("Fatal Written to file");
            Logger.Warn("Warn Written to file");
            Console.WriteLine("Running as {0}", WindowsIdentity.GetCurrent().Name);
            Console.WriteLine("Check Log file.");
            Console.ReadKey();
        }
    }
}
