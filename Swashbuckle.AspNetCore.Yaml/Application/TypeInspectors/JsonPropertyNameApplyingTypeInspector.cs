using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.TypeInspectors;

namespace Swashbuckle.AspNetCore.Yaml.Application
{
    /// <summary>
    /// Searches for usage of the <see cref="JsonPropertyAttribute" /> and applies any necessary property naming changes e.g. ref => $ref
    /// </summary>
    public sealed class JsonPropertyNameApplyingTypeInspector : TypeInspectorSkeleton
    {
        private readonly ITypeInspector _innerTypeDescriptor;

        public JsonPropertyNameApplyingTypeInspector(ITypeInspector innerTypeDescriptor)
        {
            _innerTypeDescriptor = innerTypeDescriptor ?? throw new ArgumentNullException(nameof(innerTypeDescriptor));
        }

        public override IEnumerable<IPropertyDescriptor> GetProperties(Type type, object container)
        {
            return _innerTypeDescriptor.GetProperties(type, container).Select((p =>
            {
                var customAttribute = p.GetCustomAttribute<JsonPropertyAttribute>();
                if (customAttribute == null)
                {
                    return p;
                }

                return new PropertyDescriptor(p)
                {
                    Name = customAttribute.PropertyName,
                };
            }));
        }
    }
}
