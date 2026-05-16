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

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im draw list
    /// </summary>
    public struct ImDrawList
    {
        /// <summary>
        ///     The cmd buffer
        /// </summary>
        public ImVector CmdBuffer { get; set; }

        /// <summary>
        ///     The idx buffer
        /// </summary>
        public ImVector IdxBuffer { get; set; }

        /// <summary>
        ///     The vtx buffer
        /// </summary>
        public ImVector VtxBuffer { get; set; }

        /// <summary>
        ///     The flags
        /// </summary>
        public ImDrawListFlags Flags { get; set; }

        /// <summary>
        ///     The current vertex index for the draw list
        /// </summary>
        public uint VtxCurrentIdx { get; set; }

        /// <summary>
        ///     The data
        /// </summary>
        public IntPtr Data { get; set; }

        /// <summary>
        ///     The owner display name for the draw list
        /// </summary>
        public IntPtr OwnerName { get; set; }

        /// <summary>
        ///     Write pointer for vertex data
        /// </summary>
        public IntPtr VtxWritePtr { get; set; }

        /// <summary>
        ///     Write pointer for index data
        /// </summary>
        public IntPtr IdxWritePtr { get; set; }

        /// <summary>
        ///     Stack of active clipping rectangles
        /// </summary>
        public ImVector ClipRectStack { get; set; }

        /// <summary>
        ///     Stack of active texture identifiers
        /// </summary>
        public ImVector TextureIdStack { get; set; }

        /// <summary>
        ///     The path
        /// </summary>
        public ImVector Path { get; set; }

        /// <summary>
        ///     The current draw command header
        /// </summary>
        public ImDrawCmdHeader CmdHeader { get; set; }

        /// <summary>
        ///     The splitter
        /// </summary>
        public ImDrawListSplitter Splitter { get; set; }

        /// <summary>
        ///     The anti-aliasing fringe scale factor
        /// </summary>
        public float FringeScale { get; set; }
    }
}