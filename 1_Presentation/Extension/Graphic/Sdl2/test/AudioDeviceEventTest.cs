// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioDeviceEventTest.cs
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
    /// The audio device event test class
    /// </summary>
    public class AudioDeviceEventTest
    {
        /// <summary>
        /// Tests that audio device event default initialization fields have default values
        /// </summary>
        [Fact]
        public void AudioDeviceEvent_DefaultInitialization_FieldsHaveDefaultValues()
        {
            AudioDeviceEvent ev = new AudioDeviceEvent();

            Assert.Equal(0u, ev.type);
            Assert.Equal(0u, ev.timestamp);
            Assert.Equal(0u, ev.which);
            Assert.Equal(0, ev.isCapture);
        }

        /// <summary>
        /// Tests that audio device event set fields stores values correctly
        /// </summary>
        [Fact]
        public void AudioDeviceEvent_SetFields_StoresValuesCorrectly()
        {
            AudioDeviceEvent ev = new AudioDeviceEvent
            {
                type = 1u,
                timestamp = 100u,
                which = 2u,
                isCapture = 1
            };

            Assert.Equal(1u, ev.type);
            Assert.Equal(100u, ev.timestamp);
            Assert.Equal(2u, ev.which);
            Assert.Equal(1, ev.isCapture);
        }

        /// <summary>
        /// Tests that audio device event is value type copy is independent
        /// </summary>
        [Fact]
        public void AudioDeviceEvent_IsValueType_CopyIsIndependent()
        {
            AudioDeviceEvent original = new AudioDeviceEvent { type = 1u, which = 2u };
            AudioDeviceEvent copy = original;

            copy.type = 99u;

            Assert.Equal(1u, original.type);
            Assert.Equal(99u, copy.type);
        }

        /// <summary>
        /// Tests that audio device event with zero capture sets is capture to zero
        /// </summary>
        [Fact]
        public void AudioDeviceEvent_WithZeroCapture_SetsIsCaptureToZero()
        {
            AudioDeviceEvent ev = new AudioDeviceEvent { isCapture = 0 };

            Assert.Equal(0, ev.isCapture);
        }

        /// <summary>
        /// Tests that audio device event with max values stores correctly
        /// </summary>
        [Fact]
        public void AudioDeviceEvent_WithMaxValues_StoresCorrectly()
        {
            AudioDeviceEvent ev = new AudioDeviceEvent
            {
                type = uint.MaxValue,
                timestamp = uint.MaxValue,
                which = uint.MaxValue,
                isCapture = byte.MaxValue
            };

            Assert.Equal(uint.MaxValue, ev.type);
            Assert.Equal(uint.MaxValue, ev.timestamp);
            Assert.Equal(uint.MaxValue, ev.which);
            Assert.Equal(byte.MaxValue, ev.isCapture);
        }
    }
}
