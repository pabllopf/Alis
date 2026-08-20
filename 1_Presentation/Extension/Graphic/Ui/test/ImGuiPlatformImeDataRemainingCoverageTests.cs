// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiPlatformImeDataRemainingCoverageTests.cs
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
    ///     The im gui platform ime data remaining coverage tests class
    /// </summary>
    public class ImGuiPlatformImeDataRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that default values are zero
        /// </summary>
         [RequireCImguiSystemFact]
        public void Default_ValuesAreDefault()
        {
            ImGuiPlatformImeData data = default;
            Assert.Equal(0, data.WantVisible);
            Assert.Equal(default, data.InputPos);
            Assert.Equal(0f, data.InputLineHeight, 5);
        }

        /// <summary>
        ///     Tests that want visible round trips
        /// </summary>
         [RequireCImguiSystemFact]
        public void WantVisible_RoundTrip()
        {
            ImGuiPlatformImeData data = default;
            const byte expected = 1;
            data.WantVisible = expected;
            Assert.Equal(expected, data.WantVisible);
        }

        /// <summary>
        ///     Tests that input pos and input line height round trip
        /// </summary>
         [RequireCImguiSystemFact]
        public void InputPosAndInputLineHeight_RoundTrip()
        {
            ImGuiPlatformImeData data = default;
            Vector2F expectedPos = new Vector2F(3.5f, 7.2f);
            const float expectedHeight = 20.0f;
            data.InputPos = expectedPos;
            data.InputLineHeight = expectedHeight;
            Assert.Equal(expectedPos, data.InputPos);
            Assert.Equal(expectedHeight, data.InputLineHeight);
        }
    }
}
