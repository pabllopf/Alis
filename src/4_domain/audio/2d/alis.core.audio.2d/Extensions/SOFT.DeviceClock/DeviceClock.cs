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

using System;
using System.Runtime.InteropServices;
using Alis.Core.Audio.Extensions.SOFT.DeviceClock.Enums;
using Alis.Core.Audio.Native;

namespace Alis.Core.Audio.Extensions.SOFT.DeviceClock
{
    public class DeviceClock : ALBase
    {
        static DeviceClock()
        {
            // We need to register the resolver for OpenAL before we can DllImport functions.
            RegisterOpenALResolver();
        }

        private DeviceClock()
        {
        }

        /// <summary>
        ///     The name of this AL extension.
        /// </summary>
        public const string ExtensionName = "ALC_SOFT_device_clock";

        /// <summary>
        ///     Checks if this extension is present.
        /// </summary>
        /// <param name="device">The device to query.</param>
        /// <returns>Whether the extension was present or not.</returns>
        public static bool IsExtensionPresent(ALDevice device) => ALC.ALC.IsExtensionPresent(device, ExtensionName);

        public static void GetInteger(ALDevice device, GetInteger64 param, long[] values)
        {
            GetInteger(device, param, values.Length, values);
        }

        public static void GetInteger(ALDevice device, GetInteger64 param, Span<long> values)
        {
            GetInteger(device, param, values.Length, ref values[0]);
        }

        public static void GetSource(int source, SourceInteger64 param, Span<long> values)
        {
            GetSource(source, param, ref values[0]);
        }

        public static unsafe void GetSource(int source, SourceInteger64 param, out int value1, out int value2,
            out long value3)
        {
            int* values = stackalloc int[4];
            GetSource(source, param, (long*) values);
            value1 = values[0];
            value2 = values[1];
            value3 = ((long*) values)[2];
        }

        public static void GetSource(int source, SourceDouble param, Span<double> values)
        {
            GetSource(source, param, ref values[0]);
        }

        public static unsafe void GetSource(int source, SourceDouble param, out double value1, out double value2)
        {
            Span<double> values = stackalloc double[2];
            GetSource(source, param, values);
            value1 = values[0];
            value2 = values[1];
        }

#pragma warning disable SA1516 // Elements should be separated by blank line
        public static unsafe void GetInteger(ALDevice device, GetInteger64 param, int size, long* values) =>
            _GetIntegerPtr(device, param, size, values);

        [UnmanagedFunctionPointer(AL.AL.ALCallingConvention)]
        private unsafe delegate void GetIntegerPtrDelegate(ALDevice device, GetInteger64 param, int size, long* values);

        private static readonly GetIntegerPtrDelegate _GetIntegerPtr =
            LoadDelegate<GetIntegerPtrDelegate>("alcGetInteger64vSOFT");

        private static void GetInteger(ALDevice device, GetInteger64 param, int size, ref long values) =>
            _GetIntegerRef(device, param, size, ref values);

        [UnmanagedFunctionPointer(AL.AL.ALCallingConvention)]
        private delegate void GetIntegerRefDelegate(ALDevice device, GetInteger64 param, int size, ref long values);

        private static readonly GetIntegerRefDelegate _GetIntegerRef =
            LoadDelegate<GetIntegerRefDelegate>("alcGetInteger64vSOFT");

        public static void GetInteger(ALDevice device, GetInteger64 param, int size, long[] values) =>
            _GetIntegerArray(device, param, size, values);

        [UnmanagedFunctionPointer(AL.AL.ALCallingConvention)]
        private delegate void GetIntegerArrayDelegate(ALDevice device, GetInteger64 param, int size, long[] values);

        private static readonly GetIntegerArrayDelegate _GetIntegerArray =
            LoadDelegate<GetIntegerArrayDelegate>("alcGetInteger64vSOFT");

        public static unsafe void GetSource(int source, SourceInteger64 param, long* values) =>
            _GetSourcei64vPtr(source, param, values);

        [UnmanagedFunctionPointer(AL.AL.ALCallingConvention)]
        private unsafe delegate void GetSourcei64vPtrDelegate(int source, SourceInteger64 param, long* values);

        private static readonly GetSourcei64vPtrDelegate _GetSourcei64vPtr =
            LoadDelegate<GetSourcei64vPtrDelegate>("alGetSourcei64vSOFT");

        private static void GetSource(int source, SourceInteger64 param, ref long values) =>
            _GetSourcei64vRef(source, param, ref values);

        [UnmanagedFunctionPointer(AL.AL.ALCallingConvention)]
        private delegate void GetSourcei64vRefDelegate(int source, SourceInteger64 param, ref long values);

        private static readonly GetSourcei64vRefDelegate _GetSourcei64vRef =
            LoadDelegate<GetSourcei64vRefDelegate>("alGetSourcei64vSOFT");

        public static void GetSource(int source, SourceInteger64 param, long[] values) =>
            _GetSourcei64vArray(source, param, values);

        [UnmanagedFunctionPointer(AL.AL.ALCallingConvention)]
        private delegate void GetSourcei64vArrayDelegate(int source, SourceInteger64 param, long[] values);

        private static readonly GetSourcei64vArrayDelegate _GetSourcei64vArray =
            LoadDelegate<GetSourcei64vArrayDelegate>("alGetSourcei64vSOFT");

        public static unsafe void GetSource(int source, SourceDouble param, double* values) =>
            _GetSourcedvPtr(source, param, values);

        [UnmanagedFunctionPointer(AL.AL.ALCallingConvention)]
        private unsafe delegate void GetSourcedvPtrDelegate(int source, SourceDouble param, double* values);

        private static readonly GetSourcedvPtrDelegate _GetSourcedvPtr =
            LoadDelegate<GetSourcedvPtrDelegate>("alGetSourcedvSOFT");

        private static void GetSource(int source, SourceDouble param, ref double values) =>
            _GetSourcedvRef(source, param, ref values);

        [UnmanagedFunctionPointer(AL.AL.ALCallingConvention)]
        private delegate void GetSourcedvRefDelegate(int source, SourceDouble param, ref double values);

        private static readonly GetSourcedvRefDelegate _GetSourcedvRef =
            LoadDelegate<GetSourcedvRefDelegate>("alGetSourcedvSOFT");

        public static void GetSource(int source, SourceDouble param, double[] values) =>
            _GetSourcedvArray(source, param, values);

        [UnmanagedFunctionPointer(AL.AL.ALCallingConvention)]
        private delegate void GetSourcedvArrayDelegate(int source, SourceDouble param, double[] values);

        private static readonly GetSourcedvArrayDelegate _GetSourcedvArray =
            LoadDelegate<GetSourcedvArrayDelegate>("alGetSourcedvSOFT");
#pragma warning restore SA1516 // Elements should be separated by blank line
    }
}