// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SceneMarshalTest.cs
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

using System;
using Alis.Core.Ecs.Marshalling;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Marshalling
{
    /// <summary>
    /// The scene marshal test class
    /// </summary>
    public class SceneMarshalTest
    {
        /// <summary>
        /// Tests that get component with valid entity returns correct reference
        /// </summary>
        [Fact]
        public void GetComponent_WithValidEntity_ReturnsCorrectReference()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 10, Y = 20 });

            ref Position retrieved = ref SceneMarshal.GetComponent<Position>(scene, entity);

            Assert.Equal(10f, retrieved.X, 5);
            Assert.Equal(20f, retrieved.Y, 5);
        }

        /// <summary>
        /// Tests that get component modify through reference updates component
        /// </summary>
        [Fact]
        public void GetComponent_ModifyThroughReference_UpdatesComponent()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 10, Y = 20 });

            ref Position retrieved = ref SceneMarshal.GetComponent<Position>(scene, entity);
            retrieved.X = 100;
            retrieved.Y = 200;

            Position updated = entity.Get<Position>();
            Assert.Equal(100f, updated.X, 5);
            Assert.Equal(200f, updated.Y, 5);
        }

        /// <summary>
        /// Tests that get component with struct component works correctly
        /// </summary>
        [Fact]
        public void GetComponent_WithStructComponent_WorksCorrectly()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Health { Value = 100 });

            ref Health retrieved = ref SceneMarshal.GetComponent<Health>(scene, entity);

            Assert.Equal(100, retrieved.Value);
        }

        /// <summary>
        /// Tests that get component with multiple entities returns correct components
        /// </summary>
        [Fact]
        public void GetComponent_WithMultipleEntities_ReturnsCorrectComponents()
        {
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(new Position { X = 10, Y = 20 });
            GameObject entity2 = scene.Create(new Position { X = 30, Y = 40 });

            ref Position pos1 = ref SceneMarshal.GetComponent<Position>(scene, entity1);
            ref Position pos2 = ref SceneMarshal.GetComponent<Position>(scene, entity2);

            Assert.Equal(10f, pos1.X, 5);
            Assert.Equal(20f, pos1.Y, 5);
            Assert.Equal(30f, pos2.X, 5);
            Assert.Equal(40f, pos2.Y, 5);
        }

        /// <summary>
        /// Tests that get component modifications visible through normal access
        /// </summary>
        [Fact]
        public void GetComponent_ModificationsVisibleThroughNormalAccess()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 0, Y = 0 });

            ref Position pos = ref SceneMarshal.GetComponent<Position>(scene, entity);
            pos.X = 999;
            pos.Y = 888;

            Assert.Equal(999f, entity.Get<Position>().X, 5);
            Assert.Equal(888f, entity.Get<Position>().Y, 5);
        }

        /// <summary>
        /// Tests that get raw buffer with valid entity returns span and index
        /// </summary>
        [Fact]
        public void GetRawBuffer_WithValidEntity_ReturnsSpanAndIndex()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 5, Y = 10 });

            Span<Position> buffer = SceneMarshal.GetRawBuffer<Position>(scene, entity, out int index);

            Assert.True(buffer.Length > 0);
            Assert.True(index >= 0);
            Assert.Equal(5f, buffer[index].X, 5);
            Assert.Equal(10f, buffer[index].Y, 5);
        }

        /// <summary>
        /// Tests that get raw buffer modify through span updates component
        /// </summary>
        [Fact]
        public void GetRawBuffer_ModifyThroughSpan_UpdatesComponent()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 5, Y = 10 });

            Span<Position> buffer = SceneMarshal.GetRawBuffer<Position>(scene, entity, out int index);
            buffer[index] = new Position { X = 50, Y = 100 };

            Position updated = entity.Get<Position>();
            Assert.Equal(50f, updated.X, 5);
            Assert.Equal(100f, updated.Y, 5);
        }

        /// <summary>
        /// Tests that get raw buffer with multiple entities in same archetype works
        /// </summary>
        [Fact]
        public void GetRawBuffer_WithMultipleEntitiesInSameArchetype_Works()
        {
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(new Position { X = 1, Y = 2 });
            GameObject entity2 = scene.Create(new Position { X = 3, Y = 4 });

            Span<Position> buffer1 = SceneMarshal.GetRawBuffer<Position>(scene, entity1, out int index1);
            Span<Position> buffer2 = SceneMarshal.GetRawBuffer<Position>(scene, entity2, out int index2);

            Assert.Equal(1f, buffer1[index1].X, 5);
            Assert.Equal(2f, buffer1[index1].Y, 5);
            Assert.Equal(3f, buffer2[index2].X, 5);
            Assert.Equal(4f, buffer2[index2].Y, 5);
        }

        /// <summary>
        /// Tests that get with entity id returns correct component
        /// </summary>
        [Fact]
        public void Get_WithEntityId_ReturnsCorrectComponent()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Velocity { X = 1, Y = 2 });

            ref Velocity retrieved = ref SceneMarshal.Get<Velocity>(scene, entity.EntityID);

            Assert.Equal(1f, retrieved.X, 5);
            Assert.Equal(2f, retrieved.Y, 5);
        }

        /// <summary>
        /// Tests that get with entity id allows modification
        /// </summary>
        [Fact]
        public void Get_WithEntityId_AllowsModification()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Velocity { X = 1, Y = 2 });

            ref Velocity retrieved = ref SceneMarshal.Get<Velocity>(scene, entity.EntityID);
            retrieved.X = 10;
            retrieved.Y = 20;

            Velocity updated = entity.Get<Velocity>();
            Assert.Equal(10f, updated.X, 5);
            Assert.Equal(20f, updated.Y, 5);
        }

        /// <summary>
        /// Tests that get with multiple entity ids returns correct components
        /// </summary>
        [Fact]
        public void Get_WithMultipleEntityIds_ReturnsCorrectComponents()
        {
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(new Velocity { X = 1, Y = 2 });
            GameObject entity2 = scene.Create(new Velocity { X = 3, Y = 4 });

            ref Velocity vel1 = ref SceneMarshal.Get<Velocity>(scene, entity1.EntityID);
            ref Velocity vel2 = ref SceneMarshal.Get<Velocity>(scene, entity2.EntityID);

            Assert.Equal(1f, vel1.X, 5);
            Assert.Equal(2f, vel1.Y, 5);
            Assert.Equal(3f, vel2.X, 5);
            Assert.Equal(4f, vel2.Y, 5);
        }

        /// <summary>
        /// Tests that get with invalid entity id throws
        /// </summary>
        [Fact]
        public void Get_WithInvalidEntityId_Throws()
        {
            using Scene scene = new Scene();

            Assert.Throws<NullReferenceException>(() => SceneMarshal.Get<Position>(scene, -1));
        }

        /// <summary>
        /// Tests that get component get and set different types works
        /// </summary>
        [Fact]
        public void GetComponent_GetAndSetDifferentTypes_Works()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position { X = 1, Y = 2 },
                new Health { Value = 50 },
                new Velocity { X = 3, Y = 4 });

            ref Position pos = ref SceneMarshal.GetComponent<Position>(scene, entity);
            ref Health health = ref SceneMarshal.GetComponent<Health>(scene, entity);
            ref Velocity vel = ref SceneMarshal.GetComponent<Velocity>(scene, entity);

            Assert.Equal(1f, pos.X, 5);
            Assert.Equal(50, health.Value);
            Assert.Equal(3f, vel.X, 5);

            pos.X = 10;
            health.Value = 99;
            vel.Y = 40;

            Assert.Equal(10f, entity.Get<Position>().X, 5);
            Assert.Equal(99, entity.Get<Health>().Value);
            Assert.Equal(40f, entity.Get<Velocity>().Y, 5);
        }

        /// <summary>
        /// Tests that get raw buffer multiple buffers in different archetypes are independent
        /// </summary>
        [Fact]
        public void GetRawBuffer_MultipleBuffersInDifferentArchetypes_AreIndependent()
        {
            using Scene scene = new Scene();
            GameObject entityPos = scene.Create(new Position { X = 10, Y = 20 });
            GameObject entityVel = scene.Create(new Velocity { X = 30, Y = 40 });

            Span<Position> posBuffer = SceneMarshal.GetRawBuffer<Position>(scene, entityPos, out int posIndex);
            Span<Velocity> velBuffer = SceneMarshal.GetRawBuffer<Velocity>(scene, entityVel, out int velIndex);

            Assert.Equal(10f, posBuffer[posIndex].X, 5);
            Assert.Equal(20f, posBuffer[posIndex].Y, 5);
            Assert.Equal(30f, velBuffer[velIndex].X, 5);
            Assert.Equal(40f, velBuffer[velIndex].Y, 5);
        }

        /// <summary>
        /// Tests that get raw buffer buffer length reflects archetype capacity
        /// </summary>
        [Fact]
        public void GetRawBuffer_BufferLengthReflectsArchetypeCapacity()
        {
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(new Position { X = 1, Y = 2 });
            scene.Create(new Position { X = 3, Y = 4 });

            Span<Position> buffer = SceneMarshal.GetRawBuffer<Position>(scene, entity1, out int index);

            Assert.Equal(2, buffer.Length);
            Assert.True(index >= 0);
            Assert.Equal(1f, buffer[0].X, 5);
            Assert.Equal(3f, buffer[1].X, 5);
        }
    }
}
