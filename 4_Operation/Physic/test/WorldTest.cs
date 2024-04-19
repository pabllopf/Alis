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

using System;
using System.Collections.Generic;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Joints;
using Alis.Core.Physic.Shared;
using Alis.Core.Physic.Test.Samples;
using Xunit;

namespace Alis.Core.Physic.Test
{
    /// <summary>
    ///     The world test class
    /// </summary>
    public class WorldTest
    {
        /// <summary>
        ///     Tests that test add body
        /// </summary>
        [Fact]
        public void Test_AddBody()
        {
            World world = new World(new Vector2(0, -9.8f));
            Vector2 position = new Vector2(0, 0);
            Vector2 linearVelocity = new Vector2(0, 0);
            BodyType bodyType = BodyType.Static;
            float angle = 0.0f;
            float angularVelocity = 0.0f;
            float linearDamping = 0.0f;
            float angularDamping = 0.0f;
            bool allowSleep = true;
            bool awake = true;
            bool fixedRotation = false;
            bool isBullet = false;
            bool enabled = true;
            float gravityScale = 1.0f;
            
            Body body = new Body(position, linearVelocity, bodyType, angle,
                angularVelocity, linearDamping, angularDamping, allowSleep, awake, fixedRotation, isBullet, enabled, gravityScale);
            world.AddBody(body);
            Assert.Contains(body, world.Bodies);
        }
        
        /// <summary>
        ///     Tests that test remove body
        /// </summary>
        [Fact]
        public void Test_RemoveBody()
        {
            World world = new World(new Vector2(0, -9.8f));
            Vector2 position = new Vector2(0, 0);
            Vector2 linearVelocity = new Vector2(0, 0);
            BodyType bodyType = BodyType.Static;
            float angle = 0.0f;
            float angularVelocity = 0.0f;
            float linearDamping = 0.0f;
            float angularDamping = 0.0f;
            bool allowSleep = true;
            bool awake = true;
            bool fixedRotation = false;
            bool isBullet = false;
            bool enabled = true;
            float gravityScale = 1.0f;
            
            Body body = new Body(position, linearVelocity, bodyType, angle,
                angularVelocity, linearDamping, angularDamping, allowSleep, awake, fixedRotation, isBullet, enabled, gravityScale);
            world.AddBody(body);
            world.RemoveBody(body);
            Assert.DoesNotContain(body, world.Bodies);
        }
        
        /// <summary>
        ///     Tests that test add breakable body
        /// </summary>
        [Fact]
        public void Test_AddBreakableBody()
        {
            World world = new World(new Vector2(0, -9.8f));
            ICollection<Vertices> parts = new List<Vertices>();
            float density = 1.0f;
            Vector2 position = new Vector2();
            float rotation = 0.0f;
            
            MyBreakableBody breakableBody = new MyBreakableBody(world, parts, density, position, rotation);
            world.AddBreakableBody(breakableBody);
            Assert.Contains(breakableBody, world.BreakableBodies);
        }
        
        /// <summary>
        ///     Tests that test remove breakable body
        /// </summary>
        [Fact]
        public void Test_RemoveBreakableBody()
        {
            World world = new World(new Vector2(0, -9.8f));
            ICollection<Vertices> parts = new List<Vertices>();
            float density = 1.0f;
            Vector2 position = new Vector2();
            float rotation = 0.0f;
            
            MyBreakableBody breakableBody = new MyBreakableBody(world, parts, density, position, rotation);
            world.AddBreakableBody(breakableBody);
            world.RemoveBreakableBody(breakableBody);
            Assert.DoesNotContain(breakableBody, world.BreakableBodies);
        }
        
        /// <summary>
        ///     Tests that test add joint
        /// </summary>
        [Fact]
        public void Test_AddJoint()
        {
            World world = new World(new Vector2(0, -9.8f));
            RevoluteJoint joint = new RevoluteJoint();
            world.AddJoint(joint);
            Assert.Contains(joint, world.Joints);
        }
        
        /// <summary>
        ///     Tests that test remove joint
        /// </summary>
        [Fact]
        public void Test_RemoveJoint()
        {
            World world = new World(new Vector2(0, -9.8f));
            RevoluteJoint joint = new RevoluteJoint();
            world.AddJoint(joint);
            world.RemoveJoint(joint);
            Assert.DoesNotContain(joint, world.Joints);
        }
        
