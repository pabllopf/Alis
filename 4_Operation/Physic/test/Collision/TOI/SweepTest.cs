// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SweepTest.cs
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
using Alis.Core.Physic.Collision.TOI;
using Xunit;

namespace Alis.Core.Physic.Test.Collision.TOI
{
    /// <summary>
    ///     The sweep test class
    /// </summary>
    public class SweepTest
    {
        /// <summary>
        ///     Tests that test advance
        /// </summary>
        [Fact]
        public void Test_Advance()
        {
            // Arrange
            Sweep sweep = new Sweep
            {
                Alpha0 = 0.5f,
                C0 = new Vector2(1, 1),
                C = new Vector2(2, 2),
                A0 = 0.5f,
                A = 1.0f
            };
            
            // Act
            sweep.Advance(0.75f);
            
            // Assert
            Assert.Equal(0.75f, sweep.Alpha0);
            Assert.Equal(1.5f, sweep.C0.X);
            Assert.Equal(1.5f, sweep.C0.Y);
            Assert.Equal(0.75f, sweep.A0);
        }
        
        /// <summary>
        ///     Tests that test get transform
        /// </summary>
        [Fact]
        public void Test_GetTransform()
        {
            // Arrange
            Sweep sweep = new Sweep
            {
                C0 = new Vector2(1, 1),
                C = new Vector2(2, 2),
                A0 = 0.5f,
                A = 1.0f,
                LocalCenter = new Vector2(0.5f, 0.5f)
            };
            
            // Act
            sweep.GetTransform(out Transform transform, 0.5f);
            
            // Assert
            Assert.Equal(1.47f, transform.Position.X, 0.1f);
            Assert.Equal(0.79f, transform.Position.Y, 0.1f);
            Assert.Equal(0.75f, transform.Rotation.GetAngle());
        }
        
        /// <summary>
        ///     Tests that test normalize
        /// </summary>
        [Fact]
        public void Test_Normalize()
        {
            // Arrange
            Sweep sweep = new Sweep
            {
                A0 = 7 * (float) Math.PI, // 3.5 full rotations
                A = 8 * (float) Math.PI // 4 full rotations
            };
            
            // Act
            sweep.Normalize();
            
            // Assert
            Assert.Equal((float) Math.PI, sweep.A0, 0.1f);
            Assert.Equal(6.28f, sweep.A, 0.1f);
        }
    }
}