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

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im gui platform io
    /// </summary>
    public struct ImGuiPlatformIo
    {
        /// <summary>
        ///     The platform createwindow
        /// </summary>
        public IntPtr PlatformCreateWindow { get; set; }

        /// <summary>
        ///     The platform destroywindow
        /// </summary>
        public IntPtr PlatformDestroyWindow { get; set; }

        /// <summary>
        ///     The platform showwindow
        /// </summary>
        public IntPtr PlatformShowWindow { get; set; }

        /// <summary>
        ///     The platform setwindowpos
        /// </summary>
        public IntPtr PlatformSetWindowPos { get; set; }

        /// <summary>
        ///     The platform getwindowpos
        /// </summary>
        public IntPtr PlatformGetWindowPos { get; set; }

        /// <summary>
        ///     The platform setwindowsize
        /// </summary>
        public IntPtr PlatformSetWindowSize { get; set; }

        /// <summary>
        ///     The platform getwindowsize
        /// </summary>
        public IntPtr PlatformGetWindowSize { get; set; }

        /// <summary>
        ///     The platform setwindowfocus
        /// </summary>
        public IntPtr PlatformSetWindowFocus { get; set; }

        /// <summary>
        ///     The platform getwindowfocus
        /// </summary>
        public IntPtr PlatformGetWindowFocus { get; set; }

        /// <summary>
        ///     The platform getwindowminimized
        /// </summary>
        public IntPtr PlatformGetWindowMinimized { get; set; }

        /// <summary>
        ///     The platform setwindowtitle
        /// </summary>
        public IntPtr PlatformSetWindowTitle { get; set; }

        /// <summary>
        ///     The platform setwindowalpha
        /// </summary>
        public IntPtr PlatformSetWindowAlpha { get; set; }

        /// <summary>
        ///     The platform updatewindow
        /// </summary>
        public IntPtr PlatformUpdateWindow { get; set; }

        /// <summary>
        ///     The platform renderwindow
        /// </summary>
        public IntPtr PlatformRenderWindow { get; set; }

        /// <summary>
        ///     The platform swapbuffers
        /// </summary>
        public IntPtr PlatformSwapBuffers { get; set; }

        /// <summary>
        ///     The platform getwindowdpiscale
        /// </summary>
        public IntPtr PlatformGetWindowDpiScale { get; set; }

        /// <summary>
        ///     The platform onchangedviewport
        /// </summary>
        public IntPtr PlatformOnChangedViewport { get; set; }

        /// <summary>
        ///     The platform createvksurface
        /// </summary>
        public IntPtr PlatformCreateVkSurface { get; set; }

        /// <summary>
        ///     The renderer createwindow
        /// </summary>
        public IntPtr RendererCreateWindow { get; set; }

        /// <summary>
        ///     The renderer destroywindow
        /// </summary>
        public IntPtr RendererDestroyWindow { get; set; }

        /// <summary>
        ///     The renderer setwindowsize
        /// </summary>
        public IntPtr RendererSetWindowSize { get; set; }

        /// <summary>
        ///     The renderer renderwindow
        /// </summary>
        public IntPtr RendererRenderWindow { get; set; }

        /// <summary>
        ///     The renderer swapbuffers
        /// </summary>
        public IntPtr RendererSwapBuffers { get; set; }

        /// <summary>
        ///     The monitors
        /// </summary>
        public ImVector Monitors { get; set; }

        /// <summary>
        ///     The viewports
        /// </summary>
        public ImVector Viewports { get; set; }
    }
}