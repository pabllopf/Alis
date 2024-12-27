// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiPlatformImeDataTest.cs
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

using System.Diagnostics.CodeAnalysis;
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.ImGui.Test
{
    /// <summary>
    ///     The im gui platform ime data test class
    /// </summary>
    	 [ExcludeFromCodeCoverage] 
	 public class ImGuiPlatformImeDataTest 
    {
        /// <summary>
        ///     Tests that want visible should set and get correctly
        /// </summary>
        [Fact]
        public void WantVisible_Should_SetAndGetCorrectly()
        {
            ImGuiPlatformImeData platformImeData = new ImGuiPlatformImeData();
            platformImeData.WantVisible = 1;
            Assert.Equal(1, platformImeData.WantVisible);
        }

        /// <summary>
        ///     Tests that input pos should set and get correctly
        /// </summary>
        [Fact]
        public void InputPos_Should_SetAndGetCorrectly()
        {
            ImGuiPlatformImeData platformImeData = new ImGuiPlatformImeData();
            Vector2F inputPos = new Vector2F(1.0f, 2.0f);
            platformImeData.InputPos = inputPos;
            Assert.Equal(inputPos, platformImeData.InputPos);
        }

        /// <summary>
        ///     Tests that input line height should set and get correctly
        /// </summary>
        [Fact]
        public void InputLineHeight_Should_SetAndGetCorrectly()
        {
            ImGuiPlatformImeData platformImeData = new ImGuiPlatformImeData();
            platformImeData.InputLineHeight = 15.5f;
            Assert.Equal(15.5f, platformImeData.InputLineHeight);
        }
    }
}