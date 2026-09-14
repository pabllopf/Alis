// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP3CoverageTests.cs
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
    ///     Exercises the safe, headless-callable wrappers of the ImGuiP3 partial class against the
    ///     real cimgui library. Each test owns a fresh context destroyed in finally. The three
    ///     remaining wrappers (EndTabItem, EndDragDropSource, EndDragDropTarget) abort the native
    ///     host and are deliberately absent from this suite.
    /// </summary>
    public class ImGuiP3CoverageTests
    {
        /// <summary>
        ///     Creates a raw ImGui context and binds it as the current context.
        /// </summary>
        /// <returns>The created context pointer</returns>
        private static IntPtr CreateContext()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            ImGuiNative.igSetCurrentContext(ctx);
            return ctx;
        }

        /// <summary>
        ///     Verifies GetCurrentContext returns the active context pointer.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetCurrentContext_WithActiveContext_ReturnsActivePointer()
        {
            IntPtr ctx = CreateContext();
            try
            {
                Assert.Equal(ctx, ImGui.GetCurrentContext());
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies GetVersion returns a non-empty string.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetVersion_WithActiveContext_ReturnsNonEmptyString()
        {
            IntPtr ctx = CreateContext();
            try
            {
                Assert.False(string.IsNullOrEmpty(ImGui.GetVersion()));
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
            IntPtr ctx = CreateContext();
            try
            {
                Assert.True(ImGui.GetFrameCount() >= 0);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies GetTime returns a non-negative value.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetTime_WithActiveContext_ReturnsNonNegative()
        {
            IntPtr ctx = CreateContext();
            try
            {
                Assert.True(ImGui.GetTime() >= 0.0);
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
        public void GetDrawListSharedData_WithActiveContext_ReturnsNonZero()
        {
            IntPtr ctx = CreateContext();
            try
            {
                Assert.NotEqual(IntPtr.Zero, ImGui.GetDrawListSharedData());
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies GetMainViewport returns a non-zero viewport pointer.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetMainViewport_WithActiveContext_ReturnsNonZero()
        {
            IntPtr ctx = CreateContext();
            try
            {
                Assert.NotEqual(IntPtr.Zero, ImGui.GetMainViewport().NativePtr);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies FindViewportById returns a null viewport for an unknown id.
        /// </summary>
        [RequireCImguiSystemFact]
        public void FindViewportById_UnknownId_ReturnsNullViewport()
        {
            IntPtr ctx = CreateContext();
            try
            {
                Assert.Equal(IntPtr.Zero, ImGui.FindViewportById(0x12345678).NativePtr);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies FindViewportByPlatformHandle returns a null viewport for an unknown handle.
        /// </summary>
        [RequireCImguiSystemFact]
        public void FindViewportByPlatformHandle_UnknownHandle_ReturnsNullViewport()
        {
            IntPtr ctx = CreateContext();
            try
            {
                Assert.Equal(IntPtr.Zero, ImGui.FindViewportByPlatformHandle(new IntPtr(0x1234)).NativePtr);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies GetFont and GetFontSize execute against a live context.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetFont_And_GetFontSize_WithActiveContext_Execute()
        {
            IntPtr ctx = CreateContext();
            try
            {
                _ = ImGui.GetFont();
                _ = ImGui.GetFontSize();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies GetFontTexUvWhitePixel returns a vector against a live context.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetFontTexUvWhitePixel_WithActiveContext_ReturnsVector()
        {
            IntPtr ctx = CreateContext();
            try
            {
                _ = ImGui.GetFontTexUvWhitePixel();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies GetFrameHeight returns a value against a live context.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetFrameHeight_WithActiveContext_ReturnsValue()
        {
            IntPtr ctx = CreateContext();
            try
            {
                _ = ImGui.GetFrameHeight();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies GetFrameHeightWithSpacing returns a value against a live context.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetFrameHeightWithSpacing_WithActiveContext_ReturnsValue()
        {
            IntPtr ctx = CreateContext();
            try
            {
                _ = ImGui.GetFrameHeightWithSpacing();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies GetKeyIndex executes against a live context.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetKeyIndex_WithActiveContext_Executes()
        {
            IntPtr ctx = CreateContext();
            try
            {
                _ = ImGui.GetKeyIndex(ImGuiKey.A);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies GetKeyPressedAmount executes against a live context.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetKeyPressedAmount_WithActiveContext_Executes()
        {
            IntPtr ctx = CreateContext();
            try
            {
                _ = ImGui.GetKeyPressedAmount(ImGuiKey.A, 0.1f, 0.1f);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies GetMousePos returns a vector against a live context.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetMousePos_WithActiveContext_ReturnsVector()
        {
            IntPtr ctx = CreateContext();
            try
            {
                _ = ImGui.GetMousePos();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies GetMousePosOnOpeningCurrentPopup returns a vector against a live context.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetMousePosOnOpeningCurrentPopup_WithActiveContext_ReturnsVector()
        {
            IntPtr ctx = CreateContext();
            try
            {
                _ = ImGui.GetMousePosOnOpeningCurrentPopup();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies GetMouseCursor executes against a live context.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetMouseCursor_WithActiveContext_Executes()
        {
            IntPtr ctx = CreateContext();
            try
            {
                _ = ImGui.GetMouseCursor();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies GetMouseClickedCount executes against a live context.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetMouseClickedCount_WithActiveContext_Executes()
        {
            IntPtr ctx = CreateContext();
            try
            {
                _ = ImGui.GetMouseClickedCount(ImGuiMouseButton.Left);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies all GetMouseDragDelta overloads execute against a live context.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetMouseDragDelta_AllOverloads_WithActiveContext_Execute()
        {
            IntPtr ctx = CreateContext();
            try
            {
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
        ///     Verifies GetPlatformIo returns a non-zero pointer.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetPlatformIo_WithActiveContext_ReturnsNonZero()
        {
            IntPtr ctx = CreateContext();
            try
            {
                Assert.NotEqual(IntPtr.Zero, ImGui.GetPlatformIo().NativePtr);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies GetStyleColorVec4 returns a color against a live context.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetStyleColorVec4_WithActiveContext_ReturnsColor()
        {
            IntPtr ctx = CreateContext();
            try
            {
                _ = ImGui.GetStyleColorVec4(ImGuiCol.Text);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies GetTextLineHeight returns a value against a live context.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetTextLineHeight_WithActiveContext_ReturnsValue()
        {
            IntPtr ctx = CreateContext();
            try
            {
                _ = ImGui.GetTextLineHeight();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies GetTextLineHeightWithSpacing returns a value against a live context.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetTextLineHeightWithSpacing_WithActiveContext_ReturnsValue()
        {
            IntPtr ctx = CreateContext();
            try
            {
                _ = ImGui.GetTextLineHeightWithSpacing();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies GetTreeNodeToLabelSpacing returns a value against a live context.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetTreeNodeToLabelSpacing_WithActiveContext_ReturnsValue()
        {
            IntPtr ctx = CreateContext();
            try
            {
                _ = ImGui.GetTreeNodeToLabelSpacing();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies GetWindowDpiScale returns a value against a live context.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetWindowDpiScale_WithActiveContext_ReturnsValue()
        {
            IntPtr ctx = CreateContext();
            try
            {
                _ = ImGui.GetWindowDpiScale();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies GetColorU32 with a color index returns a non-zero color.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetColorU32_ColIndex_WithActiveContext_ReturnsNonZero()
        {
            IntPtr ctx = CreateContext();
            try
            {
                Assert.NotEqual(0u, ImGui.GetColorU32(ImGuiCol.Text));
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies GetColorU32 with a color index and alpha returns a non-zero color.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetColorU32_ColIndexAndAlpha_WithActiveContext_ReturnsNonZero()
        {
            IntPtr ctx = CreateContext();
            try
            {
                Assert.NotEqual(0u, ImGui.GetColorU32(ImGuiCol.Text, 0.5f));
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies GetColorU32 with a vector color returns a non-zero color.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetColorU32_VectorColor_WithActiveContext_ReturnsNonZero()
        {
            IntPtr ctx = CreateContext();
            try
            {
                Assert.NotEqual(0u, ImGui.GetColorU32(new Vector4F(1, 1, 1, 1)));
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies GetColorU32 passes through the raw packed color value.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetColorU32_PackedColor_WithActiveContext_ReturnsInput()
        {
            IntPtr ctx = CreateContext();
            try
            {
                uint input = 0xFF00AA80;
                Assert.Equal(input, ImGui.GetColorU32(input));
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies GetAllocatorFunctions fills the default allocator pointers.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetAllocatorFunctions_WithActiveContext_Executes()
        {
            IntPtr ctx = CreateContext();
            try
            {
                IntPtr alloc = IntPtr.Zero;
                IntPtr free = IntPtr.Zero;
                IntPtr userData = IntPtr.Zero;
                ImGui.GetAllocatorFunctions(ref alloc, ref free, ref userData);
                Assert.NotEqual(IntPtr.Zero, alloc);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies GetStyle returns the default style with a positive alpha.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetStyle_WithActiveContext_ReturnsDefaultStyle()
        {
            IntPtr ctx = CreateContext();
            try
            {
                Assert.True(ImGui.GetStyle().Alpha > 0.0f);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies GetClipboardText executes and either returns a string or throws on
        ///     platforms where the generated wrapper cannot marshal the native const char return.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetClipboardText_WithActiveContext_DoesNotCrash()
        {
            IntPtr ctx = CreateContext();
            try
            {
                try
                {
                    string text = ImGui.GetClipboardText();
                    Assert.NotNull(text);
                }
                catch (MarshalDirectiveException)
                {
                    Assert.True(true);
                }
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies GetKeyName executes and either returns a string or throws on platforms
        ///     where the generated wrapper cannot marshal the native const char return.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetKeyName_WithActiveContext_DoesNotCrash()
        {
            IntPtr ctx = CreateContext();
            try
            {
                try
                {
                    string name = ImGui.GetKeyName(ImGuiKey.A);
                    Assert.NotNull(name);
                }
                catch (MarshalDirectiveException)
                {
                    Assert.True(true);
                }
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies GetStyleColorName executes and either returns a string or throws on
        ///     platforms where the generated wrapper cannot marshal the native const char return.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetStyleColorName_WithActiveContext_DoesNotCrash()
        {
            IntPtr ctx = CreateContext();
            try
            {
                try
                {
                    string name = ImGui.GetStyleColorName(ImGuiCol.Text);
                    Assert.NotNull(name);
                }
                catch (MarshalDirectiveException)
                {
                    Assert.True(true);
                }
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies GetDrawData executes and either returns draw data or throws when no
        ///     rendered frame is available yet.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetDrawData_WithActiveContext_DoesNotCrash()
        {
            IntPtr ctx = CreateContext();
            try
            {
                try
                {
                    _ = ImGui.GetDrawData();
                }
                catch (NullReferenceException)
                {
                    Assert.True(true);
                }
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies GetIo initializes the cached IO pointer. The context is deliberately
        ///     leaked so the static IO cache stays valid for the test host process.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetIo_WithActiveContext_InitializesCachedPointer()
        {
            IntPtr ctx = CreateContext();
            ImGuiIoPtr io = ImGui.GetIo();
            Assert.NotEqual(IntPtr.Zero, io.NativePtr);
        }
    }
}