using System;
using DoItLess.AspNetCore.Extentions;
using Microsoft.Extensions.Hosting;

namespace DoItLess.AspNetCore.Kit
{
    public static class Extensions
    {
        public static IHostBuilder UseSwagger(this IHostBuilder hostBuilder, Action<SwaggerOptions> options)
        {
            var swaggerOptions = new SwaggerOptions();
            options.Invoke(swaggerOptions);

            

            return hostBuilder;
        }
    }
}
