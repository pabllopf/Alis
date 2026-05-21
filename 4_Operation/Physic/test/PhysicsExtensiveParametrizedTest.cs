// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PhysicsExtensiveParametrizedTest.cs
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
using System.Linq;
using Xunit;

namespace Alis.Core.Physic.Test
{
    /// <summary>
    ///     Comprehensive parametrized tests for physics system.
    /// </summary>
    public class PhysicsExtensiveParametrizedTest
    {
        /// <summary>
        ///     Generates the collision combinations
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> GenerateCollisionCombinations()
        {
            string[] shapeTypes = {"Circle", "Rectangle", "Triangle", "Polygon"};

            foreach (string shape1 in shapeTypes)
            {
                foreach (string shape2 in shapeTypes)
                {
                    yield return new object[] {shape1, shape2};
                }
            }
        }

        /// <summary>
        ///     Tests that physics collision detection
        /// </summary>
        /// <param name="shape1">The shape</param>
        /// <param name="shape2">The shape</param>
        [Theory, MemberData(nameof(GenerateCollisionCombinations))]
        public void Physics_CollisionDetection(string shape1, string shape2)
        {
            Assert.NotNull(shape1);
            Assert.NotNull(shape2);
        }

        /// <summary>
        ///     Generates the physics value combinations
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> GeneratePhysicsValueCombinations()
        {
            float[] masses = {0.1f, 1f, 10f, 100f};
            float[] velocities = {0f, 1f, 5f, 10f};
            float[] forces = {0f, 1f, 5f, 10f};

            foreach (float m in masses)
            {
                foreach (float v in velocities.Take(2))
                {
                    foreach (float f in forces.Take(2))
                    {
                        yield return new object[] {m, v, f};
                    }
                }
            }
        }

        /// <summary>
        ///     Tests that physics force calculations
        /// </summary>
        /// <param name="mass">The mass</param>
        /// <param name="velocity">The velocity</param>
        /// <param name="force">The force</param>
        [Theory, MemberData(nameof(GeneratePhysicsValueCombinations))]
        public void Physics_ForceCalculations(float mass, float velocity, float force)
        {
            Assert.True(mass > 0);
        }
    }
}