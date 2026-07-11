using System;
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// The im gui native test class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public class ImGuiP7NativeTest : IDisposable
    {
        /// <summary>
        /// The ctx
        /// </summary>
        private readonly IntPtr _ctx;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImGuiP7NativeTest"/> class
        /// </summary>
        public ImGuiP7NativeTest()
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
        /// Tests that menu item
        /// </summary>
        [Fact]
        public void MenuItem()
        {
            ImGui.NewFrame();
            bool selected = false;
            ImGui.MenuItem("Test", "Ctrl+T", ref selected, true);
            ImGui.Render();
        }

        /// <summary>
        /// Tests that new frame and render
        /// </summary>
        [Fact]
        public void NewFrame_And_Render()
        {
            ImGui.NewFrame();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that new line
        /// </summary>
        [Fact]
        public void NewLine()
        {
            ImGui.NewFrame();
            ImGui.NewLine();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that next column
        /// </summary>
        [Fact]
        public void NextColumn()
        {
            ImGui.NewFrame();
            ImGui.NextColumn();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that open popup str
        /// </summary>
        [Fact]
        public void OpenPopup_Str()
        {
            ImGui.NewFrame();
            ImGui.OpenPopup("Test");
            ImGui.Render();
        }

        /// <summary>
        /// Tests that open popup str with flags
        /// </summary>
        [Fact]
        public void OpenPopup_StrWithFlags()
        {
            ImGui.NewFrame();
            ImGui.OpenPopup("Test", ImGuiPopupFlags.None);
            ImGui.Render();
        }

        /// <summary>
        /// Tests that open popup u 32
        /// </summary>
        [Fact]
        public void OpenPopup_U32()
        {
            ImGui.NewFrame();
            ImGui.OpenPopup(123u);
            ImGui.Render();
        }

        /// <summary>
        /// Tests that open popup u 32 with flags
        /// </summary>
        [Fact]
        public void OpenPopup_U32WithFlags()
        {
            ImGui.NewFrame();
            ImGui.OpenPopup(123u, ImGuiPopupFlags.None);
            ImGui.Render();
        }

        /// <summary>
        /// Tests that open popup on item click
        /// </summary>
        [Fact]
        public void OpenPopupOnItemClick()
        {
            ImGui.NewFrame();
            ImGui.OpenPopupOnItemClick();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that open popup on item click str
        /// </summary>
        [Fact]
        public void OpenPopupOnItemClick_Str()
        {
            ImGui.NewFrame();
            ImGui.OpenPopupOnItemClick("Test");
            ImGui.Render();
        }

        /// <summary>
        /// Tests that open popup on item click str with flags
        /// </summary>
        [Fact]
        public void OpenPopupOnItemClick_StrWithFlags()
        {
            ImGui.NewFrame();
            ImGui.OpenPopupOnItemClick("Test", ImGuiPopupFlags.None);
            ImGui.Render();
        }

        /// <summary>
        /// Tests that pop allow keyboard focus
        /// </summary>
        [Fact]
        public void PopAllowKeyboardFocus()
        {
            ImGui.NewFrame();
            ImGui.PushAllowKeyboardFocus(true);
            ImGui.PopAllowKeyboardFocus();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that pop button repeat
        /// </summary>
        [Fact]
        public void PopButtonRepeat()
        {
            ImGui.NewFrame();
            ImGui.PushButtonRepeat(true);
            ImGui.PopButtonRepeat();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that pop clip rect
        /// </summary>
        [Fact]
        public void PopClipRect()
        {
            ImGui.NewFrame();
            ImGui.PushClipRect(new Vector2F(), new Vector2F(100, 100), false);
            ImGui.PopClipRect();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that pop id
        /// </summary>
        [Fact]
        public void PopId()
        {
            ImGui.NewFrame();
            ImGui.PushId("test");
            ImGui.PopId();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that pop item width
        /// </summary>
        [Fact]
        public void PopItemWidth()
        {
            ImGui.NewFrame();
            ImGui.PushItemWidth(100f);
            ImGui.PopItemWidth();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that pop style color
        /// </summary>
        [Fact]
        public void PopStyleColor()
        {
            ImGui.NewFrame();
            ImGui.PushStyleColor(ImGuiCol.Text, new Vector4F(1, 1, 1, 1));
            ImGui.PopStyleColor();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that pop style color with count
        /// </summary>
        [Fact]
        public void PopStyleColor_WithCount()
        {
            ImGui.NewFrame();
            ImGui.PushStyleColor(ImGuiCol.Text, new Vector4F(1, 1, 1, 1));
            ImGui.PushStyleColor(ImGuiCol.Text, new Vector4F(0, 0, 0, 1));
            ImGui.PopStyleColor(2);
            ImGui.Render();
        }

        /// <summary>
        /// Tests that pop style var
        /// </summary>
        [Fact]
        public void PopStyleVar()
        {
            ImGui.NewFrame();
            ImGui.PushStyleVar(ImGuiStyleVar.Alpha, 0.5f);
            ImGui.PopStyleVar();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that pop style var with count
        /// </summary>
        [Fact]
        public void PopStyleVar_WithCount()
        {
            ImGui.NewFrame();
            ImGui.PushStyleVar(ImGuiStyleVar.Alpha, 0.5f);
            ImGui.PushStyleVar(ImGuiStyleVar.Alpha, 0.8f);
            ImGui.PopStyleVar(2);
            ImGui.Render();
        }

        /// <summary>
        /// Tests that pop text wrap pos
        /// </summary>
        [Fact]
        public void PopTextWrapPos()
        {
            ImGui.NewFrame();
            ImGui.PushTextWrapPos();
            ImGui.PopTextWrapPos();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that progress bar
        /// </summary>
        [Fact]
        public void ProgressBar()
        {
            ImGui.NewFrame();
            ImGui.ProgressBar(0.5f);
            ImGui.Render();
        }

        /// <summary>
        /// Tests that progress bar with size
        /// </summary>
        [Fact]
        public void ProgressBar_WithSize()
        {
            ImGui.NewFrame();
            ImGui.ProgressBar(0.5f, new Vector2F(100, 20));
            ImGui.Render();
        }

        /// <summary>
        /// Tests that progress bar with size overlay
        /// </summary>
        [Fact]
        public void ProgressBar_WithSizeOverlay()
        {
            ImGui.NewFrame();
            ImGui.ProgressBar(0.5f, new Vector2F(100, 20), "50%");
            ImGui.Render();
        }

        /// <summary>
        /// Tests that push allow keyboard focus
        /// </summary>
        [Fact]
        public void PushAllowKeyboardFocus()
        {
            ImGui.NewFrame();
            ImGui.PushAllowKeyboardFocus(true);
            ImGui.PopAllowKeyboardFocus();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that push button repeat
        /// </summary>
        [Fact]
        public void PushButtonRepeat()
        {
            ImGui.NewFrame();
            ImGui.PushButtonRepeat(true);
            ImGui.PopButtonRepeat();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that push clip rect
        /// </summary>
        [Fact]
        public void PushClipRect()
        {
            ImGui.NewFrame();
            ImGui.PushClipRect(new Vector2F(), new Vector2F(100, 100), false);
            ImGui.PopClipRect();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that push id str
        /// </summary>
        [Fact]
        public void PushId_Str()
        {
            ImGui.NewFrame();
            ImGui.PushId("TestId");
            ImGui.PopId();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that push item width
        /// </summary>
        [Fact]
        public void PushItemWidth()
        {
            ImGui.NewFrame();
            ImGui.PushItemWidth(200f);
            ImGui.PopItemWidth();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that push style color u 32
        /// </summary>
        [Fact]
        public void PushStyleColor_U32()
        {
            ImGui.NewFrame();
            ImGui.PushStyleColor(ImGuiCol.Text, 0xFFFFFFFF);
            ImGui.PopStyleColor();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that push style color vec 4
        /// </summary>
        [Fact]
        public void PushStyleColor_Vec4()
        {
            ImGui.NewFrame();
            ImGui.PushStyleColor(ImGuiCol.Text, new Vector4F(1, 1, 1, 1));
            ImGui.PopStyleColor();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that push style var float
        /// </summary>
        [Fact]
        public void PushStyleVar_Float()
        {
            ImGui.NewFrame();
            ImGui.PushStyleVar(ImGuiStyleVar.Alpha, 0.5f);
            ImGui.PopStyleVar();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that push style var vec 2
        /// </summary>
        [Fact]
        public void PushStyleVar_Vec2()
        {
            ImGui.NewFrame();
            ImGui.PushStyleVar(ImGuiStyleVar.WindowPadding, new Vector2F(10, 10));
            ImGui.PopStyleVar();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that push text wrap pos
        /// </summary>
        [Fact]
        public void PushTextWrapPos()
        {
            ImGui.NewFrame();
            ImGui.PushTextWrapPos();
            ImGui.PopTextWrapPos();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that push text wrap pos with value
        /// </summary>
        [Fact]
        public void PushTextWrapPos_WithValue()
        {
            ImGui.NewFrame();
            ImGui.PushTextWrapPos(200f);
            ImGui.PopTextWrapPos();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that radio button
        /// </summary>
        [Fact]
        public void RadioButton()
        {
            ImGui.NewFrame();
            ImGui.RadioButton("Test", true);
            ImGui.Render();
        }

        /// <summary>
        /// Tests that render
        /// </summary>
        [Fact]
        public void Render()
        {
            ImGui.NewFrame();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that separator
        /// </summary>
        [Fact]
        public void Separator()
        {
            ImGui.NewFrame();
            ImGui.Separator();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that set color edit options
        /// </summary>
        [Fact]
        public void SetColorEditOptions()
        {
            ImGui.NewFrame();
            ImGui.SetColorEditOptions(ImGuiColorEditFlags.None);
            ImGui.Render();
        }

        /// <summary>
        /// Tests that set current context
        /// </summary>
        [Fact]
        public void SetCurrentContext()
        {
            ImGui.SetCurrentContext(_ctx);
        }

        /// <summary>
        /// Tests that set keyboard focus here
        /// </summary>
        [Fact]
        public void SetKeyboardFocusHere()
        {
            ImGui.NewFrame();
            ImGui.SetKeyboardFocusHere();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that set keyboard focus here with offset
        /// </summary>
        [Fact]
        public void SetKeyboardFocusHere_WithOffset()
        {
            ImGui.NewFrame();
            ImGui.SetKeyboardFocusHere(1);
            ImGui.Render();
        }

        /// <summary>
        /// Tests that set mouse cursor
        /// </summary>
        [Fact]
        public void SetMouseCursor()
        {
            ImGui.NewFrame();
            ImGui.SetMouseCursor(ImGuiMouseCursor.Arrow);
            ImGui.Render();
        }

        /// <summary>
        /// Tests that set next frame want capture keyboard
        /// </summary>
        [Fact]
        public void SetNextFrameWantCaptureKeyboard()
        {
            ImGui.NewFrame();
            ImGui.SetNextFrameWantCaptureKeyboard(true);
            ImGui.Render();
        }

        /// <summary>
        /// Tests that set next frame want capture mouse
        /// </summary>
        [Fact]
        public void SetNextFrameWantCaptureMouse()
        {
            ImGui.NewFrame();
            ImGui.SetNextFrameWantCaptureMouse(true);
            ImGui.Render();
        }

        /// <summary>
        /// Tests that set next item open
        /// </summary>
        [Fact]
        public void SetNextItemOpen()
        {
            ImGui.NewFrame();
            ImGui.SetNextItemOpen(true);
            ImGui.Render();
        }

        /// <summary>
        /// Tests that set next item open with cond
        /// </summary>
        [Fact]
        public void SetNextItemOpen_WithCond()
        {
            ImGui.NewFrame();
            ImGui.SetNextItemOpen(true, ImGuiCond.Once);
            ImGui.Render();
        }

        /// <summary>
        /// Tests that set next item width
        /// </summary>
        [Fact]
        public void SetNextItemWidth()
        {
            ImGui.NewFrame();
            ImGui.SetNextItemWidth(100f);
            ImGui.Render();
        }

        /// <summary>
        /// Tests that set next window bg alpha
        /// </summary>
        [Fact]
        public void SetNextWindowBgAlpha()
        {
            ImGui.NewFrame();
            ImGui.SetNextWindowBgAlpha(0.5f);
            ImGui.Render();
        }

        /// <summary>
        /// Tests that set next window content size
        /// </summary>
        [Fact]
        public void SetNextWindowContentSize()
        {
            ImGui.NewFrame();
            ImGui.SetNextWindowContentSize(new Vector2F(200, 100));
            ImGui.Render();
        }

        /// <summary>
        /// Tests that set next window focus
        /// </summary>
        [Fact]
        public void SetNextWindowFocus()
        {
            ImGui.NewFrame();
            ImGui.SetNextWindowFocus();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that set next window pos
        /// </summary>
        [Fact]
        public void SetNextWindowPos()
        {
            ImGui.NewFrame();
            ImGui.SetNextWindowPos(new Vector2F(100, 100));
            ImGui.Render();
        }

        /// <summary>
        /// Tests that set next window pos with cond
        /// </summary>
        [Fact]
        public void SetNextWindowPos_WithCond()
        {
            ImGui.NewFrame();
            ImGui.SetNextWindowPos(new Vector2F(100, 100), ImGuiCond.Once);
            ImGui.Render();
        }

        /// <summary>
        /// Tests that set next window pos with cond pivot
        /// </summary>
        [Fact]
        public void SetNextWindowPos_WithCondPivot()
        {
            ImGui.NewFrame();
            ImGui.SetNextWindowPos(new Vector2F(100, 100), ImGuiCond.Once, new Vector2F(0.5f, 0.5f));
            ImGui.Render();
        }

        /// <summary>
        /// Tests that set next window scroll
        /// </summary>
        [Fact]
        public void SetNextWindowScroll()
        {
            ImGui.NewFrame();
            ImGui.SetNextWindowScroll(new Vector2F(0, 10));
            ImGui.Render();
        }

        /// <summary>
        /// Tests that set next window size
        /// </summary>
        [Fact]
        public void SetNextWindowSize()
        {
            ImGui.NewFrame();
            ImGui.SetNextWindowSize(new Vector2F(400, 300));
            ImGui.Render();
        }

        /// <summary>
        /// Tests that set next window size with cond
        /// </summary>
        [Fact]
        public void SetNextWindowSize_WithCond()
        {
            ImGui.NewFrame();
            ImGui.SetNextWindowSize(new Vector2F(400, 300), ImGuiCond.Once);
            ImGui.Render();
        }

        /// <summary>
        /// Tests that set next window viewport
        /// </summary>
        [Fact]
        public void SetNextWindowViewport()
        {
            ImGui.NewFrame();
            ImGui.SetNextWindowViewport(1u);
            ImGui.Render();
        }

        /// <summary>
        /// Tests that set scroll from pos x
        /// </summary>
        [Fact]
        public void SetScrollFromPosX()
        {
            ImGui.NewFrame();
            ImGui.SetScrollFromPosX(50f);
            ImGui.Render();
        }

        /// <summary>
        /// Tests that set scroll from pos x with ratio
        /// </summary>
        [Fact]
        public void SetScrollFromPosX_WithRatio()
        {
            ImGui.NewFrame();
            ImGui.SetScrollFromPosX(50f, 0.3f);
            ImGui.Render();
        }

        /// <summary>
        /// Tests that set scroll from pos y
        /// </summary>
        [Fact]
        public void SetScrollFromPosY()
        {
            ImGui.NewFrame();
            ImGui.SetScrollFromPosY(50f);
            ImGui.Render();
        }

        /// <summary>
        /// Tests that set scroll from pos y with ratio
        /// </summary>
        [Fact]
        public void SetScrollFromPosY_WithRatio()
        {
            ImGui.NewFrame();
            ImGui.SetScrollFromPosY(50f, 0.3f);
            ImGui.Render();
        }

        /// <summary>
        /// Tests that set scroll here x
        /// </summary>
        [Fact]
        public void SetScrollHereX()
        {
            ImGui.NewFrame();
            ImGui.SetScrollHereX();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that set scroll here x with ratio
        /// </summary>
        [Fact]
        public void SetScrollHereX_WithRatio()
        {
            ImGui.NewFrame();
            ImGui.SetScrollHereX(0.3f);
            ImGui.Render();
        }

        /// <summary>
        /// Tests that set scroll here y
        /// </summary>
        [Fact]
        public void SetScrollHereY()
        {
            ImGui.NewFrame();
            ImGui.SetScrollHereY();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that set scroll here y with ratio
        /// </summary>
        [Fact]
        public void SetScrollHereY_WithRatio()
        {
            ImGui.NewFrame();
            ImGui.SetScrollHereY(0.3f);
            ImGui.Render();
        }

        /// <summary>
        /// Tests that set scroll x
        /// </summary>
        [Fact]
        public void SetScrollX()
        {
            ImGui.NewFrame();
            ImGui.SetScrollX(10f);
            ImGui.Render();
        }

        /// <summary>
        /// Tests that set scroll y
        /// </summary>
        [Fact]
        public void SetScrollY()
        {
            ImGui.NewFrame();
            ImGui.SetScrollY(10f);
            ImGui.Render();
        }

        /// <summary>
        /// Tests that set window focus
        /// </summary>
        [Fact]
        public void SetWindowFocus()
        {
            ImGui.NewFrame();
            ImGui.SetWindowFocus();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that set window font scale
        /// </summary>
        [Fact]
        public void SetWindowFontScale()
        {
            ImGui.NewFrame();
            ImGui.SetWindowFontScale(1.5f);
            ImGui.Render();
        }

        /// <summary>
        /// Tests that set window pos
        /// </summary>
        [Fact]
        public void SetWindowPos()
        {
            ImGui.NewFrame();
            ImGui.SetWindowPos(new Vector2F(100, 100));
            ImGui.Render();
        }

        /// <summary>
        /// Tests that set window pos with cond
        /// </summary>
        [Fact]
        public void SetWindowPos_WithCond()
        {
            ImGui.NewFrame();
            ImGui.SetWindowPos(new Vector2F(100, 100), ImGuiCond.Once);
            ImGui.Render();
        }

        /// <summary>
        /// Tests that set window size
        /// </summary>
        [Fact]
        public void SetWindowSize()
        {
            ImGui.NewFrame();
            ImGui.SetWindowSize(new Vector2F(400, 300));
            ImGui.Render();
        }

        /// <summary>
        /// Tests that set window size with cond
        /// </summary>
        [Fact]
        public void SetWindowSize_WithCond()
        {
            ImGui.NewFrame();
            ImGui.SetWindowSize(new Vector2F(400, 300), ImGuiCond.Once);
            ImGui.Render();
        }

        /// <summary>
        /// Tests that reset mouse drag delta
        /// </summary>
        [Fact]
        public void ResetMouseDragDelta()
        {
            ImGui.NewFrame();
            ImGui.ResetMouseDragDelta();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that set next window collapsed
        /// </summary>
        [Fact]
        public void SetNextWindowCollapsed()
        {
            ImGui.NewFrame();
            ImGui.SetNextWindowCollapsed(true);
            ImGui.Render();
        }

        /// <summary>
        /// Tests that set next window collapsed with cond
        /// </summary>
        [Fact]
        public void SetNextWindowCollapsed_WithCond()
        {
            ImGui.NewFrame();
            ImGui.SetNextWindowCollapsed(true, ImGuiCond.Once);
            ImGui.Render();
        }

        /// <summary>
        /// Tests that set next window dock id
        /// </summary>
        [Fact]
        public void SetNextWindowDockId()
        {
            ImGui.NewFrame();
            ImGui.SetNextWindowDockId(1u);
            ImGui.Render();
        }

        /// <summary>
        /// Tests that set next window dock id with cond
        /// </summary>
        [Fact]
        public void SetNextWindowDockId_WithCond()
        {
            ImGui.NewFrame();
            ImGui.SetNextWindowDockId(1u, ImGuiCond.Once);
            ImGui.Render();
        }

        /// <summary>
        /// Tests that set next window size constraints
        /// </summary>
        [Fact]
        public void SetNextWindowSizeConstraints()
        {
            ImGui.NewFrame();
            ImGui.SetNextWindowSizeConstraints(new Vector2F(100, 100), new Vector2F(500, 500));
            ImGui.Render();
        }

        /// <summary>
        /// Tests that set tab item closed
        /// </summary>
        [Fact]
        public void SetTabItemClosed()
        {
            ImGui.NewFrame();
            ImGui.SetTabItemClosed("TestTab");
            ImGui.Render();
        }

        /// <summary>
        /// Tests that set window collapsed
        /// </summary>
        [Fact]
        public void SetWindowCollapsed()
        {
            ImGui.NewFrame();
            ImGui.SetWindowCollapsed(true);
            ImGui.Render();
        }

        /// <summary>
        /// Tests that set window focus str
        /// </summary>
        [Fact]
        public void SetWindowFocus_Str()
        {
            ImGui.NewFrame();
            ImGui.SetWindowFocus("TestWindow");
            ImGui.Render();
        }

        /// <summary>
        /// Tests that set window pos str
        /// </summary>
        [Fact]
        public void SetWindowPos_Str()
        {
            ImGui.NewFrame();
            ImGui.SetWindowPos("TestWindow", new Vector2F(100, 100));
            ImGui.Render();
        }

        /// <summary>
        /// Tests that set window size str
        /// </summary>
        [Fact]
        public void SetWindowSize_Str()
        {
            ImGui.NewFrame();
            ImGui.SetWindowSize("TestWindow", new Vector2F(400, 300));
            ImGui.Render();
        }
    }
}
