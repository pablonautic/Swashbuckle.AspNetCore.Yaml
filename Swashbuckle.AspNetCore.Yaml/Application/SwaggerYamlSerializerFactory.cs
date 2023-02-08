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

            switch (swaggerYamlOptions.NamingConvention)
            {
                case NamingConvention.CamelCase:
                    builder.WithNamingConvention(new CamelCaseNamingConvention());
                    break;

                case NamingConvention.Hyphenated:
                    builder.WithNamingConvention(new HyphenatedNamingConvention());
                    break;

                case NamingConvention.PascalCase:
                    builder.WithNamingConvention(new PascalCaseNamingConvention());
                    break;

                case NamingConvention.Underscored:
                    builder.WithNamingConvention(new UnderscoredNamingConvention());
                    break;
            }

            builder.WithTypeInspector(innerInspector => new PropertiesIgnoreTypeInspector(innerInspector, swaggerYamlOptions.IgnoredProperties));
            builder.WithTypeInspector(innerInspector => new JsonPropertyNameApplyingTypeInspector(innerInspector));
            builder.WithTypeInspector(innerInspector => new StringQuotingTypeInspector(innerInspector));

            return builder.Build();
        }
    }
}