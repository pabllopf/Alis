using System;
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    public class ImGuiP7NativeTest : IDisposable
    {
        private readonly IntPtr _ctx;

        public ImGuiP7NativeTest()
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
        public void MenuItem()
        {
            ImGui.NewFrame();
            bool selected = false;
            ImGui.MenuItem("Test", "Ctrl+T", ref selected, true);
            ImGui.Render();
        }

        [Fact]
        public void NewFrame_And_Render()
        {
            ImGui.NewFrame();
            ImGui.Render();
        }

        [Fact]
        public void NewLine()
        {
            ImGui.NewFrame();
            ImGui.NewLine();
            ImGui.Render();
        }

        [Fact]
        public void NextColumn()
        {
            ImGui.NewFrame();
            ImGui.NextColumn();
            ImGui.Render();
        }

        [Fact]
        public void OpenPopup_Str()
        {
            ImGui.NewFrame();
            ImGui.OpenPopup("Test");
            ImGui.Render();
        }

        [Fact]
        public void OpenPopup_StrWithFlags()
        {
            ImGui.NewFrame();
            ImGui.OpenPopup("Test", ImGuiPopupFlags.None);
            ImGui.Render();
        }

        [Fact]
        public void OpenPopup_U32()
        {
            ImGui.NewFrame();
            ImGui.OpenPopup(123u);
            ImGui.Render();
        }

        [Fact]
        public void OpenPopup_U32WithFlags()
        {
            ImGui.NewFrame();
            ImGui.OpenPopup(123u, ImGuiPopupFlags.None);
            ImGui.Render();
        }

        [Fact]
        public void OpenPopupOnItemClick()
        {
            ImGui.NewFrame();
            ImGui.OpenPopupOnItemClick();
            ImGui.Render();
        }

        [Fact]
        public void OpenPopupOnItemClick_Str()
        {
            ImGui.NewFrame();
            ImGui.OpenPopupOnItemClick("Test");
            ImGui.Render();
        }

        [Fact]
        public void OpenPopupOnItemClick_StrWithFlags()
        {
            ImGui.NewFrame();
            ImGui.OpenPopupOnItemClick("Test", ImGuiPopupFlags.None);
            ImGui.Render();
        }

        [Fact]
        public void PopAllowKeyboardFocus()
        {
            ImGui.NewFrame();
            ImGui.PushAllowKeyboardFocus(true);
            ImGui.PopAllowKeyboardFocus();
            ImGui.Render();
        }

        [Fact]
        public void PopButtonRepeat()
        {
            ImGui.NewFrame();
            ImGui.PushButtonRepeat(true);
            ImGui.PopButtonRepeat();
            ImGui.Render();
        }

        [Fact]
        public void PopClipRect()
        {
            ImGui.NewFrame();
            ImGui.PushClipRect(new Vector2F(), new Vector2F(100, 100), false);
            ImGui.PopClipRect();
            ImGui.Render();
        }

        [Fact]
        public void PopId()
        {
            ImGui.NewFrame();
            ImGui.PushId("test");
            ImGui.PopId();
            ImGui.Render();
        }

        [Fact]
        public void PopItemWidth()
        {
            ImGui.NewFrame();
            ImGui.PushItemWidth(100f);
            ImGui.PopItemWidth();
            ImGui.Render();
        }

        [Fact]
        public void PopStyleColor()
        {
            ImGui.NewFrame();
            ImGui.PushStyleColor(ImGuiCol.Text, new Vector4F(1, 1, 1, 1));
            ImGui.PopStyleColor();
            ImGui.Render();
        }

        [Fact]
        public void PopStyleColor_WithCount()
        {
            ImGui.NewFrame();
            ImGui.PushStyleColor(ImGuiCol.Text, new Vector4F(1, 1, 1, 1));
            ImGui.PushStyleColor(ImGuiCol.Text, new Vector4F(0, 0, 0, 1));
            ImGui.PopStyleColor(2);
            ImGui.Render();
        }

        [Fact]
        public void PopStyleVar()
        {
            ImGui.NewFrame();
            ImGui.PushStyleVar(ImGuiStyleVar.Alpha, 0.5f);
            ImGui.PopStyleVar();
            ImGui.Render();
        }

        [Fact]
        public void PopStyleVar_WithCount()
        {
            ImGui.NewFrame();
            ImGui.PushStyleVar(ImGuiStyleVar.Alpha, 0.5f);
            ImGui.PushStyleVar(ImGuiStyleVar.Alpha, 0.8f);
            ImGui.PopStyleVar(2);
            ImGui.Render();
        }

        [Fact]
        public void PopTextWrapPos()
        {
            ImGui.NewFrame();
            ImGui.PushTextWrapPos();
            ImGui.PopTextWrapPos();
            ImGui.Render();
        }

        [Fact]
        public void ProgressBar()
        {
            ImGui.NewFrame();
            ImGui.ProgressBar(0.5f);
            ImGui.Render();
        }

        [Fact]
        public void ProgressBar_WithSize()
        {
            ImGui.NewFrame();
            ImGui.ProgressBar(0.5f, new Vector2F(100, 20));
            ImGui.Render();
        }

        [Fact]
        public void ProgressBar_WithSizeOverlay()
        {
            ImGui.NewFrame();
            ImGui.ProgressBar(0.5f, new Vector2F(100, 20), "50%");
            ImGui.Render();
        }

        [Fact]
        public void PushAllowKeyboardFocus()
        {
            ImGui.NewFrame();
            ImGui.PushAllowKeyboardFocus(true);
            ImGui.PopAllowKeyboardFocus();
            ImGui.Render();
        }

        [Fact]
        public void PushButtonRepeat()
        {
            ImGui.NewFrame();
            ImGui.PushButtonRepeat(true);
            ImGui.PopButtonRepeat();
            ImGui.Render();
        }

        [Fact]
        public void PushClipRect()
        {
            ImGui.NewFrame();
            ImGui.PushClipRect(new Vector2F(), new Vector2F(100, 100), false);
            ImGui.PopClipRect();
            ImGui.Render();
        }

        [Fact]
        public void PushId_Str()
        {
            ImGui.NewFrame();
            ImGui.PushId("TestId");
            ImGui.PopId();
            ImGui.Render();
        }

        [Fact]
        public void PushItemWidth()
        {
            ImGui.NewFrame();
            ImGui.PushItemWidth(200f);
            ImGui.PopItemWidth();
            ImGui.Render();
        }

        [Fact]
        public void PushStyleColor_U32()
        {
            ImGui.NewFrame();
            ImGui.PushStyleColor(ImGuiCol.Text, 0xFFFFFFFF);
            ImGui.PopStyleColor();
            ImGui.Render();
        }

        [Fact]
        public void PushStyleColor_Vec4()
        {
            ImGui.NewFrame();
            ImGui.PushStyleColor(ImGuiCol.Text, new Vector4F(1, 1, 1, 1));
            ImGui.PopStyleColor();
            ImGui.Render();
        }

        [Fact]
        public void PushStyleVar_Float()
        {
            ImGui.NewFrame();
            ImGui.PushStyleVar(ImGuiStyleVar.Alpha, 0.5f);
            ImGui.PopStyleVar();
            ImGui.Render();
        }

        [Fact]
        public void PushStyleVar_Vec2()
        {
            ImGui.NewFrame();
            ImGui.PushStyleVar(ImGuiStyleVar.WindowPadding, new Vector2F(10, 10));
            ImGui.PopStyleVar();
            ImGui.Render();
        }

        [Fact]
        public void PushTextWrapPos()
        {
            ImGui.NewFrame();
            ImGui.PushTextWrapPos();
            ImGui.PopTextWrapPos();
            ImGui.Render();
        }

        [Fact]
        public void PushTextWrapPos_WithValue()
        {
            ImGui.NewFrame();
            ImGui.PushTextWrapPos(200f);
            ImGui.PopTextWrapPos();
            ImGui.Render();
        }

        [Fact]
        public void RadioButton()
        {
            ImGui.NewFrame();
            ImGui.RadioButton("Test", true);
            ImGui.Render();
        }

        [Fact]
        public void Render()
        {
            ImGui.NewFrame();
            ImGui.Render();
        }

        [Fact]
        public void Separator()
        {
            ImGui.NewFrame();
            ImGui.Separator();
            ImGui.Render();
        }

        [Fact]
        public void SetColorEditOptions()
        {
            ImGui.NewFrame();
            ImGui.SetColorEditOptions(ImGuiColorEditFlags.None);
            ImGui.Render();
        }

        [Fact]
        public void SetCurrentContext()
        {
            ImGui.SetCurrentContext(_ctx);
        }

        [Fact]
        public void SetKeyboardFocusHere()
        {
            ImGui.NewFrame();
            ImGui.SetKeyboardFocusHere();
            ImGui.Render();
        }

        [Fact]
        public void SetKeyboardFocusHere_WithOffset()
        {
            ImGui.NewFrame();
            ImGui.SetKeyboardFocusHere(1);
            ImGui.Render();
        }

        [Fact]
        public void SetMouseCursor()
        {
            ImGui.NewFrame();
            ImGui.SetMouseCursor(ImGuiMouseCursor.Arrow);
            ImGui.Render();
        }

        [Fact]
        public void SetNextFrameWantCaptureKeyboard()
        {
            ImGui.NewFrame();
            ImGui.SetNextFrameWantCaptureKeyboard(true);
            ImGui.Render();
        }

        [Fact]
        public void SetNextFrameWantCaptureMouse()
        {
            ImGui.NewFrame();
            ImGui.SetNextFrameWantCaptureMouse(true);
            ImGui.Render();
        }

        [Fact]
        public void SetNextItemOpen()
        {
            ImGui.NewFrame();
            ImGui.SetNextItemOpen(true);
            ImGui.Render();
        }

        [Fact]
        public void SetNextItemOpen_WithCond()
        {
            ImGui.NewFrame();
            ImGui.SetNextItemOpen(true, ImGuiCond.Once);
            ImGui.Render();
        }

        [Fact]
        public void SetNextItemWidth()
        {
            ImGui.NewFrame();
            ImGui.SetNextItemWidth(100f);
            ImGui.Render();
        }

        [Fact]
        public void SetNextWindowBgAlpha()
        {
            ImGui.NewFrame();
            ImGui.SetNextWindowBgAlpha(0.5f);
            ImGui.Render();
        }

        [Fact]
        public void SetNextWindowContentSize()
        {
            ImGui.NewFrame();
            ImGui.SetNextWindowContentSize(new Vector2F(200, 100));
            ImGui.Render();
        }

        [Fact]
        public void SetNextWindowFocus()
        {
            ImGui.NewFrame();
            ImGui.SetNextWindowFocus();
            ImGui.Render();
        }

        [Fact]
        public void SetNextWindowPos()
        {
            ImGui.NewFrame();
            ImGui.SetNextWindowPos(new Vector2F(100, 100));
            ImGui.Render();
        }

        [Fact]
        public void SetNextWindowPos_WithCond()
        {
            ImGui.NewFrame();
            ImGui.SetNextWindowPos(new Vector2F(100, 100), ImGuiCond.Once);
            ImGui.Render();
        }

        [Fact]
        public void SetNextWindowPos_WithCondPivot()
        {
            ImGui.NewFrame();
            ImGui.SetNextWindowPos(new Vector2F(100, 100), ImGuiCond.Once, new Vector2F(0.5f, 0.5f));
            ImGui.Render();
        }

        [Fact]
        public void SetNextWindowScroll()
        {
            ImGui.NewFrame();
            ImGui.SetNextWindowScroll(new Vector2F(0, 10));
            ImGui.Render();
        }

        [Fact]
        public void SetNextWindowSize()
        {
            ImGui.NewFrame();
            ImGui.SetNextWindowSize(new Vector2F(400, 300));
            ImGui.Render();
        }

        [Fact]
        public void SetNextWindowSize_WithCond()
        {
            ImGui.NewFrame();
            ImGui.SetNextWindowSize(new Vector2F(400, 300), ImGuiCond.Once);
            ImGui.Render();
        }

        [Fact]
        public void SetNextWindowViewport()
        {
            ImGui.NewFrame();
            ImGui.SetNextWindowViewport(1u);
            ImGui.Render();
        }

        [Fact]
        public void SetScrollFromPosX()
        {
            ImGui.NewFrame();
            ImGui.SetScrollFromPosX(50f);
            ImGui.Render();
        }

        [Fact]
        public void SetScrollFromPosX_WithRatio()
        {
            ImGui.NewFrame();
            ImGui.SetScrollFromPosX(50f, 0.3f);
            ImGui.Render();
        }

        [Fact]
        public void SetScrollFromPosY()
        {
            ImGui.NewFrame();
            ImGui.SetScrollFromPosY(50f);
            ImGui.Render();
        }

        [Fact]
        public void SetScrollFromPosY_WithRatio()
        {
            ImGui.NewFrame();
            ImGui.SetScrollFromPosY(50f, 0.3f);
            ImGui.Render();
        }

        [Fact]
        public void SetScrollHereX()
        {
            ImGui.NewFrame();
            ImGui.SetScrollHereX();
            ImGui.Render();
        }

        [Fact]
        public void SetScrollHereX_WithRatio()
        {
            ImGui.NewFrame();
            ImGui.SetScrollHereX(0.3f);
            ImGui.Render();
        }

        [Fact]
        public void SetScrollHereY()
        {
            ImGui.NewFrame();
            ImGui.SetScrollHereY();
            ImGui.Render();
        }

        [Fact]
        public void SetScrollHereY_WithRatio()
        {
            ImGui.NewFrame();
            ImGui.SetScrollHereY(0.3f);
            ImGui.Render();
        }

        [Fact]
        public void SetScrollX()
        {
            ImGui.NewFrame();
            ImGui.SetScrollX(10f);
            ImGui.Render();
        }

        [Fact]
        public void SetScrollY()
        {
            ImGui.NewFrame();
            ImGui.SetScrollY(10f);
            ImGui.Render();
        }

        [Fact]
        public void SetWindowFocus()
        {
            ImGui.NewFrame();
            ImGui.SetWindowFocus();
            ImGui.Render();
        }

        [Fact]
        public void SetWindowFontScale()
        {
            ImGui.NewFrame();
            ImGui.SetWindowFontScale(1.5f);
            ImGui.Render();
        }

        [Fact]
        public void SetWindowPos()
        {
            ImGui.NewFrame();
            ImGui.SetWindowPos(new Vector2F(100, 100));
            ImGui.Render();
        }

        [Fact]
        public void SetWindowPos_WithCond()
        {
            ImGui.NewFrame();
            ImGui.SetWindowPos(new Vector2F(100, 100), ImGuiCond.Once);
            ImGui.Render();
        }

        [Fact]
        public void SetWindowSize()
        {
            ImGui.NewFrame();
            ImGui.SetWindowSize(new Vector2F(400, 300));
            ImGui.Render();
        }

        [Fact]
        public void SetWindowSize_WithCond()
        {
            ImGui.NewFrame();
            ImGui.SetWindowSize(new Vector2F(400, 300), ImGuiCond.Once);
            ImGui.Render();
        }

        [Fact]
        public void ResetMouseDragDelta()
        {
            ImGui.NewFrame();
            ImGui.ResetMouseDragDelta();
            ImGui.Render();
        }

        [Fact]
        public void SetNextWindowCollapsed()
        {
            ImGui.NewFrame();
            ImGui.SetNextWindowCollapsed(true);
            ImGui.Render();
        }

        [Fact]
        public void SetNextWindowCollapsed_WithCond()
        {
            ImGui.NewFrame();
            ImGui.SetNextWindowCollapsed(true, ImGuiCond.Once);
            ImGui.Render();
        }

        [Fact]
        public void SetNextWindowDockId()
        {
            ImGui.NewFrame();
            ImGui.SetNextWindowDockId(1u);
            ImGui.Render();
        }

        [Fact]
        public void SetNextWindowDockId_WithCond()
        {
            ImGui.NewFrame();
            ImGui.SetNextWindowDockId(1u, ImGuiCond.Once);
            ImGui.Render();
        }

        [Fact]
        public void SetNextWindowSizeConstraints()
        {
            ImGui.NewFrame();
            ImGui.SetNextWindowSizeConstraints(new Vector2F(100, 100), new Vector2F(500, 500));
            ImGui.Render();
        }

        [Fact]
        public void SetTabItemClosed()
        {
            ImGui.NewFrame();
            ImGui.SetTabItemClosed("TestTab");
            ImGui.Render();
        }

        [Fact]
        public void SetWindowCollapsed()
        {
            ImGui.NewFrame();
            ImGui.SetWindowCollapsed(true);
            ImGui.Render();
        }

        [Fact]
        public void SetWindowFocus_Str()
        {
            ImGui.NewFrame();
            ImGui.SetWindowFocus("TestWindow");
            ImGui.Render();
        }

        [Fact]
        public void SetWindowPos_Str()
        {
            ImGui.NewFrame();
            ImGui.SetWindowPos("TestWindow", new Vector2F(100, 100));
            ImGui.Render();
        }

        [Fact]
        public void SetWindowSize_Str()
        {
            ImGui.NewFrame();
            ImGui.SetWindowSize("TestWindow", new Vector2F(400, 300));
            ImGui.Render();
        }
    }
}
