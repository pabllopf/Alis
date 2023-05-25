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

namespace Alis.Core.Graphic.ImGui
{
    /// <summary>
    ///     The im gui platform io
    /// </summary>
    public struct ImGuiPlatformIO
    {
        /// <summary>
        ///     The platform createwindow
        /// </summary>
        public IntPtr Platform_CreateWindow;

        /// <summary>
        ///     The platform destroywindow
        /// </summary>
        public IntPtr Platform_DestroyWindow;

        /// <summary>
        ///     The platform showwindow
        /// </summary>
        public IntPtr Platform_ShowWindow;

        /// <summary>
        ///     The platform setwindowpos
        /// </summary>
        public IntPtr Platform_SetWindowPos;

        /// <summary>
        ///     The platform getwindowpos
        /// </summary>
        public IntPtr Platform_GetWindowPos;

        /// <summary>
        ///     The platform setwindowsize
        /// </summary>
        public IntPtr Platform_SetWindowSize;

        /// <summary>
        ///     The platform getwindowsize
        /// </summary>
        public IntPtr Platform_GetWindowSize;

        /// <summary>
        ///     The platform setwindowfocus
        /// </summary>
        public IntPtr Platform_SetWindowFocus;

        /// <summary>
        ///     The platform getwindowfocus
        /// </summary>
        public IntPtr Platform_GetWindowFocus;

        /// <summary>
        ///     The platform getwindowminimized
        /// </summary>
        public IntPtr Platform_GetWindowMinimized;

        /// <summary>
        ///     The platform setwindowtitle
        /// </summary>
        public IntPtr Platform_SetWindowTitle;

        /// <summary>
        ///     The platform setwindowalpha
        /// </summary>
        public IntPtr Platform_SetWindowAlpha;

        /// <summary>
        ///     The platform updatewindow
        /// </summary>
        public IntPtr Platform_UpdateWindow;

        /// <summary>
        ///     The platform renderwindow
        /// </summary>
        public IntPtr Platform_RenderWindow;

        /// <summary>
        ///     The platform swapbuffers
        /// </summary>
        public IntPtr Platform_SwapBuffers;

        /// <summary>
        ///     The platform getwindowdpiscale
        /// </summary>
        public IntPtr Platform_GetWindowDpiScale;

        /// <summary>
        ///     The platform onchangedviewport
        /// </summary>
        public IntPtr Platform_OnChangedViewport;

        /// <summary>
        ///     The platform createvksurface
        /// </summary>
        public IntPtr Platform_CreateVkSurface;

        /// <summary>
        ///     The renderer createwindow
        /// </summary>
        public IntPtr Renderer_CreateWindow;

        /// <summary>
        ///     The renderer destroywindow
        /// </summary>
        public IntPtr Renderer_DestroyWindow;

        /// <summary>
        ///     The renderer setwindowsize
        /// </summary>
        public IntPtr Renderer_SetWindowSize;

        /// <summary>
        ///     The renderer renderwindow
        /// </summary>
        public IntPtr Renderer_RenderWindow;

        /// <summary>
        ///     The renderer swapbuffers
        /// </summary>
        public IntPtr Renderer_SwapBuffers;

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