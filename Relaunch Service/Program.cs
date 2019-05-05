using Serilog;
using System;
using System.Configuration;
using System.Timers;

namespace Relaunch_Service
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("relaunch-service.log")
                .CreateLogger();

            Console.WriteLine("Sistema iniciado");
            Log.Information("Sistema iniciado");

            // Create a timer
            var myTimer = new Timer();
            // Tell the timer what to do when it elapses
            myTimer.Elapsed += new ElapsedEventHandler(myEvent);
            // Set it to go off every five seconds
            myTimer.Interval = Convert.ToDouble(ConfigurationManager.AppSettings["SERVICE_LAUNCH_TIMEGAP"]);
            // And start it        
            myTimer.Enabled = true;

        }

        // Implement a call with the right signature for events going off
        private static void myEvent(object source, ElapsedEventArgs e)
        {

        }
    }
}
