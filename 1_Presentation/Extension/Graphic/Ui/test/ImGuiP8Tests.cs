// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP8Tests.cs
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
    ///     Executes every method from ImGuiP8 to drive line coverage.
    /// </summary>
    public class ImGuiP8Tests : IDisposable
    {
        internal readonly IntPtr _ctx;

        public ImGuiP8Tests()
        {
            _ctx = ImGui.CreateContext();
            ImGui.SetCurrentContext(_ctx);
            ImGuiIoPtr io = ImGui.GetIo();
            io.DisplaySize = new Vector2F(1920f, 1080f);
            io.Fonts.Build();
        }

        public void Dispose()
        {
            ImGui.SetCurrentContext(IntPtr.Zero);
            ImGuiNative.igDestroyContext(_ctx);
        }

        [RequireCImguiSystemFact]
        public void ShowAboutWindow_NoArgs_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.ShowAboutWindow();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void ShowAboutWindow_RefBool_ShouldExecute()
        {
            ImGui.NewFrame();
            bool open = true;
            ImGui.ShowAboutWindow(ref open);
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void ShowDebugLogWindow_NoArgs_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.ShowDebugLogWindow();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void ShowDebugLogWindow_RefBool_ShouldExecute()
        {
            ImGui.NewFrame();
            bool open = true;
            ImGui.ShowDebugLogWindow(ref open);
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void ShowDemoWindow_NoArgs_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.ShowDemoWindow();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void ShowDemoWindow_RefBool_ShouldExecute()
        {
            ImGui.NewFrame();
            bool open = true;
            ImGui.ShowDemoWindow(ref open);
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void ShowFontSelector_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("fontWin");
            ImGui.ShowFontSelector("TestFont");
            ImGui.End();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void ShowMetricsWindow_NoArgs_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.ShowMetricsWindow();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void ShowMetricsWindow_RefBool_ShouldExecute()
        {
            ImGui.NewFrame();
            bool open = true;
            ImGui.ShowMetricsWindow(ref open);
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void ShowStackToolWindow_NoArgs_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.ShowStackToolWindow();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void ShowStackToolWindow_RefBool_ShouldExecute()
        {
            ImGui.NewFrame();
            bool open = true;
            ImGui.ShowStackToolWindow(ref open);
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void ShowStyleEditor_NoArgs_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("styleWin");
            ImGui.ShowStyleEditor();
            ImGui.End();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void ShowStyleEditor_WithStyle_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("styleWin2");
            ImGui.ShowStyleEditor(new ImGuiStyle());
            ImGui.End();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void ShowStyleSelector_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("selWin");
            bool result = ImGui.ShowStyleSelector("Style##Selector");
            _ = result;
            ImGui.End();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void ShowUserGuide_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("guideWin");
            ImGui.ShowUserGuide();
            ImGui.End();
            ImGui.Render();
        }
    }
}
