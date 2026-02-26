// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CursorTypeEnumTests.cs
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
    ///     Tests for CursorType enum
    /// </summary>
    public class CursorTypeEnumTests
    {
        /// <summary>
        /// Tests that cursor type arrow is defined
        /// </summary>
        [Fact]
        public void CursorType_Arrow_IsDefined()
        {
            Assert.True(Enum.IsDefined(typeof(CursorType), CursorType.Arrow));
        }

        /// <summary>
        /// Tests that cursor type i beam is defined
        /// </summary>
        [Fact]
        public void CursorType_IBeam_IsDefined()
        {
            Assert.True(Enum.IsDefined(typeof(CursorType), CursorType.Beam));
        }

        /// <summary>
        /// Tests that cursor type crosshair is defined
        /// </summary>
        [Fact]
        public void CursorType_Crosshair_IsDefined()
        {
            Assert.True(Enum.IsDefined(typeof(CursorType), CursorType.Crosshair));
        }

        /// <summary>
        /// Tests that cursor type hand is defined
        /// </summary>
        [Fact]
        public void CursorType_Hand_IsDefined()
        {
            Assert.True(Enum.IsDefined(typeof(CursorType), CursorType.Hand));
        }

        /// <summary>
        /// Tests that cursor type can be cast to int
        /// </summary>
        [Fact]
        public void CursorType_CanBeCastToInt()
        {
            CursorType type = CursorType.Arrow;
            int value = (int)type;
            Assert.True(value != 0);
        }
    }
}

