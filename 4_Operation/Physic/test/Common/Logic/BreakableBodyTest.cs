// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BreakableBodyTest.cs
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
using System.Reflection;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Common.Logic;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Contacts;
using Moq;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Logic
{
    /// <summary>
    /// The breakable body test class
    /// </summary>
    public class BreakableBodyTest
    {
        /// <summary>
        /// Tests that breakable body type should be accessible
        /// </summary>
        [Fact]
        public void BreakableBody_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(BreakableBody));
        }

        /// <summary>
        /// Tests that parts list should be initialized with capacity 8
        /// </summary>
        [Fact]
        public void BreakableBody_PartsShouldBeInitializedWithDefaultCapacity()
        {
            Mock<WorldPhysic> mockWorld = new Mock<WorldPhysic>();

            BreakableBody breakableBody = CreateBreakableBody(mockWorld.Object);

            Assert.Equal(8, breakableBody.Parts.Capacity);
            Assert.Empty(breakableBody.Parts);
        }

        /// <summary>
        /// Tests that strength should have default value of 500.0f
        /// </summary>
        [Fact]
        public void BreakableBody_StrengthShouldHaveDefault500()
        {
            Mock<WorldPhysic> mockWorld = new Mock<WorldPhysic>();

            BreakableBody breakableBody = CreateBreakableBody(mockWorld.Object);

            Assert.Equal(500.0f, breakableBody.Strength);
        }

        /// <summary>
        /// Tests that world property should return the provided world
        /// </summary>
        [Fact]
        public void BreakableBody_WorldPropertyShouldReturnProvidedWorld()
        {
            WorldPhysic world = new Mock<WorldPhysic>().Object;

            BreakableBody breakableBody = CreateBreakableBody(world);

            Assert.Same(world, breakableBody.WorldPhysic);
        }

        /// <summary>
        /// Tests that main body property should be set from constructor
        /// </summary>
        [Fact]
        public void BreakableBody_MainBodyPropertyShouldBeSetFromConstructor()
        {
            Mock<WorldPhysic> mockWorld = new Mock<WorldPhysic>();
            Mock<Body> mockBody = new Mock<Body>();

            mockWorld.Setup(w => w.CreateBody(It.IsAny<Vector2F>(), It.IsAny<float>(), It.IsAny<BodyType>()))
                .Returns(mockBody.Object);

            List<Alis.Core.Physic.Common.Vertices> vertices = new List<Alis.Core.Physic.Common.Vertices>
            {
                new Alis.Core.Physic.Common.Vertices(new[]
                {
                    new Vector2F(0f, 0f),
                    new Vector2F(1f, 0f),
                    new Vector2F(1f, 1f),
                    new Vector2F(0f, 1f)
                })
            };

            BreakableBody breakableBody = new BreakableBody(mockWorld.Object, vertices, 1.0f);

            Assert.NotNull(breakableBody.MainBody);
        }

        /// <summary>
        /// Tests that state should default to Unbroken
        /// </summary>
        [Fact]
        public void BreakableBody_StateShouldDefaultToUnbroken()
        {
            Mock<WorldPhysic> mockWorld = new Mock<WorldPhysic>();

            BreakableBody breakableBody = CreateBreakableBody(mockWorld.Object);

            Assert.Equal(BreakableBodyState.Unbroken, breakableBody.State);
        }

        /// <summary>
        /// Tests that state property can be set to ShouldBreak
        /// </summary>
        [Fact]
        public void BreakableBody_StateShouldBeSettableToShouldBreak()
        {
            Mock<WorldPhysic> mockWorld = new Mock<WorldPhysic>();

            BreakableBody breakableBody = CreateBreakableBody(mockWorld.Object);

            breakableBody.State = BreakableBodyState.ShouldBreak;

            Assert.Equal(BreakableBodyState.ShouldBreak, breakableBody.State);
        }

        /// <summary>
        /// Tests that state property can be set to Broken
        /// </summary>
        [Fact]
        public void BreakableBody_StateShouldBeSettableToBroken()
        {
            Mock<WorldPhysic> mockWorld = new Mock<WorldPhysic>();

            BreakableBody breakableBody = CreateBreakableBody(mockWorld.Object);

            breakableBody.State = BreakableBodyState.Broken;

            Assert.Equal(BreakableBodyState.Broken, breakableBody.State);
        }

        /// <summary>
        /// Tests that Update in Unbroken state executes CacheVelocities without error
        /// </summary>
        [Fact]
        public void BreakableBody_Update_WhenUnbroken_ShouldExecuteCacheVelocities()
        {
            Mock<WorldPhysic> mockWorld = new Mock<WorldPhysic>();

            BreakableBody breakableBody = CreateBreakableBody(mockWorld.Object);

            breakableBody.Update();
        }

        /// <summary>
        /// Tests that BreakableBody can be created with a single Vertices
        /// </summary>
        [Fact]
        public void BreakableBody_ShouldCreateFromSingleVertices()
        {
            Mock<WorldPhysic> mockWorld = new Mock<WorldPhysic>();
            Mock<Body> mockBody = new Mock<Body>();

            mockWorld.Setup(w => w.CreateBody(It.IsAny<Vector2F>(), It.IsAny<float>(), It.IsAny<BodyType>()))
                .Returns(mockBody.Object);

            Alis.Core.Physic.Common.Vertices vertices = new Alis.Core.Physic.Common.Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(1f, 1f)
            });

            BreakableBody breakableBody = new BreakableBody(mockWorld.Object, vertices, 1.0f);

            Assert.NotNull(breakableBody.MainBody);
            Assert.Equal(1, breakableBody.Parts.Count);
        }

        /// <summary>
        /// Creates the breakable body using the specified world
        /// </summary>
        /// <param name="world">The world</param>
        /// <returns>The breakable body</returns>
        private static BreakableBody CreateBreakableBody(WorldPhysic world)
        {
            ConstructorInfo ctor = typeof(BreakableBody).GetConstructor(
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance,
                null,
                new[] { typeof(WorldPhysic) },
                null);

            return (BreakableBody)ctor.Invoke(new[] { world });
        }
    }
}
