using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    /// The generic variant coverage test class
    /// </summary>
    public class GenericVariantCoverageTest
    {
        /// <summary>
        /// Tests that game object query enumerator all arities are value types
        /// </summary>
        [Fact] public void GameObjectQueryEnumerator_AllArities_AreValueTypes()
        {
            Assert.True(typeof(GameObjectQueryEnumerator<Position>).IsValueType);
            Assert.True(typeof(GameObjectQueryEnumerator<Position, Velocity>).IsValueType);
            Assert.True(typeof(GameObjectQueryEnumerator<Position, Velocity, Health>).IsValueType);
            Assert.True(typeof(GameObjectQueryEnumerator<Position, Velocity, Health, Transform>).IsValueType);
            Assert.True(typeof(GameObjectQueryEnumerator<Position, Velocity, Health, Transform, TestComponent>).IsValueType);
            Assert.True(typeof(GameObjectQueryEnumerator<Position, Velocity, Health, Transform, TestComponent, AnotherComponent>).IsValueType);
            Assert.True(typeof(GameObjectQueryEnumerator<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage>).IsValueType);
            Assert.True(typeof(GameObjectQueryEnumerator<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor>).IsValueType);
        }

        /// <summary>
        /// Tests that game object ref tuple all arities are value types
        /// </summary>
        [Fact] public void GameObjectRefTuple_AllArities_AreValueTypes()
        {
            Assert.True(typeof(GameObjectRefTuple<Position>).IsValueType);
            Assert.True(typeof(GameObjectRefTuple<Position, Velocity>).IsValueType);
            Assert.True(typeof(GameObjectRefTuple<Position, Velocity, Health>).IsValueType);
            Assert.True(typeof(GameObjectRefTuple<Position, Velocity, Health, Transform>).IsValueType);
            Assert.True(typeof(GameObjectRefTuple<Position, Velocity, Health, Transform, TestComponent>).IsValueType);
            Assert.True(typeof(GameObjectRefTuple<Position, Velocity, Health, Transform, TestComponent, AnotherComponent>).IsValueType);
            Assert.True(typeof(GameObjectRefTuple<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage>).IsValueType);
            Assert.True(typeof(GameObjectRefTuple<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor>).IsValueType);
        }

        /// <summary>
        /// Tests that query enumerable all arities are value types
        /// </summary>
        [Fact] public void QueryEnumerable_AllArities_AreValueTypes()
        {
            Assert.True(typeof(QueryEnumerable<Position>).IsValueType);
            Assert.True(typeof(QueryEnumerable<Position, Velocity>).IsValueType);
            Assert.True(typeof(QueryEnumerable<Position, Velocity, Health>).IsValueType);
            Assert.True(typeof(QueryEnumerable<Position, Velocity, Health, Transform>).IsValueType);
            Assert.True(typeof(QueryEnumerable<Position, Velocity, Health, Transform, TestComponent>).IsValueType);
            Assert.True(typeof(QueryEnumerable<Position, Velocity, Health, Transform, TestComponent, AnotherComponent>).IsValueType);
            Assert.True(typeof(QueryEnumerable<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage>).IsValueType);
            Assert.True(typeof(QueryEnumerable<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor>).IsValueType);
        }

        /// <summary>
        /// Tests that chunk tuple all arities are value types
        /// </summary>
        [Fact] public void ChunkTuple_AllArities_AreValueTypes()
        {
            Assert.True(typeof(ChunkTuple<Position>).IsValueType);
            Assert.True(typeof(ChunkTuple<Position, Velocity>).IsValueType);
            Assert.True(typeof(ChunkTuple<Position, Velocity, Health>).IsValueType);
            Assert.True(typeof(ChunkTuple<Position, Velocity, Health, Transform>).IsValueType);
            Assert.True(typeof(ChunkTuple<Position, Velocity, Health, Transform, TestComponent>).IsValueType);
            Assert.True(typeof(ChunkTuple<Position, Velocity, Health, Transform, TestComponent, AnotherComponent>).IsValueType);
            Assert.True(typeof(ChunkTuple<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage>).IsValueType);
            Assert.True(typeof(ChunkTuple<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor>).IsValueType);
        }

        /// <summary>
        /// Tests that ref tuple all arities are value types
        /// </summary>
        [Fact] public void RefTuple_AllArities_AreValueTypes()
        {
            Assert.True(typeof(RefTuple<Position>).IsValueType);
            Assert.True(typeof(RefTuple<Position, Velocity>).IsValueType);
            Assert.True(typeof(RefTuple<Position, Velocity, Health>).IsValueType);
            Assert.True(typeof(RefTuple<Position, Velocity, Health, Transform>).IsValueType);
            Assert.True(typeof(RefTuple<Position, Velocity, Health, Transform, TestComponent>).IsValueType);
            Assert.True(typeof(RefTuple<Position, Velocity, Health, Transform, TestComponent, AnotherComponent>).IsValueType);
            Assert.True(typeof(RefTuple<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage>).IsValueType);
            Assert.True(typeof(RefTuple<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor>).IsValueType);
        }

        /// <summary>
        /// Tests that query enumerator all arities have query enumerable
        /// </summary>
        [Fact] public void QueryEnumerator_AllArities_HaveQueryEnumerable()
        {
            Assert.True(typeof(QueryEnumerator<Position>.QueryEnumerable).IsValueType);
            Assert.True(typeof(QueryEnumerator<Position, Velocity>.QueryEnumerable).IsValueType);
        }

        /// <summary>
        /// Tests that chunk query enumerator all arities are value types
        /// </summary>
        [Fact] public void ChunkQueryEnumerator_AllArities_AreValueTypes()
        {
            Assert.True(typeof(ChunkQueryEnumerator<Position>).IsValueType);
            Assert.True(typeof(ChunkQueryEnumerator<Position, Velocity>).IsValueType);
            Assert.True(typeof(ChunkQueryEnumerator<Position, Velocity, Health>).IsValueType);
        }

        /// <summary>
        /// Tests that game object enumerator is value type
        /// </summary>
        [Fact] public void GameObjectEnumerator_IsValueType()
        {
            Assert.True(typeof(GameObjectEnumerator).IsValueType);
        }

        /// <summary>
        /// Tests that include disabled is value type
        /// </summary>
        [Fact] public void IncludeDisabled_IsValueType()
        {
            Assert.True(typeof(IncludeDisabled).IsValueType);
        }

        /// <summary>
        /// Tests that not is value type
        /// </summary>
        [Fact] public void Not_IsValueType()
        {
            Assert.True(typeof(Not<Position>).IsValueType);
        }

        /// <summary>
        /// Tests that with is value type
        /// </summary>
        [Fact] public void With_IsValueType()
        {
            Assert.True(typeof(With<Position>).IsValueType);
        }
    }
}
