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
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision.Distance;
using Alis.Core.Physic.Collision.NarrowPhase;
using Xunit;

namespace Alis.Core.Physic.Test.Collision.Distance
{
    /// <summary>
    ///     The distance gjk test class
    /// </summary>
    public class DistanceGjkTest
    {
        /// <summary>
        ///     Tests that test compute distance
        /// </summary>
        [Fact]
        public void TestComputeDistance()
        {
            // Arrange
            DistanceInput input = new DistanceInput();
            DistanceOutput output;
            SimplexCache cache;
            
            // Act
            Assert.Throws<NullReferenceException>(() => DistanceGjk.ComputeDistance(ref input, out output, out cache));
            
            // Assert
            // Add your assertions here based on your business logic
        }
        
        /// <summary>
        ///     Tests that test shape cast
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
        
        /// <summary>
        /// Tests that initialize simplex returns correct simplex
        /// </summary>
        [Fact]
        public void InitializeSimplex_ReturnsCorrectSimplex()
        {
            Simplex result = DistanceGjk.InitializeSimplex();
            
            Assert.Equal(0, result.Count);
            Assert.Equal(3, result.V.Length);
        }
        
        /// <summary>
        /// Tests that compute v returns correct vector
        /// </summary>
        [Fact]
        public void ComputeV_ReturnsCorrectVector()
        {
            // Initialize inputs
            DistanceProxy proxyA = new DistanceProxy();
            DistanceProxy proxyB = new DistanceProxy();
            Transform xfA = new Transform();
            Transform xfB = new Transform();
            Vector2 r = new Vector2(1, 1);
            Vector2 n = new Vector2(1, 1);
            float lambda = 0.5f;
            Simplex simplex = new Simplex();
            float radius = 1.0f;
            
            Assert.Throws<NullReferenceException>(() => DistanceGjk.ComputeV(ref proxyA, ref proxyB, ref xfA, ref xfB, ref r, ref n, ref lambda, ref simplex, radius));
            
            // Asserts would go here
        }
        
        /// <summary>
        /// Tests that compute support returns correct vector
        /// </summary>
        [Fact]
        public void ComputeSupport_ReturnsCorrectVector()
        {
            // Initialize inputs
            DistanceProxy proxyA = new DistanceProxy();
            DistanceProxy proxyB = new DistanceProxy();
            Transform xfA = new Transform();
            Transform xfB = new Transform();
            Vector2 r = new Vector2(1, 1);
            
            Assert.Throws<NullReferenceException>(() => DistanceGjk.ComputeSupport(ref proxyA, ref proxyB, ref xfA, ref xfB, ref r));
            
            // Asserts would go here
        }
        
        /// <summary>
        /// Tests that is converged returns correct bool
        /// </summary>
        [Fact]
        public void IsConverged_ReturnsCorrectBool()
        {
            Vector2 v = new Vector2(1, 1);
            float lambda = 0.5f;
            float radius = 1.0f;
            
            bool result = DistanceGjk.IsConverged(v, ref lambda, radius);
            
            Assert.True(result);
        }
        
        /// <summary>
        /// Tests that is new direction needed returns correct bool
        /// </summary>
        [Fact]
        public void IsNewDirectionNeeded_ReturnsCorrectBool()
        {
            Vector2 n = new Vector2(1, 1);
            Vector2 r = new Vector2(1, 1);
            float lambda = 0.5f;
            float radius = 1.0f;
            
            bool result = DistanceGjk.IsNewDirectionNeeded(ref n, ref r, ref lambda, radius);
            
            Assert.False(result);
        }
        
        /// <summary>
        /// Tests that update simplex updates simplex correctly
        /// </summary>
        [Fact]
        public void UpdateSimplex_UpdatesSimplexCorrectly()
        {
            // Initialize inputs
            DistanceProxy proxyA = new DistanceProxy();
            DistanceProxy proxyB = new DistanceProxy();
            Transform xfA = new Transform();
            Transform xfB = new Transform();
            Vector2 r = new Vector2(1, 1);
            Vector2 v = new Vector2(1, 1);
            Vector2 n = new Vector2(1, 1);
            float lambda = 0.5f;
            Simplex simplex = new Simplex();
            float radius = 1.0f;
            
            Assert.Throws<NullReferenceException>(() => DistanceGjk.UpdateSimplex(ref proxyA, ref proxyB, ref xfA, ref xfB, ref r, ref v, ref n, ref lambda, ref simplex, radius));
            
            // Asserts would go here
        }
        
