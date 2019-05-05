using Serilog;
using System;
using System.Configuration;
using System.Linq;
using System.ServiceProcess;
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

            processServices();
        }

        private static void processServices()
        {
            Log.Information("Obteniendo lista de servicios");

            var services = ConfigurationManager.AppSettings["SERVICE_LIST"].Split(";").ToList();

            Log.Information($"{services.Count} servicios a validar");

            foreach(var service in services)
            {
                try
                {
                    var serviceController = new ServiceController(service, ".");

                    if (serviceController.Status == ServiceControllerStatus.Stopped)
                    {
                        serviceController.Start();

                        serviceController.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromMilliseconds(Convert.ToDouble(ConfigurationManager.AppSettings["SERVICE_LAUNCH_TIMEOUT"])));

                        serviceController.Refresh();

                        Log.Information($"Servicio {service} iniciado");
                    }

                }
                catch(Exception ex)
                {
                    Log.Error(ex, $"Búsqueda y/o ejecución de {service}");
                }
            }
        }
    }
}
