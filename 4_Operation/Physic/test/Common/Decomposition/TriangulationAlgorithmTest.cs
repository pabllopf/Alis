// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TriangulationAlgorithmTest.cs
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

using Alis.Core.Physic.Common.Decomposition;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition
{
    /// <summary>
    ///     The triangulation algorithm test class
    /// </summary>
    public class TriangulationAlgorithmTest
    {
        /// <summary>
        ///     Tests that earclip enum value should be defined
        /// </summary>
        [Fact]
        public void EarclipEnumValue_ShouldBeDefined()
        {
            TriangulationAlgorithm algorithm = TriangulationAlgorithm.Earclip;
            
            Assert.Equal(TriangulationAlgorithm.Earclip, algorithm);
        }

        /// <summary>
        ///     Tests that bayazit enum value should be defined
        /// </summary>
        [Fact]
        public void BayazitEnumValue_ShouldBeDefined()
        {
            TriangulationAlgorithm algorithm = TriangulationAlgorithm.Bayazit;
            
            Assert.Equal(TriangulationAlgorithm.Bayazit, algorithm);
        }

        /// <summary>
        ///     Tests that flipcode enum value should be defined
        /// </summary>
        [Fact]
        public void FlipcodeEnumValue_ShouldBeDefined()
        {
            TriangulationAlgorithm algorithm = TriangulationAlgorithm.Flipcode;
            
            Assert.Equal(TriangulationAlgorithm.Flipcode, algorithm);
        }

        /// <summary>
        ///     Tests that seidel enum value should be defined
        /// </summary>
        [Fact]
        public void SeidelEnumValue_ShouldBeDefined()
        {
            TriangulationAlgorithm algorithm = TriangulationAlgorithm.Seidel;
            
            Assert.Equal(TriangulationAlgorithm.Seidel, algorithm);
        }

        /// <summary>
        ///     Tests that seidel trapezoids enum value should be defined
        /// </summary>
        [Fact]
        public void SeidelTrapezoidsEnumValue_ShouldBeDefined()
        {
            TriangulationAlgorithm algorithm = TriangulationAlgorithm.SeidelTrapezoids;
            
            Assert.Equal(TriangulationAlgorithm.SeidelTrapezoids, algorithm);
        }

        /// <summary>
        ///     Tests that delauny enum value should be defined
        /// </summary>
        [Fact]
        public void DelaunyEnumValue_ShouldBeDefined()
        {
            TriangulationAlgorithm algorithm = TriangulationAlgorithm.Delauny;
            
            Assert.Equal(TriangulationAlgorithm.Delauny, algorithm);
        }

        /// <summary>
        ///     Tests that triangulation algorithm should have six values
        /// </summary>
        [Fact]
        public void TriangulationAlgorithm_ShouldHaveSixValues()
        {
            var values = System.Enum.GetValues(typeof(TriangulationAlgorithm));
            
            Assert.Equal(6, values.Length);
        }

        /// <summary>
        ///     Tests that triangulation algorithm should be castable to int
        /// </summary>
        [Fact]
        public void TriangulationAlgorithm_ShouldBeCastableToInt()
        {
            int earclipValue = (int)TriangulationAlgorithm.Earclip;
            int bayazitValue = (int)TriangulationAlgorithm.Bayazit;
            int flipcodeValue = (int)TriangulationAlgorithm.Flipcode;
            
            Assert.Equal(0, earclipValue);
            Assert.Equal(1, bayazitValue);
            Assert.Equal(2, flipcodeValue);
        }

        /// <summary>
        ///     Tests that triangulation algorithm should support equality comparison
        /// </summary>
        [Fact]
        public void TriangulationAlgorithm_ShouldSupportEqualityComparison()
        {
            TriangulationAlgorithm algo1 = TriangulationAlgorithm.Bayazit;
            TriangulationAlgorithm algo2 = TriangulationAlgorithm.Bayazit;
            
            Assert.Equal(algo1, algo2);
        }

        /// <summary>
        ///     Tests that triangulation algorithm should support inequality comparison
        /// </summary>
        [Fact]
        public void TriangulationAlgorithm_ShouldSupportInequalityComparison()
        {
            TriangulationAlgorithm algo1 = TriangulationAlgorithm.Earclip;
            TriangulationAlgorithm algo2 = TriangulationAlgorithm.Delauny;
            
            Assert.NotEqual(algo1, algo2);
        }

        /// <summary>
        ///     Tests that triangulation algorithm should support switch statement
        /// </summary>
        [Fact]
        public void TriangulationAlgorithm_ShouldSupportSwitchStatement()
        {
            TriangulationAlgorithm algorithm = TriangulationAlgorithm.Seidel;
            string result = algorithm switch
            {
                TriangulationAlgorithm.Earclip => "Earclip",
                TriangulationAlgorithm.Bayazit => "Bayazit",
                TriangulationAlgorithm.Flipcode => "Flipcode",
                TriangulationAlgorithm.Seidel => "Seidel",
                TriangulationAlgorithm.SeidelTrapezoids => "SeidelTrapezoids",
                TriangulationAlgorithm.Delauny => "Delauny",
                _ => "Unknown"
            };
            
            Assert.Equal("Seidel", result);
        }
    }
}

