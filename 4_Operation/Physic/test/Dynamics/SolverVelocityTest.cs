// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SolverVelocityTest.cs
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
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    ///     The solver velocity test class
    /// </summary>
    public class SolverVelocityTest
    {
        /// <summary>
        ///     Tests that default constructor should initialize with default values
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldInitializeWithDefaultValues()
        {
            SolverVelocity velocity = new SolverVelocity();
            
            Assert.Equal(Vector2F.Zero, velocity.V);
            Assert.Equal(0.0f, velocity.W);
        }

        /// <summary>
        ///     Tests that v property should set and get correctly
        /// </summary>
        [Fact]
        public void VProperty_ShouldSetAndGetCorrectly()
        {
            SolverVelocity velocity = new SolverVelocity
            {
                V = new Vector2F(10.0f, 15.0f)
            };
            
            Assert.Equal(10.0f, velocity.V.X);
            Assert.Equal(15.0f, velocity.V.Y);
        }

        /// <summary>
        ///     Tests that w property should set and get correctly
        /// </summary>
        [Fact]
        public void WProperty_ShouldSetAndGetCorrectly()
        {
            SolverVelocity velocity = new SolverVelocity
            {
                W = 5.0f
            };
            
            Assert.Equal(5.0f, velocity.W);
        }

        /// <summary>
        ///     Tests that solver velocity should support negative linear velocity
        /// </summary>
        [Fact]
        public void SolverVelocity_ShouldSupportNegativeLinearVelocity()
        {
            SolverVelocity velocity = new SolverVelocity
            {
                V = new Vector2F(-5.0f, -10.0f)
            };
            
            Assert.Equal(-5.0f, velocity.V.X);
            Assert.Equal(-10.0f, velocity.V.Y);
        }

        /// <summary>
        ///     Tests that solver velocity should support negative angular velocity
        /// </summary>
        [Fact]
        public void SolverVelocity_ShouldSupportNegativeAngularVelocity()
        {
            SolverVelocity velocity = new SolverVelocity
            {
                W = -2.5f
            };
            
            Assert.Equal(-2.5f, velocity.W);
        }

        /// <summary>
        ///     Tests that solver velocity should be value type
        /// </summary>
        [Fact]
        public void SolverVelocity_ShouldBeValueType()
        {
            SolverVelocity velocity1 = new SolverVelocity { W = 1.0f };
            SolverVelocity velocity2 = velocity1;
            
            velocity2.W = 2.0f;
            
            Assert.NotEqual(velocity1.W, velocity2.W);
        }

        /// <summary>
        ///     Tests that solver velocity should handle zero velocity
        /// </summary>
        [Fact]
        public void SolverVelocity_ShouldHandleZeroVelocity()
        {
            SolverVelocity velocity = new SolverVelocity
            {
                V = Vector2F.Zero,
                W = 0.0f
            };
            
            Assert.Equal(Vector2F.Zero, velocity.V);
            Assert.Equal(0.0f, velocity.W);
        }

        /// <summary>
        ///     Tests that solver velocity should handle large velocity values
        /// </summary>
        [Fact]
        public void SolverVelocity_ShouldHandleLargeVelocityValues()
        {
            SolverVelocity velocity = new SolverVelocity
            {
                V = new Vector2F(1000.0f, 2000.0f),
                W = 100.0f
            };
            
            Assert.Equal(1000.0f, velocity.V.X);
            Assert.Equal(2000.0f, velocity.V.Y);
            Assert.Equal(100.0f, velocity.W);
        }

        /// <summary>
        ///     Tests that solver velocity should support small velocity values
        /// </summary>
        [Fact]
        public void SolverVelocity_ShouldSupportSmallVelocityValues()
        {
            SolverVelocity velocity = new SolverVelocity
            {
                V = new Vector2F(float.Epsilon, float.Epsilon),
                W = float.Epsilon
            };
            
            Assert.Equal(float.Epsilon, velocity.V.X);
            Assert.Equal(float.Epsilon, velocity.V.Y);
            Assert.Equal(float.Epsilon, velocity.W);
        }
    }
}

