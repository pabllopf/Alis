// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PluralizationEngineTest.cs
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
using Xunit;

namespace Alis.Extension.Language.Translator.Test
{
    /// <summary>
    ///     Tests for the PluralizationEngine class
    /// </summary>
    public class PluralizationEngineTest
    {
        /// <summary>
        ///     Tests that English pluralization returns singular form for 1
        /// </summary>
        [Fact]
        public void GetPluralForm_EnglishWithOne_ShouldReturnSingular()
        {
            // Arrange
            var engine = new PluralizationEngine();

            // Act
            int form = engine.GetPluralForm("en", 1);

            // Assert
            Assert.Equal(0, form);
        }

        /// <summary>
        ///     Tests that English pluralization returns plural form for other quantities
        /// </summary>
        [Theory]
        [InlineData(0)]
        [InlineData(2)]
        [InlineData(5)]
        [InlineData(100)]
        public void GetPluralForm_EnglishWithMultiple_ShouldReturnPlural(int quantity)
        {
            // Arrange
            var engine = new PluralizationEngine();

            // Act
            int form = engine.GetPluralForm("en", quantity);

            // Assert
            Assert.Equal(1, form);
        }

        /// <summary>
        ///     Tests that Spanish pluralization works correctly
        /// </summary>
        [Theory]
        [InlineData(1, 0)]
        [InlineData(2, 1)]
        [InlineData(0, 1)]
        public void GetPluralForm_Spanish_ShouldWorkCorrectly(int quantity, int expected)
        {
            // Arrange
            var engine = new PluralizationEngine();

            // Act
            int form = engine.GetPluralForm("es", quantity);

            // Assert
            Assert.Equal(expected, form);
        }

        /// <summary>
        ///     Tests that Russian pluralization returns correct forms
        /// </summary>
        [Theory]
        [InlineData(1, 0)]      // Singular
        [InlineData(21, 0)]     // Singular (ends with 1)
        [InlineData(2, 1)]      // Few
        [InlineData(5, 2)]      // Many
        [InlineData(0, 2)]      // Many
        public void GetPluralForm_Russian_ShouldReturnCorrectForm(int quantity, int expected)
        {
            // Arrange
            var engine = new PluralizationEngine();

            // Act
            int form = engine.GetPluralForm("ru", quantity);

            // Assert
            Assert.Equal(expected, form);
        }

        /// <summary>
        ///     Tests that Japanese has no pluralization
        /// </summary>
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(100)]
        public void GetPluralForm_Japanese_ShouldAlwaysReturnZero(int quantity)
        {
            // Arrange
            var engine = new PluralizationEngine();

            // Act
            int form = engine.GetPluralForm("ja", quantity);

            // Assert
            Assert.Equal(0, form);
        }

        /// <summary>
        ///     Tests that RegisterPluralizationRule adds custom rule
        /// </summary>
        [Fact]
        public void RegisterPluralizationRule_WithCustomRule_ShouldUseCustomRule()
        {
            // Arrange
            var engine = new PluralizationEngine();
            Func<int, int> customRule = q => q % 2 == 0 ? 0 : 1;

            // Act
            engine.RegisterPluralizationRule("custom", customRule);
            int form = engine.GetPluralForm("custom", 4);

            // Assert
            Assert.Equal(0, form);
        }

        /// <summary>
        ///     Tests that RegisterPluralizationRule with null rule throws exception
        /// </summary>
        [Fact]
        public void RegisterPluralizationRule_WithNullRule_ShouldThrowException()
        {
            // Arrange
            var engine = new PluralizationEngine();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => engine.RegisterPluralizationRule("test", null));
        }

        /// <summary>
        ///     Tests that GetPluralFormCount returns correct counts
        /// </summary>
        [Theory]
        [InlineData("en", 2)]
        [InlineData("es", 2)]
        [InlineData("ru", 3)]
        [InlineData("ja", 1)]
        public void GetPluralFormCount_ShouldReturnCorrectCount(string languageCode, int expectedCount)
        {
            // Arrange
            var engine = new PluralizationEngine();

            // Act
            int count = engine.GetPluralFormCount(languageCode);

            // Assert
            Assert.Equal(expectedCount, count);
        }

        /// <summary>
        ///     Tests that GetPluralForm with null language code throws exception
        /// </summary>
        [Fact]
        public void GetPluralForm_WithNullLanguageCode_ShouldThrowException()
        {
            // Arrange
            var engine = new PluralizationEngine();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => engine.GetPluralForm(null, 1));
        }
    }
}

