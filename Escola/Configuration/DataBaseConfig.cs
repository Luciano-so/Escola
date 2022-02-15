using Escola.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Escola.Api.Configuration
{
    public static class DataBaseConfig
    {
        public static void DataBaseRegister(this IServiceCollection services, IConfiguration configuration)
        {
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            IWebHostEnvironment env = serviceProvider.GetService<IWebHostEnvironment>();
            services.AddDbContext<EscolaContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        }

        public static void DataBaseRegister(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            var IdentityContext = serviceScope.ServiceProvider.GetRequiredService<EscolaContext>();
            IdentityContext.Database.Migrate();
        }
    }
}
