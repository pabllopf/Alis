// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EncoderOptionsRemainingCoverageTests.cs
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
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Encoding
{
    /// <summary>
    ///     Remaining coverage tests for the <see cref="EncoderOptions" /> POCO.
    /// </summary>
    public class EncoderOptionsRemainingCoverageTests
    {
        /// <summary>
        ///     Verifies that the constructor creates a non-null instance.
        /// </summary>
        [Fact]
        public void Constructor_CreatesNonNullInstance()
        {
            EncoderOptions opts = new EncoderOptions();
            Assert.NotNull(opts);
        }

        /// <summary>
        ///     Verifies that the Format property round-trips a value.
        /// </summary>
        [Fact]
        public void Format_RoundTrip()
        {
            EncoderOptions opts = new EncoderOptions();
            opts.Format = "mp4";
            Assert.Equal("mp4", opts.Format);
        }

        /// <summary>
        ///     Verifies that the EncoderName property round-trips a value.
        /// </summary>
        [Fact]
        public void EncoderName_RoundTrip()
        {
            EncoderOptions opts = new EncoderOptions();
            opts.EncoderName = "libx264";
            Assert.Equal("libx264", opts.EncoderName);
        }

        /// <summary>
        ///     Verifies that the EncoderArguments property round-trips a value.
        /// </summary>
        [Fact]
        public void EncoderArguments_RoundTrip()
        {
            EncoderOptions opts = new EncoderOptions();
            opts.EncoderArguments = "-preset fast";
            Assert.Equal("-preset fast", opts.EncoderArguments);
        }

        /// <summary>
        ///     Verifies that all default property values are null.
        /// </summary>
        [Fact]
        public void DefaultValues_AreNull()
        {
            EncoderOptions opts = new EncoderOptions();
            Assert.Null(opts.Format);
            Assert.Null(opts.EncoderName);
            Assert.Null(opts.EncoderArguments);
        }

        /// <summary>
        ///     Verifies that all properties round-trip when set together.
        /// </summary>
        [Fact]
        public void AllProperties_SetTogether_RoundTrip()
        {
            EncoderOptions opts = new EncoderOptions();
            opts.Format = "webm";
            opts.EncoderName = "libvpx";
            opts.EncoderArguments = "-crf 23";
            Assert.Equal("webm", opts.Format);
            Assert.Equal("libvpx", opts.EncoderName);
            Assert.Equal("-crf 23", opts.EncoderArguments);
        }
    }
}