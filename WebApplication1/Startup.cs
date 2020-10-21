using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebApplication1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add the controllers
            services.AddControllers();

            // Register the SQL Context datacontext
            services.RegisterContextInjection(options => options.UseSqlServer(

                // This is simply the connection stirng
                Configuration.GetConnectionString("SqlConnection"),

                // We add a migration assembly only if the EF core DbContext is in another project
                actions => actions.MigrationsAssembly("My.Other.Project.Assembly")
            ));

            // Register the SQL Context repository injections 
            services.RegisterRepositoryInjections();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
