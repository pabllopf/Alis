// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SensorEvent.cs
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
    ///     Represents an SDL sensor event, fired when a sensor (e.g. accelerometer, gyroscope) updates its data.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SensorEvent
    {
        /// <summary>
        ///     The event type identifier, set to <see cref="EventType.SensorUpdate"/>.
        /// </summary>
        public readonly EventType type;

        /// <summary>
        ///     The timestamp of the event, in milliseconds, from the SDL event system.
        /// </summary>
        public readonly uint timestamp;

        /// <summary>
        ///     The SDL sensor instance ID that generated the event.
        /// </summary>
        public readonly int which;

        /// <summary>
        ///     The first sensor data value (e.g. X-axis acceleration).
        /// </summary>
        public readonly float float0;

        /// <summary>
        ///     The second sensor data value (e.g. Y-axis acceleration).
        /// </summary>
        public readonly float float1;

        /// <summary>
        ///     The third sensor data value (e.g. Z-axis acceleration).
        /// </summary>
        public readonly float float2;

        /// <summary>
        ///     The fourth sensor data value (e.g. X-axis gyroscope).
        /// </summary>
        public readonly float float3;

        /// <summary>
        ///     The fifth sensor data value (e.g. Y-axis gyroscope).
        /// </summary>
        public readonly float float4;

        /// <summary>
        ///     The sixth sensor data value (e.g. Z-axis gyroscope or additional sensor data).
        /// </summary>
        public readonly float float5;
    }
}