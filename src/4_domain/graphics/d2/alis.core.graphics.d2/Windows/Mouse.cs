// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Mouse.cs
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
using Alis.Core.Graphics2D.Systems;

namespace Alis.Core.Graphics2D.Windows
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    ///     Give access to the real-time state of the mouse
    /// </summary>
    ////////////////////////////////////////////////////////////
    public static class Mouse
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Mouse buttons
        /// </summary>
        ////////////////////////////////////////////////////////////
        public enum Button
        {
            /// <summary>The left mouse button</summary>
            Left,

            /// <summary>The right mouse button</summary>
            Right,

            /// <summary>The middle (wheel) mouse button</summary>
            Middle,

            /// <summary>The first extra mouse button</summary>
            XButton1,

            /// <summary>The second extra mouse button</summary>
            XButton2,

            /// <summary>Keep last -- the total number of mouse buttons</summary>
            ButtonCount
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Mouse wheels
        /// </summary>
        ////////////////////////////////////////////////////////////
        public enum Wheel
        {
            /// <summary>The vertical mouse wheel</summary>
            VerticalWheel,

            /// <summary>The horizontal mouse wheel</summary>
            HorizontalWheel
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Check if a mouse button is pressed
        /// </summary>
        /// <param name="button">Button to check</param>
        /// <returns>True if the button is pressed, false otherwise</returns>
        ////////////////////////////////////////////////////////////
        public static bool IsButtonPressed(Button button) => sfMouse_isButtonPressed(button);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Get the current position of the mouse
        /// </summary>
        /// This function returns the current position of the mouse
        /// cursor in desktop coordinates.
        /// <returns>Current position of the mouse</returns>
        ////////////////////////////////////////////////////////////
        public static Vector2i GetPosition() => GetPosition(null);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Get the current position of the mouse
        /// </summary>
        /// This function returns the current position of the mouse
        /// cursor relative to a window.
        /// <param name="relativeTo">Reference window</param>
        /// <returns>Current position of the mouse</returns>
        ////////////////////////////////////////////////////////////
        public static Vector2i GetPosition(Window relativeTo)
        {
            if (relativeTo != null)
            {
                return relativeTo.InternalGetMousePosition();
            }

            return sfMouse_getPosition(IntPtr.Zero);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Set the current position of the mouse
        /// </summary>
        /// This function sets the current position of the mouse
        /// cursor in desktop coordinates.
        /// <param name="position">New position of the mouse</param>
        ////////////////////////////////////////////////////////////
        public static void SetPosition(Vector2i position)
        {
            SetPosition(position, null);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Set the current position of the mouse
        /// </summary>
        /// This function sets the current position of the mouse
        /// cursor relative to a window.
        /// <param name="position">New position of the mouse</param>
        /// <param name="relativeTo">Reference window</param>
        ////////////////////////////////////////////////////////////
        public static void SetPosition(Vector2i position, Window relativeTo)
        {
            if (relativeTo != null)
            {
                relativeTo.InternalSetMousePosition(position);
            }
            else
            {
                sfMouse_setPosition(position, IntPtr.Zero);
            }
        }

        #region Imports

        /// <summary>
        ///     Describes whether sf mouse is button pressed
        /// </summary>
        /// <param name="button">The button</param>
        /// <returns>The bool</returns>
        [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern bool sfMouse_isButtonPressed(Button button);

        /// <summary>
        ///     Sfs the mouse get position using the specified relative to
        /// </summary>
        /// <param name="relativeTo">The relative to</param>
        /// <returns>The vector 2i</returns>
        [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern Vector2i sfMouse_getPosition(IntPtr relativeTo);

        /// <summary>
        ///     Sfs the mouse set position using the specified position
        /// </summary>
        /// <param name="position">The position</param>
        /// <param name="relativeTo">The relative to</param>
        [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfMouse_setPosition(Vector2i position, IntPtr relativeTo);

        #endregion
    }
}