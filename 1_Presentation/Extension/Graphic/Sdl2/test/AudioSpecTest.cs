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
using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    ///     Unit tests for the AudioSpec struct.
    /// </summary>
    public class AudioSpecTest
    {
        /// <summary>
        ///     Tests the AudioSpec struct default initialization.
        /// </summary>
        [Fact]
        public void AudioSpec_DefaultInitialization_CreatesValidStruct()
        {
            AudioSpec audioSpec = new AudioSpec();

            Assert.Equal(0, audioSpec.Freq);
            Assert.Equal(0u, audioSpec.Format);
            Assert.Equal(0, audioSpec.Channels);
            Assert.Equal(0, audioSpec.Samples);
        }

        /// <summary>
        ///     Tests setting AudioSpec properties.
        /// </summary>
        [Fact]
        public void AudioSpec_SetProperties_StoresValuesCorrectly()
        {
            AudioSpec audioSpec = new AudioSpec();

            audioSpec.Freq = 44100;
            audioSpec.Format = Sdl.AudioS16Lsb;
            audioSpec.Channels = 2;
            audioSpec.Samples = 4096;

            Assert.Equal(44100, audioSpec.Freq);
            Assert.Equal(Sdl.AudioS16Lsb, audioSpec.Format);
            Assert.Equal(2, audioSpec.Channels);
            Assert.Equal(4096, audioSpec.Samples);
        }

        /// <summary>
        ///     Tests AudioSpec with various frequency values.
        /// </summary>
        [Theory, InlineData(8000), InlineData(16000), InlineData(22050), InlineData(44100), InlineData(48000)]
        public void AudioSpec_WithDifferentFrequencies_StoresValueCorrectly(int frequency)
        {
            AudioSpec audioSpec = new AudioSpec {Freq = frequency};

            Assert.Equal(frequency, audioSpec.Freq);
        }

        /// <summary>
        ///     Tests AudioSpec with various channel counts.
        /// </summary>
        [Theory, InlineData(1), InlineData(2), InlineData(6)]
        public void AudioSpec_WithDifferentChannels_StoresValueCorrectly(byte channels)
        {
            AudioSpec audioSpec = new AudioSpec {Channels = channels};

            Assert.Equal(channels, audioSpec.Channels);
        }

        /// <summary>
        ///     Tests AudioSpec with various format values.
        /// </summary>
        [Fact]
        public void AudioSpec_WithDifferentFormats_StoresFormatCorrectly()
        {
            AudioSpec audioSpec = new AudioSpec {Format = Sdl.AudioF32Lsb};

            Assert.Equal(Sdl.AudioF32Lsb, audioSpec.Format);
        }

        /// <summary>
        ///     Tests AudioSpec userdata property.
        /// </summary>
        [Fact]
        public void AudioSpec_SetUserdata_StoresPointerCorrectly()
        {
            AudioSpec audioSpec = new AudioSpec();
            IntPtr userdata = new IntPtr(12345);

            audioSpec.Userdata = userdata;

            Assert.Equal(userdata, audioSpec.Userdata);
        }

        /// <summary>
        ///     Tests that AudioSpec is a value type (struct).
        /// </summary>
        [Fact]
        public void AudioSpec_IsValueType_CanBeCopied()
        {
            AudioSpec original = new AudioSpec {Freq = 44100, Channels = 2};

            AudioSpec copy = original;

            Assert.Equal(original.Freq, copy.Freq);
            Assert.Equal(original.Channels, copy.Channels);
        }

        /// <summary>
        ///     Tests that copying AudioSpec creates independent instances.
        /// </summary>
        [Fact]
        public void AudioSpec_CopyIsIndependent_ModifyingCopyDoesNotAffectOriginal()
        {
            AudioSpec original = new AudioSpec {Freq = 44100, Channels = 2};
            AudioSpec copy = original;

            copy.Freq = 48000;

            Assert.Equal(44100, original.Freq);
            Assert.Equal(48000, copy.Freq);
        }
    }
}