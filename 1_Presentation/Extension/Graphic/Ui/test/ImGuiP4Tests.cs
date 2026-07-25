// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP4Tests.cs
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
    public class ImGuiP4Tests : IDisposable
    {
        internal readonly IntPtr _ctx;

        public ImGuiP4Tests()
        {
            _ctx = ImGui.CreateContext();
            ImGui.SetCurrentContext(_ctx);
            ImGuiIoPtr io = ImGui.GetIo();
            io.DisplaySize = new Vector2F(1920f, 1080f);
            io.Fonts.Build();
        }

        public void Dispose()
        {
            ImGuiNative.igDestroyContext(_ctx);
        }

        [RequireCImguiSystemFact]
        public void TableSetupColumn_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            if (ImGui.BeginTable("t", 2))
            {
                ImGui.TableSetupColumn("Col1", ImGuiTableColumnFlags.None);
                ImGui.TableSetupColumn("Col2", ImGuiTableColumnFlags.None, 100.0f);
                ImGui.TableSetupColumn("Col3", ImGuiTableColumnFlags.None, 100.0f, 1u);
                ImGui.EndTable();
            }
            ImGui.End();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void TableSetupScrollFreeze_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            if (ImGui.BeginTable("t", 3))
            {
                ImGui.TableSetupScrollFreeze(1, 0);
                ImGui.EndTable();
            }
            ImGui.End();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void TextMethods_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");

            ImGui.Text("Hello");
            ImGui.TextColored(new Vector4F(1.0f, 0.0f, 0.0f, 1.0f), "Red Text");
            ImGui.TextDisabled("Disabled Text");
            ImGui.TextUnformatted("Unformatted Text");
            ImGui.TextWrapped("Wrapped Text");

            ImGui.End();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void TreeNodeMethods_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");

            bool r1 = ImGui.TreeNode("label1");
            if (r1) ImGui.TreePop();

            bool r2 = ImGui.TreeNode("id2", "fmt2");
            if (r2) ImGui.TreePop();

            bool r3 = ImGui.TreeNode(IntPtr.Zero, "ptr3");
            if (r3) ImGui.TreePop();

            bool r4 = ImGui.TreeNodeEx("label4");
            if (r4) ImGui.TreePop();

            bool r5 = ImGui.TreeNodeEx("label5", ImGuiTreeNodeFlags.None);
            if (r5) ImGui.TreePop();

            bool r6 = ImGui.TreeNodeEx("id6", ImGuiTreeNodeFlags.None, "fmt6");
            if (r6) ImGui.TreePop();

            bool r7 = ImGui.TreeNodeEx(IntPtr.Zero, ImGuiTreeNodeFlags.None, "fmt7");
            if (r7) ImGui.TreePop();

            _ = r1;
            _ = r2;
            _ = r3;
            _ = r4;
            _ = r5;
            _ = r6;
            _ = r7;

            ImGui.End();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void TreePush_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");

            ImGui.TreePush("strId");
            ImGui.TreePop();

            ImGui.TreePush(IntPtr.Zero);
            ImGui.TreePop();

            ImGui.End();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void TreePop_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");

            ImGui.TreePush("test");
            ImGui.TreePop();

            ImGui.End();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void Unindent_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");

            ImGui.Unindent();
            ImGui.Unindent(10.0f);

            ImGui.End();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void Value_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");

            ImGui.Value("bool", true);
            ImGui.Value("int", 42);
            ImGui.Value("uint", 42u);
            ImGui.Value("float", 3.14f);
            ImGui.Value("format", 3.14f, "%.2f");

            ImGui.End();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void VSliderFloat_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");

            float v = 50.0f;
            Vector2F size = new Vector2F(20.0f, 100.0f);

            bool r1 = ImGui.VSliderFloat("s1", size, ref v, 0.0f, 100.0f);
            bool r2 = ImGui.VSliderFloat("s2", size, ref v, 0.0f, 100.0f, "%.1f");
            bool r3 = ImGui.VSliderFloat("s3", size, ref v, 0.0f, 100.0f, "%.1f", ImGuiSliderFlags.None);

            _ = r1;
            _ = r2;
            _ = r3;

            ImGui.End();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void VSliderInt_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");

            int v = 50;
            Vector2F size = new Vector2F(20.0f, 100.0f);

            bool r1 = ImGui.VSliderInt("s1", size, ref v, 0, 100);
            bool r2 = ImGui.VSliderInt("s2", size, ref v, 0, 100, "%d");
            bool r3 = ImGui.VSliderInt("s3", size, ref v, 0, 100, "%d", ImGuiSliderFlags.None);

            _ = r1;
            _ = r2;
            _ = r3;

            ImGui.End();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void VSliderScalar_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");

            Vector2F size = new Vector2F(20.0f, 100.0f);
            float val = 50.0f;
            float min = 0.0f;
            float max = 100.0f;

            IntPtr pData = Marshal.AllocHGlobal(sizeof(float));
            IntPtr pMin = Marshal.AllocHGlobal(sizeof(float));
            IntPtr pMax = Marshal.AllocHGlobal(sizeof(float));
            Marshal.StructureToPtr(val, pData, false);
            Marshal.StructureToPtr(min, pMin, false);
            Marshal.StructureToPtr(max, pMax, false);

            bool r1 = ImGui.VSliderScalar("s1", size, ImGuiDataType.Float, pData, pMin, pMax);
            bool r2 = ImGui.VSliderScalar("s2", size, ImGuiDataType.Float, pData, pMin, pMax, "%.1f");
            bool r3 = ImGui.VSliderScalar("s3", size, ImGuiDataType.Float, pData, pMin, pMax, "%.1f", ImGuiSliderFlags.None);

            _ = r1;
            _ = r2;
            _ = r3;

            Marshal.FreeHGlobal(pData);
            Marshal.FreeHGlobal(pMin);
            Marshal.FreeHGlobal(pMax);

            ImGui.End();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void InputText_RefStringOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");

            string input = "test";
            bool r1 = ImGui.InputText("lbl", ref input, 256);
            bool r2 = ImGui.InputText("lbl", ref input, 256, ImGuiInputTextFlags.None);
            bool r3 = ImGui.InputText("lbl", ref input, 256, ImGuiInputTextFlags.None, null);
            bool r4 = ImGui.InputText("lbl", ref input, 256, ImGuiInputTextFlags.None, null, IntPtr.Zero);

            _ = r1;
            _ = r2;
            _ = r3;
            _ = r4;

            ImGui.End();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void InputText_ByteArrayOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");

            byte[] buf = new byte[256];
            bool r1 = ImGui.InputText("lbl", buf, 256);
            bool r2 = ImGui.InputText("lbl", buf, 256, ImGuiInputTextFlags.None);
            bool r3 = ImGui.InputText("lbl", buf, 256, ImGuiInputTextFlags.None, null);
            bool r4 = ImGui.InputText("lbl", buf, 256, ImGuiInputTextFlags.None, null, IntPtr.Zero);

            _ = r1;
            _ = r2;
            _ = r3;
            _ = r4;

            ImGui.End();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void InputText_IntPtrOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");

            IntPtr buf = Marshal.AllocHGlobal(256);

            bool r1 = ImGui.InputText("lbl", buf, 256);
            bool r2 = ImGui.InputText("lbl", buf, 256, ImGuiInputTextFlags.None);
            bool r3 = ImGui.InputText("lbl", buf, 256, ImGuiInputTextFlags.None, null);
            bool r4 = ImGui.InputText("lbl", buf, 256, ImGuiInputTextFlags.None, null, IntPtr.Zero);

            _ = r1;
            _ = r2;
            _ = r3;
            _ = r4;

            Marshal.FreeHGlobal(buf);

            ImGui.End();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void InputTextMultiline_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");

            string input = "multi\nline";
            Vector2F size = new Vector2F(200.0f, 100.0f);

            bool r1 = ImGui.InputTextMultiline("lbl", ref input, 256, size);
            bool r2 = ImGui.InputTextMultiline("lbl", ref input, 256, size, ImGuiInputTextFlags.None);
            bool r3 = ImGui.InputTextMultiline("lbl", ref input, 256, size, ImGuiInputTextFlags.None, null);
            bool r4 = ImGui.InputTextMultiline("lbl", ref input, 256, size, ImGuiInputTextFlags.None, null, IntPtr.Zero);

            _ = r1;
            _ = r2;
            _ = r3;
            _ = r4;

            ImGui.End();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void InputTextWithHint_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");

            string input = "value";
            string hint = "enter text";

            bool r1 = ImGui.InputTextWithHint("lbl", hint, input, 256);
            bool r2 = ImGui.InputTextWithHint("lbl", hint, input, 256, ImGuiInputTextFlags.None);
            bool r3 = ImGui.InputTextWithHint("lbl", hint, input, 256, ImGuiInputTextFlags.None, null);
            bool r4 = ImGui.InputTextWithHint("lbl", hint, input, 256, ImGuiInputTextFlags.None, null, IntPtr.Zero);

            _ = r1;
            _ = r2;
            _ = r3;
            _ = r4;

            ImGui.End();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void CalcTextSize_AllOverloads_ShouldExecute()
        {
            Vector2F r1 = ImGui.CalcTextSize("hello");
            Vector2F r2 = ImGui.CalcTextSize("hello", 0);
            Vector2F r3 = ImGui.CalcTextSize("hello", -1.0f);
            Vector2F r4 = ImGui.CalcTextSize("hello", false);
            Vector2F r5 = ImGui.CalcTextSize("hello", 0, 5);
            Vector2F r6 = ImGui.CalcTextSize("hello", 0, false);
            Vector2F r7 = ImGui.CalcTextSize("hello", 0, -1.0f);
            Vector2F r8 = ImGui.CalcTextSize("hello", false, -1.0f);
            Vector2F r9 = ImGui.CalcTextSize("hello", 0, 5, false);
            Vector2F r10 = ImGui.CalcTextSize("hello", 0, 5, -1.0f);
            Vector2F r11 = ImGui.CalcTextSize("hello", 0, 5, false, -1.0f);

            _ = r1;
            _ = r2;
            _ = r3;
            _ = r4;
            _ = r5;
            _ = r6;
            _ = r7;
            _ = r8;
            _ = r9;
            _ = r10;
            _ = r11;
        }

        [RequireCImguiSystemFact]
        public void Begin_WithFlags_ShouldExecute()
        {
            ImGui.NewFrame();

            ImGui.Begin("FlaggedWin", ImGuiWindowFlags.None);
            ImGui.Text("inside flagged window");
            ImGui.End();

            ImGui.Render();
        }
    }
}
