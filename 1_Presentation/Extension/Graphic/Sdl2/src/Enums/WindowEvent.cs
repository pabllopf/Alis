// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WindowEvent.cs
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

namespace Alis.Extension.Graphic.Sdl2.Enums
{
    /// <summary>
    ///     The sdl window event
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct WindowEvent
    {
        /// <summary>
        ///     The type
        /// </summary>
        public readonly EventType type;

        /// <summary>
        ///     The timestamp
        /// </summary>
        public readonly uint timestamp;

        /// <summary>
        ///     The window id
        /// </summary>
        public readonly uint windowID;

        /// <summary>
        ///     The window event
        /// </summary>
        public readonly WindowEventId windowEvent;

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
        ///     The data
        /// </summary>
        public readonly int data1;

        /// <summary>
        ///     The data
        /// </summary>
        public readonly int data2;
    }
}