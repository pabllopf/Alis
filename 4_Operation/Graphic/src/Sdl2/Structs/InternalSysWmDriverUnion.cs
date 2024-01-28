// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:InternalSysWmDriverUnion.cs
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

using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The internal sys wm driver union
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct InternalSysWmDriverUnion
    {
        /// <summary>
        ///     The win
        /// </summary>
        [FieldOffset(0)] public InternalWindowsWmInfo win;

        /// <summary>
        ///     The winrt
        /// </summary>
        [FieldOffset(0)] public InternalWinrtWmInfo winrt;

        /// <summary>
        ///     The 11
        /// </summary>
        [FieldOffset(0)] public InternalX11WmInfo x11;

        /// <summary>
        ///     The dfb
        /// </summary>
        [FieldOffset(0)] public InternalDirectfbWmInfo dfb;

        /// <summary>
        ///     The cocoa
        /// </summary>
        [FieldOffset(0)] public InternalCocoaWmInfo cocoa;

        /// <summary>
        ///     The uikit
        /// </summary>
        [FieldOffset(0)] public InternalUikitWmInfo uikit;

        /// <summary>
        ///     The wl
        /// </summary>
        [FieldOffset(0)] public InternalWaylandWmInfo wl;

        /// <summary>
        ///     The mir
        /// </summary>
        [FieldOffset(0)] public InternalMirWmInfo mir;

        /// <summary>
        ///     The android
        /// </summary>
        [FieldOffset(0)] public InternalAndroidWmInfo android;

        /// <summary>
        ///     The os
        /// </summary>
        [FieldOffset(0)] public InternalOs2WmInfo os2;

        /// <summary>
        ///     The vivante
        /// </summary>
        [FieldOffset(0)] public InternalVivanteWmInfo VivanteWmInfo;

        /// <summary>
        ///     The ksm
        /// </summary>
        [FieldOffset(0)] public InternalKmsWmInfo ksm;
    }
}