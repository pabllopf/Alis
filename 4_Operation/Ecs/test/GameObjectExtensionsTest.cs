// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectExtensionsTest.cs
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
    ///     The game object extensions test class
    /// </summary>
    /// <remarks>
    ///     Tests the GameObject extension methods for adding, removing and managing tags.
    /// </remarks>
    public class GameObjectExtensionsTest
    {
        /// <summary>
        ///     Tests that game object can be tagged
        /// </summary>
        /// <remarks>
        ///     Verifies that Tag method can add a tag to an entity.
        /// </remarks>
        [Fact]
        public void GameObject_CanBeTagged()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 1, Y = 2 });

            // Act
            entity.Tag<PlayerTag>();

            // Assert
            Assert.True(entity.Tagged<PlayerTag>());
        }

        /// <summary>
        ///     Tests that game object can have multiple tags
        /// </summary>
        /// <remarks>
        ///     Tests that an entity can have multiple different tags simultaneously.
        /// </remarks>
        [Fact]
        public void GameObject_CanHaveMultipleTags()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 1, Y = 2 });

            // Act
            entity.Tag<PlayerTag>();
            entity.Tag<TagComponent>();

            // Assert
            Assert.True(entity.Tagged<PlayerTag>());
            Assert.True(entity.Tagged<TagComponent>());
        }

        /// <summary>
        ///     Tests that game object add component adds new component
        /// </summary>
        /// <remarks>
        ///     Tests that Add extension method can add a new component to an entity.
        /// </remarks>
        [Fact]
        public void GameObject_AddComponent_AddsNewComponent()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 5, Y = 10 });

            // Act
            entity.Add(new Velocity { VX = 1.0f, VY = 2.0f });

            // Assert
            Assert.True(entity.Has<Velocity>());
        }

        /// <summary>
        ///     Tests that game object remove component removes component
        /// </summary>
        /// <remarks>
        ///     Validates that Remove extension method can remove a component from an entity.
        /// </remarks>
        [Fact]
        public void GameObject_RemoveComponent_RemovesComponent()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 5, Y = 10 }, new Velocity { VX = 1.0f, VY = 2.0f });

            // Act
            entity.Remove<Velocity>();

            // Assert
            Assert.False(entity.Has<Velocity>());
        }
        
        /// <summary>
        ///     Tests that add with generic component works
        /// </summary>
        /// <remarks>
        ///     Tests that the generic Add method works correctly for adding components.
        /// </remarks>
        [Fact]
        public void Add_WithGenericComponent_Works()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 10, Y = 20 });

            // Act
            entity.Add(new Health { Value = 100 });

            // Assert
            Assert.True(entity.Has<Health>());
            Assert.Equal(100, entity.Get<Health>().Value);
        }

        /// <summary>
        ///     Tests that entity can add and remove components multiple times
        /// </summary>
        /// <remarks>
        ///     Validates that components can be added and removed multiple times on the same entity.
        /// </remarks>
        [Fact]
        public void Entity_CanAddAndRemoveComponentsMultipleTimes()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 5, Y = 5 });

            // Act & Assert
            entity.Add(new Health { Value = 50 });
            Assert.True(entity.Has<Health>());

            entity.Remove<Health>();
            Assert.False(entity.Has<Health>());

            entity.Add(new Health { Value = 75 });
            Assert.True(entity.Has<Health>());
            Assert.Equal(75, entity.Get<Health>().Value);
        }

        /// <summary>
        ///     Tests that tagging does not affect components
        /// </summary>
        /// <remarks>
        ///     Tests that adding tags to an entity doesn't affect its existing components.
        /// </remarks>
        [Fact]
        public void Tagging_DoesNotAffectComponents()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 100, Y = 200 });

            // Act
            entity.Tag<PlayerTag>();

            // Assert
            Assert.True(entity.Has<Position>());
            Assert.Equal(100, entity.Get<Position>().X);
            Assert.Equal(200, entity.Get<Position>().Y);
            Assert.True(entity.Tagged<PlayerTag>());
        }

        /// <summary>
        ///     Tests that multiple entities can have same tag
        /// </summary>
        /// <remarks>
        ///     Validates that multiple entities can have the same tag simultaneously.
        /// </remarks>
        [Fact]
        public void MultipleEntities_CanHaveSameTag()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(new Position { X = 1, Y = 2 });
            GameObject entity2 = scene.Create(new Position { X = 3, Y = 4 });

            // Act
            entity1.Tag<PlayerTag>();
            entity2.Tag<PlayerTag>();

            // Assert
            Assert.True(entity1.Tagged<PlayerTag>());
            Assert.True(entity2.Tagged<PlayerTag>());
        }
        
    }
}

