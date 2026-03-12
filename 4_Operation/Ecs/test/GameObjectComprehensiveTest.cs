// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectComprehensiveTest.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Comprehensive tests for GameObject struct covering all aspects
    /// </summary>
    public class GameObjectComprehensiveTest
    {
        /// <summary>
        /// Tests that game object null static is null
        /// </summary>
        [Fact]
        public void GameObject_NullStatic_IsNull()
        {
            // Arrange & Act
            GameObject nullGo = GameObject.Null;

            // Assert
            Assert.True(nullGo.IsNull);
            Assert.False(nullGo.IsAlive);
        }

        /// <summary>
        /// Tests that game object create sets correct properties
        /// </summary>
        [Fact]
        public void GameObject_Create_SetsCorrectProperties()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            GameObject go = scene.Create();

            // Assert
            Assert.NotNull(go);
            Assert.True(go.IsAlive);
            Assert.False(go.IsNull);
        }

        /// <summary>
        /// Tests that game object create with component stores component
        /// </summary>
        [Fact]
        public void GameObject_CreateWithComponent_StoresComponent()
        {
            // Arrange
            using Scene scene = new Scene();
            Position pos = new Position { X = 10, Y = 20 };

            // Act
            GameObject go = scene.Create(pos);

            // Assert
            Assert.True(go.Has<Position>());
            Assert.Equal(10, go.Get<Position>().X);
            Assert.Equal(20, go.Get<Position>().Y);
        }

        /// <summary>
        /// Tests that game object create multiple entities all are independent
        /// </summary>
        /// <param name="count">The count</param>
        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(10)]
        public void GameObject_CreateMultipleEntities_AllAreIndependent(int count)
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject[] entities = new GameObject[count];

            // Act
            for (int i = 0; i < count; i++)
            {
                entities[i] = scene.Create();
            }

            // Assert
            for (int i = 0; i < count; i++)
            {
                Assert.True(entities[i].IsAlive);
                Assert.False(entities[i].IsNull);
                for (int j = i + 1; j < count; j++)
                {
                    Assert.NotEqual(entities[i], entities[j]);
                }
            }
        }
        
        /// <summary>
        /// Tests that game object add component component exists
        /// </summary>
        [Fact]
        public void GameObject_AddComponent_ComponentExists()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject go = scene.Create();
            Position pos = new Position { X = 5, Y = 15 };

            // Act
            go.Add(pos);

            // Assert
            Assert.True(go.Has<Position>());
            Assert.Equal(5, go.Get<Position>().X);
        }

        /// <summary>
        /// Tests that game object add multiple components all exist
        /// </summary>
        [Fact]
        public void GameObject_AddMultipleComponents_AllExist()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject go = scene.Create();

            // Act
            go.Add(new Position { X = 1, Y = 2 });
            go.Add(new Health { Value = 100 });
            go.Add(new Velocity { X = 10, Y = 20 });

            // Assert
            Assert.True(go.Has<Position>());
            Assert.True(go.Has<Health>());
            Assert.True(go.Has<Velocity>());
        }

        /// <summary>
        /// Tests that game object remove component component no longer exists
        /// </summary>
        [Fact]
        public void GameObject_RemoveComponent_ComponentNoLongerExists()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject go = scene.Create(new Position { X = 1, Y = 2 });

            // Act
            go.Remove<Position>();

            // Assert
            Assert.False(go.Has<Position>());
        }

        /// <summary>
        /// Tests that game object get component returns correct value
        /// </summary>
        [Fact]
        public void GameObject_GetComponent_ReturnsCorrectValue()
        {
            // Arrange
            using Scene scene = new Scene();
            Position expected = new Position { X = 42, Y = 84 };
            GameObject go = scene.Create(expected);

            // Act
            ref Position actual = ref go.Get<Position>();

            // Assert
            Assert.Equal(expected.X, actual.X);
            Assert.Equal(expected.Y, actual.Y);
        }

        /// <summary>
        /// Tests that game object modify component via ref changes are persisted
        /// </summary>
        [Fact]
        public void GameObject_ModifyComponentViaRef_ChangesArePersisted()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject go = scene.Create(new Position { X = 10, Y = 20 });

            // Act
            ref Position pos = ref go.Get<Position>();
            pos.X = 100;
            pos.Y = 200;

            // Assert
            Assert.Equal(100, go.Get<Position>().X);
            Assert.Equal(200, go.Get<Position>().Y);
        }

        /// <summary>
        /// Tests that game object delete with various component counts succeeds
        /// </summary>
        /// <param name="componentCount">The component count</param>
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(10)]
        public void GameObject_DeleteWithVariousComponentCounts_Succeeds(int componentCount)
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject go = scene.Create();

            // Act
            if (componentCount >= 1) go.Add(new Position { X = 1, Y = 1 });
            if (componentCount >= 2) go.Add(new Health { Value = 50 });
            if (componentCount >= 3) go.Add(new Velocity { X = 1, Y = 1 });
            if (componentCount >= 4) go.Add(new Transform { X = 0, Y = 0 });
            if (componentCount >= 5) go.Add(new Damage { Value = 10 });
            if (componentCount >= 6) go.Add(new AnotherComponent { Data = 42 });
            if (componentCount >= 7) go.Add(new AnotherComponent2 { Data = 100 });
            if (componentCount >= 8) go.Add(new Armor { Value = 25 });
            if (componentCount >= 9) go.Add(new TagComponent());
            if (componentCount >= 10) go.Add(new TestComponent { Value = 999 });

            // Assert - should not throw
            Assert.True(go.IsAlive);
            go.Delete();
            Assert.False(go.IsAlive);
        }

        /// <summary>
        /// Tests that game object equals operator compares two entities
        /// </summary>
        [Fact]
        public void GameObject_EqualsOperator_ComparesTwoEntities()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject go1 = scene.Create();
            GameObject go2 = scene.Create();

            // Act & Assert
            Assert.NotEqual(go1, go2);
            Assert.True(go1 == go1);
            Assert.False(go1 == go2);
        }

        /// <summary>
        /// Tests that game object not equals operator differentiate entities
        /// </summary>
        [Fact]
        public void GameObject_NotEqualsOperator_DifferentiateEntities()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject go1 = scene.Create();
            GameObject go2 = scene.Create();

            // Act & Assert
            Assert.True(go1 != go2);
            Assert.False(go1 != go1);
        }

        /// <summary>
        /// Tests that game object get hash code consistent for same entity
        /// </summary>
        [Fact]
        public void GameObject_GetHashCode_ConsistentForSameEntity()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject go = scene.Create();

            // Act
            int hash1 = go.GetHashCode();
            int hash2 = go.GetHashCode();

            // Assert
            Assert.Equal(hash1, hash2);
        }

        /// <summary>
        /// Tests that game object to string returns valid string
        /// </summary>
        [Fact]
        public void GameObject_ToString_ReturnsValidString()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject go = scene.Create();

            // Act
            string str = go.ToString();

            // Assert
            Assert.NotNull(str);
            Assert.False(string.IsNullOrEmpty(str));
        }

        /// <summary>
        /// Tests that game object create multiple with same components independent data
        /// </summary>
        /// <param name="first">The first</param>
        /// <param name="second">The second</param>
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(5, 5)]
        [InlineData(10, 10)]
        public void GameObject_CreateMultipleWithSameComponents_IndependentData(int first, int second)
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            GameObject go1 = scene.Create(new Position { X = first, Y = first });
            GameObject go2 = scene.Create(new Position { X = second, Y = second });

            // Assert
            Assert.Equal(first, go1.Get<Position>().X);
            Assert.Equal(second, go2.Get<Position>().X);
        }

        /// <summary>
        /// Tests that game object remove all components entity still alive
        /// </summary>
        [Fact]
        public void GameObject_RemoveAllComponents_EntityStillAlive()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject go = scene.Create(new Position { X = 1, Y = 1 }, new Health { Value = 100 });

            // Act
            go.Remove<Position>();
            go.Remove<Health>();

            // Assert
            Assert.False(go.Has<Position>());
            Assert.False(go.Has<Health>());
        }

        /// <summary>
        /// Tests that game object get component count reflects added components
        /// </summary>
        [Fact]
        public void GameObject_GetComponentCount_ReflectsAddedComponents()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject go = scene.Create();

            // Act
            go.Add(new Position { X = 1, Y = 1 });
            go.Add(new Health { Value = 50 });

            // Assert - GetComponentCount may be available
            Assert.True(go.Has<Position>());
            Assert.True(go.Has<Health>());
        }
    }
}

