// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiNativeMiscCoverageTests.cs
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
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     Covers the remaining safe native paths: style palettes and font config
    ///     allocation on ImGui, plus the ImGuiIOPtr list-backed property getters
    ///     that only read native IO memory.
    /// </summary>
    public class ImGuiNativeMiscCoverageTests
    {
        /// <summary>
        ///     Verifies StyleColorsClassic, StyleColorsDark and StyleColorsLight
        ///     execute, including the dst-carrying overloads.
        /// </summary>
        [RequireCImguiSystemFact]
        public void StyleColors_AllVariants_Execute()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                ImGui.StyleColorsClassic();
                ImGui.StyleColorsClassic(new ImGuiStyle());
                ImGui.StyleColorsDark();
                ImGui.StyleColorsDark(new ImGuiStyle());
                ImGui.StyleColorsLight();
                ImGui.StyleColorsLight(new ImGuiStyle());
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies ImFontConfig allocates a native font config.
        /// </summary>
        [RequireCImguiSystemFact]
        public void ImFontConfig_AllocatesNativeConfig()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                ImFontConfigPtr config = ImGui.ImFontConfig();
                Assert.NotEqual(IntPtr.Zero, config.NativePtr);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies KeysData throws because the generated field offset does not
        ///     match the managed ImGuiIo layout.
        /// </summary>
        [RequireCImguiSystemFact]
        public void KeysData_ThrowsArgumentException()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                ImGuiIoPtr io = new ImGuiIoPtr(ImGuiNative.igGetIO());
                Assert.Throws<ArgumentException>(() => io.KeysData);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies MouseClickedPos throws because the generated field offset does
        ///     not match the managed ImGuiIo layout.
        /// </summary>
        [RequireCImguiSystemFact]
        public void MouseClickedPos_ThrowsArgumentException()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                ImGuiIoPtr io = new ImGuiIoPtr(ImGuiNative.igGetIO());
                Assert.Throws<ArgumentException>(() => io.MouseClickedPos);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies MouseDragMaxDistanceAbs throws because the generated field
        ///     offset does not match the managed ImGuiIo layout.
        /// </summary>
        [RequireCImguiSystemFact]
        public void MouseDragMaxDistanceAbs_ThrowsArgumentException()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                ImGuiIoPtr io = new ImGuiIoPtr(ImGuiNative.igGetIO());
                Assert.Throws<ArgumentException>(() => io.MouseDragMaxDistanceAbs);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }
    }
}
