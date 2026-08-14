// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Sdl2CoreCoverageTests.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using Alis.Core.Aspect.Math.Shapes.Point;
using Alis.Core.Aspect.Math.Shapes.Rectangle;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sdl2.Enums;
using Alis.Extension.Graphic.Sdl2.Structs;
using Alis.Extension.Graphic.Sdl2.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    ///     Coverage tests for core Sdl methods that do not require a video display
    /// </summary>
    public class Sdl2CoreCoverageTests
    {
        /// <summary>
        ///     Tests that video query functions behave without initializing video
        /// </summary>
        [RequireSdl2Fact]
        public void VideoQueries_DoNotRequireVideoInit()
        {
            int drivers = Sdl.GetNumVideoDrivers();
            Assert.True(drivers >= 0);
            string driver = Sdl.GetVideoDriver(0);
            if (drivers > 0)
            {
                Assert.NotNull(driver);
            }
            Assert.True(Sdl.GetNumVideoDisplays() >= -1);
            Sdl.GetCurrentVideoDriver();
            Sdl.GetDisplayName(0);
            RectangleI bounds;
            Sdl.GetDisplayBounds(0, out bounds);
            float dpi;
            Sdl.GetDisplayDpi(0, out dpi, out dpi, out dpi);
            DisplayMode mode;
            Sdl.GetDisplayMode(0, 0, out mode);
            Sdl.GetDisplayUsableBounds(0, out bounds);
            Sdl.GetNumDisplayModes(0);
            Sdl.GetDesktopDisplayMode(0, out mode);
            Sdl.GetCurrentDisplayMode(0, out mode);
            mode.w = 640;
            mode.h = 480;
            Sdl.GetClosestDisplayMode(0, ref mode, out mode);
        }

        /// <summary>
        ///     Tests that clipboard functions do not crash without video
        /// </summary>
        [RequireSdl2Fact]
        public void Clipboard_Functions_DoNotThrow()
        {
            Sdl.HasClipboardText();
            Sdl.GetClipboardText();
            Sdl.SetClipboardText("alis sdl2 coverage");
        }

        /// <summary>
        ///     Tests that gl attribute functions do not crash without video
        /// </summary>
        [RequireSdl2Fact]
        public void GlAttributes_DoNotRequireVideoInit()
        {
            Sdl.ResetAttributes();
            Sdl.GetCurrentWindow();
            Sdl.GetCurrentContext();
            int value;
            Sdl.GetAttribute(Attr.SdlGlRedSize, out value);
            Sdl.GetSwapInterval();
            Sdl.SetAttributeByInt(Attr.SdlGlRedSize, 8);
            Sdl.SetAttributeByProfile(Attr.SdlGlContextProfileMask, Profiles.SdlGlContextProfileCore);
            Sdl.SetSwapInterval(1);
            Sdl.GetProcAddress("glGetString");
            Sdl.ExtensionSupported("GL_EXT_texture_filter_anisotropic");
            Sdl.MakeCurrent(IntPtr.Zero, IntPtr.Zero);
            int w;
            int h;
            Sdl.GetDrawableSize(IntPtr.Zero, out w, out h);
            Sdl.DeleteContext(IntPtr.Zero);
            float texW;
            float texH;
            Sdl.BindTexture(IntPtr.Zero, out texW, out texH);
            Sdl.UnbindTexture(IntPtr.Zero);
        }

        /// <summary>
        ///     Tests that window getter functions accept a null window
        /// </summary>
        [RequireSdl2Fact]
        public void WindowGetters_WithNullWindow_DoNotCrash()
        {
            Sdl.GetWindowTitle(IntPtr.Zero);
            Sdl.GetWindowFlags(IntPtr.Zero);
            Sdl.GetWindowId(IntPtr.Zero);
            Sdl.GetWindowFromId(0);
            Sdl.GetWindowDisplayIndex(IntPtr.Zero);
            Sdl.GetWindowGrab(IntPtr.Zero);
            Sdl.GetWindowBrightness(IntPtr.Zero);
            float opacity;
            Sdl.GetWindowOpacity(IntPtr.Zero, out opacity);
            Sdl.GetWindowPixelFormat(IntPtr.Zero);
            ushort[] ramp = new ushort[256];
            Sdl.GetWindowGammaRamp(IntPtr.Zero, ramp, ramp, ramp);
            int maxW;
            int maxH;
            Sdl.GetWindowMaximumSize(IntPtr.Zero, out maxW, out maxH);
            Sdl.GetWindowMinimumSize(IntPtr.Zero, out maxW, out maxH);
            int x;
            int y;
            Sdl.GetWindowPosition(IntPtr.Zero, out x, out y);
            Sdl.GetWindowSize(IntPtr.Zero);
            Sdl.GetWindowSurface(IntPtr.Zero);
            DisplayMode mode;
            Sdl.GetWindowDisplayMode(IntPtr.Zero, out mode);
            Sdl.GetWindowData(IntPtr.Zero, "coverage");
        }

        /// <summary>
        ///     Tests that window setter functions accept a null window
        /// </summary>
        [RequireSdl2Fact]
        public void WindowSetters_WithNullWindow_DoNotCrash()
        {
            Sdl.SetWindowOpacity(IntPtr.Zero, 0.5f);
            Sdl.SetWindowModalFor(IntPtr.Zero, IntPtr.Zero);
            Sdl.SetWindowInputFocus(IntPtr.Zero);
            Sdl.SetWindowData(IntPtr.Zero, "coverage", IntPtr.Zero);
            DisplayMode mode = new DisplayMode();
            Sdl.SetWindowDisplayMode(IntPtr.Zero, ref mode);
            Sdl.SetWindowDisplayMode(IntPtr.Zero, IntPtr.Zero);
            Sdl.SetWindowFullscreen(IntPtr.Zero, 0);
            ushort[] ramp = new ushort[256];
            Sdl.SetWindowGammaRamp(IntPtr.Zero, ramp, ramp, ramp);
            Sdl.SetWindowGrab(IntPtr.Zero, false);
            Sdl.SetWindowIcon(IntPtr.Zero, IntPtr.Zero);
            Sdl.SetWindowMaximumSize(IntPtr.Zero, 0, 0);
            Sdl.SetWindowMinimumSize(IntPtr.Zero, 0, 0);
            Sdl.SetWindowPosition(IntPtr.Zero, 0, 0);
            Sdl.SetWindowSize(IntPtr.Zero, 0, 0);
            Sdl.SetWindowBordered(IntPtr.Zero, false);
            Sdl.SetWindowResizable(IntPtr.Zero, false);
            Sdl.SetWindowTitle(IntPtr.Zero, "coverage");
            Sdl.SetWindowBrightness(IntPtr.Zero, 1.0f);
            int top;
            int left;
            int bottom;
            int right;
            Sdl.GetWindowBordersSize(IntPtr.Zero, out top, out left, out bottom, out right);
        }

        /// <summary>
        ///     Tests that window action functions accept a null window
        /// </summary>
        [RequireSdl2Fact]
        public void WindowActions_WithNullWindow_DoNotCrash()
        {
            Sdl.HideWindow(IntPtr.Zero);
            Sdl.MaximizeWindow(IntPtr.Zero);
            Sdl.MinimizeWindow(IntPtr.Zero);
            Sdl.RaiseWindow(IntPtr.Zero);
            Sdl.RestoreWindow(IntPtr.Zero);
            Sdl.ShowWindow(IntPtr.Zero);
            Sdl.SwapWindow(IntPtr.Zero);
            Sdl.UpdateWindowSurface(IntPtr.Zero);
            Sdl.UpdateWindowSurfaceRects(IntPtr.Zero, new RectangleI[1], 1);
            Sdl.SetWindowHitTest(IntPtr.Zero, null, IntPtr.Zero);
            Sdl.DestroyWindow(IntPtr.Zero);
        }

        /// <summary>
        ///     Tests that renderer query functions accept a null renderer
        /// </summary>
        [RequireSdl2Fact]
        public void RendererQueries_WithNullRenderer_DoNotCrash()
        {
            Sdl.CreateRenderer(IntPtr.Zero, -1, Renderers.None);
            Sdl.CreateSoftwareRenderer(IntPtr.Zero);
            Sdl.DestroyRenderer(IntPtr.Zero);
            Sdl.DestroyTexture(IntPtr.Zero);
            Sdl.GetNumRenderDrivers();
            BlendModes blend;
            Sdl.GetRenderDrawBlendMode(IntPtr.Zero, out blend);
            byte r;
            byte g;
            byte b;
            byte a;
            Sdl.GetRenderDrawColor(IntPtr.Zero, out r, out g, out b, out a);
            RendererInfo info;
            Sdl.GetRenderDriverInfo(0, out info);
            Sdl.GetRenderer(IntPtr.Zero);
            Sdl.GetRendererInfo(IntPtr.Zero, out info);
            int w;
            int h;
            Sdl.GetRendererOutputSize(IntPtr.Zero, out w, out h);
            Sdl.GetTextureAlphaMod(IntPtr.Zero, out a);
            Sdl.GetTextureBlendMode(IntPtr.Zero, out blend);
            Sdl.GetTextureColorMod(IntPtr.Zero, out r, out g, out b);
            RectangleI rect = new RectangleI();
            IntPtr pixels;
            int pitch;
            Sdl.LockTexture(IntPtr.Zero, ref rect, out pixels, out pitch);
            uint format;
            int access;
            Sdl.QueryTexture(IntPtr.Zero, out format, out access, out w, out h);
        }

        /// <summary>
        ///     Tests that render drawing functions accept a null renderer
        /// </summary>
        [RequireSdl2Fact]
        public void RenderDrawing_WithNullRenderer_DoNotCrash()
        {
            Sdl.RenderClear(IntPtr.Zero);
            RectangleI rect = new RectangleI();
            Sdl.RenderCopy(IntPtr.Zero, IntPtr.Zero, ref rect, ref rect);
            Sdl.RenderCopy(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, ref rect);
            Sdl.RenderCopy(IntPtr.Zero, IntPtr.Zero, ref rect, IntPtr.Zero);
            Sdl.RenderCopy(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
            PointI center = new PointI();
            Sdl.RenderCopyEx(IntPtr.Zero, IntPtr.Zero, ref rect, ref rect, 0.0, ref center, RendererFlips.None);
            Sdl.RenderCopyEx(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, ref rect, 0.0, ref center, RendererFlips.None);
            Sdl.RenderCopyEx(IntPtr.Zero, IntPtr.Zero, ref rect, IntPtr.Zero, 0.0, ref center, RendererFlips.None);
            Sdl.RenderCopyEx(IntPtr.Zero, IntPtr.Zero, ref rect, ref rect, 0.0, IntPtr.Zero, RendererFlips.None);
            Sdl.RenderCopyEx(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, 0.0, ref center, RendererFlips.None);
            Sdl.RenderCopyEx(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, ref rect, 0.0, IntPtr.Zero, RendererFlips.None);
            Sdl.RenderCopyEx(IntPtr.Zero, IntPtr.Zero, ref rect, IntPtr.Zero, 0.0, IntPtr.Zero, RendererFlips.None);
            Sdl.RenderCopyEx(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, 0.0, IntPtr.Zero, RendererFlips.None);
            Sdl.RenderDrawLine(IntPtr.Zero, 0, 0, 1, 1);
            Sdl.RenderDrawLines(IntPtr.Zero, new PointI[1], 1);
            Sdl.RenderDrawPoint(IntPtr.Zero, 0, 0);
            Sdl.RenderDrawPoints(IntPtr.Zero, new PointI[1], 1);
            Sdl.RenderDrawRect(IntPtr.Zero, ref rect);
            Sdl.RenderDrawRect(IntPtr.Zero, IntPtr.Zero);
            Sdl.RenderDrawRects(IntPtr.Zero, new RectangleI[1], 1);
            Sdl.RenderFillRect(IntPtr.Zero, ref rect);
            Sdl.RenderFillRect(IntPtr.Zero, IntPtr.Zero);
            Sdl.RenderFillRects(IntPtr.Zero, new RectangleI[1], 1);
            RectangleF rectF = new RectangleF();
            Sdl.RenderCopyF(IntPtr.Zero, IntPtr.Zero, ref rect, ref rectF);
            Sdl.RenderCopyF(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, ref rectF);
            Sdl.RenderCopyF(IntPtr.Zero, IntPtr.Zero, ref rect, IntPtr.Zero);
            Sdl.RenderCopyF(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
            PointF centerF = new PointF();
            Sdl.RenderCopyEx(IntPtr.Zero, IntPtr.Zero, ref rect, ref rectF, 0.0, ref centerF, RendererFlips.None);
            Sdl.RenderCopyEx(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, ref rectF, 0.0, ref centerF, RendererFlips.None);
            Sdl.RenderCopyExF(IntPtr.Zero, IntPtr.Zero, ref rect, IntPtr.Zero, 0.0, ref centerF, RendererFlips.None);
            Sdl.RenderCopyExF(IntPtr.Zero, IntPtr.Zero, ref rect, ref rectF, 0.0, IntPtr.Zero, RendererFlips.None);
            Sdl.RenderCopyExF(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, 0.0, ref centerF, RendererFlips.None);
            Sdl.RenderCopyExF(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, ref rectF, 0.0, IntPtr.Zero, RendererFlips.None);
            Sdl.RenderCopyExF(IntPtr.Zero, IntPtr.Zero, ref rect, IntPtr.Zero, 0.0, IntPtr.Zero, RendererFlips.None);
            Sdl.RenderCopyExF(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, 0.0, IntPtr.Zero, RendererFlips.None);
            Sdl.RenderDrawPointF(IntPtr.Zero, 0.0f, 0.0f);
            Sdl.RenderDrawPointsF(IntPtr.Zero, new PointF[1], 1);
            Sdl.RenderDrawLineF(IntPtr.Zero, 0.0f, 0.0f, 1.0f, 1.0f);
            Sdl.RenderDrawLinesF(IntPtr.Zero, new PointF[1], 1);
            Sdl.RenderDrawRectF(IntPtr.Zero, ref rectF);
            Sdl.RenderDrawRectF(IntPtr.Zero, IntPtr.Zero);
            Sdl.RenderDrawRectsF(IntPtr.Zero, new RectangleF[1], 1);
            Sdl.RenderFillRectF(IntPtr.Zero, rectF);
            Sdl.RenderFillRectF(IntPtr.Zero, IntPtr.Zero);
            Sdl.RenderFillRectsF(IntPtr.Zero, new RectangleF[1], 1);
        }

        /// <summary>
        ///     Tests that render state functions accept a null renderer
        /// </summary>
        [RequireSdl2Fact]
        public void RenderState_WithNullRenderer_DoNotCrash()
        {
            RectangleI rect = new RectangleI();
            Sdl.RenderGetClipRect(IntPtr.Zero, out rect);
            int w;
            int h;
            Sdl.RenderGetLogicalSize(IntPtr.Zero, out w, out h);
            float scaleX;
            float scaleY;
            Sdl.RenderGetScale(IntPtr.Zero, out scaleX, out scaleY);
            Sdl.RenderGetViewport(IntPtr.Zero, out rect);
            Sdl.RenderPresent(IntPtr.Zero);
            Sdl.RenderReadPixels(IntPtr.Zero, ref rect, 0, IntPtr.Zero, 0);
            Sdl.RenderSetClipRect(IntPtr.Zero, ref rect);
            Sdl.RenderSetClipRect(IntPtr.Zero, IntPtr.Zero);
            Sdl.RenderSetLogicalSize(IntPtr.Zero, 1, 1);
            Sdl.RenderSetScale(IntPtr.Zero, 1.0f, 1.0f);
            Sdl.RenderSetIntegerScale(IntPtr.Zero, false);
            Sdl.RenderSetViewport(IntPtr.Zero, ref rect);
            Sdl.SetRenderDrawBlendMode(IntPtr.Zero, BlendModes.None);
            Sdl.SetRenderDrawColor(IntPtr.Zero, 0, 0, 0, 0);
            Sdl.SetRenderTarget(IntPtr.Zero, IntPtr.Zero);
            Sdl.SetTextureAlphaMod(IntPtr.Zero, 0);
            Sdl.SetTextureBlendMode(IntPtr.Zero, BlendModes.None);
            Sdl.SetTextureColorMod(IntPtr.Zero, 0, 0, 0);
            Sdl.UpdateTexture(IntPtr.Zero, ref rect, IntPtr.Zero, 0);
            Sdl.UpdateTexture(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, 0);
            Sdl.UpdateTexture(IntPtr.Zero, IntPtr.Zero, new byte[4], 4);
            Sdl.RenderTargetSupported(IntPtr.Zero);
            Sdl.RenderIsClipEnabled(IntPtr.Zero);
            Sdl.CreateTexture(IntPtr.Zero, 0, 0, 1, 1);
            Sdl.CreateTextureFromSurface(IntPtr.Zero, IntPtr.Zero);
            Sdl.UnlockTexture(IntPtr.Zero);
        }

        /// <summary>
        ///     Tests that keyboard functions do not crash without video
        /// </summary>
        [RequireSdl2Fact]
        public void Keyboard_Functions_DoNotCrash()
        {
            Sdl.GetKeyboardFocus();
            int numKeys;
            Sdl.GetKeyboardState(out numKeys);
            Sdl.GetModState();
            Sdl.SetModState(KeyMods.None);
            Sdl.StartTextInput();
            Sdl.IsTextInputActive();
            Sdl.StopTextInput();
            RectangleI rect = new RectangleI();
            Sdl.SetTextInputRect(ref rect);
            Sdl.HasScreenKeyboardSupport();
            Sdl.IsScreenKeyboardShown(IntPtr.Zero);
        }

        /// <summary>
        ///     Tests that mouse functions do not crash without video
        /// </summary>
        [RequireSdl2Fact]
        public void Mouse_Functions_DoNotCrash()
        {
            Sdl.GetMouseFocus();
            int x;
            int y;
            Sdl.GetMouseStateOutXAndY(out x, out y);
            Sdl.GetMouseStateXAndYOut(IntPtr.Zero, out y);
            Sdl.GetMouseStateXOutAndY(out x, IntPtr.Zero);
            Sdl.GetMouseStateToXAndY(IntPtr.Zero, IntPtr.Zero);
            Sdl.GetGlobalMouseStateOutXAndOutY(out x, out y);
            Sdl.GetGlobalMouseStateXAndY(IntPtr.Zero, IntPtr.Zero);
            Sdl.GetRelativeMouseState(out x, out y);
            Sdl.SetRelativeMouseMode(false);
            Sdl.GetRelativeMouseMode();
            Sdl.CaptureMouse(false);
            Sdl.WarpMouseGlobal(0, 0);
            Sdl.WarpMouseInWindow(IntPtr.Zero, 0, 0);
        }

        /// <summary>
        ///     Tests that cursor functions do not crash without video
        /// </summary>
        [RequireSdl2Fact]
        public void CursorFunctions_DoNotCrash()
        {
            Sdl.ShowCursor(0);
            Sdl.GetCursor();
            Sdl.SetCursor(IntPtr.Zero);
            Sdl.FreeCursor(IntPtr.Zero);
            Sdl.CreateColorCursor(IntPtr.Zero, 0, 0);
            Sdl.CreateSystemCursor(SystemCursor.SdlSystemCursorArrow);
        }

        /// <summary>
        ///     Tests that load file handles a missing file
        /// </summary>
        [RequireSdl2Fact]
        public void LoadFile_MissingFile_ReturnsNull()
        {
            IntPtr dataSize;
            IntPtr data = Sdl.LoadFile("nonexistent_file_xyz.txt", out dataSize);
            Assert.Equal(IntPtr.Zero, data);
        }

        /// <summary>
        ///     Tests that event filter and watch registrations do not crash
        /// </summary>
        [RequireSdl2Fact]
        public void EventFilters_DoNotCrash()
        {
            Sdl.SetEventFilter(null, IntPtr.Zero);
            Sdl.AddEventWatch(null, IntPtr.Zero);
            Sdl.DelEventWatch(null, IntPtr.Zero);
        }

        /// <summary>
        ///     Tests that peep events works with the events subsystem
        /// </summary>
        [RequireSdl2Fact]
        public void PeepEvents_WithEventsInit_Works()
        {
            Sdl.Init(InitSettings.InitEvents);
            Sdl.PeepEvents(new Event[1], 1, EventAction.SdlAddEvent, EventType.FirstEvent, EventType.LastEvent);
            Sdl.Quit();
        }
    }
}
