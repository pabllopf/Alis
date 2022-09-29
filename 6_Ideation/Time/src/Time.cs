// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Time.cs
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

namespace Alis.Core.Aspect.Time
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    ///     This class represents a time value
    /// </summary>
    ////////////////////////////////////////////////////////////
    [StructLayout(LayoutKind.Sequential)]
    public struct Time : IEquatable<Time>
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Predefined "zero" time value
        /// </summary>
        ////////////////////////////////////////////////////////////
        public static readonly Time Zero = FromMicroseconds(0);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct a time value from a number of seconds
        /// </summary>
        /// <param name="seconds">Number of seconds</param>
        /// <returns>Time value constructed from the amount of seconds</returns>
        ////////////////////////////////////////////////////////////
        public static Time FromSeconds(float seconds) => sfSeconds(seconds);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct a time value from a number of milliseconds
        /// </summary>
        /// <param name="milliseconds">Number of milliseconds</param>
        /// <returns>Time value constructed from the amount of milliseconds</returns>
        ////////////////////////////////////////////////////////////
        public static Time FromMilliseconds(int milliseconds) => sfMilliseconds(milliseconds);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct a time value from a number of microseconds
        /// </summary>
        /// <param name="microseconds">Number of microseconds</param>
        /// <returns>Time value constructed from the amount of microseconds</returns>
        ////////////////////////////////////////////////////////////
        public static Time FromMicroseconds(long microseconds) => sfMicroseconds(microseconds);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Returns the time value as a number of seconds
        /// </summary>
        ////////////////////////////////////////////////////////////
        public float AsSeconds() => sfTime_asSeconds(this);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Returns the time value as a number of milliseconds
        /// </summary>
        ////////////////////////////////////////////////////////////
        public int AsMilliseconds() => sfTime_asMilliseconds(this);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Returns the time value as a number of microseconds
        /// </summary>
        ////////////////////////////////////////////////////////////
        public long AsMicroseconds() => sfTime_asMicroseconds(this);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Compare two times and checks if they are equal
        /// </summary>
        /// <returns>Times are equal</returns>
        ////////////////////////////////////////////////////////////
        public static bool operator ==(Time left, Time right) => left.Equals(right);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Compare two times and checks if they are not equal
        /// </summary>
        /// <returns>Times are not equal</returns>
        ////////////////////////////////////////////////////////////
        public static bool operator !=(Time left, Time right) => !left.Equals(right);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Compare time and object and checks if they are equal
        /// </summary>
        /// <param name="obj">Object to check</param>
        /// <returns>Object and time are equal</returns>
        ////////////////////////////////////////////////////////////
        public override bool Equals(object obj) => obj is Time && Equals((Time) obj);

        ///////////////////////////////////////////////////////////
        /// <summary>
        ///     Compare two times and checks if they are equal
        /// </summary>
        /// <param name="other">Time to check</param>
        /// <returns>times are equal</returns>
        ////////////////////////////////////////////////////////////
        public bool Equals(Time other) => microseconds == other.microseconds;

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Overload of &lt; operator to compare two time values
        /// </summary>
        /// <returns>True if left is lesser than right</returns>
        ////////////////////////////////////////////////////////////
        public static bool operator <(Time left, Time right) => left.AsMicroseconds() < right.AsMicroseconds();

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Overload of &lt;= operator to compare two time values
        /// </summary>
        /// <returns>True if left is lesser or equal than right</returns>
        ////////////////////////////////////////////////////////////
        public static bool operator <=(Time left, Time right) => left.AsMicroseconds() <= right.AsMicroseconds();

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Overload of &gt; operator to compare two time values
        /// </summary>
        /// <returns>True if left is greater than right</returns>
        ////////////////////////////////////////////////////////////
        public static bool operator >(Time left, Time right) => left.AsMicroseconds() > right.AsMicroseconds();

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Overload of &gt;= operator to compare two time values
        /// </summary>
        /// <returns>True if left is greater or equal than right</returns>
        ////////////////////////////////////////////////////////////
        public static bool operator >=(Time left, Time right) => left.AsMicroseconds() >= right.AsMicroseconds();

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Overload of binary - operator to subtract two time values
        /// </summary>
        /// <returns>Difference of the two times values</returns>
        ////////////////////////////////////////////////////////////
        public static Time operator -(Time left, Time right) => FromMicroseconds(left.AsMicroseconds() - right.AsMicroseconds());

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Overload of binary + operator to add two time values
        /// </summary>
        /// <returns>Sum of the two times values</returns>
        ////////////////////////////////////////////////////////////
        public static Time operator +(Time left, Time right) => FromMicroseconds(left.AsMicroseconds() + right.AsMicroseconds());

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Overload of binary * operator to scale a time value
        /// </summary>
        /// <returns>left multiplied by the right</returns>
        ////////////////////////////////////////////////////////////
        public static Time operator *(Time left, float right) => FromSeconds(left.AsSeconds() * right);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Overload of binary * operator to scale a time value
        /// </summary>
        /// <returns>left multiplied by the right</returns>
        ////////////////////////////////////////////////////////////
        public static Time operator *(Time left, long right) => FromMicroseconds(left.AsMicroseconds() * right);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Overload of binary * operator to scale a time value
        /// </summary>
        /// <returns>left multiplied by the right</returns>
        ////////////////////////////////////////////////////////////
        public static Time operator *(float left, Time right) => FromSeconds(left * right.AsSeconds());

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Overload of binary * operator to scale a time value
        /// </summary>
        /// <returns>left multiplied by the right</returns>
        ////////////////////////////////////////////////////////////
        public static Time operator *(long left, Time right) => FromMicroseconds(left * right.AsMicroseconds());

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Overload of binary / operator to scale a time value
        /// </summary>
        /// <returns>left divided by the right</returns>
        ////////////////////////////////////////////////////////////
        public static Time operator /(Time left, Time right) => FromMicroseconds(left.AsMicroseconds() / right.AsMicroseconds());

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Overload of binary / operator to scale a time value
        /// </summary>
        /// <returns>left divided by the right</returns>
        ////////////////////////////////////////////////////////////
        public static Time operator /(Time left, float right) => FromSeconds(left.AsSeconds() / right);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Overload of binary / operator to scale a time value
        /// </summary>
        /// <returns>left divided by the right</returns>
        ////////////////////////////////////////////////////////////
        public static Time operator /(Time left, long right) => FromMicroseconds(left.AsMicroseconds() / right);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Overload of binary % operator to compute remainder of a time value
        /// </summary>
        /// <returns>left modulo of right</returns>
        ////////////////////////////////////////////////////////////
        public static Time operator %(Time left, Time right) => FromMicroseconds(left.AsMicroseconds() % right.AsMicroseconds());

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Provide a integer describing the object
        /// </summary>
        /// <returns>Integer description of the object</returns>
        ////////////////////////////////////////////////////////////
        public override int GetHashCode() => microseconds.GetHashCode();

        /// <summary>
        ///     The microseconds
        /// </summary>
        private readonly long microseconds;

        /// <summary>
        ///     Sfs the seconds using the specified amount
        /// </summary>
        /// <param name="amount">The amount</param>
        /// <returns>The time</returns>
        [DllImport(Csfml.System, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern Time sfSeconds(float amount);

        /// <summary>
        ///     Sfs the milliseconds using the specified amount
        /// </summary>
        /// <param name="amount">The amount</param>
        /// <returns>The time</returns>
        [DllImport(Csfml.System, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern Time sfMilliseconds(int amount);

        /// <summary>
        ///     Sfs the microseconds using the specified amount
        /// </summary>
        /// <param name="amount">The amount</param>
        /// <returns>The time</returns>
        [DllImport(Csfml.System, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern Time sfMicroseconds(long amount);

        /// <summary>
        ///     Sfs the time as seconds using the specified time
        /// </summary>
        /// <param name="time">The time</param>
        /// <returns>The float</returns>
        [DllImport(Csfml.System, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern float sfTime_asSeconds(Time time);

        /// <summary>
        ///     Sfs the time as milliseconds using the specified time
        /// </summary>
        /// <param name="time">The time</param>
        /// <returns>The int</returns>
        [DllImport(Csfml.System, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern int sfTime_asMilliseconds(Time time);

        /// <summary>
        ///     Sfs the time as microseconds using the specified time
        /// </summary>
        /// <param name="time">The time</param>
        /// <returns>The long</returns>
        [DllImport(Csfml.System, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern long sfTime_asMicroseconds(Time time);
    }
}