// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WorldTest.cs
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
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Joints;
using Alis.Core.Physic.Extensions.Controllers.Velocity;
using Moq;
using Xunit;

namespace Alis.Core.Physic.Test
{
    /// <summary>
    ///     The world test class
    /// </summary>
    public class WorldTest
    {
        /// <summary>
        ///     The world
        /// </summary>
        private readonly World _world = new World(new Vector2F(0, 9.18f));

        /// <summary>
        ///     Tests that add body adds a body to the bodies collection.
        /// </summary>
        [Fact]
        public void AddBody_AddsBodyToBodiesCollection()
        {
            Vector2F gravity = new Vector2F(0f, 9.18f);
            Vector2F position = new Vector2F(0f, 0f);
            Vector2F velocity = new Vector2F(0f, -1f);

            // Create a mock body object.
            Mock<Body> mockBody = new Mock<Body>(
                position,
                velocity,
                BodyType.Dynamic,
                0.0f,
                0.0f,
                0.0f,
                0.0f,
                true,
                true,
                false,
                false,
                true,
                1.0f);

            // Create a world object.
            World world = new World(gravity);

            // Call the AddBody method on the world object.
            world.AddBody(mockBody.Object);

            // Assert that the mock body object is added to the bodies collection.
            Assert.Single(world.Bodies);
            Assert.Equal(mockBody.Object, world.Bodies[0]);
        }

        /// <summary>
        ///     Tests that clear forces clears forces for a single body
        /// </summary>
        [Fact]
        public void ClearForces_ClearsForcesForOneBody()
        {
            Vector2F gravity = new Vector2F(0f, 9.18f);
            Vector2F position = new Vector2F(0f, 0f);
            Vector2F velocity = new Vector2F(0f, -1f);

            // Create a world object with the ClearForces method and 9.18f gravity.
            World world = new World(gravity);

            // Create a mock body object with the ClearForces method.
            Mock<Body> mockBody = new Mock<Body>(
                position,
                velocity,
                BodyType.Dynamic,
                0.0f,
                0.0f,
                0.0f,
                0.0f,
                true,
                true,
                false,
                false,
                true,
                1.0f);

            // Call the ClearForces method on the physics engine.
            world.AddBody(mockBody.Object);

            // Call the ClearForces method on the word class
            world.ClearForces();

            // Assert that the ClearForces method is called on the mock body object.
            Assert.Single(world.Bodies);

            // Assert that the force is zero
            Assert.Equal(Vector2F.Zero, world.Bodies[0].Force);

            // Assert that the torque is zero
            Assert.Equal(0, world.Bodies[0].Torque);

            // Verify that the ClearForces method is called on the mock body object.
            mockBody.VerifyAll();
        }

        /// <summary>
        ///     Tests that clear forces clears forces for multiple bodies
        /// </summary>
        [Fact]
        public void ClearForces_ClearsForcesForMultipleBodies()
        {
            Vector2F gravity = new Vector2F(0f, 9.18f);
            Vector2F position = new Vector2F(0f, 0f);
            Vector2F velocity = new Vector2F(0f, -1f);

            // Create a world object with the ClearForces method and 9.18f gravity.
            World world = new World(gravity);

            List<Mock<Body>> listMocksBodies = new List<Mock<Body>>();

            for (int i = 0; i < 10; i++)
            {
                Mock<Body> mockBody = new Mock<Body>(position,
                    velocity,
                    BodyType.Dynamic,
                    0.0f,
                    0.0f,
                    0.0f,
                    0.0f,
                    true,
                    true,
                    false,
                    false,
                    true,
                    1.0f);

                listMocksBodies.Add(mockBody);
                world.AddBody(mockBody.Object);
            }

            // Call the ClearForces method on the word class
            world.ClearForces();

            // Assert that is not empty bodies
            Assert.NotEmpty(world.Bodies);

            // Assert that is 10 bodies
            Assert.Equal(10, world.Bodies.Count);

            // Assert that all bodies set to zero force and torque
            for (int i = 0; i < 10; i++)
            {
                // Assert that the force is zero
                Assert.Equal(Vector2F.Zero, world.Bodies[i].Force);

                // Assert that the torque is zero
                Assert.Equal(0, world.Bodies[i].Torque);
            }

            // Verify that the ClearForces method is called on the mock body object.
            foreach (Mock<Body> mockBody in listMocksBodies)
            {
                mockBody.VerifyAll();
            }
        }

