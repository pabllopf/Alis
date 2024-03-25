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

using System.Text;

namespace Alis.Extension.Graphic.ImGui
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
        
        /// <summary>
        ///     Clears this instance
        /// </summary>
        public void Clear()
        {
            ImGuiNative.ImGuiPayload_Clear(ref this);
        }

        /// <summary>
        ///     Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImGuiPayload_destroy(ref this);
        }

        /// <summary>
        ///     Describes whether this instance is data type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The bool</returns>
        public bool IsDataType(string type)
        {
            byte* nativeType;
            int typeByteCount = 0;
            if (type != null)
            {
                typeByteCount = Encoding.UTF8.GetByteCount(type);
                if (typeByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeType = Util.Allocate(typeByteCount + 1);
                }
                else
                {
                    byte* nativeTypeStackBytes = stackalloc byte[typeByteCount + 1];
                    nativeType = nativeTypeStackBytes;
                }

                int nativeTypeOffset = Util.GetUtf8(type, nativeType, typeByteCount);
                nativeType[nativeTypeOffset] = 0;
            }
            else
            {
                nativeType = null;
            }

            byte ret = ImGuiNative.ImGuiPayload_IsDataType(ref this, nativeType);
            if (typeByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeType);
            }

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether this instance is delivery
        /// </summary>
        /// <returns>The bool</returns>
        public bool IsDelivery()
        {
            byte ret = ImGuiNative.ImGuiPayload_IsDelivery(ref this);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether this instance is preview
        /// </summary>
        /// <returns>The bool</returns>
        public bool IsPreview()
        {
            byte ret = ImGuiNative.ImGuiPayload_IsPreview(ref this);
            return ret != 0;
        }
    }
}