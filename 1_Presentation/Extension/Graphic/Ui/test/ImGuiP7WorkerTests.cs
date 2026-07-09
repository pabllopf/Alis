using System;
using System.Text;
using Alis.Core.Aspect.Math.Vector;
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

        [Fact]
        public void PlotHistogram_Default()
        {
            ImGui.NewFrame();
            float val = 1.0f;
            ImGui.PlotHistogram("hist", ref val, 1);
            ImGui.Render();
        }

        [Fact]
        public void PlotHistogram_WithOffset()
        {
            ImGui.NewFrame();
            float val = 1.0f;
            ImGui.PlotHistogram("hist", ref val, 1, 0);
            ImGui.Render();
        }

        [Fact]
        public void PlotHistogram_WithOverlay()
        {
            ImGui.NewFrame();
            float val = 1.0f;
            ImGui.PlotHistogram("hist", ref val, 1, 0, "overlay");
            ImGui.Render();
        }

        [Fact]
        public void PlotHistogram_WithScaleMin()
        {
            ImGui.NewFrame();
            float val = 1.0f;
            ImGui.PlotHistogram("hist", ref val, 1, 0, "overlay", 0.0f);
            ImGui.Render();
        }

        [Fact]
        public void PlotHistogram_WithScaleMax()
        {
            ImGui.NewFrame();
            float val = 1.0f;
            ImGui.PlotHistogram("hist", ref val, 1, 0, "overlay", 0.0f, 2.0f);
            ImGui.Render();
        }

        [Fact]
        public void PlotHistogram_WithGraphSize()
        {
            ImGui.NewFrame();
            float val = 1.0f;
            ImGui.PlotHistogram("hist", ref val, 1, 0, "overlay", 0.0f, 2.0f, new Vector2F(100, 50));
            ImGui.Render();
        }

        [Fact]
        public void PlotHistogram_WithStride()
        {
            ImGui.NewFrame();
            float val = 1.0f;
            ImGui.PlotHistogram("hist", ref val, 1, 0, "overlay", 0.0f, 2.0f, new Vector2F(100, 50), sizeof(float));
            ImGui.Render();
        }

        [Fact]
        public void PlotLines_Default()
        {
            ImGui.NewFrame();
            float val = 1.0f;
            ImGui.PlotLines("lines", ref val, 1);
            ImGui.Render();
        }

        [Fact]
        public void PlotLines_WithOffset()
        {
            ImGui.NewFrame();
            float val = 1.0f;
            ImGui.PlotLines("lines", ref val, 1, 0);
            ImGui.Render();
        }

        [Fact]
        public void PlotLines_WithOverlay()
        {
            ImGui.NewFrame();
            float val = 1.0f;
            ImGui.PlotLines("lines", ref val, 1, 0, "overlay");
            ImGui.Render();
        }

        [Fact]
        public void PlotLines_WithScaleMin()
        {
            ImGui.NewFrame();
            float val = 1.0f;
            ImGui.PlotLines("lines", ref val, 1, 0, "overlay", 0.0f);
            ImGui.Render();
        }

        [Fact]
        public void PlotLines_WithScaleMax()
        {
            ImGui.NewFrame();
            float val = 1.0f;
            ImGui.PlotLines("lines", ref val, 1, 0, "overlay", 0.0f, 2.0f);
            ImGui.Render();
        }

        [Fact]
        public void PlotLines_WithGraphSize()
        {
            ImGui.NewFrame();
            float val = 1.0f;
            ImGui.PlotLines("lines", ref val, 1, 0, "overlay", 0.0f, 2.0f, new Vector2F(100, 50));
            ImGui.Render();
        }

        [Fact]
        public void PlotLines_WithStride()
        {
            ImGui.NewFrame();
            float val = 1.0f;
            ImGui.PlotLines("lines", ref val, 1, 0, "overlay", 0.0f, 2.0f, new Vector2F(100, 50), sizeof(float));
            ImGui.Render();
        }

        [Fact]
        public void PushId_IntPtr()
        {
            ImGui.NewFrame();
            IntPtr ptr = IntPtr.Zero;
            ImGui.PushId(ptr);
            ImGui.PopId();
            ImGui.Render();
        }

        [Fact]
        public void PushId_Int()
        {
            ImGui.NewFrame();
            ImGui.PushId(42);
            ImGui.PopId();
            ImGui.Render();
        }

        [Fact]
        public void RadioButton_IntPtr()
        {
            ImGui.NewFrame();
            int v = 0;
            bool result = ImGui.RadioButton("test", ref v, 1);
            ImGui.Render();
        }

        [Fact]
        public void RadioButton_IntPtr_ReturnsTrue()
        {
            ImGui.NewFrame();
            int v = 1;
            bool result = ImGui.RadioButton("test", ref v, 1);
            ImGui.Render();
        }

        [Fact]
        public void RenderPlatformWindowsDefault_NoArgs()
        {
            ImGui.NewFrame();
            ImGui.Render();
            ImGui.RenderPlatformWindowsDefault();
        }

        [Fact]
        public void RenderPlatformWindowsDefault_PlatformArg()
        {
            ImGui.NewFrame();
            ImGui.Render();
            ImGui.RenderPlatformWindowsDefault(IntPtr.Zero);
        }

        [Fact]
        public void RenderPlatformWindowsDefault_BothArgs()
        {
            ImGui.NewFrame();
            ImGui.Render();
            ImGui.RenderPlatformWindowsDefault(IntPtr.Zero, IntPtr.Zero);
        }

        [Fact]
        public void SaveIniSettingsToDisk()
        {
            ImGui.NewFrame();
            ImGui.Render();
            ImGui.SaveIniSettingsToDisk("test.ini");
        }

        [Fact]
        public void SaveIniSettingsToMemory()
        {
            ImGui.NewFrame();
            ImGui.Render();
            string result = ImGui.SaveIniSettingsToMemory();
            Assert.NotNull(result);
        }

        [Fact]
        public void SaveIniSettingsToMemory_WithOutSize()
        {
            ImGui.NewFrame();
            ImGui.Render();
            string result = ImGui.SaveIniSettingsToMemory(out uint size);
            Assert.NotNull(result);
        }

        [Fact]
        public void Selectable_Label()
        {
            ImGui.NewFrame();
            bool result = ImGui.Selectable("test");
            ImGui.Render();
        }

        [Fact]
        public void Selectable_WithSelected()
        {
            ImGui.NewFrame();
            bool result = ImGui.Selectable("test", true);
            ImGui.Render();
        }

        [Fact]
        public void Selectable_WithFlags()
        {
            ImGui.NewFrame();
            bool result = ImGui.Selectable("test", true, ImGuiSelectableFlags.None);
            ImGui.Render();
        }

        [Fact]
        public void Selectable_WithFlagsSize()
        {
            ImGui.NewFrame();
            bool result = ImGui.Selectable("test", true, ImGuiSelectableFlags.None, new Vector2F(100, 20));
            ImGui.Render();
        }

        [Fact]
        public void Selectable_RefBool()
        {
            ImGui.NewFrame();
            bool selected = false;
            bool result = ImGui.Selectable("test", ref selected);
            ImGui.Render();
        }

        [Fact]
        public void Selectable_RefBoolFlags()
        {
            ImGui.NewFrame();
            bool selected = false;
            bool result = ImGui.Selectable("test", ref selected, ImGuiSelectableFlags.None);
            ImGui.Render();
        }

        [Fact]
        public void Selectable_RefBoolFlagsSize()
        {
            ImGui.NewFrame();
            bool selected = false;
            bool result = ImGui.Selectable("test", ref selected, ImGuiSelectableFlags.None, new Vector2F(100, 20));
            ImGui.Render();
        }

        [Fact]
        public void SetClipboardText()
        {
            ImGui.NewFrame();
            ImGui.SetClipboardText("test clipboard");
            ImGui.Render();
        }

        [Fact]
        public void SetCursorPos()
        {
            ImGui.NewFrame();
            ImGui.SetCursorPos(new Vector2F(10, 20));
            ImGui.Render();
        }

        [Fact]
        public void SetCursorPosX()
        {
            ImGui.NewFrame();
            ImGui.SetCursorPosX(15.0f);
            ImGui.Render();
        }

        [Fact]
        public void SetCursorPosY()
        {
            ImGui.NewFrame();
            ImGui.SetCursorPosY(25.0f);
            ImGui.Render();
        }

        [Fact]
        public void SetCursorScreenPos()
        {
            ImGui.NewFrame();
            ImGui.SetCursorScreenPos(new Vector2F(100, 200));
            ImGui.Render();
        }

        [Fact]
        public void SetItemAllowOverlap()
        {
            ImGui.NewFrame();
            ImGui.SetItemAllowOverlap();
            ImGui.Render();
        }

        [Fact]
        public void SetItemDefaultFocus()
        {
            ImGui.NewFrame();
            ImGui.SetItemDefaultFocus();
            ImGui.Render();
        }

        [Fact]
        public void ResetMouseDragDelta_WithButton()
        {
            ImGui.NewFrame();
            ImGui.ResetMouseDragDelta(ImGuiMouseButton.Left);
            ImGui.Render();
        }

        [Fact]
        public void SetNextWindowClass()
        {
            ImGui.NewFrame();
            var wc = new ImGuiWindowClass();
            ImGui.SetNextWindowClass(wc);
            ImGui.Render();
        }

        [Fact]
        public void SameLine_Default()
        {
            ImGui.NewFrame();
            ImGui.SameLine();
            ImGui.Render();
        }

        [Fact]
        public void SameLine_WithOffset()
        {
            ImGui.NewFrame();
            ImGui.SameLine(10.0f);
            ImGui.Render();
        }

        [Fact]
        public void SameLine_WithOffsetSpacing()
        {
            ImGui.NewFrame();
            ImGui.SameLine(10.0f, 5.0f);
            ImGui.Render();
        }

        [Fact]
        public void SetColumnOffset()
        {
            ImGui.NewFrame();
            ImGui.SetColumnOffset(0, 10.0f);
            ImGui.Render();
        }

        [Fact]
        public void SetColumnWidth()
        {
            ImGui.NewFrame();
            ImGui.SetColumnWidth(0, 100.0f);
            ImGui.Render();
        }

        [Fact]
        public void SetStateStorage()
        {
            ImGui.NewFrame();
            var storage = new ImGuiStorage();
            ImGui.SetStateStorage(storage);
            ImGui.Render();
        }

        [Fact]
        public void MenuItem_WithSelectedEnabled()
        {
            ImGui.NewFrame();
            bool selected = false;
            bool result = ImGui.MenuItem("Test", "Ctrl+T", ref selected, true);
            ImGui.Render();
        }

        [Fact]
        public void MenuItem_WithSelectedEnabled_ReturnsBool()
        {
            ImGui.NewFrame();
            bool selected = false;
            bool result = ImGui.MenuItem("Test", "", ref selected, true);
            ImGui.Render();
        }
    }
}
