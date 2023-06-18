// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiPayload.cs
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

namespace Alis.Core.Graphic.ImGui.Structs
{
    /// <summary>
    ///     The im gui payload
    /// </summary>
    public unsafe struct ImGuiPayload
    {
        /// <summary>
        ///     The data
        /// </summary>
        public void* Data;

        /// <summary>
        ///     The data size
        /// </summary>
        public int DataSize;

        /// <summary>
        ///     The source id
        /// </summary>
        public uint SourceId;

        /// <summary>
        ///     The source parent id
        /// </summary>
        public uint SourceParentId;

        /// <summary>
        ///     The data frame count
        /// </summary>
        public int DataFrameCount;

        /// <summary>
        ///     The data type
        /// </summary>
        public fixed byte DataType[33];

        /// <summary>
        ///     The preview
        /// </summary>
        public byte Preview;

        /// <summary>
        ///     The delivery
        /// </summary>
        public byte Delivery;
    }
}