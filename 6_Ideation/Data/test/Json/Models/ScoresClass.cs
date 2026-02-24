using System.Collections.Generic;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Core.Aspect.Data.Test.Json.Models
{
    /// <summary>
    ///     Class with list of integers
    /// </summary>
    public class ScoresClass : IJsonSerializable, IJsonDesSerializable<ScoresClass>
    {
        /// <summary>
        /// Gets or sets the value of the player name
        /// </summary>
        public string PlayerName { get; set; }
        /// <summary>
        /// Gets or sets the value of the scores
        /// </summary>
        public List<int> Scores { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScoresClass"/> class
        /// </summary>
        public ScoresClass()
        {
            Scores = new List<int>();
        }

        /// <summary>
        /// Gets the serializable properties
        /// </summary>
        /// <returns>An enumerable of string property name and string value</returns>
        public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
        {
            yield return (nameof(PlayerName), PlayerName);
            string scoresJson = "[" + string.Join(",", Scores) + "]";
            yield return (nameof(Scores), scoresJson);
        }

        /// <summary>
        /// Creates the from properties using the specified properties
        /// </summary>
        /// <param name="properties">The properties</param>
        /// <returns>The obj</returns>
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