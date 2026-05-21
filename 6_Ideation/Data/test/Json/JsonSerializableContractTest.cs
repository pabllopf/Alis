

using System.Collections.Generic;
using System.Linq;
using Alis.Core.Aspect.Data.Json;
using Xunit;

namespace Alis.Core.Aspect.Data.Test.Json
{
    /// <summary>
    ///     Tests the serialization and deserialization contract interfaces.
    /// </summary>
    public class JsonSerializableContractTest
    {
        /// <summary>
        ///     Tests that serializable properties are emitted in expected order and values.
        /// </summary>
        [Fact]
        public void GetSerializableProperties_ReturnsExpectedPairs()
        {
            DemoJsonModel model = new DemoJsonModel
            {
                Name = "PlayerOne",
                Score = 1250
            };

            (string PropertyName, string Value)[] properties = model.GetSerializableProperties().ToArray();

            Assert.Equal(2, properties.Length);
            Assert.Equal(("Name", "PlayerOne"), properties[0]);
            Assert.Equal(("Score", "1250"), properties[1]);
        }

        /// <summary>
        ///     Tests that a model can be created from a dictionary using deserialization contract.
        /// </summary>
        [Fact]
        public void CreateFromProperties_BuildsModelFromDictionary()
        {
            DemoJsonModel source = new DemoJsonModel();
            Dictionary<string, string> properties = new Dictionary<string, string>
            {
                ["Name"] = "PlayerTwo",
                ["Score"] = "42"
            };

            DemoJsonModel created = source.CreateFromProperties(properties);

            Assert.Equal("PlayerTwo", created.Name);
            Assert.Equal(42, created.Score);
        }

        /// <summary>
        ///     Demo model implementing both serialization contracts.
        /// </summary>
        private sealed class DemoJsonModel : IJsonSerializable, IJsonDesSerializable<DemoJsonModel>
        {
            /// <summary>
            ///     Gets or sets the player name.
            /// </summary>
            public string Name { get; set; } = string.Empty;

            /// <summary>
            ///     Gets or sets the player score.
            /// </summary>
            public int Score { get; set; }

            /// <summary>
            ///     Gets serializable properties.
            /// </summary>
            /// <returns>The serializable property pairs.</returns>
            public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
            {
                yield return ("Name", Name);
                yield return ("Score", Score.ToString());
            }

            /// <summary>
            ///     Creates a model from property dictionary.
            /// </summary>
            /// <param name="properties">The serialized properties.</param>
            /// <returns>The created model.</returns>
            public DemoJsonModel CreateFromProperties(Dictionary<string, string> properties)
            {
                return new DemoJsonModel
                {
                    Name = properties["Name"],
                    Score = int.Parse(properties["Score"])
                };
            }
        }
    }
}
