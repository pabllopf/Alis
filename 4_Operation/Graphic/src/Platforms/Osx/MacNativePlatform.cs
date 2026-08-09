// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MacNativePlatform.cs
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

#if osxarm64 || osxarm || osxx64 || osx
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Logging;
using Alis.Core.Graphic.Platforms.Osx.Native;

namespace Alis.Core.Graphic.Platforms.Osx
{
    /// <summary>
    ///     Plataforma nativa para macOS, coordinando ventana y contexto OpenGL
    /// </summary>
    public class MacNativePlatform : INativePlatform
    {
        /// <summary>
        /// </summary>
        private static IntPtr _openGlHandle = IntPtr.Zero;

        /// <summary>
        ///     The mouse buttons
        /// </summary>
        internal readonly bool[] mouseButtons = new bool[5];

        /// <summary>
        ///     The pressed keys
        /// </summary>
        internal readonly HashSet<ConsoleKey> pressedKeys = new HashSet<ConsoleKey>();

        /// <summary>
        /// </summary>
        private MacOpenGLContext glContext;

        /// <summary>
        /// </summary>
        private ConsoleKey? lastKeyPressed;

        /// <summary>
        ///     The mouse wheel
        /// </summary>
        internal float mouseWheel;

        /// <summary>
        ///     The mouse x
        /// </summary>
        internal int mouseX;

        /// <summary>
        ///     The mouse y
        /// </summary>
        internal int mouseY;

        /// <summary>
        /// </summary>
        private IntPtr pool, app, distantPast, runLoopMode;

        /// <summary>
        /// </summary>
        private MacWindow window;

        /// <summary>
        /// </summary>
        /// <param name="w"></param>
        /// <param name="h"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Initialize(int width, int height, string title)
        {
            ObjectiveCInterop.NSApplicationLoad();
            pool = ObjectiveCInterop.objc_msgSend(ObjectiveCInterop.Class("NSAutoreleasePool"), ObjectiveCInterop.Sel("new"));
            app = ObjectiveCInterop.objc_msgSend(ObjectiveCInterop.Class("NSApplication"), ObjectiveCInterop.Sel("sharedApplication"));
            ObjectiveCInterop.objc_msgSend_void_Long(app, ObjectiveCInterop.Sel("setActivationPolicy:"), MacConstants.NsApplicationActivationPolicyRegular);
            ObjectiveCInterop.objc_msgSend_void_Bool(app, ObjectiveCInterop.Sel("activateIgnoringOtherApps:"), true);
            ObjectiveCInterop.objc_msgSend_void(app, ObjectiveCInterop.Sel("finishLaunching"));
            window = new MacWindow(width, height, title);
            glContext = new MacOpenGLContext(window);
            ObjectiveCInterop.objc_msgSend_void_IntPtr(window.Handle, ObjectiveCInterop.Sel("makeKeyAndOrderFront:"), IntPtr.Zero);
            distantPast = ObjectiveCInterop.objc_msgSend(ObjectiveCInterop.Class("NSDate"), ObjectiveCInterop.Sel("distantPast"));
            runLoopMode = ObjectiveCInterop.CFStringCreateWithCString(IntPtr.Zero, "kCFRunLoopDefaultMode", MacConstants.KCfStringEncodingUtf8);

            return true;
        }

        /// <summary>
        /// </summary>
        public void ShowWindow() => window?.Show();

        /// <summary>
        /// </summary>
        public void HideWindow() => window?.Hide();

        /// <summary>
        /// </summary>
        /// <param name="t"></param>
        public void SetTitle(string title) => window?.SetTitle(title);

        /// <summary>
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void SetSize(int width, int height) => window?.SetSize(width, height);

        /// <summary>
        /// </summary>
        public void MakeContextCurrent() => glContext?.MakeCurrent();

        /// <summary>
        /// </summary>
        public void SwapBuffers() => glContext?.SwapBuffers();

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public bool IsWindowVisible() => window?.IsVisible() ?? false;

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public int GetWindowWidth() => window?.Width ?? 0;

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public int GetWindowHeight() => window?.Height ?? 0;

