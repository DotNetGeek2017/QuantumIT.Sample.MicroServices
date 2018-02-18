using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace QuantumIT.Sample.MicroServices.Initialization
{
    public static class SwaggerInitializer
    {
        /// <summary>
        /// To register swagger implementation
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterSwagger(
        this IServiceCollection services)
        {
            services.AddSwaggerGen(c => {
                c.DescribeAllEnumsAsStrings();
                c.SwaggerDoc("v1",new Info
                {
                    Version = "v1",
                    Title = "Demo - Microservices",
                    Description = "Microservices for Demo Module",
                    TermsOfService = "None"
                });
            });
            return services;
        }
    }
}
