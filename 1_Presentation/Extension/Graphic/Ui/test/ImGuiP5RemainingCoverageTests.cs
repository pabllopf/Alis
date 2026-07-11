using System;
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// The im gui remaining coverage tests class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public class ImGuiP5RemainingCoverageTests : IDisposable
    {
        /// <summary>
        /// The ctx
        /// </summary>
        private readonly IntPtr _ctx;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImGuiP5RemainingCoverageTests"/> class
        /// </summary>
        public ImGuiP5RemainingCoverageTests()
        {
            _ctx = ImGui.CreateContext();
            ImGui.SetCurrentContext(_ctx);
            var io = ImGui.GetIo();
            io.DisplaySize = new Vector2F(1920f, 1080f);
            io.Fonts.Build();
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            ImGuiNative.igDestroyContext(_ctx);
        }

        /// <summary>
        /// Tests that align text to frame padding test
        /// </summary>
        [Fact]
        public void AlignTextToFramePadding_Test()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            ImGui.AlignTextToFramePadding();
            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that arrow button test
        /// </summary>
        [Fact]
        public void ArrowButton_Test()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            ImGui.ArrowButton("btn", ImGuiDir.Right);
            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that begin window test
        /// </summary>
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

        /// <summary>
        /// Tests that begin child string test
        /// </summary>
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

        /// <summary>
        /// Tests that begin child uint test
        /// </summary>
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

        /// <summary>
        /// Tests that begin child frame test
        /// </summary>
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

        /// <summary>
        /// Tests that begin combo test
        /// </summary>
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

        /// <summary>
        /// Tests that begin disabled test
        /// </summary>
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

        /// <summary>
        /// Tests that begin drag drop source test
        /// </summary>
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

        /// <summary>
        /// Tests that begin drag drop target test
        /// </summary>
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

        /// <summary>
        /// Tests that begin group test
        /// </summary>
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

        /// <summary>
        /// Tests that begin list box test
        /// </summary>
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

        /// <summary>
        /// Tests that begin main menu bar test
        /// </summary>
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

        /// <summary>
        /// Tests that begin menu test
        /// </summary>
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

        /// <summary>
        /// Tests that begin menu bar test
        /// </summary>
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

        /// <summary>
        /// Tests that begin popup context item test
        /// </summary>
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

        /// <summary>
        /// Tests that begin popup context void test
        /// </summary>
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

        /// <summary>
        /// Tests that begin popup context window test
        /// </summary>
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

        /// <summary>
        /// Tests that begin tab bar test
        /// </summary>
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

        /// <summary>
        /// Tests that begin table test
        /// </summary>
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

        /// <summary>
        /// Tests that begin tooltip test
        /// </summary>
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

        /// <summary>
        /// Tests that bullet test
        /// </summary>
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

        /// <summary>
        /// Tests that button test
        /// </summary>
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

        /// <summary>
        /// Tests that calc item width test
        /// </summary>
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

        /// <summary>
        /// Tests that close current popup test
        /// </summary>
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

        /// <summary>
        /// Tests that color button test
        /// </summary>
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

        /// <summary>
        /// Tests that color convert float 4 to u 32 test
        /// </summary>
        [Fact]
        public void ColorConvertFloat4ToU32_Test()
        {
            var col = new Vector4F(0.2f, 0.4f, 0.6f, 1.0f);
            uint result = ImGui.ColorConvertFloat4ToU32(col);
            Assert.NotEqual(0u, result);
        }

        /// <summary>
        /// Tests that color convert hs vto rgb test
        /// </summary>
        [Fact]
        public void ColorConvertHsVtoRgb_Test()
        {
            float r, g, b;
            ImGui.ColorConvertHsVtoRgb(0.5f, 1.0f, 1.0f, out r, out g, out b);
            Assert.InRange(r, 0f, 1f);
            Assert.InRange(g, 0f, 1f);
            Assert.InRange(b, 0f, 1f);
        }

        /// <summary>
        /// Tests that color convert rg bto hsv test
        /// </summary>
        [Fact]
        public void ColorConvertRgBtoHsv_Test()
        {
            float h, s, v;
            ImGui.ColorConvertRgBtoHsv(1.0f, 0.0f, 0.0f, out h, out s, out v);
            Assert.InRange(h, 0f, 360f);
            Assert.InRange(s, 0f, 1f);
            Assert.InRange(v, 0f, 1f);
        }

        /// <summary>
        /// Tests that color convert u 32 to float 4 test
        /// </summary>
        [Fact]
        public void ColorConvertU32ToFloat4_Test()
        {
            Vector4F result = ImGui.ColorConvertU32ToFloat4(0xFF4080C0u);
            Assert.InRange(result.X, 0f, 1f);
            Assert.InRange(result.Y, 0f, 1f);
            Assert.InRange(result.Z, 0f, 1f);
            Assert.InRange(result.W, 0f, 1f);
        }

        /// <summary>
        /// Tests that color edit 4 test
        /// </summary>
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

        /// <summary>
        /// Tests that columns test
        /// </summary>
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
