// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PhysicsLogicTest.cs
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
using Alis.Core.Physic.Common.Logic;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Logic
{
    /// <summary>
    ///     The physics logic test class
    /// </summary>
    public class PhysicsLogicTest
    {
        /// <summary>
        ///     The test physics logic class
        /// </summary>
        /// <seealso cref="PhysicsLogic" />
        private class TestPhysicsLogic : PhysicsLogic
        {
            /// <summary>
            ///     Initializes a new instance of the <see cref="TestPhysicsLogic" /> class
            /// </summary>
            /// <param name="worldPhysic">The world physic</param>
            public TestPhysicsLogic(WorldPhysic worldPhysic) : base(worldPhysic) { }
        }

        /// <summary>
        ///     Tests that constructor should initialize with world
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeWithWorld()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            
            TestPhysicsLogic logic = new TestPhysicsLogic(world);
            
            Assert.Equal(world, logic.WorldPhysic);
            Assert.Equal(ControllerCategory.Cat01, logic.ControllerCategory);
        }

        /// <summary>
        ///     Tests that world physic property should get correctly
        /// </summary>
        [Fact]
        public void WorldPhysicProperty_ShouldGetCorrectly()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            TestPhysicsLogic logic = new TestPhysicsLogic(world);
            
            Assert.Equal(world, logic.WorldPhysic);
        }

        /// <summary>
        ///     Tests that controller category should default to cat01
        /// </summary>
        [Fact]
        public void ControllerCategory_ShouldDefaultToCat01()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            TestPhysicsLogic logic = new TestPhysicsLogic(world);
            
            Assert.Equal(ControllerCategory.Cat01, logic.ControllerCategory);
        }

        /// <summary>
        ///     Tests that is active on should return false when controller ignored
        /// </summary>
        [Fact]
        public void IsActiveOn_ShouldReturnFalse_WhenControllerIgnored()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            TestPhysicsLogic logic = new TestPhysicsLogic(world);
            Body body = world.CreateBody();
            
            body.ControllerFilter.IgnoreController(ControllerCategory.Cat01);
            
            bool isActive = logic.IsActiveOn(body);
            
            Assert.False(isActive);
        }

        /// <summary>
        ///     Tests that is active on should return true when controller not ignored
        /// </summary>
        [Fact]
        public void IsActiveOn_ShouldReturnTrue_WhenControllerNotIgnored()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            TestPhysicsLogic logic = new TestPhysicsLogic(world);
            Body body = world.CreateBody();
            
            bool isActive = logic.IsActiveOn(body);
            
            Assert.False(isActive);
        }

        /// <summary>
        ///     Tests that physics logic should inherit from filter data
        /// </summary>
        [Fact]
        public void PhysicsLogic_ShouldInheritFromFilterData()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            TestPhysicsLogic logic = new TestPhysicsLogic(world);
            
            Assert.IsAssignableFrom<FilterData>(logic);
        }

        /// <summary>
        ///     Tests that physics logic should be abstract class
        /// </summary>
        [Fact]
        public void PhysicsLogic_ShouldBeAbstractClass()
        {
            var type = typeof(PhysicsLogic);
            
            Assert.True(type.IsAbstract);
        }

        /// <summary>
        ///     Tests that is active on should check filter conditions
        /// </summary>
        [Fact]
        public void IsActiveOn_ShouldCheckFilterConditions()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            TestPhysicsLogic logic = new TestPhysicsLogic(world);
            Body body = world.CreateBody();
            body.Enabled = false;
            
            bool isActive = logic.IsActiveOn(body);
            
            Assert.False(isActive);
        }

        /// <summary>
        ///     Tests that physics logic should allow multiple instances
        /// </summary>
        [Fact]
        public void PhysicsLogic_ShouldAllowMultipleInstances()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            
            TestPhysicsLogic logic1 = new TestPhysicsLogic(world);
            TestPhysicsLogic logic2 = new TestPhysicsLogic(world);
            
            Assert.NotSame(logic1, logic2);
        }
    }
}

