// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiViewport.cs
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
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im gui viewport
    /// </summary>
    public struct ImGuiViewport
    {
        /// <summary>
        ///     The id
        /// </summary>
        public uint Id { get; set; }

        /// <summary>
        ///     The flags
        /// </summary>
        public ImGuiViewportFlags Flags { get; set; }

        /// <summary>
        ///     The pos
        /// </summary>
        public Vector2F Pos { get; set; }

        /// <summary>
        ///     The size
        /// </summary>
        public Vector2F Size { get; set; }

        /// <summary>
        ///     The work pos
        /// </summary>
        public Vector2F WorkPos { get; set; }

        /// <summary>
        ///     The work size
        /// </summary>
        public Vector2F WorkSize { get; set; }

        /// <summary>
        ///     The dpi scale
        /// </summary>
        public float DpiScale { get; set; }

        /// <summary>
        ///     The parent viewport id
        /// </summary>
        public uint ParentViewportId { get; set; }

        /// <summary>
        ///     The draw data
        /// </summary>
        public IntPtr DrawData { get; set; }

        /// <summary>
        ///     The renderer user data
        /// </summary>
        public IntPtr RendererUserData { get; set; }

        /// <summary>
        ///     The platform user data
        /// </summary>
        public IntPtr PlatformUserData { get; set; }

        /// <summary>
        ///     The platform handle
        /// </summary>
        public IntPtr PlatformHandle { get; set; }

        /// <summary>
        ///     The platform handle raw
        /// </summary>
        public IntPtr PlatformHandleRaw { get; set; }

        /// <summary>
        ///     The platform window created
        /// </summary>
        public byte PlatformWindowCreated { get; set; }

        /// <summary>
        ///     The platform request move
        /// </summary>
        public byte PlatformRequestMove { get; set; }

        /// <summary>
        ///     The platform request resize
        /// </summary>
        public byte PlatformRequestResize { get; set; }

        /// <summary>
        ///     The platform request close
        /// </summary>
        public byte PlatformRequestClose { get; set; }
    }
}