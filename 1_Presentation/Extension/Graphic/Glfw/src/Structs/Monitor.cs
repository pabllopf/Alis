// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Monitor.cs
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
using System.Drawing;
using System.Runtime.InteropServices;

namespace Alis.Extension.Graphic.Glfw.Structs
{
    /// <summary>
    ///     Wrapper around a pointer to monitor.
    /// </summary>
    /// <seealso cref="Monitor" />
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Monitor : IEquatable<Monitor>
    {
        /// <summary>
        ///     Represents a <c>null</c> value for a <see cref="Monitor" /> object.
        /// </summary>
        public static readonly Monitor None;

        /// <summary>
        ///     Internal pointer.
        /// </summary>
        private readonly IntPtr handle;

        /// <summary>
        ///     Determines whether the specified <see cref="Monitor" />, is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="Monitor" /> to compare with this instance.</param>
        /// <returns>
        ///     <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(Monitor other) => handle.Equals(other.handle);

        /// <summary>
        ///     Determines whether the specified <see cref="object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns>
        ///     <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is Monitor monitor)
            {
                return Equals(monitor);
            }

            return false;
        }

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        ///     A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode() => handle.GetHashCode();

        /// <summary>
        ///     Implements the operator ==.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        ///     The result of the operator.
        /// </returns>
        public static bool operator ==(Monitor left, Monitor right) => left.Equals(right);

        /// <summary>
        ///     Implements the operator !=.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        ///     The result of the operator.
        /// </returns>
        public static bool operator !=(Monitor left, Monitor right) => !left.Equals(right);

        /// <summary>
        ///     Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>
        ///     A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString() => handle.ToString();

        /// <summary>
        ///     Gets the position, in screen coordinates of the valid work are for the monitor.
        /// </summary>
        public Rectangle WorkArea
        {
            get
            {
                GlfwNative.GetMonitorWorkArea(handle, out int x, out int y, out int width, out int height);
                return new Rectangle(x, y, width, height);
            }
        }

        /// <summary>
        ///     Gets the content scale of this monitor.
        ///     <para>The content scale is the ratio between the current DPI and the platform's default DPI.</para>
        /// </summary>
        /// <seealso cref="GlfwNative.GetMonitorContentScale" />

        public PointF ContentScale
        {
            get
            {
                GlfwNative.GetMonitorContentScale(handle, out float x, out float y);
                return new PointF(x, y);
            }
        }

        /// <summary>
        ///     Gets or sets a user-defined pointer to associate with the window.
        /// </summary>
        /// <seealso cref="GlfwNative.GetMonitorUserPointer" />
        /// <seealso cref="GlfwNative.SetMonitorUserPointer" />
        public IntPtr UserPointer
        {
            get => GlfwNative.GetMonitorUserPointer(handle);
            set => GlfwNative.SetMonitorUserPointer(handle, value);
        }
    }
}