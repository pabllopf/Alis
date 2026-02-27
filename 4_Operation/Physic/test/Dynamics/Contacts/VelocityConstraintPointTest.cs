// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VelocityConstraintPointTest.cs
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
using Alis.Core.Physic.Dynamics.Contacts;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Contacts
{
    /// <summary>
    ///     The velocity constraint point test class
    /// </summary>
    public class VelocityConstraintPointTest
    {
        /// <summary>
        ///     Tests that default constructor should initialize with default values
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldInitializeWithDefaultValues()
        {
            VelocityConstraintPoint point = new VelocityConstraintPoint();
            
            Assert.Equal(0.0f, point.NormalImpulse);
            Assert.Equal(0.0f, point.NormalMass);
            Assert.Equal(Vector2F.Zero, point.Ra);
            Assert.Equal(Vector2F.Zero, point.Rb);
            Assert.Equal(0.0f, point.TangentImpulse);
            Assert.Equal(0.0f, point.TangentMass);
            Assert.Equal(0.0f, point.VelocityBias);
        }

        /// <summary>
        ///     Tests that normal impulse should set and get correctly
        /// </summary>
        [Fact]
        public void NormalImpulse_ShouldSetAndGetCorrectly()
        {
            VelocityConstraintPoint point = new VelocityConstraintPoint
            {
                NormalImpulse = 5.5f
            };
            
            Assert.Equal(5.5f, point.NormalImpulse);
        }

        /// <summary>
        ///     Tests that normal mass should set and get correctly
        /// </summary>
        [Fact]
        public void NormalMass_ShouldSetAndGetCorrectly()
        {
            VelocityConstraintPoint point = new VelocityConstraintPoint
            {
                NormalMass = 10.0f
            };
            
            Assert.Equal(10.0f, point.NormalMass);
        }

        /// <summary>
        ///     Tests that ra should set and get correctly
        /// </summary>
        [Fact]
        public void Ra_ShouldSetAndGetCorrectly()
        {
            VelocityConstraintPoint point = new VelocityConstraintPoint
            {
                Ra = new Vector2F(3, 4)
            };
            
            Assert.Equal(new Vector2F(3, 4), point.Ra);
        }

        /// <summary>
        ///     Tests that rb should set and get correctly
        /// </summary>
        [Fact]
        public void Rb_ShouldSetAndGetCorrectly()
        {
            VelocityConstraintPoint point = new VelocityConstraintPoint
            {
                Rb = new Vector2F(5, 6)
            };
            
            Assert.Equal(new Vector2F(5, 6), point.Rb);
        }

        /// <summary>
        ///     Tests that tangent impulse should set and get correctly
        /// </summary>
        [Fact]
        public void TangentImpulse_ShouldSetAndGetCorrectly()
        {
            VelocityConstraintPoint point = new VelocityConstraintPoint
            {
                TangentImpulse = 2.5f
            };
            
            Assert.Equal(2.5f, point.TangentImpulse);
        }

        /// <summary>
        ///     Tests that tangent mass should set and get correctly
        /// </summary>
        [Fact]
        public void TangentMass_ShouldSetAndGetCorrectly()
        {
            VelocityConstraintPoint point = new VelocityConstraintPoint
            {
                TangentMass = 8.0f
            };
            
            Assert.Equal(8.0f, point.TangentMass);
        }

        /// <summary>
        ///     Tests that velocity bias should set and get correctly
        /// </summary>
        [Fact]
        public void VelocityBias_ShouldSetAndGetCorrectly()
        {
            VelocityConstraintPoint point = new VelocityConstraintPoint
            {
                VelocityBias = 1.5f
            };
            
            Assert.Equal(1.5f, point.VelocityBias);
        }

        /// <summary>
        ///     Tests that velocity constraint point should handle negative values
        /// </summary>
        [Fact]
        public void VelocityConstraintPoint_ShouldHandleNegativeValues()
        {
            VelocityConstraintPoint point = new VelocityConstraintPoint
            {
                NormalImpulse = -5.0f,
                TangentImpulse = -3.0f
            };
            
            Assert.Equal(-5.0f, point.NormalImpulse);
            Assert.Equal(-3.0f, point.TangentImpulse);
        }

        /// <summary>
        ///     Tests that velocity constraint point should be sealed class
        /// </summary>
        [Fact]
        public void VelocityConstraintPoint_ShouldBeSealedClass()
        {
            var type = typeof(VelocityConstraintPoint);
            
            Assert.True(type.IsSealed);
        }

        /// <summary>
        ///     Tests that velocity constraint point should handle all properties together
        /// </summary>
        [Fact]
        public void VelocityConstraintPoint_ShouldHandleAllPropertiesTogether()
        {
            VelocityConstraintPoint point = new VelocityConstraintPoint
            {
                NormalImpulse = 1.0f,
                NormalMass = 2.0f,
                Ra = new Vector2F(3, 4),
                Rb = new Vector2F(5, 6),
                TangentImpulse = 7.0f,
                TangentMass = 8.0f,
                VelocityBias = 9.0f
            };
            
            Assert.Equal(1.0f, point.NormalImpulse);
            Assert.Equal(2.0f, point.NormalMass);
            Assert.Equal(new Vector2F(3, 4), point.Ra);
            Assert.Equal(new Vector2F(5, 6), point.Rb);
            Assert.Equal(7.0f, point.TangentImpulse);
            Assert.Equal(8.0f, point.TangentMass);
            Assert.Equal(9.0f, point.VelocityBias);
        }

        /// <summary>
        ///     Tests that velocity constraint point should allow zero values
        /// </summary>
        [Fact]
        public void VelocityConstraintPoint_ShouldAllowZeroValues()
        {
            VelocityConstraintPoint point = new VelocityConstraintPoint
            {
                NormalImpulse = 0.0f,
                NormalMass = 0.0f,
                TangentImpulse = 0.0f,
                TangentMass = 0.0f,
                VelocityBias = 0.0f
            };
            
            Assert.Equal(0.0f, point.NormalImpulse);
            Assert.Equal(0.0f, point.NormalMass);
        }
    }
}

