// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ControllerCollectionTest.cs
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
using System.Collections.Generic;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Controllers;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    /// The controller collection test class
    /// </summary>
    public class ControllerCollectionTest
    {
        /// <summary>
        /// Tests that collection should expose controllers added through world
        /// </summary>
        [Fact]
        public void Collection_ShouldExposeControllersAddedThroughWorld()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            GravityController controller = new GravityController(1.0f);

            world.Add(controller);

            Assert.Single(world.ControllerList);
            Assert.True(world.ControllerList.Contains(controller));
        }

        /// <summary>
        /// Tests that collection should be read only from i collection interface
        /// </summary>
        [Fact]
        public void Collection_ShouldBeReadOnlyFromICollectionInterface()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            ControllerCollection collection = world.ControllerList;

            Assert.True(collection.IsReadOnly);
            Assert.Throws<NotSupportedException>(() => ((ICollection<Controller>) collection).Add(new GravityController(1.0f)));
            Assert.Throws<NotSupportedException>(() => ((ICollection<Controller>) collection).Clear());
        }

        /// <summary>
        /// Tests that collection enumerator should iterate all controllers
        /// </summary>
        [Fact]
        public void Collection_Enumerator_ShouldIterateAllControllers()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.Add(new GravityController(1.0f));
            world.Add(new VelocityLimitController());

            int count = 0;
            foreach (Controller _ in world.ControllerList)
            {
                count++;
            }

            Assert.Equal(2, count);
        }
    }
}

