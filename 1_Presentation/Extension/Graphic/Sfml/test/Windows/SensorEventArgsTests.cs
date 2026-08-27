// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SensorEventArgsTests.cs
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
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    ///     Tests for SensorEventArgs.
    /// </summary>
    public class SensorEventArgsTests
    {
        /// <summary>
        ///     Tests that constructor sets type from sensor event
        /// </summary>
        [Fact]
        public void Constructor_SetsTypeFromEvent()
        {
            SensorEvent e = new SensorEvent { Type = Sensor.Type.Gyroscope };

            SensorEventArgs args = new SensorEventArgs(e);

            Assert.Equal(Sensor.Type.Gyroscope, args.Type);
        }

        /// <summary>
        ///     Tests that constructor sets x from sensor event
        /// </summary>
        [Fact]
        public void Constructor_SetsXFromEvent()
        {
            SensorEvent e = new SensorEvent { X = 1.5f };

            SensorEventArgs args = new SensorEventArgs(e);

            Assert.Equal(1.5f, args.X);
        }

        /// <summary>
        ///     Tests that constructor sets y from sensor event
        /// </summary>
        [Fact]
        public void Constructor_SetsYFromEvent()
        {
            SensorEvent e = new SensorEvent { Y = -2.5f };

            SensorEventArgs args = new SensorEventArgs(e);

            Assert.Equal(-2.5f, args.Y);
        }

        /// <summary>
        ///     Tests that constructor sets z from sensor event
        /// </summary>
        [Fact]
        public void Constructor_SetsZFromEvent()
        {
            SensorEvent e = new SensorEvent { Z = 3.75f };

            SensorEventArgs args = new SensorEventArgs(e);

            Assert.Equal(3.75f, args.Z);
        }

        /// <summary>
        ///     Tests that default sensor event produces default arguments
        /// </summary>
        [Fact]
        public void DefaultEvent_ProducesDefaultArgs()
        {
            SensorEventArgs args = new SensorEventArgs(new SensorEvent());

            Assert.Equal(default, args.Type);
            Assert.Equal(0.0f, args.X);
            Assert.Equal(0.0f, args.Y);
            Assert.Equal(0.0f, args.Z);
        }

        /// <summary>
        ///     Tests that properties get and set values
        /// </summary>
        [Fact]
        public void Properties_GetAndSetValues()
        {
            SensorEventArgs args = new SensorEventArgs(new SensorEvent());

            args.Type = Sensor.Type.Magnetometer;
            args.X = 4.0f;
            args.Y = 5.0f;
            args.Z = 6.0f;

            Assert.Equal(Sensor.Type.Magnetometer, args.Type);
            Assert.Equal(4.0f, args.X);
            Assert.Equal(5.0f, args.Y);
            Assert.Equal(6.0f, args.Z);
        }

        /// <summary>
        ///     Tests that sensor event args inherits from event args
        /// </summary>
        [Fact]
        public void SensorEventArgs_InheritsFromEventArgs()
        {
            SensorEventArgs args = new SensorEventArgs(new SensorEvent());

            Assert.IsAssignableFrom<EventArgs>(args);
        }

        /// <summary>
        ///     Tests that to string returns expected format
        /// </summary>
        [Fact]
        public void ToString_ReturnsExpectedFormat()
        {
            SensorEvent e = new SensorEvent { Type = Sensor.Type.Accelerometer, X = 1.0f, Y = 2.0f, Z = 3.0f };
            SensorEventArgs args = new SensorEventArgs(e);

            string str = args.ToString();

            Assert.Contains("[SensorEventArgs]", str);
            Assert.Contains("Type(Accelerometer)", str);
            Assert.Contains("X(1)", str);
            Assert.Contains("Y(2)", str);
            Assert.Contains("Z(3)", str);
        }
    }
}
