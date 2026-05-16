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

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im gui payload
    /// </summary>
    public struct ImGuiPayload
    {
        /// <summary>
        ///     The data
        /// </summary>
        public IntPtr Data { get; set; }

        /// <summary>
        ///     The data size
        /// </summary>
        public int DataSize { get; set; }

        /// <summary>
        ///     The source id
        /// </summary>
        public uint SourceId { get; set; }

        /// <summary>
        ///     The source parent id
        /// </summary>
        public uint SourceParentId { get; set; }

        /// <summary>
        ///     The data frame count
        /// </summary>
        public int DataFrameCount { get; set; }

        /// <summary>
        ///     The data type
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 33)]
        public byte[] DataType;

        /// <summary>
        ///     The preview
        /// </summary>
        public byte Preview { get; set; }

        /// <summary>
        ///     The delivery
        /// </summary>
        public byte Delivery { get; set; }

        /// <summary>
        ///     Clears this instance
        /// </summary>
        public void Clear() => ImGuiNative.ImGuiPayload_Clear(ref this);

        /// <summary>
        ///     Describes whether this instance is data type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The bool</returns>
        public bool IsDataType(string type) => ImGuiNative.ImGuiPayload_IsDataType(ref this, Encoding.UTF8.GetBytes(type)) != 0;

        /// <summary>
        ///     Describes whether this instance is delivery
        /// </summary>
        /// <returns>The bool</returns>
        public bool IsDelivery() => ImGuiNative.ImGuiPayload_IsDelivery(ref this) != 0;

        /// <summary>
        ///     Describes whether this instance is preview
        /// </summary>
        /// <returns>The bool</returns>
        public bool IsPreview() => ImGuiNative.ImGuiPayload_IsPreview(ref this) != 0;
    }
}