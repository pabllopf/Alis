// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:HatEnumTests.cs
// 
//  Author:GitHub Copilot
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

using System;
using Alis.Extension.Graphic.Glfw.Enums;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test.Enums
{
    /// <summary>
    ///     Tests for Hat enum
    /// </summary>
    public class HatEnumTests
    {
        /// <summary>
        /// Tests that hat centered is defined
        /// </summary>
        [Fact]
        public void Hat_Centered_IsDefined()
        {
            Assert.True(Enum.IsDefined(typeof(Hat), Hat.Centered));
        }

        /// <summary>
        /// Tests that hat up is defined
        /// </summary>
        [Fact]
        public void Hat_Up_IsDefined()
        {
            Assert.True(Enum.IsDefined(typeof(Hat), Hat.Up));
        }

        /// <summary>
        /// Tests that hat right is defined
        /// </summary>
        [Fact]
        public void Hat_Right_IsDefined()
        {
            Assert.True(Enum.IsDefined(typeof(Hat), Hat.Right));
        }

        /// <summary>
        /// Tests that hat down is defined
        /// </summary>
        [Fact]
        public void Hat_Down_IsDefined()
        {
            Assert.True(Enum.IsDefined(typeof(Hat), Hat.Down));
        }

        /// <summary>
        /// Tests that hat left is defined
        /// </summary>
        [Fact]
        public void Hat_Left_IsDefined()
        {
            Assert.True(Enum.IsDefined(typeof(Hat), Hat.Left));
        }

        /// <summary>
        /// Tests that hat right up is defined
        /// </summary>
        [Fact]
        public void Hat_RightUp_IsDefined()
        {
            Assert.True(Enum.IsDefined(typeof(Hat), Hat.RightUp));
        }

        /// <summary>
        /// Tests that hat right down is defined
        /// </summary>
        [Fact]
        public void Hat_RightDown_IsDefined()
        {
            Assert.True(Enum.IsDefined(typeof(Hat), Hat.RightDown));
        }

        /// <summary>
        /// Tests that hat left up is defined
        /// </summary>
        [Fact]
        public void Hat_LeftUp_IsDefined()
        {
            Assert.True(Enum.IsDefined(typeof(Hat), Hat.LeftUp));
        }

        /// <summary>
        /// Tests that hat left down is defined
        /// </summary>
        [Fact]
        public void Hat_LeftDown_IsDefined()
        {
            Assert.True(Enum.IsDefined(typeof(Hat), Hat.LeftDown));
        }

        /// <summary>
        /// Tests that hat can be combined with bitwise or
        /// </summary>
        [Fact]
        public void Hat_CanBeCombinedWithBitwiseOr()
        {
            Hat combined = Hat.Up | Hat.Right;
            Assert.NotEqual(Hat.Centered, combined);
            Assert.True((combined & Hat.Up) == Hat.Up);
            Assert.True((combined & Hat.Right) == Hat.Right);
        }

        /// <summary>
        /// Tests that hat centered has zero value
        /// </summary>
        [Fact]
        public void Hat_Centered_HasZeroValue()
        {
            Assert.Equal(0, (int)Hat.Centered);
        }

        /// <summary>
        /// Tests that hat can be cast to int
        /// </summary>
        [Fact]
        public void Hat_CanBeCastToInt()
        {
            Hat hat = Hat.Up;
            int value = (int)hat;
            Assert.True(value > 0);
        }
    }
}

