// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DepthTests.cs
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

using System.Runtime.Serialization;
using Alis.Core.Aspect.Math.Definition;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Definition
{
    /// <summary>
    ///     The depth tests class
    /// </summary>
    public class DepthTests
    {
        /// <summary>
        ///     Tests that constructor sets value correctly
        /// </summary>
        [Fact]
        public void Constructor_SetsValueCorrectly()
        {
            // Arrange
            const int expectedValue = 10;

            // Act
            Depth depth = new Depth(expectedValue);

            // Assert
            Assert.Equal(expectedValue, depth.Value);
        }

        /// <summary>
        ///     Tests that GetObjectData serializes the value correctly
        /// </summary>
        [Fact]
        public void GetObjectData_WritesSerializedValue()
        {
            Depth depth = new Depth(42);
            SerializationInfo info = new SerializationInfo(typeof(Depth), new FormatterConverter());

            depth.GetObjectData(info, default(StreamingContext));

            Assert.Equal(42, info.GetInt32("value"));
        }
    }
}