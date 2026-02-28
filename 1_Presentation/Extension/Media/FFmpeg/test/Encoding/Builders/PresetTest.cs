// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PresetTest.cs
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
using System.Collections.Generic;
using Alis.Extension.Media.FFmpeg.Encoding.Builders;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Encoding.Builders
{
    /// <summary>
    ///     The preset test class
    /// </summary>
    /// <seealso cref="Preset" />
    public class PresetTest
    {
        /// <summary>
        ///     Tests that preset ultra fast should have correct value
        /// </summary>
        [Fact]
        public void Preset_UltraFast_ShouldHaveCorrectValue()
        {
            // Arrange & Act
            Preset preset = Preset.UltraFast;

            // Assert
            Assert.Equal(0, (int) preset);
        }

        /// <summary>
        ///     Tests that preset super fast should have correct value
        /// </summary>
        [Fact]
        public void Preset_SuperFast_ShouldHaveCorrectValue()
        {
            // Arrange & Act
            Preset preset = Preset.SuperFast;

            // Assert
            Assert.Equal(1, (int) preset);
        }

        /// <summary>
        ///     Tests that preset very fast should have correct value
        /// </summary>
        [Fact]
        public void Preset_VeryFast_ShouldHaveCorrectValue()
        {
            // Arrange & Act
            Preset preset = Preset.VeryFast;

            // Assert
            Assert.Equal(2, (int) preset);
        }

        /// <summary>
        ///     Tests that preset faster should have correct value
        /// </summary>
        [Fact]
        public void Preset_Faster_ShouldHaveCorrectValue()
        {
            // Arrange & Act
            Preset preset = Preset.Faster;

            // Assert
            Assert.Equal(3, (int) preset);
        }

        /// <summary>
        ///     Tests that preset fast should have correct value
        /// </summary>
        [Fact]
        public void Preset_Fast_ShouldHaveCorrectValue()
        {
            // Arrange & Act
            Preset preset = Preset.Fast;

            // Assert
            Assert.Equal(4, (int) preset);
        }

        /// <summary>
        ///     Tests that preset medium should have correct value
        /// </summary>
        [Fact]
        public void Preset_Medium_ShouldHaveCorrectValue()
        {
            // Arrange & Act
            Preset preset = Preset.Medium;

            // Assert
            Assert.Equal(5, (int) preset);
        }

        /// <summary>
        ///     Tests that preset slow should have correct value
        /// </summary>
        [Fact]
        public void Preset_Slow_ShouldHaveCorrectValue()
        {
            // Arrange & Act
            Preset preset = Preset.Slow;

            // Assert
            Assert.Equal(6, (int) preset);
        }

        /// <summary>
        ///     Tests that preset slower should have correct value
        /// </summary>
        [Fact]
        public void Preset_Slower_ShouldHaveCorrectValue()
        {
            // Arrange & Act
            Preset preset = Preset.Slower;

            // Assert
            Assert.Equal(7, (int) preset);
        }

        /// <summary>
        ///     Tests that preset very slow should have correct value
        /// </summary>
        [Fact]
        public void Preset_VerySlow_ShouldHaveCorrectValue()
        {
            // Arrange & Act
            Preset preset = Preset.VerySlow;

            // Assert
            Assert.Equal(8, (int) preset);
        }

        /// <summary>
        ///     Tests that preset enum should have nine values
        /// </summary>
        [Fact]
        public void Preset_Enum_ShouldHaveNineValues()
        {
            // Arrange & Act
            Preset[] values = (Preset[]) Enum.GetValues(typeof(Preset));

            // Assert
            Assert.Equal(9, values.Length);
        }

        /// <summary>
        ///     Tests that preset should be convertible to string
        /// </summary>
        [Fact]
        public void Preset_ShouldBeConvertibleToString()
        {
            // Arrange
            Preset ultraFast = Preset.UltraFast;
            Preset medium = Preset.Medium;
            Preset verySlow = Preset.VerySlow;

            // Act
            string ultraFastStr = ultraFast.ToString();
            string mediumStr = medium.ToString();
            string verySlowStr = verySlow.ToString();

            // Assert
            Assert.Equal("UltraFast", ultraFastStr);
            Assert.Equal("Medium", mediumStr);
            Assert.Equal("VerySlow", verySlowStr);
        }

        /// <summary>
        ///     Tests that preset should be parseable from string
        /// </summary>
        [Fact]
        public void Preset_ShouldBeParseableFromString()
        {
            // Arrange & Act
            Preset fast = (Preset) Enum.Parse(typeof(Preset), "Fast");
            Preset slow = (Preset) Enum.Parse(typeof(Preset), "Slow");

            // Assert
            Assert.Equal(Preset.Fast, fast);
            Assert.Equal(Preset.Slow, slow);
        }

        /// <summary>
        ///     Tests that preset should support equality comparison
        /// </summary>
        [Fact]
        public void Preset_ShouldSupportEqualityComparison()
        {
            // Arrange
            Preset medium1 = Preset.Medium;
            Preset medium2 = Preset.Medium;
            Preset fast = Preset.Fast;

            // Act & Assert
            Assert.Equal(medium1, medium2);
            Assert.NotEqual(medium1, fast);
        }

        /// <summary>
        ///     Tests that preset to lower invariant should work correctly
        /// </summary>
        [Fact]
        public void Preset_ToLowerInvariant_ShouldWorkCorrectly()
        {
            // Arrange
            Preset ultraFast = Preset.UltraFast;
            Preset medium = Preset.Medium;
            Preset verySlow = Preset.VerySlow;

            // Act
            string ultraFastLower = ultraFast.ToString().ToLowerInvariant();
            string mediumLower = medium.ToString().ToLowerInvariant();
            string verySlowLower = verySlow.ToString().ToLowerInvariant();

            // Assert
            Assert.Equal("ultrafast", ultraFastLower);
            Assert.Equal("medium", mediumLower);
            Assert.Equal("veryslow", verySlowLower);
        }

        /// <summary>
        ///     Tests that preset all values should be defined
        /// </summary>
        [Fact]
        public void Preset_AllValues_ShouldBeDefined()
        {
            // Arrange & Act & Assert
            Assert.True(Enum.IsDefined(typeof(Preset), Preset.UltraFast));
            Assert.True(Enum.IsDefined(typeof(Preset), Preset.SuperFast));
            Assert.True(Enum.IsDefined(typeof(Preset), Preset.VeryFast));
            Assert.True(Enum.IsDefined(typeof(Preset), Preset.Faster));
            Assert.True(Enum.IsDefined(typeof(Preset), Preset.Fast));
            Assert.True(Enum.IsDefined(typeof(Preset), Preset.Medium));
            Assert.True(Enum.IsDefined(typeof(Preset), Preset.Slow));
            Assert.True(Enum.IsDefined(typeof(Preset), Preset.Slower));
            Assert.True(Enum.IsDefined(typeof(Preset), Preset.VerySlow));
        }

        /// <summary>
        ///     Tests that preset should have unique values
        /// </summary>
        [Fact]
        public void Preset_ShouldHaveUniqueValues()
        {
            // Arrange
            int[] values = new[]
            {
                (int) Preset.UltraFast,
                (int) Preset.SuperFast,
                (int) Preset.VeryFast,
                (int) Preset.Faster,
                (int) Preset.Fast,
                (int) Preset.Medium,
                (int) Preset.Slow,
                (int) Preset.Slower,
                (int) Preset.VerySlow
            };

            // Act & Assert
            Assert.Equal(values.Length, new HashSet<int>(values).Count);
        }

        /// <summary>
        ///     Tests that preset should be castable to int
        /// </summary>
        [Fact]
        public void Preset_ShouldBeCastableToInt()
        {
            // Arrange
            Preset preset = Preset.Medium;

            // Act
            int value = (int) preset;

            // Assert
            Assert.Equal(5, value);
        }

        /// <summary>
        ///     Tests that preset should be castable from int
        /// </summary>
        [Fact]
        public void Preset_ShouldBeCastableFromInt()
        {
            // Arrange
            int value = 4;

            // Act
            Preset preset = (Preset) value;

            // Assert
            Assert.Equal(Preset.Fast, preset);
        }

        /// <summary>
        ///     Tests that preset should be usable in arrays
        /// </summary>
        [Fact]
        public void Preset_ShouldBeUsableInArrays()
        {
            // Arrange
            Preset[] presets = new[] {Preset.Fast, Preset.Medium, Preset.Slow};

            // Act & Assert
            Assert.Equal(3, presets.Length);
            Assert.Equal(Preset.Fast, presets[0]);
            Assert.Equal(Preset.Medium, presets[1]);
            Assert.Equal(Preset.Slow, presets[2]);
        }
    }
}