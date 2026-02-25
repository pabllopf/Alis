using System.Collections.Generic;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Core.Aspect.Data.Test.Json.Models
{
    /// <summary>
    ///     Class with list of integers
    /// </summary>
    public class ScoresClass : IJsonSerializable, IJsonDesSerializable<ScoresClass>
    {
        public string PlayerName { get; set; }
        public List<int> Scores { get; set; }

        public ScoresClass()
        {
            Scores = new List<int>();
        }

        public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
        {
            yield return (nameof(PlayerName), PlayerName);
            var scoresJson = "[" + string.Join(",", Scores) + "]";
            yield return (nameof(Scores), scoresJson);
        }

        public ScoresClass CreateFromProperties(Dictionary<string, string> properties)
        {
            var obj = new ScoresClass();
            if (properties.TryGetValue(nameof(PlayerName), out var name)) obj.PlayerName = name;
            if (properties.TryGetValue(nameof(Scores), out var scoresJson))
            {
                var items = scoresJson.Trim('[', ']').Split(',');
                foreach (var item in items)
                {
                    if (int.TryParse(item.Trim(), out var score))
                        obj.Scores.Add(score);
                }
            }
            return obj;
        }
    }
}