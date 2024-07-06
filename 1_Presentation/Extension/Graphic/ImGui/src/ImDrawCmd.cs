// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImDrawCmd.cs
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
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.ImGui
{
    /// <summary>
    ///     The im draw cmd
    /// </summary>
    public struct ImDrawCmd
    {
        /// <summary>
        ///     The clip rect
        /// </summary>
        public Vector4 ClipRect;

        /// <summary>
        ///     The texture id
        /// </summary>
        public IntPtr TextureId;

        /// <summary>
        ///     The vtx offset
        /// </summary>
        public uint VtxOffset;

        /// <summary>
        ///     The idx offset
        /// </summary>
        public uint IdxOffset;

        /// <summary>
        ///     The elem count
        /// </summary>
        public uint ElemCount;

        /// <summary>
        ///     The user callback
        /// </summary>
        public IntPtr UserCallback;

        /// <summary>
        ///     The user callback data
        /// </summary>
        public IntPtr UserCallbackData;

        /// <summary>
        ///     Gets the clip rect
        /// </summary>
        /// <returns>The vector</returns>
        public Vector4 GetClipRect() => ClipRect;

        /// <summary>
        ///     Gets the texture id
        /// </summary>
        /// <returns>The int ptr</returns>
        public IntPtr GetTextureId() => TextureId;

        /// <summary>
        ///     Gets the vtx offset
        /// </summary>
        /// <returns>The uint</returns>
        public uint GetVtxOffset() => VtxOffset;

        /// <summary>
        ///     Gets the idx offset
        /// </summary>
        /// <returns>The uint</returns>
        public uint GetIdxOffset() => IdxOffset;

        /// <summary>
        ///     Gets the elem count
        /// </summary>
        /// <returns>The uint</returns>
        public uint GetElemCount() => ElemCount;

        /// <summary>
        ///     Gets the user callback
        /// </summary>
        /// <returns>The int ptr</returns>
        public IntPtr GetUserCallback() => UserCallback;

        /// <summary>
        ///     Gets the user callback data
        /// </summary>
        /// <returns>The int ptr</returns>
        public IntPtr GetUserCallbackData() => UserCallbackData;

        /// <summary>
        ///     Sets the user callback data using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        public void SetUserCallbackData(IntPtr value) => UserCallbackData = value;

        /// <summary>
        ///     Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImDrawCmd_destroy(ref this);
        }

        /// <summary>
        ///     Gets the tex id
        /// </summary>
        /// <returns>The ret</returns>
        public IntPtr GetTexId()
        {
            IntPtr ret = ImGuiNative.ImDrawCmd_GetTexID(ref this);
            return ret;
        }
    }
}