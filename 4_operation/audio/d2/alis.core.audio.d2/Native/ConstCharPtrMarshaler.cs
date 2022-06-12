// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   ConstCharPtrMarshaler.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Audio.D2.Native
{
    /// <summary>
    ///     The const char ptr marshaler class
    /// </summary>
    /// <seealso cref="ICustomMarshaler" />
    internal class ConstCharPtrMarshaler : ICustomMarshaler
    {
        /// <summary>
        ///     The const char ptr marshaler
        /// </summary>
        private static readonly ConstCharPtrMarshaler Instance = new ConstCharPtrMarshaler();

        /// <summary>
        ///     Cleans the up managed data using the specified managed obj
        /// </summary>
        /// <param name="ManagedObj">The managed obj</param>
        public void CleanUpManagedData(object ManagedObj)
        {
        }

        /// <summary>
        ///     Cleans the up native data using the specified p native data
        /// </summary>
        /// <param name="pNativeData">The native data</param>
        public void CleanUpNativeData(IntPtr pNativeData)
        {
        }

        /// <summary>
        ///     Gets the native data size
        /// </summary>
        /// <returns>The int</returns>
        public int GetNativeDataSize()
        {
            return IntPtr.Size;
        }

        /// <summary>
        ///     Marshals the managed to native using the specified managed obj
        /// </summary>
        /// <param name="ManagedObj">The managed obj</param>
        /// <exception cref="ArgumentException">
        ///     {nameof(ConstCharPtrMarshaler)} only supports marshaling of strings. Got
        ///     '{ManagedObj.GetType()}'
        /// </exception>
        /// <returns>The int ptr</returns>
        public IntPtr MarshalManagedToNative(object ManagedObj)
        {
            switch (ManagedObj)
            {
                case string str:
                    return Marshal.StringToHGlobalAnsi(str);
                default:
                    throw new ArgumentException(
                        $"{nameof(ConstCharPtrMarshaler)} only supports marshaling of strings. Got '{ManagedObj.GetType()}'");
            }
        }

        /// <summary>
        ///     Marshals the native to managed using the specified p native data
        /// </summary>
        /// <param name="pNativeData">The native data</param>
        /// <returns>The object</returns>
        public object MarshalNativeToManaged(IntPtr pNativeData)
        {
            return Marshal.PtrToStringAnsi(pNativeData);
        }

        // See https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.custommarshalers.typetotypeinfomarshaler.getinstance
#pragma warning disable IDE0060 // Remove unused parameter
        /// <summary>
        ///     Gets the instance using the specified cookie
        /// </summary>
        /// <param name="cookie">The cookie</param>
        /// <returns>The custom marshaler</returns>
        public static ICustomMarshaler GetInstance(string cookie)
        {
            return Instance;
        }
#pragma warning restore IDE0060 // Remove unused parameter
    }
}