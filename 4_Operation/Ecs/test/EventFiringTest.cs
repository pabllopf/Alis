// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EventFiringTest.cs
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

using System.Collections.Generic;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Tests for event firing during entity lifecycle
    /// </summary>
    /// <remarks>
    ///     Validates that events are fired correctly when entities are created,
    ///     components are added/removed, and entities are deleted.
    /// </remarks>
    public class EventFiringTest
    {
        /// <summary>
        ///     Tests entity created event fires
        /// </summary>
        [Fact]
        public void Scene_EntityCreatedEventFires()
        {
            // Arrange
            using var scene = new Scene();
            int eventCount = 0;
            GameObject createdEntity = default;

            scene.EntityCreated += entity =>
            {
                eventCount++;
                createdEntity = entity;
            };

            // Act
            GameObject entity = scene.Create(new Position());

            // Assert
            Assert.Equal(1, eventCount);
            Assert.Equal(entity.EntityID, createdEntity.EntityID);
        }

        /// <summary>
        ///     Tests entity deleted event fires
        /// </summary>
        [Fact]
        public void Scene_EntityDeletedEventFires()
        {
            // Arrange
            using var scene = new Scene();
            GameObject entity = scene.Create();
            int eventCount = 0;

            scene.EntityDeleted += _ => eventCount++;

            // Act
            entity.Delete();

            // Assert
            Assert.Equal(1, eventCount);
        }

        /// <summary>
        ///     Tests component added event fires
        /// </summary>
        [Fact]
        public void Scene_ComponentAddedEventFires()
        {
            // Arrange
            using var scene = new Scene();
            GameObject entity = scene.Create();
            int eventCount = 0;
            ComponentId firedComponentId = default;

            scene.ComponentAdded += (go, componentId) =>
            {
                if (go == entity)
                {
                    eventCount++;
                    firedComponentId = componentId;
                }
            };

            // Act
            entity.Add(new Position { X = 10 });

            // Assert
            Assert.Equal(1, eventCount);
            Assert.Equal(Component<Position>.Id, firedComponentId);
        }

        /// <summary>
        ///     Tests component removed event fires
        /// </summary>
        [Fact]
        public void Scene_ComponentRemovedEventFires()
        {
            // Arrange
            using var scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 10 });
            int eventCount = 0;
            ComponentId firedComponentId = default;

            scene.ComponentRemoved += (go, componentId) =>
            {
                if (go == entity)
                {
                    eventCount++;
                    firedComponentId = componentId;
                }
            };

            // Act
            entity.Remove<Position>();

            // Assert
            Assert.Equal(1, eventCount);
            Assert.Equal(Component<Position>.Id, firedComponentId);
        }

        /// <summary>
        ///     Tests multiple events are tracked correctly
        /// </summary>
        [Fact]
        public void Scene_MultipleEventsAreTrackedCorrectly()
        {
            // Arrange
            using var scene = new Scene();
            int createdCount = 0;
            int deletedCount = 0;
            int componentAddedCount = 0;

            scene.EntityCreated += _ => createdCount++;
            scene.EntityDeleted += _ => deletedCount++;
            scene.ComponentAdded += (_, __) => componentAddedCount++;

            // Act
            scene.Create();
            scene.Create(new Position());
            _ = scene.Create(); // Create first entity and discard
            _ = scene.Create(); // Create second entity and discard

            // Assert
            Assert.Equal(4, createdCount);
            Assert.Equal(0, deletedCount);
            Assert.Equal(0, componentAddedCount); // entity2 created with Position, entity1 added Health
        }

        /// <summary>
        ///     Tests event listener can be removed
        /// </summary>
        [Fact]
        public void Scene_EventListenerCanBeRemoved()
        {
            // Arrange
            using var scene = new Scene();
            int eventCount = 0;

            void Handler(GameObject _) => eventCount++;

            scene.EntityCreated += Handler;
            GameObject entity1 = scene.Create();
            Assert.Equal(1, eventCount);

            // Act
            scene.EntityCreated -= Handler;
            GameObject entity2 = scene.Create();

            // Assert
            Assert.Equal(1, eventCount); // Should still be 1
        }

        /// <summary>
        ///     Tests multiple listeners receive same event
        /// </summary>
        [Fact]
        public void Scene_MultipleListenersReceiveSameEvent()
        {
            // Arrange
            using var scene = new Scene();
            int listener1Count = 0;
            int listener2Count = 0;

            scene.EntityCreated += _ => listener1Count++;
            scene.EntityCreated += _ => listener2Count++;

            // Act
            scene.Create();

            // Assert
            Assert.Equal(1, listener1Count);
            Assert.Equal(1, listener2Count);
        }

        /// <summary>
        ///     Tests component events include correct component ID
        /// </summary>
        [Fact]
        public void Scene_ComponentEventsIncludeCorrectComponentId()
        {
            // Arrange
            using var scene = new Scene();
            GameObject entity = scene.Create();
            var addedComponentIds = new List<ComponentId>();

            scene.ComponentAdded += (_, componentId) => addedComponentIds.Add(componentId);

            // Act
            entity.Add(new Position());
            entity.Add(new Health());
            entity.Add(new Velocity());

            // Assert
            Assert.Equal(3, addedComponentIds.Count);
            Assert.Contains(Component<Position>.Id, addedComponentIds);
            Assert.Contains(Component<Health>.Id, addedComponentIds);
            Assert.Contains(Component<Velocity>.Id, addedComponentIds);
        }
    }
}

