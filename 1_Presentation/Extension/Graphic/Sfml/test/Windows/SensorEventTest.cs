// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SensorEventTest.cs
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

using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    public class SensorEventTest
    {
        [Fact]
        public void SensorEvent_Default_HasZeroValues()
        {
            SensorEvent e = new SensorEvent();
            Assert.Equal(default(Sensor.Type), e.Type);
            Assert.Equal(0.0f, e.X);
            Assert.Equal(0.0f, e.Y);
            Assert.Equal(0.0f, e.Z);
        }

        [Fact]
        public void SensorEventArgs_Constructor_SetsProperties()
        {
            SensorEvent e = new SensorEvent { Type = Sensor.Type.Gyroscope, X = 1.0f, Y = 2.0f, Z = 3.0f };
            SensorEventArgs args = new SensorEventArgs(e);
            Assert.Equal(Sensor.Type.Gyroscope, args.Type);
            Assert.Equal(1.0f, args.X);
            Assert.Equal(2.0f, args.Y);
            Assert.Equal(3.0f, args.Z);
        }

        [Fact]
        public void SensorEventArgs_ToString_IncludesPropertyNames()
        {
            SensorEvent e = new SensorEvent { Type = Sensor.Type.Accelerometer };
            SensorEventArgs args = new SensorEventArgs(e);
            Assert.Contains("Type", args.ToString());
            Assert.Contains("X", args.ToString());
            Assert.Contains("Y", args.ToString());
            Assert.Contains("Z", args.ToString());
        }
    }
}
