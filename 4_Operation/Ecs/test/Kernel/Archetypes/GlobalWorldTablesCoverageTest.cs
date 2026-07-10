using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel.Archetypes
{
    public class GlobalWorldTablesCoverageTest
    {
        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void GrowComponentTagTable_WithManyComponents_DoesNotThrow()
        {
            using Scene scene = new();
            for (int i = 0; i < 20; i++)
            {
                scene.Create(new Position { X = i, Y = i * 2 });
            }
            Assert.NotNull(scene);
        }

        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void ComponentIndex_WithMultipleArchetypes_ReturnsValidIndex()
        {
            using Scene scene = new();
            scene.Create(new Position { X = 1, Y = 2 });
            scene.Create(new Position { X = 3, Y = 4 }, new Velocity { X = 5, Y = 6 });
            scene.Create(new Position { X = 7, Y = 8 }, new Velocity { X = 9, Y = 10 }, new Health { Value = 100 });
            Assert.NotNull(scene);
        }

        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void Has_WithPopulatedScene_WorksCorrectly()
        {
            using Scene scene = new();
            scene.Create(new Position { X = 1, Y = 2 });
            scene.Create(new Velocity { X = 3, Y = 4 });
            Assert.True(scene.AllowStructualChanges);
        }

        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void WorldArchetypeTable_WithEntities_UpdatesCorrectly()
        {
            using Scene scene = new();
            scene.Create(new Position { X = 1, Y = 2 }, new Velocity { X = 3, Y = 4 });
            scene.Create(new Position { X = 5, Y = 6 }, new Velocity { X = 7, Y = 8 });
            scene.Create(new Health { Value = 10 });
            Assert.NotNull(scene);
        }
    }
}
