// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Cursor.cs
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
using Alis.Core.Aspect.Base.Attributes;
using Alis.Core.Aspect.Base.Settings;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Graphic.SFML.Windows
{
    /// <summary>
    ///     The cursor class
    /// </summary>
    /// <seealso cref="ObjectBase" />
    public class Cursor : ObjectBase
    {
        /// <summary>
        ///     Create a native system cursor
        ///     Refer to the list of cursor available on each system
        ///     (see CursorType) to know whether a given cursor is
        ///     expected to load successfully or is not supported by
        ///     the operating system.
        /// </summary>
        /// <param name="type">System cursor type</param>
        public Cursor(CursorType type)
            : base(sfCursor_createFromSystem(type))
        {
        }

        /// <summary>
        ///     Create a cursor with the provided image
        ///     Pixels must be an array of width by height pixels
        ///     in 32-bit RGBA format. If not, this will cause undefined behavior.
        ///     If pixels is null or either width or height are 0,
        ///     the current cursor is left unchanged and the function will
        ///     return false.
        ///     In addition to specifying the pixel data, you can also
        ///     specify the location of the hotspot of the cursor. The
        ///     hotspot is the pixel coordinate within the cursor image
        ///     which will be located exactly where the mouse pointer
        ///     position is. Any mouse actions that are performed will
        ///     return the window/screen location of the hotspot.
        ///     Warning: On Unix, the pixels are mapped into a monochrome
        ///     bitmap: pixels with an alpha channel to 0 are
        ///     transparent, black if the RGB channel are close
        ///     to zero, and white otherwise.
        /// </summary>
        /// <param name="pixels">Array of pixels of the image</param>
        /// <param name="size">Width and height of the image</param>
        /// <param name="hotspot">(x,y) location of the hotspot</param>
        public Cursor(byte[] pixels, Vector2U size, Vector2U hotspot)
            : base((IntPtr) 0)
        {
            unsafe
            {
                fixed (byte* ptr = pixels)
                {
                    CPointer = sfCursor_createFromPixels((IntPtr) ptr, size, hotspot);
                }
            }
        }

        /// <summary>
        ///     Enumeration of possibly available native system cursor types
        /// </summary>
        public enum CursorType
        {
            /// <summary>
            ///     Arrow cursor (default)
            ///     Windows: Yes
            ///     Mac OS:  Yes
            ///     Linux:   Yes
            /// </summary>
            Arrow,

            /// <summary>
            ///     Busy arrow cursor
            ///     Windows: Yes
            ///     Mac OS:  No
            ///     Linux:   No
            /// </summary>
            ArrowWait,

            /// <summary>
            ///     Busy cursor
            ///     Windows: Yes
            ///     Mac OS:  No
            ///     Linux:   Yes
            /// </summary>
            Wait,

            /// <summary>
            ///     I-beam, cursor when hovering over a field allowing text entry
            ///     Windows: Yes
            ///     Mac OS:  Yes
            ///     Linux:   Yes
            /// </summary>
            Text,

            /// <summary>
            ///     Pointing hand cursor
            ///     Windows: Yes
            ///     Mac OS:  Yes
            ///     Linux:   Yes
            /// </summary>
            Hand,

            /// <summary>
            ///     Horizontal double arrow cursor
            ///     Windows: Yes
            ///     Mac OS:  Yes
            ///     Linux:   Yes
            /// </summary>
            SizeHorinzontal,

            /// <summary>
            ///     Vertical double arrow cursor
            ///     Windows: Yes
            ///     Mac OS:  Yes
            ///     Linux:   Yes
            /// </summary>
            SizeVertical,

            /// <summary>
            ///     Double arrow cursor going from top-left to bottom-right
            ///     Windows: Yes
            ///     Mac OS:  No
            ///     Linux:   No
            /// </summary>
            SizeTopLeftBottomRight,

            /// <summary>
            ///     Double arrow cursor going from bottom-left to top-right
            ///     Windows: Yes
            ///     Mac OS:  No
            ///     Linux:   No
            /// </summary>
            SizeBottomLeftTopRight,

            /// <summary>
            ///     Combination of SizeHorizontal and SizeVertical
            ///     Windows: Yes
            ///     Mac OS:  No
            ///     Linux:   Yes
            /// </summary>
            SizeAll,

            /// <summary>
            ///     Crosshair cursor
            ///     Windows: Yes
            ///     Mac OS:  Yes
            ///     Linux:   Yes
            /// </summary>
            Cross,

            /// <summary>
            ///     Help cursor
            ///     Windows: Yes
            ///     Mac OS:  No
            ///     Linux:   Yes
            /// </summary>
            Help,

            /// <summary>
            ///     Action not allowed cursor
            ///     Windows: Yes
            ///     Mac OS:  Yes
            ///     Linux:   Yes
            /// </summary>
            NotAllowed
        }

        /// <summary>
        ///     Destroys the disposing
        /// </summary>
        /// <param name="disposing">The disposing</param>
        protected override void Destroy(bool disposing)
        {
            sfCursor_destroy(CPointer);
        }

        /// <summary>
        ///     Sfs the cursor create from system using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfCursor_createFromSystem(CursorType type);

        /// <summary>
        ///     Sfs the cursor create from pixels using the specified pixels
        /// </summary>
        /// <param name="pixels">The pixels</param>
        /// <param name="size">The size</param>
        /// <param name="hotspot">The hotspot</param>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfCursor_createFromPixels(IntPtr pixels, Vector2U size, Vector2U hotspot);

        /// <summary>
        ///     Sfs the cursor destroy using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfCursor_destroy(IntPtr cPointer);
    }
}