using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    /// The remaining coverage tests class
    /// </summary>
    public class RemainingCoverageTests
    {
        /// <summary>
        /// Tests that entity with 8 components exercises all paths
        /// </summary>
        [Fact] public void EntityWith8Components_ExercisesAllPaths()
        {
            using Scene scene = new();
            scene.Create(new Position(), new Velocity(), new Health(), new Transform(),
                         new TestComponent(), new AnotherComponent(), new Damage(), new Armor());
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>,
                                       With<TestComponent>, With<AnotherComponent>, With<Damage>, With<Armor>>();
            int count = 0;
            foreach (GameObjectRefTuple<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor> _ in query.EnumerateWithEntities<Position, Velocity, Health, Transform,
                                                        TestComponent, AnotherComponent, Damage, Armor>())
            {
                count++;
            }
            Assert.Equal(1, count);
        }

        /// <summary>
        /// Tests that chunk tuple exercises chunk paths
        /// </summary>
        [Fact] public void ChunkTuple_ExercisesChunkPaths()
        {
            using Scene scene = new();
            ChunkTuple<Position, Velocity> chunk = scene.CreateMany<Position, Velocity>(2);
            Assert.Equal(2, chunk.Span1.Length);
            Assert.Equal(2, chunk.Span2.Length);
        }

        /// <summary>
        /// Tests that scene update exercises update paths
        /// </summary>
        [Fact] public void SceneUpdate_ExercisesUpdatePaths()
        {
            using Scene scene = new();
            for (int i = 0; i < 5; i++)
                scene.Create(new Position());
            scene.Update();
        }

        /// <summary>
        /// Tests that scene update with multiple types exercises all update variants
        /// </summary>
        [Fact] public void SceneUpdateWithMultipleTypes_ExercisesAllUpdateVariants()
        {
            using Scene scene = new();
            scene.Create(new Position(), new Velocity(), new Health());
            scene.Create(new Position(), new Velocity());
            scene.Update();
        }

        /// <summary>
        /// Tests that scene query with include disabled works
        /// </summary>
        [Fact] public void SceneQuery_WithIncludeDisabled_Works()
        {
            using Scene scene = new();
            scene.Create(new Position());
            Query query = scene.Query<With<Position>, IncludeDisabled>();
            Assert.NotNull(query);
        }

        /// <summary>
        /// Tests that scene query with not filters correctly
        /// </summary>
        [Fact] public void SceneQuery_WithNot_FiltersCorrectly()
        {
            using Scene scene = new();
            scene.Create(new Position());
            scene.Create(new Position(), new Velocity());
            Query query = scene.Query<With<Position>, Not<Velocity>>();
            int count = 0;
            foreach (Ecs.Systems.GameObjectRefTuple<Position> _ in query.EnumerateWithEntities<Position>())
            {
                count++;
            }
            Assert.Equal(1, count);
        }
    }
}

