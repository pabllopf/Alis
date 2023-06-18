// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiListClipper.cs
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

namespace Alis.Core.Graphic.ImGui.Structs
{
    /// <summary>
    ///     The im gui list clipper
    /// </summary>
    public unsafe struct ImGuiListClipper
    {
        /// <summary>
        ///     The ctx
        /// </summary>
        public IntPtr Ctx;

        /// <summary>
        ///     The display start
        /// </summary>
        public int DisplayStart;

        /// <summary>
        ///     The display end
        /// </summary>
        public int DisplayEnd;

        /// <summary>
        ///     The items count
        /// </summary>
        public int ItemsCount;

        /// <summary>
        ///     The items height
        /// </summary>
        public float ItemsHeight;

        /// <summary>
        ///     The start pos
        /// </summary>
        public float StartPosY;

        /// <summary>
        ///     The temp data
        /// </summary>
        public void* TempData;
    }
}