// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:HGLRC.cs
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
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.GlfwLib.Structs
{
    /// <summary>
    ///     Wrapper around a Window's HGLRC pointer.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Hglrc : IEquatable<Hglrc>
    {
        /// <summary>
        ///     Describes a default/null instance.
        /// </summary>
        public static readonly Hglrc None;

        /// <summary>
        ///     Internal pointer.
        /// </summary>
        private readonly IntPtr handle;

        /// <summary>
        ///     Performs an implicit conversion from <see cref="Hglrc" /> to <see cref="IntPtr" />.
        /// </summary>
        /// <param name="hglrc">The hglrc.</param>
        /// <returns>
        ///     The result of the conversion.
        /// </returns>
        public static implicit operator IntPtr(Hglrc hglrc) => hglrc.handle;

        /// <summary>
        ///     Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        ///     A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => handle.ToString();

        /// <summary>
        ///     Determines whether the specified <see cref="Hglrc" />, is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="Hglrc" /> to compare with this instance.</param>
        /// <returns>
        ///     <c>true</c> if the specified <see cref="Hglrc" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(Hglrc other) => handle.Equals(other.handle);

        /// <summary>
        ///     Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///     <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is Hglrc hglrc)
            {
                return Equals(hglrc);
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
        public static bool operator ==(Hglrc left, Hglrc right) => left.Equals(right);

        /// <summary>
        ///     Implements the operator !=.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        ///     The result of the operator.
        /// </returns>
        public static bool operator !=(Hglrc left, Hglrc right) => !left.Equals(right);
    }
}