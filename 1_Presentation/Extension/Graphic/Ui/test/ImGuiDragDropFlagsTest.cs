// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiDragDropFlagsTest.cs
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
    ///     Provides unit coverage for <see cref="ImGuiDragDropFlags" /> enum values.
    /// </summary>
    public class ImGuiDragDropFlagsTest
    {
        /// <summary>
        ///     Verifies that None has the expected value of 0.
        /// </summary>
        [Fact]
        public void None_ShouldHaveCorrectValue()
        {
            ImGuiDragDropFlags flag = ImGuiDragDropFlags.None;
            Assert.Equal(0, (int)flag);
        }

        /// <summary>
        ///     Verifies that SourceNoPreviewTooltip has the expected value of 1.
        /// </summary>
        [Fact]
        public void SourceNoPreviewTooltip_ShouldHaveCorrectValue()
        {
            ImGuiDragDropFlags flag = ImGuiDragDropFlags.SourceNoPreviewTooltip;
            Assert.Equal(1, (int)flag);
        }

        /// <summary>
        ///     Verifies that SourceNoDisableHover has the expected value of 2.
        /// </summary>
        [Fact]
        public void SourceNoDisableHover_ShouldHaveCorrectValue()
        {
            ImGuiDragDropFlags flag = ImGuiDragDropFlags.SourceNoDisableHover;
            Assert.Equal(2, (int)flag);
        }

        /// <summary>
        ///     Verifies that SourceNoHoldToOpenOthers has the expected value of 4.
        /// </summary>
        [Fact]
        public void SourceNoHoldToOpenOthers_ShouldHaveCorrectValue()
        {
            ImGuiDragDropFlags flag = ImGuiDragDropFlags.SourceNoHoldToOpenOthers;
            Assert.Equal(4, (int)flag);
        }

        /// <summary>
        ///     Verifies that SourceAllowNullId has the expected value of 8.
        /// </summary>
        [Fact]
        public void SourceAllowNullId_ShouldHaveCorrectValue()
        {
            ImGuiDragDropFlags flag = ImGuiDragDropFlags.SourceAllowNullId;
            Assert.Equal(8, (int)flag);
        }

        /// <summary>
        ///     Verifies that SourceExtern has the expected value of 16.
        /// </summary>
        [Fact]
        public void SourceExtern_ShouldHaveCorrectValue()
        {
            ImGuiDragDropFlags flag = ImGuiDragDropFlags.SourceExtern;
            Assert.Equal(16, (int)flag);
        }

        /// <summary>
        ///     Verifies that SourceAutoExpirePayload has the expected value of 32.
        /// </summary>
        [Fact]
        public void SourceAutoExpirePayload_ShouldHaveCorrectValue()
        {
            ImGuiDragDropFlags flag = ImGuiDragDropFlags.SourceAutoExpirePayload;
            Assert.Equal(32, (int)flag);
        }

        /// <summary>
        ///     Verifies that AcceptBeforeDelivery has the expected value of 1024.
        /// </summary>
        [Fact]
        public void AcceptBeforeDelivery_ShouldHaveCorrectValue()
        {
            ImGuiDragDropFlags flag = ImGuiDragDropFlags.AcceptBeforeDelivery;
            Assert.Equal(1024, (int)flag);
        }

        /// <summary>
        ///     Verifies that AcceptNoDrawDefaultRect has the expected value of 2048.
        /// </summary>
        [Fact]
        public void AcceptNoDrawDefaultRect_ShouldHaveCorrectValue()
        {
            ImGuiDragDropFlags flag = ImGuiDragDropFlags.AcceptNoDrawDefaultRect;
            Assert.Equal(2048, (int)flag);
        }

        /// <summary>
        ///     Verifies that AcceptNoPreviewTooltip has the expected value of 4096.
        /// </summary>
        [Fact]
        public void AcceptNoPreviewTooltip_ShouldHaveCorrectValue()
        {
            ImGuiDragDropFlags flag = ImGuiDragDropFlags.AcceptNoPreviewTooltip;
            Assert.Equal(4096, (int)flag);
        }

        /// <summary>
        ///     Verifies that AcceptPeekOnly has the expected value of 3072.
        /// </summary>
        [Fact]
        public void AcceptPeekOnly_ShouldHaveCorrectValue()
        {
            ImGuiDragDropFlags flag = ImGuiDragDropFlags.AcceptPeekOnly;
            Assert.Equal(3072, (int)flag);
        }

        /// <summary>
        ///     Verifies that flags can be combined with bitwise OR.
        /// </summary>
        [Fact]
        public void Flags_ShouldBeCombinable()
        {
            ImGuiDragDropFlags combined = ImGuiDragDropFlags.SourceNoPreviewTooltip | ImGuiDragDropFlags.SourceNoDisableHover;
            int expected = 1 | 2;
            Assert.Equal(expected, (int)combined);
        }
    }
}
