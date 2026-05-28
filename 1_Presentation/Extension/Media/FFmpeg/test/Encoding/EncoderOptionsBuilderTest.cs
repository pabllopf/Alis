// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EncoderOptionsBuilderTest.cs
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

using Alis.Extension.Media.FFmpeg.Encoding;
using Alis.Extension.Media.FFmpeg.Encoding.Builders;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Encoding
{
    /// <summary>
    ///     The encoder options builder test class
    /// </summary>
    /// <seealso cref="EncoderOptions" />
    public class EncoderOptionsBuilderTest
    {
        /// <summary>
        ///     Tests that encoder options builder format property should be settable
        /// </summary>
        [Fact]
        public void EncoderOptionsBuilder_FormatProperty_ShouldBeSettable()
        {
            H264Encoder encoder = new H264Encoder();
            string format = "mkv";

            encoder.Format = format;

            Assert.Equal(format, encoder.Format);
        }

        /// <summary>
        ///     Tests that encoder options builder name property should be readable
        /// </summary>
        [Fact]
        public void EncoderOptionsBuilder_NameProperty_ShouldBeReadable()
        {
            H264Encoder encoder = new H264Encoder();

            string name = encoder.Name;

            Assert.NotNull(name);
            Assert.NotEmpty(name);
        }

        /// <summary>
        ///     Tests that encoder options builder create method should return options
        /// </summary>
        [Fact]
        public void EncoderOptionsBuilder_CreateMethod_ShouldReturnOptions()
        {
            H264Encoder encoder = new H264Encoder();

            EncoderOptions options = encoder.Create();

            Assert.NotNull(options);
            Assert.IsAssignableFrom<EncoderOptions>(options);
        }

        /// <summary>
        ///     Tests that encoder options builder create should include format
        /// </summary>
        [Fact]
        public void EncoderOptionsBuilder_Create_ShouldIncludeFormat()
        {
            H264Encoder encoder = new H264Encoder();
            encoder.Format = "mp4";

            EncoderOptions options = encoder.Create();

            Assert.Equal("mp4", options.Format);
        }

        /// <summary>
        ///     Tests that encoder options builder create should include encoder name
        /// </summary>
        [Fact]
        public void EncoderOptionsBuilder_Create_ShouldIncludeEncoderName()
        {
            H264Encoder encoder = new H264Encoder();

            EncoderOptions options = encoder.Create();

            Assert.Equal("libx264", options.EncoderName);
        }

        /// <summary>
        ///     Tests that encoder options builder create should include encoder arguments
        /// </summary>
        [Fact]
        public void EncoderOptionsBuilder_Create_ShouldIncludeEncoderArguments()
        {
            H264Encoder encoder = new H264Encoder();

            EncoderOptions options = encoder.Create();

            Assert.NotNull(options.EncoderArguments);
            Assert.NotEmpty(options.EncoderArguments);
        }

        /// <summary>
        ///     Tests that different encoder builders should have different names
        /// </summary>
        [Fact]
        public void EncoderOptionsBuilder_DifferentEncoders_ShouldHaveDifferentNames()
        {
            H264Encoder h264 = new H264Encoder();
            Mp3Encoder mp3 = new Mp3Encoder();
            Vp9Encoder vp9 = new Vp9Encoder();

            string h264Name = h264.Name;
            string mp3Name = mp3.Name;
            string vp9Name = vp9.Name;

            Assert.NotEqual(h264Name, mp3Name);
            Assert.NotEqual(mp3Name, vp9Name);
            Assert.NotEqual(h264Name, vp9Name);
        }

        /// <summary>
        ///     Tests that different encoder builders should have different formats
        /// </summary>
        [Fact]
        public void EncoderOptionsBuilder_DifferentEncoders_ShouldHaveDifferentDefaultFormats()
        {
            H264Encoder h264 = new H264Encoder();
            Mp3Encoder mp3 = new Mp3Encoder();
            Vp9Encoder vp9 = new Vp9Encoder();

            string h264Format = h264.Format;
            string mp3Format = mp3.Format;
            string vp9Format = vp9.Format;

            Assert.Equal("mp4", h264Format);
            Assert.Equal("mp3", mp3Format);
            Assert.Equal("webm", vp9Format);
        }

        /// <summary>
        ///     Tests that encoder options builder should create valid encoder options
        /// </summary>
        [Fact]
        public void EncoderOptionsBuilder_ShouldCreateValidEncoderOptions()
        {
            H264Encoder encoder = new H264Encoder();

            EncoderOptions options = encoder.Create();

            Assert.NotNull(options.Format);
            Assert.NotNull(options.EncoderName);
            Assert.NotNull(options.EncoderArguments);
            Assert.NotEmpty(options.Format);
            Assert.NotEmpty(options.EncoderName);
            Assert.NotEmpty(options.EncoderArguments);
        }

        /// <summary>
        ///     Tests that encoder options builder format should be mutable before create
        /// </summary>
        [Fact]
        public void EncoderOptionsBuilder_FormatShouldBeMutableBeforeCreate()
        {
            H264Encoder encoder = new H264Encoder();
            string originalFormat = encoder.Format;

            encoder.Format = "mkv";
            EncoderOptions options = encoder.Create();

            Assert.NotEqual(originalFormat, "mkv");
            Assert.Equal("mkv", options.Format);
        }

        /// <summary>
        ///     Tests that encoder options builder should support multiple calls to create
        /// </summary>
        [Fact]
        public void EncoderOptionsBuilder_ShouldSupportMultipleCallsToCreate()
        {
            H264Encoder encoder = new H264Encoder();

            EncoderOptions options1 = encoder.Create();
            EncoderOptions options2 = encoder.Create();
            EncoderOptions options3 = encoder.Create();

            Assert.NotNull(options1);
            Assert.NotNull(options2);
            Assert.NotNull(options3);
        }

        /// <summary>
        ///     Tests that encoder options builder mp 3 encoder should create mp 3 options
        /// </summary>
        [Fact]
        public void EncoderOptionsBuilder_Mp3Encoder_ShouldCreateMp3Options()
        {
            Mp3Encoder encoder = new Mp3Encoder();

            EncoderOptions options = encoder.Create();

            Assert.Equal("mp3", options.Format);
            Assert.Equal("libmp3lame", options.EncoderName);
        }

        /// <summary>
        ///     Tests that encoder options builder vp 9 encoder should create vp 9 options
        /// </summary>
        [Fact]
        public void EncoderOptionsBuilder_Vp9Encoder_ShouldCreateVp9Options()
        {
            Vp9Encoder encoder = new Vp9Encoder();

            EncoderOptions options = encoder.Create();

            Assert.Equal("webm", options.Format);
            Assert.Equal("libvpx-vp9", options.EncoderName);
        }
    }
}