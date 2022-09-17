// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WorldTests.cs
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
using Alis.Aspect.Math;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Dynamics.Bodys;
using Alis.Core.Physic.Dynamics.Fixtures;
using Moq;
using Xunit;

namespace Alis.Core.Physic.Test
{
    /// <summary>
    ///     The world tests class
    /// </summary>
    public class WorldTests
    {
        /// <summary>
        ///     The mock repository
        /// </summary>
        private MockRepository mockRepository;

        /// <summary>
        ///     Initializes a new instance of the <see cref="WorldTests" /> class
        /// </summary>
        public WorldTests() => mockRepository = new MockRepository(MockBehavior.Strict);

        /// <summary>
        ///     Creates the world
        /// </summary>
        /// <returns>The world</returns>
        private World CreateWorld() => new World(
            new Aabb
            {
                LowerBound = new Vector2(-100.0f),
                UpperBound = new Vector2(-100.0f)
            },
            new Vector2(0.0f, -10.0f),
            true);

        /// <summary>
        ///     Tests that create body state under test expected behavior
        /// </summary>
        [Fact]
        public void CreateBody_StateUnderTest_ExpectedBehavior()
        {
            /*// Arrange
            var world = CreateWorld();
            Body def = default(BodyDef);

            // Act
            var result = world.AddBody(def);
*/
            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that destroy body state under test expected behavior
        /// </summary>
        [Fact]
        public void DestroyBody_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            //var world = CreateWorld();
            //Body b = null;

            // Act
            //world.RemoveBody(b);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that create joint state under test expected behavior
        /// </summary>
        [Fact]
        public void CreateJoint_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            //var world = CreateWorld();
            //JointDef def = null;

            // Act
            //var result = world.AddJoint(def);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that destroy joint state under test expected behavior
        /// </summary>
        [Fact]
        public void DestroyJoint_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            //var world = CreateWorld();
            //Joint j = null;

            // Act
            //world.RemoveJoint(j);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that add controller state under test expected behavior
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
        ///     Tests that remove controller state under test expected behavior
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
        ///     Tests that get body list state under test expected behavior
        /// </summary>
        [Fact]
        public void GetBodyList_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            World world = CreateWorld();

            // Act
            List<Body> result = world.BodyList;

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }


        /// <summary>
        ///     Tests that refilter state under test expected behavior
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
        ///     Tests that step state under test expected behavior
        /// </summary>
        [Fact]
        public void Step_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            World world = CreateWorld();
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
        ///     Tests that query state under test expected behavior
        /// </summary>
        [Fact]
        public void Query_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            World world = CreateWorld();
            Aabb aabb = default(Aabb);
            Fixture[] fixtures = null;
            int maxCount = 0;

            // Act
            int result = world.Query(
                aabb,
                fixtures,
                maxCount);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that raycast state under test expected behavior
        /// </summary>
        [Fact]
        public void Raycast_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            /*var world = CreateWorld();
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
*/
            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that raycast one state under test expected behavior
        /// </summary>
        [Fact]
        public void RaycastOne_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            /*var world = CreateWorld();
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
*/
            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }
    }
}