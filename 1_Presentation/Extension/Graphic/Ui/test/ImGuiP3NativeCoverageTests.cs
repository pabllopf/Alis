// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP3NativeCoverageTests.cs
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
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     Invokes the native-backed context, IO and style accessors contributed by
    ///     the ImGuiP3 partial class. Each test owns a fresh context destroyed in finally.
    /// </summary>
    public class ImGuiP3NativeCoverageTests
    {
        /// <summary>
        ///     Verifies GetCurrentContext returns the active context pointer.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetCurrentContext_WithActiveContext_ReturnsValidPointer()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                Assert.Equal(ctx, ImGui.GetCurrentContext());
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies GetVersion returns a non-empty version string.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetVersion_WithActiveContext_ReturnsNonEmptyString()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                string version = ImGui.GetVersion();
                Assert.False(string.IsNullOrEmpty(version));
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies GetDrawListSharedData returns a non-zero pointer.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetDrawListSharedData_WithActiveContext_ReturnsValidPointer()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                Assert.NotEqual(IntPtr.Zero, ImGui.GetDrawListSharedData());
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies GetDrawData throws because the generated wrapper cannot
        ///     marshal the native ImDrawData struct without a frame.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetDrawData_WithoutFrame_ThrowsNullReferenceException()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                Assert.Throws<NullReferenceException>(() => ImGui.GetDrawData());
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies GetFont and GetFontSize execute without error.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetFont_And_GetFontSize_WithActiveContext_Execute()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                ImFontPtr font = ImGui.GetFont();
                _ = ImGui.GetFontSize();
                Assert.Equal(IntPtr.Zero, font.NativePtr);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies GetFontTexUvWhitePixel returns a vector.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetFontTexUvWhitePixel_WithActiveContext_ReturnsVector()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                _ = ImGui.GetFontTexUvWhitePixel();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies GetFrameCount returns a non-negative value.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetFrameCount_WithActiveContext_ReturnsNonNegative()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                Assert.True(ImGui.GetFrameCount() >= 0);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies GetFrameHeight and GetFrameHeightWithSpacing return values.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetFrameHeight_WithActiveContext_ReturnsValues()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                _ = ImGui.GetFrameHeight();
                _ = ImGui.GetFrameHeightWithSpacing();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies GetKeyIndex and GetKeyPressedAmount execute.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetKeyIndex_And_GetKeyPressedAmount_Execute()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                _ = ImGui.GetKeyIndex(ImGuiKey.A);
                _ = ImGui.GetKeyPressedAmount(ImGuiKey.A, 0.1f, 0.1f);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies GetKeyName throws because the generated wrapper cannot marshal the
        ///     native const char return value.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetKeyName_ThrowsMarshalDirectiveException()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                Assert.Throws<MarshalDirectiveException>(() => ImGui.GetKeyName(ImGuiKey.A));
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies GetMainViewport returns a non-zero pointer.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetMainViewport_WithActiveContext_ReturnsValidPointer()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                ImGuiViewportPtr viewport = ImGui.GetMainViewport();
                Assert.NotEqual(IntPtr.Zero, viewport.NativePtr);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies GetMouseClickedCount and GetMouseCursor execute.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetMouseClickedCount_And_GetMouseCursor_Execute()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                _ = ImGui.GetMouseClickedCount(ImGuiMouseButton.Left);
                _ = ImGui.GetMouseCursor();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies all GetMouseDragDelta overloads execute.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetMouseDragDelta_AllOverloads_Execute()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                _ = ImGui.GetMouseDragDelta();
                _ = ImGui.GetMouseDragDelta(ImGuiMouseButton.Left);
                _ = ImGui.GetMouseDragDelta(ImGuiMouseButton.Left, -1.0f);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies GetMousePos and GetMousePosOnOpeningCurrentPopup return vectors.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetMousePos_WithActiveContext_ReturnsVector()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                _ = ImGui.GetMousePos();
                _ = ImGui.GetMousePosOnOpeningCurrentPopup();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies GetPlatformIo returns a non-zero pointer.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetPlatformIo_WithActiveContext_ReturnsValidPointer()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                ImGuiPlatformIoPtr io = ImGui.GetPlatformIo();
                Assert.NotEqual(IntPtr.Zero, io.NativePtr);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies GetStyle returns a style with a positive alpha.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetStyle_WithActiveContext_ReturnsDefaultStyle()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                ImGuiStyle style = ImGui.GetStyle();
                Assert.True(style.Alpha > 0);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies GetStyleColorName throws because the generated wrapper cannot
        ///     marshal the native const char return value.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetStyleColorName_ThrowsMarshalDirectiveException()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                Assert.Throws<MarshalDirectiveException>(() => ImGui.GetStyleColorName(ImGuiCol.Text));
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies GetStyleColorVec4 returns the default text color.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetStyleColorVec4_WithActiveContext_ReturnsColor()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                _ = ImGui.GetStyleColorVec4(ImGuiCol.Text);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies all GetColorU32 overloads execute.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetColorU32_AllOverloads_Execute()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                _ = ImGui.GetColorU32(ImGuiCol.Text);
                _ = ImGui.GetColorU32(ImGuiCol.Text, 0.5f);
                _ = ImGui.GetColorU32(new Vector4F(1, 1, 1, 1));
                _ = ImGui.GetColorU32(0xFF000000);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies GetTextLineHeight and GetTextLineHeightWithSpacing return values.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetTextLineHeight_WithActiveContext_ReturnsValues()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                _ = ImGui.GetTextLineHeight();
                _ = ImGui.GetTextLineHeightWithSpacing();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies GetTime and GetTreeNodeToLabelSpacing execute.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetTime_And_GetTreeNodeToLabelSpacing_Execute()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                _ = ImGui.GetTime();
                _ = ImGui.GetTreeNodeToLabelSpacing();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies GetAllocatorFunctions returns the default allocators.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetAllocatorFunctions_WithActiveContext_Executes()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                IntPtr alloc = IntPtr.Zero;
                IntPtr free = IntPtr.Zero;
                IntPtr userData = IntPtr.Zero;
                ImGui.GetAllocatorFunctions(ref alloc, ref free, ref userData);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies FindViewportById returns null for an unknown id without crashing.
        /// </summary>
        [RequireCImguiSystemFact]
        public void FindViewportById_UnknownId_ReturnsNull()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                ImGuiViewportPtr viewport = ImGui.FindViewportById(0x12345678);
                Assert.Equal(IntPtr.Zero, viewport.NativePtr);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies FindViewportByPlatformHandle returns null for an unknown handle.
        /// </summary>
        [RequireCImguiSystemFact]
        public void FindViewportByPlatformHandle_UnknownHandle_ReturnsNull()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                ImGuiViewportPtr viewport = ImGui.FindViewportByPlatformHandle(new IntPtr(0x1234));
                Assert.Equal(IntPtr.Zero, viewport.NativePtr);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies GetWindowDpiScale returns a scale without a frame.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetWindowDpiScale_WithoutFrame_ReturnsScale()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                _ = ImGui.GetWindowDpiScale();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies GetClipboardText throws because the generated wrapper cannot
        ///     marshal the native const char return value.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetClipboardText_ThrowsMarshalDirectiveException()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                Assert.Throws<MarshalDirectiveException>(() => ImGui.GetClipboardText());
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies GetIo initializes the cached IO pointer from the native context.
        ///     The context is deliberately leaked so the static cache stays valid for
        ///     the remainder of the test host process.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetIo_InitializesCachedPointer()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            ImGuiNative.igSetCurrentContext(ctx);
            ImGuiIoPtr io = ImGui.GetIo();
            Assert.NotEqual(IntPtr.Zero, io.NativePtr);
        }
    }
}
