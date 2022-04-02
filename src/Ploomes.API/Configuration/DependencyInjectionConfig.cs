using Microsoft.Extensions.DependencyInjection;
using Ploomes.Business.Interfaces;
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
            services.AddScoped<IProviderRepository, ProviderRepository>();
            services.AddScoped<IProviderService, ProviderService>();

            return services;
        }

    }
}
