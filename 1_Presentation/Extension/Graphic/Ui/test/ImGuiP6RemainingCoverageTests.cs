using System;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// The im gui remaining coverage tests class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public class ImGuiP6RemainingCoverageTests : IDisposable
    {
        /// <summary>
        /// The ctx
        /// </summary>
        internal readonly IntPtr _ctx;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImGuiP6RemainingCoverageTests"/> class
        /// </summary>
        public ImGuiP6RemainingCoverageTests()
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
        /// Inputs the float 4 all overloads should execute
        /// </summary>
        [RequireCImguiSystemFact]
        public void InputFloat4_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            var v = new Vector4F(1f, 2f, 3f, 4f);
            ImGui.InputFloat4("f4", ref v, "%.3f");
            ImGui.InputFloat4("f4f", ref v, "%.3f", ImGuiInputTextFlags.None);
            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        /// Inputs the int all overloads should execute
        /// </summary>
        [RequireCImguiSystemFact]
        public void InputInt_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            int val = 42;
            ImGui.InputInt("i1", ref val);
            ImGui.InputInt("i2", ref val, 5);
            ImGui.InputInt("i3", ref val, 5, 10);
            ImGui.InputInt("i4", ref val, 5, 10, ImGuiInputTextFlags.None);
            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        /// Inputs the int 2 all overloads should execute
        /// </summary>
        [RequireCImguiSystemFact]
        public void InputInt2_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            int val = 0;
            ImGui.InputInt2("i2a", ref val);
            ImGui.InputInt2("i2b", ref val, ImGuiInputTextFlags.None);
            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        /// Inputs the int 4 all overloads should execute
        /// </summary>
        [RequireCImguiSystemFact]
        public void InputInt4_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            int val = 0;
            ImGui.InputInt4("i4a", ref val);
            ImGui.InputInt4("i4b", ref val, ImGuiInputTextFlags.None);
            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        /// Inputs the scalar all overloads should execute
        /// </summary>
        [RequireCImguiSystemFact]
        public void InputScalar_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            IntPtr pData = Marshal.AllocHGlobal(sizeof(float));
            try
            {
                Marshal.StructureToPtr(0.0f, pData, false);
                ImGui.InputScalar("s1", ImGuiDataType.Float, pData);
                ImGui.InputScalar("s2", ImGuiDataType.Float, pData, IntPtr.Zero);
                ImGui.InputScalar("s3", ImGuiDataType.Float, pData, IntPtr.Zero, IntPtr.Zero);
                ImGui.InputScalar("s4", ImGuiDataType.Float, pData, IntPtr.Zero, IntPtr.Zero, "%.3f");
                ImGui.InputScalar("s5", ImGuiDataType.Float, pData, IntPtr.Zero, IntPtr.Zero, "%.3f", ImGuiInputTextFlags.None);
            }
            finally
            {
                Marshal.FreeHGlobal(pData);
            }
            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        /// Inputs the scalar n all overloads should execute
        /// </summary>
        [RequireCImguiSystemFact]
        public void InputScalarN_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            IntPtr pData = Marshal.AllocHGlobal(4 * sizeof(float));
            try
            {
                ImGui.InputScalarN("sn1", ImGuiDataType.Float, pData, 4);
                ImGui.InputScalarN("sn2", ImGuiDataType.Float, pData, 4, IntPtr.Zero);
                ImGui.InputScalarN("sn3", ImGuiDataType.Float, pData, 4, IntPtr.Zero, IntPtr.Zero);
                ImGui.InputScalarN("sn4", ImGuiDataType.Float, pData, 4, IntPtr.Zero, IntPtr.Zero, "%.3f");
                ImGui.InputScalarN("sn5", ImGuiDataType.Float, pData, 4, IntPtr.Zero, IntPtr.Zero, "%.3f", ImGuiInputTextFlags.None);
            }
            finally
            {
                Marshal.FreeHGlobal(pData);
            }
            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        /// Invisibles the button all overloads should execute
        /// </summary>
        [RequireCImguiSystemFact]
        public void InvisibleButton_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            ImGui.InvisibleButton("ib1", new Vector2F(50, 20));
            ImGui.InvisibleButton("ib2", new Vector2F(50, 20), ImGuiButtonFlags.None);
            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        /// Ises the any item queries should execute
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsAnyItemQueries_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            ImGui.Button("dummy");
            ImGui.IsAnyItemActive();
            ImGui.IsAnyItemFocused();
            ImGui.IsAnyItemHovered();
            ImGui.IsAnyMouseDown();
            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        /// Ises the item state queries should execute
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsItemStateQueries_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            ImGui.Button("dummy");
            ImGui.IsItemActivated();
            ImGui.IsItemActive();
            ImGui.IsItemDeactivated();
            ImGui.IsItemDeactivatedAfterEdit();
            ImGui.IsItemEdited();
            ImGui.IsItemFocused();
            ImGui.IsItemToggledOpen();
            ImGui.IsItemVisible();
            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        /// Ises the item clicked all overloads should execute
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsItemClicked_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            ImGui.Button("dummy");
            ImGui.IsItemClicked();
            ImGui.IsItemClicked(ImGuiMouseButton.Left);
            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        /// Ises the item hovered all overloads should execute
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsItemHovered_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            ImGui.Button("dummy");
            ImGui.IsItemHovered();
            ImGui.IsItemHovered(ImGuiHoveredFlags.None);
            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        /// Ises the key methods should execute
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsKeyMethods_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            ImGui.IsKeyDown(ImGuiKey.A);
            ImGui.IsKeyPressed(ImGuiKey.A);
            ImGui.IsKeyPressed(ImGuiKey.A, false);
            ImGui.IsKeyReleased(ImGuiKey.A);
            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        /// Ises the mouse methods should execute
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsMouseMethods_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            ImGui.IsMouseClicked(ImGuiMouseButton.Left);
            ImGui.IsMouseClicked(ImGuiMouseButton.Left, false);
            ImGui.IsMouseDoubleClicked(ImGuiMouseButton.Left);
            ImGui.IsMouseDown(ImGuiMouseButton.Left);
            ImGui.IsMouseReleased(ImGuiMouseButton.Left);
            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        /// Ises the mouse dragging all overloads should execute
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsMouseDragging_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            ImGui.IsMouseDragging(ImGuiMouseButton.Left);
            ImGui.IsMouseDragging(ImGuiMouseButton.Left, 0.5f);
            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        /// Ises the mouse hovering rect all overloads should execute
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsMouseHoveringRect_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            var min = new Vector2F(0, 0);
            var max = new Vector2F(100, 100);
            ImGui.IsMouseHoveringRect(min, max);
            ImGui.IsMouseHoveringRect(min, max, true);
            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        /// Ises the mouse pos valid all overloads should execute
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsMousePosValid_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            ImGui.IsMousePosValid();
            var pos = new Vector2F(100, 200);
            ImGui.IsMousePosValid(ref pos);
            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        /// Ises the popup open all overloads should execute
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsPopupOpen_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            ImGui.IsPopupOpen("popup");
            ImGui.IsPopupOpen("popup", ImGuiPopupFlags.None);
            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        /// Ises the rect visible all overloads should execute
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsRectVisible_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            ImGui.IsRectVisible(new Vector2F(50, 30));
            ImGui.IsRectVisible(new Vector2F(0, 0), new Vector2F(100, 100));
            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        /// Ises the window state queries should execute
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsWindowStateQueries_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            ImGui.IsWindowAppearing();
            ImGui.IsWindowCollapsed();
            ImGui.IsWindowDocked();
            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        /// Ises the window focused all overloads should execute
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsWindowFocused_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            ImGui.IsWindowFocused();
            ImGui.IsWindowFocused(ImGuiFocusedFlags.None);
            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        /// Ises the window hovered all overloads should execute
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsWindowHovered_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            ImGui.IsWindowHovered();
            ImGui.IsWindowHovered(ImGuiHoveredFlags.None);
            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        /// Labels the text should execute
        /// </summary>
        [RequireCImguiSystemFact]
        public void LabelText_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            ImGui.LabelText("key", "value");
            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        /// Loads the ini settings from memory all overloads should execute
        /// </summary>
        [RequireCImguiSystemFact]
        public void LoadIniSettingsFromMemory_AllOverloads_ShouldExecute()
        {
            ImGui.LoadIniSettingsFromMemory("");
            ImGui.LoadIniSettingsFromMemory("", 0u);
        }

        /// <summary>
        /// Logs the buttons finish text should execute
        /// </summary>
        [RequireCImguiSystemFact]
        public void LogButtons_Finish_Text_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            ImGui.LogButtons();
            ImGui.LogText("test log");
            ImGui.End();
            ImGui.Render();
            ImGui.LogFinish();
        }

        /// <summary>
        /// Logs the to clipboard all overloads should execute
        /// </summary>
        [RequireCImguiSystemFact]
        public void LogToClipboard_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.LogToClipboard();
            ImGui.LogFinish();
            ImGui.Render();
            ImGui.NewFrame();
            ImGui.LogToClipboard(-1);
            ImGui.LogFinish();
            ImGui.Render();
        }

        /// <summary>
        /// Logs the to tty all overloads should execute
        /// </summary>
        [RequireCImguiSystemFact]
        public void LogToTty_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.LogToTty();
            ImGui.LogFinish();
            ImGui.Render();
            ImGui.NewFrame();
            ImGui.LogToTty(-1);
            ImGui.LogFinish();
            ImGui.Render();
        }

        /// <summary>
        /// Mems the alloc mem free should execute
        /// </summary>
        [RequireCImguiSystemFact]
        public void MemAlloc_MemFree_ShouldExecute()
        {
            IntPtr ptr = ImGui.MemAlloc(100u);
            Assert.NotEqual(IntPtr.Zero, ptr);
            ImGui.MemFree(ptr);
        }

        /// <summary>
        /// Menus the item all overloads should execute
        /// </summary>
        [RequireCImguiSystemFact]
        public void MenuItem_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            if (ImGui.BeginMainMenuBar())
            {
                if (ImGui.BeginMenu("File"))
                {
                    ImGui.MenuItem("Open");
                    ImGui.MenuItem("Save", "Ctrl+S");
                    ImGui.MenuItem("SaveAs", "Ctrl+Shift+S", false);
                    ImGui.MenuItem("Export", "Ctrl+E", false, true);
                    bool selected = false;
                    ImGui.MenuItem("Select", "", ref selected);
                    ImGui.EndMenu();
                }
                ImGui.EndMainMenuBar();
            }
            ImGui.Render();
        }
    }
}
