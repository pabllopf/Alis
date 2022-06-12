// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Touch.cs
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
using System.Security;
using Alis.Core.Graphic.D2.Graphics;

namespace Alis.Core.Graphic.D2.Windows
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    ///     Give access to the real-time state of the touches
    /// </summary>
    ////////////////////////////////////////////////////////////
    public static class Touch
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Check if a touch event is currently down
        /// </summary>
        /// <param name="Finger">Finger index</param>
        /// <returns>True if the finger is currently touching the screen, false otherwise</returns>
        ////////////////////////////////////////////////////////////
        public static bool IsDown(uint Finger)
        {
            return sfTouch_isDown(Finger);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     This function returns the current touch position
        /// </summary>
        /// <param name="Finger">Finger index</param>
        /// <returns>Current position of the finger</returns>
        ////////////////////////////////////////////////////////////
        public static Vector2i GetPosition(uint Finger)
        {
            return GetPosition(Finger, null);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     This function returns the current touch position
        ///     relative to the given window
        /// </summary>
        /// <param name="Finger">Finger index</param>
        /// <param name="RelativeTo">Reference window</param>
        /// <returns>Current position of the finger</returns>
        ////////////////////////////////////////////////////////////
        public static Vector2i GetPosition(uint Finger, Window RelativeTo)
        {
            if (RelativeTo != null)
            {
                return RelativeTo.InternalGetTouchPosition(Finger);
            }

            return sfTouch_getPosition(Finger, IntPtr.Zero);
        }

        /// <summary>
        ///     Describes whether sf touch is down
        /// </summary>
        /// <param name="Finger">The finger</param>
        /// <returns>The bool</returns>
        [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurity]
        private static extern bool sfTouch_isDown(uint Finger);

        /// <summary>
        ///     Sfs the touch get position using the specified finger
        /// </summary>
        /// <param name="Finger">The finger</param>
        /// <param name="RelativeTo">The relative to</param>
        /// <returns>The vector 2i</returns>
        [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurity]
        private static extern Vector2i sfTouch_getPosition(uint Finger, IntPtr RelativeTo);
    }
}