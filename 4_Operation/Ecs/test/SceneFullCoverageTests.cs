// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SceneFullCoverageTests.cs
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
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Alis.Core.Ecs.Updating;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     The scene full coverage tests class
    /// </summary>
    public class SceneFullCoverageTests
    {
        /// <summary>
        ///     Tests that create many two components with listeners invokes entity created event
        /// </summary>
        [Fact]
        public void CreateMany_TwoComponents_WithListeners_InvokesEvent()
        {
            using (Scene scene = new Scene())
            {
                int callCount = 0;
                scene.EntityCreated += _ => callCount++;

                ChunkTuple<Position, Health> chunk = scene.CreateMany<Position, Health>(3);

                Assert.Equal(3, callCount);
                Assert.Equal(3, chunk.Span1.Length);
                Assert.Equal(3, chunk.Span2.Length);
            }
        }

        /// <summary>
        ///     Tests that create many three components with listeners invokes entity created event
        /// </summary>
        [Fact]
        public void CreateMany_ThreeComponents_WithListeners_InvokesEvent()
        {
            using (Scene scene = new Scene())
            {
                int callCount = 0;
                scene.EntityCreated += _ => callCount++;

                ChunkTuple<Position, Health, Velocity> chunk = scene.CreateMany<Position, Health, Velocity>(2);

                Assert.Equal(2, callCount);
                Assert.Equal(2, chunk.Span3.Length);
            }
        }

        /// <summary>
        ///     Tests that create many three components with zero count throws
        /// </summary>
        [Fact]
        public void CreateMany_ThreeComponents_WithZeroCount_Throws()
        {
            using (Scene scene = new Scene())
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => scene.CreateMany<Position, Health, Velocity>(0));
            }
        }

        /// <summary>
        ///     Tests that create many four components with zero count throws
        /// </summary>
        [Fact]
        public void CreateMany_FourComponents_WithZeroCount_Throws()
        {
            using (Scene scene = new Scene())
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => scene.CreateMany<Position, Health, Velocity, Damage>(0));
            }
        }

        /// <summary>
        ///     Tests that create many four components with listeners invokes entity created event
        /// </summary>
        [Fact]
        public void CreateMany_FourComponents_WithListeners_InvokesEvent()
        {
            using (Scene scene = new Scene())
            {
                int callCount = 0;
                scene.EntityCreated += _ => callCount++;

                ChunkTuple<Position, Health, Velocity, Damage> chunk = scene.CreateMany<Position, Health, Velocity, Damage>(2);

                Assert.Equal(2, callCount);
                Assert.Equal(2, chunk.Span4.Length);
            }
        }

        /// <summary>
        ///     Tests that create many five components with zero count throws
        /// </summary>
        [Fact]
        public void CreateMany_FiveComponents_WithZeroCount_Throws()
        {
            using (Scene scene = new Scene())
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => scene.CreateMany<Position, Health, Velocity, Damage, Armor>(0));
            }
        }

        /// <summary>
        ///     Tests that create many five components with listeners invokes entity created event
        /// </summary>
        [Fact]
        public void CreateMany_FiveComponents_WithListeners_InvokesEvent()
        {
            using (Scene scene = new Scene())
            {
                int callCount = 0;
                scene.EntityCreated += _ => callCount++;

                ChunkTuple<Position, Health, Velocity, Damage, Armor> chunk = scene.CreateMany<Position, Health, Velocity, Damage, Armor>(2);

                Assert.Equal(2, callCount);
                Assert.Equal(2, chunk.Span5.Length);
            }
        }

        /// <summary>
        ///     Tests that create many six components with zero count throws
        /// </summary>
        [Fact]
        public void CreateMany_SixComponents_WithZeroCount_Throws()
        {
            using (Scene scene = new Scene())
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => scene.CreateMany<Position, Health, Velocity, Damage, Armor, Transform>(0));
            }
        }

        /// <summary>
        ///     Tests that create many six components with listeners invokes entity created event
        /// </summary>
        [Fact]
        public void CreateMany_SixComponents_WithListeners_InvokesEvent()
        {
            using (Scene scene = new Scene())
            {
                int callCount = 0;
                scene.EntityCreated += _ => callCount++;

                ChunkTuple<Position, Health, Velocity, Damage, Armor, Transform> chunk = scene.CreateMany<Position, Health, Velocity, Damage, Armor, Transform>(2);

                Assert.Equal(2, callCount);
                Assert.Equal(2, chunk.Span6.Length);
            }
        }

        /// <summary>
        ///     Tests that create many seven components with zero count throws
        /// </summary>
        [Fact]
        public void CreateMany_SevenComponents_WithZeroCount_Throws()
        {
            using (Scene scene = new Scene())
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => scene.CreateMany<Position, Health, Velocity, Damage, Armor, Transform, TestStruct>(0));
            }
        }

        /// <summary>
        ///     Tests that create many seven components with listeners invokes entity created event
        /// </summary>
        [Fact]
        public void CreateMany_SevenComponents_WithListeners_InvokesEvent()
        {
            using (Scene scene = new Scene())
            {
                int callCount = 0;
                scene.EntityCreated += _ => callCount++;

                ChunkTuple<Position, Health, Velocity, Damage, Armor, Transform, TestStruct> chunk = scene.CreateMany<Position, Health, Velocity, Damage, Armor, Transform, TestStruct>(2);

                Assert.Equal(2, callCount);
                Assert.Equal(2, chunk.Span7.Length);
            }
        }

        /// <summary>
        ///     Tests that create many eight components with listeners invokes entity created event
        /// </summary>
        [Fact]
        public void CreateMany_EightComponents_WithListeners_InvokesEvent()
        {
            using (Scene scene = new Scene())
            {
                int callCount = 0;
                scene.EntityCreated += _ => callCount++;

                ChunkTuple<Position, Health, Velocity, Damage, Armor, Transform, TestStruct, TagComponent> chunk = scene.CreateMany<Position, Health, Velocity, Damage, Armor, Transform, TestStruct, TagComponent>(2);

                Assert.Equal(2, callCount);
                Assert.Equal(2, chunk.Span8.Length);
            }
        }

        /// <summary>
        ///     Tests that the update filter archetype added is invoked for registered attribute updates
        /// </summary>
        [Fact]
        public void UpdateFilter_ArchetypeAdded_InvokedForAttributeUpdates()
        {
            using (Scene scene = new Scene())
            {
                scene.Update<FullCoverageUpdateAttribute>();
                scene.Create(new Position {X = 1, Y = 2});
                scene.Create(new Position {X = 3, Y = 4});
                scene.Create(new Health {Value = 10});
            }
        }

        /// <summary>
        ///     Tests that the single component update filter archetype added is invoked
        /// </summary>
        [Fact]
        public void SingleComponentUpdateFilter_ArchetypeAdded_Invoked()
        {
            using (Scene scene = new Scene())
            {
                scene.UpdateComponent(Component<Position>.Id);
                scene.Create(new Position {X = 1, Y = 2});
                scene.Create(new Health {Value = 10});
            }
        }

        /// <summary>
        ///     Tests that ensure capacity with a valid count allocates the archetype capacity
        /// </summary>
        [Fact]
        public void EnsureCapacity_WithValidCount_AllocatesCapacity()
        {
            using (Scene scene = new Scene())
            {
                GameObjectType entityType = scene.Create(new Position {X = 1, Y = 2}).Type;

                scene.EnsureCapacity(entityType, 5);
            }
        }

        /// <summary>
        ///     Tests that a dead game object throws when its location is accessed
        /// </summary>
        [Fact]
        public void DeadGameObject_AccessLocation_Throws()
        {
            using (Scene scene = new Scene())
            {
                GameObject gameObject = scene.Create(new Position {X = 1, Y = 2});
                gameObject.Delete();

                Assert.ThrowsAny<Exception>(() => gameObject.Get<Position>());
            }
        }
    }

    /// <summary>
    ///     The update attribute used for testing update filter registration
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    internal sealed class FullCoverageUpdateAttribute : UpdateTypeAttribute;
}
