using System;
using Swashbuckle.AspNetCore.Swagger.Yaml;

namespace Microsoft.AspNetCore.Builder
{
    public static class SwaggerYamlBuilderExtensions
    {
        public static IApplicationBuilder UseSwaggerYaml(
            this IApplicationBuilder app,
            Action<SwaggerYamlOptions> setupAction = null)
        {
            var options = new SwaggerYamlOptions();
            setupAction?.Invoke(options);

            return app.UseMiddleware<SwaggerYamlMiddleware>(options);
        }
    }
}