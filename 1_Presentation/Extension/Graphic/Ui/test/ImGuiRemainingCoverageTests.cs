using System;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    public class ImGuiRemainingCoverageTests : IDisposable
    {
        private readonly IntPtr _ctx;

        public ImGuiRemainingCoverageTests()
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

        [RequireCImguiSystemFact]
        public void SliderInt_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            int v = 0;
            ImGui.SliderInt("s1", ref v, 0, 100);
            ImGui.SliderInt("s2", ref v, 0, 100, "%d");
            ImGui.SliderInt("s3", ref v, 0, 100, "%d", ImGuiSliderFlags.None);
            ImGui.End();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void SliderInt2_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            int v = 0;
            ImGui.SliderInt2("s1", ref v, 0, 100);
            ImGui.SliderInt2("s2", ref v, 0, 100, "%d");
            ImGui.SliderInt2("s3", ref v, 0, 100, "%d", ImGuiSliderFlags.None);
            ImGui.End();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void SliderInt3_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            int v = 0;
            ImGui.SliderInt3("s1", ref v, 0, 100);
            ImGui.SliderInt3("s2", ref v, 0, 100, "%d");
            ImGui.SliderInt3("s3", ref v, 0, 100, "%d", ImGuiSliderFlags.None);
            ImGui.End();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void SliderInt4_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            int v = 0;
            ImGui.SliderInt4("s1", ref v, 0, 100);
            ImGui.SliderInt4("s2", ref v, 0, 100, "%d");
            ImGui.SliderInt4("s3", ref v, 0, 100, "%d", ImGuiSliderFlags.None);
            ImGui.End();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void SmallButton_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            ImGui.SmallButton("sb1");
            ImGui.End();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void Spacing_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            ImGui.Spacing();
            ImGui.End();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void StyleColorsClassic_AllOverloads_ShouldExecute()
        {
            ImGui.StyleColorsClassic();
            var style = new ImGuiStyle();
            ImGui.StyleColorsClassic(style);
        }

        [RequireCImguiSystemFact]
        public void StyleColorsDark_AllOverloads_ShouldExecute()
        {
            ImGui.StyleColorsDark();
            var style = new ImGuiStyle();
            ImGui.StyleColorsDark(style);
        }

        [RequireCImguiSystemFact]
        public void StyleColorsLight_AllOverloads_ShouldExecute()
        {
            ImGui.StyleColorsLight();
            var style = new ImGuiStyle();
            ImGui.StyleColorsLight(style);
        }

        [RequireCImguiSystemFact]
        public void TabItemButton_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            if (ImGui.BeginTabBar("tb"))
            {
                ImGui.TabItemButton("t1");
                ImGui.TabItemButton("t2", ImGuiTabItemFlags.None);
                ImGui.EndTabBar();
            }
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void TableGetColumnCount_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            if (ImGui.BeginTable("t", 2))
            {
                int count = ImGui.TableGetColumnCount();
                _ = count;
                ImGui.EndTable();
            }
            ImGui.End();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void TableGetColumnFlags_WithIndex_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            if (ImGui.BeginTable("t", 2))
            {
                ImGui.TableSetupColumn("A");
                ImGui.TableSetupColumn("B");
                ImGui.TableHeadersRow();
                ImGui.TableNextRow();
                ImGui.TableNextColumn();
                ImGui.TableGetColumnFlags(0);
                ImGui.EndTable();
            }
            ImGui.End();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void TableGetColumnIndex_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            if (ImGui.BeginTable("t", 2))
            {
                int idx = ImGui.TableGetColumnIndex();
                _ = idx;
                ImGui.EndTable();
            }
            ImGui.End();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void TableGetRowIndex_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            if (ImGui.BeginTable("t", 2))
            {
                int idx = ImGui.TableGetRowIndex();
                _ = idx;
                ImGui.EndTable();
            }
            ImGui.End();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void TableGetSortSpecs_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            if (ImGui.BeginTable("t", 2, ImGuiTableFlags.Sortable))
            {
                ImGuiTableSortSpecs specs = ImGui.TableGetSortSpecs();
                _ = specs;
                ImGui.EndTable();
            }
            ImGui.End();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void TableHeader_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            if (ImGui.BeginTable("t", 2))
            {
                ImGui.TableSetupColumn("Col1");
                ImGui.TableHeadersRow();
                ImGui.TableNextRow();
                ImGui.TableNextColumn();
                ImGui.TableHeader("Header1");
                ImGui.EndTable();
            }
            ImGui.End();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void TableHeadersRow_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            if (ImGui.BeginTable("t", 2))
            {
                ImGui.TableSetupColumn("A");
                ImGui.TableSetupColumn("B");
                ImGui.TableHeadersRow();
                ImGui.EndTable();
            }
            ImGui.End();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void TableNextColumn_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            if (ImGui.BeginTable("t", 2))
            {
                ImGui.TableNextColumn();
                ImGui.TableNextColumn();
                ImGui.EndTable();
            }
            ImGui.End();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void TableNextRow_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            if (ImGui.BeginTable("t", 2))
            {
                ImGui.TableSetupColumn("A");
                ImGui.TableNextRow();
                ImGui.TableNextRow(ImGuiTableRowFlags.None);
                ImGui.TableNextRow(ImGuiTableRowFlags.None, 0.0f);
                ImGui.EndTable();
            }
            ImGui.End();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void TableSetBgColor_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            if (ImGui.BeginTable("t", 2))
            {
                ImGui.TableSetupColumn("A");
                ImGui.TableNextRow();
                ImGui.TableNextColumn();
                ImGui.TableSetBgColor(ImGuiTableBgTarget.RowBg0, 0xFF0000FF);
                ImGui.TableSetBgColor(ImGuiTableBgTarget.RowBg0, 0xFF0000FF, -1);
                ImGui.EndTable();
            }
            ImGui.End();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void TableSetColumnEnabled_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            if (ImGui.BeginTable("t", 2, ImGuiTableFlags.Hideable))
            {
                ImGui.TableSetupColumn("A");
                ImGui.TableSetupColumn("B");
                ImGui.TableHeadersRow();
                ImGui.TableSetColumnEnabled(0, true);
                ImGui.EndTable();
            }
            ImGui.End();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void TableSetColumnIndex_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            if (ImGui.BeginTable("t", 2))
            {
                ImGui.TableSetupColumn("A");
                ImGui.TableSetupColumn("B");
                ImGui.TableHeadersRow();
                ImGui.TableNextRow();
                ImGui.TableSetColumnIndex(0);
                ImGui.EndTable();
            }
            ImGui.End();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void TableSetupColumn_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            if (ImGui.BeginTable("t", 2))
            {
                ImGui.TableSetupColumn("Col1");
                ImGui.TableSetupColumn("Col2");
                ImGui.EndTable();
            }
            ImGui.End();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void MenuItem_WithEnabled_ShouldExecute()
        {
            ImGui.NewFrame();
            if (ImGui.BeginMainMenuBar())
            {
                if (ImGui.BeginMenu("File"))
                {
                    bool r1 = ImGui.MenuItem("Open", true);
                    bool r2 = ImGui.MenuItem("Disabled", false);
                    _ = r1;
                    _ = r2;
                    ImGui.EndMenu();
                }
                ImGui.EndMainMenuBar();
            }
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void ImFontConfig_ShouldExecute()
        {
            ImFontConfigPtr ptr = ImGui.ImFontConfig();
            _ = ptr;
        }

        [RequireCImguiSystemFact]
        public void DockBuilder_Basic_Chain_ShouldExecute()
        {
            ImGui.NewFrame();
            uint dockId = ImGui.DockSpaceOverViewport();

            ImGui.DockBuilderRemoveNode(dockId);
            ImGui.DockBuilderAddNode(dockId, ImGuiDockNodeFlags.None);
            ImGui.DockBuilderSetNodeSize(dockId, new Vector2F(800, 600));

            uint dockRight;
            uint dockLeft = ImGui.DockBuilderSplitNode(dockId, ImGuiDir.Left, 0.3f, null, out dockRight);
            _ = dockLeft;
            _ = dockRight;

            ImGui.DockBuilderDockWindow("Scene", dockLeft);
            ImGui.DockBuilderDockWindow("Inspector", dockRight);
            ImGui.DockBuilderFinish(dockId);
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void DockBuilderSetNodeFlags_ShouldBlock()
        {
            ImGui.NewFrame();
            uint dockId = ImGui.DockSpaceOverViewport();
            ImGui.DockBuilderAddNode(dockId, ImGuiDockNodeFlags.None);
            Assert.Throws<EntryPointNotFoundException>(() =>
                ImGui.DockBuilderSetNodeFlags(dockId, ImGuiDockNodeFlags.None));
            ImGui.Render();
        }
    }
}