        /// <summary>
        ///     Tests that clear forces does nothing with an empty list
        /// </summary>
        [Fact]
        public void ClearForces_DoesNothingWithEmptyList()
        {
            // Set the gravity to 9.18f
            Vector2F gravity = new Vector2F(0f, 9.18f);

            // Create a world object with the ClearForces method and 9.18f gravity.
            World world = new World(gravity);

            // Call the ClearForces method on the word class
            world.ClearForces();

            // Assert that is empty bodies
            Assert.Empty(world.Bodies);
        }

        /// <summary>
        ///     Tests that add body adds correctly
        /// </summary>
        [Fact]
        public void AddBody_AddsCorrectly()
        {
            Vector2F gravity = new Vector2F(0f, 9.18f);
            Vector2F position = new Vector2F(0f, 0f);
            Vector2F velocity = new Vector2F(0f, -1f);

            Mock<Body> bodyMock = new Mock<Body>(
                position,
                velocity,
                BodyType.Dynamic,
                0.0f,
                0.0f,
                0.0f,
                0.0f,
                true,
                true,
                false,
                false,
                true,
                1.0f);

            _world.AddBody(bodyMock.Object);

            Assert.Contains(bodyMock.Object, _world.Bodies);
        }

        /// <summary>
        ///     Tests that remove body removes correctly
        /// </summary>
        [Fact]
        public void RemoveBody_RemovesCorrectly()
        {
            Vector2F gravity = new Vector2F(0f, 9.18f);
            Vector2F position = new Vector2F(0f, 0f);
            Vector2F velocity = new Vector2F(0f, -1f);

            Mock<Body> bodyMock = new Mock<Body>(
                position,
                velocity,
                BodyType.Dynamic,
                0.0f,
                0.0f,
                0.0f,
                0.0f,
                true,
                true,
                false,
                false,
                true,
                1.0f);
            _world.AddBody(bodyMock.Object);

            _world.RemoveBody(bodyMock.Object);

            Assert.DoesNotContain(bodyMock.Object, _world.Bodies);
        }

        /// <summary>
        ///     Tests that add joint adds correctly
        /// </summary>
        [Fact]
        public void AddJoint_AddsCorrectly()
        {
            Vector2F gravity = new Vector2F(0f, 9.18f);
            Vector2F position = new Vector2F(0f, 0f);
            Vector2F velocity = new Vector2F(0f, -1f);

            Mock<Body> bodyMock = new Mock<Body>(
                position,
                velocity,
                BodyType.Dynamic,
                0.0f,
                0.0f,
                0.0f,
                0.0f,
                true,
                true,
                false,
                false,
                true,
                1.0f);

            Mock<AngleJoint> jointMock = new Mock<AngleJoint>(bodyMock.Object, bodyMock.Object);

            _world.AddJoint(jointMock.Object);

            Assert.Contains(jointMock.Object, _world.Joints);
        }

        /// <summary>
        ///     Tests that remove joint removes correctly
        /// </summary>
        [Fact]
        public void RemoveJoint_RemovesCorrectly()
        {
            Vector2F gravity = new Vector2F(0f, 9.18f);
            Vector2F position = new Vector2F(0f, 0f);
            Vector2F velocity = new Vector2F(0f, -1f);

            Mock<Body> bodyMock = new Mock<Body>(
                position,
                velocity,
                BodyType.Dynamic,
                0.0f,
                0.0f,
                0.0f,
                0.0f,
                true,
                true,
                false,
                false,
                true,
                1.0f);

            Mock<AngleJoint> jointMock = new Mock<AngleJoint>(bodyMock.Object, bodyMock.Object);

            _world.AddJoint(jointMock.Object);

            _world.RemoveJoint(jointMock.Object);

            Assert.DoesNotContain(jointMock.Object, _world.Joints);
        }

        /// <summary>
        ///     Tests that add controller adds correctly
        /// </summary>
        [Fact]
        public void AddController_AddsCorrectly()
        {
            Mock<VelocityLimitController> controllerMock = new Mock<VelocityLimitController>();

            _world.AddController(controllerMock.Object);

            Assert.Contains(controllerMock.Object, _world.Controllers);
        }

