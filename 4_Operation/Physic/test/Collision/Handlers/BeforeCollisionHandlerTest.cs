// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BeforeCollisionHandlerTest.cs
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
using Alis.Core.Physic.Collision.Filtering;
using Alis.Core.Physic.Collision.Handlers;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Collision.Handlers
{
    /// <summary>
    /// The before collision handler test class
    /// </summary>
    public class BeforeCollisionHandlerTest
    {
        /// <summary>
        /// Tests that before collision handler invocation test
        /// </summary>
        [Fact]
        public void BeforeCollisionHandlerInvocationTest()
        {
            // Arrange
            bool isHandlerInvoked = false;
            Action<Fixture, Fixture> handler = (fixtureA, fixtureB) => { isHandlerInvoked = true; };
            
            Fixture fixtureA =  new Fixture(new CircleShape(1, 1), new Filter(), 0.3f, 0.1f, 1.5f, true);
            Fixture fixtureB =  new Fixture(new CircleShape(1, 1), new Filter(), 0.3f, 0.1f, 1.5f, true);
            
            // Act
            handler(fixtureA, fixtureB);
            
            // Assert
            Assert.True(isHandlerInvoked);
        }
    }
}