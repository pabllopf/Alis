// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SfmlTestBootstrap.cs
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
using System.Text;
using Alis.Extension.Graphic.Sfml.Render;
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

/// <summary>
///     Runtime startup hook invoked by the .NET runtime on the main thread before the entry point when
///     <c>DOTNET_STARTUP_HOOKS</c> points at this assembly and <c>ALIS_SFML_HOOK=1</c> is set.
/// </summary>
public static class StartupHook
{
    /// <summary>
    ///     Initializes the SFML bootstrap on the main thread.
    /// </summary>
    public static void Initialize()
    {
        try
        {
            if (Environment.GetEnvironmentVariable("ALIS_SFML_HOOK") == "1")
            {
                Alis.Extension.Graphic.Sfml.Test.SfmlTestBootstrap.Initialize();
            }
        }
        catch (Exception)
        {
        }
    }
}

namespace Alis.Extension.Graphic.Sfml.Test
{
    /// <summary>
    ///     Initializes SFML on the process main thread and owns the persistent native render window used by the coverage
    ///     tests. SFML on macOS requires window creation on the main thread, so this bootstrap is triggered from the
    ///     <see cref="StartupHook" /> which the runtime executes on the main thread before the entry point.
    ///     <para>
    ///         The installed CSFML 3.0 changed the window creation ABI (an extra <c>sfWindowState</c> parameter) and the
    ///         wrapper declares the CSFML 2.x signature, so the window is created natively with the correct ABI here and
    ///         attached to a <see cref="RenderWindow" /> through <c>sfRenderWindow_createFromHandle</c> which is
    ///         signature compatible.
    ///     </para>
    /// </summary>
    internal static class SfmlTestBootstrap
    {
        /// <summary>
        ///     The persistent render window created on the main thread.
        /// </summary>
        internal static RenderWindow Window;

        /// <summary>
        ///     Indicates whether the bootstrap completed successfully on the main thread.
        /// </summary>
        internal static bool Ready;

        /// <summary>
        ///     Initializes SFML and creates the persistent window, then hides it.
        /// </summary>
        internal static void Initialize()
        {
            if (Ready)
            {
                return;
            }

            IntPtr nativeWindow = NativeWindowFactory.Create(800, 600, "alis-coverage");
            IntPtr nativeHandle = NativeWindowFactory.GetNativeHandle(nativeWindow);
            Window = new RenderWindow(nativeHandle, new ContextSettings(0, 0));
            Window.SetVisible(false);
            Ready = true;
            Render.RenderWindowMainThreadWorker.Run();
        }

        /// <summary>
        ///     Ensures the bootstrap ran; throws a skip signal when SFML could not be initialized on the main thread.
        /// </summary>
        internal static void EnsureReady()
        {
            Assert.True(Ready, "SFML main-thread bootstrap is unavailable; run with ALIS_SFML_HOOK=1 and DOTNET_STARTUP_HOOKS set.");
        }
    }

    /// <summary>
    ///     Creates native CSFML 3.0 windows using the correct ABI. The installed CSFML 3.0 library moved the
    ///     <c>sfWindowState</c> parameter into the creation functions; the wrapper's imports still target CSFML 2.x.
    /// </summary>
    internal static class NativeWindowFactory
    {
        /// <summary>
        ///     Sfs the render window create unicode with state using the specified mode
        /// </summary>
        /// <param name="mode">The mode</param>
        /// <param name="title">The title</param>
        /// <param name="style">The style</param>
        /// <param name="state">The state</param>
        /// <param name="settings">The settings</param>
        /// <returns>The int ptr</returns>
        [DllImport("csfml-graphics", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr sfRenderWindow_createUnicode(VideoMode mode, IntPtr title, uint style, uint state, ref ContextSettings settings);

        /// <summary>
        ///     Sfs the window get native handle using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        [DllImport("csfml-window", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr sfWindow_getNativeHandle(IntPtr window);

        /// <summary>
        ///     Creates a native window with the correct CSFML 3.0 ABI and returns its platform handle.
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="title">The title</param>
        /// <returns>The int ptr</returns>
        internal static IntPtr Create(uint width, uint height, string title)
        {
            byte[] titleAsUtf32 = Encoding.UTF32.GetBytes(title + '\0');
            GCHandle handle = GCHandle.Alloc(titleAsUtf32, GCHandleType.Pinned);
            try
            {
                ContextSettings settings = new ContextSettings(0, 0);
                IntPtr titlePtr = handle.AddrOfPinnedObject();
                return sfRenderWindow_createUnicode(new VideoMode(width, height), titlePtr, (uint) Alis.Extension.Graphic.Sfml.Windows.Styles.Close, 0u, ref settings);
            }
            finally
            {
                handle.Free();
            }
        }

        /// <summary>
        ///     Gets the platform handle of a native render window.
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        internal static IntPtr GetNativeHandle(IntPtr window) => sfWindow_getNativeHandle(window);
    }
}
