

using System.Collections.Generic;

namespace Alis.Core.Aspect.Data.Json.Parsing
{
    /// <summary>
    ///     Defines a contract for parsing JSON strings into flat dictionaries of key-value string pairs.
    ///     Implementing types provide the logic to traverse a JSON object structure and extract each
    ///     property as a string-based key-value entry, handling nested objects and arrays as raw JSON.
    /// </summary>
    /// <remarks>
    ///     Implementations of this interface are used as the low-level parsing engine by the
    ///     <see cref="JsonNativeAot" /> facade and the <see cref="JsonDeserializer" /> class.
    ///     The parser is expected to handle quoted strings, escape sequences, nested objects/arrays,
    ///     and primitive values (numbers, booleans, null).
    /// </remarks>
    public interface IJsonParser
    {
        /// <summary>
        ///     Parses a JSON string into a dictionary of property names and their string values.
        ///     Complex nested values (objects and arrays) are returned as raw JSON substrings.
        /// </summary>
        /// <param name="json">The JSON string to parse. Must not be null. Expected to contain a JSON object (surrounded by curly braces).</param>
        /// <returns>
        ///     A dictionary where each key is a property name from the JSON object and the corresponding
        ///     value is its string representation. Primitive values are stored as-is; nested objects and
        ///     arrays are stored as raw JSON substrings.
        ///     Returns an empty dictionary for empty, whitespace-only, or empty-object JSON strings.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="json" /> is null.</exception>
        Dictionary<string, string> ParseToDictionary(string json);
    }
}