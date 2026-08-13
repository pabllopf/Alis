// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StartupHook.cs
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
using Alis.Core.Graphic.Platforms.Osx.Native;
using Alis.Core.Graphic.Test.Platforms.Osx.Native;

/// <summary>
///     Runtime startup hook invoked by the .NET runtime on the main thread before the entry point when
///     <c>DOTNET_STARTUP_HOOKS</c> points at this assembly and <c>ALIS_MACWINDOW_HOOK=1</c> is set.
/// </summary>
public static class StartupHook
{
    /// <summary>
    ///     Initializes the MacWindow bootstrap on the main thread.
    /// </summary>
    public static void Initialize()
    {
        try
        {
            if (Environment.GetEnvironmentVariable("ALIS_MACWINDOW_HOOK") == "1")
            {
                MacWindowBootstrap.Initialize();
                MacOpenGLContextBootstrap.Initialize();
            }
        }
        catch (Exception)
        {
        }
    }
}

namespace Alis.Core.Graphic.Test.Platforms.Osx.Native
{
    /// <summary>
    ///     Creates the MacWindow on the process main thread and records the results of every member call.
    ///     <para>
    ///         AppKit requires NSWindow creation on the main thread while xUnit runs tests on worker threads,
    ///         so this bootstrap is triggered from the <see cref="StartupHook" /> which the runtime executes on
    ///         the main thread before the entry point.
    ///     </para>
    /// </summary>
    internal static class MacWindowBootstrap
    {
        /// <summary>
        ///     The window created on the main thread.
        /// </summary>
        internal static MacWindow Window;

        /// <summary>
        ///     The frame captured from the window on the main thread.
        /// </summary>
        internal static NsRect Frame;

        /// <summary>
        ///     The width recorded right after construction.
        /// </summary>
        internal static int InitialWidth;

        /// <summary>
        ///     The height recorded right after construction.
        /// </summary>
        internal static int InitialHeight;

        /// <summary>
        ///     The title recorded right after construction.
        /// </summary>
        internal static string InitialTitle;

        /// <summary>
        ///     Indicates whether the native handle was valid right after construction.
        /// </summary>
        internal static bool HandleValid;

        /// <summary>
        ///     Indicates whether the bootstrap completed successfully on the main thread.
        /// </summary>
        internal static bool Ready;

        /// <summary>
        ///     The visibility recorded right after Show.
        /// </summary>
        internal static bool VisibleAfterShow;

        /// <summary>
        ///     The visibility recorded right after Hide.
        /// </summary>
        internal static bool HiddenAfterHide;

        /// <summary>
        ///     Creates the window and exercises every member on the main thread.
        /// </summary>
        internal static void Initialize()
        {
            if (Ready)
            {
                return;
            }

            try
            {
                ObjectiveCInterop.NSApplicationLoad();
                Window = new MacWindow(320, 200, "exec");
                InitialWidth = Window.Width;
                InitialHeight = Window.Height;
                InitialTitle = Window.Title;
                HandleValid = Window.Handle != IntPtr.Zero;
                Window.Show();
                VisibleAfterShow = Window.IsVisible();
                Window.SetTitle("new title");
                Window.SetSize(640, 480);
                Frame = Window.GetFrame();
                Window.Hide();
                HiddenAfterHide = Window.IsVisible();
                Ready = true;
            }
            catch (Exception)
            {
            }
        }
    }

    /// <summary>
    ///     Creates the MacOpenGLContext on the process main thread after the window bootstrap and records
    ///     the results of every member call.
    ///     <para>
    ///         AppKit requires NSOpenGLView creation on the main thread while xUnit runs tests on worker threads,
    ///         so this bootstrap is triggered from the <see cref="StartupHook" /> which the runtime executes on
    ///         the main thread before the entry point.
    ///     </para>
    /// </summary>
    internal static class MacOpenGLContextBootstrap
    {
        /// <summary>
        ///     The context created on the main thread.
        /// </summary>
        internal static MacOpenGLContext Context;

        /// <summary>
        ///     The view handle recorded right after construction.
        /// </summary>
        internal static IntPtr View;

        /// <summary>
        ///     The context handle recorded right after construction.
        /// </summary>
        internal static IntPtr ContextHandle;

        /// <summary>
        ///     The pixel format handle recorded right after construction.
        /// </summary>
        internal static IntPtr PixelFormat;

        /// <summary>
        ///     Indicates whether MakeCurrent executed successfully on the main thread.
        /// </summary>
        internal static bool MakeCurrentOk;

        /// <summary>
        ///     Indicates whether SwapBuffers executed successfully on the main thread.
        /// </summary>
        internal static bool SwapOk;

        /// <summary>
        ///     Indicates whether the bootstrap completed successfully on the main thread.
        /// </summary>
        internal static bool Ready;

        /// <summary>
        ///     Creates the context and exercises every member on the main thread.
        /// </summary>
        internal static void Initialize()
        {
            if (Ready)
            {
                return;
            }

            if (!MacWindowBootstrap.Ready)
            {
                return;
            }

            try
            {
                Context = new MacOpenGLContext(MacWindowBootstrap.Window);
                View = Context.View;
                ContextHandle = Context.Context;
                PixelFormat = Context.PixelFormat;
                Context.MakeCurrent();
                MakeCurrentOk = true;
                Context.SwapBuffers();
                SwapOk = true;
                Ready = true;
            }
            catch (Exception)
            {
            }
        }
    }
}
#endif
