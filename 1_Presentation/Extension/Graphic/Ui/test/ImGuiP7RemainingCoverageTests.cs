using System;
using System.Text;
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    public class ImGuiP7RemainingCoverageTests : IDisposable
    {
        private readonly IntPtr _ctx;

        public ImGuiP7RemainingCoverageTests()
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
        public void OpenPopup_String()
        {
            ImGui.NewFrame();
            ImGui.OpenPopup("test_popup");
            ImGui.Render();
        }

        [Fact]
        public void OpenPopup_String_Flags()
        {
            ImGui.NewFrame();
            ImGui.OpenPopup("test_popup", ImGuiPopupFlags.None);
            ImGui.Render();
        }

        [Fact]
        public void OpenPopup_Uint()
        {
            ImGui.NewFrame();
            ImGui.OpenPopup(123u);
            ImGui.Render();
        }

        [Fact]
        public void OpenPopup_Uint_Flags()
        {
            ImGui.NewFrame();
            ImGui.OpenPopup(123u, ImGuiPopupFlags.None);
            ImGui.Render();
        }

        [Fact]
        public void OpenPopupOnItemClick_Default()
        {
            ImGui.NewFrame();
            ImGui.OpenPopupOnItemClick();
            ImGui.Render();
        }

        [Fact]
        public void OpenPopupOnItemClick_String()
        {
            ImGui.NewFrame();
            ImGui.OpenPopupOnItemClick("test");
            ImGui.Render();
        }

        [Fact]
        public void OpenPopupOnItemClick_String_Flags()
        {
            ImGui.NewFrame();
            ImGui.OpenPopupOnItemClick("test", ImGuiPopupFlags.None);
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
            ImGui.PushClipRect(new Vector2F(0, 0), new Vector2F(100, 100), true);
            ImGui.PopClipRect();
            ImGui.Render();
        }

        [Fact]
        public void PopItemWidth()
        {
            ImGui.NewFrame();
            ImGui.PushItemWidth(200.0f);
            ImGui.PopItemWidth();
            ImGui.Render();
        }

        [Fact]
        public void PopStyleColor_Default()
        {
            ImGui.NewFrame();
            ImGui.PushStyleColor(ImGuiCol.Text, new Vector4F(1, 1, 1, 1));
            ImGui.PopStyleColor();
            ImGui.Render();
        }

        [Fact]
        public void PopStyleColor_Count()
        {
            ImGui.NewFrame();
            ImGui.PushStyleColor(ImGuiCol.Text, new Vector4F(1, 1, 1, 1));
            ImGui.PushStyleColor(ImGuiCol.TextDisabled, new Vector4F(0.5f, 0.5f, 0.5f, 1));
            ImGui.PopStyleColor(2);
            ImGui.Render();
        }

        [Fact]
        public void PopStyleVar_Default()
        {
            ImGui.NewFrame();
            ImGui.PushStyleVar(ImGuiStyleVar.Alpha, 0.8f);
            ImGui.PopStyleVar();
            ImGui.Render();
        }

        [Fact]
        public void PopStyleVar_Count()
        {
            ImGui.NewFrame();
            ImGui.PushStyleVar(ImGuiStyleVar.Alpha, 0.8f);
            ImGui.PushStyleVar(ImGuiStyleVar.WindowPadding, new Vector2F(10, 10));
            ImGui.PopStyleVar(2);
            ImGui.Render();
        }

        [Fact]
        public void PopTextWrapPos()
        {
            ImGui.NewFrame();
            ImGui.PushTextWrapPos(200.0f);
            ImGui.PopTextWrapPos();
            ImGui.Render();
        }

        [Fact]
        public void ProgressBar_Fraction()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestProgressBar");
            ImGui.ProgressBar(0.5f);
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void ProgressBar_Fraction_Size()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestProgressBar2");
            ImGui.ProgressBar(0.5f, new Vector2F(100, 20));
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void ProgressBar_Fraction_Size_Overlay()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestProgressBar3");
            ImGui.ProgressBar(0.5f, new Vector2F(100, 20), "50%");
            ImGui.End();
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
            ImGui.PushClipRect(new Vector2F(0, 0), new Vector2F(100, 100), true);
            ImGui.PopClipRect();
            ImGui.Render();
        }

        [Fact]
        public void PushId_String()
        {
            ImGui.NewFrame();
            ImGui.PushId("test_id");
            ImGui.PopId();
            ImGui.Render();
        }

        [Fact]
        public void PushItemWidth()
        {
            ImGui.NewFrame();
            ImGui.PushItemWidth(300.0f);
            ImGui.PopItemWidth();
            ImGui.Render();
        }

        [Fact]
        public void PushStyleColor_Uint()
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
        public void PushTextWrapPos_Default()
        {
            ImGui.NewFrame();
            ImGui.PushTextWrapPos();
            ImGui.PopTextWrapPos();
            ImGui.Render();
        }

        [Fact]
        public void PushTextWrapPos_Float()
        {
            ImGui.NewFrame();
            ImGui.PushTextWrapPos(300.0f);
            ImGui.PopTextWrapPos();
            ImGui.Render();
        }

        [Fact]
        public void Separator()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestSeparator");
            ImGui.Separator();
            ImGui.End();
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
        public void SetKeyboardFocusHere_Default()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestKF1");
            ImGui.SetKeyboardFocusHere();
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void SetKeyboardFocusHere_Offset()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestKF2");
            ImGui.SetKeyboardFocusHere(1);
            ImGui.End();
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
        public void SetNextItemOpen_Default()
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
            ImGui.SetNextItemWidth(200.0f);
            ImGui.Render();
        }

        [Fact]
        public void SetNextWindowBgAlpha()
        {
            ImGui.NewFrame();
            ImGui.SetNextWindowBgAlpha(0.5f);
            ImGui.Begin("TestBgAlpha");
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void SetNextWindowCollapsed_Default()
        {
            ImGui.NewFrame();
            ImGui.SetNextWindowCollapsed(true);
            ImGui.Begin("TestCollapsed1");
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void SetNextWindowCollapsed_WithCond()
        {
            ImGui.NewFrame();
            ImGui.SetNextWindowCollapsed(true, ImGuiCond.Once);
            ImGui.Begin("TestCollapsed2");
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void SetNextWindowContentSize()
        {
            ImGui.NewFrame();
            ImGui.SetNextWindowContentSize(new Vector2F(400, 300));
            ImGui.Begin("TestContentSize");
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void SetNextWindowDockId_Default()
        {
            ImGui.NewFrame();
            ImGui.SetNextWindowDockId(0u);
            ImGui.Begin("TestDock1");
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void SetNextWindowDockId_WithCond()
        {
            ImGui.NewFrame();
            ImGui.SetNextWindowDockId(0u, ImGuiCond.Once);
            ImGui.Begin("TestDock2");
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void SetNextWindowFocus()
        {
            ImGui.NewFrame();
            ImGui.SetNextWindowFocus();
            ImGui.Begin("TestFocus");
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void SetNextWindowPos_Default()
        {
            ImGui.NewFrame();
            ImGui.SetNextWindowPos(new Vector2F(100, 100));
            ImGui.Begin("TestPos1");
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void SetNextWindowPos_WithCond()
        {
            ImGui.NewFrame();
            ImGui.SetNextWindowPos(new Vector2F(100, 100), ImGuiCond.Once);
            ImGui.Begin("TestPos2");
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void SetNextWindowPos_WithCondPivot()
        {
            ImGui.NewFrame();
            ImGui.SetNextWindowPos(new Vector2F(100, 100), ImGuiCond.Once, new Vector2F(0.5f, 0.5f));
            ImGui.Begin("TestPos3");
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void SetNextWindowScroll()
        {
            ImGui.NewFrame();
            ImGui.SetNextWindowScroll(new Vector2F(10, 20));
            ImGui.Begin("TestScroll");
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void SetNextWindowSize_Default()
        {
            ImGui.NewFrame();
            ImGui.SetNextWindowSize(new Vector2F(300, 200));
            ImGui.Begin("TestSize1");
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void SetNextWindowSize_WithCond()
        {
            ImGui.NewFrame();
            ImGui.SetNextWindowSize(new Vector2F(300, 200), ImGuiCond.Once);
            ImGui.Begin("TestSize2");
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void SetNextWindowSizeConstraints_Default()
        {
            ImGui.NewFrame();
            ImGui.SetNextWindowSizeConstraints(new Vector2F(100, 100), new Vector2F(500, 500));
            ImGui.Begin("TestConstraints1");
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void SetNextWindowSizeConstraints_WithCallback()
        {
            ImGui.NewFrame();
            ImGui.SetNextWindowSizeConstraints(new Vector2F(100, 100), new Vector2F(500, 500), null);
            ImGui.Begin("TestConstraints2");
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void SetNextWindowSizeConstraints_WithCallbackData()
        {
            ImGui.NewFrame();
            ImGui.SetNextWindowSizeConstraints(new Vector2F(100, 100), new Vector2F(500, 500), null, IntPtr.Zero);
            ImGui.Begin("TestConstraints3");
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void SetNextWindowViewport()
        {
            ImGui.NewFrame();
            ImGui.SetNextWindowViewport(0u);
            ImGui.Begin("TestViewport");
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void SetScrollFromPosX_Default()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestScrollX1");
            ImGui.SetScrollFromPosX(50.0f);
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void SetScrollFromPosX_WithRatio()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestScrollX2");
            ImGui.SetScrollFromPosX(50.0f, 0.3f);
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void SetScrollFromPosY_Default()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestScrollY1");
            ImGui.SetScrollFromPosY(50.0f);
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void SetScrollFromPosY_WithRatio()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestScrollY2");
            ImGui.SetScrollFromPosY(50.0f, 0.3f);
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void SetScrollHereX_Default()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestHereX1");
            ImGui.SetScrollHereX();
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void SetScrollHereX_WithRatio()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestHereX2");
            ImGui.SetScrollHereX(0.3f);
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void SetScrollHereY_Default()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestHereY1");
            ImGui.SetScrollHereY();
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void SetScrollHereY_WithRatio()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestHereY2");
            ImGui.SetScrollHereY(0.3f);
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void SetScrollX()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestSetScrollX");
            ImGui.SetScrollX(10.0f);
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void SetScrollY()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestSetScrollY");
            ImGui.SetScrollY(20.0f);
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void SetTabItemClosed()
        {
            ImGui.NewFrame();
            ImGui.SetTabItemClosed("test_tab");
            ImGui.Render();
        }

        [Fact]
        public void SetWindowCollapsed_Bool()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWC1");
            ImGui.SetWindowCollapsed(true);
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void SetWindowCollapsed_Bool_Cond()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWC2");
            ImGui.SetWindowCollapsed(true, ImGuiCond.Once);
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void SetWindowCollapsed_Str_Bool()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWC3");
            ImGui.SetWindowCollapsed("TestWC3", true);
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void SetWindowCollapsed_Str_Bool_Cond()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWC4");
            ImGui.SetWindowCollapsed("TestWC4", true, ImGuiCond.Once);
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void SetWindowFocus_Default()
        {
            ImGui.NewFrame();
            ImGui.SetWindowFocus();
            ImGui.Render();
        }

        [Fact]
        public void SetWindowFocus_Str()
        {
            ImGui.NewFrame();
            ImGui.SetWindowFocus("TestWinFocus");
            ImGui.Render();
        }

        [Fact]
        public void SetWindowFontScale()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestFontScale");
            ImGui.SetWindowFontScale(1.2f);
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void SetWindowPos_Vec2()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWP1");
            ImGui.SetWindowPos(new Vector2F(50, 50));
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void SetWindowPos_Vec2_Cond()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWP2");
            ImGui.SetWindowPos(new Vector2F(50, 50), ImGuiCond.Once);
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void SetWindowPos_Str_Vec2()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWP3");
            ImGui.SetWindowPos("TestWP3", new Vector2F(50, 50));
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void SetWindowPos_Str_Vec2_Cond()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWP4");
            ImGui.SetWindowPos("TestWP4", new Vector2F(50, 50), ImGuiCond.Once);
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void SetWindowSize_Vec2()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWS1");
            ImGui.SetWindowSize(new Vector2F(300, 200));
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void SetWindowSize_Vec2_Cond()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWS2");
            ImGui.SetWindowSize(new Vector2F(300, 200), ImGuiCond.Once);
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void SetWindowSize_Str_Vec2()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWS3");
            ImGui.SetWindowSize("TestWS3", new Vector2F(300, 200));
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void SetWindowSize_Str_Vec2_Cond()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWS4");
            ImGui.SetWindowSize("TestWS4", new Vector2F(300, 200), ImGuiCond.Once);
            ImGui.End();
            ImGui.Render();
        }

        [Fact]
        public void ResetMouseDragDelta_Default()
        {
            ImGui.NewFrame();
            ImGui.ResetMouseDragDelta();
            ImGui.Render();
        }

        [Fact]
        public void RadioButton_Label_Active()
        {
            ImGui.NewFrame();
            bool result = ImGui.RadioButton("test_rb", true);
            ImGui.Render();
        }
    }
}
