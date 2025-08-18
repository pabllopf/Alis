#if WIN
using System;
using System.Runtime.InteropServices;
using Alis.Core.Graphic.Sample.Platform.Win.Native;

namespace Alis.Core.Graphic.Sample.Platform.Win
{
    public class Win32NativePlatform : INativePlatform
    {
        // Win32 constants
        private const string WindowClassName = "AlisWin32GLWindow";
        private const int WsOverlappedwindow = 0x00CF0000;
        private const int WsVisible = 0x10000000;
        private const int CwUsedefault = unchecked((int)0x80000000);
        private const int WmClose = 0x0010;
        private const int WmDestroy = 0x0002;
        private const int WmKeydown = 0x0100;
        private const int WmSize = 0x0005;
        private const int SwShow = 5;
        private const int SwHide = 0;
        private const int CsOwndc = 0x0020;
        private const int PfdDrawToWindow = 0x00000004;
        private const int PfdSupportOpengl = 0x00000020;
        private const int PfdDoublebuffer = 0x00000001;
        private const int PfdTypeRgba = 0;
        private const int PfdMainPlane = 0;

        // Win32 types
        private delegate IntPtr WndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        // Win32 fields
        private IntPtr hInstance;
        private IntPtr hWnd;
        private IntPtr hDc;
        private IntPtr hGlrc;
        private int width, height;
        private string title;
        private ConsoleKey? lastKeyPressed = null;
        private bool running = true;
        
        private WndProc wndProcDelegate;
        private IntPtr wndProcPtr;

        public void Initialize(int w, int h, string t)
        {
            width = w;
            height = h;
            title = t;
            hInstance = Marshal.GetHINSTANCE(typeof(Win32NativePlatform).Module);
            wndProcDelegate = WindowProc;
            wndProcPtr = Marshal.GetFunctionPointerForDelegate(wndProcDelegate);
            var wc = new Wndclass
            {
                style = CsOwndc,
                lpfnWndProc = wndProcPtr,
                cbClsExtra = 0,
                cbWndExtra = 0,
                hInstance = hInstance,
                hIcon = IntPtr.Zero,
                hCursor = IntPtr.Zero,
                hbrBackground = IntPtr.Zero,
                lpszMenuName = null,
                lpszClassName = WindowClassName
            };
            User32.RegisterClass(ref wc);
            hWnd = User32.CreateWindowEx(0, WindowClassName, title, WsOverlappedwindow | WsVisible, CwUsedefault, CwUsedefault, width, height, IntPtr.Zero, IntPtr.Zero, hInstance, IntPtr.Zero);
            hDc = User32.GetDC(hWnd);
            var pfd = new Pixelformatdescriptor
            {
                nSize = (ushort)Marshal.SizeOf(typeof(Pixelformatdescriptor)),
                nVersion = 1,
                dwFlags = PfdDrawToWindow | PfdSupportOpengl | PfdDoublebuffer,
                iPixelType = PfdTypeRgba,
                cColorBits = 32,
                cDepthBits = 24,
                iLayerType = PfdMainPlane
            };
            int pixelFormat = Gdi32.ChoosePixelFormat(hDc, ref pfd);
            Gdi32.SetPixelFormat(hDc, pixelFormat, ref pfd);
            hGlrc = Opengl32.wglCreateContext(hDc);
        }

        public void ShowWindow()
        {
            if (hWnd != IntPtr.Zero)
            {
                User32.ShowWindow(hWnd, SwShow);
                User32.UpdateWindow(hWnd);
            }
        }

        public void HideWindow()
        {
            if (hWnd != IntPtr.Zero)
            {
                User32.ShowWindow(hWnd, SwHide);
            }
        }

        public void SetTitle(string t)
        {
            if (hWnd != IntPtr.Zero)
            {
                User32.SetWindowText(hWnd, t);
                title = t;
            }
        }

        public void SetSize(int w, int h)
        {
            if (hWnd != IntPtr.Zero)
            {
                User32.SetWindowPos(hWnd, IntPtr.Zero, 0, 0, w, h, 0x0040); // SWP_NOMOVE
                width = w;
                height = h;
            }
        }

        public void MakeContextCurrent()
        {
            if (hDc != IntPtr.Zero && hGlrc != IntPtr.Zero)
            {
                Opengl32.wglMakeCurrent(hDc, hGlrc);
            }
        }

        public void SwapBuffers()
        {
            if (hDc != IntPtr.Zero)
            {
                Gdi32.SwapBuffers(hDc);
            }
        }

        public bool IsWindowVisible()
        {
            return hWnd != IntPtr.Zero && User32.IsWindowVisible(hWnd);
        }

        public bool PollEvents()
        {
            Msg msg;
            while (User32.PeekMessage(out msg, hWnd, 0, 0, 1))
            {
                if (msg.message == WmKeydown)
                {
                    lastKeyPressed = (ConsoleKey)msg.wParam.ToInt32();
                }
                if (msg.message == WmClose)
                {
                    running = false;
                    User32.DestroyWindow(hWnd);
                    hWnd = IntPtr.Zero;
                }
                User32.TranslateMessage(ref msg);
                User32.DispatchMessage(ref msg);
            }
            return running && IsWindowVisible();
        }

        public void Cleanup()
        {
            if (hGlrc != IntPtr.Zero)
            {
                Opengl32.wglMakeCurrent(IntPtr.Zero, IntPtr.Zero);
                Opengl32.wglDeleteContext(hGlrc);
                hGlrc = IntPtr.Zero;
            }
            if (hWnd != IntPtr.Zero)
            {
                User32.DestroyWindow(hWnd);
                hWnd = IntPtr.Zero;
            }
            if (hDc != IntPtr.Zero)
            {
                User32.ReleaseDC(hWnd, hDc);
                hDc = IntPtr.Zero;
            }
        }

        public int GetWindowWidth()
        {
            if (hWnd != IntPtr.Zero)
            {
                Rect rect;
                User32.GetWindowRect(hWnd, out rect);
                return rect.Right - rect.Left;
            }
            return width;
        }

        public int GetWindowHeight()
        {
            if (hWnd != IntPtr.Zero)
            {
                Rect rect;
                User32.GetWindowRect(hWnd, out rect);
                return rect.Bottom - rect.Top;
            }
            return height;
        }

        public IntPtr GetProcAddress(string name)
        {
            IntPtr addr = Opengl32.wglGetProcAddress(name);
            if (addr == IntPtr.Zero)
            {
                IntPtr module = Kernel32.LoadLibrary("opengl32.dll");
                addr = Kernel32.GetProcAddress(module, name);
            }
            return addr;
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

        // Window procedure
        private IntPtr WindowProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
        {
            switch (msg)
            {
                case WmClose:
                    running = false;
                    User32.DestroyWindow(hWnd);
                    return IntPtr.Zero;
                case WmKeydown:
                    lastKeyPressed = (ConsoleKey)wParam.ToInt32();
                    break;
                case WmSize:
                    width = lParam.ToInt32() & 0xFFFF;
                    height = (lParam.ToInt32() >> 16) & 0xFFFF;
                    break;
                case WmDestroy:
                    running = false;
                    break;
            }
            return User32.DefWindowProc(hWnd, msg, wParam, lParam);
        }
    }
}
#endif
