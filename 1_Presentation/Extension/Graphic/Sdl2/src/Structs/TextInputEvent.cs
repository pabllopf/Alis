// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TextInputEvent.cs
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

using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Sdl2.Enums;

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     Represents an SDL text input event, fired when a Unicode character is composed and entered via IME or keyboard.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TextInputEvent
    {
        /// <summary>
        ///     The event type identifier, set to <see cref="EventType.TextInput"/>.
        /// </summary>
        public EventType type;

        /// <summary>
        ///     The timestamp of the event, in milliseconds, from the SDL event system.
        /// </summary>
        public uint timestamp;

        /// <summary>
        ///     The ID of the window that received the text input event.
        /// </summary>
        public uint windowID;

        /// <summary>
        ///     The first byte of the UTF-8 encoded input text buffer.
        /// </summary>
        internal byte byte0;

        /// <summary>
        ///     The second byte of the UTF-8 encoded input text buffer.
        /// </summary>
        internal byte byte1;

        /// <summary>
        ///     The third byte of the UTF-8 encoded input text buffer.
        /// </summary>
        internal byte byte2;

        /// <summary>
        ///     The fourth byte of the UTF-8 encoded input text buffer.
        /// </summary>
        internal byte byte3;

        /// <summary>
        ///     The fifth byte of the UTF-8 encoded input text buffer.
        /// </summary>
        internal byte byte4;

        /// <summary>
        ///     The sixth byte of the UTF-8 encoded input text buffer.
        /// </summary>
        internal byte byte5;

        /// <summary>
        ///     The seventh byte of the UTF-8 encoded input text buffer.
        /// </summary>
        internal byte byte6;

        /// <summary>
        ///     The eighth byte of the UTF-8 encoded input text buffer.
        /// </summary>
        internal byte byte7;

        /// <summary>
        ///     The ninth byte of the UTF-8 encoded input text buffer.
        /// </summary>
        internal byte byte8;

        /// <summary>
        ///     The tenth byte of the UTF-8 encoded input text buffer.
        /// </summary>
        internal byte byte9;

        /// <summary>
        ///     The 11th byte of the UTF-8 encoded input text buffer.
        /// </summary>
        internal byte byte10;

        /// <summary>
        ///     The 12th byte of the UTF-8 encoded input text buffer.
        /// </summary>
        internal byte byte11;

        /// <summary>
        ///     The 13th byte of the UTF-8 encoded input text buffer.
        /// </summary>
        internal byte byte12;

        /// <summary>
        ///     The 14th byte of the UTF-8 encoded input text buffer.
        /// </summary>
        internal byte byte13;

        /// <summary>
        ///     The 15th byte of the UTF-8 encoded input text buffer.
        /// </summary>
        internal byte byte14;

        /// <summary>
        ///     The 16th byte of the UTF-8 encoded input text buffer.
        /// </summary>
        internal byte byte15;

        /// <summary>
        ///     The 17th byte of the UTF-8 encoded input text buffer.
        /// </summary>
        internal byte byte16;

        /// <summary>
        ///     The 18th byte of the UTF-8 encoded input text buffer.
        /// </summary>
        internal byte byte17;

        /// <summary>
        ///     The 19th byte of the UTF-8 encoded input text buffer.
        /// </summary>
        internal byte byte18;

        /// <summary>
        ///     The 20th byte of the UTF-8 encoded input text buffer.
        /// </summary>
        internal byte byte19;

        /// <summary>
        ///     The 21st byte of the UTF-8 encoded input text buffer.
        /// </summary>
        internal byte byte20;

        /// <summary>
        ///     The 22nd byte of the UTF-8 encoded input text buffer.
        /// </summary>
        internal byte byte21;

        /// <summary>
        ///     The 23rd byte of the UTF-8 encoded input text buffer.
        /// </summary>
        internal byte byte22;

        /// <summary>
        ///     The 24th byte of the UTF-8 encoded input text buffer.
        /// </summary>
        internal byte byte23;

        /// <summary>
        ///     The 25th byte of the UTF-8 encoded input text buffer.
        /// </summary>
        internal byte byte24;

        /// <summary>
        ///     The 26th byte of the UTF-8 encoded input text buffer.
        /// </summary>
        internal byte byte25;

        /// <summary>
        ///     The 27th byte of the UTF-8 encoded input text buffer.
        /// </summary>
        internal byte byte26;

        /// <summary>
        ///     The 28th byte of the UTF-8 encoded input text buffer.
        /// </summary>
        internal byte byte27;

        /// <summary>
        ///     The 29th byte of the UTF-8 encoded input text buffer.
        /// </summary>
        internal byte byte28;

        /// <summary>
        ///     The 30th byte of the UTF-8 encoded input text buffer.
        /// </summary>
        internal byte byte29;

        /// <summary>
        ///     The 31st byte of the UTF-8 encoded input text buffer.
        /// </summary>
        internal byte byte30;

        /// <summary>
        ///     The 32nd byte of the UTF-8 encoded input text buffer.
        /// </summary>
        internal byte byte31;

        /// <summary>
        ///     Gets the 32-byte UTF-8 encoded input text as a byte array.
        /// </summary>
        public byte[] Text
        {
            get
            {
                byte[] textBytes =
                {
                    byte0,
                    byte1,
                    byte2,
                    byte3,
                    byte4,
                    byte5,
                    byte6,
                    byte7,
                    byte8,
                    byte9,
                    byte10,
                    byte11,
                    byte12,
                    byte13,
                    byte14,
                    byte15,
                    byte16,
                    byte17,
                    byte18,
                    byte19,
                    byte20,
                    byte21,
                    byte22,
                    byte23,
                    byte24,
                    byte25,
                    byte26,
                    byte27,
                    byte28,
                    byte29,
                    byte30,
                    byte31
                };

                return textBytes;
            }
        }
    }
}