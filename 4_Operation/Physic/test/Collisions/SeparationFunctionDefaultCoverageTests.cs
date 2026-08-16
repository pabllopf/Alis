// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SeparationFunctionDefaultCoverageTests.cs
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

using System.Reflection;
using Alis.Core.Physic.Collisions;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    ///     The separation function default coverage tests class
    /// </summary>
    public class SeparationFunctionDefaultCoverageTests
    {
        /// <summary>
        ///     Sets the internal separation type to an invalid value.
        /// </summary>
        private static void SetInvalidType()
        {
            FieldInfo field = typeof(SeparationFunction).GetField("_type",
                BindingFlags.NonPublic | BindingFlags.Static);
            field.SetValue(null, (SeparationFunctionType) 99);
        }

        /// <summary>
        ///     Tests that find min separation with an invalid type returns zero.
        /// </summary>
        [Fact]
        public void FindMinSeparation_WithInvalidType_ReturnsZero()
        {
            SetInvalidType();

            float result = SeparationFunction.FindMinSeparation(out int indexA, out int indexB, 0.0f);

            Assert.Equal(0.0f, result);
            Assert.Equal(-1, indexA);
            Assert.Equal(-1, indexB);
        }

        /// <summary>
        ///     Tests that evaluate with an invalid type returns zero.
        /// </summary>
        [Fact]
        public void Evaluate_WithInvalidType_ReturnsZero()
        {
            SetInvalidType();

            float result = SeparationFunction.Evaluate(0, 0, 0.0f);

            Assert.Equal(0.0f, result);
        }
    }
}
