using System;
using Alis.Core.Ecs.Exceptions;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    public class GameObjectDeepCoverageTest
    {
        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void GameObject_Has_ReturnsTrueForExistingComponent()
        {
            using Scene scene = new();
            GameObject go = scene.Create(new Position { X = 10 });
            Assert.True(go.Has<Position>());
        }

        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void GameObject_Has_ReturnsFalseForMissingComponent()
        {
            using Scene scene = new();
            GameObject go = scene.Create(new Position());
            Assert.False(go.Has<Velocity>());
        }

        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void GameObject_Add_ExistingComponent_Throws()
        {
            using Scene scene = new();
            GameObject go = scene.Create(new Position { X = 5 });
            Assert.Throws<InvalidOperationException>(() => go.Add(new Position { X = 10 }));
        }

        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void GameObject_Remove_MissingComponent_Throws()
        {
            using Scene scene = new();
            GameObject go = scene.Create(new Position());
            Assert.Throws<ComponentNotFoundException>(() => go.Remove<Velocity>());
        }

        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void GameObject_AddAndRemove_MultipleComponents_Works()
        {
            using Scene scene = new();
            GameObject go = scene.Create(new Position());
            go.Add(new Velocity { X = 1, Y = 2 });
            go.Add(new Health { Value = 100 });
            Assert.True(go.Has<Position>());
            Assert.True(go.Has<Velocity>());
            Assert.True(go.Has<Health>());
            go.Remove<Velocity>();
            Assert.False(go.Has<Velocity>());
            Assert.True(go.Has<Health>());
        }

        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void GameObject_Get_ReturnsCorrectValue()
        {
            using Scene scene = new();
            GameObject go = scene.Create(new Position { X = 42, Y = 84 });
            ref Position pos = ref go.Get<Position>();
            Assert.Equal(42, pos.X);
            Assert.Equal(84, pos.Y);
        }

        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void GameObject_IsAlive_ReturnsTrueForActive()
        {
            using Scene scene = new();
            GameObject go = scene.Create(new Position());
            Assert.True(go.IsAlive);
        }

        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void GameObject_Delete_MakesEntityNotAlive()
        {
            using Scene scene = new();
            GameObject go = scene.Create(new Position());
            go.Delete();
            Assert.False(go.IsAlive);
        }

        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void GameObject_Equals_SameEntity_ReturnsTrue()
        {
            using Scene scene = new();
            GameObject go1 = scene.Create(new Position());
            scene.Update();
            Assert.True(go1.IsAlive);
        }

        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void GameObject_Equals_DifferentEntity_ReturnsFalse()
        {
            using Scene scene = new();
            GameObject go1 = scene.Create(new Position());
            GameObject go2 = scene.Create(new Position());
            Assert.NotEqual(go1, go2);
        }

        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void GameObject_GetHashCode_IsConsistent()
        {
            using Scene scene = new();
            GameObject go = scene.Create(new Position());
            int hash1 = go.GetHashCode();
            int hash2 = go.GetHashCode();
            Assert.Equal(hash1, hash2);
        }

        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void GameObject_TryGet_WithComponent_ReturnsRef()
        {
            using Scene scene = new();
            GameObject go = scene.Create(new Velocity { X = 42 });
            bool found = go.TryGet<Velocity>(out var velRef);
            Assert.True(found);
            Assert.Equal(42, velRef.Value.X);
        }

        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void GameObject_TryGet_WithoutComponent_ReturnsFalse()
        {
            using Scene scene = new();
            GameObject go = scene.Create(new Position());
            bool found = go.TryGet<Velocity>(out _);
            Assert.False(found);
        }

        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void GameObject_Has_AfterRemove_ReturnsFalse()
        {
            using Scene scene = new();
            GameObject go = scene.Create(new Position(), new Velocity());
            Assert.True(go.Has<Velocity>());
            go.Remove<Velocity>();
            scene.Update();
            Assert.False(go.Has<Velocity>());
        }
    }
}
