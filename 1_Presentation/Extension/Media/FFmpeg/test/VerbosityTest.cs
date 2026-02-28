// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VerbosityTest.cs
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
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test
{
    /// <summary>
    ///     The verbosity test class
    /// </summary>
    /// <seealso cref="Verbosity" />
    public class VerbosityTest
    {
        /// <summary>
        ///     Tests that verbosity quiet should have correct value
        /// </summary>
        [Fact]
        public void Verbosity_Quiet_ShouldHaveCorrectValue()
        {
            // Arrange & Act
            Verbosity verbosity = Verbosity.Quiet;

            // Assert
            Assert.Equal(0, (int) verbosity);
        }

        /// <summary>
        ///     Tests that verbosity info should have correct value
        /// </summary>
        [Fact]
        public void Verbosity_Info_ShouldHaveCorrectValue()
        {
            // Arrange & Act
            Verbosity verbosity = Verbosity.Info;

            // Assert
            Assert.Equal(1, (int) verbosity);
        }

        /// <summary>
        ///     Tests that verbosity verbose should have correct value
        /// </summary>
        [Fact]
        public void Verbosity_Verbose_ShouldHaveCorrectValue()
        {
            // Arrange & Act
            Verbosity verbosity = Verbosity.Verbose;

            // Assert
            Assert.Equal(2, (int) verbosity);
        }

        /// <summary>
        ///     Tests that verbosity debug should have correct value
        /// </summary>
        [Fact]
        public void Verbosity_Debug_ShouldHaveCorrectValue()
        {
            // Arrange & Act
            Verbosity verbosity = Verbosity.Debug;

            // Assert
            Assert.Equal(3, (int) verbosity);
        }

        /// <summary>
        ///     Tests that verbosity warning should have correct value
        /// </summary>
        [Fact]
        public void Verbosity_Warning_ShouldHaveCorrectValue()
        {
            // Arrange & Act
            Verbosity verbosity = Verbosity.Warning;

            // Assert
            Assert.Equal(4, (int) verbosity);
        }

        /// <summary>
        ///     Tests that verbosity error should have correct value
        /// </summary>
        [Fact]
        public void Verbosity_Error_ShouldHaveCorrectValue()
        {
            // Arrange & Act
            Verbosity verbosity = Verbosity.Error;

            // Assert
            Assert.Equal(5, (int) verbosity);
        }

        /// <summary>
        ///     Tests that verbosity fatal should have correct value
        /// </summary>
        [Fact]
        public void Verbosity_Fatal_ShouldHaveCorrectValue()
        {
            // Arrange & Act
            Verbosity verbosity = Verbosity.Fatal;

            // Assert
            Assert.Equal(6, (int) verbosity);
        }

        /// <summary>
        ///     Tests that verbosity enum should have seven values
        /// </summary>
        [Fact]
        public void Verbosity_Enum_ShouldHaveSevenValues()
        {
            // Arrange & Act
            Verbosity[] values = (Verbosity[]) Enum.GetValues(typeof(Verbosity));

            // Assert
            Assert.Equal(7, values.Length);
        }

        /// <summary>
        ///     Tests that verbosity should be convertible to string
        /// </summary>
        [Fact]
        public void Verbosity_ShouldBeConvertibleToString()
        {
            // Arrange
            Verbosity quiet = Verbosity.Quiet;
            Verbosity info = Verbosity.Info;
            Verbosity debug = Verbosity.Debug;

            // Act
            string quietStr = quiet.ToString();
            string infoStr = info.ToString();
            string debugStr = debug.ToString();

            // Assert
            Assert.Equal("Quiet", quietStr);
            Assert.Equal("Info", infoStr);
            Assert.Equal("Debug", debugStr);
        }

        /// <summary>
        ///     Tests that verbosity should be parseable from string
        /// </summary>
        [Fact]
        public void Verbosity_ShouldBeParseableFromString()
        {
            // Arrange & Act
            Verbosity quiet = (Verbosity) Enum.Parse(typeof(Verbosity), "Quiet");
            Verbosity error = (Verbosity) Enum.Parse(typeof(Verbosity), "Error");
            Verbosity fatal = (Verbosity) Enum.Parse(typeof(Verbosity), "Fatal");

            // Assert
            Assert.Equal(Verbosity.Quiet, quiet);
            Assert.Equal(Verbosity.Error, error);
            Assert.Equal(Verbosity.Fatal, fatal);
        }

        /// <summary>
        ///     Tests that verbosity should support equality comparison
        /// </summary>
        [Fact]
        public void Verbosity_ShouldSupportEqualityComparison()
        {
            // Arrange
            Verbosity info1 = Verbosity.Info;
            Verbosity info2 = Verbosity.Info;
            Verbosity debug = Verbosity.Debug;

            // Act & Assert
            Assert.Equal(info1, info2);
            Assert.NotEqual(info1, debug);
        }

        /// <summary>
        ///     Tests that verbosity should be usable in switch statement
        /// </summary>
        [Fact]
        public void Verbosity_ShouldBeUsableInSwitchStatement()
        {
            // Arrange
            Verbosity verbosity = Verbosity.Warning;
            string result = string.Empty;

            // Act
            switch (verbosity)
            {
                case Verbosity.Quiet:
                    result = "Quiet";
                    break;
                case Verbosity.Info:
                    result = "Info";
                    break;
                case Verbosity.Verbose:
                    result = "Verbose";
                    break;
                case Verbosity.Debug:
                    result = "Debug";
                    break;
                case Verbosity.Warning:
                    result = "Warning";
                    break;
                case Verbosity.Error:
                    result = "Error";
                    break;
                case Verbosity.Fatal:
                    result = "Fatal";
                    break;
            }

            // Assert
            Assert.Equal("Warning", result);
        }

        /// <summary>
        ///     Tests that verbosity all values should be defined
        /// </summary>
        [Fact]
        public void Verbosity_AllValues_ShouldBeDefined()
        {
            // Arrange & Act & Assert
            Assert.True(Enum.IsDefined(typeof(Verbosity), Verbosity.Quiet));
            Assert.True(Enum.IsDefined(typeof(Verbosity), Verbosity.Info));
            Assert.True(Enum.IsDefined(typeof(Verbosity), Verbosity.Verbose));
            Assert.True(Enum.IsDefined(typeof(Verbosity), Verbosity.Debug));
            Assert.True(Enum.IsDefined(typeof(Verbosity), Verbosity.Warning));
            Assert.True(Enum.IsDefined(typeof(Verbosity), Verbosity.Error));
            Assert.True(Enum.IsDefined(typeof(Verbosity), Verbosity.Fatal));
        }

        /// <summary>
        ///     Tests that verbosity should have unique values
        /// </summary>
        [Fact]
        public void Verbosity_ShouldHaveUniqueValues()
        {
            // Arrange
            int[] values = new[]
            {
                (int) Verbosity.Quiet,
                (int) Verbosity.Info,
                (int) Verbosity.Verbose,
                (int) Verbosity.Debug,
                (int) Verbosity.Warning,
                (int) Verbosity.Error,
                (int) Verbosity.Fatal
            };

            // Act & Assert
            Assert.Equal(values.Length, new HashSet<int>(values).Count);
        }

        /// <summary>
        ///     Tests that verbosity should be castable to int
        /// </summary>
        [Fact]
        public void Verbosity_ShouldBeCastableToInt()
        {
            // Arrange
            Verbosity verbosity = Verbosity.Error;

            // Act
            int value = (int) verbosity;

            // Assert
            Assert.Equal(5, value);
        }

        /// <summary>
        ///     Tests that verbosity should be castable from int
        /// </summary>
        [Fact]
        public void Verbosity_ShouldBeCastableFromInt()
        {
            // Arrange
            int value = 3;

            // Act
            Verbosity verbosity = (Verbosity) value;

            // Assert
            Assert.Equal(Verbosity.Debug, verbosity);
        }

        /// <summary>
        ///     Tests that verbosity to lower invariant should work correctly
        /// </summary>
        [Fact]
        public void Verbosity_ToLowerInvariant_ShouldWorkCorrectly()
        {
            // Arrange
            Verbosity quiet = Verbosity.Quiet;
            Verbosity info = Verbosity.Info;
            Verbosity fatal = Verbosity.Fatal;

            // Act
            string quietLower = quiet.ToString().ToLowerInvariant();
            string infoLower = info.ToString().ToLowerInvariant();
            string fatalLower = fatal.ToString().ToLowerInvariant();

            // Assert
            Assert.Equal("quiet", quietLower);
            Assert.Equal("info", infoLower);
            Assert.Equal("fatal", fatalLower);
        }
    }
}