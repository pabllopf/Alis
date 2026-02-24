using System.Collections.Generic;
using System.Linq;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Core.Aspect.Data.Test.Json.Models
{
    /// <summary>
    ///     Class with list of strings
    /// </summary>
    public class TagsClass : IJsonSerializable, IJsonDesSerializable<TagsClass>
    {
        /// <summary>
        /// Gets or sets the value of the name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the value of the tags
        /// </summary>
        public List<string> Tags { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TagsClass"/> class
        /// </summary>
        public TagsClass()
        {
            Tags = new List<string>();
        }

        /// <summary>
        /// Gets the serializable properties
        /// </summary>
        /// <returns>An enumerable of string property name and string value</returns>
        public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
        {
            yield return (nameof(Name), Name);
            string tagsJson = "[" + string.Join(",", Tags.Select(t => $"\"{t}\"")) + "]";
            yield return (nameof(Tags), tagsJson);
        }

        /// <summary>
        /// Creates the from properties using the specified properties
        /// </summary>
        /// <param name="properties">The properties</param>
        /// <returns>The obj</returns>
        public TagsClass CreateFromProperties(Dictionary<string, string> properties)
        {
            TagsClass obj = new TagsClass();
            if (properties.TryGetValue(nameof(Name), out string name)) obj.Name = name;
            if (properties.TryGetValue(nameof(Tags), out string tagsJson))
            {
                string[] items = tagsJson.Trim('[', ']').Split(',');
                foreach (string item in items)
                {
                    string tag = item.Trim().Trim('"');
                    if (!string.IsNullOrEmpty(tag))
                        obj.Tags.Add(tag);
                }
            }
            return obj;
        }
    }
}