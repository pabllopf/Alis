// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:LinuxNativePlatform.cs
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

#if linuxx64 || linuxx86 || linuxarm64 || linuxarm || linux
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Alis.Core.Aspect.Logging;
using System.Diagnostics.CodeAnalysis;

namespace Alis.Core.Graphic.Platforms.Linux
{
    /// <summary>
    /// The linux native platform class
    /// </summary>
    /// <seealso cref="INativePlatform"/>
    public class LinuxNativePlatform : INativePlatform
    {
        /// <summary>
        /// 
        /// </summary>
        private IntPtr display = IntPtr.Zero;

        /// <summary>
        /// 
        /// </summary>
        private IntPtr window = IntPtr.Zero;

        /// <summary>
        /// 
        /// </summary>
        private IntPtr glxContext = IntPtr.Zero;

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
        /// The last mouse button state snapshot.
        /// </summary>
        private readonly bool[] mouseButtons = new bool[5];

        /// <summary>
        /// The accumulated text input buffer.
        /// </summary>
        private readonly StringBuilder pendingInputCharacters = new StringBuilder();

        /// <summary>
        /// The accumulated vertical mouse wheel delta.
        /// </summary>
        private float mouseWheelDelta;

        /// <summary>
        /// The WM_DELETE_WINDOW atom used to detect close requests.
        /// </summary>
        private IntPtr wmDeleteWindowAtom = IntPtr.Zero;

        /// <summary>
        /// The WM_PROTOCOLS atom used to validate client messages.
        /// </summary>
        private IntPtr wmProtocolsAtom = IntPtr.Zero;

        /// <summary>
        /// 
        /// </summary>
        private bool windowVisible = false;

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
        /// <param name="display"></param>
        /// <returns></returns>
        [System.Runtime.InteropServices.DllImport("libX11.so.6")]
        [ExcludeFromCodeCoverage]
        private static extern IntPtr XOpenDisplay(IntPtr display);

        /// <summary>
        /// 
        /// </summary>
        [System.Runtime.InteropServices.DllImport("libX11.so.6")]
        [ExcludeFromCodeCoverage]
        private static extern int XDefaultScreen(IntPtr display);

        /// <summary>
        /// 
        /// </summary>
        [System.Runtime.InteropServices.DllImport("libX11.so.6")]
        [ExcludeFromCodeCoverage]
        private static extern IntPtr XRootWindow(IntPtr display, int screen);

        /// <summary>
        /// 
        /// </summary>
        [System.Runtime.InteropServices.DllImport("libX11.so.6")]
        [ExcludeFromCodeCoverage]
        private static extern IntPtr XCreateSimpleWindow(IntPtr display, IntPtr parent, int x, int y, uint width, uint height, uint border_width, ulong border, ulong background);

        /// <summary>
        /// 
        /// </summary>
        [System.Runtime.InteropServices.DllImport("libX11.so.6")]
        [ExcludeFromCodeCoverage]
        private static extern void XMapWindow(IntPtr display, IntPtr window);

        /// <summary>
        /// 
        /// </summary>
        [System.Runtime.InteropServices.DllImport("libX11.so.6")]
        [ExcludeFromCodeCoverage]
        private static extern void XUnmapWindow(IntPtr display, IntPtr window);

        /// <summary>
        /// 
        /// </summary>
        [System.Runtime.InteropServices.DllImport("libX11.so.6")]
        [ExcludeFromCodeCoverage]
        private static extern void XStoreName(IntPtr display, IntPtr window, string name);

        /// <summary>
        /// 
        /// </summary>
        [System.Runtime.InteropServices.DllImport("libX11.so.6")]
        [ExcludeFromCodeCoverage]
        private static extern void XResizeWindow(IntPtr display, IntPtr window, uint width, uint height);

        /// <summary>
        /// 
        /// </summary>
        [System.Runtime.InteropServices.DllImport("libX11.so.6")]
        [ExcludeFromCodeCoverage]
        private static extern void XDestroyWindow(IntPtr display, IntPtr window);

        /// <summary>
        /// 
        /// </summary>
        [System.Runtime.InteropServices.DllImport("libX11.so.6")]
        [ExcludeFromCodeCoverage]
        private static extern void XCloseDisplay(IntPtr display);

        /// <summary>
        /// 
        /// </summary>
        [System.Runtime.InteropServices.DllImport("libX11.so.6")]
        [ExcludeFromCodeCoverage]
        private static extern void XSelectInput(IntPtr display, IntPtr window, long eventMask);

        /// <summary>
        /// 
        /// </summary>
        [System.Runtime.InteropServices.DllImport("libX11.so.6")]
        [ExcludeFromCodeCoverage]
        private static extern int XPending(IntPtr display);

        /// <summary>
        /// 
        /// </summary>
        [System.Runtime.InteropServices.DllImport("libX11.so.6")]
        [ExcludeFromCodeCoverage]
        private static extern int XNextEvent(IntPtr display, ref XEvent xevent);

        /// <summary>
        /// Gets the keyboard translation for the specified key event.
        /// </summary>
        [DllImport("libX11.so.6")]
        [ExcludeFromCodeCoverage]
        private static extern int XLookupString(ref XKeyEvent keyEvent, byte[] buffer, int bytesBuffer, out IntPtr keysymReturn, IntPtr statusInOut);

        /// <summary>
        /// Gets the geometry for the specified drawable.
        /// </summary>
        [DllImport("libX11.so.6")]
        [ExcludeFromCodeCoverage]
        private static extern int XGetGeometry(IntPtr display, IntPtr drawable, out IntPtr rootReturn, out int xReturn, out int yReturn, out uint widthReturn, out uint heightReturn, out uint borderWidthReturn, out uint depthReturn);

        /// <summary>
        /// Translates window coordinates into the destination coordinate space.
        /// </summary>
        [DllImport("libX11.so.6")]
        [ExcludeFromCodeCoverage]
        private static extern int XTranslateCoordinates(IntPtr display, IntPtr srcWindow, IntPtr destWindow, int srcX, int srcY, out int destX, out int destY, out IntPtr childReturn);

        /// <summary>
        /// Interns the specified X11 atom name.
        /// </summary>
        [DllImport("libX11.so.6")]
        [ExcludeFromCodeCoverage]
        private static extern IntPtr XInternAtom(IntPtr display, string atomName, bool onlyIfExists);

        /// <summary>
        /// Registers the WM protocols for the specified window.
        /// </summary>
        [DllImport("libX11.so.6")]
        [ExcludeFromCodeCoverage]
        private static extern int XSetWMProtocols(IntPtr display, IntPtr window, IntPtr[] protocols, int count);

