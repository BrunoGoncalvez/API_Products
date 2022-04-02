using Microsoft.Extensions.DependencyInjection;
using Ploomes.Business.Interfaces;
using Ploomes.Business.Notifications;
using Ploomes.Business.Services;
using Ploomes.Data.Context;
using Ploomes.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ploomes.API.Configuration
{
    public static class DependencyInjectionConfig
    {

        public static IServiceCollection ResolveDependecies(this IServiceCollection services)
        {
            services.AddScoped<DataDbContext>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProviderRepository, ProviderRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();

            services.AddScoped<IProviderService, ProviderService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<INotifier, Notifier>();

            return services;
        }

    }
}
