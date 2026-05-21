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

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    ///     Provides unit coverage for plot-specific <see cref="ImGuiDragDropFlags" /> values.
    /// </summary>
    public class ImGuiDragDropFlagsTest
    {
        /// <summary>
        ///     Verifies that none is zero.
        /// </summary>
        [Fact]
        public void None_ShouldBeZero()
        {
            Assert.Equal(0, (int) ImGuiDragDropFlags.None);
        }

        /// <summary>
        ///     Verifies that source and accept flags remain distinct.
        /// </summary>
        [Fact]
        public void SourceAndAcceptFlags_ShouldBeDistinct()
        {
            Assert.NotEqual((int) ImGuiDragDropFlags.SourceExtern, (int) ImGuiDragDropFlags.AcceptBeforeDelivery);
            Assert.NotEqual((int) ImGuiDragDropFlags.SourceAutoExpirePayload, (int) ImGuiDragDropFlags.AcceptNoPreviewTooltip);
        }

        /// <summary>
        ///     Verifies that accept-peek-only matches expected composition.
        /// </summary>
        [Fact]
        public void AcceptPeekOnly_ShouldMatchExpectedComposition()
        {
            ImGuiDragDropFlags expected = ImGuiDragDropFlags.AcceptBeforeDelivery | ImGuiDragDropFlags.AcceptNoDrawDefaultRect;

            Assert.Equal(expected, ImGuiDragDropFlags.AcceptPeekOnly);
        }
    }
}