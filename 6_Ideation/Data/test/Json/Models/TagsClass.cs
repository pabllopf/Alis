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
        public string Name { get; set; }
        public List<string> Tags { get; set; }

        public TagsClass()
        {
            Tags = new List<string>();
        }

        public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
        {
            yield return (nameof(Name), Name);
            var tagsJson = "[" + string.Join(",", Tags.Select(t => $"\"{t}\"")) + "]";
            yield return (nameof(Tags), tagsJson);
        }

        public TagsClass CreateFromProperties(Dictionary<string, string> properties)
        {
            var obj = new TagsClass();
            if (properties.TryGetValue(nameof(Name), out var name)) obj.Name = name;
            if (properties.TryGetValue(nameof(Tags), out var tagsJson))
            {
                var items = tagsJson.Trim('[', ']').Split(',');
                foreach (var item in items)
                {
                    var tag = item.Trim().Trim('"');
                    if (!string.IsNullOrEmpty(tag))
                        obj.Tags.Add(tag);
                }
            }
            return obj;
        }
    }
}