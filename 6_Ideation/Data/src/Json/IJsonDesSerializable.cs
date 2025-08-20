using System.Collections.Generic;

namespace Alis.Core.Aspect.Data.Json
{
    /// <summary>
    /// The json des serializable interface
    /// </summary>
    public interface IJsonDesSerializable<out T>
    {
        /// <summary>
        /// Creates the from properties using the specified properties
        /// </summary>
        /// <param name="properties">The properties</param>
        /// <returns>The</returns>
        T CreateFromProperties(Dictionary<string, string> properties);
    }
}