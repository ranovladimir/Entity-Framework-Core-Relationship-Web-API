using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Routing;
using AutoMapper;

using Microsoft.EntityFrameworkCore;
using TouchCloudBackEnd.Entities;
using TouchCloudBackEnd.Services.Administrations;

namespace TouchCloudBackEnd
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
            {

            var builder = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                    .AddEnvironmentVariables();
                Configuration = builder.Build();
            }

            public IConfigurationRoot Configuration { get; }
            public void ConfigureServices(IServiceCollection services)
            {
                // Add framework services.
                services.AddMvc();


            //connexion BDD
            var connection = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = TouchcloudDatabase; Integrated Security = True;";
                services.AddDbContext<TouchcloudDbContext>(options => options.UseSqlServer(connection));
                services.AddSingleton<IUserService, UserService>();

            services.AddLogging();

            }

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
            {
                loggerFactory.AddConsole(Configuration.GetSection("Logging"));
                loggerFactory.AddDebug();

            app.UseMvc(ConfigureRoutes);
            }

            private void ConfigureRoutes(IRouteBuilder routeBuilder)
            {
               
                routeBuilder.MapRoute("Default",
                    "v1/api/{controller=User}/{action=Index}/{id?}");
            }
        }
    
}
