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

using Alis.Core.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Core.Graphic.Test.Sdl2.Structs
{
    /// <summary>
    ///     The audio device event test class
    /// </summary>
    public class AudioDeviceEventTest
    {
        /// <summary>
        ///     Tests that audio device event initializes properties correctly
        /// </summary>
        [Fact]
        public void AudioDeviceEvent_InitializesPropertiesCorrectly()
        {
            AudioDeviceEvent audioDeviceEvent = new AudioDeviceEvent
            {
                type = 1,
                timestamp = 100,
                which = 2,
                isCapture = 1
            };

            Assert.Equal(1u, audioDeviceEvent.type);
            Assert.Equal(100u, audioDeviceEvent.timestamp);
            Assert.Equal(2u, audioDeviceEvent.which);
            Assert.Equal(1, audioDeviceEvent.isCapture);
        }
    }
}