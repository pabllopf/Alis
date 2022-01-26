// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   EnumerateAll.cs
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

using System.Collections.Generic;
using System.Runtime.InteropServices;
using Alis.Core.Audio.Extensions.Creative.EnumerateAll.Enums;
using Alis.Core.Audio.Native;

namespace Alis.Core.Audio.Extensions.Creative.EnumerateAll
{
    /// <summary>
    ///     Exposes the API in the EnumerateAll extension.
    /// </summary>
    public class EnumerateAll : ALBase
    {
        static EnumerateAll()
        {
            // We need to register the resolver for OpenAL before we can DllImport functions.
            RegisterOpenALResolver();
        }

        private EnumerateAll()
        {
        }

        /// <summary>
        ///     The name of this AL extension.
        /// </summary>
        public const string ExtensionName = "ALC_ENUMERATE_ALL_EXT";

        /// <summary>
        ///     Checks whether the extension is present.
        /// </summary>
        /// <returns>Whether the extension was present or not.</returns>
        public static bool IsExtensionPresent() => ALC.ALC.IsExtensionPresent(ALDevice.Null, ExtensionName);

        /// <summary>
        ///     Checks whether the extension is present.
        /// </summary>
        /// <param name="device">The device to be queried.</param>
        /// <returns>Whether the extension was present or not.</returns>
        public static bool IsExtensionPresent(ALDevice device) => ALC.ALC.IsExtensionPresent(device, ExtensionName);

        /// <summary>
        ///     Gets a named property on the context.
        /// </summary>
        /// <param name="device">The device for the context.</param>
        /// <param name="param">The named property.</param>
        /// <returns>The value.</returns>
        [DllImport(ALC.ALC.Lib, EntryPoint = "alcGetString", ExactSpelling = true,
            CallingConvention = ALC.ALC.AlcCallingConv)]
        public static extern string GetString(ALDevice device, GetEnumerateAllContextString param);

        /// <summary>
        ///     Gets a named property on the context.
        /// </summary>
        /// <param name="device">The device for the context.</param>
        /// <param name="param">The named property.</param>
        /// <returns>The value.</returns>
        [DllImport(ALC.ALC.Lib, EntryPoint = "alcGetString", ExactSpelling = true,
            CallingConvention = ALC.ALC.AlcCallingConv)]
        public static extern unsafe byte* GetStringList(ALDevice device, GetEnumerateAllContextStringList param);

        /// <inheritdoc cref="GetStringList(ALDevice, GetEnumerateAllContextStringList)" />
        public static unsafe IEnumerable<string> GetStringList(GetEnumerateAllContextStringList param)
        {
            byte* result = GetStringList(ALDevice.Null, param);
            return ALC.ALC.ALStringListToList(result);
        }
    }
}