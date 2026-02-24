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
            string scoresJson = "[" + string.Join(",", Scores) + "]";
            yield return (nameof(Scores), scoresJson);
        }

        public ScoresClass CreateFromProperties(Dictionary<string, string> properties)
        {
            ScoresClass obj = new ScoresClass();
            if (properties.TryGetValue(nameof(PlayerName), out string name)) obj.PlayerName = name;
            if (properties.TryGetValue(nameof(Scores), out string scoresJson))
            {
                string[] items = scoresJson.Trim('[', ']').Split(',');
                foreach (string item in items)
                {
                    if (int.TryParse(item.Trim(), out int score))
                        obj.Scores.Add(score);
                }
            }
            return obj;
        }
    }
}