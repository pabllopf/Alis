#if OSX
using System;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Logging;
using Alis.Core.Graphic.Platforms.Osx.Native;

namespace Alis.Core.Graphic.Platforms.Osx
{
    /// <summary>
    /// Plataforma nativa para macOS, coordinando ventana y contexto OpenGL
    /// </summary>
    public class MacNativePlatform : INativePlatform
    {
        /// <summary>
        /// 
        /// </summary>
        private MacWindow window;
        
        /// <summary>
        /// 
        /// </summary>
        private MacOpenGLContext glContext;
        
        /// <summary>
        /// 
        /// </summary>
        private IntPtr pool, app, distantPast, runLoopMode;
        
        /// <summary>
        /// 
        /// </summary>
        private static IntPtr _openGlHandle = IntPtr.Zero;
        
        /// <summary>
        /// 
        /// </summary>
        private ConsoleKey? lastKeyPressed = null;

        
        
        /// <summary>
        /// 
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
        /// 
        /// </summary>
        public void ShowWindow() => window?.Show();
        
        /// <summary>
        /// 
        /// </summary>
        public void HideWindow() => window?.Hide();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        public void SetTitle(string t) => window?.SetTitle(t);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="w"></param>
        /// <param name="h"></param>
        public void SetSize(int w, int h) => window?.SetSize(w, h);
        /// <summary>
        /// 
        /// </summary>
        public void MakeContextCurrent() => glContext?.MakeCurrent();
        
        /// <summary>
        /// 
        /// </summary>
        public void SwapBuffers() => glContext?.SwapBuffers();
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsWindowVisible() => window?.IsVisible() ?? false;
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetWindowWidth() => window?.Width ?? 0;
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetWindowHeight() => window?.Height ?? 0;
        
        /// <summary>
        /// 
        /// </summary>
        public void Cleanup()
        {
            if (pool != IntPtr.Zero)
                ObjectiveCInterop.objc_msgSend_void(pool, ObjectiveCInterop.Sel("release"));
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool PollEvents()
        {
            IntPtr evt = ObjectiveCInterop.objc_msgSend_UL_IntPtr_IntPtr_Bool(app,
                ObjectiveCInterop.Sel("nextEventMatchingMask:untilDate:inMode:dequeue:"),
                ulong.MaxValue, distantPast, runLoopMode, true);
            if (evt != IntPtr.Zero)
            {
                // Captura de tecla
                IntPtr eventType = ObjectiveCInterop.objc_msgSend(evt, ObjectiveCInterop.Sel("type"));
                int type = eventType.ToInt32();
                // NSKeyDown = 10
                if (type == 10)
                {
                    IntPtr nsString = ObjectiveCInterop.objc_msgSend(evt, ObjectiveCInterop.Sel("characters"));
                    if (nsString != IntPtr.Zero)
                    {
                        IntPtr utf8Ptr = ObjectiveCInterop.objc_msgSend(nsString, ObjectiveCInterop.Sel("UTF8String"));
                        if (utf8Ptr != IntPtr.Zero)
                        {
                            string chars = Marshal.PtrToStringAuto(utf8Ptr);
                            if (!string.IsNullOrEmpty(chars))
                            {
                                char c = chars[0];
                                if (Enum.TryParse<ConsoleKey>(c.ToString(), true, out ConsoleKey key))
                                {
                                    lastKeyPressed = key;
                                }
                            }
                        }
                    }
                }
                ObjectiveCInterop.objc_msgSend_void_IntPtr(app, ObjectiveCInterop.Sel("sendEvent:"), evt);
                ObjectiveCInterop.objc_msgSend_void(app, ObjectiveCInterop.Sel("updateWindows"));
            }
            return IsWindowVisible();
        }
        
        /// <summary>
        /// 
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
            key = default;
            return false;
        }
        
        /// <summary>
        /// 
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
        /// 
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="symbol"></param>
        /// <returns></returns>
        [System.Runtime.InteropServices.DllImport("/usr/lib/libSystem.B.dylib", EntryPoint = "dlsym", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        private static extern IntPtr Dlsym(IntPtr handle, string symbol);
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        [System.Runtime.InteropServices.DllImport("/usr/lib/libSystem.B.dylib", EntryPoint = "dlopen", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        private static extern IntPtr Dlopen(string path, int mode);
    }
}
#endif
