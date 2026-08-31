// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioSpecCoverageTests.cs
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
using Alis.Extension.Graphic.Sdl2.Delegates;
using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    ///     The audio spec coverage tests class
    /// </summary>
    public class AudioSpecCoverageTests
    {
        /// <summary>
        ///     Tests that setters and getters for frequency work correctly
        /// </summary>
        [Fact]
        public void AudioSpec_Freq_SetAndGetValue()
        {
            AudioSpec audioSpec = new AudioSpec { Freq = 44100 };
            Assert.Equal(44100, audioSpec.Freq);
        }

        /// <summary>
        ///     Tests that setters and getters for format work correctly
        /// </summary>
        [Fact]
        public void AudioSpec_Format_SetAndGetValue()
        {
            AudioSpec audioSpec = new AudioSpec { Format = 0x8010 };
            Assert.Equal(0x8010, audioSpec.Format);
        }

        /// <summary>
        ///     Tests that setters and getters for channels work correctly
        /// </summary>
        [Fact]
        public void AudioSpec_Channels_SetAndGetValue()
        {
            AudioSpec audioSpec = new AudioSpec { Channels = 2 };
            Assert.Equal(2, audioSpec.Channels);
        }

        /// <summary>
        ///     Tests that setters and getters for samples work correctly
        /// </summary>
        [Fact]
        public void AudioSpec_Samples_SetAndGetValue()
        {
            AudioSpec audioSpec = new AudioSpec { Samples = 4096 };
            Assert.Equal(4096, audioSpec.Samples);
        }

        /// <summary>
        ///     Tests that setters and getters for callback work correctly
        /// </summary>
        [Fact]
        public void AudioSpec_Callback_SetAndGetValue()
        {
            SdlAudioCallback callback = (userdata, stream, length) => { };
            AudioSpec audioSpec = new AudioSpec { Callback = callback };
            Assert.Same(callback, audioSpec.Callback);
        }

        /// <summary>
        ///     Tests that setters and getters for userdata work correctly
        /// </summary>
        [Fact]
        public void AudioSpec_Userdata_SetAndGetValue()
        {
            IntPtr userdata = new IntPtr(12345);
            AudioSpec audioSpec = new AudioSpec { Userdata = userdata };
            Assert.Equal(userdata, audioSpec.Userdata);
        }

        /// <summary>
        ///     Tests that readonly silence field defaults to zero
        /// </summary>
        [Fact]
        public void AudioSpec_ReadonlySilence_DefaultToZero()
        {
            AudioSpec audioSpec = default(AudioSpec);
            Assert.Equal(0, audioSpec.silence);
        }

        /// <summary>
        ///     Tests that readonly size field defaults to zero
        /// </summary>
        [Fact]
        public void AudioSpec_ReadonlySize_DefaultToZero()
        {
            AudioSpec audioSpec = default(AudioSpec);
            Assert.Equal(0u, audioSpec.size);
        }

        /// <summary>
        ///     Tests that value type copy is independent
        /// </summary>
        [Fact]
        public void AudioSpec_IsValueType_CopyIsIndependent()
        {
            AudioSpec original = new AudioSpec { Freq = 44100, Channels = 2 };
            AudioSpec copy = original;
            copy.Freq = 48000;
            Assert.Equal(44100, original.Freq);
            Assert.Equal(48000, copy.Freq);
        }

        /// <summary>
        ///     Tests that all properties can be assigned together
        /// </summary>
        [Fact]
        public void AudioSpec_AssignAllProperties_StoresValues()
        {
            SdlAudioCallback callback = (userdata, stream, length) => { };
            AudioSpec audioSpec = new AudioSpec
            {
                Freq = 22050,
                Format = 0x0004,
                Channels = 1,
                Samples = 512,
                Callback = callback,
                Userdata = new IntPtr(1)
            };

            Assert.Equal(22050, audioSpec.Freq);
            Assert.Equal(0x0004, audioSpec.Format);
            Assert.Equal(1, audioSpec.Channels);
            Assert.Equal(512, audioSpec.Samples);
            Assert.Same(callback, audioSpec.Callback);
            Assert.Equal(new IntPtr(1), audioSpec.Userdata);
        }
    }
}
