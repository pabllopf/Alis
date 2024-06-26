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

using System.Collections.Generic;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision.ContactSystem;
using Alis.Core.Physic.Collision.Filtering;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Solver;
using Alis.Core.Physic.Shared;
using Alis.Core.Physic.Test.Samples;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    ///     The breakable body test class
    /// </summary>
    public class BreakableBodyTest
    {
        /// <summary>
        ///     Tests that constructor test
        /// </summary>
        [Fact]
        public void ConstructorTest()
        {
            // Arrange
            World world = new World(new Vector2(0, -9.8f));
            ICollection<Vertices> parts = new List<Vertices>();
            float density = 1.0f;
            Vector2 position = new Vector2(0, 0);
            float rotation = 0.0f;
            
            // Act
            MyBreakableBody breakableBody = new MyBreakableBody(world, parts, density, position, rotation);
            
            // Assert
            Assert.NotNull(breakableBody);
            Assert.Equal(position, breakableBody.MainBody.Position);
            Assert.Equal(rotation, breakableBody.MainBody.Rotation);
        }
        
        /// <summary>
        ///     Tests that post solve test
        /// </summary>
        [Fact]
        public void PostSolveTest()
        {
            // Arrange
            World world = new World(new Vector2(0, -9.8f));
            ICollection<Vertices> parts = new List<Vertices>();
            float density = 1.0f;
            Vector2 position = new Vector2(0, 0);
            float rotation = 0.0f;
            MyBreakableBody breakableBody = new MyBreakableBody(world, parts, density, position, rotation);
            
            // Assuming you have shapes and filters available for the fixtures
            AShape shapeA = new CircleShape(1.0f, 1.0f); // Replace with the actual Circle constructor
            Filter filterA = new Filter();
            float frictionA = 0.3f;
            float restitutionA = 0.1f;
            float restitutionThresholdA = 1.5f;
            bool isSensorA = true;
            Fixture fixtureA = new Fixture(shapeA, filterA, frictionA, restitutionA, restitutionThresholdA, isSensorA);
            
            AShape shapeB = new CircleShape(1.0f, 1.0f); // Replace with the actual Circle constructor
            Filter filterB = new Filter();
            float frictionB = 0.3f;
            float restitutionB = 0.1f;
            float restitutionThresholdB = 1.5f;
            bool isSensorB = true;
            Fixture fixtureB = new Fixture(shapeB, filterB, frictionB, restitutionB, restitutionThresholdB, isSensorB);
            
            int indexA = 0;
            int indexB = 0;
            Contact contact = new Contact(fixtureA, indexA, fixtureB, indexB);
            
            ContactVelocityConstraint impulse = new ContactVelocityConstraint();
            
            // Act
            breakableBody.PostSolve(contact, impulse);
            
            // Assert
            // Add assertions here based on the expected outcome of the PostSolve method
        }
        
        /// <summary>
        ///     Tests that update test
        /// </summary>
        [Fact]
        public void UpdateTest()
        {
            // Arrange
            World world = new World(new Vector2(0, -9.8f));
            ICollection<Vertices> parts = new List<Vertices>();
            float density = 1.0f;
            Vector2 position = new Vector2(0, 0);
            float rotation = 0.0f;
            MyBreakableBody breakableBody = new MyBreakableBody(world, parts, density, position, rotation);
            
            // Act
            breakableBody.Update();
            
            // Assert
            // Add assertions here based on the expected outcome of the Update method
        }
        
        /// <summary>
        ///     Tests that decompose test
        /// </summary>
        [Fact]
        public void DecomposeTest()
        {
            // Arrange
            World world = new World(new Vector2(0, -9.8f));
            ICollection<Vertices> parts = new List<Vertices>();
            float density = 1.0f;
            Vector2 position = new Vector2(0, 0);
            float rotation = 0.0f;
            MyBreakableBody breakableBody = new MyBreakableBody(world, parts, density, position, rotation);
            
            // Act
            breakableBody.Decompose();
            
            // Assert
            // Add assertions here based on the expected outcome of the Decompose method
        }
        
        /// <summary>
        ///     Tests that break test
        /// </summary>
        [Fact]
        public void BreakTest()
        {
            // Arrange
            World world = new World(new Vector2(0, -9.8f));
            ICollection<Vertices> parts = new List<Vertices>();
            float density = 1.0f;
            Vector2 position = new Vector2(0, 0);
            float rotation = 0.0f;
            MyBreakableBody breakableBody = new MyBreakableBody(world, parts, density, position, rotation);
            
            // Act
            breakableBody.Break();
            
            // Assert
            // Add assertions here based on the expected outcome of the Break method
        }
        
        /// <summary>
        /// Tests that breakable body constructor test
        /// </summary>
        [Fact]
        public void BreakableBodyConstructorTest()
        {
            // Arrange
            World world = new World( new Vector2(0, -9.8f));
            List<AShape> shapes = new List<AShape>() {new CircleShape(1, 1.0f)};
            Vector2 position = new Vector2();
            float rotation = 0;
            
            // Act
            BreakableBody breakableBody = new MyBreakableBody(
                world,
                new List<Vertices>(),
                1.0f,
                position,
                rotation);
            
            // Assert
            Assert.Equal(position, breakableBody.MainBody.Position);
            Assert.Equal(rotation, breakableBody.MainBody.Rotation);
            Assert.Equal(BodyType.Dynamic, breakableBody.MainBody.BodyType);
        }
        
        /// <summary>
        /// Tests that breakable body update test
        /// </summary>
        [Fact]
        public void BreakableBodyUpdateTest()
        {
            // Arrange
            World world = new World( new Vector2(0, -9.8f));
            List<AShape> shapes = new List<AShape>() {new CircleShape(1, 1.0f)};
            Vector2 position = new Vector2();
            float rotation = 0;
            BreakableBody breakableBody = new MyBreakableBody(
                world,
                new List<Vertices>(),
                1.0f,
                position,
                rotation);
            
            // Act
            breakableBody.Update();
            
            // Assert
            // Here you would assert that the properties of wheelJoint have been set correctly.
        }
        
        /// <summary>
        /// Tests that breakable body decompose test
        /// </summary>
        [Fact]
        public void BreakableBodyDecomposeTest()
        {
            // Arrange
            World world = new World( new Vector2(0, -9.8f));
            List<AShape> shapes = new List<AShape>() {new CircleShape(1, 1.0f)};
            Vector2 position = new Vector2();
            float rotation = 0;
            BreakableBody breakableBody = new MyBreakableBody(
                world,
                new List<Vertices>(),
                1.0f,
                position,
                rotation);
            
            // Act
            breakableBody.Decompose();
            
            // Assert
            // Here you would assert that the properties of wheelJoint have been set correctly.
        }
        
        /// <summary>
        /// Tests that breakable body break test
        /// </summary>
        [Fact]
        public void BreakableBodyBreakTest()
        {
            // Arrange
            World world = new World( new Vector2(0, -9.8f));
            Vector2 position = new Vector2();
            float rotation = 0;
            BreakableBody breakableBody = new MyBreakableBody(
                world,
                new List<Vertices>(),
                1.0f,
                position,
                rotation);
            
            
            // Act
            breakableBody.Break();
            
            // Assert
            // Here you would assert that the properties of wheelJoint have been set correctly.
        }
    }
}