        /// <summary>
        /// Flushes pending X11 requests.
        /// </summary>
        [DllImport("libX11.so.6")]
        [ExcludeFromCodeCoverage]
        private static extern int XFlush(IntPtr display);

        /// <summary>
        /// 
        /// </summary>
        [System.Runtime.InteropServices.DllImport("libGL.so.1")]
        [ExcludeFromCodeCoverage]
        private static extern IntPtr glXChooseVisual(IntPtr display, int screen, int[] attribList);

        /// <summary>
        /// 
        /// </summary>
        [System.Runtime.InteropServices.DllImport("libGL.so.1")]
        [ExcludeFromCodeCoverage]
        private static extern IntPtr glXCreateContext(IntPtr display, IntPtr visual, IntPtr shareList, int direct);

        /// <summary>
        /// 
        /// </summary>
        [System.Runtime.InteropServices.DllImport("libGL.so.1")]
        [ExcludeFromCodeCoverage]
        private static extern void glXMakeCurrent(IntPtr display, IntPtr drawable, IntPtr ctx);

        /// <summary>
        /// 
        /// </summary>
        [System.Runtime.InteropServices.DllImport("libGL.so.1")]
        [ExcludeFromCodeCoverage]
        private static extern void glXSwapBuffers(IntPtr display, IntPtr drawable);

        /// <summary>
        /// 
        /// </summary>
        [System.Runtime.InteropServices.DllImport("libGL.so.1")]
        [ExcludeFromCodeCoverage]
        private static extern void glXDestroyContext(IntPtr display, IntPtr ctx);

        /// <summary>
        /// 
        /// </summary>
        [System.Runtime.InteropServices.DllImport("libGL.so.1")]
        [ExcludeFromCodeCoverage]
        private static extern IntPtr glXGetProcAddress(byte[] name);

        /// <summary>
        /// 
        /// </summary>
        [System.Runtime.InteropServices.DllImport("libGL.so.1")]
        [ExcludeFromCodeCoverage]
        private static extern IntPtr glXChooseFBConfig(IntPtr display, int screen, int[] attribList, out int nitems);

        /// <summary>
        /// 
        /// </summary>
        [System.Runtime.InteropServices.DllImport("libGL.so.1")]
        [ExcludeFromCodeCoverage]
        private static extern IntPtr glXGetVisualFromFBConfig(IntPtr display, IntPtr fbConfig);

        // Estructuras X11
        /// <summary>
        /// The visual info
        /// </summary>
        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        private struct XVisualInfo
        {
            /// <summary>
            /// The visual
            /// </summary>
            public IntPtr visual;

            /// <summary>
            /// The visualid
            /// </summary>
            public IntPtr visualid;

            /// <summary>
            /// The screen
            /// </summary>
            public int screen;

            /// <summary>
            /// The depth
            /// </summary>
            public int depth;

            /// <summary>
            /// The cclass
            /// </summary>
            public int cclass;

            /// <summary>
            /// The red mask
            /// </summary>
            public ulong red_mask;

            /// <summary>
            /// The green mask
            /// </summary>
            public ulong green_mask;

            /// <summary>
            /// The blue mask
            /// </summary>
            public ulong blue_mask;

            /// <summary>
            /// The colormap size
            /// </summary>
            public int colormap_size;

            /// <summary>
            /// The bits per rgb
            /// </summary>
            public int bits_per_rgb;
        }

        /// <summary>
        /// Xes the create colormap using the specified display
        /// </summary>
        /// <param name="display">The display</param>
        /// <param name="window">The window</param>
        /// <param name="visual">The visual</param>
        /// <param name="alloc">The alloc</param>
        /// <returns>The int ptr</returns>
        [System.Runtime.InteropServices.DllImport("libX11.so.6")]
        [ExcludeFromCodeCoverage]
        private static extern IntPtr XCreateColormap(IntPtr display, IntPtr window, IntPtr visual, int alloc);

        /// <summary>
        /// Xes the create window using the specified display
        /// </summary>
        /// <param name="display">The display</param>
        /// <param name="parent">The parent</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="border_width">The border width</param>
        /// <param name="depth">The depth</param>
        /// <param name="class_">The class</param>
        /// <param name="visual">The visual</param>
        /// <param name="valuemask">The valuemask</param>
        /// <param name="attributes">The attributes</param>
        /// <returns>The int ptr</returns>
        [System.Runtime.InteropServices.DllImport("libX11.so.6")]
        [ExcludeFromCodeCoverage]
        private static extern IntPtr XCreateWindow(IntPtr display, IntPtr parent, int x, int y, uint width, uint height, uint border_width, int depth, uint class_, IntPtr visual, ulong valuemask, ref XSetWindowAttributes attributes);

        /// <summary>
        /// The set window attributes
        /// </summary>
        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        private struct XSetWindowAttributes
        {
            /// <summary>
            /// The background pixmap
            /// </summary>
            public IntPtr background_pixmap;

            /// <summary>
            /// The background pixel
            /// </summary>
            public ulong background_pixel;

            /// <summary>
            /// The border pixmap
            /// </summary>
            public IntPtr border_pixmap;

            /// <summary>
            /// The border pixel
            /// </summary>
            public ulong border_pixel;

            /// <summary>
            /// The bit gravity
            /// </summary>
            public int bit_gravity;

            /// <summary>
            /// The win gravity
            /// </summary>
            public int win_gravity;

            /// <summary>
            /// The backing store
            /// </summary>
            public int backing_store;

            /// <summary>
            /// The backing planes
            /// </summary>
            public ulong backing_planes;

            /// <summary>
            /// The backing pixel
            /// </summary>
            public ulong backing_pixel;

            /// <summary>
            /// The save under
            /// </summary>
            public int save_under;

            /// <summary>
            /// The event mask
            /// </summary>
            public IntPtr event_mask;

            /// <summary>
            /// The do not propagate mask
            /// </summary>
            public IntPtr do_not_propagate_mask;

            /// <summary>
            /// The override redirect
            /// </summary>
            public int override_redirect;

            /// <summary>
            /// The colormap
            /// </summary>
            public IntPtr colormap;

            /// <summary>
            /// The cursor
            /// </summary>
            public IntPtr cursor;
        }

        /// <summary>
        /// Xes the get visual info using the specified display
        /// </summary>
        /// <param name="display">The display</param>
        /// <param name="vinfo_mask">The vinfo mask</param>
        /// <param name="vinfo_template">The vinfo template</param>
        /// <param name="nitems">The nitems</param>
        /// <returns>The int ptr</returns>
        [System.Runtime.InteropServices.DllImport("libX11.so.6")]
        [ExcludeFromCodeCoverage]
        private static extern IntPtr XGetVisualInfo(IntPtr display, long vinfo_mask, ref XVisualInfo vinfo_template, ref int nitems);

