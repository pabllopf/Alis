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

namespace Alis.Core.Extension.ImGui
{
    public struct ImDrawCmd
    {
        public Vector4 ClipRect;
        public IntPtr TextureId;
        public uint VtxOffset;
        public uint IdxOffset;
        public uint ElemCount;
        public IntPtr UserCallback;
        public IntPtr UserCallbackData;

        public Vector4 GetClipRect() => ClipRect;
        public IntPtr GetTextureId() => TextureId;
        public uint GetVtxOffset() => VtxOffset;
        public uint GetIdxOffset() => IdxOffset;
        public uint GetElemCount() => ElemCount;
        public IntPtr GetUserCallback() => UserCallback;
        public IntPtr GetUserCallbackData() => UserCallbackData;
        public void SetUserCallbackData(IntPtr value) => UserCallbackData = value;

        public void Destroy()
        {
            ImGuiNative.ImDrawCmd_destroy(ref this);
        }

        public IntPtr GetTexId()
        {
            IntPtr ret = ImGuiNative.ImDrawCmd_GetTexID(ref this);
            return ret;
        }
    }
}