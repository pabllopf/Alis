// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Sdl2TestBootstrap.cs
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
using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Sdl2.Enums;
using Xunit;

/// <summary>
///     Runtime startup hook invoked by the .NET runtime on the main thread before the entry point when
///     <c>DOTNET_STARTUP_HOOKS</c> points at this assembly and <c>ALIS_SDL2_HOOK=1</c> is set.
/// </summary>
public static class StartupHook
{
    /// <summary>
    ///     Initializes the SDL2 bootstrap on the main thread.
    /// </summary>
    public static void Initialize()
    {
        try
        {
            if (Environment.GetEnvironmentVariable("ALIS_SDL2_HOOK") == "1")
            {
                Alis.Extension.Graphic.Sdl2.Test.Sdl2TestBootstrap.Initialize();
            }
        }
        catch (Exception)
        {
        }
    }
}

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    ///     Initializes SDL2 on the process main thread and records the results of the window-subsystem wrapper calls.
    ///     SDL2's Cocoa driver requires main-menu and window operations on the process main thread, so this bootstrap is
    ///     triggered from the <see cref="StartupHook" /> which the runtime executes on the main thread before the entry
    ///     point. The tests assert the recorded results and are harmless no-ops when the hook is not installed.
    /// </summary>
    internal static class Sdl2TestBootstrap
    {
        /// <summary>
        ///     The recorded video init result
        /// </summary>
        internal static int InitResult = -1;

        /// <summary>
        ///     The recorded hidden window handle
        /// </summary>
        internal static IntPtr WindowHandle;

        /// <summary>
        ///     The recorded window and renderer creation result
        /// </summary>
        internal static int WindowAndRendererResult = -1;

        /// <summary>
        ///     The recorded GL context result for a null window
        /// </summary>
        internal static IntPtr ContextResult;

        /// <summary>
        ///     The recorded cursor handle
        /// </summary>
        internal static IntPtr CursorHandle;

        /// <summary>
        ///     Indicates whether the bootstrap completed successfully on the main thread
        /// </summary>
        internal static bool Ready;

        /// <summary>
        ///     Initializes SDL2 video and exercises the window-subsystem wrapper members on the main thread
        /// </summary>
        internal static void Initialize()
        {
            if (Ready)
            {
                return;
            }

            InitResult = Sdl.Init(InitSettings.InitVideo);
            if (InitResult == 0)
            {
                WindowHandle = Sdl.CreateWindow("alis-coverage", 0, 0, 64, 64, WindowSettings.WindowHidden);
                if (WindowHandle != IntPtr.Zero)
                {
                    NativeSdl.InternalDestroyWindow(WindowHandle);
                }

                WindowAndRendererResult = Sdl.CreateWindowAndRenderer(64, 64, WindowSettings.WindowHidden, out IntPtr window, out IntPtr renderer);
                if (renderer != IntPtr.Zero)
                {
                    NativeSdl.InternalDestroyRenderer(renderer);
                }

                if (window != IntPtr.Zero)
                {
                    NativeSdl.InternalDestroyWindow(window);
                }

                ContextResult = Sdl.CreateContext(IntPtr.Zero);

                byte[] data = new byte[8];
                byte[] mask = new byte[8];
                GCHandle dataHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
                GCHandle maskHandle = GCHandle.Alloc(mask, GCHandleType.Pinned);
                try
                {
                    CursorHandle = Sdl.CreateCursor(dataHandle.AddrOfPinnedObject(), maskHandle.AddrOfPinnedObject(), 8, 8, 0, 0);
                    if (CursorHandle != IntPtr.Zero)
                    {
                        NativeSdl.InternalFreeCursor(CursorHandle);
                    }
                }
                finally
                {
                    dataHandle.Free();
                    maskHandle.Free();
                }

                Sdl.Quit();
            }

            Ready = true;
        }

        /// <summary>
        ///     Ensures the bootstrap ran; throws a skip signal when SDL2 could not be initialized on the main thread
        /// </summary>
        internal static void EnsureReady()
        {
            Assert.True(Ready, "SDL2 main-thread bootstrap is unavailable; run with ALIS_SDL2_HOOK=1 and DOTNET_STARTUP_HOOKS set.");
        }
    }
}
