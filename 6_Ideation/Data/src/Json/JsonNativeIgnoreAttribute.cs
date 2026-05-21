

using System;

namespace Alis.Core.Aspect.Data.Json
{
    /// <summary>
    ///     Specifies that a property should be ignored during JSON serialization and deserialization.
    ///     When applied to a property, the JSON serializer and deserializer will skip that property entirely,
    ///     excluding it from the generated JSON output and ignoring it when reading JSON input.
    /// </summary>
    /// <remarks>
    ///     This attribute is only valid on properties. It is used in conjunction with the
    ///     <see cref="IJsonSerializable" /> and <see cref="IJsonDesSerializable{T}" /> interfaces
    ///     to control which properties participate in JSON conversion. Properties marked with this
    ///     attribute will not be included in serialized output and will not be populated during deserialization.
    /// </remarks>
    /// <seealso cref="Attribute" />
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class JsonNativeIgnoreAttribute : Attribute
    {
    }
}
