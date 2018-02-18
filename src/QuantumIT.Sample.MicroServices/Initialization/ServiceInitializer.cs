using System.Data;
using log4net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using QuantumIT.Sample.Microservices.DataAccess;
using QuantumIT.Sample.Microservices.DataAccess.Repositories;
using QuantumIT.Sample.Microservices.DataAccess.RulesEngine;
using QuantumIT.Sample.Microservices.Interface.DataAccess;
using QuantumIT.Sample.Microservices.Interface.ORM;
using QuantumIT.Sample.Microservices.Interface.Service;
using QuantumIT.Sample.Microservices.ORM;
using QuantumIT.Sample.Microservices.ORM.Model;
using QuantumIT.Sample.Microservices.Services.Services;
using QuantumIT.Sample.MicroServices.Middleware;

namespace QuantumIT.Sample.MicroServices.Initialization
{
    public class ServiceInitializer
    {
        public void RegisterServices(IMvcBuilder mvcBuilder, IServiceCollection services, IConfigurationRoot Configuration)
        {
            //Inject AOP logger             
            services.AddScoped<ILog>(lg => LogManager.GetLogger(this.GetType()));

            //Injecting DB Connection,Drapper,UnitOfWork
            services.AddScoped<IDbConnection>(c => new MySqlConnection(
                    Configuration.GetSection("configuration:connectionStrings:1:connectionString").Value));
            services.AddScoped<IDapperWrapper, DapperWrapper>();
            services.AddScoped<IDBProvider, DBProvider>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IDBHelper, DBHelper>();

            //Injecting Business rules
            services.AddScoped(typeof(IRulesEngine<>), typeof(BaseRulesEngine<>));

            //Repository
            services.AddScoped<ICompanyRepository<Company>, CompanyRepository>();

            //Services
            services.AddScoped<ICompanyService, CompanyService>();

        }
    }
}
