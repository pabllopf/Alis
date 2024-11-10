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
using Alis.Core.Graphic.Sdl2.Enums;

namespace Alis.Core.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The sdl text input event
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TextInputEvent
    {
        /// <summary>
        ///     The type
        /// </summary>
        public EventType type;
        
        /// <summary>
        ///     The timestamp
        /// </summary>
        public uint timestamp;
        
        /// <summary>
        ///     The window id
        /// </summary>
        public uint windowID;
        
        /// <summary>
        ///     The byte
        /// </summary>
        internal byte byte0;
        
        /// <summary>
        ///     The byte
        /// </summary>
        internal byte byte1;
        
        /// <summary>
        ///     The byte
        /// </summary>
        internal byte byte2;
        
        /// <summary>
        ///     The byte
        /// </summary>
        internal byte byte3;
        
        /// <summary>
        ///     The byte
        /// </summary>
        internal byte byte4;
        
        /// <summary>
        ///     The byte
        /// </summary>
        internal byte byte5;
        
        /// <summary>
        ///     The byte
        /// </summary>
        internal byte byte6;
        
        /// <summary>
        ///     The byte
        /// </summary>
        internal byte byte7;
        
        /// <summary>
        ///     The byte
        /// </summary>
        internal byte byte8;
        
        /// <summary>
        ///     The byte
        /// </summary>
        internal byte byte9;
        
        /// <summary>
        ///     The byte 10
        /// </summary>
        internal byte byte10;
        
        /// <summary>
        ///     The byte 11
        /// </summary>
        internal byte byte11;
        
        /// <summary>
        ///     The byte 12
        /// </summary>
        internal byte byte12;
        
        /// <summary>
        ///     The byte 13
        /// </summary>
        internal byte byte13;
        
        /// <summary>
        ///     The byte 14
        /// </summary>
        internal byte byte14;
        
        /// <summary>
        ///     The byte 15
        /// </summary>
        internal byte byte15;
        
        /// <summary>
        ///     The byte 16
        /// </summary>
        internal byte byte16;
        
        /// <summary>
        ///     The byte 17
        /// </summary>
        internal byte byte17;
        
        /// <summary>
        ///     The byte 18
        /// </summary>
        internal byte byte18;
        
        /// <summary>
        ///     The byte 19
        /// </summary>
        internal byte byte19;
        
        /// <summary>
        ///     The byte 20
        /// </summary>
        internal byte byte20;
        
        /// <summary>
        ///     The byte 21
        /// </summary>
        internal byte byte21;
        
        /// <summary>
        ///     The byte 22
        /// </summary>
        internal byte byte22;
        
        /// <summary>
        ///     The byte 23
        /// </summary>
        internal byte byte23;
        
        /// <summary>
        ///     The byte 24
        /// </summary>
        internal byte byte24;
        
        /// <summary>
        ///     The byte 25
        /// </summary>
        internal byte byte25;
        
        /// <summary>
        ///     The byte 26
        /// </summary>
        internal byte byte26;
        
        /// <summary>
        ///     The byte 27
        /// </summary>
        internal byte byte27;
        
        /// <summary>
        ///     The byte 28
        /// </summary>
        internal byte byte28;
        
        /// <summary>
        ///     The byte 29
        /// </summary>
        internal byte byte29;
        
        /// <summary>
        ///     The byte 30
        /// </summary>
        internal byte byte30;
        
        /// <summary>
        ///     The byte 31
        /// </summary>
        internal byte byte31;
        
        /// <summary>
        ///     Gets or sets the value of the text
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