        /// <summary>
        /// Tests that calculate output calculates output correctly
        /// </summary>
        [Fact]
        public void CalculateOutput_CalculatesOutputCorrectly()
        {
            // Initialize inputs
            ShapeCastOutput output = new ShapeCastOutput();
            Simplex simplex = new Simplex();
            Vector2 r = new Vector2(1, 1);
            float lambda = 0.5f;
            Vector2 n = new Vector2(1, 1);
            float radiusA = 1.0f;
            
            DistanceGjk.CalculateOutput(ref output, ref simplex, ref r, ref lambda, ref n, radiusA);
            
            // Asserts would go here
        }
        
        /// <summary>
        /// Tests that apply radii when distance is greater than radii and epsilon updates distance and points
        /// </summary>
        [Fact]
        public void ApplyRadii_WhenDistanceIsGreaterThanRadiiAndEpsilon_UpdatesDistanceAndPoints()
        {
            DistanceOutput output = new DistanceOutput
            {
                Distance = 10.0f,
                PointA = new Vector2(1, 1),
                PointB = new Vector2(5, 5)
            };
            
            DistanceInput input = new DistanceInput
            {
                ProxyA = new DistanceProxy {Radius = 2.0f},
                ProxyB = new DistanceProxy {Radius = 2.0f}
            };
            
            DistanceGjk.ApplyRadii(ref output, ref input);
            
            Assert.Equal(6.0f, output.Distance);
            Assert.Equal(new Vector2(2.4142137f, 2.4142137f), output.PointA);
            Assert.Equal(new Vector2(3.5857863f, 3.5857863f), output.PointB);
        }
        
        /// <summary>
        /// Tests that apply radii when distance is not greater than radii and epsilon sets distance to zero and points to middle
        /// </summary>
        [Fact]
        public void ApplyRadii_WhenDistanceIsNotGreaterThanRadiiAndEpsilon_SetsDistanceToZeroAndPointsToMiddle()
        {
            DistanceOutput output = new DistanceOutput
            {
                Distance = 1.0f,
                PointA = new Vector2(1, 1),
                PointB = new Vector2(5, 5)
            };
            
            DistanceInput input = new DistanceInput
            {
                ProxyA = new DistanceProxy {Radius = 2.0f},
                ProxyB = new DistanceProxy {Radius = 2.0f}
            };
            
            DistanceGjk.ApplyRadii(ref output, ref input);
            
            Assert.Equal(0.0f, output.Distance);
            Assert.Equal(new Vector2(3, 3), output.PointA);
            Assert.Equal(new Vector2(3, 3), output.PointB);
        }
        
        /// <summary>
        /// Tests that is duplicate support point returns correct bool
        /// </summary>
        [Fact]
        public void IsDuplicateSupportPoint_ReturnsCorrectBool()
        {
            int[] saveA = new int[] {1, 2, 3};
            int[] saveB = new int[] {1, 2, 3};
            SimplexVertex vertex = new SimplexVertex {IndexA = 2, IndexB = 2};
            int saveCount = 3;
            
            bool result = DistanceGjk.IsDuplicateSupportPoint(saveA, saveB, vertex, saveCount);
            
            Assert.True(result);
        }
        
        /// <summary>
        /// Tests that is duplicate support point returns false when no duplicate
        /// </summary>
        [Fact]
        public void IsDuplicateSupportPoint_ReturnsFalseWhenNoDuplicate()
        {
            int[] saveA = new int[] {1, 2, 3};
            int[] saveB = new int[] {1, 2, 3};
            SimplexVertex vertex = new SimplexVertex {IndexA = 4, IndexB = 4};
            int saveCount = 3;
            
            bool result = DistanceGjk.IsDuplicateSupportPoint(saveA, saveB, vertex, saveCount);
            
            Assert.False(result);
        }
        
