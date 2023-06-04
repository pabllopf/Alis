// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImColorPtr.cs
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
using System.Numerics;

namespace Alis.Core.Graphic.ImGui
{
    /// <summary>
    ///     The im color ptr
    /// </summary>
    public struct ImColorPtr
    {
        /// <summary>
        ///     Gets the value of the native ptr
        /// </summary>
        public ImColor NativePtr { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImColorPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImColorPtr(ImColor nativePtr) => NativePtr = nativePtr;
        
        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImColorPtr(ImColor nativePtr) => new ImColorPtr(nativePtr);

        /// <summary>
        ///     /
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImColor(ImColorPtr wrappedPtr) => wrappedPtr.NativePtr;


        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImColorPtr(IntPtr nativePtr) => new ImColorPtr(nativePtr);

        /// <summary>
        ///     Gets the value of the value
        /// </summary>
        public ref Vector4 Value => ref Unsafe.AsRef<Vector4>(&NativePtr->Value);

        /// <summary>
        ///     Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImColor_destroy(NativePtr);
        }

        /// <summary>
        ///     Hsvs the h
        /// </summary>
        /// <param name="h">The </param>
        /// <param name="s">The </param>
        /// <param name="v">The </param>
        /// <returns>The retval</returns>
        public ImColor Hsv(float h, float s, float v)
        {
            ImColor retval;
            float a = 1.0f;
            ImGuiNative.ImColor_HSV(&retval, h, s, v, a);
            return retval;
        }

        /// <summary>
        ///     Hsvs the h
        /// </summary>
        /// <param name="h">The </param>
        /// <param name="s">The </param>
        /// <param name="v">The </param>
        /// <param name="a">The </param>
        /// <returns>The retval</returns>
        public ImColor Hsv(float h, float s, float v, float a)
        {
            ImColor retval;
            ImGuiNative.ImColor_HSV(&retval, h, s, v, a);
            return retval;
        }

        /// <summary>
        ///     Sets the hsv using the specified h
        /// </summary>
        /// <param name="h">The </param>
        /// <param name="s">The </param>
        /// <param name="v">The </param>
        public void SetHsv(float h, float s, float v)
        {
            float a = 1.0f;
            ImGuiNative.ImColor_SetHSV(NativePtr, h, s, v, a);
        }

        /// <summary>
        ///     Sets the hsv using the specified h
        /// </summary>
        /// <param name="h">The </param>
        /// <param name="s">The </param>
        /// <param name="v">The </param>
        /// <param name="a">The </param>
        public void SetHsv(float h, float s, float v, float a)
        {
            ImGuiNative.ImColor_SetHSV(NativePtr, h, s, v, a);
        }
    }
}