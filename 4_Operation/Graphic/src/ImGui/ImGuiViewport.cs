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

using System.Numerics;

namespace Alis.Core.Graphic.ImGui
{
    /// <summary>
    ///     The im gui viewport
    /// </summary>
    public struct ImGuiViewport
    {
        /// <summary>
        ///     The id
        /// </summary>
        public uint Id;

        /// <summary>
        ///     The flags
        /// </summary>
        public ImGuiViewportFlags Flags;

        /// <summary>
        ///     The pos
        /// </summary>
        public Vector2 Pos;

        /// <summary>
        ///     The size
        /// </summary>
        public Vector2 Size;

        /// <summary>
        ///     The work pos
        /// </summary>
        public Vector2 WorkPos;

        /// <summary>
        ///     The work size
        /// </summary>
        public Vector2 WorkSize;

        /// <summary>
        ///     The dpi scale
        /// </summary>
        public float DpiScale;

        /// <summary>
        ///     The parent viewport id
        /// </summary>
        public uint ParentViewportId;

        /// <summary>
        ///     The draw data
        /// </summary>
        public ImDrawData* DrawData;

        /// <summary>
        ///     The renderer user data
        /// </summary>
        public void* RendererUserData;

        /// <summary>
        ///     The platform user data
        /// </summary>
        public void* PlatformUserData;

        /// <summary>
        ///     The platform handle
        /// </summary>
        public void* PlatformHandle;

        /// <summary>
        ///     The platform handle raw
        /// </summary>
        public void* PlatformHandleRaw;

        /// <summary>
        ///     The platform window created
        /// </summary>
        public byte PlatformWindowCreated;

        /// <summary>
        ///     The platform request move
        /// </summary>
        public byte PlatformRequestMove;

        /// <summary>
        ///     The platform request resize
        /// </summary>
        public byte PlatformRequestResize;

        /// <summary>
        ///     The platform request close
        /// </summary>
        public byte PlatformRequestClose;
    }
}