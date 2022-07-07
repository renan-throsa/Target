using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Target.Business.Contract;
using Target.Business.Implementation;
using Target.Business.Implementation.Validations;
using Target.Repositories.Contract;
using Target.Repositories.Implementation.Context;
using Target.Repositories.Implementation.Repositories;

namespace DependencyInjection
{
    public static class Container
    {
        public static IServiceCollection AddWebApiConfig(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });
            return services;
        }

        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Development"));
            });

            services.AddSingleton<ProductValidation>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductBusinness, ProductBusiness>();

            return services;
        }
    }
}
