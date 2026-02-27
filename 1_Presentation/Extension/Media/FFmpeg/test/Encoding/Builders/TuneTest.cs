// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TuneTest.cs
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

using Alis.Extension.Media.FFmpeg.Encoding.Builders;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Encoding.Builders
{
    /// <summary>
    ///     The tune test class
    /// </summary>
    /// <seealso cref="Tune" />
    public class TuneTest
    {
        /// <summary>
        ///     Tests that tune auto should have correct value
        /// </summary>
        [Fact]
        public void Tune_Auto_ShouldHaveCorrectValue()
        {
            // Arrange & Act
            Tune tune = Tune.Auto;

            // Assert
            Assert.Equal(0, (int)tune);
        }

        /// <summary>
        ///     Tests that tune film should have correct value
        /// </summary>
        [Fact]
        public void Tune_Film_ShouldHaveCorrectValue()
        {
            // Arrange & Act
            Tune tune = Tune.Film;

            // Assert
            Assert.Equal(1, (int)tune);
        }

        /// <summary>
        ///     Tests that tune animation should have correct value
        /// </summary>
        [Fact]
        public void Tune_Animation_ShouldHaveCorrectValue()
        {
            // Arrange & Act
            Tune tune = Tune.Animation;

            // Assert
            Assert.Equal(2, (int)tune);
        }

        /// <summary>
        ///     Tests that tune grain should have correct value
        /// </summary>
        [Fact]
        public void Tune_Grain_ShouldHaveCorrectValue()
        {
            // Arrange & Act
            Tune tune = Tune.Grain;

            // Assert
            Assert.Equal(3, (int)tune);
        }

        /// <summary>
        ///     Tests that tune still image should have correct value
        /// </summary>
        [Fact]
        public void Tune_StillImage_ShouldHaveCorrectValue()
        {
            // Arrange & Act
            Tune tune = Tune.StillImage;

            // Assert
            Assert.Equal(4, (int)tune);
        }

        /// <summary>
        ///     Tests that tune fast decode should have correct value
        /// </summary>
        [Fact]
        public void Tune_FastDecode_ShouldHaveCorrectValue()
        {
            // Arrange & Act
            Tune tune = Tune.FastDecode;

            // Assert
            Assert.Equal(5, (int)tune);
        }

        /// <summary>
        ///     Tests that tune zero latency should have correct value
        /// </summary>
        [Fact]
        public void Tune_ZeroLatency_ShouldHaveCorrectValue()
        {
            // Arrange & Act
            Tune tune = Tune.ZeroLatency;

            // Assert
            Assert.Equal(6, (int)tune);
        }

        /// <summary>
        ///     Tests that tune enum should have seven values
        /// </summary>
        [Fact]
        public void Tune_Enum_ShouldHaveSevenValues()
        {
            // Arrange & Act
            Tune[] values = (Tune[])System.Enum.GetValues(typeof(Tune));

            // Assert
            Assert.Equal(7, values.Length);
        }

        /// <summary>
        ///     Tests that tune should be convertible to string
        /// </summary>
        [Fact]
        public void Tune_ShouldBeConvertibleToString()
        {
            // Arrange
            Tune auto = Tune.Auto;
            Tune film = Tune.Film;
            Tune animation = Tune.Animation;

            // Act
            string autoStr = auto.ToString();
            string filmStr = film.ToString();
            string animationStr = animation.ToString();

            // Assert
            Assert.Equal("Auto", autoStr);
            Assert.Equal("Film", filmStr);
            Assert.Equal("Animation", animationStr);
        }

        /// <summary>
        ///     Tests that tune should be parseable from string
        /// </summary>
        [Fact]
        public void Tune_ShouldBeParseableFromString()
        {
            // Arrange & Act
            Tune grain = (Tune)System.Enum.Parse(typeof(Tune), "Grain");
            Tune zeroLatency = (Tune)System.Enum.Parse(typeof(Tune), "ZeroLatency");

            // Assert
            Assert.Equal(Tune.Grain, grain);
            Assert.Equal(Tune.ZeroLatency, zeroLatency);
        }

        /// <summary>
        ///     Tests that tune should support equality comparison
        /// </summary>
        [Fact]
        public void Tune_ShouldSupportEqualityComparison()
        {
            // Arrange
            Tune film1 = Tune.Film;
            Tune film2 = Tune.Film;
            Tune grain = Tune.Grain;

            // Act & Assert
            Assert.Equal(film1, film2);
            Assert.NotEqual(film1, grain);
        }

        /// <summary>
        ///     Tests that tune to lower invariant should work correctly
        /// </summary>
        [Fact]
        public void Tune_ToLowerInvariant_ShouldWorkCorrectly()
        {
            // Arrange
            Tune auto = Tune.Auto;
            Tune stillImage = Tune.StillImage;
            Tune fastDecode = Tune.FastDecode;

            // Act
            string autoLower = auto.ToString().ToLowerInvariant();
            string stillImageLower = stillImage.ToString().ToLowerInvariant();
            string fastDecodeLower = fastDecode.ToString().ToLowerInvariant();

            // Assert
            Assert.Equal("auto", autoLower);
            Assert.Equal("stillimage", stillImageLower);
            Assert.Equal("fastdecode", fastDecodeLower);
        }

        /// <summary>
        ///     Tests that tune all values should be defined
        /// </summary>
        [Fact]
        public void Tune_AllValues_ShouldBeDefined()
        {
            // Arrange & Act & Assert
            Assert.True(System.Enum.IsDefined(typeof(Tune), Tune.Auto));
            Assert.True(System.Enum.IsDefined(typeof(Tune), Tune.Film));
            Assert.True(System.Enum.IsDefined(typeof(Tune), Tune.Animation));
            Assert.True(System.Enum.IsDefined(typeof(Tune), Tune.Grain));
            Assert.True(System.Enum.IsDefined(typeof(Tune), Tune.StillImage));
            Assert.True(System.Enum.IsDefined(typeof(Tune), Tune.FastDecode));
            Assert.True(System.Enum.IsDefined(typeof(Tune), Tune.ZeroLatency));
        }

        /// <summary>
        ///     Tests that tune should have unique values
        /// </summary>
        [Fact]
        public void Tune_ShouldHaveUniqueValues()
        {
            // Arrange
            int[] values = new int[]
            {
                (int)Tune.Auto,
                (int)Tune.Film,
                (int)Tune.Animation,
                (int)Tune.Grain,
                (int)Tune.StillImage,
                (int)Tune.FastDecode,
                (int)Tune.ZeroLatency
            };

            // Act & Assert
            Assert.Equal(values.Length, new System.Collections.Generic.HashSet<int>(values).Count);
        }

        /// <summary>
        ///     Tests that tune should be castable to int
        /// </summary>
        [Fact]
        public void Tune_ShouldBeCastableToInt()
        {
            // Arrange
            Tune tune = Tune.Animation;

            // Act
            int value = (int)tune;

            // Assert
            Assert.Equal(2, value);
        }

        /// <summary>
        ///     Tests that tune should be castable from int
        /// </summary>
        [Fact]
        public void Tune_ShouldBeCastableFromInt()
        {
            // Arrange
            int value = 5;

            // Act
            Tune tune = (Tune)value;

            // Assert
            Assert.Equal(Tune.FastDecode, tune);
        }

        /// <summary>
        ///     Tests that tune should be usable in switch statement
        /// </summary>
        [Fact]
        public void Tune_ShouldBeUsableInSwitchStatement()
        {
            // Arrange
            Tune tune = Tune.Film;
            string result = string.Empty;

            // Act
            switch (tune)
            {
                case Tune.Auto:
                    result = "Auto";
                    break;
                case Tune.Film:
                    result = "Film";
                    break;
                case Tune.Animation:
                    result = "Animation";
                    break;
                case Tune.Grain:
                    result = "Grain";
                    break;
                case Tune.StillImage:
                    result = "StillImage";
                    break;
                case Tune.FastDecode:
                    result = "FastDecode";
                    break;
                case Tune.ZeroLatency:
                    result = "ZeroLatency";
                    break;
            }

            // Assert
            Assert.Equal("Film", result);
        }
    }
}

