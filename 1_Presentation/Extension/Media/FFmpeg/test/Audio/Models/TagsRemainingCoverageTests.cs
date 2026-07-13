// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TagsRemainingCoverageTests.cs
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

using Alis.Extension.Media.FFmpeg.Audio.Models;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Audio.Models
{
    /// <summary>
    ///     The tags remaining coverage tests class
    /// </summary>
    public class TagsRemainingCoverageTests
    {
        /// <summary>
        ///     Verifies that the constructor creates a non-null instance
        /// </summary>
        [Fact]
        public void Constructor_CreatesNonNullInstance()
        {
            Tags tags = new Tags();

            Assert.NotNull(tags);
        }

        /// <summary>
        ///     Verifies that the Encoder property round-trips a value
        /// </summary>
        [Fact]
        public void Encoder_RoundTrip()
        {
            Tags tags = new Tags();
            tags.Encoder = "Lavf58.29.100";

            Assert.Equal("Lavf58.29.100", tags.Encoder);
        }

        /// <summary>
        ///     Verifies that the Encoder property defaults to null
        /// </summary>
        [Fact]
        public void Encoder_DefaultIsNull()
        {
            Tags tags = new Tags();

            Assert.Null(tags.Encoder);
        }

        /// <summary>
        ///     Verifies that the Encoder property accepts null
        /// </summary>
        [Fact]
        public void Encoder_AcceptNull()
        {
            Tags tags = new Tags();
            tags.Encoder = null;

            Assert.Null(tags.Encoder);
        }

        /// <summary>
        ///     Verifies that the Encoder property accepts empty string
        /// </summary>
        [Fact]
        public void Encoder_AcceptEmptyString()
        {
            Tags tags = new Tags();
            tags.Encoder = string.Empty;

            Assert.Equal(string.Empty, tags.Encoder);
        }

        /// <summary>
        ///     Verifies that the Encoder property accepts whitespace
        /// </summary>
        [Fact]
        public void Encoder_AcceptWhitespace()
        {
            Tags tags = new Tags();
            tags.Encoder = "   ";

            Assert.Equal("   ", tags.Encoder);
        }

        /// <summary>
        ///     Verifies that the Encoder property accepts special characters
        /// </summary>
        [Fact]
        public void Encoder_AcceptSpecialCharacters()
        {
            Tags tags = new Tags();
            tags.Encoder = "!@#$%^&*()_+-=[]{}|;':\",./<>?`~";

            Assert.Equal("!@#$%^&*()_+-=[]{}|;':\",./<>?`~", tags.Encoder);
        }

        /// <summary>
        ///     Verifies that the Encoder property accepts a very long string
        /// </summary>
        [Fact]
        public void Encoder_AcceptVeryLongString()
        {
            Tags tags = new Tags();
            string longString = new string('A', 10000);
            tags.Encoder = longString;

            Assert.Equal(longString, tags.Encoder);
        }

        /// <summary>
        ///     Verifies that the Encoder property accepts Unicode characters
        /// </summary>
        [Fact]
        public void Encoder_AcceptUnicodeCharacters()
        {
            Tags tags = new Tags();
            tags.Encoder = "编码器测试 エンコーダ 테스트";

            Assert.Equal("编码器测试 エンコーダ 테스트", tags.Encoder);
        }

        /// <summary>
        ///     Verifies that initializer syntax sets the Encoder property
        /// </summary>
        [Fact]
        public void Initializer_SetsEncoder()
        {
            Tags tags = new Tags { Encoder = "Lavf59.27.100" };

            Assert.Equal("Lavf59.27.100", tags.Encoder);
        }

        /// <summary>
        ///     Verifies that the Encoder property is mutable after construction
        /// </summary>
        [Fact]
        public void Encoder_IsMutable()
        {
            Tags tags = new Tags { Encoder = "Lavf58.29.100" };
            tags.Encoder = "Lavf59.27.100";

            Assert.Equal("Lavf59.27.100", tags.Encoder);
        }

        /// <summary>
        ///     Verifies that multiple instances have independent Encoder values
        /// </summary>
        [Fact]
        public void MultipleInstances_IndependentEncoderValues()
        {
            Tags tags1 = new Tags { Encoder = "EncoderA" };
            Tags tags2 = new Tags { Encoder = "EncoderB" };

            Assert.Equal("EncoderA", tags1.Encoder);
            Assert.Equal("EncoderB", tags2.Encoder);

            tags1.Encoder = "EncoderC";

            Assert.Equal("EncoderC", tags1.Encoder);
            Assert.Equal("EncoderB", tags2.Encoder);
        }

        /// <summary>
        ///     Verifies that setting Encoder to null after having a value works
        /// </summary>
        [Fact]
        public void Encoder_SetToNull_AfterValue()
        {
            Tags tags = new Tags { Encoder = "Lavf58.29.100" };

            tags.Encoder = null;

            Assert.Null(tags.Encoder);
        }

        /// <summary>
        ///     Verifies that setting Encoder to empty string after having a value works
        /// </summary>
        [Fact]
        public void Encoder_SetToEmpty_AfterValue()
        {
            Tags tags = new Tags { Encoder = "Lavf58.29.100" };

            tags.Encoder = string.Empty;

            Assert.Equal(string.Empty, tags.Encoder);
        }
    }
}
