using System;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// Coverage for methods in ImGuiP4, ImGuiP6 (not yet covered), and ImGuiP8.
    /// </summary>
    /// <seealso cref="IDisposable" />
    public class ImGuiP4P6P8RemainingCoverageTests : IDisposable
    {
        /// <summary>
        /// The context
        /// </summary>
        internal readonly IntPtr _ctx;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImGuiP4P6P8RemainingCoverageTests"/> class
        /// </summary>
        public ImGuiP4P6P8RemainingCoverageTests()
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

        // ========== P4: TableSetupColumn (3 overloads) ==========

        /// <summary>
        /// Tests that table setup column all overloads execute
        /// </summary>
        [Fact]
        public void TableSetupColumn_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            if (ImGui.BeginTable("tbl", 3))
            {
                ImGui.TableSetupColumn("Col1", ImGuiTableColumnFlags.None);
                ImGui.TableSetupColumn("Col2", ImGuiTableColumnFlags.None, 100.0f);
                ImGui.TableSetupColumn("Col3", ImGuiTableColumnFlags.None, 100.0f, 1u);
                ImGui.EndTable();
            }
            ImGui.End();
            ImGui.Render();
        }

        // ========== P4: TableSetupScrollFreeze ==========

        /// <summary>
        /// Tests that table setup scroll freeze executes
        /// </summary>
        [Fact]
        public void TableSetupScrollFreeze_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            if (ImGui.BeginTable("tbl", 3))
            {
                ImGui.TableSetupScrollFreeze(1, 1);
                ImGui.EndTable();
            }
            ImGui.End();
            ImGui.Render();
        }

        // ========== P4: Text variants ==========

        /// <summary>
        /// Tests that text variants execute
        /// </summary>
        [Fact]
        public void TextVariants_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            ImGui.Text("Hello");
            ImGui.TextColored(new Vector4F(1f, 0f, 0f, 1f), "Red");
            ImGui.TextDisabled("Disabled");
            ImGui.TextUnformatted("Unformatted");
            ImGui.TextWrapped("Wrapped text that should wrap around");
            ImGui.End();
            ImGui.Render();
        }

        // ========== P4: TreeNode (3 overloads) ==========

        /// <summary>
        /// Tests that tree node all overloads execute
        /// </summary>
        [Fact]
        public void TreeNode_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            bool r1 = ImGui.TreeNode("node1");
            if (r1) ImGui.TreePop();
            bool r2 = ImGui.TreeNode("node2", "label");
            if (r2) ImGui.TreePop();
            IntPtr ptrId = new IntPtr(42);
            bool r3 = ImGui.TreeNode(ptrId, "ptr node");
            if (r3) ImGui.TreePop();
            _ = r1; _ = r2; _ = r3;
            ImGui.End();
            ImGui.Render();
        }

        // ========== P4: TreeNodeEx (4 overloads) ==========

        /// <summary>
        /// Tests that tree node ex all overloads execute
        /// </summary>
        [Fact]
        public void TreeNodeEx_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            bool r1 = ImGui.TreeNodeEx("ex1");
            if (r1) ImGui.TreePop();
            bool r2 = ImGui.TreeNodeEx("ex2", ImGuiTreeNodeFlags.None);
            if (r2) ImGui.TreePop();
            bool r3 = ImGui.TreeNodeEx("ex3", ImGuiTreeNodeFlags.None, "ex3 label");
            if (r3) ImGui.TreePop();
            IntPtr ptrId = new IntPtr(42);
            bool r4 = ImGui.TreeNodeEx(ptrId, ImGuiTreeNodeFlags.None, "ptr ex");
            if (r4) ImGui.TreePop();
            _ = r1; _ = r2; _ = r3; _ = r4;
            ImGui.End();
            ImGui.Render();
        }

        // ========== P4: TreePush (2 overloads) + TreePop ==========

        /// <summary>
        /// Tests that tree push all overloads and tree pop execute
        /// </summary>
        [Fact]
        public void TreePush_AllOverloads_And_TreePop_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            bool r = ImGui.TreeNode("root");
            if (r)
            {
                ImGui.TreePush("child1");
                ImGui.TreePop();
                IntPtr ptr = new IntPtr(1);
                ImGui.TreePush(ptr);
                ImGui.TreePop();
                ImGui.TreePop();
            }
            _ = r;
            ImGui.End();
            ImGui.Render();
        }

        // ========== P4: Unindent (2 overloads) ==========

        /// <summary>
        /// Tests that unindent all overloads execute
        /// </summary>
        [Fact]
        public void Unindent_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            ImGui.Indent();
            ImGui.Unindent();
            ImGui.Indent(20f);
            ImGui.Unindent(20f);
            ImGui.End();
            ImGui.Render();
        }

        // ========== P4: UpdatePlatformWindows ==========

        /// <summary>
        /// Tests that update platform windows executes without exception
        /// </summary>
        [Fact]
        public void UpdatePlatformWindows_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Render();
            ImGui.UpdatePlatformWindows();
        }

        // ========== P4: Value (5 overloads) ==========

        /// <summary>
        /// Tests that value all overloads execute
        /// </summary>
        [Fact]
        public void Value_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            ImGui.Value("bool", true);
            ImGui.Value("int", 42);
            ImGui.Value("uint", 123u);
            ImGui.Value("float", 3.14f);
            ImGui.Value("float_fmt", 3.14f, "%.2f");
            ImGui.End();
            ImGui.Render();
        }

        // ========== P4: VSliderFloat (3 overloads) ==========

        /// <summary>
        /// Tests that v slider float all overloads execute
        /// </summary>
        [Fact]
        public void VSliderFloat_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            float val = 0.5f;
            var size = new Vector2F(20f, 100f);
            bool r1 = ImGui.VSliderFloat("vsf1", size, ref val, 0f, 1f);
            bool r2 = ImGui.VSliderFloat("vsf2", size, ref val, 0f, 1f, "%.3f");
            bool r3 = ImGui.VSliderFloat("vsf3", size, ref val, 0f, 1f, "%.3f", ImGuiSliderFlags.None);
            _ = r1; _ = r2; _ = r3;
            ImGui.End();
            ImGui.Render();
        }

        // ========== P4: VSliderInt (3 overloads) ==========

        /// <summary>
        /// Tests that v slider int all overloads execute
        /// </summary>
        [Fact]
        public void VSliderInt_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            int val = 5;
            var size = new Vector2F(20f, 100f);
            bool r1 = ImGui.VSliderInt("vsi1", size, ref val, 0, 10);
            bool r2 = ImGui.VSliderInt("vsi2", size, ref val, 0, 10, "%d");
            bool r3 = ImGui.VSliderInt("vsi3", size, ref val, 0, 10, "%d", ImGuiSliderFlags.None);
            _ = r1; _ = r2; _ = r3;
            ImGui.End();
            ImGui.Render();
        }

        // ========== P4: VSliderScalar (3 overloads) ==========

        /// <summary>
        /// Tests that v slider scalar all overloads execute
        /// </summary>
        [Fact]
        public void VSliderScalar_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            int data = 5;
            IntPtr pData = Marshal.AllocHGlobal(sizeof(int));
            Marshal.WriteInt32(pData, data);
            IntPtr pMin = Marshal.AllocHGlobal(sizeof(int));
            Marshal.WriteInt32(pMin, 0);
            IntPtr pMax = Marshal.AllocHGlobal(sizeof(int));
            Marshal.WriteInt32(pMax, 10);
            var size = new Vector2F(20f, 100f);
            try
            {
                bool r1 = ImGui.VSliderScalar("vss1", size, ImGuiDataType.S32, pData, pMin, pMax);
                bool r2 = ImGui.VSliderScalar("vss2", size, ImGuiDataType.S32, pData, pMin, pMax, "%d");
                bool r3 = ImGui.VSliderScalar("vss3", size, ImGuiDataType.S32, pData, pMin, pMax, "%d", ImGuiSliderFlags.None);
                _ = r1; _ = r2; _ = r3;
            }
            finally
            {
                Marshal.FreeHGlobal(pData);
                Marshal.FreeHGlobal(pMin);
                Marshal.FreeHGlobal(pMax);
            }
            ImGui.End();
            ImGui.Render();
        }

        // ========== P4: InputText with byte[] buf (4 overloads) ==========

        /// <summary>
        /// Tests that input text with byte array buf all overloads execute
        /// </summary>
        [Fact]
        public void InputText_ByteArrayBuf_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            byte[] buf = new byte[256];
            bool r1 = ImGui.InputText("it1", buf, 256);
            bool r2 = ImGui.InputText("it2", buf, 256, ImGuiInputTextFlags.None);
            bool r3 = ImGui.InputText("it3", buf, 256, ImGuiInputTextFlags.None, null);
            bool r4 = ImGui.InputText("it4", buf, 256, ImGuiInputTextFlags.None, null, IntPtr.Zero);
            _ = r1; _ = r2; _ = r3; _ = r4;
            ImGui.End();
            ImGui.Render();
        }

        // ========== P4: InputText with ref string (4 overloads) ==========

        /// <summary>
        /// Tests that input text with string reference all overloads execute
        /// </summary>
        [Fact]
        public void InputText_StringRef_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            string text = "hello";
            bool r1 = ImGui.InputText("its1", ref text, 256);
            bool r2 = ImGui.InputText("its2", ref text, 256, ImGuiInputTextFlags.None);
            bool r3 = ImGui.InputText("its3", ref text, 256, ImGuiInputTextFlags.None, null);
            bool r4 = ImGui.InputText("its4", ref text, 256, ImGuiInputTextFlags.None, null, IntPtr.Zero);
            _ = r1; _ = r2; _ = r3; _ = r4;
            ImGui.End();
            ImGui.Render();
        }

        // ========== P4: InputText with IntPtr buf (4 overloads) ==========

        /// <summary>
        /// Tests that input text with int pointer buf all overloads execute
        /// </summary>
        [Fact]
        public void InputText_IntPtrBuf_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            IntPtr buf = Marshal.AllocHGlobal(256);
            try
            {
                bool r1 = ImGui.InputText("itp1", buf, 256);
                bool r2 = ImGui.InputText("itp2", buf, 256, ImGuiInputTextFlags.None);
                bool r3 = ImGui.InputText("itp3", buf, 256, ImGuiInputTextFlags.None, null);
                bool r4 = ImGui.InputText("itp4", buf, 256, ImGuiInputTextFlags.None, null, IntPtr.Zero);
                _ = r1; _ = r2; _ = r3; _ = r4;
            }
            finally
            {
                Marshal.FreeHGlobal(buf);
            }
            ImGui.End();
            ImGui.Render();
        }

        // ========== P4: InputTextMultiline (4 overloads) ==========

        /// <summary>
        /// Tests that input text multiline all overloads execute
        /// </summary>
        [Fact]
        public void InputTextMultiline_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            string text = "multi\nline";
            var size = new Vector2F(200f, 100f);
            bool r1 = ImGui.InputTextMultiline("itm1", ref text, 1024, size);
            bool r2 = ImGui.InputTextMultiline("itm2", ref text, 1024, size, ImGuiInputTextFlags.None);
            bool r3 = ImGui.InputTextMultiline("itm3", ref text, 1024, size, ImGuiInputTextFlags.None, null);
            bool r4 = ImGui.InputTextMultiline("itm4", ref text, 1024, size, ImGuiInputTextFlags.None, null, IntPtr.Zero);
            _ = r1; _ = r2; _ = r3; _ = r4;
            ImGui.End();
            ImGui.Render();
        }

        // ========== P4: InputTextWithHint (4 overloads) ==========

        /// <summary>
        /// Tests that input text with hint all overloads execute
        /// </summary>
        [Fact]
        public void InputTextWithHint_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            string text = "";
            bool r1 = ImGui.InputTextWithHint("ith1", "Enter text", text, 256);
            bool r2 = ImGui.InputTextWithHint("ith2", "Enter text", text, 256, ImGuiInputTextFlags.None);
            bool r3 = ImGui.InputTextWithHint("ith3", "Enter text", text, 256, ImGuiInputTextFlags.None, null);
            bool r4 = ImGui.InputTextWithHint("ith4", "Enter text", text, 256, ImGuiInputTextFlags.None, null, IntPtr.Zero);
            _ = r1; _ = r2; _ = r3; _ = r4;
            ImGui.End();
            ImGui.Render();
        }

        // ========== P4: CalcTextSize (representative overloads) ==========

        /// <summary>
        /// Tests that calc text size representative overloads execute
        /// </summary>
        [Fact]
        public void CalcTextSize_ShouldExecute()
        {
            Vector2F r1 = ImGui.CalcTextSize("Hello");
            Vector2F r2 = ImGui.CalcTextSize("Hello", 0);
            Vector2F r3 = ImGui.CalcTextSize("Hello", true);
            Vector2F r4 = ImGui.CalcTextSize("Hello", 0f);
            Vector2F r5 = ImGui.CalcTextSize("Hello", 0, 5);
            Vector2F r6 = ImGui.CalcTextSize("Hello", true, 200f);
            Vector2F r7 = ImGui.CalcTextSize("Hello", 0, 5, true);
            Vector2F r8 = ImGui.CalcTextSize("Hello", 0, 5, 200f);
            Vector2F r9 = ImGui.CalcTextSize("Hello", 0, 5, true, 200f);
            _ = r1; _ = r2; _ = r3; _ = r4; _ = r5; _ = r6; _ = r7; _ = r8; _ = r9;
        }

        // ========== P4: Begin with ImGuiWindowFlags ==========

        /// <summary>
        /// Tests that begin with window flags executes
        /// </summary>
        [Fact]
        public void Begin_WithWindowFlags_ShouldExecute()
        {
            ImGui.NewFrame();
            bool result = ImGui.Begin("TestFlags", ImGuiWindowFlags.None);
            ImGui.End();
            ImGui.Render();
            _ = result;
        }

        // ========== P6: InputInt3 (2 overloads - not covered elsewhere) ==========

        /// <summary>
        /// Tests that input int 3 all overloads execute
        /// </summary>
        [Fact]
        public void InputInt3_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            int val = 0;
            bool r1 = ImGui.InputInt3("i3a", ref val);
            bool r2 = ImGui.InputInt3("i3b", ref val, ImGuiInputTextFlags.None);
            _ = r1; _ = r2;
            ImGui.End();
            ImGui.Render();
        }

        // ========== P6: ListBox (2 overloads - not covered elsewhere) ==========

        /// <summary>
        /// Tests that list box all overloads execute
        /// </summary>
        [Fact]
        public void ListBox_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            int current = 0;
            string[] items = { "A", "B", "C" };
            bool r1 = ImGui.ListBox("lb1", ref current, items, items.Length);
            bool r2 = ImGui.ListBox("lb2", ref current, items, items.Length, 3);
            _ = r1; _ = r2;
            ImGui.End();
            ImGui.Render();
        }

        // ========== P6: LoadIniSettingsFromDisk (not covered elsewhere) ==========

        /// <summary>
        /// Tests that load ini settings from disk executes
        /// </summary>
        [Fact]
        public void LoadIniSettingsFromDisk_ShouldExecute()
        {
            ImGui.LoadIniSettingsFromDisk("test.ini");
        }

        // ========== P6: LogToFile (3 overloads - not covered elsewhere) ==========

        /// <summary>
        /// Tests that log to file all overloads execute
        /// </summary>
        [Fact]
        public void LogToFile_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.LogToFile();
            ImGui.LogFinish();
            ImGui.Render();
            ImGui.NewFrame();
            ImGui.LogToFile(-1);
            ImGui.LogFinish();
            ImGui.Render();
            ImGui.NewFrame();
            ImGui.LogToFile(-1, "test_log.txt");
            ImGui.LogFinish();
            ImGui.Render();
        }

        // ========== P8: ShowAboutWindow (2 overloads) ==========

        /// <summary>
        /// Tests that show about window all overloads execute
        /// </summary>
        [Fact]
        public void ShowAboutWindow_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.ShowAboutWindow();
            bool isOpen = true;
            ImGui.ShowAboutWindow(ref isOpen);
            ImGui.Render();
        }

        // ========== P8: ShowDebugLogWindow (2 overloads) ==========

        /// <summary>
        /// Tests that show debug log window all overloads execute
        /// </summary>
        [Fact]
        public void ShowDebugLogWindow_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.ShowDebugLogWindow();
            bool isOpen = true;
            ImGui.ShowDebugLogWindow(ref isOpen);
            ImGui.Render();
        }

        // ========== P8: ShowDemoWindow (2 overloads) ==========

        /// <summary>
        /// Tests that show demo window all overloads execute
        /// </summary>
        [Fact]
        public void ShowDemoWindow_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.ShowDemoWindow();
            bool isOpen = true;
            ImGui.ShowDemoWindow(ref isOpen);
            ImGui.Render();
        }

        // ========== P8: ShowMetricsWindow (2 overloads) ==========

        /// <summary>
        /// Tests that show metrics window all overloads execute
        /// </summary>
        [Fact]
        public void ShowMetricsWindow_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.ShowMetricsWindow();
            bool isOpen = true;
            ImGui.ShowMetricsWindow(ref isOpen);
            ImGui.Render();
        }

        // ========== P8: ShowStyleEditor (2 overloads) ==========

        /// <summary>
        /// Tests that show style editor all overloads execute
        /// </summary>
        [Fact]
        public void ShowStyleEditor_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.ShowStyleEditor();
            ImGui.ShowStyleEditor(new ImGuiStyle());
            ImGui.Render();
        }

        // ========== P8: ShowFontSelector ==========

        /// <summary>
        /// Tests that show font selector executes
        /// </summary>
        [Fact]
        public void ShowFontSelector_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            ImGui.ShowFontSelector("font");
            ImGui.End();
            ImGui.Render();
        }

        // ========== P8: ShowStackToolWindow (2 overloads) ==========

        /// <summary>
        /// Tests that show stack tool window all overloads execute
        /// </summary>
        [Fact]
        public void ShowStackToolWindow_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.ShowStackToolWindow();
            bool isOpen = true;
            ImGui.ShowStackToolWindow(ref isOpen);
            ImGui.Render();
        }

        // ========== P8: ShowStyleSelector ==========

        /// <summary>
        /// Tests that show style selector executes
        /// </summary>
        [Fact]
        public void ShowStyleSelector_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            bool result = ImGui.ShowStyleSelector("style_sel");
            _ = result;
            ImGui.End();
            ImGui.Render();
        }

        // ========== P8: ShowUserGuide ==========

        /// <summary>
        /// Tests that show user guide executes
        /// </summary>
        [Fact]
        public void ShowUserGuide_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.ShowUserGuide();
            ImGui.Render();
        }

        // ========== P8: SliderAngle (5 overloads) ==========

        /// <summary>
        /// Tests that slider angle all overloads execute
        /// </summary>
        [Fact]
        public void SliderAngle_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            float rad = 0.5f;
            bool r1 = ImGui.SliderAngle("sa1", ref rad);
            bool r2 = ImGui.SliderAngle("sa2", ref rad, -180f);
            bool r3 = ImGui.SliderAngle("sa3", ref rad, -180f, 180f);
            bool r4 = ImGui.SliderAngle("sa4", ref rad, -180f, 180f, "%.1f deg");
            bool r5 = ImGui.SliderAngle("sa5", ref rad, -180f, 180f, "%.1f deg", ImGuiSliderFlags.None);
            _ = r1; _ = r2; _ = r3; _ = r4; _ = r5;
            ImGui.End();
            ImGui.Render();
        }

        // ========== P8: SliderFloat (3 overloads) ==========

        /// <summary>
        /// Tests that slider float all overloads execute
        /// </summary>
        [Fact]
        public void SliderFloat_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            float val = 0.5f;
            bool r1 = ImGui.SliderFloat("sf1", ref val, 0f, 1f);
            bool r2 = ImGui.SliderFloat("sf2", ref val, 0f, 1f, "%.3f");
            bool r3 = ImGui.SliderFloat("sf3", ref val, 0f, 1f, "%.3f", ImGuiSliderFlags.None);
            _ = r1; _ = r2; _ = r3;
            ImGui.End();
            ImGui.Render();
        }

        // ========== P8: SliderFloat2 (3 overloads) ==========

        /// <summary>
        /// Tests that slider float 2 all overloads execute
        /// </summary>
        [Fact]
        public void SliderFloat2_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            var val = new Vector2F(0.5f, 0.5f);
            bool r1 = ImGui.SliderFloat2("sf2a", ref val, 0f, 1f);
            bool r2 = ImGui.SliderFloat2("sf2b", ref val, 0f, 1f, "%.3f");
            bool r3 = ImGui.SliderFloat2("sf2c", ref val, 0f, 1f, "%.3f", ImGuiSliderFlags.None);
            _ = r1; _ = r2; _ = r3;
            ImGui.End();
            ImGui.Render();
        }

        // ========== P8: SliderFloat3 (3 overloads) ==========

        /// <summary>
        /// Tests that slider float 3 all overloads execute
        /// </summary>
        [Fact]
        public void SliderFloat3_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            var val = new Vector3F(0.5f, 0.5f, 0.5f);
            bool r1 = ImGui.SliderFloat3("sf3a", ref val, 0f, 1f);
            bool r2 = ImGui.SliderFloat3("sf3b", ref val, 0f, 1f, "%.3f");
            bool r3 = ImGui.SliderFloat3("sf3c", ref val, 0f, 1f, "%.3f", ImGuiSliderFlags.None);
            _ = r1; _ = r2; _ = r3;
            ImGui.End();
            ImGui.Render();
        }

        // ========== P8: SliderFloat4 (2 overloads - 3rd already covered in ImGuiCsP1P2) ==========

        /// <summary>
        /// Tests that slider float 4 basic overloads execute
        /// </summary>
        [Fact]
        public void SliderFloat4_BasicOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            var val = new Vector4F(0.5f, 0.5f, 0.5f, 0.5f);
            bool r1 = ImGui.SliderFloat4("sf4a", ref val, 0f, 1f);
            bool r2 = ImGui.SliderFloat4("sf4b", ref val, 0f, 1f, "%.3f");
            _ = r1; _ = r2;
            ImGui.End();
            ImGui.Render();
        }
    }
}
