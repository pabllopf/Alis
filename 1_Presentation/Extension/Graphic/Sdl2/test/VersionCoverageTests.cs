// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VersionCoverageTests.cs
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

using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    ///     The version coverage tests class
    /// </summary>
    public class VersionCoverageTests
    {
        /// <summary>
        ///     Tests that the constructor assigns the fields
        /// </summary>
        [Fact]
        public void Constructor_AssignsFields()
        {
            Version version = new Version(3, 2, 1);

            Assert.Equal(3, version.major);
            Assert.Equal(2, version.minor);
            Assert.Equal(1, version.patch);
        }

        /// <summary>
        ///     Tests that the default constructor leaves fields zero
        /// </summary>
        [Fact]
        public void DefaultConstructor_FieldsAreZero()
        {
            Version version = new Version();

            Assert.Equal(0, version.major);
            Assert.Equal(0, version.minor);
            Assert.Equal(0, version.patch);
        }

        /// <summary>
        ///     Tests that values exceeding byte range are truncated
        /// </summary>
        [Fact]
        public void Constructor_TruncatesValuesExceedingByteRange()
        {
            Version version = new Version(256, 512, 1024);

            Assert.Equal(0, version.major);
            Assert.Equal(0, version.minor);
            Assert.Equal(0, version.patch);
        }

        /// <summary>
        ///     Tests that the public fields can be assigned directly and round trip
        /// </summary>
        [Fact]
        public void Fields_SetDirectly_RoundTrip()
        {
            Version version = new Version();

            version.major = 1;
            version.minor = 2;
            version.patch = 3;

            Assert.Equal(1, version.major);
            Assert.Equal(2, version.minor);
            Assert.Equal(3, version.patch);
        }

        /// <summary>
        ///     Tests that the struct is a value type and copies are independent
        /// </summary>
        [Fact]
        public void IsValueType_CopyIsIndependent()
        {
            Version original = new Version(1, 2, 3);
            Version copy = original;

            copy.major = 9;

            Assert.Equal(1, original.major);
            Assert.Equal(9, copy.major);
        }
    }
}