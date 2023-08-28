// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiStoragePtr.cs
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
using Alis.Core.Graphic.UI.Utils;

namespace Alis.Core.Graphic.UI
{
    /// <summary>
    ///     The im gui storage ptr
    /// </summary>
    public unsafe struct ImGuiStoragePtr
    {
        /// <summary>
        ///     Gets the value of the native ptr
        /// </summary>
        public ImGuiStorage* NativePtr { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImGuiStoragePtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiStoragePtr(ImGuiStorage* nativePtr) => NativePtr = nativePtr;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImGuiStoragePtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiStoragePtr(IntPtr nativePtr) => NativePtr = (ImGuiStorage*) nativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiStoragePtr(ImGuiStorage* nativePtr) => new ImGuiStoragePtr(nativePtr);

        /// <summary>
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiStorage*(ImGuiStoragePtr wrappedPtr) => wrappedPtr.NativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiStoragePtr(IntPtr nativePtr) => new ImGuiStoragePtr(nativePtr);

        /// <summary>
        ///     Gets the value of the data
        /// </summary>
        public ImPtrVector<ImGuiStoragePairPtr> Data => new ImPtrVector<ImGuiStoragePairPtr>(NativePtr->Data, Unsafe.SizeOf<ImGuiStoragePair>());

        /// <summary>
        ///     Builds the sort by key
        /// </summary>
        public void BuildSortByKey()
        {
            ImGuiNative.ImGuiStorage_BuildSortByKey(NativePtr);
        }

        /// <summary>
        ///     Clears this instance
        /// </summary>
        public void Clear()
        {
            ImGuiNative.ImGuiStorage_Clear(NativePtr);
        }

        /// <summary>
        ///     Describes whether this instance get bool
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The bool</returns>
        public bool GetBool(uint key)
        {
            byte defaultVal = 0;
            byte ret = ImGuiNative.ImGuiStorage_GetBool(NativePtr, key, defaultVal);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether this instance get bool
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="defaultVal">The default val</param>
        /// <returns>The bool</returns>
        public bool GetBool(uint key, bool defaultVal)
        {
            byte nativeDefaultVal = defaultVal ? (byte) 1 : (byte) 0;
            byte ret = ImGuiNative.ImGuiStorage_GetBool(NativePtr, key, nativeDefaultVal);
            return ret != 0;
        }

        /// <summary>
        ///     Gets the bool ref using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The ret</returns>
        public byte* GetBoolRef(uint key)
        {
            byte defaultVal = 0;
            byte* ret = ImGuiNative.ImGuiStorage_GetBoolRef(NativePtr, key, defaultVal);
            return ret;
        }

        /// <summary>
        ///     Gets the bool ref using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="defaultVal">The default val</param>
        /// <returns>The ret</returns>
        public byte* GetBoolRef(uint key, bool defaultVal)
        {
            byte nativeDefaultVal = defaultVal ? (byte) 1 : (byte) 0;
            byte* ret = ImGuiNative.ImGuiStorage_GetBoolRef(NativePtr, key, nativeDefaultVal);
            return ret;
        }

        /// <summary>
        ///     Gets the float using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The ret</returns>
        public float GetFloat(uint key)
        {
            float defaultVal = 0.0f;
            float ret = ImGuiNative.ImGuiStorage_GetFloat(NativePtr, key, defaultVal);
            return ret;
        }

        /// <summary>
        ///     Gets the float using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="defaultVal">The default val</param>
        /// <returns>The ret</returns>
        public float GetFloat(uint key, float defaultVal)
        {
            float ret = ImGuiNative.ImGuiStorage_GetFloat(NativePtr, key, defaultVal);
            return ret;
        }

        /// <summary>
        ///     Gets the float ref using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The ret</returns>
        public float* GetFloatRef(uint key)
        {
            float defaultVal = 0.0f;
            float* ret = ImGuiNative.ImGuiStorage_GetFloatRef(NativePtr, key, defaultVal);
            return ret;
        }

        /// <summary>
        ///     Gets the float ref using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="defaultVal">The default val</param>
        /// <returns>The ret</returns>
        public float* GetFloatRef(uint key, float defaultVal)
        {
            float* ret = ImGuiNative.ImGuiStorage_GetFloatRef(NativePtr, key, defaultVal);
            return ret;
        }

        /// <summary>
        ///     Gets the int using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The ret</returns>
        public int GetInt(uint key)
        {
            int defaultVal = 0;
            int ret = ImGuiNative.ImGuiStorage_GetInt(NativePtr, key, defaultVal);
            return ret;
        }

        /// <summary>
        ///     Gets the int using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="defaultVal">The default val</param>
        /// <returns>The ret</returns>
        public int GetInt(uint key, int defaultVal)
        {
            int ret = ImGuiNative.ImGuiStorage_GetInt(NativePtr, key, defaultVal);
            return ret;
        }

        /// <summary>
        ///     Gets the int ref using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The ret</returns>
        public int* GetIntRef(uint key)
        {
            int defaultVal = 0;
            int* ret = ImGuiNative.ImGuiStorage_GetIntRef(NativePtr, key, defaultVal);
            return ret;
        }

        /// <summary>
        ///     Gets the int ref using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="defaultVal">The default val</param>
        /// <returns>The ret</returns>
        public int* GetIntRef(uint key, int defaultVal)
        {
            int* ret = ImGuiNative.ImGuiStorage_GetIntRef(NativePtr, key, defaultVal);
            return ret;
        }

        /// <summary>
        ///     Gets the void ptr using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The int ptr</returns>
        public IntPtr GetVoidPtr(uint key)
        {
            void* ret = ImGuiNative.ImGuiStorage_GetVoidPtr(NativePtr, key);
            return (IntPtr) ret;
        }

        /// <summary>
        ///     Gets the void ptr ref using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The ret</returns>
        public void** GetVoidPtrRef(uint key)
        {
            void* defaultVal = null;
            void** ret = ImGuiNative.ImGuiStorage_GetVoidPtrRef(NativePtr, key, defaultVal);
            return ret;
        }

        /// <summary>
        ///     Gets the void ptr ref using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="defaultVal">The default val</param>
        /// <returns>The ret</returns>
        public void** GetVoidPtrRef(uint key, IntPtr defaultVal)
        {
            void* nativeDefaultVal = defaultVal.ToPointer();
            void** ret = ImGuiNative.ImGuiStorage_GetVoidPtrRef(NativePtr, key, nativeDefaultVal);
            return ret;
        }

        /// <summary>
        ///     Sets the all int using the specified val
        /// </summary>
        /// <param name="val">The val</param>
        public void SetAllInt(int val)
        {
            ImGuiNative.ImGuiStorage_SetAllInt(NativePtr, val);
        }

        /// <summary>
        ///     Sets the bool using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="val">The val</param>
        public void SetBool(uint key, bool val)
        {
            byte nativeVal = val ? (byte) 1 : (byte) 0;
            ImGuiNative.ImGuiStorage_SetBool(NativePtr, key, nativeVal);
        }

        /// <summary>
        ///     Sets the float using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="val">The val</param>
        public void SetFloat(uint key, float val)
        {
            ImGuiNative.ImGuiStorage_SetFloat(NativePtr, key, val);
        }

        /// <summary>
        ///     Sets the int using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="val">The val</param>
        public void SetInt(uint key, int val)
        {
            ImGuiNative.ImGuiStorage_SetInt(NativePtr, key, val);
        }

        /// <summary>
        ///     Sets the void ptr using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="val">The val</param>
        public void SetVoidPtr(uint key, IntPtr val)
        {
            void* nativeVal = val.ToPointer();
            ImGuiNative.ImGuiStorage_SetVoidPtr(NativePtr, key, nativeVal);
        }
    }
}