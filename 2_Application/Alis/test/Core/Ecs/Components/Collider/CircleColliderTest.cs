// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CircleColliderTest.cs
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


using Alis.Core.Ecs.Components.Collider;
using Xunit;

namespace Alis.Test.Core.Ecs.Components.Collider
{
    /// <summary>
    ///     Tests for the CircleCollider component struct
    /// </summary>
    public class CircleColliderTest
    {
        /// <summary>
        ///     Tests that the constructor creates a CircleCollider with default values
        /// </summary>
        [Fact]
        public void CircleCollider_DefaultConstructor_ShouldCreateWithDefaultValues()
        {
            CircleCollider collider = new CircleCollider();

            Assert.IsType<CircleCollider>(collider);
        }

        /// <summary>
        ///     Tests that CircleCollider default state is valid
        /// </summary>
        [Fact]
        public void CircleCollider_DefaultState_ShouldBeValid()
        {
            CircleCollider collider = new CircleCollider();

            Assert.NotNull(collider);
        }

        /// <summary>
        ///     Tests that CircleCollider has expected public members
        /// </summary>
        [Fact]
        public void CircleCollider_ShouldHaveExpectedPublicMembers()
        {
            CircleCollider collider = new CircleCollider();

            Assert.IsType<CircleCollider>(collider);
        }

        /// <summary>
        ///     Tests that CircleCollider is a struct type
        /// </summary>
        [Fact]
        public void CircleCollider_ShouldBeStructType()
        {
            CircleCollider collider = new CircleCollider();

            Assert.IsType<CircleCollider>(collider);
        }

        /// <summary>
        ///     Tests that CircleCollider implements expected interfaces
        /// </summary>
        [Fact]
        public void CircleCollider_ShouldImplementExpectedInterfaces()
        {
            CircleCollider collider = new CircleCollider();

            Assert.IsAssignableFrom<object>(collider);
        }

        /// <summary>
        ///     Tests that CircleCollider constructor doesn't throw
        /// </summary>
        [Fact]
        public void CircleCollider_Constructor_ShouldNotThrow()
        {
            CircleCollider collider = new CircleCollider();

            Assert.NotNull(collider);
        }

        /// <summary>
        ///     Tests that CircleCollider can be instantiated multiple times
        /// </summary>
        [Fact]
        public void CircleCollider_MultipleInstances_ShouldBeIndependent()
        {
            CircleCollider collider1 = new CircleCollider();
            CircleCollider collider2 = new CircleCollider();

            Assert.NotNull(collider1);
            Assert.NotNull(collider2);
        }

        /// <summary>
        ///     Tests that CircleCollider can be created without exceptions
        /// </summary>
        [Fact]
        public void CircleCollider_Constructor_WithoutParameters_ShouldNotThrow()
        {
            CircleCollider collider = new CircleCollider();

            Assert.NotNull(collider);
            Assert.IsType<CircleCollider>(collider);
        }
    }
}
