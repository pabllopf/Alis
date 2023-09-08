// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlControllerAxisEvent.cs
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
    ///     The sdl controller axis event
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlControllerAxisEvent
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
        ///     The which SDL_JoystickID
        /// </summary>
        public readonly int which;

        /// <summary>
        ///     The axis
        /// </summary>
        public readonly byte axis;

        /// <summary>
        ///     The padding
        /// </summary>
        private readonly byte padding1;

        /// <summary>
        ///     The padding
        /// </summary>
        private readonly byte padding2;

        /// <summary>
        ///     The padding
        /// </summary>
        private readonly byte padding3;

        /// <summary>
        ///     The axis value
        /// </summary>
        public readonly short axisValue;

        /// <summary>
        ///     The padding
        /// </summary>
        private readonly ushort padding4;
    }
}