// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   SourceLatency.cs
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
using Alis.Core.Audio2D.Extensions.SOFT.SourceLatency.Enums;
using Alis.Core.Audio2D.Mathematics.Vector;
using Alis.Core.Audio2D.Native;

namespace Alis.Core.Audio2D.Extensions.SOFT.SourceLatency
{
    /// <summary>
    ///     The source latency class
    /// </summary>
    /// <seealso cref="ALBase" />
    public class SourceLatency : ALBase
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SourceLatency" /> class
        /// </summary>
        static SourceLatency()
        {
            // We need to register the resolver for OpenAL before we can DllImport functions.
            RegisterOpenALResolver();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SourceLatency" /> class
        /// </summary>
        private SourceLatency()
        {
        }

        /// <summary>
        ///     The name of this AL extension.
        /// </summary>
        public const string ExtensionName = "AL_SOFT_source_latency";

        /// <summary>
        ///     Checks if this extension is present.
        /// </summary>
        /// <returns>Whether the extension was present or not.</returns>
        public static bool IsExtensionPresent() => AL.IsExtensionPresent(ExtensionName);

        /// <summary>
        ///     Gets the source using the specified source
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="param">The param</param>
        /// <param name="value1">The value</param>
        /// <param name="value2">The value</param>
        public static unsafe void GetSource(int source, SourceLatencyVector2i param, out long value1, out long value2)
        {
            long* values = stackalloc long[2];
            GetSource(source, param, values);
            value1 = values[0];
            value2 = values[1];
        }

        /// <summary>
        ///     Gets the source using the specified source
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="param">The param</param>
        /// <param name="values">The values</param>
        public static void GetSource(int source, SourceLatencyVector2i param, Span<long> values)
        {
            GetSource(source, param, out values[0]);
        }

        /// <summary>
        ///     Gets the source using the specified source
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="param">The param</param>
        /// <param name="value1">The value</param>
        /// <param name="value2">The value</param>
        /// <param name="value3">The value</param>
        public static unsafe void GetSource(int source, SourceLatencyVector2i param, out int value1, out int value2,
            out long value3)
        {
            // FIXME: This might result in wrong values, though it seems to be somewhat correct...
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
        /// <param name="value1">The value</param>
        /// <param name="value2">The value</param>
        public static unsafe void GetSource(int source, SourceLatencyVector2d param, out double value1,
            out double value2)
        {
            double* values = stackalloc double[2];
            GetSource(source, param, values);
            value1 = values[0];
            value2 = values[1];
        }

        /// <summary>
        ///     Gets the source using the specified source
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="param">The param</param>
        /// <param name="values">The values</param>
        public static void GetSource(int source, SourceLatencyVector2d param, Span<double> values)
        {
            GetSource(source, param, out values[0]);
        }

        /// <summary>
        ///     Gets the source using the specified source
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="param">The param</param>
        /// <param name="values">The values</param>
        public static void GetSource(int source, SourceLatencyVector2d param, out Vector2d values)
        {
            values.Y = default(double);
            GetSource(source, param, out values.X);
        }

#pragma warning disable SA1516 // Elements should be separated by blank line
        /// <summary>
        ///     Gets the source using the specified source
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="param">The param</param>
        /// <param name="values">The values</param>
        public static unsafe void GetSource(int source, SourceLatencyVector2i param, long* values) =>
            _GetSourcei64vPtr(source, param, values);

        /// <summary>
        ///     The get sourcei 64v ptr delegate
        /// </summary>
        [UnmanagedFunctionPointer(AL.ALCallingConvention)]
        private unsafe delegate void GetSourcei64vPtrDelegate(int source, SourceLatencyVector2i param, long* values);

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
        private static void GetSource(int source, SourceLatencyVector2i param, out long values) =>
            _GetSourcei64vRef(source, param, out values);

        /// <summary>
        ///     The get sourcei 64v ref delegate
        /// </summary>
        [UnmanagedFunctionPointer(AL.ALCallingConvention)]
        private delegate void GetSourcei64vRefDelegate(int source, SourceLatencyVector2i param, out long values);

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
        public static void GetSource(int source, SourceLatencyVector2i param, long[] values) =>
            _GetSourcei64vArray(source, param, values);

        /// <summary>
        ///     The get sourcei 64v array delegate
        /// </summary>
        [UnmanagedFunctionPointer(AL.ALCallingConvention)]
        private delegate void GetSourcei64vArrayDelegate(int source, SourceLatencyVector2i param, long[] values);

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
        public static unsafe void GetSource(int source, SourceLatencyVector2d param, double* values) =>
            _GetSourcedvPtr(source, param, values);

        /// <summary>
        ///     The get sourcedv ptr delegate
        /// </summary>
        [UnmanagedFunctionPointer(AL.ALCallingConvention)]
        private unsafe delegate void GetSourcedvPtrDelegate(int source, SourceLatencyVector2d param, double* values);

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
        private static void GetSource(int source, SourceLatencyVector2d param, out double values) =>
            _GetSourcedvRef(source, param, out values);

        /// <summary>
        ///     The get sourcedv ref delegate
        /// </summary>
        [UnmanagedFunctionPointer(AL.ALCallingConvention)]
        private delegate void GetSourcedvRefDelegate(int source, SourceLatencyVector2d param, out double values);

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
        public static void GetSource(int source, SourceLatencyVector2d param, double[] values) =>
            _GetSourcedvArray(source, param, values);

        /// <summary>
        ///     The get sourcedv array delegate
        /// </summary>
        [UnmanagedFunctionPointer(AL.ALCallingConvention)]
        private delegate void GetSourcedvArrayDelegate(int source, SourceLatencyVector2d param, double[] values);

        /// <summary>
        ///     The get sourcedv array delegate
        /// </summary>
        private static readonly GetSourcedvArrayDelegate _GetSourcedvArray =
            LoadDelegate<GetSourcedvArrayDelegate>("alGetSourcedvSOFT");
#pragma warning restore SA1516 // Elements should be separated by blank line
    }
}