// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BodyHelperTest.cs
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
using Alis.Core.Physic.Collision.ContactSystem;
using Alis.Core.Physic.Collision.Filtering;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Collision.TOI;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Solver;
using Alis.Core.Physic.Figure;
using Alis.Core.Physic.Shared;
using Alis.Core.Physic.Test.Collision.BroadPhase.Sample;
using Alis.Core.Physic.Test.Samples;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    /// The body helper test class
    /// </summary>
    public class BodyHelperTest
    {
        /// <summary>
        /// Tests that advance body test
        /// </summary>
        [Fact]
        public void AdvanceBodyTest()
        {
            // Arrange
            ContactManager contactManager = new ContactManager(new BroadPhaseImplementation());
            Island island = new Island();
            // Assuming you have fixtures available for the contact
            Shape shapeA = new CircleShape(1.0f, 1.0f); // Replace with the actual Circle constructor
            Filter filterA = new Filter();
            float frictionA = 0.3f;
            float restitutionA = 0.1f;
            float restitutionThresholdA = 1.5f;
            bool isSensorA = true;
            Fixture fixtureA = new Fixture(shapeA, filterA, frictionA, restitutionA, restitutionThresholdA, isSensorA);
            
            Shape shapeB = new CircleShape(1.0f, 1.0f); // Replace with the actual Circle constructor
            Filter filterB = new Filter();
            float frictionB = 0.3f;
            float restitutionB = 0.1f;
            float restitutionThresholdB = 1.5f;
            bool isSensorB = true;
            Fixture fixtureB = new Fixture(shapeB, filterB, frictionB, restitutionB, restitutionThresholdB, isSensorB);
            
            int indexA = 0;
            int indexB = 0;
            Contact minContact = new Contact(fixtureA, indexA, fixtureB, indexB);
            float minAlpha = 0.5f;
            
            // Act
            Assert.Throws<NullReferenceException>(() => BodyHelper.AdvanceBody(contactManager, island, minContact, minAlpha));
            
        }
        
        /// <summary>
        /// Tests that advance bodies test
        /// </summary>
        [Fact]
        public void AdvanceBodiesTest()
        {
            // Arrange
            // Assuming you have fixtures available for the contact
            Shape shapeA = new CircleShape(1.0f, 1.0f); // Replace with the actual Circle constructor
            Filter filterA = new Filter();
            float frictionA = 0.3f;
            float restitutionA = 0.1f;
            float restitutionThresholdA = 1.5f;
            bool isSensorA = true;
            Fixture fixtureA = new Fixture(shapeA, filterA, frictionA, restitutionA, restitutionThresholdA, isSensorA);
            
            Shape shapeB = new CircleShape(1.0f, 1.0f); // Replace with the actual Circle constructor
            Filter filterB = new Filter();
            float frictionB = 0.3f;
            float restitutionB = 0.1f;
            float restitutionThresholdB = 1.5f;
            bool isSensorB = true;
            Fixture fixtureB = new Fixture(shapeB, filterB, frictionB, restitutionB, restitutionThresholdB, isSensorB);
            
            int indexA = 0;
            int indexB = 0;
            Contact minContact = new Contact(fixtureA, indexA, fixtureB, indexB);
            float minAlpha = 0.5f;
            
            // Act
            Assert.Throws<NullReferenceException>(() => BodyHelper.AdvanceBodies(minContact, minAlpha));
        }
        
        /// <summary>
        /// Tests that update contact test
        /// </summary>
        [Fact]
        public void UpdateContactTest()
        {
            // Arrange
            ContactManager contactManager = new ContactManager(new BroadPhaseImplementation());
            // Assuming you have fixtures available for the contact
            Shape shapeA = new CircleShape(1.0f, 1.0f); // Replace with the actual Circle constructor
            Filter filterA = new Filter();
            float frictionA = 0.3f;
            float restitutionA = 0.1f;
            float restitutionThresholdA = 1.5f;
            bool isSensorA = true;
            Fixture fixtureA = new Fixture(shapeA, filterA, frictionA, restitutionA, restitutionThresholdA, isSensorA);
            
            Shape shapeB = new CircleShape(1.0f, 1.0f); // Replace with the actual Circle constructor
            Filter filterB = new Filter();
            float frictionB = 0.3f;
            float restitutionB = 0.1f;
            float restitutionThresholdB = 1.5f;
            bool isSensorB = true;
            Fixture fixtureB = new Fixture(shapeB, filterB, frictionB, restitutionB, restitutionThresholdB, isSensorB);
            
            int indexA = 0;
            int indexB = 0;
            Contact minContact = new Contact(fixtureA, indexA, fixtureB, indexB);
            
            // Act
            Assert.Throws<NullReferenceException>(() =>BodyHelper.UpdateContact(contactManager, minContact));
            
            // Assert
            // Add assertions here based on the expected outcome of the UpdateContact method
        }
        
        /// <summary>
        /// Tests that check contact solid test
        /// </summary>
        [Fact]
        public void CheckContactSolidTest()
        {
            // Arrange
            // Assuming you have fixtures available for the contact
            Shape shapeA = new CircleShape(1.0f, 1.0f); // Replace with the actual Circle constructor
            Filter filterA = new Filter();
            float frictionA = 0.3f;
            float restitutionA = 0.1f;
            float restitutionThresholdA = 1.5f;
            bool isSensorA = true;
            Fixture fixtureA = new Fixture(shapeA, filterA, frictionA, restitutionA, restitutionThresholdA, isSensorA);
            
            Shape shapeB = new CircleShape(1.0f, 1.0f); // Replace with the actual Circle constructor
            Filter filterB = new Filter();
            float frictionB = 0.3f;
            float restitutionB = 0.1f;
            float restitutionThresholdB = 1.5f;
            bool isSensorB = true;
            Fixture fixtureB = new Fixture(shapeB, filterB, frictionB, restitutionB, restitutionThresholdB, isSensorB);
            
            int indexA = 0;
            int indexB = 0;
            Contact minContact = new Contact(fixtureA, indexA, fixtureB, indexB);
            Body[] bodies = new Body[2];
            Sweep backup1 = new Sweep();
            Sweep backup2 = new Sweep();
            
            // Act
            Assert.Throws<NullReferenceException>(() => BodyHelper.CheckContactSolid(minContact, bodies, backup1, backup2));
            
        }
        
        /// <summary>
        /// Tests that build island test
        /// </summary>
        [Fact]
        public void BuildIslandTest()
        {
            // Arrange
            Island island = new Island();
            // Assuming you have fixtures available for the contact
            Shape shapeA = new CircleShape(1.0f, 1.0f); // Replace with the actual Circle constructor
            Filter filterA = new Filter();
            float frictionA = 0.3f;
            float restitutionA = 0.1f;
            float restitutionThresholdA = 1.5f;
            bool isSensorA = true;
            Fixture fixtureA = new Fixture(shapeA, filterA, frictionA, restitutionA, restitutionThresholdA, isSensorA);
            
            Shape shapeB = new CircleShape(1.0f, 1.0f); // Replace with the actual Circle constructor
            Filter filterB = new Filter();
            float frictionB = 0.3f;
            float restitutionB = 0.1f;
            float restitutionThresholdB = 1.5f;
            bool isSensorB = true;
            Fixture fixtureB = new Fixture(shapeB, filterB, frictionB, restitutionB, restitutionThresholdB, isSensorB);
            
            int indexA = 0;
            int indexB = 0;
            Contact minContact = new Contact(fixtureA, indexA, fixtureB, indexB);
            Body[] bodies = new Body[2];
            
            // Act
            Assert.Throws<NullReferenceException>(() => BodyHelper.BuildIsland(island, minContact, bodies));
            
            // Assert
            // Add assertions here based on the expected outcome of the BuildIsland method
        }
        
        /// <summary>
        /// Tests that get contacts test
        /// </summary>
        [Fact]
        public void GetContactsTest()
        {
            // Arrange
            ContactManager contactManager = new ContactManager(new BroadPhaseImplementation());
            float minAlpha = 0.5f;
            Body[] bodies = new Body[2];
            Island island = new Island();
            // Assuming you have fixtures available for the contact
            Shape shapeA = new CircleShape(1.0f, 1.0f); // Replace with the actual Circle constructor
            Filter filterA = new Filter();
            float frictionA = 0.3f;
            float restitutionA = 0.1f;
            float restitutionThresholdA = 1.5f;
            bool isSensorA = true;
            Fixture fixtureA = new Fixture(shapeA, filterA, frictionA, restitutionA, restitutionThresholdA, isSensorA);
            
            Shape shapeB = new CircleShape(1.0f, 1.0f); // Replace with the actual Circle constructor
            Filter filterB = new Filter();
            float frictionB = 0.3f;
            float restitutionB = 0.1f;
            float restitutionThresholdB = 1.5f;
            bool isSensorB = true;
            Fixture fixtureB = new Fixture(shapeB, filterB, frictionB, restitutionB, restitutionThresholdB, isSensorB);
            
            int indexA = 0;
            int indexB = 0;
            Contact minContact = new Contact(fixtureA, indexA, fixtureB, indexB);
            
            
            
            // Act
            Assert.Throws<NullReferenceException>(() => BodyHelper.GetContacts(contactManager, minAlpha, bodies, island, minContact));
            
            // Assert
            // Add assertions here based on the expected outcome of the GetContacts method
        }
        
      /// <summary>
      /// Tests that process body contacts test
      /// </summary>
      [Fact]
        public void ProcessBodyContactsTest()
        {
            // Arrange
            World world = new World(new Vector2(0, -9.8f));
            Body body = new Rectangle(1.0f, 1.0f, 
                new Vector2(0,0),
                new Vector2(1,1), BodyType.Static,1.0f, 0, 0);


            ContactManager contactManager = new ContactManager(new BroadPhaseImplementation());

            Island island = new Island();

            // Assuming you have fixtures available for the contact
            Shape shapeA = new CircleShape(1.0f, 1.0f); // Replace with the actual Circle constructor
            Filter filterA = new Filter();
            float frictionA = 0.3f;
            float restitutionA = 0.1f;
            float restitutionThresholdA = 1.5f;
            bool isSensorA = true;
            Fixture fixtureA = new Fixture(shapeA, filterA, frictionA, restitutionA, restitutionThresholdA, isSensorA);

            Shape shapeB = new CircleShape(1.0f, 1.0f); // Replace with the actual Circle constructor
            Filter filterB = new Filter();
            float frictionB = 0.3f;
            float restitutionB = 0.1f;
            float restitutionThresholdB = 1.5f;
            bool isSensorB = true;
            Fixture fixtureB = new Fixture(shapeB, filterB, frictionB, restitutionB, restitutionThresholdB, isSensorB);

            int indexA = 0;
            int indexB = 0;
            Contact minContact = new Contact(fixtureA, indexA, fixtureB, indexB);

            // Act
            BodyHelper.ProcessBodyContacts(body, contactManager, 0.5f, island, minContact);

            // Assert
            // Add assertions here based on the expected outcome of the ProcessBodyContacts method
            // For example, you might want to check if the body's contact list has been processed correctly
        }
                
        /// <summary>
        /// Tests that post solve test
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
            Shape shapeA = new CircleShape(1.0f, 1.0f); // Replace with the actual Circle constructor
            Filter filterA = new Filter();
            float frictionA = 0.3f;
            float restitutionA = 0.1f;
            float restitutionThresholdA = 1.5f;
            bool isSensorA = true;
            Fixture fixtureA = new Fixture(shapeA, filterA, frictionA, restitutionA, restitutionThresholdA, isSensorA);
            
            Shape shapeB = new CircleShape(1.0f, 1.0f); // Replace with the actual Circle constructor
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
    }
}