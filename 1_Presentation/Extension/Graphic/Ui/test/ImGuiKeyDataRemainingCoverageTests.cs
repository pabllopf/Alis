// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiKeyDataRemainingCoverageTests.cs
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
    ///     Remaining coverage tests for the <see cref="ImGuiKeyData" /> struct.
    /// </summary>
    public class ImGuiKeyDataRemainingCoverageTests
    {
        /// <summary>
        ///     Verifies that default values are zero.
        /// </summary>
         [RequireCImguiSystemFact]
        public void Default_ValuesAreZero()
        {
            ImGuiKeyData keyData = default;
            Assert.Equal(0, keyData.Down);
            Assert.Equal(0f, keyData.DownDuration, 5);
            Assert.Equal(0f, keyData.DownDurationPrev, 5);
            Assert.Equal(0f, keyData.AnalogValue, 5);
        }

        /// <summary>
        ///     Verifies that Down property round-trips.
        /// </summary>
         [RequireCImguiSystemFact]
        public void Down_RoundTrip()
        {
            ImGuiKeyData keyData = default;
            keyData.Down = 1;
            Assert.Equal(1, keyData.Down);
        }

        /// <summary>
        ///     Verifies that float properties round-trip.
        /// </summary>
         [RequireCImguiSystemFact]
        public void FloatProperties_RoundTrip()
        {
            ImGuiKeyData keyData = default;
            keyData.DownDuration = 1.5f;
            keyData.DownDurationPrev = 2.5f;
            keyData.AnalogValue = 3.5f;
            Assert.Equal(1.5f, keyData.DownDuration, 5);
            Assert.Equal(2.5f, keyData.DownDurationPrev, 5);
            Assert.Equal(3.5f, keyData.AnalogValue, 5);
        }
    }
}
