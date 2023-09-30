// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiPlatformIO.cs
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

namespace Alis.App.Engine.UI
{
    /// <summary>
    ///     The im gui platform io
    /// </summary>
    public struct ImGuiPlatformIo
    {
        /// <summary>
        ///     The platform createwindow
        /// </summary>
        public IntPtr PlatformCreateWindow;

        /// <summary>
        ///     The platform destroywindow
        /// </summary>
        public IntPtr PlatformDestroyWindow;

        /// <summary>
        ///     The platform showwindow
        /// </summary>
        public IntPtr PlatformShowWindow;

        /// <summary>
        ///     The platform setwindowpos
        /// </summary>
        public IntPtr PlatformSetWindowPos;

        /// <summary>
        ///     The platform getwindowpos
        /// </summary>
        public IntPtr PlatformGetWindowPos;

        /// <summary>
        ///     The platform setwindowsize
        /// </summary>
        public IntPtr PlatformSetWindowSize;

        /// <summary>
        ///     The platform getwindowsize
        /// </summary>
        public IntPtr PlatformGetWindowSize;

        /// <summary>
        ///     The platform setwindowfocus
        /// </summary>
        public IntPtr PlatformSetWindowFocus;

        /// <summary>
        ///     The platform getwindowfocus
        /// </summary>
        public IntPtr PlatformGetWindowFocus;

        /// <summary>
        ///     The platform getwindowminimized
        /// </summary>
        public IntPtr PlatformGetWindowMinimized;

        /// <summary>
        ///     The platform setwindowtitle
        /// </summary>
        public IntPtr PlatformSetWindowTitle;

        /// <summary>
        ///     The platform setwindowalpha
        /// </summary>
        public IntPtr PlatformSetWindowAlpha;

        /// <summary>
        ///     The platform updatewindow
        /// </summary>
        public IntPtr PlatformUpdateWindow;

        /// <summary>
        ///     The platform renderwindow
        /// </summary>
        public IntPtr PlatformRenderWindow;

        /// <summary>
        ///     The platform swapbuffers
        /// </summary>
        public IntPtr PlatformSwapBuffers;

        /// <summary>
        ///     The platform getwindowdpiscale
        /// </summary>
        public IntPtr PlatformGetWindowDpiScale;

        /// <summary>
        ///     The platform onchangedviewport
        /// </summary>
        public IntPtr PlatformOnChangedViewport;

        /// <summary>
        ///     The platform createvksurface
        /// </summary>
        public IntPtr PlatformCreateVkSurface;

        /// <summary>
        ///     The renderer createwindow
        /// </summary>
        public IntPtr RendererCreateWindow;

        /// <summary>
        ///     The renderer destroywindow
        /// </summary>
        public IntPtr RendererDestroyWindow;

        /// <summary>
        ///     The renderer setwindowsize
        /// </summary>
        public IntPtr RendererSetWindowSize;

        /// <summary>
        ///     The renderer renderwindow
        /// </summary>
        public IntPtr RendererRenderWindow;

        /// <summary>
        ///     The renderer swapbuffers
        /// </summary>
        public IntPtr RendererSwapBuffers;

        /// <summary>
        ///     The monitors
        /// </summary>
        public ImVector Monitors;

        /// <summary>
        ///     The viewports
        /// </summary>
        public ImVector Viewports;
    }
}