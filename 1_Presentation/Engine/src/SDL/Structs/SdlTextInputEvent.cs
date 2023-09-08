// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlTextInputEvent.cs
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
using Alis.App.Engine.SDL.Enums;

namespace Alis.App.Engine.SDL.Structs
{
    /// <summary>
    ///     The sdl textinputevent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlTextInputEvent
    {
        /// <summary>
        ///     The type
        /// </summary>
        public readonly SdlEventType type;

        /// <summary>
        ///     The timestamp
        /// </summary>
        public readonly uint timestamp;

        /// <summary>
        ///     The window id
        /// </summary>
        public readonly uint windowID;

        /// <summary>
        ///     The byte
        /// </summary>
        private readonly byte byte0;

        /// <summary>
        ///     The byte
        /// </summary>
        private readonly byte byte1;

        /// <summary>
        ///     The byte
        /// </summary>
        private readonly byte byte2;

        /// <summary>
        ///     The byte
        /// </summary>
        private readonly byte byte3;

        /// <summary>
        ///     The byte
        /// </summary>
        private readonly byte byte4;

        /// <summary>
        ///     The byte
        /// </summary>
        private readonly byte byte5;

        /// <summary>
        ///     The byte
        /// </summary>
        private readonly byte byte6;

        /// <summary>
        ///     The byte
        /// </summary>
        private readonly byte byte7;

        /// <summary>
        ///     The byte
        /// </summary>
        private readonly byte byte8;

        /// <summary>
        ///     The byte
        /// </summary>
        private readonly byte byte9;

        /// <summary>
        ///     The byte 10
        /// </summary>
        private readonly byte byte10;

        /// <summary>
        ///     The byte 11
        /// </summary>
        private readonly byte byte11;

        /// <summary>
        ///     The byte 12
        /// </summary>
        private readonly byte byte12;

        /// <summary>
        ///     The byte 13
        /// </summary>
        private readonly byte byte13;

        /// <summary>
        ///     The byte 14
        /// </summary>
        private readonly byte byte14;

        /// <summary>
        ///     The byte 15
        /// </summary>
        private readonly byte byte15;

        /// <summary>
        ///     The byte 16
        /// </summary>
        private readonly byte byte16;

        /// <summary>
        ///     The byte 17
        /// </summary>
        private readonly byte byte17;

        /// <summary>
        ///     The byte 18
        /// </summary>
        private readonly byte byte18;

        /// <summary>
        ///     The byte 19
        /// </summary>
        private readonly byte byte19;

        /// <summary>
        ///     The byte 20
        /// </summary>
        private readonly byte byte20;

        /// <summary>
        ///     The byte 21
        /// </summary>
        private readonly byte byte21;

        /// <summary>
        ///     The byte 22
        /// </summary>
        private readonly byte byte22;

        /// <summary>
        ///     The byte 23
        /// </summary>
        private readonly byte byte23;

        /// <summary>
        ///     The byte 24
        /// </summary>
        private readonly byte byte24;

        /// <summary>
        ///     The byte 25
        /// </summary>
        private readonly byte byte25;

        /// <summary>
        ///     The byte 26
        /// </summary>
        private readonly byte byte26;

        /// <summary>
        ///     The byte 27
        /// </summary>
        private readonly byte byte27;

        /// <summary>
        ///     The byte 28
        /// </summary>
        private readonly byte byte28;

        /// <summary>
        ///     The byte 29
        /// </summary>
        private readonly byte byte29;

        /// <summary>
        ///     The byte 30
        /// </summary>
        private readonly byte byte30;

        /// <summary>
        ///     The byte 31
        /// </summary>
        private readonly byte byte31;

        /// <summary>
        ///     Gets or sets the value of the text
        /// </summary>
        public byte[] Text
        {
            get
            {
                byte[] textBytes = new byte[32]
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