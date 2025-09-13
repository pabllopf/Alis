// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WinNativePlatform.cs
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

#if winx64
using System;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Logging;
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
        /// <summary>
        /// 
        /// </summary>
        private const string WindowClassName = "AlisWin32GLWindow";

        /// <summary>
        /// 
        /// </summary>
        private const int CwUsedefault = unchecked((int) 0x80000000);

        /// <summary>
        /// 
        /// </summary>
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
        /// <summary>
        /// 
        /// </summary>
        private IntPtr hInstance;

        /// <summary>
        /// 
        /// </summary>
        private IntPtr hWnd;

        /// <summary>
        /// 
        /// </summary>
        private IntPtr hDc;

        /// <summary>
        /// 
        /// </summary>
        private IntPtr hGlrc;

        /// <summary>
        /// 
        /// </summary>
        private int width;

        /// <summary>
        /// 
        /// </summary>
        private int height;

        /// <summary>
        /// 
        /// </summary>
        private string title;

        /// <summary>
        /// 
        /// </summary>
        private ConsoleKey? lastKeyPressed = null;

        /// <summary>
        /// 
        /// </summary>
        private bool running = true;

        /// <summary>
        /// 
        /// </summary>
        private WndProc wndProcDelegate;

        /// <summary>
        /// 
        /// </summary>
        private IntPtr wndProcPtr;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="lpModuleName"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);


        // ------------------------------------------------------------------
        // PUBLIC METHODS
        // ------------------------------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="w"></param>
        /// <param name="h"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Initialize(int w, int h, string t)
        {
            width = w;
            height = h;
            title = t;
            hInstance = GetModuleHandle(null);
            wndProcDelegate = WindowProc;
            wndProcPtr = Marshal.GetFunctionPointerForDelegate(wndProcDelegate);
            // Usa un nombre de clase único para evitar conflictos y asegurar el registro correcto
            string className = WindowClassName + "_" + Guid.NewGuid().ToString("N");
            Wndclass wc = new Wndclass
            {
                style = (uint) ClassStyles.OwnDC,
                lpfnWndProc = wndProcPtr,
                cbClsExtra = 0,
                cbWndExtra = 0,
                hInstance = hInstance,
                hIcon = IntPtr.Zero,
                hCursor = IntPtr.Zero,
                hbrBackground = IntPtr.Zero,
                lpszMenuName = WindowClassName,
                lpszClassName = className
            };
            ushort regResult = User32.RegisterClass(ref wc);
            if (regResult == 0)
            {
                int win32Err = Marshal.GetLastWin32Error();
                string meaning = GetWin32ErrorMeaning(win32Err);
                Logger.Info($"Failed to register window class '{className}' (RegisterClass returned 0x0), Win32 error: {win32Err} - {meaning}");
                return false;
            }

            // Try all combinations for maximum compatibility
            var styleCombos = new[]
            {
                (WindowStyles.OverlappedWindow | WindowStyles.Visible),
                //(WindowStyles.OverlappedWindow),
                //(WindowStyles.Visible),
                //(WindowStyles.Popup | WindowStyles.Visible),
                //(WindowStyles.Popup),
                //(WindowStyles.Child | WindowStyles.Visible),
                //(WindowStyles.Child),
                //(WindowStyles.Border | WindowStyles.Visible),
                //(WindowStyles.Border),
            };
            var exStyles = new[]
            {
                //(int)WindowExStyles.None,
                (int)WindowExStyles.AppWindow,
                /*(int)WindowExStyles.Topmost,
                (int)WindowExStyles.ToolWindow,
                (int)WindowExStyles.WindowEdge,
                (int)WindowExStyles.ClientEdge,
                (int)WindowExStyles.ContextHelp,
                (int)WindowExStyles.Layered,
                (int)WindowExStyles.StaticEdge,
                (int)WindowExStyles.ControlParent,
                (int)WindowExStyles.Transparent,
                (int)WindowExStyles.AcceptFiles,
                (int)WindowExStyles.NoActivate,
                (int)WindowExStyles.Composited,
                (int)WindowExStyles.DlgModalFrame,
                (int)WindowExStyles.MdiChild,
                (int)WindowExStyles.NoParentNotify,*/
            };
            var sizes = new[]
            {
                //(width, height),
                (800, 600),
                //(1024, 768),
                //(640, 480),
            };
            hWnd = IntPtr.Zero;
            bool windowCreated = false;
            string lastErrorMsg = "";
            foreach (var exStyle in exStyles)
            {
                foreach (var style in styleCombos)
                {
                    // Avoid invalid combinations: WS_CHILD with WS_EX_APPWINDOW
                    if ((style & WindowStyles.Child) != 0 && exStyle == (int)WindowExStyles.AppWindow)
                        continue;
                    foreach (var sz in sizes)
                    {
                        hWnd = User32.CreateWindowEx(exStyle, className, title,
                            (int)style,
                            CwUsedefault, CwUsedefault, sz.Item1, sz.Item2,
                            IntPtr.Zero, IntPtr.Zero, hInstance, IntPtr.Zero);
                        if (hWnd != IntPtr.Zero)
                        {
                            Logger.Info($"Window created successfully with exStyle: 0x{exStyle:X}, style: 0x{(int)style:X}, size: {sz.Item1}x{sz.Item2}");
                            windowCreated = true;
                            break;
                        }
                        else
                        {
                            int win32Err = Marshal.GetLastWin32Error();
                            string meaning = GetWin32ErrorMeaning(win32Err);
                            lastErrorMsg = $"Failed to create window with exStyle: 0x{exStyle:X}, style: 0x{(int)style:X}, size: {sz.Item1}x{sz.Item2}, Win32 error: {win32Err} - {meaning}";
                            Logger.Info(lastErrorMsg);
                        }
                    }
                    if (windowCreated) break;
                }
                if (windowCreated) break;
            }
            if (!windowCreated)
            {
                Logger.Info($"Could not create Win32 window after several attempts. Last error: {lastErrorMsg}");
                return false;
            }

            hDc = User32.GetDC(hWnd);
            if (hDc == IntPtr.Zero)
            {
                Logger.Info("No se pudo obtener el HDC de la ventana (GetDC devolvió 0x0)");
                return false;
            }

            // Lista de configuraciones a probar
            Pixelformatdescriptor[] configs = new[]
            {
                new Pixelformatdescriptor
                {
                    nSize = (ushort) Marshal.SizeOf(typeof(Pixelformatdescriptor)),
                    nVersion = 1,
                    dwFlags = (uint) (PixelFormatFlags.DrawToWindow | PixelFormatFlags.SupportOpenGL | PixelFormatFlags.DoubleBuffer),
                    iPixelType = (byte) PixelType.RGBA,
                    cColorBits = 32,
                    cRedBits = 8,
                    cGreenBits = 8,
                    cBlueBits = 8,
                    cAlphaBits = 8,
                    cDepthBits = 24,
                    cStencilBits = 8,
                    iLayerType = (byte) LayerType.MainPlane
                },
                new Pixelformatdescriptor
                {
                    nSize = (ushort) Marshal.SizeOf(typeof(Pixelformatdescriptor)),
                    nVersion = 1,
                    dwFlags = (uint) (PixelFormatFlags.DrawToWindow | PixelFormatFlags.SupportOpenGL),
                    iPixelType = (byte) PixelType.RGBA,
                    cColorBits = 24,
                    cRedBits = 8,
                    cGreenBits = 8,
                    cBlueBits = 8,
                    cAlphaBits = 0,
                    cDepthBits = 0,
                    cStencilBits = 0,
                    iLayerType = (byte) LayerType.MainPlane
                },
                new Pixelformatdescriptor
                {
                    nSize = (ushort) Marshal.SizeOf(typeof(Pixelformatdescriptor)),
                    nVersion = 1,
                    dwFlags = (uint) (PixelFormatFlags.DrawToWindow | PixelFormatFlags.SupportOpenGL | PixelFormatFlags.DoubleBuffer),
                    iPixelType = (byte) PixelType.RGBA,
                    cColorBits = 16,
                    cRedBits = 5,
                    cGreenBits = 6,
                    cBlueBits = 5,
                    cAlphaBits = 0,
                    cDepthBits = 16,
                    cStencilBits = 0,
                    iLayerType = (byte) LayerType.MainPlane
                }
            };
            bool contextOk = false;
            for (int i = 0; i < configs.Length; i++)
            {
                var pfd = configs[i];
                int pixelFormat = Gdi32.ChoosePixelFormat(hDc, ref pfd);
                if (pixelFormat == 0) continue;
                if (!Gdi32.SetPixelFormat(hDc, pixelFormat, ref pfd)) continue;
                IntPtr dummyContext = Opengl32.wglCreateContext(hDc);
                if (dummyContext == IntPtr.Zero) continue;
                if (!Opengl32.wglMakeCurrent(hDc, dummyContext))
                {
                    Opengl32.wglDeleteContext(dummyContext);
                    continue;
                }

                // Intentar contexto moderno
                IntPtr procAttribs = Opengl32.wglGetProcAddress("wglCreateContextAttribsARB");
                if (procAttribs != IntPtr.Zero)
                {
                    WglCreateContextAttribsARB wglCreateContextAttribsARB = Marshal.GetDelegateForFunctionPointer<WglCreateContextAttribsARB>(procAttribs);
                    int[] attribs = new int[]
                    {
                        0x2091, 3, // WGL_CONTEXT_MAJOR_VERSION_ARB, 3
                        0x2092, 3, // WGL_CONTEXT_MINOR_VERSION_ARB, 3
                        0x9126, 0x00000001, // WGL_CONTEXT_PROFILE_MASK_ARB, WGL_CONTEXT_CORE_PROFILE_BIT_ARB
                        0 // End
                    };
                    IntPtr modernContext = wglCreateContextAttribsARB(hDc, IntPtr.Zero, attribs);
                    if (modernContext != IntPtr.Zero)
                    {
                        Opengl32.wglMakeCurrent(IntPtr.Zero, IntPtr.Zero);
                        Opengl32.wglDeleteContext(dummyContext);
                        hGlrc = modernContext;
                        if (Opengl32.wglMakeCurrent(hDc, hGlrc))
                        {
                            contextOk = true;
                            break;
                        }
                        else
                        {
                            Opengl32.wglDeleteContext(hGlrc);
                            hGlrc = IntPtr.Zero;
                        }
                    }
                }

                // Si no hay contexto moderno, usar dummy
                hGlrc = dummyContext;
                contextOk = true;
                break;
            }

            if (!contextOk)
            {
                Logger.Info("No se pudo crear el contexto OpenGL con ninguna configuración. Verifica drivers y compatibilidad OpenGL en tu sistema.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Shows the window.
        /// </summary>
        public void ShowWindow()
        {
            if (hWnd != IntPtr.Zero)
            {
                User32.ShowWindow(hWnd, (int) ShowWindowCommand.Show);
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
                User32.ShowWindow(hWnd, (int) ShowWindowCommand.Hide);
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
                if (msg.message == (uint) WindowMessage.KeyDown)
                {
                    lastKeyPressed = (ConsoleKey) msg.wParam.ToInt32();
                }

                if (msg.message == (uint) WindowMessage.Close)
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
            switch ((WindowMessage) msg)
            {
                case WindowMessage.Close:
                    running = false;
                    User32.DestroyWindow(hWnd);
                    return IntPtr.Zero;
                case WindowMessage.KeyDown:
                    lastKeyPressed = (ConsoleKey) wParam.ToInt32();
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

        /// <summary>
        /// 
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate IntPtr WglCreateContextAttribsARB(IntPtr hdc, IntPtr hShareContext, int[] attribs);

        private string GetWin32ErrorMeaning(int errorCode)
        {
            switch (errorCode)
            {
                case 1406: return "ERROR_CREATE_FAILED: Cannot create a top-level child window.";
                case 1407: return "ERROR_NO_WINDOW_CLASS: Cannot find window class.";
                case 2: return "ERROR_FILE_NOT_FOUND: The system cannot find the file specified.";
                case 5: return "ERROR_ACCESS_DENIED: Access is denied.";
                case 87: return "ERROR_INVALID_PARAMETER: The parameter is incorrect.";
                case 8: return "ERROR_NOT_ENOUGH_MEMORY: Not enough storage is available to process this command.";
                case 1816: return "ERROR_NOT_ENOUGH_QUOTA: Not enough quota is available to process this command.";
                default: return "Unknown error.";
            }
        }
    }
}
#endif
// --------------------------------------------------------------------------
// End of Win32NativePlatform.cs
// --------------------------------------------------------------------------