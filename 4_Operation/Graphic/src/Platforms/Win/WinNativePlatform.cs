// --------------------------------------------------------------------------
// Win32NativePlatform.cs
// Platform abstraction for Win32 window and OpenGL context management
// --------------------------------------------------------------------------
#if WIN
using System;
using System.Runtime.InteropServices;
using Alis.Core.Graphic.Platforms.Win.Native;

namespace Alis.Core.Graphic.Platforms.Win
{
    /// <summary>
    /// Provides a Win32 implementation for native platform window and OpenGL context management.
    /// Designed for scalability and maintainability.
    /// </summary>
    public class WinNativePlatform : INativePlatform
    {
        // ------------------------------------------------------------------
        // CONSTANTS
        // ------------------------------------------------------------------
        private const string WindowClassName = "AlisWin32GLWindow";
        private const int CwUsedefault = unchecked((int)0x80000000);
        private const uint SwpNomove = 0x0040;

        // ------------------------------------------------------------------
        // DELEGATES
        // ------------------------------------------------------------------
        /// <summary>
        /// Delegate for window procedure callback.
        /// </summary>
        private delegate IntPtr WndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        // ------------------------------------------------------------------
        // FIELDS
        // ------------------------------------------------------------------
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

        // ------------------------------------------------------------------
        // PUBLIC METHODS
        // ------------------------------------------------------------------
        /// <summary>
        /// Initializes the Win32 window and OpenGL context.
        /// </summary>
        public void Initialize(int w, int h, string t)
        {
            width = w;
            height = h;
            title = t;
            hInstance = Marshal.GetHINSTANCE(typeof(WinNativePlatform).Module);
            wndProcDelegate = WindowProc;
            wndProcPtr = Marshal.GetFunctionPointerForDelegate(wndProcDelegate);
            var wc = new Wndclass
            {
                style = (uint)ClassStyles.OwnDC,
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
            hWnd = User32.CreateWindowEx((int)WindowExStyles.None, WindowClassName, title,
                (int)(WindowStyles.OverlappedWindow | WindowStyles.Visible),
                CwUsedefault, CwUsedefault, width, height,
                IntPtr.Zero, IntPtr.Zero, hInstance, IntPtr.Zero);
            hDc = User32.GetDC(hWnd);
            var pfd = new Pixelformatdescriptor
            {
                nSize = (ushort)Marshal.SizeOf(typeof(Pixelformatdescriptor)),
                nVersion = 1,
                dwFlags = (uint)(PixelFormatFlags.DrawToWindow | PixelFormatFlags.SupportOpenGL | PixelFormatFlags.DoubleBuffer),
                iPixelType = (byte)PixelType.RGBA,
                cColorBits = 32,
                cDepthBits = 24,
                iLayerType = (byte)LayerType.MainPlane
            };
            int pixelFormat = Gdi32.ChoosePixelFormat(hDc, ref pfd);
            Gdi32.SetPixelFormat(hDc, pixelFormat, ref pfd);
            hGlrc = Opengl32.wglCreateContext(hDc);
        }

        /// <summary>
        /// Shows the window.
        /// </summary>
        public void ShowWindow()
        {
            if (hWnd != IntPtr.Zero)
            {
                User32.ShowWindow(hWnd, (int)ShowWindowCommand.Show);
                User32.UpdateWindow(hWnd);
            }
        }

        /// <summary>
        /// Hides the window.
        /// </summary>
        public void HideWindow()
        {
            if (hWnd != IntPtr.Zero)
            {
                User32.ShowWindow(hWnd, (int)ShowWindowCommand.Hide);
            }
        }

        /// <summary>
        /// Sets the window title.
        /// </summary>
        public void SetTitle(string t)
        {
            if (hWnd != IntPtr.Zero)
            {
                User32.SetWindowText(hWnd, t);
                title = t;
            }
        }

        /// <summary>
        /// Sets the window size.
        /// </summary>
        public void SetSize(int w, int h)
        {
            if (hWnd != IntPtr.Zero)
            {
                User32.SetWindowPos(hWnd, IntPtr.Zero, 0, 0, w, h, SwpNomove); // SWP_NOMOVE
                width = w;
                height = h;
            }
        }

        /// <summary>
        /// Makes the OpenGL context current.
        /// </summary>
        public void MakeContextCurrent()
        {
            if (hDc != IntPtr.Zero && hGlrc != IntPtr.Zero)
            {
                Opengl32.wglMakeCurrent(hDc, hGlrc);
            }
        }

        /// <summary>
        /// Swaps the front and back buffers.
        /// </summary>
        public void SwapBuffers()
        {
            if (hDc != IntPtr.Zero)
            {
                Gdi32.SwapBuffers(hDc);
            }
        }

        /// <summary>
        /// Returns whether the window is visible.
        /// </summary>
        public bool IsWindowVisible()
        {
            return hWnd != IntPtr.Zero && User32.IsWindowVisible(hWnd);
        }

        /// <summary>
        /// Polls and processes window events.
        /// </summary>
        public bool PollEvents()
        {
            Msg msg;
            while (User32.PeekMessage(out msg, hWnd, 0, 0, 1))
            {
                if (msg.message == (uint)WindowMessage.KeyDown)
                {
                    lastKeyPressed = (ConsoleKey)msg.wParam.ToInt32();
                }
                if (msg.message == (uint)WindowMessage.Close)
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

        /// <summary>
        /// Cleans up resources and destroys the window and OpenGL context.
        /// </summary>
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

        /// <summary>
        /// Gets the current window width.
        /// </summary>
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

        /// <summary>
        /// Gets the current window height.
        /// </summary>
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

        /// <summary>
        /// Gets the address of an OpenGL function.
        /// </summary>
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

        /// <summary>
        /// Tries to get the last key pressed.
        /// </summary>
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

        // ------------------------------------------------------------------
        // PRIVATE METHODS
        // ------------------------------------------------------------------
        /// <summary>
        /// Window procedure callback for handling window messages.
        /// </summary>
        private IntPtr WindowProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
        {
            switch ((WindowMessage)msg)
            {
                case WindowMessage.Close:
                    running = false;
                    User32.DestroyWindow(hWnd);
                    return IntPtr.Zero;
                case WindowMessage.KeyDown:
                    lastKeyPressed = (ConsoleKey)wParam.ToInt32();
                    break;
                case WindowMessage.Size:
                    width = lParam.ToInt32() & 0xFFFF;
                    height = (lParam.ToInt32() >> 16) & 0xFFFF;
                    break;
                case WindowMessage.Destroy:
                    running = false;
                    break;
            }
            return User32.DefWindowProc(hWnd, msg, wParam, lParam);
        }
    }
}
#endif
// --------------------------------------------------------------------------
// End of Win32NativePlatform.cs
// --------------------------------------------------------------------------