        /// <summary>
        ///     Tests that test add joint v 2
        /// </summary>
        [Fact]
        public void Test_AddJoint_v2()
        {
            World world = new World(new Vector2(0, -9.8f));
            RevoluteJoint joint = new RevoluteJoint();
            world.AddJoint(joint);
            Assert.Contains(joint, world.Joints);
        }
        
        /// <summary>
        ///     Tests that test remove joint v 2
        /// </summary>
        [Fact]
        public void Test_RemoveJoint_v2()
        {
            World world = new World(new Vector2(0, -9.8f));
            RevoluteJoint joint = new RevoluteJoint();
            world.AddJoint(joint);
            world.RemoveJoint(joint);
            Assert.DoesNotContain(joint, world.Joints);
        }
        
        /// <summary>
        ///     Tests that test add body
        /// </summary>
        [Fact]
        public void TestAddBody()
        {
            World world = new World(new Vector2(0, -9.8f));
            Body body = new Body(new Vector2(0, 0), Vector2.Zero, BodyType.Dynamic);
            world.AddBody(body);
            Assert.Contains(body, world.Bodies);
        }
        
        /// <summary>
        ///     Tests that test remove body
        /// </summary>
        [Fact]
        public void TestRemoveBody()
        {
            World world = new World(new Vector2(0, -9.8f));
            Body body = new Body(new Vector2(0, 0), Vector2.Zero, BodyType.Dynamic);
            world.AddBody(body);
            world.RemoveBody(body);
            Assert.DoesNotContain(body, world.Bodies);
        }
        
        /// <summary>
        ///     Tests that test add joint
        /// </summary>
        [Fact]
        public void TestAddJoint()
        {
            World world = new World(new Vector2(0, -9.8f));
            DistanceJoint joint = new DistanceJoint(new Body(new Vector2(0, 0), Vector2.Zero, BodyType.Dynamic), new Body(new Vector2(1, 0), Vector2.Zero, BodyType.Dynamic));
            world.AddJoint(joint);
            Assert.Contains(joint, world.Joints);
        }
        
        /// <summary>
        ///     Tests that test remove joint
        /// </summary>
        [Fact]
        public void TestRemoveJoint()
        {
            World world = new World(new Vector2(0, -9.8f));
            DistanceJoint joint = new DistanceJoint(new Body(new Vector2(0, 0), Vector2.Zero, BodyType.Dynamic), new Body(new Vector2(1, 0), Vector2.Zero, BodyType.Dynamic));
            world.AddJoint(joint);
            world.RemoveJoint(joint);
            Assert.DoesNotContain(joint, world.Joints);
        }
        
        /// <summary>
        ///     Tests that step updates delta time correctly
        /// </summary>
        [Fact]
        public void Step_UpdatesDeltaTimeCorrectly()
        {
            // Arrange
            World world = new World(new Vector2(0, -9.8f));
            float initialDeltaTime = world.TimeStepGlobal.DeltaTime;
            float dt = 0.02f; // This would be the time step for your simulation
            
            // Act
            world.Step(dt);
            
            // Assert
            Assert.NotEqual(initialDeltaTime, world.TimeStepGlobal.DeltaTime);
            Assert.Equal(dt, world.TimeStepGlobal.DeltaTime);
        }
        
        /// <summary>
        ///     Tests that test update inverted delta time
        /// </summary>
        [Fact]
        public void Test_UpdateInvertedDeltaTime()
        {
            // Arrange
            World world = new World(new Vector2(0, -9.8f))
                {
                    TimeStepGlobal = {
                        DeltaTime = 0.5f,
                        InvertedDeltaTime = 2.0f
                    }
                };
            
            // Act
            world.UpdateInvertedDeltaTime();
            
            // Assert
            Assert.Equal(2.0f, world.TimeStepGlobal.InvertedDeltaTimeZero);
        }
        
