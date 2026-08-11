// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP6NativeCoverageTests.cs
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
    ///     Invokes the native input-state and memory helpers contributed by the
    ///     ImGuiP6 partial class. All calls are safe without a frame because they
    ///     only read context/IO state or use the global allocators.
    /// </summary>
    public class ImGuiP6NativeCoverageTests
    {
        /// <summary>
        ///     Verifies IsAnyMouseDown and the IsAnyItem query helpers execute.
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsAnyMouseDown_And_IsAnyItem_Execute()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                _ = ImGui.IsAnyMouseDown();
                _ = ImGui.IsAnyItemActive();
                _ = ImGui.IsAnyItemFocused();
                _ = ImGui.IsAnyItemHovered();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies the IsKey query helpers execute.
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsKey_QueryHelpers_Execute()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                _ = ImGui.IsKeyDown(ImGuiKey.A);
                _ = ImGui.IsKeyPressed(ImGuiKey.A);
                _ = ImGui.IsKeyPressed(ImGuiKey.A, false);
                _ = ImGui.IsKeyReleased(ImGuiKey.A);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies the IsMouse query helpers execute.
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsMouse_QueryHelpers_Execute()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                _ = ImGui.IsMouseClicked(ImGuiMouseButton.Left);
                _ = ImGui.IsMouseClicked(ImGuiMouseButton.Left, false);
                _ = ImGui.IsMouseDoubleClicked(ImGuiMouseButton.Left);
                _ = ImGui.IsMouseDown(ImGuiMouseButton.Left);
                _ = ImGui.IsMouseDragging(ImGuiMouseButton.Left);
                _ = ImGui.IsMouseDragging(ImGuiMouseButton.Left, -1.0f);
                _ = ImGui.IsMouseReleased(ImGuiMouseButton.Left);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies IsMouseHoveringRect with clipping disabled executes. The
        ///     overload without the clip argument hardcodes clipping enabled, which
        ///     crashes without a frame, so only this variant is safe.
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsMouseHoveringRect_WithoutClip_Executes()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                _ = ImGui.IsMouseHoveringRect(new Vector2F(0, 0), new Vector2F(10, 10), false);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies IsMousePosValid overloads execute.
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsMousePosValid_AllOverloads_Execute()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                _ = ImGui.IsMousePosValid();
                Vector2F mousePos = new Vector2F(10, 20);
                _ = ImGui.IsMousePosValid(ref mousePos);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies the IsItem query helpers execute without a frame.
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsItem_QueryHelpers_Execute()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                _ = ImGui.IsItemActivated();
                _ = ImGui.IsItemActive();
                _ = ImGui.IsItemClicked();
                _ = ImGui.IsItemClicked(ImGuiMouseButton.Left);
                _ = ImGui.IsItemDeactivated();
                _ = ImGui.IsItemDeactivatedAfterEdit();
                _ = ImGui.IsItemEdited();
                _ = ImGui.IsItemFocused();
                _ = ImGui.IsItemHovered();
                _ = ImGui.IsItemHovered(Alis.Extension.Graphic.Ui.ImGuiHoveredFlags.None);
                _ = ImGui.IsItemToggledOpen();
                _ = ImGui.IsItemVisible();
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies LoadIniSettingsFromMemory overloads execute.
        /// </summary>
        [RequireCImguiSystemFact]
        public void LoadIniSettingsFromMemory_AllOverloads_Execute()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                ImGui.LoadIniSettingsFromMemory("[Window][x]\nPos=1,2");
                ImGui.LoadIniSettingsFromMemory("[Window][x]\nPos=1,2", 32);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }

        /// <summary>
        ///     Verifies MemAlloc and MemFree round trip through the global allocator.
        /// </summary>
        [RequireCImguiSystemFact]
        public void MemAlloc_And_MemFree_RoundTrip()
        {
            IntPtr ctx = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(ctx);
                IntPtr block = ImGui.MemAlloc(64);
                Assert.NotEqual(IntPtr.Zero, block);
                ImGui.MemFree(block);
            }
            finally
            {
                ImGuiNative.igDestroyContext(ctx);
            }
        }
    }
}
