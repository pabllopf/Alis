// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SimplexTest.cs
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
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision.Distance;
using Alis.Core.Physic.Collision.NarrowPhase;
using Xunit;

namespace Alis.Core.Physic.Test.Collision.NarrowPhase
{
    /// <summary>
    /// The simplex test class
    /// </summary>
    public class SimplexTest
    {
        /// <summary>
        /// Tests that test count property
        /// </summary>
        [Fact]
        public void Test_CountProperty()
        {
            // Arrange
            Simplex simplex = new Simplex();
            int expectedValue = 3;
            
            // Act
            simplex.Count = expectedValue;
            
            // Assert
            Assert.Equal(expectedValue, simplex.Count);
        }
        
        /// <summary>
        /// Tests that test read cache method
        /// </summary>
        [Fact]
        public void Test_ReadCacheMethod()
        {
            // Arrange
            Simplex simplex = new Simplex();
            SimplexCache cache = new SimplexCache();
            DistanceProxy proxyA = new DistanceProxy();
            Transform transformA = new Transform();
            DistanceProxy proxyB = new DistanceProxy();
            Transform transformB = new Transform();
            
            // Act
            Assert.Throws<NullReferenceException>(() => simplex.ReadCache(ref cache, ref proxyA, ref transformA, ref proxyB, ref transformB));
            
            // Assert
            // Add your assertions here based on what you expect after calling ReadCache
        }
        
        /// <summary>
        /// Tests that test write cache method
        /// </summary>
        [Fact]
        public void Test_WriteCacheMethod()
        {
            // Arrange
            Simplex simplex = new Simplex();
            SimplexCache cache = new SimplexCache();
            
            // Act
            simplex.WriteCache(ref cache);
            
            // Assert
            // Add your assertions here based on what you expect after calling WriteCache
        }
        
        /// <summary>
        /// Tests that test get search direction method
        /// </summary>
        [Fact]
        public void Test_GetSearchDirectionMethod()
        {
            // Arrange
            Simplex simplex = new Simplex();
            
            // Act
            Vector2 result = simplex.GetSearchDirection();
            
            // Assert
            // Add your assertions here based on what you expect from GetSearchDirection
        }
        
        /// <summary>
        /// Tests that test get closest point method
        /// </summary>
        [Fact]
        public void Test_GetClosestPointMethod()
        {
            // Arrange
            Simplex simplex = new Simplex();
            
            // Act
            Vector2 result = simplex.GetClosestPoint();
            
            // Assert
            // Add your assertions here based on what you expect from GetClosestPoint
        }
        
        /// <summary>
        /// Tests that test get witness points method
        /// </summary>
        [Fact]
        public void Test_GetWitnessPointsMethod()
        {
            // Arrange
            Simplex simplex = new Simplex();
            Vector2 pA, pB;
            
            // Act
            simplex.GetWitnessPoints(out pA, out pB);
            
            // Assert
            // Add your assertions here based on what you expect from GetWitnessPoints
        }
        
        /// <summary>
        /// Tests that test solve 2 method
        /// </summary>
        [Fact]
        public void Test_Solve2Method()
        {
            // Arrange
            Simplex simplex = new Simplex();
            
            // Act
            simplex.Solve2();
            
            // Assert
            // Add your assertions here based on what you expect after calling Solve2
        }
        
        /// <summary>
        /// Tests that test solve 3 method
        /// </summary>
        [Fact]
        public void Test_Solve3Method()
        {
            // Arrange
            Simplex simplex = new Simplex();
            
            // Act
            simplex.Solve3();
            
            // Assert
            // Add your assertions here based on what you expect after calling Solve3
        }
    }
}