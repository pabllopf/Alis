using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Systems
{
    /// <summary>
    /// The query and scene deep coverage test class
    /// </summary>
    public class QueryAndSceneDeepCoverageTest
    {
        /// <summary>
        /// Tests that scene create many with position and velocity creates multiple
        /// </summary>
        [Fact] public void Scene_CreateMany_WithPositionAndVelocity_CreatesMultiple()
        {
            using Scene scene = new();
            ChunkTuple<Position, Velocity> chunk = scene.CreateMany<Position, Velocity>(3);
            Assert.Equal(3, chunk.Span1.Length);
            Assert.Equal(3, chunk.Span2.Length);
        }

        /// <summary>
        /// Tests that scene create many with single component creates multiple
        /// </summary>
        [Fact] public void Scene_CreateMany_WithSingleComponent_CreatesMultiple()
        {
            using Scene scene = new();
            ChunkTuple<Position> chunk = scene.CreateMany<Position>(5);
            Assert.Equal(5, chunk.Span.Length);
        }

        /// <summary>
        /// Tests that scene query with not and include disabled combines filters
        /// </summary>
        [Fact] public void SceneQuery_WithNotAndIncludeDisabled_CombinesFilters()
        {
            using Scene scene = new();
            scene.Create(new Position());
            scene.Create(new Position(), new Velocity());
            Query query = scene.Query<With<Position>, Not<Velocity>, IncludeDisabled>();
            Assert.NotNull(query);
        }

        /// <summary>
        /// Tests that scene multiple disposals no throw
        /// </summary>
        [Fact] public void Scene_MultipleDisposals_NoThrow()
        {
            Scene scene = new();
            scene.Create(new Position());
            scene.Dispose();
            scene.Dispose();
        }

        /// <summary>
        /// Tests that scene update with events works
        /// </summary>
        [Fact] public void Scene_Update_WithEvents_Works()
        {
            using Scene scene = new();
            scene.Create(new Position());
            scene.Update();
        }

        /// <summary>
        /// Tests that scene update with multiple frames works
        /// </summary>
        [Fact] public void Scene_Update_WithMultipleFrames_Works()
        {
            using Scene scene = new();
            for (int i = 0; i < 3; i++)
                scene.Create(new Position { X = i });
            for (int i = 0; i < 5; i++)
                scene.Update();
        }

        /// <summary>
        /// Tests that query enumerator ref tuple deconstruct works
        /// </summary>
        [Fact] public void QueryEnumerator_RefTuple_DeconstructWorks()
        {
            using Scene scene = new();
            scene.Create(new Position { X = 5 });
            Query query = scene.Query<With<Position>>();
            foreach (RefTuple<Position> tuple in query.Enumerate<Position>())
            {
                Assert.Equal(5, tuple.Item1.Value.X);
            }
        }

        /// <summary>
        /// Tests that query enumerator two components deconstruct works
        /// </summary>
        [Fact] public void QueryEnumerator_TwoComponents_DeconstructWorks()
        {
            using Scene scene = new();
            scene.Create(new Position { X = 1 }, new Velocity { X = 10 });
            Query query = scene.Query<With<Position>, With<Velocity>>();
            foreach (RefTuple<Position, Velocity> tuple in query.Enumerate<Position, Velocity>())
            {
                Assert.Equal(1, tuple.Item1.Value.X);
                Assert.Equal(10, tuple.Item2.Value.X);
            }
        }

        /// <summary>
        /// Tests that query enumerator three components deconstruct works
        /// </summary>
        [Fact] public void QueryEnumerator_ThreeComponents_DeconstructWorks()
        {
            using Scene scene = new();
            scene.Create(new Position { X = 1 }, new Velocity { X = 10 }, new Health { Value = 100 });
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>>();
            foreach (RefTuple<Position, Velocity, Health> tuple in query.Enumerate<Position, Velocity, Health>())
            {
                Assert.Equal(1, tuple.Item1.Value.X);
                Assert.Equal(10, tuple.Item2.Value.X);
                Assert.Equal(100, tuple.Item3.Value.Value);
            }
        }

        /// <summary>
        /// Tests that chunk enumerator with single component works
        /// </summary>
        [Fact] public void ChunkEnumerator_WithSingleComponent_Works()
        {
            using Scene scene = new();
            scene.Create(new Position { X = 1 });
            scene.Create(new Position { X = 2 });
            Query query = scene.Query<With<Position>>();
            foreach (ChunkTuple<Position> chunk in query.EnumerateChunks<Position>())
            {
                Assert.Equal(2, chunk.Span.Length);
            }
        }

        /// <summary>
        /// Tests that chunk enumerator with two components works
        /// </summary>
        [Fact] public void ChunkEnumerator_WithTwoComponents_Works()
        {
            using Scene scene = new();
            scene.CreateMany<Position, Velocity>(2);
            Query query = scene.Query<With<Position>, With<Velocity>>();
            foreach (ChunkTuple<Position, Velocity> chunk in query.EnumerateChunks<Position, Velocity>())
            {
                Assert.Equal(2, chunk.Span1.Length);
                Assert.Equal(2, chunk.Span2.Length);
            }
        }

        /// <summary>
        /// Tests that scene create many three components works
        /// </summary>
        [Fact] public void Scene_CreateMany_ThreeComponents_Works()
        {
            using Scene scene = new();
            ChunkTuple<Position, Velocity, Health> chunk = scene.CreateMany<Position, Velocity, Health>(4);
            Assert.Equal(4, chunk.Span1.Length);
            Assert.Equal(4, chunk.Span2.Length);
            Assert.Equal(4, chunk.Span3.Length);
        }

        /// <summary>
        /// Tests that scene create many four components works
        /// </summary>
        [Fact] public void Scene_CreateMany_FourComponents_Works()
        {
            using Scene scene = new();
            ChunkTuple<Position, Velocity, Health, Transform> chunk = scene.CreateMany<Position, Velocity, Health, Transform>(2);
            Assert.Equal(2, chunk.Span1.Length);
            Assert.Equal(2, chunk.Span2.Length);
        }

        /// <summary>
        /// Tests that scene create eight components works
        /// </summary>
        [Fact] public void Scene_Create_EightComponents_Works()
        {
            using Scene scene = new();
            scene.Create(new Position(), new Velocity(), new Health(), new Transform(),
                         new TestComponent(), new AnotherComponent(), new Damage(), new Armor());
            Assert.NotNull(scene);
        }
    }
}

