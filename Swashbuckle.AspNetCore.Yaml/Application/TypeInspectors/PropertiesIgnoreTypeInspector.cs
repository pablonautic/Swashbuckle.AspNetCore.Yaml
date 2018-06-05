using System;
using System.Collections.Generic;
using System.Linq;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.TypeInspectors;

namespace Swashbuckle.AspNetCore.Swagger.Yaml
{
    public class PropertiesIgnoreTypeInspector : TypeInspectorSkeleton
    {
        private readonly ITypeInspector _typeInspector;
        private readonly string[] _ignoredProperties;

        public PropertiesIgnoreTypeInspector(ITypeInspector typeInspector, string[] ignoredProperties)
        {
            _typeInspector = typeInspector ?? throw new ArgumentNullException(nameof(typeInspector));
            _ignoredProperties = ignoredProperties ?? throw new ArgumentNullException(nameof(ignoredProperties));
        }

        public override IEnumerable<IPropertyDescriptor> GetProperties(Type type, object container)
        {
            return _typeInspector.GetProperties(type, container).Where(p => !_ignoredProperties.Contains(p.Name));
        }
    }
}