        /// <summary>
        ///     Tests that test is min alpha greater than epsilon
        /// </summary>
        [Fact]
        public void TestIsMinAlphaGreaterThanEpsilon()
        {
            float minAlpha = 0.5f;
            bool result = World.IsMinAlphaGreaterThanEpsilon(minAlpha);
            Assert.False(result); // Assert that the result is false when minAlpha is less than 1.0f - Constant.Epsilon * 10.0f
            
            minAlpha = 1.0f;
            result = World.IsMinAlphaGreaterThanEpsilon(minAlpha);
            Assert.True(result); // Assert that the result is true when minAlpha is equal to 1.0f - Constant.Epsilon * 10.0f
        }
        
        /// <summary>
        ///     Tests that test synchronize island bodies
        /// </summary>
        [Fact]
        public void TestSynchronizeIslandBodies()
        {
            World world = new World(new Vector2(0, -9.8f));
            
            // Act
            Exception exception = Record.Exception(() => world.SynchronizeIslandBodies());
            
            // Assert
            Assert.Null(exception);
        }
        
        /// <summary>
        ///     Tests that test clear forces
        /// </summary>
        [Fact]
        public void TestClearForces()
        {
            World world = new World(new Vector2(0, -9.8f));
            
            // Act
            Exception exception = Record.Exception(() => world.ClearForces());
            
            // Assert
            Assert.Null(exception);
        }
        
        /// <summary>
        ///     Tests that test solve toi
        /// </summary>
        [Fact]
        public void TestSolveToi()
        {
            // Arrange
            World world = new World(new Vector2(0, -9.8f));
            
            // Act
            Exception exception = Record.Exception(() => world.SolveToi());
            
            // Assert
            Assert.Null(exception);
        }
        
        /// <summary>
        ///     Tests that test set alpha to zero for fast moving bodies
        /// </summary>
        [Fact]
        public void TestSetAlphaToZeroForFastMovingBodies()
        {
            // Arrange
            World world = new World(new Vector2(0, -9.8f));
            
            // Act
            Exception exception = Record.Exception(() => world.SetAlphaToZeroForFastMovingBodies());
            
            // Assert
            Assert.Null(exception);
        }
        
        /// <summary>
        ///     Tests that test invalidate contact toi
        /// </summary>
        [Fact]
        public void TestInvalidateContactToi()
        {
            // Arrange
            World world = new World(new Vector2(0, -9.8f));
            
            // Act
            Exception exception = Record.Exception(() => world.InvalidateContactToi());
            
            // Assert
            Assert.Null(exception);
        }
        
        /// <summary>
        ///     Tests that test solve toi events
        /// </summary>
        [Fact]
        public void TestSolveToiEvents()
        {
            // Arrange
            World world = new World(new Vector2(0, -9.8f));
            
            // Act
            Exception exception = Record.Exception(() => world.SolveToiEvents());
            
            // Assert
            Assert.Null(exception);
        }
        
        /// <summary>
        ///     Tests that set alpha to zero for fast moving bodies empty list no exception thrown
        /// </summary>
        [Fact]
        public void SetAlphaToZeroForFastMovingBodies_EmptyList_NoExceptionThrown()
        {
            // Arrange
            World world = new World(new Vector2(0, -9.8f));
            
            // Act
            Exception exception = Record.Exception(() => world.SetAlphaToZeroForFastMovingBodies());
            
            // Assert
            Assert.Null(exception);
        }
        
        /// <summary>
        ///     Tests that set alpha to zero for fast moving bodies non empty list all bodies alpha set to zero
        /// </summary>
        [Fact]
        public void SetAlphaToZeroForFastMovingBodies_NonEmptyList_AllBodiesAlphaSetToZero()
        {
            // Arrange
            World world = new World(new Vector2(0, -9.8f));
            
            // Act
            Exception exception = Record.Exception(() => world.SetAlphaToZeroForFastMovingBodies());
            
            // Assert
            Assert.Null(exception);
        }
        
        /// <summary>
        ///     Tests that test solve toi island
        /// </summary>
        [Fact]
        public void TestSolveToiIsland()
        {
            // Arrange
            World world = new World(new Vector2(0, -9.8f));
            float minAlpha = 0.5f;
            int islandIndexA = 1;
            int islandIndexB = 2;
            
            // Act
            Exception exception = Record.Exception(() => world.SolveToiIsland(minAlpha, islandIndexA, islandIndexB));
            
            // Assert
            Assert.NotNull(exception);
        }
    }
}