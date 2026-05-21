

using System;

namespace Alis.Core.Aspect.Data.Json
{
    /// <summary>
    ///     Specifies the JSON property name to be used when serializing or deserializing a
    ///     property of a class. When applied, the JSON serializer and deserializer will use
    ///     the provided name instead of the actual property name, enabling mapping between
    ///     C# property names and different JSON key names.
    /// </summary>
    /// <remarks>
    ///     This attribute is only valid on properties. It is useful when the JSON key name
    ///     differs from the C# property name (e.g., due to naming conventions or external
    ///     API requirements). The specified name is used by both serialization
    ///     (<see cref="IJsonSerializable" />) and deserialization
    ///     (<see cref="IJsonDesSerializable{T}" />) processes.
    /// </remarks>
    /// <seealso cref="Attribute" />
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class JsonNativePropertyNameAttribute : Attribute
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="JsonNativePropertyNameAttribute" /> class
        ///     with the specified JSON property name.
        /// </summary>
        /// <param name="name">The JSON key name to use for the decorated property. Must not be null or empty.</param>
        public JsonNativePropertyNameAttribute(string name) => Name = name;

        /// <summary>
        ///     Gets the custom JSON property name that will replace the original C# property name
        ///     during serialization and deserialization.
        /// </summary>
        /// <value>The JSON key name used for the decorated property in serialization and deserialization.</value>
        public string Name { get; }
    }
}