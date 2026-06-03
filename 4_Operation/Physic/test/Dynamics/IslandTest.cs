// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IslandTest.cs
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

using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    /// The island test class
    /// </summary>
    public class IslandTest
    {
        /// <summary>
        /// Tests that island type should be accessible
        /// </summary>
        [Fact]
        public void Island_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(Island));
        }

        /// <summary>
        /// Tests that reset should set counts to zero
        /// </summary>
        [Fact]
        public void Reset_ShouldSetCountsToZero()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            ContactManager contactManager = world.ContactManager;
            Island island = new Island();

            island.Reset(2, 2, 2, contactManager);

            Assert.Equal(0, island.BodyCount);
            Assert.Equal(0, island.ContactCount);
            Assert.Equal(0, island.JointCount);
        }

        /// <summary>
        /// Tests that reset should allocate buffers with minimum capacity
        /// </summary>
        [Fact]
        public void Reset_ShouldAllocateBuffersWithMinimumCapacity()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            ContactManager contactManager = world.ContactManager;
            Island island = new Island();

            island.Reset(1, 1, 1, contactManager);

            Assert.NotNull(island.Bodies);
            Assert.True(island.Bodies.Length >= 32);
        }

        /// <summary>
        /// Tests that clear should reset all counts to zero
        /// </summary>
        [Fact]
        public void Clear_ShouldResetAllCountsToZero()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            ContactManager contactManager = world.ContactManager;
            Island island = new Island();
            island.Reset(4, 4, 4, contactManager);

            island.Clear();

            Assert.Equal(0, island.BodyCount);
            Assert.Equal(0, island.ContactCount);
            Assert.Equal(0, island.JointCount);
        }

        /// <summary>
        /// Tests that add body should increment body count
        /// </summary>
        [Fact]
        public void AddBody_ShouldIncrementBodyCount()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            ContactManager contactManager = world.ContactManager;
            Island island = new Island();
            island.Reset(4, 4, 4, contactManager);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Static);

            island.Add(body);

            Assert.Equal(1, island.BodyCount);
        }

        /// <summary>
        /// Tests that dispose should not throw
        /// </summary>
        [Fact]
        public void Dispose_ShouldNotThrow()
        {
            Island island = new Island();

            System.Exception ex = Record.Exception(() => island.Dispose());

            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that dispose called twice should not throw
        /// </summary>
        [Fact]
        public void Dispose_CalledTwice_ShouldNotThrow()
        {
            Island island = new Island();

            island.Dispose();
            System.Exception ex = Record.Exception(() => island.Dispose());

            Assert.Null(ex);
        }
    }
}