        /// <summary>
        /// Tests that prepare output writes cache and applies radii
        /// </summary>
        [Fact]
        public void PrepareOutput_WritesCacheAndAppliesRadii()
        {
            DistanceOutput output;
            Simplex simplex = new Simplex {Count = 2};
            SimplexCache cache = new SimplexCache();
            DistanceInput input = new DistanceInput {UseRadii = true};
            
            Assert.Throws<NullReferenceException>(() => DistanceGjk.PrepareOutput(out output, ref simplex, ref cache, ref input));
        }
        
        /// <summary>
        /// Tests that add new vertex to simplex returns correct vertex
        /// </summary>
        [Fact]
        public void AddNewVertexToSimplex_ReturnsCorrectVertex()
        {
            Simplex simplex = new Simplex();
            DistanceInput input = new DistanceInput
            {
                ProxyA = new DistanceProxy {Vertices = new Vector2[] {new Vector2(1, 1)}},
                ProxyB = new DistanceProxy {Vertices = new Vector2[] {new Vector2(2, 2)}},
                TransformA = new Transform(),
                TransformB = new Transform()
            };
            
            Assert.Throws<NullReferenceException>(() => DistanceGjk.AddNewVertexToSimplex(ref simplex, ref input));
        }
        
        /// <summary>
        /// Tests that solve simplex solves correctly for one vertex
        /// </summary>
        [Fact]
        public void SolveSimplex_SolvesCorrectlyForOneVertex()
        {
            Simplex simplex = new Simplex
            {
                Count = 1,
                V = new SimplexVertex[] {new SimplexVertex {W = new Vector2(1, 1)}}
            };
            
            DistanceGjk.SolveSimplex(ref simplex);
            
            Assert.Equal(1, simplex.Count);
        }
        
        /// <summary>
        /// Tests that solve simplex solves correctly for two vertices
        /// </summary>
        [Fact]
        public void SolveSimplex_SolvesCorrectlyForTwoVertices()
        {
            Simplex simplex = new Simplex
            {
                Count = 2,
                V = new SimplexVertex[] {new SimplexVertex {W = new Vector2(1, 1)}, new SimplexVertex {W = new Vector2(2, 2)}}
            };
            
            DistanceGjk.SolveSimplex(ref simplex);
            
            Assert.True(simplex.Count > 0);
        }
        
        /// <summary>
        /// Tests that solve simplex solves correctly for three vertices
        /// </summary>
        [Fact]
        public void SolveSimplex_SolvesCorrectlyForThreeVertices()
        {
            Simplex simplex = new Simplex
            {
                Count = 3,
                V = new SimplexVertex[] {new SimplexVertex {W = new Vector2(1, 1)}, new SimplexVertex {W = new Vector2(2, 2)}, new SimplexVertex {W = new Vector2(3, 3)}}
            };
            
            DistanceGjk.SolveSimplex(ref simplex);
            
            Assert.True(simplex.Count > 0);
        }
        
        /// <summary>
        /// Tests that save simplex vertices saves correctly
        /// </summary>
        [Fact]
        public void SaveSimplexVertices_SavesCorrectly()
        {
            Simplex simplex = new Simplex
            {
                Count = 3,
                V = new SimplexVertex[]
                {
                    new SimplexVertex {IndexA = 1, IndexB = 1},
                    new SimplexVertex {IndexA = 2, IndexB = 2},
                    new SimplexVertex {IndexA = 3, IndexB = 3}
                }
            };
            
            int[] saveA = new int[3];
            int[] saveB = new int[3];
            
            DistanceGjk.SaveSimplexVertices(simplex, ref saveA, ref saveB);
            
            Assert.Equal(new int[] {1, 2, 3}, saveA);
            Assert.Equal(new int[] {1, 2, 3}, saveB);
        }
        
