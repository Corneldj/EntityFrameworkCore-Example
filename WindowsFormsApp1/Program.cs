using EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        static string connecitonstring = "MyConnectionstring";
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var builder = new HostBuilder()
             .ConfigureServices((hostContext, services) =>
             {
                 services.AddSingleton<Main>();
                 services.AddLogging(configure => configure.AddConsole());

                 // Register the
                 services.RegisterContextInjection(options => options.UseSqlServer(

                         // This is simply the connection stirng
                         connecitonstring,

                        // We add a migration assembly only if the EF core DbContext is in another project
                        actions => actions.MigrationsAssembly("My.Other.Project.Assembly")
                    ));

                 // Register the repositories
                 services.RegisterRepositoryInjections();
             });

            var host = builder.Build();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var serviceScope = host.Services.CreateScope())
            {
                try
                {
                    
                    var main = serviceScope.ServiceProvider.GetRequiredService<Main>();

                    
                    Application.Run(main);
                } catch(Exception e)
                {
                    Console.WriteLine("Error has occured: " + e.Message);
                }
            }
        }
    }
}
