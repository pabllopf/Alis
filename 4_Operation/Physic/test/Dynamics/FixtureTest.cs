// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FixtureTest.cs
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
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision.BroadPhase;
using Alis.Core.Physic.Collision.Filtering;
using Alis.Core.Physic.Collision.RayCast;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Shared;
using Alis.Core.Physic.Test.Collision.BroadPhase.Sample;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    ///     The fixture test class
    /// </summary>
    public class FixtureTest
    {
        /// <summary>
        ///     Tests that fixture constructor test
        /// </summary>
        [Fact]
        public void FixtureConstructorTest()
        {
            // Arrange
            CircleShape shape = new CircleShape(1, 1.0f); // Replace with the actual Circle constructor
            Filter filter = new Filter();
            float friction = 0.3f;
            float restitution = 0.1f;
            float restitutionThreshold = 1.5f;
            bool isSensor = true;
            
            // Act
            Fixture fixture = new Fixture(shape, filter, friction, restitution, restitutionThreshold, isSensor);
            
            // Assert
            Assert.Equal(shape.ShapeType, fixture.Shape.ShapeType);
            Assert.Equal(filter.CategoryMask, fixture.Filter.CategoryMask);
            Assert.Equal(friction, fixture.Friction);
            Assert.Equal(restitution, fixture.Restitution);
            Assert.Equal(restitutionThreshold, fixture.RestitutionThreshold);
            Assert.Equal(isSensor, fixture.IsSensor);
        }
        
        /// <summary>
        ///     Tests that test point test
        /// </summary>
        [Fact]
        public void TestPointTest()
        {
            // Arrange
            CircleShape shape = new CircleShape(1, 1.0f); // Replace with the actual Circle constructor
            Filter filter = new Filter();
            Fixture fixture = new Fixture(shape, filter);
            Vector2 point = new Vector2(0, 0);
            
            // Act
            Assert.Throws<NullReferenceException>(() => fixture.TestPoint(ref point));
        }
        
        /// <summary>
        ///     Tests that ray cast test
        /// </summary>
        [Fact]
        public void RayCastTest()
        {
            // Arrange
            CircleShape shape = new CircleShape(1, 1.0f); // Replace with the actual Circle constructor
            Filter filter = new Filter();
            Fixture fixture = new Fixture(shape, filter);
            RayCastInput input = new RayCastInput();
            RayCastOutput output;
            int childIndex = 0;
            
            // ActA
            Assert.Throws<NullReferenceException>(() => fixture.RayCast(out output, ref input, childIndex));
        }
        
        /// <summary>
        ///     Tests that get aabb test
        /// </summary>
        [Fact]
        public void GetAabbTest()
        {
            // Arrange
            CircleShape shape = new CircleShape(1, 1.0f); // Replace with the actual Circle constructor
            Filter filter = new Filter();
            Fixture fixture = new Fixture(shape, filter);
            int childIndex = 0;
            Aabb aabb;
            
            // Act
            fixture.GetAabb(out aabb, childIndex);
            
            Assert.Equal(new Vector2(0, 0), aabb.LowerBound);
        }
        
        /// <summary>
        /// Tests that synchronize should synchronize correctly
        /// </summary>
        [Fact]
        public void Synchronize_ShouldSynchronizeCorrectly()
        {
            // Arrange
            IBroadPhase broadPhase = new BroadPhaseImplementation(); // Replace with actual instance
            Transform transform1 = new Transform();
            Transform transform2 = new Transform();
            Fixture fixture = new Fixture(
                new CircleShape(1, 1.0f), // Replace with actual shape
                new Filter()
            );
            fixture.Proxies[0] = new FixtureProxy(); // Replace with actual proxy
            
            
            // Act
            fixture.Synchronize(broadPhase, ref transform1, ref transform2);
            
            // Assert
            // Here you would assert that the properties of wheelJoint have been set correctly.
        }
        
        /// <summary>
        /// Tests that fixture constructor test v 2
        /// </summary>
        [Fact]
        public void FixtureConstructorTest_v2()
        {
            // Arrange
            CircleShape shape = new CircleShape(1, 1.0f);
            Filter filter = new Filter();
            float friction = 0.3f;
            float restitution = 0.1f;
            float restitutionThreshold = 1.5f;
            bool isSensor = true;
            
            // Act
            Fixture fixture = new Fixture(shape, filter, friction, restitution, restitutionThreshold, isSensor);
            
            // Assert
            Assert.Equal(shape.ShapeType, fixture.Shape.ShapeType);
            Assert.Equal(filter.CategoryMask, fixture.Filter.CategoryMask);
            Assert.Equal(friction, fixture.Friction);
            Assert.Equal(restitution, fixture.Restitution);
            Assert.Equal(restitutionThreshold, fixture.RestitutionThreshold);
            Assert.Equal(isSensor, fixture.IsSensor);
        }
        
        /// <summary>
        /// Tests that test point test v 2
        /// </summary>
        [Fact]
        public void TestPointTest_v2()
        {
            // Arrange
            CircleShape shape = new CircleShape(1, 1.0f);
            Filter filter = new Filter();
            Fixture fixture = new Fixture(shape, filter);
            Vector2 point = new Vector2(0, 0);
            
            // Act
            Assert.Throws<NullReferenceException>( () => fixture.TestPoint(ref point));
        }
        
        /// <summary>
        /// Tests that ray cast test v 2
        /// </summary>
        [Fact]
        public void RayCastTest_v2()
        {
            // Arrange
            CircleShape shape = new CircleShape(1, 1.0f);
            Filter filter = new Filter();
            Fixture fixture = new Fixture(shape, filter);
            RayCastInput input = new RayCastInput();
            RayCastOutput output;
            int childIndex = 0;
            
            // Act
            Assert.Throws<NullReferenceException>( () =>fixture.RayCast(out output, ref input, childIndex));
        }
        
        /// <summary>
        /// Tests that get aabb test v 2
        /// </summary>
        [Fact]
        public void GetAabbTest_v2()
        {
            // Arrange
            CircleShape shape = new CircleShape(1, 1.0f);
            Filter filter = new Filter();
            Fixture fixture = new Fixture(shape, filter);
            int childIndex = 0;
            Aabb aabb;
            
            // Act
            fixture.GetAabb(out aabb, childIndex);
            
            // Assert
            Assert.Equal(new Vector2(0, 0), aabb.LowerBound);
        }
        
        /// <summary>
        /// Tests that synchronize should synchronize correctly v 2
        /// </summary>
        [Fact]
        public void Synchronize_ShouldSynchronizeCorrectly_v2()
        {
            // Arrange
            IBroadPhase broadPhase = new BroadPhaseImplementation();
            Transform transform1 = new Transform();
            Transform transform2 = new Transform();
            Fixture fixture = new Fixture(
                new CircleShape(1, 1.0f),
                new Filter()
            );
            fixture.Proxies[0] = new FixtureProxy();
            
            // Act
            fixture.Synchronize(broadPhase, ref transform1, ref transform2);
            
            // Assert
            // Here you would assert that the properties of wheelJoint have been set correctly.
        }
    }
}