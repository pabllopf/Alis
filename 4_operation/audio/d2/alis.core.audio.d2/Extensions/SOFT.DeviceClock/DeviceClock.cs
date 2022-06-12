// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   DeviceClock.cs
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

using System.Runtime.InteropServices;
using Alis.Core.Audio.D2.Extensions.SOFT.DeviceClock.Enums;
using Alis.Core.Audio.D2.Native;

namespace Alis.Core.Audio.D2.Extensions.SOFT.DeviceClock
{
    /// <summary>
    ///     The device clock class
    /// </summary>
    /// <seealso cref="ALBase" />
    public class DeviceClock : ALBase
    {
        /// <summary>
        ///     The name of this AL extension.
        /// </summary>
        public const string ExtensionName = "ALC_SOFT_device_clock";

        /// <summary>
        ///     Initializes a new instance of the <see cref="DeviceClock" /> class
        /// </summary>
        static DeviceClock()
        {
            // We need to register the resolver for OpenAL before we can DllImport functions.
            RegisterOpenALResolver();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="DeviceClock" /> class
        /// </summary>
        private DeviceClock()
        {
        }

        /// <summary>
        ///     Checks if this extension is present.
        /// </summary>
        /// <param name="device">The device to query.</param>
        /// <returns>Whether the extension was present or not.</returns>
        public static bool IsExtensionPresent(ALDevice device)
        {
            return ALC.IsExtensionPresent(device, ExtensionName);
        }

        /// <summary>
        ///     Gets the integer using the specified device
        /// </summary>
        /// <param name="device">The device</param>
        /// <param name="param">The param</param>
        /// <param name="values">The values</param>
        public static void GetInteger(ALDevice device, GetInteger64 param, long[] values)
        {
            GetInteger(device, param, values.Length, values);
        }

        /// <summary>
        ///     Gets the integer using the specified device
        /// </summary>
        /// <param name="device">The device</param>
        /// <param name="param">The param</param>
        /// <param name="values">The values</param>
        public static void GetInteger(ALDevice device, GetInteger64 param, Span<long> values)
        {
            GetInteger(device, param, values.Length, ref values[0]);
        }

        /// <summary>
        ///     Gets the source using the specified source
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="param">The param</param>
        /// <param name="values">The values</param>
        public static void GetSource(int source, SourceInteger64 param, Span<long> values)
        {
            GetSource(source, param, ref values[0]);
        }

        /// <summary>
        ///     Gets the source using the specified source
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="param">The param</param>
        /// <param name="value1">The value</param>
        /// <param name="value2">The value</param>
        /// <param name="value3">The value</param>
        public static unsafe void GetSource(int source, SourceInteger64 param, out int value1, out int value2,
            out long value3)
        {
            int* values = stackalloc int[4];
            GetSource(source, param, (long*) values);
            value1 = values[0];
            value2 = values[1];
            value3 = ((long*) values)[2];
        }

        /// <summary>
        ///     Gets the source using the specified source
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="param">The param</param>
        /// <param name="values">The values</param>
        public static void GetSource(int source, SourceDouble param, Span<double> values)
        {
            GetSource(source, param, ref values[0]);
        }

        /// <summary>
        ///     Gets the source using the specified source
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="param">The param</param>
        /// <param name="value1">The value</param>
        /// <param name="value2">The value</param>
        public static unsafe void GetSource(int source, SourceDouble param, out double value1, out double value2)
        {
            Span<double> values = stackalloc double[2];
            GetSource(source, param, values);
            value1 = values[0];
            value2 = values[1];
        }

#pragma warning disable SA1516 // Elements should be separated by blank line
        /// <summary>
        ///     Gets the integer using the specified device
        /// </summary>
        /// <param name="device">The device</param>
        /// <param name="param">The param</param>
        /// <param name="size">The size</param>
        /// <param name="values">The values</param>
        public static unsafe void GetInteger(ALDevice device, GetInteger64 param, int size, long* values)
        {
            _GetIntegerPtr(device, param, size, values);
        }

        /// <summary>
        ///     The get integer ptr delegate
        /// </summary>
        [UnmanagedFunctionPointer(AL.ALCallingConvention)]
        private unsafe delegate void GetIntegerPtrDelegate(ALDevice device, GetInteger64 param, int size, long* values);

        /// <summary>
        ///     The get integer ptr delegate
        /// </summary>
        private static readonly GetIntegerPtrDelegate _GetIntegerPtr =
            LoadDelegate<GetIntegerPtrDelegate>("alcGetInteger64vSOFT");

        /// <summary>
        ///     Gets the integer using the specified device
        /// </summary>
        /// <param name="device">The device</param>
        /// <param name="param">The param</param>
        /// <param name="size">The size</param>
        /// <param name="values">The values</param>
        private static void GetInteger(ALDevice device, GetInteger64 param, int size, ref long values)
        {
            _GetIntegerRef(device, param, size, ref values);
        }

        /// <summary>
        ///     The get integer ref delegate
        /// </summary>
        [UnmanagedFunctionPointer(AL.ALCallingConvention)]
        private delegate void GetIntegerRefDelegate(ALDevice device, GetInteger64 param, int size, ref long values);

        /// <summary>
        ///     The get integer ref delegate
        /// </summary>
        private static readonly GetIntegerRefDelegate _GetIntegerRef =
            LoadDelegate<GetIntegerRefDelegate>("alcGetInteger64vSOFT");

        /// <summary>
        ///     Gets the integer using the specified device
        /// </summary>
        /// <param name="device">The device</param>
        /// <param name="param">The param</param>
        /// <param name="size">The size</param>
        /// <param name="values">The values</param>
        public static void GetInteger(ALDevice device, GetInteger64 param, int size, long[] values)
        {
            _GetIntegerArray(device, param, size, values);
        }

        /// <summary>
        ///     The get integer array delegate
        /// </summary>
        [UnmanagedFunctionPointer(AL.ALCallingConvention)]
        private delegate void GetIntegerArrayDelegate(ALDevice device, GetInteger64 param, int size, long[] values);

        /// <summary>
        ///     The get integer array delegate
        /// </summary>
        private static readonly GetIntegerArrayDelegate _GetIntegerArray =
            LoadDelegate<GetIntegerArrayDelegate>("alcGetInteger64vSOFT");

        /// <summary>
        ///     Gets the source using the specified source
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="param">The param</param>
        /// <param name="values">The values</param>
        public static unsafe void GetSource(int source, SourceInteger64 param, long* values)
        {
            _GetSourcei64vPtr(source, param, values);
        }

        /// <summary>
        ///     The get sourcei 64v ptr delegate
        /// </summary>
        [UnmanagedFunctionPointer(AL.ALCallingConvention)]
        private unsafe delegate void GetSourcei64vPtrDelegate(int source, SourceInteger64 param, long* values);

        /// <summary>
        ///     The get sourcei 64v ptr delegate
        /// </summary>
        private static readonly GetSourcei64vPtrDelegate _GetSourcei64vPtr =
            LoadDelegate<GetSourcei64vPtrDelegate>("alGetSourcei64vSOFT");

        /// <summary>
        ///     Gets the source using the specified source
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="param">The param</param>
        /// <param name="values">The values</param>
        private static void GetSource(int source, SourceInteger64 param, ref long values)
        {
            _GetSourcei64vRef(source, param, ref values);
        }

        /// <summary>
        ///     The get sourcei 64v ref delegate
        /// </summary>
        [UnmanagedFunctionPointer(AL.ALCallingConvention)]
        private delegate void GetSourcei64vRefDelegate(int source, SourceInteger64 param, ref long values);

        /// <summary>
        ///     The get sourcei 64v ref delegate
        /// </summary>
        private static readonly GetSourcei64vRefDelegate _GetSourcei64vRef =
            LoadDelegate<GetSourcei64vRefDelegate>("alGetSourcei64vSOFT");

        /// <summary>
        ///     Gets the source using the specified source
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="param">The param</param>
        /// <param name="values">The values</param>
        public static void GetSource(int source, SourceInteger64 param, long[] values)
        {
            _GetSourcei64vArray(source, param, values);
        }

        /// <summary>
        ///     The get sourcei 64v array delegate
        /// </summary>
        [UnmanagedFunctionPointer(AL.ALCallingConvention)]
        private delegate void GetSourcei64vArrayDelegate(int source, SourceInteger64 param, long[] values);

        /// <summary>
        ///     The get sourcei 64v array delegate
        /// </summary>
        private static readonly GetSourcei64vArrayDelegate _GetSourcei64vArray =
            LoadDelegate<GetSourcei64vArrayDelegate>("alGetSourcei64vSOFT");

        /// <summary>
        ///     Gets the source using the specified source
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="param">The param</param>
        /// <param name="values">The values</param>
        public static unsafe void GetSource(int source, SourceDouble param, double* values)
        {
            _GetSourcedvPtr(source, param, values);
        }

        /// <summary>
        ///     The get sourcedv ptr delegate
        /// </summary>
        [UnmanagedFunctionPointer(AL.ALCallingConvention)]
        private unsafe delegate void GetSourcedvPtrDelegate(int source, SourceDouble param, double* values);

        /// <summary>
        ///     The get sourcedv ptr delegate
        /// </summary>
        private static readonly GetSourcedvPtrDelegate _GetSourcedvPtr =
            LoadDelegate<GetSourcedvPtrDelegate>("alGetSourcedvSOFT");

        /// <summary>
        ///     Gets the source using the specified source
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="param">The param</param>
        /// <param name="values">The values</param>
        private static void GetSource(int source, SourceDouble param, ref double values)
        {
            _GetSourcedvRef(source, param, ref values);
        }

        /// <summary>
        ///     The get sourcedv ref delegate
        /// </summary>
        [UnmanagedFunctionPointer(AL.ALCallingConvention)]
        private delegate void GetSourcedvRefDelegate(int source, SourceDouble param, ref double values);

        /// <summary>
        ///     The get sourcedv ref delegate
        /// </summary>
        private static readonly GetSourcedvRefDelegate _GetSourcedvRef =
            LoadDelegate<GetSourcedvRefDelegate>("alGetSourcedvSOFT");

        /// <summary>
        ///     Gets the source using the specified source
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="param">The param</param>
        /// <param name="values">The values</param>
        public static void GetSource(int source, SourceDouble param, double[] values)
        {
            _GetSourcedvArray(source, param, values);
        }

        /// <summary>
        ///     The get sourcedv array delegate
        /// </summary>
        [UnmanagedFunctionPointer(AL.ALCallingConvention)]
        private delegate void GetSourcedvArrayDelegate(int source, SourceDouble param, double[] values);

        /// <summary>
        ///     The get sourcedv array delegate
        /// </summary>
        private static readonly GetSourcedvArrayDelegate _GetSourcedvArray =
            LoadDelegate<GetSourcedvArrayDelegate>("alGetSourcedvSOFT");
#pragma warning restore SA1516 // Elements should be separated by blank line
    }
}