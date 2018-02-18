using System.IO;
using AutoMapper;
using log4net;
using log4net.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using QuantumIT.Sample.MicroServices.Initialization;

namespace QuantumIT.Sample.MicroServices
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
            var mvcBuilder = services.AddMvc();
            services.AddAutoMapper();
            new ServiceInitializer().RegisterServices(mvcBuilder, services,(IConfigurationRoot)Configuration);
            SwaggerInitializer.RegisterSwagger(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var logRepository = LogManager.GetRepository(System.Reflection.Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
            //app.UseLoggingMiddleware();
            app.UseSwagger();

            app.UseSwaggerUI(c=> {
                c.RoutePrefix = "swagger/ui";
                c.SwaggerEndpoint(Configuration["Swagger:JSONLocation"], "swagger/ui");
            });
            app.UseMvc();
        }
    }
}
