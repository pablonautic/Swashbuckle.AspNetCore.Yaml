using Swashbuckle.AspNetCore.Yaml.Application;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Swashbuckle.AspNetCore.Swagger.Yaml
{
    public class SwaggerYamlSerializerFactory
    {
        public static Serializer Create(SwaggerYamlOptions swaggerYamlOptions)
        {
            var builder = new SerializerBuilder();
            builder.WithNamingConvention(new HyphenatedNamingConvention());
            builder.WithTypeInspector(innerInspector => new PropertiesIgnoreTypeInspector(innerInspector, swaggerYamlOptions.IgnoredProperties));
            builder.WithTypeInspector(innerInspector => new JsonPropertyNameApplyingTypeInspector(innerInspector));
            builder.WithTypeInspector(innerInspector => new StringQuotingTypeInspector(innerInspector));
            return builder.Build();
        }
    }
}
