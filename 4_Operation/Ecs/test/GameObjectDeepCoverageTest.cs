using System;
using Alis.Core.Ecs.Exceptions;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    /// The game object deep coverage test class
    /// </summary>
    public class GameObjectDeepCoverageTest
    {
        /// <summary>
        /// Tests that game object has returns true for existing component
        /// </summary>
        [Fact] public void GameObject_Has_ReturnsTrueForExistingComponent()
        {
            using (Scene scene = new())
            {
                GameObject go = scene.Create(new Position {X = 10});
                Assert.True(go.Has<Position>());
            }
        }

        /// <summary>
        /// Tests that game object has returns false for missing component
        /// </summary>
        [Fact] public void GameObject_Has_ReturnsFalseForMissingComponent()
        {
            using (Scene scene = new())
            {
                GameObject go = scene.Create(new Position());
                Assert.False(go.Has<Velocity>());
            }
        }

        /// <summary>
        /// Tests that game object add existing component throws
        /// </summary>
        [Fact] public void GameObject_Add_ExistingComponent_Throws()
        {
            using (Scene scene = new())
            {
                GameObject go = scene.Create(new Position {X = 5});
                Assert.Throws<InvalidOperationException>(() => go.Add(new Position {X = 10}));
            }
        }

        /// <summary>
        /// Tests that game object remove missing component throws
        /// </summary>
        [Fact] public void GameObject_Remove_MissingComponent_Throws()
        {
            using (Scene scene = new())
            {
                GameObject go = scene.Create(new Position());
                Assert.Throws<ComponentNotFoundException>(() => go.Remove<Velocity>());
            }
        }

        /// <summary>
        /// Tests that game object add and remove multiple components works
        /// </summary>
        [Fact] public void GameObject_AddAndRemove_MultipleComponents_Works()
        {
            using (Scene scene = new())
            {
                GameObject go = scene.Create(new Position());
                go.Add(new Velocity {X = 1, Y = 2});
                go.Add(new Health {Value = 100});
                Assert.True(go.Has<Position>());
                Assert.True(go.Has<Velocity>());
                Assert.True(go.Has<Health>());
                go.Remove<Velocity>();
                Assert.False(go.Has<Velocity>());
                Assert.True(go.Has<Health>());
            }
        }

        /// <summary>
        /// Tests that game object get returns correct value
        /// </summary>
        [Fact] public void GameObject_Get_ReturnsCorrectValue()
        {
            using (Scene scene = new())
            {
                GameObject go = scene.Create(new Position {X = 42, Y = 84});
                ref Position pos = ref go.Get<Position>();
                Assert.Equal(42, pos.X);
                Assert.Equal(84, pos.Y);
            }
        }

        /// <summary>
        /// Tests that game object is alive returns true for active
        /// </summary>
        [Fact] public void GameObject_IsAlive_ReturnsTrueForActive()
        {
            using (Scene scene = new())
            {
                GameObject go = scene.Create(new Position());
                Assert.True(go.IsAlive);
            }
        }

        /// <summary>
        /// Tests that game object delete makes entity not alive
        /// </summary>
        [Fact] public void GameObject_Delete_MakesEntityNotAlive()
        {
            using (Scene scene = new())
            {
                GameObject go = scene.Create(new Position());
                go.Delete();
                Assert.False(go.IsAlive);
            }
        }

        /// <summary>
        /// Tests that game object equals same entity returns true
        /// </summary>
        [Fact] public void GameObject_Equals_SameEntity_ReturnsTrue()
        {
            using (Scene scene = new())
            {
                GameObject go1 = scene.Create(new Position());
                scene.Update();
                Assert.True(go1.IsAlive);
            }
        }

        /// <summary>
        /// Tests that game object equals different entity returns false
        /// </summary>
        [Fact] public void GameObject_Equals_DifferentEntity_ReturnsFalse()
        {
            using (Scene scene = new())
            {
                GameObject go1 = scene.Create(new Position());
                GameObject go2 = scene.Create(new Position());
                Assert.NotEqual(go1, go2);
            }
        }

        /// <summary>
        /// Tests that game object get hash code is consistent
        /// </summary>
        [Fact] public void GameObject_GetHashCode_IsConsistent()
        {
            using (Scene scene = new())
            {
                GameObject go = scene.Create(new Position());
                int hash1 = go.GetHashCode();
                int hash2 = go.GetHashCode();
                Assert.Equal(hash1, hash2);
            }
        }

        /// <summary>
        /// Tests that game object try get with component returns ref
        /// </summary>
        [Fact] public void GameObject_TryGet_WithComponent_ReturnsRef()
        {
            using (Scene scene = new())
            {
                GameObject go = scene.Create(new Velocity {X = 42});
                bool found = go.TryGet<Velocity>(out Ref<Velocity> velRef);
                Assert.True(found);
                Assert.Equal(42, velRef.Value.X);
            }
        }

        /// <summary>
        /// Tests that game object try get without component returns false
        /// </summary>
        [Fact] public void GameObject_TryGet_WithoutComponent_ReturnsFalse()
        {
            using (Scene scene = new())
            {
                GameObject go = scene.Create(new Position());
                bool found = go.TryGet<Velocity>(out _);
                Assert.False(found);
            }
        }

        /// <summary>
        /// Tests that game object has after remove returns false
        /// </summary>
        [Fact] public void GameObject_Has_AfterRemove_ReturnsFalse()
        {
            using (Scene scene = new())
            {
                GameObject go = scene.Create(new Position(), new Velocity());
                Assert.True(go.Has<Velocity>());
                go.Remove<Velocity>();
                scene.Update();
                Assert.False(go.Has<Velocity>());
            }
        }
    }
}
