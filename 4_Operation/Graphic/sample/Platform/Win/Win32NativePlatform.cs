#if WIN
using System;
using System.Runtime.InteropServices;
using System.Text;
using Alis.Core.Graphic.Sample.Platform;

namespace Alis.Core.Graphic.Sample.Platform.Win
{
    public class Win32NativePlatform : INativePlatform
    {
        // Win32 constants
        private const string WINDOW_CLASS_NAME = "AlisWin32GLWindow";
        private const int WS_OVERLAPPEDWINDOW = 0x00CF0000;
        private const int WS_VISIBLE = 0x10000000;
        private const int CW_USEDEFAULT = unchecked((int)0x80000000);
        private const int WM_CLOSE = 0x0010;
        private const int WM_DESTROY = 0x0002;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_SIZE = 0x0005;
        private const int SW_SHOW = 5;
        private const int SW_HIDE = 0;
        private const int CS_OWNDC = 0x0020;
        private const int PFD_DRAW_TO_WINDOW = 0x00000004;
        private const int PFD_SUPPORT_OPENGL = 0x00000020;
        private const int PFD_DOUBLEBUFFER = 0x00000001;
        private const int PFD_TYPE_RGBA = 0;
        private const int PFD_MAIN_PLANE = 0;

        // Win32 types
        private delegate IntPtr WndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        // Win32 fields
        private IntPtr hInstance;
        private IntPtr hWnd;
        private IntPtr hDC;
        private IntPtr hGLRC;
        private int width, height;
        private string title;
        private ConsoleKey? lastKeyPressed = null;
        private bool running = true;

        // Win32 structs
        [StructLayout(LayoutKind.Sequential)]
        private struct WNDCLASS
        {
            public uint style;
            public IntPtr lpfnWndProc;
            public int cbClsExtra;
            public int cbWndExtra;
            public IntPtr hInstance;
            public IntPtr hIcon;
            public IntPtr hCursor;
            public IntPtr hbrBackground;
            public string lpszMenuName;
            public string lpszClassName;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct PIXELFORMATDESCRIPTOR
        {
            public ushort nSize;
            public ushort nVersion;
            public uint dwFlags;
            public byte iPixelType;
            public byte cColorBits;
            public byte cRedBits;
            public byte cRedShift;
            public byte cGreenBits;
            public byte cGreenShift;
            public byte cBlueBits;
            public byte cBlueShift;
            public byte cAlphaBits;
            public byte cAlphaShift;
            public byte cAccumBits;
            public byte cAccumRedBits;
            public byte cAccumGreenBits;
            public byte cAccumBlueBits;
            public byte cAccumAlphaBits;
            public byte cDepthBits;
            public byte cStencilBits;
            public byte cAuxBuffers;
            public byte iLayerType;
            public byte bReserved;
            public uint dwLayerMask;
            public uint dwVisibleMask;
            public uint dwDamageMask;
        }

