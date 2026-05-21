// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BuilderTest.cs
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
    ///     The builder test class
    /// </summary>
    public class BuilderTest
    {
        /// <summary>
        ///     Tests that builder returns expected value
        /// </summary>
        [Fact]
        public void Builder_ReturnsExpectedValue()
        {
            TestHasBuilder testHasBuilder = new TestHasBuilder();

            string result = testHasBuilder.Builder();

            Assert.Equal("Test", result);
        }

        /// <summary>
        ///     Tests that builder does not return null
        /// </summary>
        [Fact]
        public void Builder_DoesNotReturnNull()
        {
            TestHasBuilder testHasBuilder = new TestHasBuilder();

            string result = testHasBuilder.Builder();

            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that builder returns correct type
        /// </summary>
        [Fact]
        public void Builder_ReturnsCorrectType()
        {
            TestHasBuilder testHasBuilder = new TestHasBuilder();

            string result = testHasBuilder.Builder();

            Assert.IsType<string>(result);
        }
    }
}