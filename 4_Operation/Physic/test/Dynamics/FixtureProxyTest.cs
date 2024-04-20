// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FixtureProxyTest.cs
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
using Alis.Core.Physic.Collision.Filtering;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Shared;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    /// The fixture proxy test class
    /// </summary>
    public class FixtureProxyTest
    {
        /// <summary>
        /// Tests that aabb property test
        /// </summary>
        [Fact]
        public void AabbPropertyTest()
        {
            // Arrange
            Aabb aabb = new Aabb(new Vector2(0, 0), new Vector2(1, 1));
            FixtureProxy fixtureProxy = new FixtureProxy();
            
            // Act
            fixtureProxy.Aabb = aabb;
            
            // Assert
            Assert.Equal(aabb, fixtureProxy.Aabb);
        }
        
        /// <summary>
        /// Tests that child index property test
        /// </summary>
        [Fact]
        public void ChildIndexPropertyTest()
        {
            // Arrange
            int childIndex = 1;
            FixtureProxy fixtureProxy = new FixtureProxy();
            
            // Act
            fixtureProxy.ChildIndex = childIndex;
            
            // Assert
            Assert.Equal(childIndex, fixtureProxy.ChildIndex);
        }
        
        /// <summary>
        /// Tests that fixture constructor test
        /// </summary>
        [Fact]
        public void FixtureConstructorTest()
        {
            // Arrange
            CircleShape circle = new CircleShape(1, 1.0f); // Replace with the actual Circle constructor
            Filter filter = new Filter();
            float friction = 0.3f;
            float restitution = 0.1f;
            float restitutionThreshold = 1.5f;
            bool isSensor = true;

            // Act
            Fixture fixture = new Fixture(circle, filter, friction, restitution, restitutionThreshold, isSensor);

            // Assert
            Assert.Equal(circle.ShapeType, fixture.Shape.ShapeType);
            Assert.Equal(filter.CategoryMask, fixture.Filter.CategoryMask);
            Assert.Equal(friction, fixture.Friction);
            Assert.Equal(restitution, fixture.Restitution);
            Assert.Equal(restitutionThreshold, fixture.RestitutionThreshold);
            Assert.Equal(isSensor, fixture.IsSensor);
        }
        
        /// <summary>
        /// Tests that proxy id property test
        /// </summary>
        [Fact]
        public void ProxyIdPropertyTest()
        {
            // Arrange
            int proxyId = 1;
            FixtureProxy fixtureProxy = new FixtureProxy();
            
            // Act
            fixtureProxy.ProxyId = proxyId;
            
            // Assert
            Assert.Equal(proxyId, fixtureProxy.ProxyId);
        }
    }
}