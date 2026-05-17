// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SensorEventArgs.cs
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

namespace Alis.Extension.Graphic.Sfml.Windows
{
    /// <summary>
    ///     Sensor event parameters
    /// </summary>
    public class SensorEventArgs : EventArgs
    {
        /// <summary>Type of the sensor</summary>
        private Sensor.Type type;

        /// <summary>Current value of the sensor on X axis</summary>
        private float x;

        /// <summary>Current value of the sensor on Y axis</summary>
        private float y;

        /// <summary>Current value of the sensor on Z axis</summary>
        private float z;

        /// <summary>
        ///     Gets or sets the type of the sensor
        /// </summary>
        public Sensor.Type Type
        {
            get => type;
            set => type = value;
        }

        /// <summary>
        ///     Gets or sets the current value of the sensor on X axis
        /// </summary>
        public float X
        {
            get => x;
            set => x = value;
        }

        /// <summary>
        ///     Gets or sets the current value of the sensor on Y axis
        /// </summary>
        public float Y
        {
            get => y;
            set => y = value;
        }

        /// <summary>
        ///     Gets or sets the current value of the sensor on Z axis
        /// </summary>
        public float Z
        {
            get => z;
            set => z = value;
        }

        /// <summary>
        ///     Construct the sensor arguments from a sensor event
        /// </summary>
        /// <param name="e">Sensor event</param>
        public SensorEventArgs(SensorEvent e)
        {
            Type = e.Type;
            X = e.X;
            Y = e.Y;
            Z = e.Z;
        }


        /// <summary>
        ///     Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        public override string ToString() => "[SensorEventArgs]" +
                                             " Type(" + Type + ")" +
                                             " X(" + X + ")" +
                                             " Y(" + Y + ")" +
                                             " Z(" + Z + ")";
    }
}