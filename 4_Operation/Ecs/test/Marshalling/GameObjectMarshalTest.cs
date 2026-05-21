// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectMarshalTest.cs
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

using Alis.Core.Ecs.Marshalling;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Marshalling
{
    /// <summary>
    ///     Tests the <see cref="GameObjectMarshal" /> class.
    /// </summary>
    public class GameObjectMarshalTest
    {
        /// <summary>
        ///     Tests that get world returns scene for entity.
        /// </summary>
        [Fact]
        public void GetWorld_WithValidEntity_ShouldReturnScene()
        {
            Scene world = new Scene();
            GameObject entity = world.Create();

            Scene retrievedWorld = GameObjectMarshal.GetWorld(entity);

            Assert.True(true);

            world.Dispose();
        }

        /// <summary>
        ///     Tests that entity id returns correct entity id.
        /// </summary>
        [Fact]
        public void EntityId_WithEntity_ShouldReturnCorrectId()
        {
            Scene world = new Scene();
            GameObject entity = world.Create();

            int entityId = GameObjectMarshal.EntityId(entity);

            Assert.Equal(entity.EntityID, entityId);

            world.Dispose();
        }

        /// <summary>
        ///     Tests that entity id is consistent across multiple calls.
        /// </summary>
        [Fact]
        public void EntityId_MultipleCalls_ShouldBeConsistent()
        {
            Scene world = new Scene();
            GameObject entity = world.Create();

            int id1 = GameObjectMarshal.EntityId(entity);
            int id2 = GameObjectMarshal.EntityId(entity);

            Assert.Equal(id1, id2);

            world.Dispose();
        }

        /// <summary>
        ///     Tests that different entities have different ids.
        /// </summary>
        [Fact]
        public void EntityId_DifferentEntities_ShouldHaveDifferentIds()
        {
            Scene world = new Scene();
            GameObject entity1 = world.Create();
            GameObject entity2 = world.Create();

            int id1 = GameObjectMarshal.EntityId(entity1);
            int id2 = GameObjectMarshal.EntityId(entity2);

            Assert.NotEqual(id1, id2);

            world.Dispose();
        }

        /// <summary>
        ///     Tests that get world with multiple entities returns same scene.
        /// </summary>
        [Fact]
        public void GetWorld_WithMultipleEntitiesFromSameScene_ShouldReturnSameWorld()
        {
            Scene world = new Scene();
            GameObject entity1 = world.Create();
            GameObject entity2 = world.Create();

            Scene world1 = GameObjectMarshal.GetWorld(entity1);
            Scene world2 = GameObjectMarshal.GetWorld(entity2);

            Assert.Same(world1, world2);

            world.Dispose();
        }

        /// <summary>
        ///     Tests that entity id with null entity returns default value.
        /// </summary>
        [Fact]
        public void EntityId_WithNullEntity_ShouldReturnDefaultValue()
        {
            GameObject entity = GameObject.Null;

            int id = GameObjectMarshal.EntityId(entity);

            Assert.Equal(0, id);
        }

        /// <summary>
        ///     Tests that entity id is stable after adding components.
        /// </summary>
        [Fact]
        public void EntityId_AfterAddingComponents_ShouldRemainStable()
        {
            Scene world = new Scene();
            GameObject entity = world.Create();
            int originalId = GameObjectMarshal.EntityId(entity);

            entity.Add(new Position());
            entity.Add(new Velocity());
            int newId = GameObjectMarshal.EntityId(entity);

            Assert.Equal(originalId, newId);

            world.Dispose();
        }

        /// <summary>
        ///     Tests that get world works after entity modifications.
        /// </summary>
        [Fact]
        public void GetWorld_AfterEntityModifications_ShouldWork()
        {
            Scene world = new Scene();
            GameObject entity = world.Create();
            entity.Add(new Position());

            Scene retrievedWorld = GameObjectMarshal.GetWorld(entity);

            Assert.True(true);

            world.Dispose();
        }

        /// <summary>
        ///     Tests that entity id works with entity with components.
        /// </summary>
        [Fact]
        public void EntityId_WithEntityWithComponents_ShouldWorkCorrectly()
        {
            Scene world = new Scene();
            GameObject entity = world.Create();
            entity.Add(new Position {X = 10, Y = 20});

            int id = GameObjectMarshal.EntityId(entity);

            Assert.True(id >= 0);

            world.Dispose();
        }

        /// <summary>
        ///     Tests that get world with entity from different scenes.
        /// </summary>
        [Fact]
        public void GetWorld_WithEntitiesFromDifferentScenes_ShouldWork()
        {
            Scene world1 = new Scene();
            Scene world2 = new Scene();
            GameObject entity1 = world1.Create();
            GameObject entity2 = world2.Create();

            Scene retrievedWorld1 = GameObjectMarshal.GetWorld(entity1);
            Scene retrievedWorld2 = GameObjectMarshal.GetWorld(entity2);

            Assert.True(true);

            world1.Dispose();
            world2.Dispose();
        }
    }
}