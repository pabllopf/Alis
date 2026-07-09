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
    public class FontRemainingCoverageTests
    {
        [Fact]
        public void Constructor_SetsNameFile()
        {
            var font = new Font("TestFont", 1, 12);
            Assert.Equal("TestFont", font.NameFile);
        }

        [Fact]
        public void Constructor_SetsDepth()
        {
            var font = new Font("TestFont", 5, 12);
            Assert.Equal(5, font.Depth);
        }

        [Fact]
        public void NameFile_CanGetAndSet()
        {
            var font = new Font("Original", 1, 12);
            font.NameFile = "Modified";
            Assert.Equal("Modified", font.NameFile);
        }

        [Fact]
        public void Depth_CanGetAndSet()
        {
            var font = new Font("Test", 1, 12);
            font.Depth = 42;
            Assert.Equal(42, font.Depth);
        }

        [Fact]
        public void Constructor_WithNullNameFile()
        {
            var font = new Font(null, 1, 12);
            Assert.Null(font.NameFile);
        }

        [Fact]
        public void Constructor_WithEmptyNameFile()
        {
            var font = new Font("", 1, 12);
            Assert.Equal("", font.NameFile);
        }

        [Fact]
        public void Constructor_WithNegativeDepth()
        {
            var font = new Font("Test", -5, 12);
            Assert.Equal(-5, font.Depth);
        }

        [Fact]
        public void Constructor_WithZeroDepth()
        {
            var font = new Font("Test", 0, 12);
            Assert.Equal(0, font.Depth);
        }
    }
}
