using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    public class GenericVariantCoverageTest
    {
        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void GameObjectQueryEnumerator_AllArities_AreValueTypes()
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

        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void GameObjectRefTuple_AllArities_AreValueTypes()
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

        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void QueryEnumerable_AllArities_AreValueTypes()
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

        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void ChunkTuple_AllArities_AreValueTypes()
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

        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void RefTuple_AllArities_AreValueTypes()
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

        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void QueryEnumerator_AllArities_HaveQueryEnumerable()
        {
            Assert.True(typeof(QueryEnumerator<Position>.QueryEnumerable).IsValueType);
            Assert.True(typeof(QueryEnumerator<Position, Velocity>.QueryEnumerable).IsValueType);
        }

        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void ChunkQueryEnumerator_AllArities_AreValueTypes()
        {
            Assert.True(typeof(ChunkQueryEnumerator<Position>).IsValueType);
            Assert.True(typeof(ChunkQueryEnumerator<Position, Velocity>).IsValueType);
            Assert.True(typeof(ChunkQueryEnumerator<Position, Velocity, Health>).IsValueType);
        }

        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void GameObjectEnumerator_IsValueType()
        {
            Assert.True(typeof(GameObjectEnumerator).IsValueType);
        }

        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void IncludeDisabled_IsValueType()
        {
            Assert.True(typeof(IncludeDisabled).IsValueType);
        }

        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void Not_IsValueType()
        {
            Assert.True(typeof(Not<Position>).IsValueType);
        }

        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void With_IsValueType()
        {
            Assert.True(typeof(With<Position>).IsValueType);
        }
    }
}
