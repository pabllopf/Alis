// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioSpecTest.cs
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
using System.Diagnostics.CodeAnalysis;
using Alis.Core.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Core.Graphic.Test.Sdl2.Structs
{
    /// <summary>
    ///     The audio spec test class
    /// </summary>
    	  
	 public class AudioSpecTest 
    {
        /// <summary>
        ///     Tests that constructor initializes properties correctly
        /// </summary>
        [Fact]
        public void Constructor_InitializesPropertiesCorrectly()
        {
            AudioSpec audioSpec = new AudioSpec
            {
                Freq = 44100,
                Format = 32784,
                Channels = 2,
                Samples = 512,
                Callback = null,
                Userdata = IntPtr.Zero
            };

            Assert.Equal(44100, audioSpec.Freq);
            Assert.Equal((ushort) 32784, audioSpec.Format);
            Assert.Equal((byte) 2, audioSpec.Channels);
            Assert.Equal((ushort) 512, audioSpec.Samples);
            Assert.Null(audioSpec.Callback);
            Assert.Equal(IntPtr.Zero, audioSpec.Userdata);
        }

        /// <summary>
        ///     Tests that properties set values correctly
        /// </summary>
        /// <param name="freq">The freq</param>
        /// <param name="format">The format</param>
        /// <param name="channels">The channels</param>
        /// <param name="samples">The samples</param>
        [Theory, InlineData(22050, 32779, 1, 256), InlineData(88200, 32785, 2, 1024)]
        public void Properties_SetValuesCorrectly(int freq, ushort format, byte channels, ushort samples)
        {
            AudioSpec audioSpec = new AudioSpec
            {
                Freq = freq,
                Format = format,
                Channels = channels,
                Samples = samples,
                Callback = null,
                Userdata = IntPtr.Zero
            };

            Assert.Equal(freq, audioSpec.Freq);
            Assert.Equal(format, audioSpec.Format);
            Assert.Equal(channels, audioSpec.Channels);
            Assert.Equal(samples, audioSpec.Samples);
            Assert.Null(audioSpec.Callback);
            Assert.Equal(IntPtr.Zero, audioSpec.Userdata);
        }
    }
}