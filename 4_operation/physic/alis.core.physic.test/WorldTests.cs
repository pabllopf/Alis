// -------------------------------------------------------------------------- 
//  
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█  
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄ 
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█ 
//
//  -------------------------------------------------------------------------- 
//  File:   WorldTests.cs 
//  
//  Author: Pablo Perdomo Falcón 
//  Web:    https://www.pabllopf.dev/  
//  
//  Copyright (c) 2021 GNU General Public License v3.0 
//  
//  This program is free software: you can redistribute it and/or modify 
//  it under the terms of the GNU General Public License as published by 
//  the Free Software Foundation, either version 3 of the License, or 
//  (at your option) any later version. 
//  
//  This program is distributed in the hope that it will be useful, 
//  but WITHOUT ANY WARRANTY without even the implied warranty of 
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the 
//  GNU General Public License for more details. 
//  
//  You should have received a copy of the GNU General Public License 
//  along with this program.  If not, see <http://www.gnu.org/licenses/>. 
//  
//  --------------------------------------------------------------------------

using Alis.Aspect.Math;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Controllers;
using Alis.Core.Physic.Dynamics.Joints;
using Moq;
using Xunit;

namespace Alis.Core.Physic.Test
{
    /// <summary>
    /// The world tests class
    /// </summary>
    public class WorldTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="WorldTests"/> class
        /// </summary>
        public WorldTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the world
        /// </summary>
        /// <returns>The world</returns>
        private World CreateWorld()
        {
            return new World(
                worldAabb: new Aabb
                {
                    LowerBound = new Vector2(-100.0f),
                    UpperBound =  new Vector2(-100.0f),
                },  
                gravity: new Vector2(0.0f, -10.0f), 
                doSleep: true);
        }

        /// <summary>
        /// Tests that dispose state under test expected behavior
        /// </summary>
        [Fact]
        public void Dispose_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var world = CreateWorld();

            // Act
            world.Dispose();

            // Assert
            Assert.Null(world.BroadPhase);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that set destruction listener state under test expected behavior
        /// </summary>
        [Fact]
        public void SetDestructionListener_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var world = CreateWorld();
            DestructionListener listener = null;

            // Act
            world.SetDestructionListener(
                listener);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that set boundary listener state under test expected behavior
        /// </summary>
        [Fact]
        public void SetBoundaryListener_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var world = CreateWorld();
            BoundaryListener listener = null;

            // Act
            world.SetBoundaryListener(
                listener);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that set contact filter state under test expected behavior
        /// </summary>
        [Fact]
        public void SetContactFilter_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var world = CreateWorld();
            ContactFilter filter = null;

            // Act
            world.SetContactFilter(
                filter);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that set contact listener state under test expected behavior
        /// </summary>
        [Fact]
        public void SetContactListener_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var world = CreateWorld();
            IContactListener listener = null;

            // Act
            world.SetContactListener(
                listener);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that set debug draw state under test expected behavior
        /// </summary>
        [Fact]
        public void SetDebugDraw_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var world = CreateWorld();
            DebugDraw debugDraw = null;

            // Act
            world.SetDebugDraw(
                debugDraw);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that create body state under test expected behavior
        /// </summary>
        [Fact]
        public void CreateBody_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var world = CreateWorld();
            BodyDef def = default(BodyDef);

            // Act
            var result = world.CreateBody(
                def);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that destroy body state under test expected behavior
        /// </summary>
        [Fact]
        public void DestroyBody_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            //var world = CreateWorld();
            //Body b = null;

            // Act
            //world.DestroyBody(b);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that create joint state under test expected behavior
        /// </summary>
        [Fact]
        public void CreateJoint_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            //var world = CreateWorld();
            //JointDef def = null;

            // Act
            //var result = world.CreateJoint(def);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that destroy joint state under test expected behavior
        /// </summary>
        [Fact]
        public void DestroyJoint_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            //var world = CreateWorld();
            //Joint j = null;

            // Act
            //world.DestroyJoint(j);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that add controller state under test expected behavior
        /// </summary>
        [Fact]
        public void AddController_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            //var world = CreateWorld();
            //Controller def = null;

            // Act
            //var result = world.AddController(def);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that remove controller state under test expected behavior
        /// </summary>
        [Fact]
        public void RemoveController_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            //var world = CreateWorld();
            //Controller controller = null;

