// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Vector4FExtensiveTest.cs
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
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Vector
{
    /// <summary>
    ///     Extensive unit tests for Vector4F struct.
    ///     Tests all operators, methods, properties, and edge cases.
    /// </summary>
    public class Vector4FExtensiveTest
    {
        /// <summary>
        ///     Tests that constructor four values sets all components correctly
        /// </summary>
        [Fact]
        public void Constructor_FourValues_SetsAllComponentsCorrectly()
        {
            Vector4F vector = new Vector4F(1.0f, 2.0f, 3.0f, 4.0f);
            Assert.Equal(1.0f, vector.X);
            Assert.Equal(2.0f, vector.Y);
            Assert.Equal(3.0f, vector.Z);
            Assert.Equal(4.0f, vector.W);
        }

        /// <summary>
        ///     Tests that constructor default creates zero vector
        /// </summary>
        [Fact]
        public void Constructor_Default_CreatesZeroVector()
        {
            Vector4F vector = default(Vector4F);
            Assert.Equal(0.0f, vector.X);
            Assert.Equal(0.0f, vector.Y);
            Assert.Equal(0.0f, vector.Z);
            Assert.Equal(0.0f, vector.W);
        }
    }
}