// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ControllerEnumeratorTest.cs
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
using System.Collections;
using System.Collections.Generic;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Controllers;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    /// The controller enumerator test class
    /// </summary>
    public class ControllerEnumeratorTest
    {
        /// <summary>
        /// Tests that move next and current should enumerate controllers
        /// </summary>
        [Fact]
        public void MoveNext_AndCurrent_ShouldEnumerateControllers()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            GravityController first = new GravityController(1.0f);
            GravityController second = new GravityController(2.0f);
            world.Add(first);
            world.Add(second);

            using ControllerEnumerator enumerator = world.ControllerList.GetEnumerator();

            Assert.True(enumerator.MoveNext());
            Assert.Equal(first, enumerator.Current);
            Assert.True(enumerator.MoveNext());
            Assert.Equal(second, enumerator.Current);
            Assert.False(enumerator.MoveNext());
        }

        /// <summary>
        /// Tests that move next should throw when collection was modified
        /// </summary>
        [Fact]
        public void MoveNext_ShouldThrow_WhenCollectionWasModified()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.Add(new GravityController(1.0f));
            using ControllerEnumerator enumerator = world.ControllerList.GetEnumerator();

            world.Add(new GravityController(2.0f));

            Assert.Throws<InvalidOperationException>(() => enumerator.MoveNext());
        }

        /// <summary>
        /// Tests that generic i enumerable get enumerator returns typed enumerator
        /// </summary>
        [Fact]
        public void GenericEnumerable_GetEnumerator_ReturnsTypedEnumerator()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.Add(new GravityController(1.0f));

            IEnumerator<Controller> enumerator = ((IEnumerable<Controller>)world.ControllerList).GetEnumerator();

            using (enumerator)
            {
                Assert.True(enumerator.MoveNext());
                Assert.NotNull(enumerator.Current);
            }
        }

        /// <summary>
        /// Tests that non generic i enumerable get enumerator returns enumerator
        /// </summary>
        [Fact]
        public void NonGenericEnumerable_GetEnumerator_ReturnsEnumerator()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.Add(new GravityController(1.0f));

            IEnumerator enumerator = ((IEnumerable)world.ControllerList).GetEnumerator();

            Assert.True(enumerator.MoveNext());
            Assert.NotNull(enumerator.Current);
        }

        /// <summary>
        /// Tests that generic i enumerator current returns correct controller
        /// </summary>
        [Fact]
        public void GenericEnumerator_Current_ReturnsCorrectController()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            GravityController controller = new GravityController(1.0f);
            world.Add(controller);
            IEnumerator<Controller> enumerator = ((IEnumerable<Controller>)world.ControllerList).GetEnumerator();

            enumerator.MoveNext();

            Assert.Equal(controller, enumerator.Current);
        }

        /// <summary>
        /// Tests that non generic i enumerator current returns correct controller
        /// </summary>
        [Fact]
        public void NonGenericEnumerator_Current_ReturnsCorrectController()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            GravityController controller = new GravityController(1.0f);
            world.Add(controller);
            IEnumerator enumerator = ((IEnumerable)world.ControllerList).GetEnumerator();

            enumerator.MoveNext();

            Assert.Equal(controller, enumerator.Current);
        }

        /// <summary>
        /// Tests that i enumerator reset resets enumerator
        /// </summary>
        [Fact]
        public void IEnumerator_Reset_ResetsEnumerator()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.Add(new GravityController(1.0f));
            world.Add(new GravityController(2.0f));
            IEnumerator enumerator = ((IEnumerable)world.ControllerList).GetEnumerator();

            enumerator.MoveNext();
            enumerator.Reset();
            enumerator.MoveNext();

            Assert.NotNull(enumerator.Current);
        }

        /// <summary>
        /// Tests that generic i enumerator current throws when collection modified
        /// </summary>
        [Fact]
        public void GenericEnumerator_Current_WhenCollectionModified_ThrowsInvalidOperation()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.Add(new GravityController(1.0f));
            IEnumerator<Controller> enumerator = ((IEnumerable<Controller>)world.ControllerList).GetEnumerator();

            world.Add(new GravityController(2.0f));

            Assert.Throws<InvalidOperationException>(() => enumerator.Current);
        }

        /// <summary>
        /// Tests that non generic i enumerator current throws when collection modified
        /// </summary>
        [Fact]
        public void NonGenericEnumerator_Current_WhenCollectionModified_ThrowsInvalidOperation()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.Add(new GravityController(1.0f));
            IEnumerator enumerator = ((IEnumerable)world.ControllerList).GetEnumerator();

            world.Add(new GravityController(2.0f));

            Assert.Throws<InvalidOperationException>(() => enumerator.Current);
        }

        /// <summary>
        /// Tests that enumerator reset then enumerate works
        /// </summary>
        [Fact]
        public void ResetThenEnumerate_Works()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.Add(new GravityController(1.0f));
            world.Add(new GravityController(2.0f));
            IEnumerator enumerator = world.ControllerList.GetEnumerator();

            enumerator.MoveNext();
            enumerator.MoveNext();
            Assert.False(enumerator.MoveNext());

            enumerator.Reset();
            Assert.True(enumerator.MoveNext());
        }

        /// <summary>
        /// Tests that dispose does not throw
        /// </summary>
        [Fact]
        public void Dispose_DoesNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.Add(new GravityController(1.0f));
            ControllerEnumerator enumerator = world.ControllerList.GetEnumerator();

            ((IDisposable)enumerator).Dispose();
        }

    }
}

