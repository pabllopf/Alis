// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImDrawList.cs
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
    ///     The im draw list
    /// </summary>
    public unsafe struct ImDrawList
    {
        /// <summary>
        ///     The cmd buffer
        /// </summary>
        public ImVector CmdBuffer;

        /// <summary>
        ///     The idx buffer
        /// </summary>
        public ImVector IdxBuffer;

        /// <summary>
        ///     The vtx buffer
        /// </summary>
        public ImVector VtxBuffer;

        /// <summary>
        ///     The flags
        /// </summary>
        public ImDrawListFlags Flags;

        /// <summary>
        ///     The vtx current idx
        /// </summary>
        public uint _VtxCurrentIdx;

        /// <summary>
        ///     The data
        /// </summary>
        public IntPtr _Data;

        /// <summary>
        ///     The owner name
        /// </summary>
        public byte* _OwnerName;

        /// <summary>
        ///     The vtx write ptr
        /// </summary>
        public ImDrawVert* _VtxWritePtr;

        /// <summary>
        ///     The idx write ptr
        /// </summary>
        public ushort* _IdxWritePtr;

        /// <summary>
        ///     The clip rect stack
        /// </summary>
        public ImVector _ClipRectStack;

        /// <summary>
        ///     The texture id stack
        /// </summary>
        public ImVector _TextureIdStack;

        /// <summary>
        ///     The path
        /// </summary>
        public ImVector _Path;

        /// <summary>
        ///     The cmd header
        /// </summary>
        public ImDrawCmdHeader _CmdHeader;

        /// <summary>
        ///     The splitter
        /// </summary>
        public ImDrawListSplitter _Splitter;

        /// <summary>
        ///     The fringe scale
        /// </summary>
        public float _FringeScale;
    }
}