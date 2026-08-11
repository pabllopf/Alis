// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP5NativeCoverageTests.cs
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
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     Invokes the native color conversion helpers contributed by the ImGuiP5
    ///     partial class. These are pure math functions that do not require a frame.
    /// </summary>
    public class ImGuiP5NativeCoverageTests
    {
        /// <summary>
        ///     Verifies ColorConvertFloat4ToU32 converts a color to an unsigned int.
        /// </summary>
        [RequireCImguiSystemFact]
        public void ColorConvertFloat4ToU32_ReturnsPackedColor()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                uint packed = ImGui.ColorConvertFloat4ToU32(new Vector4F(1, 1, 1, 1));
                Assert.Equal(0xFFFFFFFF, packed);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies ColorConvertHsVtoRgb fills the rgb channels.
        /// </summary>
        [RequireCImguiSystemFact]
        public void ColorConvertHsVtoRgb_FillsChannels()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                ImGui.ColorConvertHsVtoRgb(0.5f, 1.0f, 1.0f, out float r, out float g, out float b);
                Assert.InRange(r, 0.0f, 1.0f);
                Assert.InRange(g, 0.0f, 1.0f);
                Assert.InRange(b, 0.0f, 1.0f);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies ColorConvertRgBtoHsv fills the hsv channels.
        /// </summary>
        [RequireCImguiSystemFact]
        public void ColorConvertRgBtoHsv_FillsChannels()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                ImGui.ColorConvertRgBtoHsv(0.5f, 0.5f, 0.5f, out float h, out float s, out float v);
                Assert.InRange(h, 0.0f, 1.0f);
                Assert.InRange(s, 0.0f, 1.0f);
                Assert.InRange(v, 0.0f, 1.0f);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies ColorConvertU32ToFloat4 converts a packed color to channels.
        /// </summary>
        [RequireCImguiSystemFact]
        public void ColorConvertU32ToFloat4_ReturnsChannels()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                Vector4F color = ImGui.ColorConvertU32ToFloat4(0xFFFFFFFF);
                Assert.Equal(1.0f, color.X);
                Assert.Equal(1.0f, color.Y);
                Assert.Equal(1.0f, color.Z);
                Assert.Equal(1.0f, color.W);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }
    }
}
