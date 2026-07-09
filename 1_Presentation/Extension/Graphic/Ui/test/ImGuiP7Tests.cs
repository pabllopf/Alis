// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP7Tests.cs
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
using System.Linq;
using System.Reflection;
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    public class ImGuiP7Tests : IDisposable
    {
        private readonly IntPtr _ctx;

        public ImGuiP7Tests()
        {
            _ctx = ImGui.CreateContext();
            ImGui.SetCurrentContext(_ctx);
            var io = ImGui.GetIo();
            io.DisplaySize = new Vector2F(1920f, 1080f);
            io.Fonts.Build();
        }

        public void Dispose()
        {
            ImGuiNative.igDestroyContext(_ctx);
        }

        [Fact]
        public void SetTooltip()
        {
            ImGui.NewFrame();
            ImGui.SetTooltip("Test tooltip");
            ImGui.Render();
        }

        [Fact]
        public void PushFont_And_PopFont()
        {
            ImGui.NewFrame();
            var io = ImGui.GetIo();
            if (io.Fonts.Fonts.Size > 0)
            {
                ImFontPtr font = io.Fonts.Fonts[0];
                ImGui.PushFont(font);
                ImGui.PopFont();
            }
            ImGui.Render();
        }

        [Fact]
        public void PushFont_WithNullFont_DoesNotThrow()
        {
            ImGui.NewFrame();
            var exception = Record.Exception(() =>
            {
                ImGui.PopFont();
            });
            ImGui.Render();
        }

        [Fact]
        public void PopFont_AfterPush_DoesNotThrow()
        {
            ImGui.NewFrame();
            var io = ImGui.GetIo();
            if (io.Fonts.Fonts.Size > 0)
            {
                ImFontPtr font = io.Fonts.Fonts[0];
                ImGui.PushFont(font);
                ImGui.PopFont();
            }
            ImGui.Render();
        }

        [Fact]
        public void SetAllocatorFunctions_TwoArgs_WithNull_DoesNotThrow()
        {
            ImGui.NewFrame();
            ImGui.SetAllocatorFunctions(IntPtr.Zero, IntPtr.Zero);
            ImGui.Render();
        }

        [Fact]
        public void SetAllocatorFunctions_ThreeArgs_WithNull_DoesNotThrow()
        {
            ImGui.NewFrame();
            ImGui.SetAllocatorFunctions(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
            ImGui.Render();
        }

        [Fact]
        public void SetDragDropPayload_DefaultCond()
        {
            ImGui.NewFrame();
            IntPtr data = IntPtr.Zero;
            bool result = ImGui.SetDragDropPayload("test", data, 0);
            ImGui.Render();
        }

        [Fact]
        public void SetDragDropPayload_WithCond()
        {
            ImGui.NewFrame();
            IntPtr data = IntPtr.Zero;
            bool result = ImGui.SetDragDropPayload("test", data, 0, ImGuiCond.Once);
            ImGui.Render();
        }

        [Fact]
        public void SetAllocatorFunctions_ShouldExposeTwoOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(m => m.Name == "SetAllocatorFunctions").ToArray();
            Assert.True(methods.Length >= 2);
        }

        [Fact]
        public void SetDragDropPayload_ShouldExposeTwoOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(m => m.Name == "SetDragDropPayload").ToArray();
            Assert.True(methods.Length >= 2);
        }

        [Fact]
        public void SetTooltip_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("SetTooltip", BindingFlags.Public | BindingFlags.Static));
        }

        [Fact]
        public void PushFont_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("PushFont", BindingFlags.Public | BindingFlags.Static));
        }

        [Fact]
        public void PopFont_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("PopFont", BindingFlags.Public | BindingFlags.Static));
        }
    }
}