        /// <summary>
        ///     Tests that add body when called should add body to physics world
        /// </summary>
        [Fact]
        public void AddBody_WhenCalled_ShouldAddBodyToPhysicsWorld()
        {
            Vector2F position = new Vector2F(0f, 0f);
            Vector2F velocity = new Vector2F(0f, -1f);

            Mock<Body> mockBody = new Mock<Body>(
                position,
                velocity,
                BodyType.Dynamic,
                0.0f,
                0.0f,
                0.0f,
                0.0f,
                true,
                true,
                false,
                false,
                true,
                1.0f);

            _world.AddBody(mockBody.Object);

            Assert.Contains(mockBody.Object, _world.Bodies);
        }

        /// <summary>
        ///     Tests that add joint when called should add joint to physics world
        /// </summary>
        [Fact]
        public void AddJoint_WhenCalled_ShouldAddJointToPhysicsWorld()
        {
            Vector2F position = new Vector2F(0f, 0f);
            Vector2F velocity = new Vector2F(0f, -1f);

            Mock<Body> bodyMock = new Mock<Body>(
                position,
                velocity,
                BodyType.Dynamic,
                0.0f,
                0.0f,
                0.0f,
                0.0f,
                true,
                true,
                false,
                false,
                true,
                1.0f);

            Mock<AngleJoint> mockJoint = new Mock<AngleJoint>(bodyMock.Object, bodyMock.Object);

            _world.AddJoint(mockJoint.Object);

            Assert.Contains(mockJoint.Object, _world.Joints);
        }

        /// <summary>
        ///     Tests that add controller when called should add controller to physics world
        /// </summary>
        [Fact]
        public void AddController_WhenCalled_ShouldAddControllerToPhysicsWorld()
        {
            Mock<VelocityLimitController> mockController = new Mock<VelocityLimitController>();
            _world.AddController(mockController.Object);

            Assert.Contains(mockController.Object, _world.Controllers);
        }

        /// <summary>
        ///     Tests that remove body when called should remove body from physics world
        /// </summary>
        [Fact]
        public void RemoveBody_WhenCalled_ShouldRemoveBodyFromPhysicsWorld()
        {
            Vector2F position = new Vector2F(0f, 0f);
            Vector2F velocity = new Vector2F(0f, -1f);

            Mock<Body> mockBody = new Mock<Body>(
                position,
                velocity,
                BodyType.Dynamic,
                0.0f,
                0.0f,
                0.0f,
                0.0f,
                true,
                true,
                false,
                false,
                true,
                1.0f);

            _world.AddBody(mockBody.Object);
            _world.RemoveBody(mockBody.Object);

            Assert.DoesNotContain(mockBody.Object, _world.Bodies);
        }

        /// <summary>
        ///     Tests that remove joint when called should remove joint from physics world
        /// </summary>
        [Fact]
        public void RemoveJoint_WhenCalled_ShouldRemoveJointFromPhysicsWorld()
        {
            Vector2F position = new Vector2F(0f, 0f);
            Vector2F velocity = new Vector2F(0f, -1f);

            Mock<Body> bodyMock = new Mock<Body>(
                position,
                velocity,
                BodyType.Dynamic,
                0.0f,
                0.0f,
                0.0f,
                0.0f,
                true,
                true,
                false,
                false,
                true,
                1.0f);

            Mock<AngleJoint> mockJoint = new Mock<AngleJoint>(bodyMock.Object, bodyMock.Object);
            _world.AddJoint(mockJoint.Object);
            _world.RemoveJoint(mockJoint.Object);

            Assert.DoesNotContain(mockJoint.Object, _world.Joints);
        }

        /// <summary>
        ///     Tests that remove controller when called should remove controller from physics world
        /// </summary>
        [Fact]
        public void RemoveController_WhenCalled_ShouldRemoveControllerFromPhysicsWorld()
        {
            Mock<VelocityLimitController> mockController = new Mock<VelocityLimitController>();
            _world.AddController(mockController.Object);
            _world.RemoveController(mockController.Object);

            Assert.DoesNotContain(mockController.Object, _world.Controllers);
        }

        /// <summary>
        ///     Tests that step when called should update physics world
        /// </summary>
        [Fact]
        public void Step_WhenCalled_ShouldUpdatePhysicsWorld()
        {
            _world.Step(1.0f);

            // Perform some assertion in addition to just verifying it didn't throw exceptions
            Assert.NotNull(_world.ContactManager);
            Assert.NotNull(_world.Bodies);
        }
    }
}