// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImDrawData.cs
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

using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.ImGui
{
    /// <summary>
    ///     The im draw data
    /// </summary>
    public unsafe struct ImDrawData
    {
        /// <summary>
        ///     The valid
        /// </summary>
        public byte Valid;

        /// <summary>
        ///     The cmd lists count
        /// </summary>
        public int CmdListsCount;

        /// <summary>
        ///     The total idx count
        /// </summary>
        public int TotalIdxCount;

        /// <summary>
        ///     The total vtx count
        /// </summary>
        public int TotalVtxCount;

        /// <summary>
        ///     The cmd lists
        /// </summary>
        public ImDrawList** CmdLists;

        /// <summary>
        ///     The display pos
        /// </summary>
        public Vector2 DisplayPos;

        /// <summary>
        ///     The display size
        /// </summary>
        public Vector2 DisplaySize;

        /// <summary>
        ///     The framebuffer scale
        /// </summary>
        public Vector2 FramebufferScale;

        /// <summary>
        ///     The owner viewport
        /// </summary>
        public ImGuiViewport* OwnerViewport;
    }
}