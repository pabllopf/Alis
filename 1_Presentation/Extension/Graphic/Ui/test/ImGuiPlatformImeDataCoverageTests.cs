// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiPlatformImeDataCoverageTests.cs
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

using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im gui platform ime data coverage tests class
    /// </summary>
    public class ImGuiPlatformImeDataCoverageTests
    {
        /// <summary>
        ///     Tests that default initialization properties have default values
        /// </summary>
        [Fact]
        public void ImGuiPlatformImeData_DefaultInitialization_PropertiesHaveDefaultValues()
        {
            ImGuiPlatformImeData data = default(ImGuiPlatformImeData);

            Assert.Equal((byte)0, data.WantVisible);
            Assert.Equal(0f, data.InputPos.X, 5);
            Assert.Equal(0f, data.InputPos.Y, 5);
            Assert.Equal(0f, data.InputLineHeight, 5);
        }

        /// <summary>
        ///     Tests that set properties stores values correctly
        /// </summary>
        [Fact]
        public void ImGuiPlatformImeData_SetProperties_StoresValuesCorrectly()
        {
            ImGuiPlatformImeData data = new ImGuiPlatformImeData
            {
                WantVisible = 1,
                InputPos = new Vector2F(2f, 3f),
                InputLineHeight = 4f
            };

            Assert.Equal((byte)1, data.WantVisible);
            Assert.Equal(2f, data.InputPos.X, 5);
            Assert.Equal(3f, data.InputPos.Y, 5);
            Assert.Equal(4f, data.InputLineHeight, 5);
        }

        /// <summary>
        ///     Tests that the struct is a value type and copies are independent
        /// </summary>
        [Fact]
        public void ImGuiPlatformImeData_IsValueType_CopyIsIndependent()
        {
            ImGuiPlatformImeData original = new ImGuiPlatformImeData { WantVisible = 1 };
            ImGuiPlatformImeData copy = original;

            copy.WantVisible = 0;

            Assert.Equal((byte)1, original.WantVisible);
            Assert.Equal((byte)0, copy.WantVisible);
        }
    }
}