        /// <summary>
        /// The visual id mask
        /// </summary>
        private const long VisualIDMask = 0x2;

        // Constantes de eventos X11
        /// <summary>
        /// The exposure mask
        /// </summary>
        private const long ExposureMask = 0x00008000L;

        /// <summary>
        /// The key release mask
        /// </summary>
        private const long KeyReleaseMask = 0x00000002L;

        /// <summary>
        /// The button press mask
        /// </summary>
        private const long ButtonPressMask = 0x00000004L;

        /// <summary>
        /// The button release mask
        /// </summary>
        private const long ButtonReleaseMask = 0x00000008L;

        /// <summary>
        /// The enter window mask
        /// </summary>
        private const long EnterWindowMask = 0x00000010L;

        /// <summary>
        /// The leave window mask
        /// </summary>
        private const long LeaveWindowMask = 0x00000020L;

        /// <summary>
        /// The pointer motion mask
        /// </summary>
        private const long PointerMotionMask = 0x00000040L;

        /// <summary>
        /// The visibility change mask
        /// </summary>
        private const long VisibilityChangeMask = 0x00010000L;

        /// <summary>
        /// The focus change mask
        /// </summary>
        private const long FocusChangeMask = 0x00200000L;

        /// <summary>
        /// The property change mask
        /// </summary>
        private const long PropertyChangeMask = 0x00400000L;

        /// <summary>
        /// The key press mask
        /// </summary>
        private const long KeyPressMask = 0x00000001L;

        /// <summary>
        /// The structure notify mask
        /// </summary>
        private const long StructureNotifyMask = 0x00020000L;

        /// <summary>
        /// The key press
        /// </summary>
        private const int KeyPress = 2;

        /// <summary>
        /// The key release
        /// </summary>
        private const int KeyRelease = 3;

        /// <summary>
        /// The button press
        /// </summary>
        private const int ButtonPress = 4;

        /// <summary>
        /// The button release
        /// </summary>
        private const int ButtonRelease = 5;

        /// <summary>
        /// The motion notify
        /// </summary>
        private const int MotionNotify = 6;

        /// <summary>
        /// The enter notify
        /// </summary>
        private const int EnterNotify = 7;

        /// <summary>
        /// The leave notify
        /// </summary>
        private const int LeaveNotify = 8;

        /// <summary>
        /// The focus in
        /// </summary>
        private const int FocusIn = 9;

        /// <summary>
        /// The focus out
        /// </summary>
        private const int FocusOut = 10;

        /// <summary>
        /// The expose
        /// </summary>
        private const int Expose = 12;

        /// <summary>
        /// The visibility notify
        /// </summary>
        private const int VisibilityNotify = 15;

        /// <summary>
        /// The unmap notify
        /// </summary>
        private const int UnmapNotify = 18;

        /// <summary>
        /// The map notify
        /// </summary>
        private const int MapNotify = 19;

        /// <summary>
        /// The configure notify
        /// </summary>
        private const int ConfigureNotify = 22;

        /// <summary>
        /// The client message
        /// </summary>
        private const int ClientMessage = 33;

        /// <summary>
        /// The destroy notify
        /// </summary>
        private const int DestroyNotify = 17;

        /// <summary>
        /// The X11 keysym for Escape.
        /// </summary>
        private const ulong XkEscape = 0xFF1B;

        /// <summary>
        /// The X11 keysym for Backspace.
        /// </summary>
        private const ulong XkBackSpace = 0xFF08;

        /// <summary>
        /// The X11 keysym for Tab.
        /// </summary>
        private const ulong XkTab = 0xFF09;

        /// <summary>
        /// The X11 keysym for Return.
        /// </summary>
        private const ulong XkReturn = 0xFF0D;

        /// <summary>
        /// The X11 keysym for Delete.
        /// </summary>
        private const ulong XkDelete = 0xFFFF;

        /// <summary>
        /// The X11 keysym for Home.
        /// </summary>
        private const ulong XkHome = 0xFF50;

        /// <summary>
        /// The X11 keysym for Left.
        /// </summary>
        private const ulong XkLeft = 0xFF51;

        /// <summary>
        /// The X11 keysym for Up.
        /// </summary>
        private const ulong XkUp = 0xFF52;

        /// <summary>
        /// The X11 keysym for Right.
        /// </summary>
        private const ulong XkRight = 0xFF53;

        /// <summary>
        /// The X11 keysym for Down.
        /// </summary>
        private const ulong XkDown = 0xFF54;

        /// <summary>
        /// The X11 keysym for PageUp.
        /// </summary>
        private const ulong XkPageUp = 0xFF55;

        /// <summary>
        /// The X11 keysym for PageDown.
        /// </summary>
        private const ulong XkPageDown = 0xFF56;

        /// <summary>
        /// The X11 keysym for End.
        /// </summary>
        private const ulong XkEnd = 0xFF57;

        /// <summary>
        /// The X11 keysym for Insert.
        /// </summary>
        private const ulong XkInsert = 0xFF63;

        /// <summary>
        /// The X11 keysym for Menu.
        /// </summary>
        private const ulong XkMenu = 0xFF67;

        /// <summary>
        /// The X11 keysym for Shift left.
        /// </summary>
        private const ulong XkShiftL = 0xFFE1;

        /// <summary>
        /// The X11 keysym for Shift right.
        /// </summary>
        private const ulong XkShiftR = 0xFFE2;

        /// <summary>
        /// The X11 keysym for Control left.
        /// </summary>
        private const ulong XkControlL = 0xFFE3;

        /// <summary>
        /// The X11 keysym for Control right.
        /// </summary>
        private const ulong XkControlR = 0xFFE4;

        /// <summary>
        /// The X11 keysym for Alt left.
        /// </summary>
        private const ulong XkAltL = 0xFFE9;

        /// <summary>
        /// The X11 keysym for Alt right.
        /// </summary>
        private const ulong XkAltR = 0xFFEA;

        /// <summary>
        /// The X11 keysym for Super left.
        /// </summary>
        private const ulong XkSuperL = 0xFFEB;

        /// <summary>
        /// The X11 keysym for Super right.
        /// </summary>
        private const ulong XkSuperR = 0xFFEC;

        /// <summary>
        /// The X11 keysym for F1.
        /// </summary>
        private const ulong XkF1 = 0xFFBE;

