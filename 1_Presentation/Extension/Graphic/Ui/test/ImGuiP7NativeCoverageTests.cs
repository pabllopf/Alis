// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP7NativeCoverageTests.cs
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
    ///     Invokes the native context, clipboard and next-frame state helpers
    ///     contributed by the ImGuiP7 partial class. All calls only mutate context
    ///     data and are safe without a frame.
    /// </summary>
    public class ImGuiP7NativeCoverageTests
    {
        /// <summary>
        ///     Verifies SetCurrentContext switches the active context.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetCurrentContext_WithContext_SwitchesContext()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGui.SetCurrentContext(ctx);
                Assert.Equal(ctx, ImGuiNative.igGetCurrentContext());
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies SetClipboardText executes without a frame.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetClipboardText_WithActiveContext_Executes()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                ImGui.SetClipboardText("clipboard");
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies SaveIniSettingsToDisk writes the ini data to a temp file.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SaveIniSettingsToDisk_WithActiveContext_Executes()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                ImGui.SaveIniSettingsToDisk("/tmp/alis_ui_save_ini_probe.ini");
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies SaveIniSettingsToMemory throws because the generated wrapper
        ///     cannot marshal the native const char return value.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SaveIniSettingsToMemory_ThrowsMarshalDirectiveException()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                Assert.Throws<MarshalDirectiveException>(() => ImGui.SaveIniSettingsToMemory());
                Assert.Throws<MarshalDirectiveException>(() => ImGui.SaveIniSettingsToMemory(out uint size));
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies ResetMouseDragDelta overloads execute.
        /// </summary>
        [RequireCImguiSystemFact]
        public void ResetMouseDragDelta_AllOverloads_Execute()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                ImGui.ResetMouseDragDelta();
                ImGui.ResetMouseDragDelta(ImGuiMouseButton.Left);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies SetColorEditOptions and SetMouseCursor execute.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetColorEditOptions_And_SetMouseCursor_Execute()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                ImGui.SetColorEditOptions(ImGuiColorEditFlags.None);
                ImGui.SetMouseCursor(ImGuiMouseCursor.Arrow);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies the next-frame capture helpers execute.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetNextFrameWantCapture_Helpers_Execute()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                ImGui.SetNextFrameWantCaptureKeyboard(true);
                ImGui.SetNextFrameWantCaptureMouse(true);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies SetNextItemWidth executes.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetNextItemWidth_WithActiveContext_Executes()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                ImGui.SetNextItemWidth(120.0f);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies SetNextWindowBgAlpha and SetNextWindowCollapsed execute.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetNextWindowBgAlpha_And_Collapsed_Execute()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                ImGui.SetNextWindowBgAlpha(0.5f);
                ImGui.SetNextWindowCollapsed(false);
                ImGui.SetNextWindowCollapsed(false, ImGuiCond.Once);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies SetNextWindowClass and SetNextWindowContentSize execute.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetNextWindowClass_And_ContentSize_Execute()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                ImGui.SetNextWindowClass(new ImGuiWindowClass());
                ImGui.SetNextWindowContentSize(new Vector2F(100, 100));
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies SetNextWindowDockId overloads execute.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetNextWindowDockId_AllOverloads_Execute()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                ImGui.SetNextWindowDockId(1);
                ImGui.SetNextWindowDockId(1, ImGuiCond.Once);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies SetNextWindowFocus and SetNextWindowPos overloads execute.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetNextWindowFocus_And_Pos_Execute()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                ImGui.SetNextWindowFocus();
                ImGui.SetNextWindowPos(new Vector2F(10, 10));
                ImGui.SetNextWindowPos(new Vector2F(10, 10), ImGuiCond.Once);
                ImGui.SetNextWindowPos(new Vector2F(10, 10), ImGuiCond.Once, new Vector2F(0.5f, 0.5f));
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies SetNextWindowScroll and SetNextWindowSize overloads execute.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetNextWindowScroll_And_Size_Execute()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                ImGui.SetNextWindowScroll(new Vector2F(1, 2));
                ImGui.SetNextWindowSize(new Vector2F(320, 240));
                ImGui.SetNextWindowSize(new Vector2F(320, 240), ImGuiCond.Once);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies SetNextWindowSizeConstraints overloads execute.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetNextWindowSizeConstraints_AllOverloads_Execute()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                ImGui.SetNextWindowSizeConstraints(new Vector2F(1, 2), new Vector2F(3, 4));
                ImGui.SetNextWindowSizeConstraints(new Vector2F(1, 2), new Vector2F(3, 4), null);
                ImGui.SetNextWindowSizeConstraints(new Vector2F(1, 2), new Vector2F(3, 4), null, IntPtr.Zero);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies SetNextWindowViewport executes.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetNextWindowViewport_WithActiveContext_Executes()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                ImGui.SetNextWindowViewport(1);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }
    }
}
