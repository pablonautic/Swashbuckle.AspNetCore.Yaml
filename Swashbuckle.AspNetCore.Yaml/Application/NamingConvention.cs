using YamlDotNet.Serialization.NamingConventions;

namespace Swashbuckle.AspNetCore.Yaml.Application
{
    /// <summary>
    /// Kind of string naming transformation
    /// </summary>
    public enum NamingConvention
    {
        /// <summary>
        /// Performs no naming conversion.
        /// </summary>
        /// <seealso cref="NullNamingConvention"/>
        Null,

        /// <summary>
        /// Convert the string with underscores or hyphens to camel case.
        /// </summary>
        /// <seealso cref="CamelCaseNamingConvention"/>
        CamelCase,

        /// <summary>
        /// Convert the string with underscores.
        /// </summary>
        /// <seealso cref="HyphenatedNamingConvention"/>
        Hyphenated,

        /// <summary>
        /// Convert the string with underscores or hyphens to pascal case.
        /// </summary>
        /// <seealso cref="PascalCaseNamingConvention"/>
        PascalCase,

        /// <summary>
        /// Convert the string from camelcase to a underscored.
        /// </summary>
        /// <seealso cref="UnderscoredNamingConvention"/>
        Underscored
    }
}