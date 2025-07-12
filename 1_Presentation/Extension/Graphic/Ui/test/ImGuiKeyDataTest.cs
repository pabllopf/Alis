// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiKeyDataTest.cs
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
    ///     The im gui key data test class
    /// </summary>
    public class ImGuiKeyDataTest
    {
        /// <summary>
        ///     Tests that down should set and get correctly
        /// </summary>
        [Fact]
        public void Down_Should_SetAndGetCorrectly()
        {
            ImGuiKeyData keyData = new ImGuiKeyData();
            keyData.Down = 1;
            Assert.Equal(1, keyData.Down);
        }

        /// <summary>
        ///     Tests that down duration should set and get correctly
        /// </summary>
        [Fact]
        public void DownDuration_Should_SetAndGetCorrectly()
        {
            ImGuiKeyData keyData = new ImGuiKeyData();
            keyData.DownDuration = 1.5f;
            Assert.Equal(1.5f, keyData.DownDuration);
        }

        /// <summary>
        ///     Tests that down duration prev should set and get correctly
        /// </summary>
        [Fact]
        public void DownDurationPrev_Should_SetAndGetCorrectly()
        {
            ImGuiKeyData keyData = new ImGuiKeyData();
            keyData.DownDurationPrev = 2.5f;
            Assert.Equal(2.5f, keyData.DownDurationPrev);
        }

        /// <summary>
        ///     Tests that analog value should set and get correctly
        /// </summary>
        [Fact]
        public void AnalogValue_Should_SetAndGetCorrectly()
        {
            ImGuiKeyData keyData = new ImGuiKeyData();
            keyData.AnalogValue = 3.5f;
            Assert.Equal(3.5f, keyData.AnalogValue);
        }
    }
}