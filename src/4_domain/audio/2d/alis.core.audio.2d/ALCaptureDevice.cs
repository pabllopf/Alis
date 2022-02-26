// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   ALCaptureDevice.cs
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
using System.Diagnostics.CodeAnalysis;

namespace Alis.Core.Audio
{
    /// <summary>
    ///     Handle to an OpenAL capture device.
    /// </summary>
    public struct ALCaptureDevice : IEquatable<ALCaptureDevice>
    {
        /// <summary>
        /// The zero
        /// </summary>
        public static readonly ALCaptureDevice Null = new ALCaptureDevice(IntPtr.Zero);

        /// <summary>
        /// The handle
        /// </summary>
        public IntPtr Handle;

        /// <summary>
        /// Initializes a new instance of the <see cref="ALCaptureDevice"/> class
        /// </summary>
        /// <param name="handle">The handle</param>
        public ALCaptureDevice(IntPtr handle) => Handle = handle;

        /// <summary>
        /// Describes whether this instance equals
        /// </summary>
        /// <param name="obj">The obj</param>
        /// <returns>The bool</returns>
        public override bool Equals(object obj) => obj is ALCaptureDevice device && Equals(device);

        /// <summary>
        /// Describes whether this instance equals
        /// </summary>
        /// <param name="other">The other</param>
        /// <returns>The bool</returns>
        public bool Equals([AllowNull] ALCaptureDevice other) => Handle.Equals(other.Handle);

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>The int</returns>
        public override int GetHashCode() => HashCode.Combine(Handle);

        public static bool operator ==(ALCaptureDevice left, ALCaptureDevice right) => left.Equals(right);

        public static bool operator !=(ALCaptureDevice left, ALCaptureDevice right) => !(left == right);

        public static implicit operator IntPtr(ALCaptureDevice device) => device.Handle;
    }
}