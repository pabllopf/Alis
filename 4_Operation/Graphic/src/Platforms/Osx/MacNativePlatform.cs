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
        /// </summary>
        private MacOpenGLContext glContext;

        /// <summary>
        /// </summary>
        private ConsoleKey? lastKeyPressed;

        /// <summary>
        /// </summary>
        private IntPtr pool, app, distantPast, runLoopMode;

        /// <summary>
        /// </summary>
        private MacWindow window;

        private HashSet<ConsoleKey> pressedKeys = new HashSet<ConsoleKey>();

        /// <summary>
        /// </summary>
        /// <param name="w"></param>
        /// <param name="h"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Initialize(int w, int h, string t)
        {
            ObjectiveCInterop.NSApplicationLoad();
            pool = ObjectiveCInterop.objc_msgSend(ObjectiveCInterop.Class("NSAutoreleasePool"), ObjectiveCInterop.Sel("new"));
            app = ObjectiveCInterop.objc_msgSend(ObjectiveCInterop.Class("NSApplication"), ObjectiveCInterop.Sel("sharedApplication"));
            ObjectiveCInterop.objc_msgSend_void_Long(app, ObjectiveCInterop.Sel("setActivationPolicy:"), MacConstants.NsApplicationActivationPolicyRegular);
            ObjectiveCInterop.objc_msgSend_void_Bool(app, ObjectiveCInterop.Sel("activateIgnoringOtherApps:"), true);
            ObjectiveCInterop.objc_msgSend_void(app, ObjectiveCInterop.Sel("finishLaunching"));
            window = new MacWindow(w, h, t);
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
        public void SetTitle(string t) => window?.SetTitle(t);

        /// <summary>
        /// </summary>
        /// <param name="w"></param>
        /// <param name="h"></param>
        public void SetSize(int w, int h) => window?.SetSize(w, h);

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
            if (evt != IntPtr.Zero)
            {
                IntPtr eventType = ObjectiveCInterop.objc_msgSend(evt, ObjectiveCInterop.Sel("type"));
                int type = eventType.ToInt32();
                if (type == 10) // NSKeyDown
                {
                    int keyCode = ObjectiveCInterop.objc_msgSend_Int(evt, ObjectiveCInterop.Sel("keyCode"));
                    ulong modifierFlags = ObjectiveCInterop.objc_msgSend_UL(evt, ObjectiveCInterop.Sel("modifierFlags"));
                    IntPtr nsString = ObjectiveCInterop.objc_msgSend(evt, ObjectiveCInterop.Sel("characters"));
                    char c = '\0';
                    if (nsString != IntPtr.Zero)
                    {
                        IntPtr utf8Ptr = ObjectiveCInterop.objc_msgSend(nsString, ObjectiveCInterop.Sel("UTF8String"));
                        if (utf8Ptr != IntPtr.Zero)
                        {
                            string chars = Marshal.PtrToStringAuto(utf8Ptr);
                            if (!string.IsNullOrEmpty(chars))
                                c = chars[0];
                        }
                    }
                    // Mapear por keyCode primero (teclas especiales y flechas)
                    switch (keyCode)
                    {
                        case 123: lastKeyPressed = ConsoleKey.LeftArrow; pressedKeys.Add(ConsoleKey.LeftArrow); break;
                        case 124: lastKeyPressed = ConsoleKey.RightArrow; pressedKeys.Add(ConsoleKey.RightArrow); break;
                        case 125: lastKeyPressed = ConsoleKey.DownArrow; pressedKeys.Add(ConsoleKey.DownArrow); break;
                        case 126: lastKeyPressed = ConsoleKey.UpArrow; pressedKeys.Add(ConsoleKey.UpArrow); break;
                        case 115: lastKeyPressed = ConsoleKey.Home; pressedKeys.Add(ConsoleKey.Home); break;
                        case 119: lastKeyPressed = ConsoleKey.End; pressedKeys.Add(ConsoleKey.End); break;
                        case 116: lastKeyPressed = ConsoleKey.PageUp; pressedKeys.Add(ConsoleKey.PageUp); break;
                        case 121: lastKeyPressed = ConsoleKey.PageDown; pressedKeys.Add(ConsoleKey.PageDown); break;
                        case 51: lastKeyPressed = ConsoleKey.Backspace; pressedKeys.Add(ConsoleKey.Backspace); break;
                        case 117: lastKeyPressed = ConsoleKey.Delete; pressedKeys.Add(ConsoleKey.Delete); break;
                        case 36: lastKeyPressed = ConsoleKey.Enter; pressedKeys.Add(ConsoleKey.Enter); break;
                        case 48: lastKeyPressed = ConsoleKey.Tab; pressedKeys.Add(ConsoleKey.Tab); break;
                        case 53: lastKeyPressed = ConsoleKey.Escape; pressedKeys.Add(ConsoleKey.Escape); break;
                        case 122: lastKeyPressed = ConsoleKey.F1; pressedKeys.Add(ConsoleKey.F1); break;
                        case 120: lastKeyPressed = ConsoleKey.F2; pressedKeys.Add(ConsoleKey.F2); break;
                        case 99: lastKeyPressed = ConsoleKey.F3; pressedKeys.Add(ConsoleKey.F3); break;
                        case 118: lastKeyPressed = ConsoleKey.F4; pressedKeys.Add(ConsoleKey.F4); break;
                        case 96: lastKeyPressed = ConsoleKey.F5; pressedKeys.Add(ConsoleKey.F5); break;
                        case 97: lastKeyPressed = ConsoleKey.F6; pressedKeys.Add(ConsoleKey.F6); break;
                        case 98: lastKeyPressed = ConsoleKey.F7; pressedKeys.Add(ConsoleKey.F7); break;
                        case 100: lastKeyPressed = ConsoleKey.F8; pressedKeys.Add(ConsoleKey.F8); break;
                        case 101: lastKeyPressed = ConsoleKey.F9; pressedKeys.Add(ConsoleKey.F9); break;
                        case 109: lastKeyPressed = ConsoleKey.F10; pressedKeys.Add(ConsoleKey.F10); break;
                        case 103: lastKeyPressed = ConsoleKey.F11; pressedKeys.Add(ConsoleKey.F11); break;
                        case 111: lastKeyPressed = ConsoleKey.F12; pressedKeys.Add(ConsoleKey.F12); break;
                        //case 57: lastKeyPressed = ConsoleKey.CapsLock; pressedKeys.Add(ConsoleKey.CapsLock); break;
                        case 55: lastKeyPressed = ConsoleKey.LeftWindows; pressedKeys.Add(ConsoleKey.LeftWindows); break; // Command
                        //case 56: lastKeyPressed = ConsoleKey.LeftShift; pressedKeys.Add(ConsoleKey.LeftShift); break;
                        //case 60: lastKeyPressed = ConsoleKey.RightShift; pressedKeys.Add(ConsoleKey.RightShift); break;
                        //case 59: lastKeyPressed = ConsoleKey.LeftCtrl; pressedKeys.Add(ConsoleKey.LeftCtrl); break;
                        //case 62: lastKeyPressed = ConsoleKey.RightCtrl; pressedKeys.Add(ConsoleKey.RightCtrl); break;
                        //case 58: lastKeyPressed = ConsoleKey.LeftAlt; pressedKeys.Add(ConsoleKey.LeftAlt); break; // Option
                        //case 61: lastKeyPressed = ConsoleKey.RightAlt; pressedKeys.Add(ConsoleKey.RightAlt); break;
                        default:
                            // Si es número, letra o símbolo
                            if (c >= '0' && c <= '9')
                            {
                                lastKeyPressed = (ConsoleKey)((int)ConsoleKey.D0 + (c - '0'));
                                pressedKeys.Add(lastKeyPressed.Value);
                            }
                            else if (c >= 'A' && c <= 'Z')
                            {
                                lastKeyPressed = (ConsoleKey)((int)ConsoleKey.A + (c - 'A'));
                                pressedKeys.Add(lastKeyPressed.Value);
                            }
                            else if (c >= 'a' && c <= 'z')
                            {
                                lastKeyPressed = (ConsoleKey)((int)ConsoleKey.A + (c - 'a'));
                                pressedKeys.Add(lastKeyPressed.Value);
                            }
                            else
                            {
                                switch (c)
                                {
                                    case ' ': lastKeyPressed = ConsoleKey.Spacebar; pressedKeys.Add(ConsoleKey.Spacebar); break;
                                    case '\n': case '\r': lastKeyPressed = ConsoleKey.Enter; pressedKeys.Add(ConsoleKey.Enter); break;
                                    case '\t': lastKeyPressed = ConsoleKey.Tab; pressedKeys.Add(ConsoleKey.Tab); break;
                                    case (char)27: lastKeyPressed = ConsoleKey.Escape; pressedKeys.Add(ConsoleKey.Escape); break;
                                    case (char)8: lastKeyPressed = ConsoleKey.Backspace; pressedKeys.Add(ConsoleKey.Backspace); break;
                                    case (char)127: lastKeyPressed = ConsoleKey.Delete; pressedKeys.Add(ConsoleKey.Delete); break;
                                    case '-': lastKeyPressed = ConsoleKey.OemMinus; pressedKeys.Add(ConsoleKey.OemMinus); break;
                                    case '+': lastKeyPressed = ConsoleKey.OemPlus; pressedKeys.Add(ConsoleKey.OemPlus); break;
                                    case ',': lastKeyPressed = ConsoleKey.OemComma; pressedKeys.Add(ConsoleKey.OemComma); break;
                                    case '.': lastKeyPressed = ConsoleKey.OemPeriod; pressedKeys.Add(ConsoleKey.OemPeriod); break;
                                    case '/': lastKeyPressed = ConsoleKey.Oem2; pressedKeys.Add(ConsoleKey.Oem2); break;
                                    case ';': lastKeyPressed = ConsoleKey.Oem1; pressedKeys.Add(ConsoleKey.Oem1); break;
                                    case '\\': lastKeyPressed = ConsoleKey.Oem5; pressedKeys.Add(ConsoleKey.Oem5); break;
                                    case '[': lastKeyPressed = ConsoleKey.Oem4; pressedKeys.Add(ConsoleKey.Oem4); break;
                                    case ']': lastKeyPressed = ConsoleKey.Oem6; pressedKeys.Add(ConsoleKey.Oem6); break;
                                    case '`': lastKeyPressed = ConsoleKey.Oem3; pressedKeys.Add(ConsoleKey.Oem3); break;
                                }
                            }
                            break;
                    }
                }
                else if (type == 11) // NSKeyUp
                {
                    int keyCode = ObjectiveCInterop.objc_msgSend_Int(evt, ObjectiveCInterop.Sel("keyCode"));
                    IntPtr nsString = ObjectiveCInterop.objc_msgSend(evt, ObjectiveCInterop.Sel("characters"));
                    char c = '\0';
                    if (nsString != IntPtr.Zero)
                    {
                        IntPtr utf8Ptr = ObjectiveCInterop.objc_msgSend(nsString, ObjectiveCInterop.Sel("UTF8String"));
                        if (utf8Ptr != IntPtr.Zero)
                        {
                            string chars = Marshal.PtrToStringAuto(utf8Ptr);
                            if (!string.IsNullOrEmpty(chars))
                                c = chars[0];
                        }
                    }
                    switch (keyCode)
                    {
                        case 123: pressedKeys.Remove(ConsoleKey.LeftArrow); break;
                        case 124: pressedKeys.Remove(ConsoleKey.RightArrow); break;
                        case 125: pressedKeys.Remove(ConsoleKey.DownArrow); break;
                        case 126: pressedKeys.Remove(ConsoleKey.UpArrow); break;
                        case 115: pressedKeys.Remove(ConsoleKey.Home); break;
                        case 119: pressedKeys.Remove(ConsoleKey.End); break;
                        case 116: pressedKeys.Remove(ConsoleKey.PageUp); break;
                        case 121: pressedKeys.Remove(ConsoleKey.PageDown); break;
                        case 51: pressedKeys.Remove(ConsoleKey.Backspace); break;
                        case 117: pressedKeys.Remove(ConsoleKey.Delete); break;
                        case 36: pressedKeys.Remove(ConsoleKey.Enter); break;
                        case 48: pressedKeys.Remove(ConsoleKey.Tab); break;
                        case 53: pressedKeys.Remove(ConsoleKey.Escape); break;
                        case 122: pressedKeys.Remove(ConsoleKey.F1); break;
                        case 120: pressedKeys.Remove(ConsoleKey.F2); break;
                        case 99: pressedKeys.Remove(ConsoleKey.F3); break;
                        case 118: pressedKeys.Remove(ConsoleKey.F4); break;
                        case 96: pressedKeys.Remove(ConsoleKey.F5); break;
                        case 97: pressedKeys.Remove(ConsoleKey.F6); break;
                        case 98: pressedKeys.Remove(ConsoleKey.F7); break;
                        case 100: pressedKeys.Remove(ConsoleKey.F8); break;
                        case 101: pressedKeys.Remove(ConsoleKey.F9); break;
                        case 109: pressedKeys.Remove(ConsoleKey.F10); break;
                        case 103: pressedKeys.Remove(ConsoleKey.F11); break;
                        case 111: pressedKeys.Remove(ConsoleKey.F12); break;
                        //case 57: pressedKeys.Remove(ConsoleKey.CapsLock); break;
                        case 55: pressedKeys.Remove(ConsoleKey.LeftWindows); break;
                        //case 56: pressedKeys.Remove(ConsoleKey.LeftShift); break;
                        //case 60: pressedKeys.Remove(ConsoleKey.RightShift); break;
                        //case 59: pressedKeys.Remove(ConsoleKey.LeftCtrl); break;
                        //case 62: pressedKeys.Remove(ConsoleKey.RightCtrl); break;
                        //case 58: pressedKeys.Remove(ConsoleKey.LeftAlt); break;
                        //case 61: pressedKeys.Remove(ConsoleKey.RightAlt); break;
                        default:
                            if (c >= '0' && c <= '9')
                                pressedKeys.Remove((ConsoleKey)((int)ConsoleKey.D0 + (c - '0')));
                            else if (c >= 'A' && c <= 'Z')
                                pressedKeys.Remove((ConsoleKey)((int)ConsoleKey.A + (c - 'A')));
                            else if (c >= 'a' && c <= 'z')
                                pressedKeys.Remove((ConsoleKey)((int)ConsoleKey.A + (c - 'a')));
                            else
                            {
                                switch (c)
                                {
                                    case ' ': pressedKeys.Remove(ConsoleKey.Spacebar); break;
                                    case '\n': case '\r': pressedKeys.Remove(ConsoleKey.Enter); break;
                                    case '\t': pressedKeys.Remove(ConsoleKey.Tab); break;
                                    case (char)27: pressedKeys.Remove(ConsoleKey.Escape); break;
                                    case (char)8: pressedKeys.Remove(ConsoleKey.Backspace); break;
                                    case (char)127: pressedKeys.Remove(ConsoleKey.Delete); break;
                                    case '-': pressedKeys.Remove(ConsoleKey.OemMinus); break;
                                    case '+': pressedKeys.Remove(ConsoleKey.OemPlus); break;
                                    case ',': pressedKeys.Remove(ConsoleKey.OemComma); break;
                                    case '.': pressedKeys.Remove(ConsoleKey.OemPeriod); break;
                                    case '/': pressedKeys.Remove(ConsoleKey.Oem2); break;
                                    case ';': pressedKeys.Remove(ConsoleKey.Oem1); break;
                                    case '\\': pressedKeys.Remove(ConsoleKey.Oem5); break;
                                    case '[': pressedKeys.Remove(ConsoleKey.Oem4); break;
                                    case ']': pressedKeys.Remove(ConsoleKey.Oem6); break;
                                    case '`': pressedKeys.Remove(ConsoleKey.Oem3); break;
                                }
                            }
                            break;
                    }
                }
                else
                {
                    ObjectiveCInterop.objc_msgSend_void_IntPtr(app, ObjectiveCInterop.Sel("sendEvent:"), evt);
                }
                ObjectiveCInterop.objc_msgSend_void(app, ObjectiveCInterop.Sel("updateWindows"));
            }

            return IsWindowVisible();
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
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool IsKeyDown(ConsoleKey key)
        {
            return pressedKeys.Contains(key);
        }

        /// <summary>
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IntPtr GetProcAddress(string name)
        {
            // OpenGL dynamic loading
            const string OpenGLPath = "/System/Library/Frameworks/OpenGL.framework/OpenGL";
            const int RtldDefault = 0;
            if (_openGlHandle == IntPtr.Zero)
            {
                _openGlHandle = Dlopen(OpenGLPath, RtldDefault);
                if (_openGlHandle == IntPtr.Zero)
                {
                    Logger.Info("❌ No se pudo abrir la librería OpenGL");
                    return IntPtr.Zero;
                }
            }

            return Dlsym(_openGlHandle, name);
        }

        /// <summary>
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="symbol"></param>
        /// <returns></returns>
        [DllImport("/usr/lib/libSystem.B.dylib", EntryPoint = "dlsym", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr Dlsym(IntPtr handle, string symbol);

        /// <summary>
        /// </summary>
        /// <param name="path"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        [DllImport("/usr/lib/libSystem.B.dylib", EntryPoint = "dlopen", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr Dlopen(string path, int mode);

        /// <summary>
        /// Creates the window and sets the icon from the specified BMP file path (Cocoa, using objc_msgSend)
        /// </summary>
        public bool Initialize(int width, int height, string title, string iconPath)
        {
            bool result = Initialize(width, height, title);
            if (!result)
                return false;
            try
            {
                IntPtr nsImageClass = objc_getClass("NSImage");
                IntPtr allocSel = sel_registerName("alloc");
                IntPtr initWithContentsSel = sel_registerName("initWithContentsOfFile:");
                IntPtr nsAppClass = objc_getClass("NSApplication");
                IntPtr sharedAppSel = sel_registerName("sharedApplication");
                IntPtr setIconSel = sel_registerName("setApplicationIconImage:");

                IntPtr nsImageAlloc = objc_msgSend(nsImageClass, allocSel);
                IntPtr nsImage = objc_msgSend(nsImageAlloc, initWithContentsSel, Marshal.StringToHGlobalAuto(iconPath));
                IntPtr nsApp = objc_msgSend(nsAppClass, sharedAppSel);
                objc_msgSend(nsApp, setIconSel, nsImage);
            }
            catch (Exception ex)
            {
                Logger.Error($"❌ Error to set window icon: {ex.Message}");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Sets the window icon from the specified BMP file path (Cocoa, safe NSString handling)
        /// </summary>
        public void SetWindowIcon(string iconPath)
        {
            try
            {
                IntPtr nsImageClass = objc_getClass("NSImage");
                IntPtr allocSel = sel_registerName("alloc");
                IntPtr initWithContentsSel = sel_registerName("initWithContentsOfFile:");
                IntPtr nsAppClass = objc_getClass("NSApplication");
                IntPtr sharedAppSel = sel_registerName("sharedApplication");
                IntPtr setIconSel = sel_registerName("setApplicationIconImage:");
                IntPtr nsStringClass = objc_getClass("NSString");
                IntPtr stringWithUTF8Sel = sel_registerName("stringWithUTF8String:");

                // Crear NSString desde el path
                IntPtr iconPathUtf8 = Marshal.StringToHGlobalAnsi(iconPath);
                IntPtr nsString = objc_msgSend(nsStringClass, stringWithUTF8Sel, iconPathUtf8);
                Marshal.FreeHGlobal(iconPathUtf8);
                if (nsString == IntPtr.Zero)
                    return;

                IntPtr nsImageAlloc = objc_msgSend(nsImageClass, allocSel);
                IntPtr nsImage = objc_msgSend(nsImageAlloc, initWithContentsSel, nsString);
                if (nsImage == IntPtr.Zero)
                    return;
                IntPtr nsApp = objc_msgSend(nsAppClass, sharedAppSel);
                objc_msgSend(nsApp, setIconSel, nsImage);
            }
            catch (Exception ex)
            {
                Logger.Error($"❌ Error to set window icon: {ex.Message}");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="receiver"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        [DllImport("/usr/lib/libobjc.A.dylib")]
        private static extern IntPtr objc_msgSend(IntPtr receiver, IntPtr selector);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="receiver"></param>
        /// <param name="selector"></param>
        /// <param name="arg1"></param>
        /// <returns></returns>
        [DllImport("/usr/lib/libobjc.A.dylib")]
        private static extern IntPtr objc_msgSend(IntPtr receiver, IntPtr selector, IntPtr arg1);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [DllImport("/usr/lib/libobjc.A.dylib")]
        private static extern IntPtr objc_getClass(string name);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [DllImport("/usr/lib/libobjc.A.dylib")]
        private static extern IntPtr sel_registerName(string name);
    }
}
#endif

