namespace Swashbuckle.AspNetCore.Swagger.Yaml
{
    public class SwaggerYamlOptions
    {
        public SwaggerOptions SwaggerOptions { get; set; } = new SwaggerOptions {  RouteTemplate = "swagger/{documentName}/swagger.yaml" };

        public string[] IgnoredProperties { get; set; } = {"extensions", "operation-id"};
    }
}
