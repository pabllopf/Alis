// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Ivec3CoverageTests.cs
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

using Alis.Extension.Graphic.Sfml.Render;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    ///     The ivec 3 coverage tests class
    /// </summary>
    public class Ivec3CoverageTests
    {
        /// <summary>
        ///     Tests that the constructor assigns the components
        /// </summary>
        [Fact]
        public void Constructor_AssignsComponents()
        {
            Ivec3 vec = new Ivec3(1, 2, 3);

            Assert.Equal(1, vec.X);
            Assert.Equal(2, vec.Y);
            Assert.Equal(3, vec.Z);
        }

        /// <summary>
        ///     Tests that the default constructor leaves components zero
        /// </summary>
        [Fact]
        public void DefaultConstructor_ComponentsAreZero()
        {
            Ivec3 vec = default(Ivec3);

            Assert.Equal(0, vec.X);
            Assert.Equal(0, vec.Y);
            Assert.Equal(0, vec.Z);
        }

        /// <summary>
        ///     Tests that the public fields can be assigned directly and round trip
        /// </summary>
        [Fact]
        public void Fields_SetDirectly_RoundTrip()
        {
            Ivec3 vec = default(Ivec3);

            vec.X = 10;
            vec.Y = 20;
            vec.Z = 30;

            Assert.Equal(10, vec.X);
            Assert.Equal(20, vec.Y);
            Assert.Equal(30, vec.Z);
        }

        /// <summary>
        ///     Tests that the struct is a value type and copies are independent
        /// </summary>
        [Fact]
        public void IsValueType_CopyIsIndependent()
        {
            Ivec3 original = new Ivec3(1, 2, 3);
            Ivec3 copy = original;

            copy.X = 5;

            Assert.Equal(1, original.X);
            Assert.Equal(5, copy.X);
        }
    }
}