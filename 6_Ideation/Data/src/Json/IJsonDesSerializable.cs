

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Alis.Core.Aspect.Data.Json
{
    /// <summary>
    ///     Defines a contract for objects that can reconstruct themselves from a flat dictionary
    ///     of JSON property names and their string values during deserialization.
    /// </summary>
    /// <typeparam name="T">The concrete type that will be instantiated and populated from the property dictionary.</typeparam>
    /// <remarks>
    ///     Types implementing this interface can reconstruct themselves from a property dictionary
    ///     created by the JSON parser. This is the deserialization counterpart to <see cref="IJsonSerializable" />.
    ///     <para>
    ///     Usage Pattern:
    ///     Classes should implement this interface to support JSON deserialization through the
    ///     <see cref="JsonNativeAot.Deserialize{T}" /> method. For complete bidirectional support,
    ///     also implement <see cref="IJsonSerializable" />.
    ///     </para>
    ///     <para>
    ///     The class must have a parameterless constructor as required by the generic constraint
    ///     on the deserializer methods.
    ///     </para>
    ///     Implementation Guide:
    ///     - Use <see cref="CreateFromProperties" /> to create a new instance and populate its properties
    ///     - The dictionary keys are property names exactly as they appear in the JSON
    ///     - Complex nested values are delivered as raw JSON strings and may require secondary parsing
    ///     - Handle missing or null dictionary entries gracefully by using default values
    /// </remarks>
    public interface IJsonDesSerializable<out T>
    {
        /// <summary>
        ///     Creates and returns a fully initialized instance of type <typeparamref name="T" />,
        ///     populating its properties from the provided dictionary of key-value string pairs.
        /// </summary>
        /// <param name="properties">
        ///     A dictionary mapping property names (JSON keys) to their string values.
        ///     Primitive values are stored as plain strings; nested objects and arrays are stored as
        ///     raw JSON substrings. Must not be null.
        /// </param>
        /// <returns>A new instance of <typeparamref name="T" /> with properties populated from the dictionary.</returns>
        /// <exception cref="System.ArgumentException">
        ///     Thrown when the property dictionary contains invalid or unexpected keys,
        ///     or when a value cannot be converted to the expected target type.
        /// </exception>
        [ExcludeFromCodeCoverage]
        T CreateFromProperties(Dictionary<string, string> properties);
    }
}