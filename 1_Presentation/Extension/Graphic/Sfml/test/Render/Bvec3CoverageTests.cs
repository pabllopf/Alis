// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Bvec3CoverageTests.cs
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
    ///     The bvec 3 coverage tests class
    /// </summary>
    public class Bvec3CoverageTests
    {
        /// <summary>
        ///     Tests that the constructor assigns the components
        /// </summary>
        [Fact]
        public void Constructor_AssignsComponents()
        {
            Bvec3 vec = new Bvec3(true, false, true);

            Assert.True(vec.X);
            Assert.False(vec.Y);
            Assert.True(vec.Z);
        }

        /// <summary>
        ///     Tests that the default constructor leaves components false
        /// </summary>
        [Fact]
        public void DefaultConstructor_ComponentsAreFalse()
        {
            Bvec3 vec = default(Bvec3);

            Assert.False(vec.X);
            Assert.False(vec.Y);
            Assert.False(vec.Z);
        }

        /// <summary>
        ///     Tests that the public fields can be assigned directly and round trip
        /// </summary>
        [Fact]
        public void Fields_SetDirectly_RoundTrip()
        {
            Bvec3 vec = default(Bvec3);

            vec.X = true;
            vec.Y = false;
            vec.Z = true;

            Assert.True(vec.X);
            Assert.False(vec.Y);
            Assert.True(vec.Z);
        }

        /// <summary>
        ///     Tests that the struct is a value type and copies are independent
        /// </summary>
        [Fact]
        public void IsValueType_CopyIsIndependent()
        {
            Bvec3 original = new Bvec3(true, false, false);
            Bvec3 copy = original;

            copy.X = false;

            Assert.True(original.X);
            Assert.False(copy.X);
        }
    }
}