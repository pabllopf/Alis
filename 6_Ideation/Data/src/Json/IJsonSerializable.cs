using System.Collections.Generic;

namespace Alis.Core.Aspect.Data.Json
{
    /// <summary>
    /// The json serializable interface
    /// </summary>
    public interface IJsonSerializable
    {
        /// <summary>
        /// Gets the serializable properties
        /// </summary>
        /// <returns>An enumerable of string property name and string value</returns>
        IEnumerable<(string PropertyName, string Value)> GetSerializableProperties();
    }
}