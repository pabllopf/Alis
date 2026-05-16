// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ControllerSensorEvent.cs
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
    ///     Represents an SDL controller sensor event, fired when a game controller's built-in sensor (e.g. accelerometer, gyroscope) updates.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ControllerSensorEvent
    {
        /// <summary>
        ///     The event type identifier, set to <see cref="EventType.ControllerSensorUpdate"/>.
        /// </summary>
        public readonly uint type;

        /// <summary>
        ///     The timestamp of the event, in milliseconds, from the SDL event system.
        /// </summary>
        public readonly uint timestamp;

        /// <summary>
        ///     The SDL joystick instance ID for the controller that generated the sensor event.
        /// </summary>
        public readonly int which;

        /// <summary>
        ///     The sensor type index (e.g. SDL_SENSOR_ACCEL, SDL_SENSOR_GYRO).
        /// </summary>
        public readonly int sensor;

        /// <summary>
        ///     The first component of the sensor data vector (e.g. X-axis for accelerometer).
        /// </summary>
        public readonly float data1;

        /// <summary>
        ///     The second component of the sensor data vector (e.g. Y-axis for accelerometer).
        /// </summary>
        public readonly float data2;

        /// <summary>
        ///     The third component of the sensor data vector (e.g. Z-axis for accelerometer).
        /// </summary>
        public readonly float data3;
    }
}