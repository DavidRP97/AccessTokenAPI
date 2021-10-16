using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WidgetSnippet.GetAccessToken;
using WidgetSnippet.GetAccessToken.Interfaces;

namespace WidgetSnippet.DependecyInjection
{
    public static class ConfigDependencyInjection
    {
        public static void ConfigInjection(this IServiceCollection services)
        {
            services.AddTransient<IGetToken, GetToken>();
            
        }
    }
    
}