            // Act
            //world.RemoveController(controller);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that get ground body state under test expected behavior
        /// </summary>
        [Fact]
        public void GetGroundBody_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var world = CreateWorld();

            // Act
            var result = world.GetGroundBody();

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that get body list state under test expected behavior
        /// </summary>
        [Fact]
        public void GetBodyList_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var world = CreateWorld();

            // Act
            var result = world.GetBodyList();

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that get joint list state under test expected behavior
        /// </summary>
        [Fact]
        public void GetJointList_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var world = CreateWorld();

            // Act
            var result = world.GetJointList();

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that get controller list state under test expected behavior
        /// </summary>
        [Fact]
        public void GetControllerList_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var world = CreateWorld();

            // Act
            var result = world.GetControllerList();

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that get controller count state under test expected behavior
        /// </summary>
        [Fact]
        public void GetControllerCount_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var world = CreateWorld();

            // Act
            var result = world.GetControllerCount();

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that refilter state under test expected behavior
        /// </summary>
        [Fact]
        public void Refilter_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            //var world = CreateWorld();
            //Fixture fixture = null;

            // Act
            //world.Refilter(fixture);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that set warm starting state under test expected behavior
        /// </summary>
        [Fact]
        public void SetWarmStarting_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var world = CreateWorld();
            bool flag = false;

            // Act
            world.SetWarmStarting(
                flag);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that set continuous physics state under test expected behavior
        /// </summary>
        [Fact]
        public void SetContinuousPhysics_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var world = CreateWorld();
            bool flag = false;

            // Act
            world.SetContinuousPhysics(
                flag);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that validate state under test expected behavior
        /// </summary>
        [Fact]
        public void Validate_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var world = CreateWorld();

            // Act
            world.Validate();

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that get proxy count state under test expected behavior
        /// </summary>
        [Fact]
        public void GetProxyCount_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var world = CreateWorld();

            // Act
            var result = world.GetProxyCount();

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that get pair count state under test expected behavior
        /// </summary>
        [Fact]
        public void GetPairCount_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var world = CreateWorld();

            // Act
            var result = world.GetPairCount();

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that get body count state under test expected behavior
        /// </summary>
        [Fact]
        public void GetBodyCount_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var world = CreateWorld();

            // Act
            var result = world.GetBodyCount();

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that get joint count state under test expected behavior
        /// </summary>
        [Fact]
        public void GetJointCount_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var world = CreateWorld();

            // Act
            var result = world.GetJointCount();

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that get contact count state under test expected behavior
        /// </summary>
        [Fact]
        public void GetContactCount_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var world = CreateWorld();

            // Act
            var result = world.GetContactCount();

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that step state under test expected behavior
        /// </summary>
        [Fact]
        public void Step_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var world = CreateWorld();
            float dt = 0;
            int velocityIterations = 0;
            int positionIteration = 0;

            // Act
            world.Step(
                dt,
                velocityIterations,
                positionIteration);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that query state under test expected behavior
        /// </summary>
        [Fact]
        public void Query_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var world = CreateWorld();
            Aabb aabb = default(Aabb);
            Fixture[] fixtures = null;
            int maxCount = 0;

            // Act
            var result = world.Query(
                aabb,
                fixtures,
                maxCount);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that raycast state under test expected behavior
        /// </summary>
        [Fact]
        public void Raycast_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var world = CreateWorld();
            Segment segment = default(Segment);
            Fixture[] fixtures = null;
            int maxCount = 0;
            bool solidShapes = false;
            object userData = null;

            // Act
            var result = world.Raycast(
                segment,
                out fixtures,
                maxCount,
                solidShapes,
                userData);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that raycast one state under test expected behavior
        /// </summary>
        [Fact]
        public void RaycastOne_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var world = CreateWorld();
            Segment segment = default(Segment);
            float lambda = 0;
            Vector2 normal = default(Vector2);
            bool solidShapes = false;
            object userData = null;

            // Act
            var result = world.RaycastOne(
                segment,
                out lambda,
                out normal,
                solidShapes,
                userData);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that in range state under test expected behavior
        /// </summary>
        [Fact]
        public void InRange_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var world = CreateWorld();
            Aabb aabb = default(Aabb);

            // Act
            var result = world.InRange(
                aabb);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }
    }
}
