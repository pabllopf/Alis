// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioMetadataTests.cs
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
using System.Threading.Tasks;
using Alis.Extension.FFMeg.Audio;
using Alis.Extension.FFMeg.Test.Assets;
using Xunit;

namespace Alis.Extension.FFMeg.Test
{
    /// <summary>
    ///     The audio metadata tests class
    /// </summary>
    public class AudioMetadataTests
    {
        /// <summary>
        ///     Tests that load metadata mp 3
        /// </summary>
        [Fact]
        public async Task LoadMetadataMp3()
        {
            AudioReader audio = new AudioReader(Res.GetPath(Res.Audio_Mp3));

            await audio.LoadMetadataAsync();

            Assert.True(audio.Metadata.Codec == "mp3");
            Assert.True(audio.Metadata.BitRate == 128000);
            Assert.True(audio.Metadata.SampleFormat == "fltp");
            Assert.True(audio.Metadata.SampleRate == 44100);
            Assert.True(audio.Metadata.Channels == 2);
            Assert.True(audio.Metadata.Streams.Length == 1);
            Assert.True(Math.Abs(audio.Metadata.Duration - 1.549187) < 0.01);
        }

        /// <summary>
        ///     Tests that load metadata ogg
        /// </summary>
        [Fact]
        public async Task LoadMetadataOgg()
        {
            AudioReader audio = new AudioReader(Res.GetPath(Res.Audio_Ogg));

            await audio.LoadMetadataAsync();

            Assert.True(audio.Metadata.Codec == "vorbis");
            Assert.True(audio.Metadata.BitRate == 48000);
            Assert.True(audio.Metadata.SampleFormat == "fltp");
            Assert.True(audio.Metadata.SampleRate == 11025);
            Assert.True(audio.Metadata.Channels == 2);
            Assert.True(audio.Metadata.Streams.Length == 1);
            Assert.True(Math.Abs(audio.Metadata.Duration - 1.515102) < 0.01);
        }
    }
}