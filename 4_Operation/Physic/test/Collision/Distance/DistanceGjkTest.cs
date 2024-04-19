// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DistanceGjkTest.cs
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
using Alis.Core.Aspect.Math;
using Alis.Core.Physic.Collision.ContactSystem;
using Alis.Core.Physic.Collision.Distance;
using Alis.Core.Physic.Collision.NarrowPhase;
using Alis.Core.Physic.Collision.TOI;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Collision.Distance
{
    /// <summary>
    /// The distance gjk test class
    /// </summary>
    public class DistanceGjkTest
    {
        /// <summary>
        /// Tests that test compute distance
        /// </summary>
        [Fact]
        public void TestComputeDistance()
        {
            // Arrange
            DistanceInput input = new DistanceInput();
            DistanceOutput output;
            SimplexCache cache;
            
            // Act
            Assert.Throws<NullReferenceException>(() =>DistanceGjk.ComputeDistance(ref input, out output, out cache));
            
            // Assert
            // Add your assertions here based on your business logic
        }
        
        /// <summary>
        /// Tests that test shape cast
        /// </summary>
        [Fact]
        public void TestShapeCast()
        {
            // Arrange
            ShapeCastInput input = new ShapeCastInput();
            ShapeCastOutput output;
            
            // Act
            Assert.Throws<NullReferenceException>(() => DistanceGjk.ShapeCast(ref input, out output));
            
            // Assert
            // Add your assertions here based on your business logic
        }
    }
}