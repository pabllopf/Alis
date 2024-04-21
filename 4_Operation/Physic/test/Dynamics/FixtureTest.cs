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
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision.Filtering;
using Alis.Core.Physic.Collision.RayCast;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Shared;
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
    }
}