        /// <summary>
        /// The X11 keysym for F12.
        /// </summary>
        private const ulong XkF12 = 0xFFC9;

        /// <summary>
        /// The visual selection result
        /// </summary>
        private struct VisualSelectionResult
        {
            /// <summary>
            /// The visual ptr
            /// </summary>
            public IntPtr VisualPtr;

            /// <summary>
            /// The visual info
            /// </summary>
            public XVisualInfo VisualInfo;

            /// <summary>
            /// The source
            /// </summary>
            public string Source;
        }

        /// <summary>
        /// Prints the x visual info using the specified prefix
        /// </summary>
        /// <param name="prefix">The prefix</param>
        /// <param name="info">The info</param>
        /// <param name="ptr">The ptr</param>
        private void PrintXVisualInfo(string prefix, XVisualInfo info, IntPtr ptr)
        {
            Logger.Info($"{prefix} visual: ptr=0x{ptr.ToInt64():X}, visualid={info.visualid}, depth={info.depth}, class={info.cclass}, screen={info.screen}, colormap_size={info.colormap_size}, bits_per_rgb={info.bits_per_rgb}, red_mask=0x{info.red_mask:X}, green_mask=0x{info.green_mask:X}, blue_mask=0x{info.blue_mask:X}");
        }

        /// <summary>
        /// Gets the valid visual info using the specified display
        /// </summary>
        /// <param name="display">The display</param>
        /// <param name="screen">The screen</param>
        /// <returns>The visual selection result</returns>
        private VisualSelectionResult? GetValidVisualInfo(IntPtr display, int screen)
        {
            int[][] fbAttribSets = new int[][]
            {
                new int[] {0x8010, 1, 0x8011, 1, 0x6, 1, 0x8012, 1, 0x8, 24, 0},
                new int[] {0x6, 1, 0x8, 24, 0x8010, 1, 0},
                new int[] {0x8010, 1, 0x8012, 1, 0x8, 16, 0},
                new int[] {0x8010, 1, 0x8012, 1, 0}
            };
            foreach (var fbAttribs in fbAttribSets)
            {
                int nitems;
                IntPtr fbConfigs = glXChooseFBConfig(display, screen, fbAttribs, out nitems);
                if (fbConfigs != IntPtr.Zero && nitems > 0)
                {
                    IntPtr fbConfig = System.Runtime.InteropServices.Marshal.ReadIntPtr(fbConfigs);
                    IntPtr visualPtr = glXGetVisualFromFBConfig(display, fbConfig);
                    if (visualPtr != IntPtr.Zero)
                    {
                        XVisualInfo info = System.Runtime.InteropServices.Marshal.PtrToStructure<XVisualInfo>(visualPtr);
                        PrintXVisualInfo("FBConfig", info, visualPtr);
                        // Get canonical XVisualInfo from XGetVisualInfo
                        int nitems2 = 0;
                        IntPtr canonicalPtr = XGetVisualInfo(display, VisualIDMask, ref info, ref nitems2);
                        if (canonicalPtr != IntPtr.Zero && nitems2 > 0)
                        {
                            XVisualInfo canonicalInfo = System.Runtime.InteropServices.Marshal.PtrToStructure<XVisualInfo>(canonicalPtr);
                            PrintXVisualInfo("Canonical", canonicalInfo, canonicalPtr);
                            if (canonicalInfo.cclass == 4)
                                return new VisualSelectionResult {VisualPtr = canonicalPtr, VisualInfo = canonicalInfo, Source = "FBConfig+Canonical"};
                        }
                    }
                }
            }

            int[][] visualAttribSets = new int[][]
            {
                new int[] {0x6, 1, 0x8, 24, 0x8010, 1, 0},
                new int[] {0x6, 1, 0x8, 16, 0},
                new int[] {0x6, 1, 0}
            };
            foreach (var attribs in visualAttribSets)
            {
                IntPtr visualPtr = glXChooseVisual(display, screen, attribs);
                if (visualPtr != IntPtr.Zero)
                {
                    XVisualInfo info = System.Runtime.InteropServices.Marshal.PtrToStructure<XVisualInfo>(visualPtr);
                    PrintXVisualInfo("Legacy", info, visualPtr);
                    int nitems2 = 0;
                    IntPtr canonicalPtr = XGetVisualInfo(display, VisualIDMask, ref info, ref nitems2);
                    if (canonicalPtr != IntPtr.Zero && nitems2 > 0)
                    {
                        XVisualInfo canonicalInfo = System.Runtime.InteropServices.Marshal.PtrToStructure<XVisualInfo>(canonicalPtr);
                        PrintXVisualInfo("Canonical", canonicalInfo, canonicalPtr);
                        if (canonicalInfo.cclass == 4)
                            return new VisualSelectionResult {VisualPtr = canonicalPtr, VisualInfo = canonicalInfo, Source = "Legacy+Canonical"};
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Initializes the w
        /// </summary>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <param name="t">The </param>
        /// <exception cref="Exception">[OnInit] Error creating the colormap</exception>
        /// <exception cref="Exception">[OnInit] Error creating the X11 window (BadMatch): check the visual and colormap</exception>
        /// <exception cref="Exception">[OnInit] Could not open the X11 display</exception>
        /// <exception cref="Exception">[OnInit] Could not create the GLX context</exception>
        /// <exception cref="Exception">[OnInit] Could not obtain a valid GLX visual (neither FBConfig nor Visual). Make sure libgl1-mesa-glx, libgl1-mesa-dev, and libx11-dev are installed and that you are running on X11, not Wayland.</exception>
        /// <returns>The bool</returns>
        public bool Initialize(int w, int h, string t)
        {
            Logger.Info("[OnInit] Starting LinuxNativePlatform initialization...");
            width = w;
            height = h;
            title = t;
            display = XOpenDisplay(IntPtr.Zero);
            if (display == IntPtr.Zero)
                throw new Exception("[OnInit] Could not open the X11 display");
            int screen = XDefaultScreen(display);
            IntPtr root = XRootWindow(display, screen);
            Logger.Info($"[OnInit] Display opened, screen={screen}, root=0x{root.ToInt64():X}");
            var visualResult = GetValidVisualInfo(display, screen);
            if (!visualResult.HasValue)
            {
                throw new Exception("[OnInit] Could not obtain a valid GLX visual (neither FBConfig nor Visual). Make sure libgl1-mesa-glx, libgl1-mesa-dev, and libx11-dev are installed and that you are running on X11, not Wayland.");
            }

            var visualPtr = visualResult.Value.VisualPtr;
            var visualInfo = visualResult.Value.VisualInfo;
            PrintXVisualInfo("[OnInit] Selected", visualInfo, visualPtr);
            IntPtr colormap = XCreateColormap(display, root, visualInfo.visual, 0);
            if (colormap == IntPtr.Zero)
                throw new Exception("[OnInit] Error creating the colormap");
            Logger.Info($"[OnInit] Colormap created: 0x{colormap.ToInt64():X}");
            XSetWindowAttributes attrs = new XSetWindowAttributes();
            attrs.colormap = colormap;
            attrs.event_mask = (IntPtr) (ExposureMask | KeyPressMask | KeyReleaseMask | ButtonPressMask | ButtonReleaseMask | PointerMotionMask | EnterWindowMask | LeaveWindowMask | StructureNotifyMask | VisibilityChangeMask | FocusChangeMask | PropertyChangeMask);
            ulong CWColormap = 0x00000010;
            ulong CWEventMask = 0x00000080;
            ulong valuemask = CWColormap | CWEventMask;
            window = XCreateWindow(display, root, 0, 0, (uint) width, (uint) height, 0, visualInfo.depth, 1 /*InputOutput*/, visualInfo.visual, valuemask, ref attrs);
            if (window == IntPtr.Zero)
                throw new Exception("[OnInit] Error creating the X11 window (BadMatch): check the visual and colormap");
            Logger.Info($"[OnInit] Window created: 0x{window.ToInt64():X}");
            XStoreName(display, window, title);
            wmProtocolsAtom = XInternAtom(display, "WM_PROTOCOLS", false);
            wmDeleteWindowAtom = XInternAtom(display, "WM_DELETE_WINDOW", false);
            if (wmDeleteWindowAtom != IntPtr.Zero)
            {
                IntPtr[] protocols = new[] { wmDeleteWindowAtom };
                XSetWMProtocols(display, window, protocols, protocols.Length);
            }

            XMapWindow(display, window);
            Logger.Info("[OnInit] Window mapped");
            Logger.Info($"[OnInit] glXCreateContext params: display=0x{display.ToInt64():X}, visualPtr=0x{visualPtr.ToInt64():X}, window=0x{window.ToInt64():X}");
            glxContext = glXCreateContext(display, visualPtr, IntPtr.Zero, 1);
            if (glxContext == IntPtr.Zero)
            {
                Logger.Info("[OnInit] glXCreateContext failed, trying legacy visual fallback...");
                // Try legacy visual fallback
                var legacyVisual = GetValidVisualInfo(display, screen);
                if (legacyVisual.HasValue)
                {
                    glxContext = glXCreateContext(display, legacyVisual.Value.VisualPtr, IntPtr.Zero, 1);
                    if (glxContext != IntPtr.Zero)
                        Logger.Info("[OnInit] Legacy visual context created");
                }
            }

            if (glxContext == IntPtr.Zero)
                throw new Exception("[OnInit] Could not create the GLX context");
            Logger.Info($"[OnInit] GLX context created: 0x{glxContext.ToInt64():X}");
            glXMakeCurrent(display, window, glxContext);
            Logger.Info("[OnInit] GLX context activated");
            // Print OpenGL version
            try
            {
                var glVersion = Alis.Core.Graphic.OpenGL.Gl.GlGetString(Alis.Core.Graphic.OpenGL.Enums.StringName.Version);
                Logger.Info($"[OnInit] OpenGL version: {glVersion}");
            }
            catch (Exception ex)
            {
                Logger.Info($"[OnInit] Error getting the OpenGL version: {ex.Message}");
            }

            windowVisible = true;
            running = true;
            mouseWheelDelta = 0.0f;
            pendingInputCharacters.Clear();
            pressedKeys.Clear();
            mouseButtons[0] = false;
            mouseButtons[1] = false;
            mouseButtons[2] = false;
            mouseButtons[3] = false;
            mouseButtons[4] = false;

            return true;
        }

        /// <summary>
        /// Shows the window
        /// </summary>
        public void ShowWindow()
        {
            if (display != IntPtr.Zero && window != IntPtr.Zero)
            {
                XMapWindow(display, window);
                windowVisible = true;
            }
        }

        /// <summary>
        /// Hides the window
        /// </summary>
        public void HideWindow()
        {
            if (display != IntPtr.Zero && window != IntPtr.Zero)
            {
                XUnmapWindow(display, window);
                windowVisible = false;
            }
        }

        /// <summary>
        /// Sets the title using the specified t
        /// </summary>
        /// <param name="t">The </param>
        public void SetTitle(string t)
        {
            if (display != IntPtr.Zero && window != IntPtr.Zero)
            {
                XStoreName(display, window, t);
                title = t;
            }
        }

        /// <summary>
        /// Sets the size using the specified w
        /// </summary>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        public void SetSize(int w, int h)
        {
            if (display != IntPtr.Zero && window != IntPtr.Zero)
            {
                XResizeWindow(display, window, (uint) w, (uint) h);
                width = w;
                height = h;
            }
        }

        /// <summary>
        /// Makes the context current
        /// </summary>
        public void MakeContextCurrent()
        {
            if (display != IntPtr.Zero && window != IntPtr.Zero && glxContext != IntPtr.Zero)
            {
                glXMakeCurrent(display, window, glxContext);
            }
        }

        /// <summary>
        /// Swaps the buffers
        /// </summary>
        public void SwapBuffers()
        {
            if (display != IntPtr.Zero && window != IntPtr.Zero)
            {
                glXSwapBuffers(display, window);
            }
        }

        /// <summary>
        /// Ises the window visible
        /// </summary>
        /// <returns>The window visible</returns>
        public bool IsWindowVisible()
        {
            return windowVisible;
        }

        /// <summary>
        /// Checks if the specified key is currently pressed down.
        /// </summary>
        /// <param name="key">The key to check.</param>
        /// <returns>True if the key is down, false otherwise.</returns>
        public bool IsKeyDown(ConsoleKey key)
        {
            return pressedKeys.Contains(key);
        }

        /// <summary>
        /// Polls the events
        /// </summary>
        /// <returns>The bool</returns>
        public bool PollEvents()
        {
            if (display == IntPtr.Zero || window == IntPtr.Zero)
                return false;

            while (XPending(display) > 0)
            {
                XEvent xev = new XEvent();
                XNextEvent(display, ref xev);

                switch (xev.type)
                {
                    case KeyPress:
                        HandleKeyEvent(ref xev.xkey, true);
                        break;
                    case KeyRelease:
                        HandleKeyEvent(ref xev.xkey, false);
                        break;
                    case ButtonPress:
                        HandleButtonEvent(ref xev.xbutton, true);
                        break;
                    case ButtonRelease:
                        HandleButtonEvent(ref xev.xbutton, false);
                        break;
                    case MotionNotify:
                        break;
                    case EnterNotify:
                    case FocusIn:
                    case MapNotify:
                    case Expose:
                        windowVisible = true;
                        break;
                    case LeaveNotify:
                    case FocusOut:
                        break;
                    case UnmapNotify:
                        windowVisible = false;
                        break;
                    case VisibilityNotify:
                        windowVisible = xev.xvisibility.state != 2;
                        break;
                    case ConfigureNotify:
                        width = xev.xconfigure.width;
                        height = xev.xconfigure.height;
                        break;
                    case ClientMessage:
                        if (wmDeleteWindowAtom != IntPtr.Zero && wmProtocolsAtom != IntPtr.Zero && xev.xclient.message_type == (UIntPtr) wmProtocolsAtom.ToInt64() && xev.xclient.data0 == wmDeleteWindowAtom)
                        {
                            running = false;
                            windowVisible = false;
                        }

                        break;
                    case DestroyNotify:
                        running = false;
                        windowVisible = false;
                        break;
                }
            }

            return running && windowVisible;
        }

        /// <summary>
        /// Cleanups this instance
        /// </summary>
        public void Cleanup()
        {
            if (display != IntPtr.Zero)
            {
                if (glxContext != IntPtr.Zero)
                {
                    glXMakeCurrent(display, window, IntPtr.Zero);
                    glXDestroyContext(display, glxContext);
                    glxContext = IntPtr.Zero;
                }

                if (window != IntPtr.Zero)
                {
                    XDestroyWindow(display, window);
                    window = IntPtr.Zero;
                }

                XCloseDisplay(display);
                display = IntPtr.Zero;
            }

            running = false;
            windowVisible = false;
            wmProtocolsAtom = IntPtr.Zero;
            wmDeleteWindowAtom = IntPtr.Zero;
            mouseWheelDelta = 0.0f;
            pendingInputCharacters.Clear();
        }

        /// <summary>
        /// Gets the window width
        /// </summary>
        /// <returns>The int</returns>
        public int GetWindowWidth() => width;

        /// <summary>
        /// Gets the window height
        /// </summary>
        /// <returns>The int</returns>
        public int GetWindowHeight() => height;

        /// <summary>
        /// Gets the proc address using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The int ptr</returns>
        public IntPtr GetProcAddress(string name)
        {
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(name + "\0");
            return glXGetProcAddress(bytes);
        }

        /// <summary>
        /// Tries the get last key pressed using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The bool</returns>
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
        /// Creates the window and assigns a BMP icon from the provided path (X11).
        /// </summary>
        public bool Initialize(int width, int height, string title, string iconPath)
        {
            bool result = Initialize(width, height, title);
            if (!result)
                return false;
            
            if (!string.IsNullOrEmpty(iconPath) && System.IO.File.Exists(iconPath))
            {
                SetWindowIconSafe(iconPath);
            }
            else if (!string.IsNullOrEmpty(iconPath))
            {
                Logger.Warning($"[OnInit] Icon file not found: {iconPath}");
            }

            return true;
        }
        
        /// <summary>
        /// Safely attempts to set the window icon from a BMP file
        /// </summary>
        private void SetWindowIconSafe(string iconPath)
        {
            try
            {
                byte[] bmpData = System.IO.File.ReadAllBytes(iconPath);
                
                // Validate BMP header (must start with "BM")
                if (bmpData.Length < 26 || bmpData[0] != 0x42 || bmpData[1] != 0x4D)
                {
                    Logger.Warning("[SetWindowIcon] Invalid BMP file format (missing BM signature)");
                    return;
                }
                
                // Extract dimensions from BMP header (little-endian)
                int iconWidth = BitConverter.ToInt32(bmpData, 18);
                int iconHeight = BitConverter.ToInt32(bmpData, 22);
                
                // Validate dimensions (reasonable limits for icons)
                if (iconWidth <= 0 || iconWidth > 512 || iconHeight <= 0 || iconHeight > 512)
                {
                    Logger.Warning($"[SetWindowIcon] BMP dimensions out of valid range: {iconWidth}x{iconHeight}");
                    return;
                }
                
                int pixelOffset = BitConverter.ToInt32(bmpData, 10);
                if (pixelOffset <= 0 || pixelOffset >= bmpData.Length)
                {
                    Logger.Warning("[SetWindowIcon] Invalid pixel offset in BMP");
                    return;
                }
                
                // Extract only the pixel data (skip BMP headers)
                int pixelDataLength = bmpData.Length - pixelOffset;
                byte[] pixelData = new byte[pixelDataLength];
                System.Array.Copy(bmpData, pixelOffset, pixelData, 0, pixelDataLength);
                
                // Try to create pixmap with extracted pixel data
                IntPtr iconPixmap = XCreatePixmapFromBitmapData(display, window, pixelData, iconWidth, iconHeight);
                
                if (iconPixmap != IntPtr.Zero)
                {
                    XWMHints hints = new XWMHints { flags = 2, icon_pixmap = iconPixmap };
                    XSetWMHints(display, window, ref hints);
                    Logger.Info($"[SetWindowIcon] Icon loaded successfully: {iconWidth}x{iconHeight}");
                }
                else
                {
                    Logger.Warning("[SetWindowIcon] Failed to create pixmap from BMP data");
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                Logger.Warning($"[SetWindowIcon] Icon file not found: {iconPath}");
            }
            catch (System.IO.IOException ex)
            {
                Logger.Warning($"[SetWindowIcon] Error reading icon file: {ex.Message}");
            }
            catch (Exception ex)
            {
                Logger.Warning($"[SetWindowIcon] Error setting window icon: {ex.Message}");
            }
        }

        /// <summary>
        /// The xwm hints
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        private struct XWMHints
        {
            /// <summary>
            /// The flags
            /// </summary>
            public int flags;

            /// <summary>
            /// The input
            /// </summary>
            public IntPtr input;

            /// <summary>
            /// The icon pixmap
            /// </summary>
            public IntPtr icon_pixmap;

            /// <summary>
            /// The icon window
            /// </summary>
            public IntPtr icon_window;

            /// <summary>
            /// The icon
            /// </summary>
            public IntPtr icon_x;

            /// <summary>
            /// The icon
            /// </summary>
            public IntPtr icon_y;

            /// <summary>
            /// The icon mask
            /// </summary>
            public IntPtr icon_mask;

            /// <summary>
            /// The window group
            /// </summary>
            public IntPtr window_group;
        }

        /// <summary>
        /// Xes the set wm hints using the specified display
        /// </summary>
        /// <param name="display">The display</param>
        /// <param name="window">The window</param>
        /// <param name="hints">The hints</param>
        [DllImport("libX11.so")]
        [ExcludeFromCodeCoverage]
        private static extern void XSetWMHints(IntPtr display, IntPtr window, ref XWMHints hints);

        /// <summary>
        /// Xes the create pixmap from bitmap data using the specified display
        /// </summary>
        /// <param name="display">The display</param>
        /// <param name="window">The window</param>
        /// <param name="data">The data</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <returns>The int ptr</returns>
        [DllImport("libX11.so")]
        [ExcludeFromCodeCoverage]
        private static extern IntPtr XCreatePixmapFromBitmapData(IntPtr display, IntPtr window, byte[] data, int width, int height);

        /// <summary>
        /// The console key
        /// </summary>
        private HashSet<ConsoleKey> pressedKeys = new HashSet<ConsoleKey>();

        /// <summary>
        /// Sets the window icon from the specified BMP file path (X11)
        /// </summary>
        public void SetWindowIcon(string iconPath)
        {
            if (display == IntPtr.Zero || window == IntPtr.Zero)
                return;
            
            if (!string.IsNullOrEmpty(iconPath) && System.IO.File.Exists(iconPath))
            {
                SetWindowIconSafe(iconPath);
            }
            else if (!string.IsNullOrEmpty(iconPath))
            {
                Logger.Warning($"[SetWindowIcon] Icon file not found: {iconPath}");
            }
        }

        [System.Runtime.InteropServices.DllImport("libX11.so.6")]
        [ExcludeFromCodeCoverage]
        private static extern bool XQueryPointer(IntPtr display, IntPtr w, out IntPtr root_return, out IntPtr child_return,
            out int root_x_return, out int root_y_return, out int win_x_return, out int win_y_return, out uint mask_return);

        /// <summary>
        /// Gets the mouse position and button state in X11.
        /// </summary>
        public void GetMouseState(out int x, out int y, out bool[] buttons)
        {
            x = 0;
            y = 0;
            buttons = new bool[5];

            if (display == IntPtr.Zero || window == IntPtr.Zero)
            {
                Array.Copy(mouseButtons, buttons, mouseButtons.Length);
                return;
            }

            if (XQueryPointer(display, window, out IntPtr root, out IntPtr child, out int rootx, out int rooty, out int winx, out int winy, out uint mask))
            {
                x = winx;
                y = winy;
                const uint Button1Mask = (1u << 8);
                const uint Button2Mask = (1u << 9);
                const uint Button3Mask = (1u << 10);
                const uint Button4Mask = (1u << 11);
                const uint Button5Mask = (1u << 12);
                buttons[0] = (mask & Button1Mask) != 0;
                buttons[1] = (mask & Button3Mask) != 0;
                buttons[2] = (mask & Button2Mask) != 0;
                buttons[3] = (mask & Button4Mask) != 0;
                buttons[4] = (mask & Button5Mask) != 0;
            }
            else
            {
                Array.Copy(mouseButtons, buttons, mouseButtons.Length);
            }
        }

        /// <summary>
        /// Returns and clears the accumulated mouse wheel delta.
        /// </summary>
        public float GetMouseWheel()
        {
            float value = mouseWheelDelta;
            mouseWheelDelta = 0.0f;
            return value;
        }

        /// <summary>
        /// Returns and clears the accumulated input characters.
        /// </summary>
        /// <param name="chars">The chars</param>
        /// <returns>The bool</returns>
        public bool TryGetLastInputCharacters(out string chars)
        {
            if (pendingInputCharacters.Length > 0)
            {
                chars = pendingInputCharacters.ToString();
                pendingInputCharacters.Clear();
                return true;
            }

            chars = string.Empty;
            return false;
        }

        public int GetWindowPositionX()
        {
            if (TryGetWindowPosition(out int x, out _))
            {
                return x;
            }

            return 0;
        }

        public int GetWindowPositionY()
        {
            if (TryGetWindowPosition(out _, out int y))
            {
                return y;
            }

            return 0;
        }

        public void GetWindowMetrics(out int winX, out int winY, out int winW, out int winH, out int fbW, out int fbH)
        {
            winX = 0;
            winY = 0;
            winW = width;
            winH = height;
            fbW = width;
            fbH = height;

            if (display != IntPtr.Zero && window != IntPtr.Zero)
            {
                TryGetWindowPosition(out winX, out winY);

                if (XGetGeometry(display, window, out IntPtr root, out int geometryX, out int geometryY, out uint geometryWidth, out uint geometryHeight, out uint borderWidth, out uint depth) != 0)
                {
                    winW = (int) geometryWidth;
                    winH = (int) geometryHeight;
                    fbW = winW;
                    fbH = winH;
                }
            }
        }

        public void GetMousePositionInView(out float x, out float y)
        {
            GetMouseState(out int mouseX, out int mouseY, out _);
            x = mouseX;
            y = mouseY;
        }

        /// <summary>
        /// Tries to get the window position using X11 root coordinates.
        /// </summary>
        /// <param name="x">The window x coordinate.</param>
        /// <param name="y">The window y coordinate.</param>
        /// <returns><c>true</c> if the position was resolved, otherwise <c>false</c>.</returns>
        private bool TryGetWindowPosition(out int x, out int y)
        {
            x = 0;
            y = 0;

            if (display == IntPtr.Zero || window == IntPtr.Zero)
            {
                return false;
            }

            IntPtr root = XRootWindow(display, XDefaultScreen(display));
            return XTranslateCoordinates(display, window, root, 0, 0, out x, out y, out IntPtr child) != 0;
        }

        /// <summary>
        /// Handles a keyboard event and updates key, text, and pressed-key state.
        /// </summary>
        /// <param name="keyEvent">The native X11 key event.</param>
        /// <param name="isPressed">Whether the event is a press or release.</param>
        private void HandleKeyEvent(ref XKeyEvent keyEvent, bool isPressed)
        {
            byte[] buffer = new byte[32];
            int length = XLookupString(ref keyEvent, buffer, buffer.Length, out IntPtr keysymPtr, IntPtr.Zero);
            ulong keySym = keysymPtr == IntPtr.Zero ? 0UL : unchecked((ulong)keysymPtr.ToInt64());
            string text = length > 0 ? Encoding.UTF8.GetString(buffer, 0, length) : string.Empty;

            ConsoleKey? mappedKey = MapKeySymToConsoleKey(keySym, text);
            if (mappedKey.HasValue)
            {
                if (isPressed)
                {
                    lastKeyPressed = mappedKey.Value;
                    pressedKeys.Add(mappedKey.Value);
                }
                else
                {
                    pressedKeys.Remove(mappedKey.Value);
                }
            }

            if (isPressed && !string.IsNullOrEmpty(text))
            {
                AppendInputCharacters(text);
            }
        }

        /// <summary>
        /// Handles a mouse button event, including wheel accumulation and extra button state.
        /// </summary>
        /// <param name="buttonEvent">The native X11 button event.</param>
        /// <param name="isPressed">Whether the event is a press or release.</param>
        private void HandleButtonEvent(ref XButtonEvent buttonEvent, bool isPressed)
        {
            switch (buttonEvent.button)
            {
                case 4:
                    if (isPressed)
                    {
                        mouseWheelDelta += 1.0f;
                    }

                    return;
                case 5:
                    if (isPressed)
                    {
                        mouseWheelDelta -= 1.0f;
                    }

                    return;
            }

            UpdateMouseButtonState(buttonEvent.button, isPressed);
        }

        /// <summary>
        /// Updates the cached mouse button snapshot.
        /// </summary>
        /// <param name="button">The X11 button number.</param>
        /// <param name="isPressed">Whether the button is pressed.</param>
        private void UpdateMouseButtonState(uint button, bool isPressed)
        {
            switch (button)
            {
                case 1:
                    mouseButtons[0] = isPressed;
                    break;
                case 3:
                    mouseButtons[1] = isPressed;
                    break;
                case 2:
                    mouseButtons[2] = isPressed;
                    break;
                case 8:
                    mouseButtons[3] = isPressed;
                    break;
                case 9:
                    mouseButtons[4] = isPressed;
                    break;
            }
        }

        /// <summary>
        /// Adds printable characters to the pending text input buffer.
        /// </summary>
        /// <param name="text">The text to append.</param>
        private void AppendInputCharacters(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return;
            }

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                if (!char.IsControl(c))
                {
                    pendingInputCharacters.Append(c);
                }
            }
        }

        /// <summary>
        /// Maps an X11 keysym or translated character to a <see cref="ConsoleKey"/> value.
        /// </summary>
        /// <param name="keySym">The X11 keysym value.</param>
        /// <param name="text">The translated text returned by XLookupString.</param>
        /// <returns>The mapped key if one is available; otherwise <c>null</c>.</returns>
        private ConsoleKey? MapKeySymToConsoleKey(ulong keySym, string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                ConsoleKey? textKey = MapPrintableCharacterToConsoleKey(text[0]);
                if (textKey.HasValue)
                {
                    return textKey;
                }
            }

            if (keySym >= XkF1 && keySym <= XkF12)
            {
                return (ConsoleKey) ((int) ConsoleKey.F1 + (int) (keySym - XkF1));
            }

            if (keySym >= 0xFFB0 && keySym <= 0xFFB9)
            {
                return (ConsoleKey) ((int) ConsoleKey.NumPad0 + (int) (keySym - 0xFFB0));
            }

            switch (keySym)
            {
                case XkEscape:
                    return ConsoleKey.Escape;
                case XkBackSpace:
                    return ConsoleKey.Backspace;
                case XkTab:
                    return ConsoleKey.Tab;
                case XkReturn:
                    return ConsoleKey.Enter;
                case XkDelete:
                    return ConsoleKey.Delete;
                case XkHome:
                    return ConsoleKey.Home;
                case XkEnd:
                    return ConsoleKey.End;
                case XkPageUp:
                    return ConsoleKey.PageUp;
                case XkPageDown:
                    return ConsoleKey.PageDown;
                case XkLeft:
                    return ConsoleKey.LeftArrow;
                case XkRight:
                    return ConsoleKey.RightArrow;
                case XkUp:
                    return ConsoleKey.UpArrow;
                case XkDown:
                    return ConsoleKey.DownArrow;
                case XkInsert:
                    return ConsoleKey.Insert;
                case XkMenu:
                    return ConsoleKey.Menu;
                case XkShiftL:
                    return ConsoleKey.LeftShift;
                case XkShiftR:
                    return ConsoleKey.RightShift;
                case XkControlL:
                    return ConsoleKey.LeftCtrl;
                case XkControlR:
                    return ConsoleKey.RightCtrl;
                case XkAltL:
                    return ConsoleKey.LeftAlt;
                case XkAltR:
                    return ConsoleKey.RightAlt;
                case XkSuperL:
                    return ConsoleKey.LeftWindows;
                case XkSuperR:
                    return ConsoleKey.RightWindows;
                case 0x0020:
                    return ConsoleKey.Spacebar;
                case 0xFFAA:
                    return ConsoleKey.Multiply;
                case 0xFFAB:
                    return ConsoleKey.Add;
                case 0xFFAD:
                    return ConsoleKey.Subtract;
                case 0xFFAE:
                    return ConsoleKey.Decimal;
                case 0xFFAF:
                    return ConsoleKey.Divide;
                case 0xFF8D:
                    return ConsoleKey.Enter;
            }

            return null;
        }

        /// <summary>
        /// Maps a printable character to a <see cref="ConsoleKey"/> value.
        /// </summary>
        /// <param name="c">The printable character.</param>
        /// <returns>The mapped key if one is available; otherwise <c>null</c>.</returns>
        private static ConsoleKey? MapPrintableCharacterToConsoleKey(char c)
        {
            if (c >= 'a' && c <= 'z')
            {
                return (ConsoleKey) ((int) ConsoleKey.A + (c - 'a'));
            }

            if (c >= 'A' && c <= 'Z')
            {
                return (ConsoleKey) ((int) ConsoleKey.A + (c - 'A'));
            }

            if (c >= '0' && c <= '9')
            {
                return (ConsoleKey) ((int) ConsoleKey.D0 + (c - '0'));
            }

            switch (c)
            {
                case ' ':
                    return ConsoleKey.Spacebar;
                case ',':
                    return ConsoleKey.OemComma;
                case '.':
                    return ConsoleKey.OemPeriod;
                case '/':
                    return ConsoleKey.Oem2;
                case ';':
                    return ConsoleKey.Oem1;
                case '\\':
                    return ConsoleKey.Oem5;
                case '[':
                    return ConsoleKey.Oem4;
                case ']':
                    return ConsoleKey.Oem6;
                case '-':
                    return ConsoleKey.OemMinus;
                case '+':
                    return ConsoleKey.OemPlus;
                case '`':
                    return ConsoleKey.Oem3;
            }

            return null;
        }
    }
}


#endif
