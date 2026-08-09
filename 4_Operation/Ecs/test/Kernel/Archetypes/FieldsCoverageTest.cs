using Alis.Core.Ecs.Kernel.Archetypes;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel.Archetypes
{
    /// <summary>
    /// The fields coverage test class
    /// </summary>
    public class FieldsCoverageTest
    {
        /// <summary>
        /// Tests that archetype data property returns fields
        /// </summary>
        [Fact] public void Archetype_DataProperty_ReturnsFields()
        {
            using Scene scene = new();
            Archetype archetype = scene.DefaultArchetype;
            Fields data = archetype.Data;
            Assert.NotNull(data.Map);
            Assert.NotNull(data.Components);
        }

        /// <summary>
        /// Tests that GetComponentDataReference on Fields from the correct archetype
        /// successfully invokes GetComponentStorageDataReference, covering all code paths.
        /// </summary>
        [Fact] public void GetComponentDataReference_OnProperArchetype_CoversAllLines()
        {
            using Scene scene = new();
            scene.Create(new Alis.Core.Ecs.Test.Models.Position { X = 42, Y = 84 });

            WorldArchetypeTableItem worldItem = Archetype<Alis.Core.Ecs.Test.Models.Position>.CreateNewOrGetExistingArchetypes(scene);
            Archetype arch = worldItem.Archetype;
            Fields fields = arch.Data;

            ref Alis.Core.Ecs.Test.Models.Position pos = ref fields.GetComponentDataReference<Alis.Core.Ecs.Test.Models.Position>();

            Assert.Equal(42f, pos.X, 5);
            Assert.Equal(84f, pos.Y, 5);
        }

        /// <summary>
        /// The position
        /// </summary>
        private struct Position
        {
            /// <summary>
            /// Gets or sets the value of the x
            /// </summary>
            public int X { get; set; }
            /// <summary>
            /// Gets or sets the value of the y
            /// </summary>
            public int Y { get; set; }
        }
    }
}
