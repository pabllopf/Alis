// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Clock.cs
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
using Alis.Core.Aspect.Base;
using Alis.Core.Aspect.Base.Attributes;
using Alis.Core.Aspect.Base.Settings;

namespace Alis.Core.Graphic.D2.SFML.Graphics
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    ///     Utility class that measures the elapsed time
    /// </summary>
    ////////////////////////////////////////////////////////////
    public class Clock : ObjectBase
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Default Constructor
        /// </summary>
        ////////////////////////////////////////////////////////////
        public Clock() : base(sfClock_create())
        {
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Gets the time elapsed since the last call to Restart
        /// </summary>
        ////////////////////////////////////////////////////////////
        public Time ElapsedTime => sfClock_getElapsedTime(CPointer);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Handle the destruction of the object
        /// </summary>
        /// <param name="disposing">Is the GC disposing the object, or is it an explicit call ?</param>
        ////////////////////////////////////////////////////////////
        protected override void Destroy(bool disposing)
        {
            sfClock_destroy(CPointer);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     This function puts the time counter back to zero.
        /// </summary>
        /// <returns>Time elapsed since the clock was started.</returns>
        ////////////////////////////////////////////////////////////
        public Time Restart() => sfClock_restart(CPointer);

        /// <summary>
        ///     Sfs the clock create
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.System, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfClock_create();

        /// <summary>
        ///     Sfs the clock destroy using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        [DllImport(Csfml.System, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfClock_destroy(IntPtr cPointer);

        /// <summary>
        ///     Sfs the clock get elapsed time using the specified clock
        /// </summary>
        /// <param name="clock">The clock</param>
        /// <returns>The time</returns>
        [DllImport(Csfml.System, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern Time sfClock_getElapsedTime(IntPtr clock);

        /// <summary>
        ///     Sfs the clock restart using the specified clock
        /// </summary>
        /// <param name="clock">The clock</param>
        /// <returns>The time</returns>
        [DllImport(Csfml.System, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern Time sfClock_restart(IntPtr clock);
    }
}