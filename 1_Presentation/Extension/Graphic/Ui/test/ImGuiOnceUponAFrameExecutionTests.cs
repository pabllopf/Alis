// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiOnceUponAFrameExecutionTests.cs
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

using Alis.Extension.Graphic.Ui;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im gui once upon a frame execution tests class
    /// </summary>
    public class ImGuiOnceUponAFrameExecutionTests
    {
        /// <summary>
        ///     Tests that the ref frame property round-trips a value
        /// </summary>
        [Fact]
        public void ImGuiOnceUponAFrame_RefFrame_RoundTripsValue()
        {
            ImGuiOnceUponAFrame once = default;
            int expected = 42;

            once.RefFrame = expected;

            Assert.Equal(expected, once.RefFrame);
        }

        /// <summary>
        ///     Tests that the ref frame property can be overwritten
        /// </summary>
        [Fact]
        public void ImGuiOnceUponAFrame_RefFrame_OverwritesPreviousValue()
        {
            ImGuiOnceUponAFrame once = new ImGuiOnceUponAFrame { RefFrame = 1 };

            once.RefFrame = 2;

            Assert.Equal(2, once.RefFrame);
        }

        /// <summary>
        ///     Tests that the ref frame property defaults to zero
        /// </summary>
        [Fact]
        public void ImGuiOnceUponAFrame_Default_RefFrameIsZero()
        {
            ImGuiOnceUponAFrame once = default;

            Assert.Equal(0, once.RefFrame);
        }

        /// <summary>
        ///     Tests that the struct is a value type and copies are independent
        /// </summary>
        [Fact]
        public void ImGuiOnceUponAFrame_IsValueType_CopiesAreIndependent()
        {
            ImGuiOnceUponAFrame original = new ImGuiOnceUponAFrame { RefFrame = 10 };
            ImGuiOnceUponAFrame copy = original;

            copy.RefFrame = 20;

            Assert.Equal(10, original.RefFrame);
            Assert.Equal(20, copy.RefFrame);
        }
    }
}
