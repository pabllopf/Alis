// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiSizeCallbackDataCoverageTests.cs
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
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im gui size callback data coverage tests class
    /// </summary>
    public class ImGuiSizeCallbackDataCoverageTests
    {
        /// <summary>
        ///     Tests that default initialization properties have default values
        /// </summary>
        [Fact]
        public void ImGuiSizeCallbackData_DefaultInitialization_PropertiesHaveDefaultValues()
        {
            ImGuiSizeCallbackData data = default(ImGuiSizeCallbackData);

            Assert.Equal(IntPtr.Zero, data.UserData);
            Assert.Equal(0f, data.Pos.X, 5);
            Assert.Equal(0f, data.Pos.Y, 5);
            Assert.Equal(0f, data.CurrentSize.X, 5);
            Assert.Equal(0f, data.CurrentSize.Y, 5);
            Assert.Equal(0f, data.DesiredSize.X, 5);
            Assert.Equal(0f, data.DesiredSize.Y, 5);
        }

        /// <summary>
        ///     Tests that set properties stores values correctly
        /// </summary>
        [Fact]
        public void ImGuiSizeCallbackData_SetProperties_StoresValuesCorrectly()
        {
            ImGuiSizeCallbackData data = new ImGuiSizeCallbackData
            {
                UserData = new IntPtr(10),
                Pos = new Vector2F(1f, 2f),
                CurrentSize = new Vector2F(3f, 4f),
                DesiredSize = new Vector2F(5f, 6f)
            };

            Assert.Equal(new IntPtr(10), data.UserData);
            Assert.Equal(1f, data.Pos.X, 5);
            Assert.Equal(2f, data.Pos.Y, 5);
            Assert.Equal(3f, data.CurrentSize.X, 5);
            Assert.Equal(4f, data.CurrentSize.Y, 5);
            Assert.Equal(5f, data.DesiredSize.X, 5);
            Assert.Equal(6f, data.DesiredSize.Y, 5);
        }

        /// <summary>
        ///     Tests that the struct is a value type and copies are independent
        /// </summary>
        [Fact]
        public void ImGuiSizeCallbackData_IsValueType_CopyIsIndependent()
        {
            ImGuiSizeCallbackData original = new ImGuiSizeCallbackData { UserData = new IntPtr(100) };
            ImGuiSizeCallbackData copy = original;

            copy.UserData = new IntPtr(200);

            Assert.Equal(new IntPtr(100), original.UserData);
            Assert.Equal(new IntPtr(200), copy.UserData);
        }
    }
}