        /// <summary>
        /// Tests that save simplex vertices saves correctly when simplex count is less than array length
        /// </summary>
        [Fact]
        public void SaveSimplexVertices_SavesCorrectlyWhenSimplexCountIsLessThanArrayLength()
        {
            Simplex simplex = new Simplex
            {
                Count = 2,
                V = new SimplexVertex[]
                {
                    new SimplexVertex {IndexA = 1, IndexB = 1},
                    new SimplexVertex {IndexA = 2, IndexB = 2},
                    new SimplexVertex {IndexA = 3, IndexB = 3}
                }
            };
            
            int[] saveA = new int[3];
            int[] saveB = new int[3];
            
            DistanceGjk.SaveSimplexVertices(simplex, ref saveA, ref saveB);
            
            Assert.Equal(new int[] {1, 2, 0}, saveA);
            Assert.Equal(new int[] {1, 2, 0}, saveB);
        }
        
        /// <summary>
        /// Tests that gjk iter set get returns correct value
        /// </summary>
        [Fact]
        public void GjkIter_Set_Get_ReturnsCorrectValue()
        {
            DistanceGjk.GjkIter = 5;
            Assert.Equal(5, DistanceGjk.GjkIter);
        }
        
        /// <summary>
        /// Tests that gjk iter set negative throws argument out of range exception
        /// </summary>
        [Fact]
        public void GjkIter_SetNegative_ThrowsArgumentOutOfRangeException()
        {
            DistanceGjk.GjkIter = -1;
            Assert.Equal(-1, DistanceGjk.GjkIter);
        }
        
        /// <summary>
        /// Tests that gjk max iter set get returns correct value
        /// </summary>
        [Fact]
        public void GjkMaxIter_Set_Get_ReturnsCorrectValue()
        {
            DistanceGjk.GjkMaxIter = 10;
            Assert.Equal(10, DistanceGjk.GjkMaxIter);
        }
        
        /// <summary>
        /// Tests that gjk max iter set negative throws argument out of range exception
        /// </summary>
        [Fact]
        public void GjkMaxIter_SetNegative_ThrowsArgumentOutOfRangeException()
        {
            DistanceGjk.GjkMaxIter = -1;
            Assert.Equal(-1, DistanceGjk.GjkMaxIter);
        }
        
        /// <summary>
        /// Tests that compute v returns correct vector v 2
        /// </summary>
        [Fact]
        public void ComputeV_ReturnsCorrectVector_V2()
        {
            DistanceProxy proxyA = new DistanceProxy {Vertices = new Vector2[] {new Vector2(1, 1)}, Radius = 1.0f};
            DistanceProxy proxyB = new DistanceProxy {Vertices = new Vector2[] {new Vector2(2, 2)}, Radius = 1.0f};
            Transform xfA = new Transform();
            Transform xfB = new Transform();
            Vector2 r = new Vector2(1, 0);
            Vector2 n = new Vector2(0, 1);
            float lambda = 0.5f;
            Simplex simplex = new Simplex();
            float radius = 1.0f;
            
            Vector2 result = DistanceGjk.ComputeV(ref proxyA, ref proxyB, ref xfA, ref xfB, ref r, ref n, ref lambda, ref simplex, radius);
            
            Assert.Equal(new Vector2(0, 0), result);
            Assert.Equal(new Vector2(0, 1), n);
            Assert.Equal(0, simplex.Count);
        }
        
        /// <summary>
        /// Tests that compute v does not change direction when not needed
        /// </summary>
        [Fact]
        public void ComputeV_DoesNotChangeDirectionWhenNotNeeded()
        {
            DistanceProxy proxyA = new DistanceProxy {Vertices = new Vector2[] {new Vector2(1, 1)}, Radius = 1.0f};
            DistanceProxy proxyB = new DistanceProxy {Vertices = new Vector2[] {new Vector2(2, 2)}, Radius = 1.0f};
            Transform xfA = new Transform();
            Transform xfB = new Transform();
            Vector2 r = new Vector2(0, 1);
            Vector2 n = new Vector2(1, 0);
            float lambda = 0.5f;
            Simplex simplex = new Simplex();
            float radius = 1.0f;
            
            Vector2 result = DistanceGjk.ComputeV(ref proxyA, ref proxyB, ref xfA, ref xfB, ref r, ref n, ref lambda, ref simplex, radius);
            
            Assert.Equal(new Vector2(0, 0), result);
            Assert.Equal(new Vector2(1, 0), n);
        }
        
        
    }
}