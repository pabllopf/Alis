// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DollarGestureEventTest.cs
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
    /// The dollar gesture event test class
    /// </summary>
    public class DollarGestureEventTest
    {
        /// <summary>
        /// Tests that dollar gesture event default initialization fields have default values
        /// </summary>
        [Fact]
        public void DollarGestureEvent_DefaultInitialization_FieldsHaveDefaultValues()
        {
            DollarGestureEvent ev = new DollarGestureEvent();

            Assert.Equal(0u, ev.type);
            Assert.Equal(0u, ev.timestamp);
            Assert.Equal(0L, ev.touchId);
            Assert.Equal(0L, ev.gestureId);
            Assert.Equal(0u, ev.numFingers);
            Assert.Equal(0f, ev.error);
            Assert.Equal(0f, ev.x);
            Assert.Equal(0f, ev.y);
        }

        /// <summary>
        /// Tests that dollar gesture event set fields stores values correctly
        /// </summary>
        [Fact]
        public void DollarGestureEvent_SetFields_StoresValuesCorrectly()
        {
            DollarGestureEvent ev = new DollarGestureEvent
            {
                type = 1u,
                timestamp = 100u,
                touchId = 12345L,
                gestureId = 67890L,
                numFingers = 3u,
                error = 0.1f,
                x = 200f,
                y = 150f
            };

            Assert.Equal(1u, ev.type);
            Assert.Equal(100u, ev.timestamp);
            Assert.Equal(12345L, ev.touchId);
            Assert.Equal(67890L, ev.gestureId);
            Assert.Equal(3u, ev.numFingers);
            Assert.Equal(0.1f, ev.error);
            Assert.Equal(200f, ev.x);
            Assert.Equal(150f, ev.y);
        }

        /// <summary>
        /// Tests that dollar gesture event is value type copy is independent
        /// </summary>
        [Fact]
        public void DollarGestureEvent_IsValueType_CopyIsIndependent()
        {
            DollarGestureEvent original = new DollarGestureEvent { touchId = 999L, gestureId = 888L };
            DollarGestureEvent copy = original;

            copy.touchId = 111L;

            Assert.Equal(999L, original.touchId);
            Assert.Equal(111L, copy.touchId);
        }
    }
}
