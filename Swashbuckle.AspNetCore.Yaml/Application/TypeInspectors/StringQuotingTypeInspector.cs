using System;
using System.Collections.Generic;
using System.Linq;
using YamlDotNet.Core;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.TypeInspectors;

namespace Swashbuckle.AspNetCore.Swagger.Yaml
{
    public class StringQuotingTypeInspector : TypeInspectorSkeleton
    {
        private readonly ITypeInspector _typeInspector;

        public StringQuotingTypeInspector(ITypeInspector typeInspector)
        {
            _typeInspector = typeInspector ?? throw new ArgumentNullException(nameof(typeInspector));
        }

        public override IEnumerable<IPropertyDescriptor> GetProperties(Type type, object container)
        {
            return _typeInspector.GetProperties(type, container).Select(p =>
            {
                if (type == typeof(SwaggerDocument) && p.Name == "swagger")
                {
                    p.ScalarStyle = ScalarStyle.SingleQuoted;
                }
                return p;
            });
        }
    }
}