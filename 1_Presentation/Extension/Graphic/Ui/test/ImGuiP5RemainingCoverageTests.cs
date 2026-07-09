using System;
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    public class ImGuiP5RemainingCoverageTests : IDisposable
    {
        private readonly IntPtr _ctx;

        public ImGuiP5RemainingCoverageTests()
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
        public void AlignTextToFramePadding_Test()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            ImGui.AlignTextToFramePadding();
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void ArrowButton_Test()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            ImGui.ArrowButton("btn", ImGuiDir.Right);
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void Begin_Window_Test()
        {
            ImGui.NewFrame();
            bool isOpen = true;
            ImGui.Begin("Test1");
            ImGui.End();
            ImGui.Begin("Test2", ref isOpen);
            ImGui.End();
            ImGui.Begin("Test3", ref isOpen, ImGuiWindowFlags.None);
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void BeginChild_String_Test()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            ImGui.BeginChild("c1");
            ImGui.EndChild();
            ImGui.BeginChild("c2", new Vector2F(100, 100));
            ImGui.EndChild();
            ImGui.BeginChild("c3", new Vector2F(100, 100), true);
            ImGui.EndChild();
            ImGui.BeginChild("c4", new Vector2F(100, 100), true, ImGuiWindowFlags.None);
            ImGui.EndChild();
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void BeginChild_Uint_Test()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            ImGui.BeginChild(1u);
            ImGui.EndChild();
            ImGui.BeginChild(2u, new Vector2F(100, 100));
            ImGui.EndChild();
            ImGui.BeginChild(3u, new Vector2F(100, 100), true);
            ImGui.EndChild();
            ImGui.BeginChild(4u, new Vector2F(100, 100), true, ImGuiWindowFlags.None);
            ImGui.EndChild();
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void BeginChildFrame_Test()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            ImGui.BeginChildFrame(1u, new Vector2F(100, 100));
            ImGui.EndChildFrame();
            ImGui.BeginChildFrame(2u, new Vector2F(100, 100), ImGuiWindowFlags.None);
            ImGui.EndChildFrame();
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void BeginCombo_Test()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            if (ImGui.BeginCombo("combo", "item"))
            {
                ImGui.EndCombo();
            }
            if (ImGui.BeginCombo("combo2", "item", ImGuiComboFlags.None))
            {
                ImGui.EndCombo();
            }
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void BeginDisabled_Test()
        {
            ImGui.NewFrame();
            ImGui.BeginDisabled();
            ImGui.EndDisabled();
            ImGui.BeginDisabled(true);
            ImGui.EndDisabled();
            ImGui.Render();
        }

        [Fact]
        public void BeginDragDropSource_Test()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            ImGui.Button("drag");
            if (ImGui.BeginDragDropSource())
            {
                ImGui.EndDragDropSource();
            }
            if (ImGui.BeginDragDropSource(ImGuiDragDropFlags.None))
            {
                ImGui.EndDragDropSource();
            }
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void BeginDragDropTarget_Test()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            if (ImGui.BeginDragDropTarget())
            {
                ImGui.EndDragDropTarget();
            }
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void BeginGroup_Test()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            ImGui.BeginGroup();
            ImGui.EndGroup();
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void BeginListBox_Test()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            if (ImGui.BeginListBox("lb1"))
            {
                ImGui.EndListBox();
            }
            if (ImGui.BeginListBox("lb2", new Vector2F(150, 100)))
            {
                ImGui.EndListBox();
            }
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void BeginMainMenuBar_Test()
        {
            ImGui.NewFrame();
            if (ImGui.BeginMainMenuBar())
            {
                ImGui.EndMainMenuBar();
            }
            ImGui.Render();
        }

        [Fact]
        public void BeginMenu_Test()
        {
            ImGui.NewFrame();
            if (ImGui.BeginMainMenuBar())
            {
                if (ImGui.BeginMenu("File"))
                {
                    ImGui.EndMenu();
                }
                if (ImGui.BeginMenu("Edit", true))
                {
                    ImGui.EndMenu();
                }
                ImGui.EndMainMenuBar();
            }
            ImGui.Render();
        }

        [Fact]
        public void BeginMenuBar_Test()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            if (ImGui.BeginMenuBar())
            {
                ImGui.EndMenuBar();
            }
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void BeginPopupContextItem_Test()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            ImGui.Button("test");
            if (ImGui.BeginPopupContextItem())
            {
                ImGui.EndPopup();
            }
            if (ImGui.BeginPopupContextItem("ctx1"))
            {
                ImGui.EndPopup();
            }
            if (ImGui.BeginPopupContextItem("ctx2", ImGuiPopupFlags.None))
            {
                ImGui.EndPopup();
            }
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void BeginPopupContextVoid_Test()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            if (ImGui.BeginPopupContextVoid())
            {
                ImGui.EndPopup();
            }
            if (ImGui.BeginPopupContextVoid("ctx1"))
            {
                ImGui.EndPopup();
            }
            if (ImGui.BeginPopupContextVoid("ctx2", ImGuiPopupFlags.None))
            {
                ImGui.EndPopup();
            }
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void BeginPopupContextWindow_Test()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            if (ImGui.BeginPopupContextWindow())
            {
                ImGui.EndPopup();
            }
            if (ImGui.BeginPopupContextWindow("ctx1"))
            {
                ImGui.EndPopup();
            }
            if (ImGui.BeginPopupContextWindow("ctx2", ImGuiPopupFlags.None))
            {
                ImGui.EndPopup();
            }
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void BeginTabBar_Test()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            if (ImGui.BeginTabBar("tb1"))
            {
                ImGui.EndTabBar();
            }
            if (ImGui.BeginTabBar("tb2", ImGuiTabBarFlags.None))
            {
                ImGui.EndTabBar();
            }
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void BeginTable_Test()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            if (ImGui.BeginTable("t1", 2))
            {
                ImGui.EndTable();
            }
            if (ImGui.BeginTable("t2", 3, ImGuiTableFlags.None))
            {
                ImGui.EndTable();
            }
            if (ImGui.BeginTable("t3", 4, ImGuiTableFlags.None, new Vector2F(200, 0)))
            {
                ImGui.EndTable();
            }
            if (ImGui.BeginTable("t4", 5, ImGuiTableFlags.None, new Vector2F(200, 0), 0.0f))
            {
                ImGui.EndTable();
            }
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void BeginTooltip_Test()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            ImGui.BeginTooltip();
            ImGui.EndTooltip();
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void Bullet_Test()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            ImGui.Bullet();
            ImGui.BulletText("bullet text");
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void Button_Test()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            ImGui.Button("click");
            ImGui.Button("click", new Vector2F(100, 30));
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void CalcItemWidth_Test()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            float width = ImGui.CalcItemWidth();
            _ = width;
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void CloseCurrentPopup_Test()
        {
            ImGui.NewFrame();
            ImGui.OpenPopup("test_popup");
            if (ImGui.BeginPopup("test_popup"))
            {
                ImGui.CloseCurrentPopup();
                ImGui.EndPopup();
            }
            ImGui.Render();
        }

        [Fact]
        public void ColorButton_Test()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            var col = new Vector4F(1f, 0f, 0f, 1f);
            ImGui.ColorButton("cb1", col);
            ImGui.ColorButton("cb2", col, ImGuiColorEditFlags.None);
            ImGui.ColorButton("cb3", col, ImGuiColorEditFlags.None, new Vector2F(20, 20));
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void ColorConvertFloat4ToU32_Test()
        {
            var col = new Vector4F(0.2f, 0.4f, 0.6f, 1.0f);
            uint result = ImGui.ColorConvertFloat4ToU32(col);
            Assert.NotEqual(0u, result);
        }

        [Fact]
        public void ColorConvertHsVtoRgb_Test()
        {
            float r, g, b;
            ImGui.ColorConvertHsVtoRgb(0.5f, 1.0f, 1.0f, out r, out g, out b);
            Assert.InRange(r, 0f, 1f);
            Assert.InRange(g, 0f, 1f);
            Assert.InRange(b, 0f, 1f);
        }

        [Fact]
        public void ColorConvertRgBtoHsv_Test()
        {
            float h, s, v;
            ImGui.ColorConvertRgBtoHsv(1.0f, 0.0f, 0.0f, out h, out s, out v);
            Assert.InRange(h, 0f, 360f);
            Assert.InRange(s, 0f, 1f);
            Assert.InRange(v, 0f, 1f);
        }

        [Fact]
        public void ColorConvertU32ToFloat4_Test()
        {
            Vector4F result = ImGui.ColorConvertU32ToFloat4(0xFF4080C0u);
            Assert.InRange(result.X, 0f, 1f);
            Assert.InRange(result.Y, 0f, 1f);
            Assert.InRange(result.Z, 0f, 1f);
            Assert.InRange(result.W, 0f, 1f);
        }

        [Fact]
        public void ColorEdit4_Test()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            var col = new Vector4F(1f, 0.5f, 0f, 1f);
            var labelPtr = System.Runtime.InteropServices.Marshal.StringToCoTaskMemUTF8("ce4");
            try
            {
                ImGui.ColorEdit4(labelPtr, ref col);
                ImGui.ColorEdit4(labelPtr, ref col, ImGuiColorEditFlags.None);
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.FreeCoTaskMem(labelPtr);
            }
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void Columns_Test()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            ImGui.Columns();
            ImGui.NextColumn();
            ImGui.Columns(2);
            ImGui.NextColumn();
            ImGui.Columns(3, "cols");
            ImGui.NextColumn();
            ImGui.Columns(4, "colsb", true);
            ImGui.NextColumn();
            ImGui.End();
            ImGui.Render();
        }
    }
}
