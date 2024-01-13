// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: SdlJoyButtonEvent.cs
// 
//  Author: Pablo Perdomo Falcón
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
    ///     The sdl joy button event
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlJoyButtonEvent
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
        ///     The which
        /// </summary>
        public readonly int which; 

        /// <summary>
        ///     The button
        /// </summary>
        public readonly byte button;

        /// <summary>
        ///     The state
        /// </summary>
        public readonly byte state;

        /// <summary>
        ///     The padding
        /// </summary>
        private readonly byte padding1;

        /// <summary>
        ///     The padding
        /// </summary>
        private readonly byte padding2;
    }
}