        /// <summary>
        /// </summary>
        public void Cleanup()
        {
            if (pool != IntPtr.Zero)
            {
                ObjectiveCInterop.objc_msgSend_void(pool, ObjectiveCInterop.Sel("release"));
            }
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public bool PollEvents()
        {
            IntPtr evt = ObjectiveCInterop.objc_msgSend_UL_IntPtr_IntPtr_Bool(app,
                ObjectiveCInterop.Sel("nextEventMatchingMask:untilDate:inMode:dequeue:"),
                ulong.MaxValue, distantPast, runLoopMode, true);
            if (evt == IntPtr.Zero)
            {
                return IsWindowVisible();
            }

            IntPtr eventType = ObjectiveCInterop.objc_msgSend(evt, ObjectiveCInterop.Sel("type"));
            int type = eventType.ToInt32();

            if (IsMouseEvent(type))
            {
                return HandleMouseEvent(evt, type);
            }

            if (type == 10)
            {
                HandleKeyDownEvent(evt);
            }
            else if (type == 11)
            {
                HandleKeyUpEvent(evt);
            }
            else
            {
                ObjectiveCInterop.objc_msgSend_void_IntPtr(app, ObjectiveCInterop.Sel("sendEvent:"), evt);
            }

            ObjectiveCInterop.objc_msgSend_void(app, ObjectiveCInterop.Sel("updateWindows"));
            return IsWindowVisible();
        }

        /// <summary>
        ///     Determines whether the specified event type is a mouse event.
        /// </summary>
        /// <param name="type">The event type.</param>
        /// <returns>true if the event type is a mouse event; otherwise, false.</returns>
        private static bool IsMouseEvent(int type) => type == 1 || type == 2 || type == 3 || type == 4 || type == 5 || type == 22;

        /// <summary>
        ///     Handles a mouse event by updating the mouse position and button states.
        /// </summary>
        /// <param name="evt">The native event pointer.</param>
        /// <param name="type">The event type.</param>
        /// <returns>true if the window is still visible; otherwise, false.</returns>
        private bool HandleMouseEvent(IntPtr evt, int type)
        {
            UpdateMousePosition(evt);

            switch (type)
            {
                case 1:
                    mouseButtons[0] = true;
                    Console.WriteLine($"Mouse izquierdo presionado en ({mouseX},{mouseY})");
                    break;
                case 2:
                    mouseButtons[0] = false;
                    Console.WriteLine($"Mouse izquierdo soltado en ({mouseX},{mouseY})");
                    break;
                case 3:
                    mouseButtons[1] = true;
                    Console.WriteLine($"Mouse derecho presionado en ({mouseX},{mouseY})");
                    break;
                case 4:
                    mouseButtons[1] = false;
                    Console.WriteLine($"Mouse derecho soltado en ({mouseX},{mouseY})");
                    break;
                case 22:
                    double deltaY = ObjectiveCInterop.objc_msgSend_double(evt, ObjectiveCInterop.Sel("deltaY"));
                    mouseWheel = (float) deltaY;
                    Console.WriteLine($"Scroll: {mouseWheel}");
                    break;
            }

            ObjectiveCInterop.objc_msgSend_void_IntPtr(app, ObjectiveCInterop.Sel("sendEvent:"), evt);
            ObjectiveCInterop.objc_msgSend_void(app, ObjectiveCInterop.Sel("updateWindows"));
            return IsWindowVisible();
        }

        /// <summary>
        ///     Updates the stored mouse position from the native event.
        /// </summary>
        /// <param name="evt">The native event pointer.</param>
        internal void UpdateMousePosition(IntPtr evt)
        {
            IntPtr locationPtr = ObjectiveCInterop.objc_msgSend(evt, ObjectiveCInterop.Sel("locationInWindow"));
            long lx = Marshal.ReadInt64(locationPtr, 0);
            long ly = Marshal.ReadInt64(locationPtr, 8);
            double px = BitConverter.Int64BitsToDouble(lx);
            double py = BitConverter.Int64BitsToDouble(ly);
            mouseX = (int) Math.Round(px);
            mouseY = (int) Math.Round(py);
        }

        /// <summary>
        ///     Handles a key down event by extracting the key and updating the pressed keys state.
        /// </summary>
        /// <param name="evt">The native event pointer.</param>
        internal void HandleKeyDownEvent(IntPtr evt)
        {
            int keyCode = ObjectiveCInterop.objc_msgSend_Int(evt, ObjectiveCInterop.Sel("keyCode"));
            char c = ExtractCharacterFromEvent(evt);
            Console.WriteLine($"Tecla presionada: keyCode={keyCode} char='{c}'");

            if (!TryMapSpecialKey(keyCode, out ConsoleKey mappedKey))
            {
                MapCharacterKey(c, true);
                return;
            }

            lastKeyPressed = mappedKey;
            pressedKeys.Add(mappedKey);
        }

        /// <summary>
        ///     Handles a key up event by extracting the key and removing it from the pressed keys state.
        /// </summary>
        /// <param name="evt">The native event pointer.</param>
        internal void HandleKeyUpEvent(IntPtr evt)
        {
            int keyCode = ObjectiveCInterop.objc_msgSend_Int(evt, ObjectiveCInterop.Sel("keyCode"));
            char c = ExtractCharacterFromEvent(evt);
            Console.WriteLine($"Tecla soltada: keyCode={keyCode} char='{c}'");

            if (!TryMapSpecialKey(keyCode, out ConsoleKey mappedKey))
            {
                MapCharacterKey(c, false);
                return;
            }

            pressedKeys.Remove(mappedKey);
        }

        /// <summary>
        ///     Extracts the first character from a native key event.
        /// </summary>
        /// <param name="evt">The native event pointer.</param>
        /// <returns>The character, or '\0' if none.</returns>
        private static char ExtractCharacterFromEvent(IntPtr evt)
        {
            IntPtr nsString = ObjectiveCInterop.objc_msgSend(evt, ObjectiveCInterop.Sel("characters"));
            if (nsString == IntPtr.Zero)
            {
                return '\0';
            }

            IntPtr utf8Ptr = ObjectiveCInterop.objc_msgSend(nsString, ObjectiveCInterop.Sel("UTF8String"));
            if (utf8Ptr == IntPtr.Zero)
            {
                return '\0';
            }

            string chars = Marshal.PtrToStringAuto(utf8Ptr);
            if (string.IsNullOrEmpty(chars))
            {
                return '\0';
            }

            return chars[0];
        }

        /// <summary>
        ///     The special key map
        /// </summary>
        private static readonly Dictionary<int, ConsoleKey> SpecialKeyMap = new Dictionary<int, ConsoleKey>
        {
            { 123, ConsoleKey.LeftArrow },
            { 124, ConsoleKey.RightArrow },
            { 125, ConsoleKey.DownArrow },
            { 126, ConsoleKey.UpArrow },
            { 115, ConsoleKey.Home },
            { 119, ConsoleKey.End },
            { 116, ConsoleKey.PageUp },
            { 121, ConsoleKey.PageDown },
            { 51, ConsoleKey.Backspace },
            { 117, ConsoleKey.Delete },
            { 36, ConsoleKey.Enter },
            { 48, ConsoleKey.Tab },
            { 53, ConsoleKey.Escape },
            { 122, ConsoleKey.F1 },
            { 120, ConsoleKey.F2 },
            { 99, ConsoleKey.F3 },
            { 118, ConsoleKey.F4 },
            { 96, ConsoleKey.F5 },
            { 97, ConsoleKey.F6 },
            { 98, ConsoleKey.F7 },
            { 100, ConsoleKey.F8 },
            { 101, ConsoleKey.F9 },
            { 109, ConsoleKey.F10 },
            { 103, ConsoleKey.F11 },
            { 111, ConsoleKey.F12 },
            { 55, ConsoleKey.LeftWindows }
        };

        /// <summary>
        ///     Maps a macOS virtual key code to a ConsoleKey value.
        /// </summary>
        /// <param name="keyCode">The macOS key code.</param>
        /// <param name="mappedKey">The mapped ConsoleKey.</param>
        /// <returns>true if the key was mapped; otherwise, false.</returns>
        private static bool TryMapSpecialKey(int keyCode, out ConsoleKey mappedKey) => SpecialKeyMap.TryGetValue(keyCode, out mappedKey);

        /// <summary>
        ///     Maps a character key event to a ConsoleKey and updates the pressed keys state.
        /// </summary>
        /// <param name="c">The character.</param>
        /// <param name="isKeyDown">Whether the key is being pressed down.</param>
        internal void MapCharacterKey(char c, bool isKeyDown)
        {
            ConsoleKey? mapped = null;

            if ((c >= '0') && (c <= '9'))
            {
                mapped = (ConsoleKey) ((int) ConsoleKey.D0 + (c - '0'));
            }
            else if ((c >= 'A') && (c <= 'Z'))
            {
                mapped = (ConsoleKey) ((int) ConsoleKey.A + (c - 'A'));
            }
            else if ((c >= 'a') && (c <= 'z'))
            {
                mapped = (ConsoleKey) ((int) ConsoleKey.A + (c - 'a'));
            }
            else
            {
                mapped = MapSymbolKey(c);
            }

            if (!mapped.HasValue)
            {
                return;
            }

            if (isKeyDown)
            {
                lastKeyPressed = mapped.Value;
                pressedKeys.Add(mapped.Value);
            }
            else
            {
                pressedKeys.Remove(mapped.Value);
            }
        }

        /// <summary>
        ///     Maps a symbol character to a ConsoleKey value.
        /// </summary>
        /// <param name="c">The character.</param>
        /// <returns>The mapped ConsoleKey, or null if not mapped.</returns>
        private static ConsoleKey? MapSymbolKey(char c)
        {
            switch (c)
            {
                case ' ': return ConsoleKey.Spacebar;
                case '\n':
                case '\r': return ConsoleKey.Enter;
                case '\t': return ConsoleKey.Tab;
                case (char) 27: return ConsoleKey.Escape;
                case (char) 8: return ConsoleKey.Backspace;
                case (char) 127: return ConsoleKey.Delete;
                case '-': return ConsoleKey.OemMinus;
                case '+': return ConsoleKey.OemPlus;
                case ',': return ConsoleKey.OemComma;
                case '.': return ConsoleKey.OemPeriod;
                case '/': return ConsoleKey.Oem2;
                case ';': return ConsoleKey.Oem1;
                case '\\': return ConsoleKey.Oem5;
                case '[': return ConsoleKey.Oem4;
                case ']': return ConsoleKey.Oem6;
                case '`': return ConsoleKey.Oem3;
                default: return null;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool TryGetLastKeyPressed(out ConsoleKey key)
        {
            if (lastKeyPressed.HasValue)
            {
                key = lastKeyPressed.Value;
                lastKeyPressed = null;
                return true;
            }

            key = default(ConsoleKey);
            return false;
        }

        /// <summary>
        ///     Obtiene el estado actual del ratón (posición y botones)
        /// </summary>
        public void GetMouseState(out int x, out int y, out bool[] buttons)
        {
            CGPoint mouseLocation = GetMouseLocation();

            x = (int) mouseLocation.X;
            y = (int) mouseLocation.Y;
            buttons = (bool[]) mouseButtons.Clone();
        }


        /// <summary>
        ///     Obtiene delta de rueda (vertical) y lo consume
        /// </summary>
        public float GetMouseWheel()
        {
            float v = mouseWheel;
            mouseWheel = 0.0f;
            return v;
        }

        /// <summary>
        ///     Gets the last input characters.
        /// </summary>
        /// <param name="chars">The last input characters.</param>
        /// <returns>true if characters were available; otherwise, false.</returns>
        public bool TryGetLastInputCharacters(out string chars)
        {
            chars = "";
            return false;
        }

        /// <summary>
        ///     Gets the window position on the X axis.
        /// </summary>
        /// <returns>The X position of the window.</returns>
        public int GetWindowPositionX()
        {
            NsRect frame = window.GetFrame();
            return (int) frame.x;
        }

        /// <summary>
        ///     Gets the window position on the Y axis.
        /// </summary>
        /// <returns>The Y position of the window.</returns>
        public int GetWindowPositionY()
        {
            NsRect frame = window.GetFrame();
            return (int) frame.y;
        }

        /// <summary>
        ///     Gets the window metrics including position, size, and framebuffer size.
        /// </summary>
        /// <param name="winX">The window X position.</param>
        /// <param name="winY">The window Y position.</param>
        /// <param name="winW">The window width.</param>
        /// <param name="winH">The window height.</param>
        /// <param name="fbW">The framebuffer width.</param>
        /// <param name="fbH">The framebuffer height.</param>
        public void GetWindowMetrics(out int winX, out int winY, out int winW, out int winH, out int fbW, out int fbH)
        {
            NsRect frame = ObjectiveCInterop.GetWindowFrame(window.Handle);
            winX = (int) frame.x;
            winY = (int) frame.y;
            winW = (int) frame.width;
            winH = (int) frame.height;

            IntPtr contentView = ObjectiveCInterop.objc_msgSend(window.Handle, ObjectiveCInterop.Sel("contentView"));
            if (contentView != IntPtr.Zero)
            {
                NsRect viewFrame = ObjectiveCInterop.NSViewGetFrame(contentView);
                fbW = (int) viewFrame.width;
                fbH = (int) viewFrame.height;
            }
            else
            {
                fbW = winW;
                fbH = winH;
            }
        }

        /// <summary>
        ///     Gets the mouse position relative to the content view.
        /// </summary>
        /// <param name="x">The mouse X position.</param>
        /// <param name="y">The mouse Y position.</param>
        public void GetMousePositionInView(out float x, out float y)
        {
            x = 0;
            y = 0;

            if (window == null || window.Handle == IntPtr.Zero)
            {
                return;
            }

            IntPtr nsWindow = window.Handle;

            IntPtr nsView = ObjectiveCInterop.objc_msgSend(
                nsWindow,
                ObjectiveCInterop.Sel("contentView"));

            if (nsView == IntPtr.Zero)
            {
                return;
            }

            NsPoint mouseScreen =
                ObjectiveCInterop.objc_msgSend_NSPoint(nsWindow, ObjectiveCInterop.selMouseLocationOutside);

            NsPoint local =
                ObjectiveCInterop.objc_msgSend_NSPoint_NSPoint_IntPtr(
                    nsView,
                    ObjectiveCInterop.selConvertPointFromView,
                    mouseScreen,
                    IntPtr.Zero);

            x = (float) local.X;
            y = (float) local.Y;
        }


        /// <summary>
        ///     Determines whether the specified console key is pressed
        /// </summary>
        /// <param name="consoleKey">The console key</param>
        /// <returns>The <see cref="bool"/></returns>
        public bool IsKeyDown(ConsoleKey consoleKey) => pressedKeys.Contains(consoleKey);

        /// <summary>
        ///     Gets the proc address using the specified proc name
        /// </summary>
        /// <param name="procName">The proc name</param>
        /// <returns></returns>
#pragma warning disable S2696
        public IntPtr GetProcAddress(string procName)
        {
            const string OpenGLPath = "/System/Library/Frameworks/OpenGL.framework/OpenGL";
            const int RtldDefault = 0;
            if (_openGlHandle == IntPtr.Zero)
            {
                _openGlHandle = ObjectiveCInterop.Dlopen(OpenGLPath, RtldDefault);
                if (_openGlHandle == IntPtr.Zero)
                {
                    Logger.Info("❌ No se pudo abrir la librería OpenGL");
                    return IntPtr.Zero;
                }
            }

            return ObjectiveCInterop.Dlsym(_openGlHandle, procName);
        }
#pragma warning restore S2696


        /// <summary>
        ///     Creates the window and sets the icon from the specified BMP file path (Cocoa, using objc_msgSend)
        /// </summary>
        public bool Initialize(int width, int height, string title, string iconPath)
        {
            bool result = Initialize(width, height, title);
            if (!result)
            {
                return false;
            }

            try
            {
                IntPtr nsImageClass = ObjectiveCInterop.objc_getClass("NSImage");
                IntPtr allocSel = ObjectiveCInterop.sel_registerName("alloc");
                IntPtr initWithContentsSel = ObjectiveCInterop.sel_registerName("initWithContentsOfFile:");
                IntPtr nsAppClass = ObjectiveCInterop.objc_getClass("NSApplication");
                IntPtr sharedAppSel = ObjectiveCInterop.sel_registerName("sharedApplication");
                IntPtr setIconSel = ObjectiveCInterop.sel_registerName("setApplicationIconImage:");

                IntPtr nsImageAlloc = ObjectiveCInterop.objc_msgSend(nsImageClass, allocSel);
                IntPtr nsImage = ObjectiveCInterop.objc_msgSend(nsImageAlloc, initWithContentsSel, Marshal.StringToHGlobalAuto(iconPath));
                IntPtr nsApp = ObjectiveCInterop.objc_msgSend(nsAppClass, sharedAppSel);
                ObjectiveCInterop.objc_msgSend(nsApp, setIconSel, nsImage);
            }
            catch (Exception ex)
            {
                Logger.Error($"❌ Error to set window icon: {ex.Message}");
                return false;
            }

            return true;
        }

        /// <summary>
        ///     Sets the window icon from the specified BMP file path (Cocoa, safe NSString handling)
        /// </summary>
        public void SetWindowIcon(string iconPath)
        {
            try
            {
                IntPtr nsImageClass = ObjectiveCInterop.objc_getClass("NSImage");
                IntPtr allocSel = ObjectiveCInterop.sel_registerName("alloc");
                IntPtr initWithContentsSel = ObjectiveCInterop.sel_registerName("initWithContentsOfFile:");
                IntPtr nsAppClass = ObjectiveCInterop.objc_getClass("NSApplication");
                IntPtr sharedAppSel = ObjectiveCInterop.sel_registerName("sharedApplication");
                IntPtr setIconSel = ObjectiveCInterop.sel_registerName("setApplicationIconImage:");
                IntPtr nsStringClass = ObjectiveCInterop.objc_getClass("NSString");
                IntPtr stringWithUTF8Sel = ObjectiveCInterop.sel_registerName("stringWithUTF8String:");

                IntPtr iconPathUtf8 = Marshal.StringToHGlobalAnsi(iconPath);
                IntPtr nsString = ObjectiveCInterop.objc_msgSend(nsStringClass, stringWithUTF8Sel, iconPathUtf8);
                Marshal.FreeHGlobal(iconPathUtf8);
                if (nsString == IntPtr.Zero)
                {
                    return;
                }

                IntPtr nsImageAlloc = ObjectiveCInterop.objc_msgSend(nsImageClass, allocSel);
                IntPtr nsImage = ObjectiveCInterop.objc_msgSend(nsImageAlloc, initWithContentsSel, nsString);
                if (nsImage == IntPtr.Zero)
                {
                    return;
                }

                IntPtr nsApp = ObjectiveCInterop.objc_msgSend(nsAppClass, sharedAppSel);
                ObjectiveCInterop.objc_msgSend(nsApp, setIconSel, nsImage);
            }
            catch (Exception ex)
            {
                Logger.Error($"❌ Error to set window icon: {ex.Message}");
            }
        }

        // Estructura para la posición

        private static CGPoint GetMouseLocation()
        {
            IntPtr eventRef = ObjectiveCInterop.CGEventCreate(IntPtr.Zero);
            CGPoint point = ObjectiveCInterop.CGEventGetLocation(eventRef);
            ObjectiveCInterop.CFRelease(eventRef);
            return point;
        }
    }
}
#endif