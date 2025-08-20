#if OSX
using System;
using System.Runtime.InteropServices;
using Alis.Core.Graphic.Sample.Platform.OSX.Internal;

namespace Alis.Core.Graphic.Sample.Platform.OSX
{
    /// <summary>
    /// Plataforma nativa para macOS, coordinando ventana y contexto OpenGL
    /// </summary>
    public class MacNativePlatform : INativePlatform
    {
        private MacWindow window;
        private MacOpenGLContext glContext;
        private IntPtr pool, app, distantPast, runLoopMode;
        private static IntPtr _openGlHandle = IntPtr.Zero;
        private ConsoleKey? lastKeyPressed = null;

        public void Initialize(int w, int h, string t)
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
        }

        public void ShowWindow() => window?.Show();
        public void HideWindow() => window?.Hide();
        public void SetTitle(string t) => window?.SetTitle(t);
        public void SetSize(int w, int h) => window?.SetSize(w, h);
        public void MakeContextCurrent() => glContext?.MakeCurrent();
        public void SwapBuffers() => glContext?.SwapBuffers();
        public bool IsWindowVisible() => window?.IsVisible() ?? false;
        public int GetWindowWidth() => window?.Width ?? 0;
        public int GetWindowHeight() => window?.Height ?? 0;
        public void Cleanup()
        {
            if (pool != IntPtr.Zero)
                ObjectiveCInterop.objc_msgSend_void(pool, ObjectiveCInterop.Sel("release"));
        }
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
                            string chars = Marshal.PtrToStringUTF8(utf8Ptr);
                            if (!string.IsNullOrEmpty(chars))
                            {
                                char c = chars[0];
                                if (Enum.TryParse<ConsoleKey>(c.ToString(), true, out var key))
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
                    Console.WriteLine("❌ No se pudo abrir la librería OpenGL");
                    return IntPtr.Zero;
                }
            }
            return Dlsym(_openGlHandle, name);
        }
        [System.Runtime.InteropServices.DllImport("/usr/lib/libSystem.B.dylib", EntryPoint = "dlsym", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        private static extern IntPtr Dlsym(IntPtr handle, string symbol);
       
        [System.Runtime.InteropServices.DllImport("/usr/lib/libSystem.B.dylib", EntryPoint = "dlopen", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        private static extern IntPtr Dlopen(string path, int mode);
    }
}
#endif
