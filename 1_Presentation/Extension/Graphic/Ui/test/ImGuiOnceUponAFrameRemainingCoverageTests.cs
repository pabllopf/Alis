// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiOnceUponAFrameRemainingCoverageTests.cs
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
    ///     The im gui once upon a frame remaining coverage tests class
    /// </summary>
    public class ImGuiOnceUponAFrameRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that default values are zero
        /// </summary>
         [RequireCImguiSystemFact]
        public void Default_ValuesAreZero()
        {
            ImGuiOnceUponAFrame onceUponAFrame = default;
            Assert.Equal(0, onceUponAFrame.RefFrame);
        }

        /// <summary>
        ///     Tests that ref frame round trips
        /// </summary>
         [RequireCImguiSystemFact]
        public void RefFrame_RoundTrip()
        {
            ImGuiOnceUponAFrame onceUponAFrame = default;
            const int expected = 42;
            onceUponAFrame.RefFrame = expected;
            Assert.Equal(expected, onceUponAFrame.RefFrame);
        }
    }
}
