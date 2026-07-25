using System;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Ui.Test.Attributes;
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
        internal readonly IntPtr _ctx;

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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
        public void ColorConvertFloat4ToU32_Test()
        {
            var col = new Vector4F(0.2f, 0.4f, 0.6f, 1.0f);
            uint result = ImGui.ColorConvertFloat4ToU32(col);
            Assert.NotEqual(0u, result);
        }

        /// <summary>
        /// Tests that color convert hs vto rgb test
        /// </summary>
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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

        /// <summary>
        /// Tests that accept drag drop payload test
        /// </summary>
        [RequireCImguiSystemFact]
        public void AcceptDragDropPayload_Test()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            ImGui.Button("source");
            if (ImGui.BeginDragDropSource())
            {
                _ = ImGui.SetDragDropPayload("test_type", IntPtr.Zero, 0u, ImGuiCond.None);
                ImGui.EndDragDropSource();
            }
            if (ImGui.BeginDragDropTarget())
            {
                _ = ImGui.AcceptDragDropPayload("test_type");
                ImGui.EndDragDropTarget();
            }
            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that accept drag drop payload with flags test
        /// </summary>
        [RequireCImguiSystemFact]
        public void AcceptDragDropPayload_WithFlags_Test()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            ImGui.Button("source2");
            if (ImGui.BeginDragDropSource())
            {
                _ = ImGui.SetDragDropPayload("test_type2", IntPtr.Zero, 0u, ImGuiCond.None);
                ImGui.EndDragDropSource();
            }
            if (ImGui.BeginDragDropTarget())
            {
                _ = ImGui.AcceptDragDropPayload("test_type2", ImGuiDragDropFlags.None);
                ImGui.EndDragDropTarget();
            }
            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that begin popup test
        /// </summary>
        [RequireCImguiSystemFact]
        public void BeginPopup_Test()
        {
            ImGui.NewFrame();
            if (ImGui.BeginPopup("popup1"))
            {
                ImGui.EndPopup();
            }
            if (ImGui.BeginPopup("popup2", ImGuiWindowFlags.None))
            {
                ImGui.EndPopup();
            }
            ImGui.Render();
        }

        /// <summary>
        /// Tests that begin popup modal test
        /// </summary>
        [RequireCImguiSystemFact]
        public void BeginPopupModal_Test()
        {
            ImGui.NewFrame();
            ImGui.OpenPopup("modal1");
            if (ImGui.BeginPopupModal("modal1"))
            {
                ImGui.CloseCurrentPopup();
                ImGui.EndPopup();
            }
            ImGui.Render();
        }

        /// <summary>
        /// Tests that begin popup modal with ref bool test
        /// </summary>
        [RequireCImguiSystemFact]
        public void BeginPopupModal_RefBool_Test()
        {
            ImGui.NewFrame();
            bool open = true;
            ImGui.OpenPopup("modal2");
            if (ImGui.BeginPopupModal("modal2", ref open))
            {
                ImGui.CloseCurrentPopup();
                ImGui.EndPopup();
            }
            ImGui.Render();
        }

        /// <summary>
        /// Tests that begin popup modal with flags test
        /// </summary>
        [RequireCImguiSystemFact]
        public void BeginPopupModal_Flags_Test()
        {
            ImGui.NewFrame();
            bool open = true;
            ImGui.OpenPopup("modal3");
            if (ImGui.BeginPopupModal("modal3", ref open, ImGuiWindowFlags.None))
            {
                ImGui.CloseCurrentPopup();
                ImGui.EndPopup();
            }
            ImGui.Render();
        }

        /// <summary>
        /// Tests that begin tab item test
        /// </summary>
        [RequireCImguiSystemFact]
        public void BeginTabItem_Test()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            if (ImGui.BeginTabBar("tb"))
            {
                if (ImGui.BeginTabItem("ti1"))
                {
                    ImGui.EndTabItem();
                }
                bool open = true;
                if (ImGui.BeginTabItem("ti2", ref open))
                {
                    ImGui.EndTabItem();
                }
                if (ImGui.BeginTabItem("ti3", ref open, ImGuiTabItemFlags.None))
                {
                    ImGui.EndTabItem();
                }
                ImGui.EndTabBar();
            }
            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that checkbox test
        /// </summary>
        [RequireCImguiSystemFact]
        public void Checkbox_Test()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            bool value = true;
            ImGui.Checkbox("cb1", ref value);
            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that checkbox flags int test
        /// </summary>
        [RequireCImguiSystemFact]
        public void CheckboxFlags_Int_Test()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            int flags = 1;
            ImGui.CheckboxFlags("cf1", ref flags, 1);
            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that checkbox flags uint test
        /// </summary>
        [RequireCImguiSystemFact]
        public void CheckboxFlags_Uint_Test()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            uint flags = 1u;
            ImGui.CheckboxFlags("cf2", ref flags, 1u);
            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that collapsing header test
        /// </summary>
        [RequireCImguiSystemFact]
        public void CollapsingHeader_Test()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            ImGui.CollapsingHeader("ch1");
            ImGui.CollapsingHeader("ch2", ImGuiTreeNodeFlags.None);
            bool visible = true;
            ImGui.CollapsingHeader("ch3", ref visible);
            ImGui.CollapsingHeader("ch4", ref visible, ImGuiTreeNodeFlags.None);
            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that color edit 3 test
        /// </summary>
        [RequireCImguiSystemFact]
        public void ColorEdit3_Test()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            var col = new Vector3F(0.2f, 0.4f, 0.6f);
            ImGui.ColorEdit3("ce3", ref col);
            ImGui.ColorEdit3("ce3b", ref col, ImGuiColorEditFlags.None);
            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that color picker 3 test
        /// </summary>
        [RequireCImguiSystemFact]
        public void ColorPicker3_Test()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            var col = new Vector3F(0.2f, 0.4f, 0.6f);
            ImGui.ColorPicker3("cp3", ref col);
            ImGui.ColorPicker3("cp3b", ref col, ImGuiColorEditFlags.None);
            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that color picker 4 test
        /// </summary>
        [RequireCImguiSystemFact]
        public void ColorPicker4_Test()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            var col = new Vector4F(0.2f, 0.4f, 0.6f, 1.0f);
            ImGui.ColorPicker4("cp4", ref col);
            ImGui.ColorPicker4("cp4b", ref col, ImGuiColorEditFlags.None);
            float refCol = 0.5f;
            ImGui.ColorPicker4("cp4c", ref col, ImGuiColorEditFlags.None, ref refCol);
            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that combo test
        /// </summary>
        [RequireCImguiSystemFact]
        public void Combo_Test()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            int current = 0;
            string[] items = { "A", "B", "C" };
            ImGui.Combo("co1", ref current, items, items.Length);
            ImGui.Combo("co2", ref current, items, items.Length, -1);
            ImGui.End();
            ImGui.Render();
        }
    }
}
