// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ControllerSensorEventTest.cs
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

using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    /// The controller sensor event test class
    /// </summary>
    public class ControllerSensorEventTest
    {
        /// <summary>
        /// Tests that controller sensor event default initialization fields have default values
        /// </summary>
        [Fact]
        public void ControllerSensorEvent_DefaultInitialization_FieldsHaveDefaultValues()
        {
            ControllerSensorEvent ev = new ControllerSensorEvent();

            Assert.Equal(0u, ev.type);
            Assert.Equal(0u, ev.timestamp);
            Assert.Equal(0, ev.which);
            Assert.Equal(0, ev.sensor);
            Assert.Equal(0f, ev.data1);
            Assert.Equal(0f, ev.data2);
            Assert.Equal(0f, ev.data3);
        }

        /// <summary>
        /// Tests that controller sensor event is value type copy is independent
        /// </summary>
        [Fact]
        public void ControllerSensorEvent_IsValueType_CopyIsIndependent()
        {
            ControllerSensorEvent original = new ControllerSensorEvent();
            ControllerSensorEvent copy = original;

            Assert.Equal(original.type, copy.type);
            Assert.Equal(original.timestamp, copy.timestamp);
            Assert.Equal(original.which, copy.which);
            Assert.Equal(original.sensor, copy.sensor);
            Assert.Equal(original.data1, copy.data1);
        }
    }
}
