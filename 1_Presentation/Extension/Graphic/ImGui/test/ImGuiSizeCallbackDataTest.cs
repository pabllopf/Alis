// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiSizeCallbackDataTest.cs
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

using System;
using System.Diagnostics.CodeAnalysis;
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.ImGui.Test
{
    /// <summary>
    ///     The im gui size callback data test class
    /// </summary>
    	 [ExcludeFromCodeCoverage] 
	 public class ImGuiSizeCallbackDataTest 
    {
        /// <summary>
        ///     Tests that user data should be initialized
        /// </summary>
        [Fact]
        public void UserData_ShouldBeInitialized()
        {
            ImGuiSizeCallbackData data = new ImGuiSizeCallbackData();
            Assert.Equal(IntPtr.Zero, data.UserData);
        }

        /// <summary>
        ///     Tests that pos should be initialized
        /// </summary>
        [Fact]
        public void Pos_ShouldBeInitialized()
        {
            ImGuiSizeCallbackData data = new ImGuiSizeCallbackData();
            Assert.Equal(default(Vector2F), data.Pos);
        }

        /// <summary>
        ///     Tests that current size should be initialized
        /// </summary>
        [Fact]
        public void CurrentSize_ShouldBeInitialized()
        {
            ImGuiSizeCallbackData data = new ImGuiSizeCallbackData();
            Assert.Equal(default(Vector2F), data.CurrentSize);
        }

        /// <summary>
        ///     Tests that desired size should be initialized
        /// </summary>
        [Fact]
        public void DesiredSize_ShouldBeInitialized()
        {
            ImGuiSizeCallbackData data = new ImGuiSizeCallbackData();
            Assert.Equal(default(Vector2F), data.DesiredSize);
        }

        /// <summary>
        ///     Tests that user data should set and get correctly
        /// </summary>
        [Fact]
        public void UserData_Should_SetAndGetCorrectly()
        {
            ImGuiSizeCallbackData data = new ImGuiSizeCallbackData();
            IntPtr userData = new IntPtr(123);
            data.UserData = userData;
            Assert.Equal(userData, data.UserData);
        }

        /// <summary>
        ///     Tests that pos should set and get correctly
        /// </summary>
        [Fact]
        public void Pos_Should_SetAndGetCorrectly()
        {
            ImGuiSizeCallbackData data = new ImGuiSizeCallbackData();
            Vector2F pos = new Vector2F(1, 2);
            data.Pos = pos;
            Assert.Equal(pos, data.Pos);
        }

        /// <summary>
        ///     Tests that current size should set and get correctly
        /// </summary>
        [Fact]
        public void CurrentSize_Should_SetAndGetCorrectly()
        {
            ImGuiSizeCallbackData data = new ImGuiSizeCallbackData();
            Vector2F currentSize = new Vector2F(3, 4);
            data.CurrentSize = currentSize;
            Assert.Equal(currentSize, data.CurrentSize);
        }

        /// <summary>
        ///     Tests that desired size should set and get correctly
        /// </summary>
        [Fact]
        public void DesiredSize_Should_SetAndGetCorrectly()
        {
            ImGuiSizeCallbackData data = new ImGuiSizeCallbackData();
            Vector2F desiredSize = new Vector2F(5, 6);
            data.DesiredSize = desiredSize;
            Assert.Equal(desiredSize, data.DesiredSize);
        }
    }
}