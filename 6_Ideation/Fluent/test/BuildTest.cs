// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BuildTest.cs
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

using Xunit;

namespace Alis.Core.Aspect.Fluent.Test
{
    /// <summary>
    ///     The build test class
    /// </summary>
    public class BuildTest
    {
        /// <summary>
        ///     Tests that build returns expected value
        /// </summary>
        [Fact]
        public void Build_ReturnsExpectedValue()
        {
            // Arrange
            TestBuild testBuild = new TestBuild();

            // Act
            string result = testBuild.Build();

            // Assert
            Assert.Equal("Test", result);
        }

        /// <summary>
        ///     Tests that build does not return null
        /// </summary>
        [Fact]
        public void Build_DoesNotReturnNull()
        {
            // Arrange
            TestBuild testBuild = new TestBuild();

            // Act
            string result = testBuild.Build();

            // Assert
            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that build returns correct type
        /// </summary>
        [Fact]
        public void Build_ReturnsCorrectType()
        {
            // Arrange
            TestBuild testBuild = new TestBuild();

            // Act
            string result = testBuild.Build();

            // Assert
            Assert.IsType<string>(result);
        }
    }
}