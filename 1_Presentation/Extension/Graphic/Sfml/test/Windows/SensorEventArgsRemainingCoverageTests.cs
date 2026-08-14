// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SensorEventArgsRemainingCoverageTests.cs
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

using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    ///     The sensor event args remaining coverage tests class
    /// </summary>
    public class SensorEventArgsRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that constructor assigns values from event
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Constructor_AssignsValuesFromEvent()
        {
            SensorEvent sensorEvent = new SensorEvent
            {
                Type = Sensor.Type.Accelerometer,
                X = 1.0f,
                Y = 2.0f,
                Z = 3.0f
            };

            SensorEventArgs args = new SensorEventArgs(sensorEvent);

            Assert.Equal(Sensor.Type.Accelerometer, args.Type);
            Assert.Equal(1.0f, args.X);
            Assert.Equal(2.0f, args.Y);
            Assert.Equal(3.0f, args.Z);
        }

        /// <summary>
        ///     Tests that properties get and set values
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Properties_GetAndSetValues()
        {
            SensorEventArgs args = new SensorEventArgs(new SensorEvent());

            args.Type = Sensor.Type.Gyroscope;
            args.X = 4.0f;
            args.Y = 5.0f;
            args.Z = 6.0f;

            Assert.Equal(Sensor.Type.Gyroscope, args.Type);
            Assert.Equal(4.0f, args.X);
            Assert.Equal(5.0f, args.Y);
            Assert.Equal(6.0f, args.Z);
        }

        /// <summary>
        ///     Tests that to string returns expected format
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void ToString_ReturnsExpectedFormat()
        {
            SensorEvent sensorEvent = new SensorEvent
            {
                Type = Sensor.Type.Accelerometer,
                X = 1,
                Y = 2,
                Z = 3
            };
            SensorEventArgs args = new SensorEventArgs(sensorEvent);

            string str = args.ToString();

            Assert.Contains("[SensorEventArgs]", str);
            Assert.Contains("Type(Accelerometer)", str);
            Assert.Contains("X(1)", str);
            Assert.Contains("Y(2)", str);
            Assert.Contains("Z(3)", str);
        }
    }
}