        // Win32 P/Invoke
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr CreateWindowEx(
            int dwExStyle,
            string lpClassName,
            string lpWindowName,
            int dwStyle,
            int x,
            int y,
            int nWidth,
            int nHeight,
            IntPtr hWndParent,
            IntPtr hMenu,
            IntPtr hInstance,
            IntPtr lpParam);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool DestroyWindow(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool UpdateWindow(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetWindowText(IntPtr hWnd, string lpString);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr DefWindowProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern ushort RegisterClass(ref WNDCLASS lpWndClass);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool PeekMessage(out MSG lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax, uint wRemoveMsg);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool TranslateMessage(ref MSG lpMsg);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr DispatchMessage(ref MSG lpMsg);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetMessage(out MSG lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool IsWindowVisible(IntPtr hWnd);

        // Win32 structs
        [StructLayout(LayoutKind.Sequential)]
        private struct MSG
        {
            public IntPtr hwnd;
            public uint message;
            public IntPtr wParam;
            public IntPtr lParam;
            public uint time;
            public int pt_x;
            public int pt_y;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        // WGL P/Invoke
        [DllImport("gdi32.dll", SetLastError = true)]
        private static extern int ChoosePixelFormat(IntPtr hdc, ref PIXELFORMATDESCRIPTOR ppfd);

        [DllImport("gdi32.dll", SetLastError = true)]
        private static extern bool SetPixelFormat(IntPtr hdc, int format, ref PIXELFORMATDESCRIPTOR ppfd);

        [DllImport("gdi32.dll", SetLastError = true)]
        private static extern bool SwapBuffers(IntPtr hdc);

        [DllImport("opengl32.dll", SetLastError = true)]
        private static extern IntPtr wglCreateContext(IntPtr hdc);

        [DllImport("opengl32.dll", SetLastError = true)]
        private static extern bool wglMakeCurrent(IntPtr hdc, IntPtr hglrc);

        [DllImport("opengl32.dll", SetLastError = true)]
        private static extern bool wglDeleteContext(IntPtr hglrc);

        [DllImport("opengl32.dll", SetLastError = true)]
        private static extern IntPtr wglGetProcAddress(string lpszProc);

        // Window procedure
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
            var wc = new WNDCLASS
            {
                style = CS_OWNDC,
                lpfnWndProc = wndProcPtr,
                cbClsExtra = 0,
                cbWndExtra = 0,
                hInstance = hInstance,
                hIcon = IntPtr.Zero,
                hCursor = IntPtr.Zero,
                hbrBackground = IntPtr.Zero,
                lpszMenuName = null,
                lpszClassName = WINDOW_CLASS_NAME
            };
            RegisterClass(ref wc);
            hWnd = CreateWindowEx(0, WINDOW_CLASS_NAME, title, WS_OVERLAPPEDWINDOW | WS_VISIBLE, CW_USEDEFAULT, CW_USEDEFAULT, width, height, IntPtr.Zero, IntPtr.Zero, hInstance, IntPtr.Zero);
            hDC = GetDC(hWnd);
            var pfd = new PIXELFORMATDESCRIPTOR
            {
                nSize = (ushort)Marshal.SizeOf(typeof(PIXELFORMATDESCRIPTOR)),
                nVersion = 1,
                dwFlags = PFD_DRAW_TO_WINDOW | PFD_SUPPORT_OPENGL | PFD_DOUBLEBUFFER,
                iPixelType = PFD_TYPE_RGBA,
                cColorBits = 32,
                cDepthBits = 24,
                iLayerType = PFD_MAIN_PLANE
            };
            int pixelFormat = ChoosePixelFormat(hDC, ref pfd);
            SetPixelFormat(hDC, pixelFormat, ref pfd);
            hGLRC = wglCreateContext(hDC);
        }

        public void ShowWindow()
        {
            if (hWnd != IntPtr.Zero)
            {
                ShowWindow(hWnd, SW_SHOW);
                UpdateWindow(hWnd);
            }
        }

        public void HideWindow()
        {
            if (hWnd != IntPtr.Zero)
            {
                ShowWindow(hWnd, SW_HIDE);
            }
        }

        public void SetTitle(string t)
        {
            if (hWnd != IntPtr.Zero)
            {
                SetWindowText(hWnd, t);
                title = t;
            }
        }

        public void SetSize(int w, int h)
        {
            if (hWnd != IntPtr.Zero)
            {
                SetWindowPos(hWnd, IntPtr.Zero, 0, 0, w, h, 0x0040); // SWP_NOMOVE
                width = w;
                height = h;
            }
        }

        public void MakeContextCurrent()
        {
            if (hDC != IntPtr.Zero && hGLRC != IntPtr.Zero)
            {
                wglMakeCurrent(hDC, hGLRC);
            }
        }

        public void SwapBuffers()
        {
            if (hDC != IntPtr.Zero)
            {
                SwapBuffers(hDC);
            }
        }

        public bool IsWindowVisible()
        {
            return hWnd != IntPtr.Zero && IsWindowVisible(hWnd);
        }

        public bool PollEvents()
        {
            MSG msg;
            while (PeekMessage(out msg, hWnd, 0, 0, 1))
            {
                if (msg.message == WM_KEYDOWN)
                {
                    lastKeyPressed = (ConsoleKey)msg.wParam.ToInt32();
                }
                if (msg.message == WM_CLOSE)
                {
                    running = false;
                    DestroyWindow(hWnd);
                    hWnd = IntPtr.Zero;
                }
                TranslateMessage(ref msg);
                DispatchMessage(ref msg);
            }
            return running && IsWindowVisible();
        }

        public void Cleanup()
        {
            if (hGLRC != IntPtr.Zero)
            {
                wglMakeCurrent(IntPtr.Zero, IntPtr.Zero);
                wglDeleteContext(hGLRC);
                hGLRC = IntPtr.Zero;
            }
            if (hWnd != IntPtr.Zero)
            {
                DestroyWindow(hWnd);
                hWnd = IntPtr.Zero;
            }
            if (hDC != IntPtr.Zero)
            {
                ReleaseDC(hWnd, hDC);
                hDC = IntPtr.Zero;
            }
        }

        public int GetWindowWidth()
        {
            if (hWnd != IntPtr.Zero)
            {
                RECT rect;
                GetWindowRect(hWnd, out rect);
                return rect.Right - rect.Left;
            }
            return width;
        }

        public int GetWindowHeight()
        {
            if (hWnd != IntPtr.Zero)
            {
                RECT rect;
                GetWindowRect(hWnd, out rect);
                return rect.Bottom - rect.Top;
            }
            return height;
        }

        public IntPtr GetProcAddress(string name)
        {
            IntPtr addr = wglGetProcAddress(name);
            if (addr == IntPtr.Zero)
            {
                IntPtr module = LoadLibrary("opengl32.dll");
                addr = GetProcAddress(module, name);
            }
            return addr;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr LoadLibrary(string lpFileName);

        [DllImport("kernel32.dll", SetLastError = true, EntryPoint = "GetProcAddress")]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

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
                case WM_CLOSE:
                    running = false;
                    DestroyWindow(hWnd);
                    return IntPtr.Zero;
                case WM_KEYDOWN:
                    lastKeyPressed = (ConsoleKey)wParam.ToInt32();
                    break;
                case WM_SIZE:
                    width = lParam.ToInt32() & 0xFFFF;
                    height = (lParam.ToInt32() >> 16) & 0xFFFF;
                    break;
                case WM_DESTROY:
                    running = false;
                    break;
            }
            return DefWindowProc(hWnd, msg, wParam, lParam);
        }
    }
}
#endif
