using System;
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    public class ImGuiCsP1P2RemainingCoverageTests : IDisposable
    {
        internal readonly IntPtr _ctx;

        public ImGuiCsP1P2RemainingCoverageTests()
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
        public void SliderFloat4_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            Vector4F v4 = new Vector4F(0.5f, 0.5f, 0.5f, 0.5f);
            bool result = ImGui.SliderFloat4("slider4", ref v4, 0.0f, 1.0f, "%.3f", ImGuiSliderFlags.None);
            _ = result;
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void SliderInt_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            int val = 5;
            bool r1 = ImGui.SliderInt("s1", ref val, 0, 10);
            _ = r1;
            bool r2 = ImGui.SliderInt("s2", ref val, 0, 10, "%d");
            _ = r2;
            bool r3 = ImGui.SliderInt("s3", ref val, 0, 10, "%d", ImGuiSliderFlags.None);
            _ = r3;
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void SliderInt2_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            int val = 0;
            bool r1 = ImGui.SliderInt2("s1", ref val, 0, 10);
            _ = r1;
            bool r2 = ImGui.SliderInt2("s2", ref val, 0, 10, "%d");
            _ = r2;
            bool r3 = ImGui.SliderInt2("s3", ref val, 0, 10, "%d", ImGuiSliderFlags.None);
            _ = r3;
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void SliderInt3_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            int val = 0;
            bool r1 = ImGui.SliderInt3("s1", ref val, 0, 10);
            _ = r1;
            bool r2 = ImGui.SliderInt3("s2", ref val, 0, 10, "%d");
            _ = r2;
            bool r3 = ImGui.SliderInt3("s3", ref val, 0, 10, "%d", ImGuiSliderFlags.None);
            _ = r3;
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void SliderInt4_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            int val = 0;
            bool r1 = ImGui.SliderInt4("s1", ref val, 0, 10);
            _ = r1;
            bool r2 = ImGui.SliderInt4("s2", ref val, 0, 10, "%d");
            _ = r2;
            bool r3 = ImGui.SliderInt4("s3", ref val, 0, 10, "%d", ImGuiSliderFlags.None);
            _ = r3;
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void SliderScalar_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            int data = 5;
            IntPtr pData = System.Runtime.InteropServices.Marshal.AllocHGlobal(sizeof(int));
            System.Runtime.InteropServices.Marshal.WriteInt32(pData, data);
            IntPtr pMin = System.Runtime.InteropServices.Marshal.AllocHGlobal(sizeof(int));
            System.Runtime.InteropServices.Marshal.WriteInt32(pMin, 0);
            IntPtr pMax = System.Runtime.InteropServices.Marshal.AllocHGlobal(sizeof(int));
            System.Runtime.InteropServices.Marshal.WriteInt32(pMax, 10);
            try
            {
                bool r1 = ImGui.SliderScalar("ss1", ImGuiDataType.S32, pData, pMin, pMax);
                _ = r1;
                bool r2 = ImGui.SliderScalar("ss2", ImGuiDataType.S32, pData, pMin, pMax, "%d");
                _ = r2;
                bool r3 = ImGui.SliderScalar("ss3", ImGuiDataType.S32, pData, pMin, pMax, "%d", ImGuiSliderFlags.None);
                _ = r3;
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.FreeHGlobal(pData);
                System.Runtime.InteropServices.Marshal.FreeHGlobal(pMin);
                System.Runtime.InteropServices.Marshal.FreeHGlobal(pMax);
            }
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void SliderScalarN_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            int[] dataArr = new int[4] { 1, 2, 3, 4 };
            IntPtr pData = System.Runtime.InteropServices.Marshal.AllocHGlobal(sizeof(int) * 4);
            System.Runtime.InteropServices.Marshal.Copy(dataArr, 0, pData, 4);
            IntPtr pMin = System.Runtime.InteropServices.Marshal.AllocHGlobal(sizeof(int));
            System.Runtime.InteropServices.Marshal.WriteInt32(pMin, 0);
            IntPtr pMax = System.Runtime.InteropServices.Marshal.AllocHGlobal(sizeof(int));
            System.Runtime.InteropServices.Marshal.WriteInt32(pMax, 10);
            try
            {
                bool r1 = ImGui.SliderScalarN("ssn1", ImGuiDataType.S32, pData, 4, pMin, pMax);
                _ = r1;
                bool r2 = ImGui.SliderScalarN("ssn2", ImGuiDataType.S32, pData, 4, pMin, pMax, "%d");
                _ = r2;
                bool r3 = ImGui.SliderScalarN("ssn3", ImGuiDataType.S32, pData, 4, pMin, pMax, "%d", ImGuiSliderFlags.None);
                _ = r3;
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.FreeHGlobal(pData);
                System.Runtime.InteropServices.Marshal.FreeHGlobal(pMin);
                System.Runtime.InteropServices.Marshal.FreeHGlobal(pMax);
            }
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void SmallButton_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            bool result = ImGui.SmallButton("small");
            _ = result;
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void Spacing_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            ImGui.Spacing();
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void StyleColorsClassic_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            ImGui.StyleColorsClassic();
            ImGui.StyleColorsClassic(new ImGuiStyle());
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void StyleColorsDark_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            ImGui.StyleColorsDark();
            ImGui.StyleColorsDark(new ImGuiStyle());
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void StyleColorsLight_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            ImGui.StyleColorsLight();
            ImGui.StyleColorsLight(new ImGuiStyle());
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void TabItemButton_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            if (ImGui.BeginTabBar("tabbar"))
            {
                bool r1 = ImGui.TabItemButton("tb1");
                _ = r1;
                bool r2 = ImGui.TabItemButton("tb2", ImGuiTabItemFlags.None);
                _ = r2;
                ImGui.EndTabBar();
            }
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void TableFunctions_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            if (ImGui.BeginTable("table", 2))
            {
                ImGui.TableSetupColumn("Col1");
                ImGui.TableHeadersRow();
                ImGui.TableNextRow();
                ImGui.TableNextRow(ImGuiTableRowFlags.None);
                ImGui.TableNextRow(ImGuiTableRowFlags.None, 0.0f);
                ImGui.TableSetColumnEnabled(0, true);
                bool colSet = ImGui.TableSetColumnIndex(0);
                _ = colSet;
                bool nextCol = ImGui.TableNextColumn();
                _ = nextCol;
                int colCount = ImGui.TableGetColumnCount();
                _ = colCount;
                ImGuiTableColumnFlags colFlags1 = ImGui.TableGetColumnFlags();
                _ = colFlags1;
                ImGuiTableColumnFlags colFlags2 = ImGui.TableGetColumnFlags(0);
                _ = colFlags2;
                int colIdx = ImGui.TableGetColumnIndex();
                _ = colIdx;
                string colName1 = ImGui.TableGetColumnName();
                _ = colName1;
                string colName2 = ImGui.TableGetColumnName(0);
                _ = colName2;
                int rowIdx = ImGui.TableGetRowIndex();
                _ = rowIdx;
                ImGuiTableSortSpecs sortSpecs = ImGui.TableGetSortSpecs();
                _ = sortSpecs;
                ImGui.TableHeader("Header");
                ImGui.TableSetBgColor(ImGuiTableBgTarget.RowBg0, 0xFF0000FFu);
                ImGui.TableSetBgColor(ImGuiTableBgTarget.RowBg1, 0xFF00FF00u, 0);
                ImGui.EndTable();
            }
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void MenuItem_WithEnabled_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            bool result = ImGui.MenuItem("item", true);
            _ = result;
            bool result2 = ImGui.MenuItem("item2", false);
            _ = result2;
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void DockBuilder_AllMethods_ShouldExecute()
        {
            ImGui.NewFrame();
            uint dockId = ImGui.DockSpaceOverViewport();
            ImGui.DockBuilderRemoveNode(dockId);
            ImGui.DockBuilderAddNode(dockId, ImGuiDockNodeFlags.None);
            ImGui.DockBuilderSetNodeSize(dockId, new Vector2F(1920, 1080));
            uint splitId;
            uint rightId = ImGui.DockBuilderSplitNode(dockId, ImGuiDir.Right, 0.5f, null, out splitId);
            _ = rightId;
            ImGui.DockBuilderDockWindow("TestWin", dockId);
            ImGui.DockBuilderSetNodeFlags(dockId, ImGuiDockNodeFlags.None);
            ImGui.DockBuilderFinish(dockId);
            ImGui.Render();
        }

        [Fact]
        public void Combo_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            int currentItem = 0;
            bool r1 = ImGui.Combo("combo1", ref currentItem, "A\0B\0C\0");
            _ = r1;
            bool r2 = ImGui.Combo("combo2", ref currentItem, "A\0B\0C\0", 5);
            _ = r2;
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void CreateContext_WithFontAtlas_ShouldExecute()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr(ImGuiNative.ImFontAtlas_ImFontAtlas());
            IntPtr ctx = ImGui.CreateContext(atlas);
            Assert.NotEqual(IntPtr.Zero, ctx);
            ImGuiNative.igDestroyContext(ctx);
        }

        [Fact]
        public void DebugCheckVersionAndDataLayout_ShouldExecute()
        {
            bool result = ImGui.DebugCheckVersionAndDataLayout(
                ImGui.GetVersion(),
                (uint)System.Runtime.InteropServices.Marshal.SizeOf(typeof(ImGuiIo)),
                (uint)System.Runtime.InteropServices.Marshal.SizeOf(typeof(ImGuiStyle)),
                (uint)System.Runtime.InteropServices.Marshal.SizeOf(typeof(Vector2F)),
                (uint)System.Runtime.InteropServices.Marshal.SizeOf(typeof(Vector4F)),
                (uint)System.Runtime.InteropServices.Marshal.SizeOf(typeof(ImDrawVert)),
                (uint)System.Runtime.InteropServices.Marshal.SizeOf(typeof(ushort)));
            _ = result;
        }

        [Fact]
        public void DebugTextEncoding_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.DebugTextEncoding("test text");
            ImGui.Render();
        }

        [Fact]
        public void DockSpace_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            uint id = ImGui.GetId("MyDockspace");
            uint r1 = ImGui.DockSpace(id);
            _ = r1;
            uint r2 = ImGui.DockSpace(id, new Vector2F(500, 500));
            _ = r2;
            uint r3 = ImGui.DockSpace(id, new Vector2F(500, 500), ImGuiDockNodeFlags.None);
            _ = r3;
            uint r4 = ImGui.DockSpace(id, new Vector2F(500, 500), ImGuiDockNodeFlags.None, new ImGuiWindowClass());
            _ = r4;
            ImGui.Render();
        }

        [Fact]
        public void DockSpaceOverViewport_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            uint r1 = ImGui.DockSpaceOverViewport();
            _ = r1;
            ImGuiViewportPtr viewport = ImGui.GetMainViewport();
            uint r2 = ImGui.DockSpaceOverViewport(viewport);
            _ = r2;
            uint r3 = ImGui.DockSpaceOverViewport(viewport, ImGuiDockNodeFlags.None);
            _ = r3;
            uint r4 = ImGui.DockSpaceOverViewport(viewport, ImGuiDockNodeFlags.None, new ImGuiWindowClass());
            _ = r4;
            ImGui.Render();
        }

        [Fact]
        public void DragFloat_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            float val = 0.5f;
            bool r1 = ImGui.DragFloat("df1", ref val);
            _ = r1;
            bool r2 = ImGui.DragFloat("df2", ref val, 0.01f);
            _ = r2;
            bool r3 = ImGui.DragFloat("df3", ref val, 0.01f, 0.0f);
            _ = r3;
            bool r4 = ImGui.DragFloat("df4", ref val, 0.01f, 0.0f, 1.0f);
            _ = r4;
            bool r5 = ImGui.DragFloat("df5", ref val, 0.01f, 0.0f, 1.0f, "%.3f");
            _ = r5;
            bool r6 = ImGui.DragFloat("df6", ref val, 0.01f, 0.0f, 1.0f, "%.3f", ImGuiSliderFlags.None);
            _ = r6;
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void DragFloat2_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            Vector2F val = new Vector2F(0.5f, 0.5f);
            bool r1 = ImGui.DragFloat2("df1", ref val);
            _ = r1;
            bool r2 = ImGui.DragFloat2("df2", ref val, 0.01f);
            _ = r2;
            bool r3 = ImGui.DragFloat2("df3", ref val, 0.01f, 0.0f);
            _ = r3;
            bool r4 = ImGui.DragFloat2("df4", ref val, 0.01f, 0.0f, 1.0f);
            _ = r4;
            bool r5 = ImGui.DragFloat2("df5", ref val, 0.01f, 0.0f, 1.0f, "%.3f");
            _ = r5;
            bool r6 = ImGui.DragFloat2("df6", ref val, 0.01f, 0.0f, 1.0f, "%.3f", ImGuiSliderFlags.None);
            _ = r6;
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void DragFloat3_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            Vector3F val = new Vector3F(0.5f, 0.5f, 0.5f);
            bool r1 = ImGui.DragFloat3("df1", ref val);
            _ = r1;
            bool r2 = ImGui.DragFloat3("df2", ref val, 0.01f);
            _ = r2;
            bool r3 = ImGui.DragFloat3("df3", ref val, 0.01f, 0.0f);
            _ = r3;
            bool r4 = ImGui.DragFloat3("df4", ref val, 0.01f, 0.0f, 1.0f);
            _ = r4;
            bool r5 = ImGui.DragFloat3("df5", ref val, 0.01f, 0.0f, 1.0f, "%.3f");
            _ = r5;
            bool r6 = ImGui.DragFloat3("df6", ref val, 0.01f, 0.0f, 1.0f, "%.3f", ImGuiSliderFlags.None);
            _ = r6;
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void DragFloat4_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            Vector4F val = new Vector4F(0.5f, 0.5f, 0.5f, 0.5f);
            bool r1 = ImGui.DragFloat4("df1", ref val);
            _ = r1;
            bool r2 = ImGui.DragFloat4("df2", ref val, 0.01f);
            _ = r2;
            bool r3 = ImGui.DragFloat4("df3", ref val, 0.01f, 0.0f);
            _ = r3;
            bool r4 = ImGui.DragFloat4("df4", ref val, 0.01f, 0.0f, 1.0f);
            _ = r4;
            bool r5 = ImGui.DragFloat4("df5", ref val, 0.01f, 0.0f, 1.0f, "%.3f");
            _ = r5;
            bool r6 = ImGui.DragFloat4("df6", ref val, 0.01f, 0.0f, 1.0f, "%.3f", ImGuiSliderFlags.None);
            _ = r6;
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void DragFloatRange2_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            float minVal = 0.0f;
            float maxVal = 1.0f;
            bool r1 = ImGui.DragFloatRange2("dfr1", ref minVal, ref maxVal);
            _ = r1;
            bool r2 = ImGui.DragFloatRange2("dfr2", ref minVal, ref maxVal, 0.01f);
            _ = r2;
            bool r3 = ImGui.DragFloatRange2("dfr3", ref minVal, ref maxVal, 0.01f, 0.0f);
            _ = r3;
            bool r4 = ImGui.DragFloatRange2("dfr4", ref minVal, ref maxVal, 0.01f, 0.0f, 1.0f);
            _ = r4;
            bool r5 = ImGui.DragFloatRange2("dfr5", ref minVal, ref maxVal, 0.01f, 0.0f, 1.0f, "%.3f");
            _ = r5;
            bool r6 = ImGui.DragFloatRange2("dfr6", ref minVal, ref maxVal, 0.01f, 0.0f, 1.0f, "%.3f", "%.3f");
            _ = r6;
            bool r7 = ImGui.DragFloatRange2("dfr7", ref minVal, ref maxVal, 0.01f, 0.0f, 1.0f, "%.3f", "%.3f", ImGuiSliderFlags.None);
            _ = r7;
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void DragInt_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            int val = 5;
            bool r1 = ImGui.DragInt("di1", ref val);
            _ = r1;
            bool r2 = ImGui.DragInt("di2", ref val, 0.5f);
            _ = r2;
            bool r3 = ImGui.DragInt("di3", ref val, 0.5f, 0);
            _ = r3;
            bool r4 = ImGui.DragInt("di4", ref val, 0.5f, 0, 10);
            _ = r4;
            bool r5 = ImGui.DragInt("di5", ref val, 0.5f, 0, 10, "%d");
            _ = r5;
            bool r6 = ImGui.DragInt("di6", ref val, 0.5f, 0, 10, "%d", ImGuiSliderFlags.None);
            _ = r6;
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void DragInt2_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            int val = 0;
            bool r1 = ImGui.DragInt2("di1", ref val);
            _ = r1;
            bool r2 = ImGui.DragInt2("di2", ref val, 1.0f);
            _ = r2;
            bool r3 = ImGui.DragInt2("di3", ref val, 1.0f, 0);
            _ = r3;
            bool r4 = ImGui.DragInt2("di4", ref val, 1.0f, 0, 10);
            _ = r4;
            bool r5 = ImGui.DragInt2("di5", ref val, 1.0f, 0, 10, "%d");
            _ = r5;
            bool r6 = ImGui.DragInt2("di6", ref val, 1.0f, 0, 10, "%d", ImGuiSliderFlags.None);
            _ = r6;
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void DragInt3_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            int val = 0;
            bool r1 = ImGui.DragInt3("di1", ref val);
            _ = r1;
            bool r2 = ImGui.DragInt3("di2", ref val, 1.0f);
            _ = r2;
            bool r3 = ImGui.DragInt3("di3", ref val, 1.0f, 0);
            _ = r3;
            bool r4 = ImGui.DragInt3("di4", ref val, 1.0f, 0, 10);
            _ = r4;
            bool r5 = ImGui.DragInt3("di5", ref val, 1.0f, 0, 10, "%d");
            _ = r5;
            bool r6 = ImGui.DragInt3("di6", ref val, 1.0f, 0, 10, "%d", ImGuiSliderFlags.None);
            _ = r6;
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void DragInt4_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            int val = 0;
            bool r1 = ImGui.DragInt4("di1", ref val);
            _ = r1;
            bool r2 = ImGui.DragInt4("di2", ref val, 1.0f);
            _ = r2;
            bool r3 = ImGui.DragInt4("di3", ref val, 1.0f, 0);
            _ = r3;
            bool r4 = ImGui.DragInt4("di4", ref val, 1.0f, 0, 10);
            _ = r4;
            bool r5 = ImGui.DragInt4("di5", ref val, 1.0f, 0, 10, "%d");
            _ = r5;
            bool r6 = ImGui.DragInt4("di6", ref val, 1.0f, 0, 10, "%d", ImGuiSliderFlags.None);
            _ = r6;
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void DragIntRange2_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            int minVal = 0;
            int maxVal = 10;
            bool r1 = ImGui.DragIntRange2("dir1", ref minVal, ref maxVal);
            _ = r1;
            bool r2 = ImGui.DragIntRange2("dir2", ref minVal, ref maxVal, 1.0f);
            _ = r2;
            bool r3 = ImGui.DragIntRange2("dir3", ref minVal, ref maxVal, 1.0f, 0);
            _ = r3;
            bool r4 = ImGui.DragIntRange2("dir4", ref minVal, ref maxVal, 1.0f, 0, 100);
            _ = r4;
            bool r5 = ImGui.DragIntRange2("dir5", ref minVal, ref maxVal, 1.0f, 0, 100, "%d");
            _ = r5;
            bool r6 = ImGui.DragIntRange2("dir6", ref minVal, ref maxVal, 1.0f, 0, 100, "%d", "%d");
            _ = r6;
            bool r7 = ImGui.DragIntRange2("dir7", ref minVal, ref maxVal, 1.0f, 0, 100, "%d", "%d", ImGuiSliderFlags.None);
            _ = r7;
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void DragScalar_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            int data = 5;
            IntPtr pData = System.Runtime.InteropServices.Marshal.AllocHGlobal(sizeof(int));
            System.Runtime.InteropServices.Marshal.WriteInt32(pData, data);
            IntPtr pMin = System.Runtime.InteropServices.Marshal.AllocHGlobal(sizeof(int));
            System.Runtime.InteropServices.Marshal.WriteInt32(pMin, 0);
            IntPtr pMax = System.Runtime.InteropServices.Marshal.AllocHGlobal(sizeof(int));
            System.Runtime.InteropServices.Marshal.WriteInt32(pMax, 10);
            try
            {
                bool r1 = ImGui.DragScalar("ds1", ImGuiDataType.S32, pData);
                _ = r1;
                bool r2 = ImGui.DragScalar("ds2", ImGuiDataType.S32, pData, 1.0f);
                _ = r2;
                bool r3 = ImGui.DragScalar("ds3", ImGuiDataType.S32, pData, 1.0f, pMin);
                _ = r3;
                bool r4 = ImGui.DragScalar("ds4", ImGuiDataType.S32, pData, 1.0f, pMin, pMax);
                _ = r4;
                bool r5 = ImGui.DragScalar("ds5", ImGuiDataType.S32, pData, 1.0f, pMin, pMax, "%d");
                _ = r5;
                bool r6 = ImGui.DragScalar("ds6", ImGuiDataType.S32, pData, 1.0f, pMin, pMax, "%d", ImGuiSliderFlags.None);
                _ = r6;
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.FreeHGlobal(pData);
                System.Runtime.InteropServices.Marshal.FreeHGlobal(pMin);
                System.Runtime.InteropServices.Marshal.FreeHGlobal(pMax);
            }
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void DragScalarN_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            int[] dataArr = new int[4] { 1, 2, 3, 4 };
            IntPtr pData = System.Runtime.InteropServices.Marshal.AllocHGlobal(sizeof(int) * 4);
            System.Runtime.InteropServices.Marshal.Copy(dataArr, 0, pData, 4);
            IntPtr pMin = System.Runtime.InteropServices.Marshal.AllocHGlobal(sizeof(int));
            System.Runtime.InteropServices.Marshal.WriteInt32(pMin, 0);
            try
            {
                bool r1 = ImGui.DragScalarN("dsn1", ImGuiDataType.S32, pData, 4);
                _ = r1;
                bool r2 = ImGui.DragScalarN("dsn2", ImGuiDataType.S32, pData, 4, 1.0f);
                _ = r2;
                bool r3 = ImGui.DragScalarN("dsn3", ImGuiDataType.S32, pData, 4, 1.0f, pMin);
                _ = r3;
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.FreeHGlobal(pData);
                System.Runtime.InteropServices.Marshal.FreeHGlobal(pMin);
            }
            ImGui.End();
            ImGui.Render();
        }
    }
}
