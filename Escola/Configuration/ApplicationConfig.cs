using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace Escola.Configuration
{
    [ExcludeFromCodeCoverage]
    public static class ApplicationConfig
    {
        public static void ApplicationRegister(this IServiceCollection services)
        {
            services.AddControllersWithViews().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });
        }

    }
}
