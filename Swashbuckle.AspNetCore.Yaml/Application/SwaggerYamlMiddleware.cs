using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Template;
using YamlDotNet.Serialization;

namespace Swashbuckle.AspNetCore.Swagger.Yaml
{
    public class SwaggerYamlMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ISwaggerProvider _swaggerProvider;
        private readonly Serializer _swaggerSerializer;
        private readonly SwaggerYamlOptions _options;
        private readonly TemplateMatcher _requestMatcher;

        public SwaggerYamlMiddleware(
            RequestDelegate next,
            ISwaggerProvider swaggerProvider,
            SwaggerYamlOptions options)
        {
            _next = next;
            _swaggerProvider = swaggerProvider;
            _swaggerSerializer = SwaggerYamlSerializerFactory.Create(options);
            _options = options;
            _requestMatcher = new TemplateMatcher(TemplateParser.Parse(_options.SwaggerOptions.RouteTemplate), new RouteValueDictionary());
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (!RequestingSwaggerDocument(httpContext.Request, out string documentName))
            {
                await _next(httpContext);
                return;
            }

            var basePath = string.IsNullOrEmpty(httpContext.Request.PathBase)
                ? null
                : httpContext.Request.PathBase.ToString();

            var swagger = _swaggerProvider.GetSwagger(documentName, null, basePath);

            // One last opportunity to modify the Swagger Document - this time with request context
            foreach (var filter in _options.SwaggerOptions.PreSerializeFilters)
            {
                filter(swagger, httpContext.Request);
            }

            await RespondWithSwaggerYaml(httpContext.Response, swagger);
        }

        private bool RequestingSwaggerDocument(HttpRequest request, out string documentName)
        {
            documentName = null;
            if (request.Method != "GET") return false;

            var routeValues = new RouteValueDictionary();
            if (!_requestMatcher.TryMatch(request.Path, routeValues) || !routeValues.ContainsKey("documentName")) return false;

            documentName = routeValues["documentName"].ToString();
            return true;
        }

        private async Task RespondWithSwaggerYaml(HttpResponse response, SwaggerDocument swagger)
        {
            response.StatusCode = 200;
            response.ContentType = "text/yaml;charset=utf-8";

            var jsonBuilder = new StringBuilder();
            using (var writer = new StringWriter(jsonBuilder))
            {
                _swaggerSerializer.Serialize(writer, swagger);
                await response.WriteAsync(jsonBuilder.ToString(), new UTF8Encoding(false));
            }
        }

    }
}