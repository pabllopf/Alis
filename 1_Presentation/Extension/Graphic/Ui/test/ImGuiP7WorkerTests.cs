using System;
using System.Text;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    public class ImGuiP7WorkerTests : IDisposable
    {
        private readonly IntPtr _ctx;

        public ImGuiP7WorkerTests()
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
        public void PlotHistogram_Default()
        {
            ImGui.NewFrame();
            float val = 1.0f;
            ImGui.PlotHistogram("hist", ref val, 1);
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void PlotHistogram_WithOffset()
        {
            ImGui.NewFrame();
            float val = 1.0f;
            ImGui.PlotHistogram("hist", ref val, 1, 0);
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void PlotHistogram_WithOverlay()
        {
            ImGui.NewFrame();
            float val = 1.0f;
            ImGui.PlotHistogram("hist", ref val, 1, 0, "overlay");
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void PlotHistogram_WithScaleMin()
        {
            ImGui.NewFrame();
            float val = 1.0f;
            ImGui.PlotHistogram("hist", ref val, 1, 0, "overlay", 0.0f);
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void PlotHistogram_WithScaleMax()
        {
            ImGui.NewFrame();
            float val = 1.0f;
            ImGui.PlotHistogram("hist", ref val, 1, 0, "overlay", 0.0f, 2.0f);
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void PlotHistogram_WithGraphSize()
        {
            ImGui.NewFrame();
            float val = 1.0f;
            ImGui.PlotHistogram("hist", ref val, 1, 0, "overlay", 0.0f, 2.0f, new Vector2F(100, 50));
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void PlotHistogram_WithStride()
        {
            ImGui.NewFrame();
            float val = 1.0f;
            ImGui.PlotHistogram("hist", ref val, 1, 0, "overlay", 0.0f, 2.0f, new Vector2F(100, 50), sizeof(float));
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void PlotLines_Default()
        {
            ImGui.NewFrame();
            float val = 1.0f;
            ImGui.PlotLines("lines", ref val, 1);
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void PlotLines_WithOffset()
        {
            ImGui.NewFrame();
            float val = 1.0f;
            ImGui.PlotLines("lines", ref val, 1, 0);
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void PlotLines_WithOverlay()
        {
            ImGui.NewFrame();
            float val = 1.0f;
            ImGui.PlotLines("lines", ref val, 1, 0, "overlay");
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void PlotLines_WithScaleMin()
        {
            ImGui.NewFrame();
            float val = 1.0f;
            ImGui.PlotLines("lines", ref val, 1, 0, "overlay", 0.0f);
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void PlotLines_WithScaleMax()
        {
            ImGui.NewFrame();
            float val = 1.0f;
            ImGui.PlotLines("lines", ref val, 1, 0, "overlay", 0.0f, 2.0f);
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void PlotLines_WithGraphSize()
        {
            ImGui.NewFrame();
            float val = 1.0f;
            ImGui.PlotLines("lines", ref val, 1, 0, "overlay", 0.0f, 2.0f, new Vector2F(100, 50));
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void PlotLines_WithStride()
        {
            ImGui.NewFrame();
            float val = 1.0f;
            ImGui.PlotLines("lines", ref val, 1, 0, "overlay", 0.0f, 2.0f, new Vector2F(100, 50), sizeof(float));
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void PushId_IntPtr()
        {
            ImGui.NewFrame();
            IntPtr ptr = IntPtr.Zero;
            ImGui.PushId(ptr);
            ImGui.PopId();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void PushId_Int()
        {
            ImGui.NewFrame();
            ImGui.PushId(42);
            ImGui.PopId();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void RadioButton_IntPtr()
        {
            ImGui.NewFrame();
            int v = 0;
            bool result = ImGui.RadioButton("test", ref v, 1);
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void RadioButton_IntPtr_ReturnsTrue()
        {
            ImGui.NewFrame();
            int v = 1;
            bool result = ImGui.RadioButton("test", ref v, 1);
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void RenderPlatformWindowsDefault_NoArgs()
        {
            ImGui.NewFrame();
            ImGui.Render();
            ImGui.RenderPlatformWindowsDefault();
        }

        [RequireCImguiSystemFact]
        public void RenderPlatformWindowsDefault_PlatformArg()
        {
            ImGui.NewFrame();
            ImGui.Render();
            ImGui.RenderPlatformWindowsDefault(IntPtr.Zero);
        }

        [RequireCImguiSystemFact]
        public void RenderPlatformWindowsDefault_BothArgs()
        {
            ImGui.NewFrame();
            ImGui.Render();
            ImGui.RenderPlatformWindowsDefault(IntPtr.Zero, IntPtr.Zero);
        }

        [RequireCImguiSystemFact]
        public void SaveIniSettingsToDisk()
        {
            ImGui.NewFrame();
            ImGui.Render();
            ImGui.SaveIniSettingsToDisk("test.ini");
        }

        [RequireCImguiSystemFact]
        public void SaveIniSettingsToMemory()
        {
            ImGui.NewFrame();
            ImGui.Render();
            string result = ImGui.SaveIniSettingsToMemory();
            Assert.NotNull(result);
        }

        [RequireCImguiSystemFact]
        public void SaveIniSettingsToMemory_WithOutSize()
        {
            ImGui.NewFrame();
            ImGui.Render();
            string result = ImGui.SaveIniSettingsToMemory(out uint size);
            Assert.NotNull(result);
        }

        [RequireCImguiSystemFact]
        public void Selectable_Label()
        {
            ImGui.NewFrame();
            bool result = ImGui.Selectable("test");
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void Selectable_WithSelected()
        {
            ImGui.NewFrame();
            bool result = ImGui.Selectable("test", true);
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void Selectable_WithFlags()
        {
            ImGui.NewFrame();
            bool result = ImGui.Selectable("test", true, ImGuiSelectableFlags.None);
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void Selectable_WithFlagsSize()
        {
            ImGui.NewFrame();
            bool result = ImGui.Selectable("test", true, ImGuiSelectableFlags.None, new Vector2F(100, 20));
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void Selectable_RefBool()
        {
            ImGui.NewFrame();
            bool selected = false;
            bool result = ImGui.Selectable("test", ref selected);
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void Selectable_RefBoolFlags()
        {
            ImGui.NewFrame();
            bool selected = false;
            bool result = ImGui.Selectable("test", ref selected, ImGuiSelectableFlags.None);
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void Selectable_RefBoolFlagsSize()
        {
            ImGui.NewFrame();
            bool selected = false;
            bool result = ImGui.Selectable("test", ref selected, ImGuiSelectableFlags.None, new Vector2F(100, 20));
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void SetClipboardText()
        {
            ImGui.NewFrame();
            ImGui.SetClipboardText("test clipboard");
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void SetCursorPos()
        {
            ImGui.NewFrame();
            ImGui.SetCursorPos(new Vector2F(10, 20));
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void SetCursorPosX()
        {
            ImGui.NewFrame();
            ImGui.SetCursorPosX(15.0f);
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void SetCursorPosY()
        {
            ImGui.NewFrame();
            ImGui.SetCursorPosY(25.0f);
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void SetCursorScreenPos()
        {
            ImGui.NewFrame();
            ImGui.SetCursorScreenPos(new Vector2F(100, 200));
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void SetItemAllowOverlap()
        {
            ImGui.NewFrame();
            ImGui.SetItemAllowOverlap();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void SetItemDefaultFocus()
        {
            ImGui.NewFrame();
            ImGui.SetItemDefaultFocus();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void ResetMouseDragDelta_WithButton()
        {
            ImGui.NewFrame();
            ImGui.ResetMouseDragDelta(ImGuiMouseButton.Left);
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void SetNextWindowClass()
        {
            ImGui.NewFrame();
            var wc = new ImGuiWindowClass();
            ImGui.SetNextWindowClass(wc);
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void SameLine_Default()
        {
            ImGui.NewFrame();
            ImGui.SameLine();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void SameLine_WithOffset()
        {
            ImGui.NewFrame();
            ImGui.SameLine(10.0f);
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void SameLine_WithOffsetSpacing()
        {
            ImGui.NewFrame();
            ImGui.SameLine(10.0f, 5.0f);
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void SetColumnOffset()
        {
            ImGui.NewFrame();
            ImGui.SetColumnOffset(0, 10.0f);
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void SetColumnWidth()
        {
            ImGui.NewFrame();
            ImGui.SetColumnWidth(0, 100.0f);
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void SetStateStorage()
        {
            ImGui.NewFrame();
            var storage = new ImGuiStorage();
            ImGui.SetStateStorage(storage);
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void MenuItem_WithSelectedEnabled()
        {
            ImGui.NewFrame();
            bool selected = false;
            bool result = ImGui.MenuItem("Test", "Ctrl+T", ref selected, true);
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void MenuItem_WithSelectedEnabled_ReturnsBool()
        {
            ImGui.NewFrame();
            bool selected = false;
            bool result = ImGui.MenuItem("Test", "", ref selected, true);
            ImGui.Render();
        }
    }
}
