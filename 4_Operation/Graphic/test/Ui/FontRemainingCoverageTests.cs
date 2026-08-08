// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FontRemainingCoverageTests.cs
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

using Alis.Core.Graphic.Ui;
using Xunit;

namespace Alis.Core.Graphic.Test.Ui
{
    /// <summary>
    /// The font remaining coverage tests class
    /// </summary>
    public class FontRemainingCoverageTests
    {
        /// <summary>
        /// Tests that constructor sets name file
        /// </summary>
        [Fact]
        public void Constructor_SetsNameFile()
        {
            Font font = new Font("TestFont", 1, 12);
            Assert.Equal("TestFont", font.NameFile);
        }

        /// <summary>
        /// Tests that constructor sets depth
        /// </summary>
        [Fact]
        public void Constructor_SetsDepth()
        {
            Font font = new Font("TestFont", 5, 12);
            Assert.Equal(5, font.Depth);
        }

        /// <summary>
        /// Tests that name file can get and set
        /// </summary>
        [Fact]
        public void NameFile_CanGetAndSet()
        {
            Font font = new Font("Original", 1, 12);
            font.NameFile = "Modified";
            Assert.Equal("Modified", font.NameFile);
        }

        /// <summary>
        /// Tests that depth can get and set
        /// </summary>
        [Fact]
        public void Depth_CanGetAndSet()
        {
            Font font = new Font("Test", 1, 12);
            font.Depth = 42;
            Assert.Equal(42, font.Depth);
        }

        /// <summary>
        /// Tests that constructor with null name file
        /// </summary>
        [Fact]
        public void Constructor_WithNullNameFile()
        {
            Font font = new Font(null, 1, 12);
            Assert.Null(font.NameFile);
        }

        /// <summary>
        /// Tests that constructor with empty name file
        /// </summary>
        [Fact]
        public void Constructor_WithEmptyNameFile()
        {
            Font font = new Font("", 1, 12);
            Assert.Equal("", font.NameFile);
        }

        /// <summary>
        /// Tests that constructor with negative depth
        /// </summary>
        [Fact]
        public void Constructor_WithNegativeDepth()
        {
            Font font = new Font("Test", -5, 12);
            Assert.Equal(-5, font.Depth);
        }

        /// <summary>
        /// Tests that constructor with zero depth
        /// </summary>
        [Fact]
        public void Constructor_WithZeroDepth()
        {
            Font font = new Font("Test", 0, 12);
            Assert.Equal(0, font.Depth);
        }
    }
}
