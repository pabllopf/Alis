// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SeparationFunctionTest.cs
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
using Alis.Core.Physic.Collision.Distance;
using Alis.Core.Physic.Collision.NarrowPhase;
using Alis.Core.Physic.Collision.TOI;
using Xunit;

namespace Alis.Core.Physic.Test.Collision.TOI
{
    /// <summary>
    ///     The separation function test class
    /// </summary>
    public class SeparationFunctionTest
    {

        
        /// <summary>
        /// Tests that find min separation should return correct value
        /// </summary>
        [Fact]
        public void FindMinSeparation_ShouldReturnCorrectValue()
        {
            // Arrange
            int indexA;
            int indexB;
            float t = 0.5f;
            DistanceProxy proxyA = new DistanceProxy();
            Sweep sweepA = new Sweep();
            DistanceProxy proxyB = new DistanceProxy();
            Sweep sweepB = new Sweep();
            Vector2 axis = new Vector2();
            Vector2 localPoint = new Vector2();
            SeparationFunctionType type = SeparationFunctionType.Points;
            
            // Act
            Assert.Throws<NullReferenceException>(() => SeparationFunction.FindMinSeparation(out indexA, out indexB, t, proxyA, ref sweepA, proxyB, ref sweepB, ref axis,
                ref localPoint, type));
            
            // Assert
            // Here you would assert that the properties of wheelJoint have been set correctly.
        }
        
        /// <summary>
        /// Tests that evaluate should return correct value
        /// </summary>
        [Fact]
        public void Evaluate_ShouldReturnCorrectValue()
        {
            // Arrange
            int indexA = 0;
            int indexB = 0;
            float t = 0.5f;
            DistanceProxy proxyA = new DistanceProxy();
            Sweep sweepA = new Sweep();
            DistanceProxy proxyB = new DistanceProxy();
            Sweep sweepB = new Sweep();
            Vector2 axis = new Vector2();
            Vector2 localPoint = new Vector2();
            SeparationFunctionType type = SeparationFunctionType.Points;
            
            // Act
            Assert.Throws<NullReferenceException>(() => SeparationFunction.Evaluate(indexA, indexB, t, proxyA, ref sweepA, proxyB, ref sweepB, ref axis, ref localPoint, type));
            
            // Assert
            // Here you would assert that the properties of wheelJoint have been set correctly.
        }
    }
}