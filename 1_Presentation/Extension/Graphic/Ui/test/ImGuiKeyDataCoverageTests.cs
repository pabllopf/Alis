// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiKeyDataCoverageTests.cs
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

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im gui key data coverage tests class
    /// </summary>
    public class ImGuiKeyDataCoverageTests
    {
        /// <summary>
        ///     Tests that default initialization properties have default values
        /// </summary>
        [Fact]
        public void ImGuiKeyData_DefaultInitialization_PropertiesHaveDefaultValues()
        {
            ImGuiKeyData data = default(ImGuiKeyData);

            Assert.Equal((byte)0, data.Down);
            Assert.Equal(0f, data.DownDuration, 5);
            Assert.Equal(0f, data.DownDurationPrev, 5);
            Assert.Equal(0f, data.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that set properties stores values correctly
        /// </summary>
        [Fact]
        public void ImGuiKeyData_SetProperties_StoresValuesCorrectly()
        {
            ImGuiKeyData data = new ImGuiKeyData
            {
                Down = 1,
                DownDuration = 2.5f,
                DownDurationPrev = 3.5f,
                AnalogValue = 4.5f
            };

            Assert.Equal((byte)1, data.Down);
            Assert.Equal(2.5f, data.DownDuration, 5);
            Assert.Equal(3.5f, data.DownDurationPrev, 5);
            Assert.Equal(4.5f, data.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that the struct is a value type and copies are independent
        /// </summary>
        [Fact]
        public void ImGuiKeyData_IsValueType_CopyIsIndependent()
        {
            ImGuiKeyData original = new ImGuiKeyData { Down = 1 };
            ImGuiKeyData copy = original;

            copy.Down = 2;

            Assert.Equal((byte)1, original.Down);
            Assert.Equal((byte)2, copy.Down);
        }
    }
}