// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ControllerDelegateTest.cs
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
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Controllers;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    /// The controller delegate test class
    /// </summary>
    public class ControllerDelegateTest
    {
        /// <summary>
        /// Tests that delegate should be invokable
        /// </summary>
        [Fact]
        public void Delegate_ShouldBeInvokable()
        {
            WorldPhysic capturedWorld = null;
            Controller capturedController = null;
            ControllerDelegate callback = (world, controller) =>
            {
                capturedWorld = world;
                capturedController = controller;
            };

            WorldPhysic sender = new WorldPhysic(Vector2F.Zero);
            GravityController controllerArg = new GravityController(1.0f);

            callback(sender, controllerArg);

            Assert.Equal(sender, capturedWorld);
            Assert.Equal(controllerArg, capturedController);
        }

        /// <summary>
        ///     Tests that chaining multiple handlers should call all
        /// </summary>
        [Fact]
        public void Chaining_ShouldCallAllHandlers()
        {
            int callCount = 0;
            ControllerDelegate first = (w, c) => { callCount++; };
            ControllerDelegate second = (w, c) => { callCount++; };

            ControllerDelegate chain = first + second;
            chain(null, null);

            Assert.Equal(2, callCount);
        }
    }
}
