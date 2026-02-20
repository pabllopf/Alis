// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:LanguageProviderTest.cs
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
    ///     Tests for the LanguageProvider class
    /// </summary>
    public class LanguageProviderTest
    {
        /// <summary>
        ///     Tests that AddLanguage with valid language should add language successfully
        /// </summary>
        [Fact]
        public void AddLanguage_WithValidLanguage_ShouldAddLanguageSuccessfully()
        {
            // Arrange
            var provider = new LanguageProvider();
            var language = new Lang("en", "English");

            // Act
            provider.AddLanguage(language);

            // Assert
            Assert.Single(provider.GetAvailableLanguages());
            Assert.Contains(language, provider.GetAvailableLanguages());
        }

        /// <summary>
        ///     Tests that AddLanguage with null language should throw exception
        /// </summary>
        [Fact]
        public void AddLanguage_WithNullLanguage_ShouldThrowException()
        {
            // Arrange
            var provider = new LanguageProvider();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => provider.AddLanguage(null));
        }

        /// <summary>
        ///     Tests that AddLanguage with duplicate language code should throw exception
        /// </summary>
        [Fact]
        public void AddLanguage_WithDuplicateLanguageCode_ShouldThrowException()
        {
            // Arrange
            var provider = new LanguageProvider();
            var language1 = new Lang("en", "English");
            var language2 = new Lang("en", "English Language");

            // Act
            provider.AddLanguage(language1);

            // Assert
            Assert.Throws<InvalidOperationException>(() => provider.AddLanguage(language2));
        }

        /// <summary>
        ///     Tests that RemoveLanguage with existing language should remove successfully
        /// </summary>
        [Fact]
        public void RemoveLanguage_WithExistingLanguage_ShouldRemoveSuccessfully()
        {
            // Arrange
            var provider = new LanguageProvider();
            var language = new Lang("en", "English");
            provider.AddLanguage(language);

            // Act
            bool result = provider.RemoveLanguage("en");

            // Assert
            Assert.True(result);
            Assert.Empty(provider.GetAvailableLanguages());
        }

        /// <summary>
        ///     Tests that RemoveLanguage with non-existing language should return false
        /// </summary>
        [Fact]
        public void RemoveLanguage_WithNonExistingLanguage_ShouldReturnFalse()
        {
            // Arrange
            var provider = new LanguageProvider();

            // Act
            bool result = provider.RemoveLanguage("en");

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that GetLanguageByCode with existing language should return language
        /// </summary>
        [Fact]
        public void GetLanguageByCode_WithExistingLanguage_ShouldReturnLanguage()
        {
            // Arrange
            var provider = new LanguageProvider();
            var language = new Lang("en", "English");
            provider.AddLanguage(language);

            // Act
            var result = provider.GetLanguageByCode("en");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(language, result);
        }

        /// <summary>
        ///     Tests that GetLanguageByCode with non-existing language should return null
        /// </summary>
        [Fact]
        public void GetLanguageByCode_WithNonExistingLanguage_ShouldReturnNull()
        {
            // Arrange
            var provider = new LanguageProvider();

            // Act
            var result = provider.GetLanguageByCode("en");

            // Assert
            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that LanguageExists with existing language should return true
        /// </summary>
        [Fact]
        public void LanguageExists_WithExistingLanguage_ShouldReturnTrue()
        {
            // Arrange
            var provider = new LanguageProvider();
            var language = new Lang("en", "English");
            provider.AddLanguage(language);

            // Act
            bool result = provider.LanguageExists("en");

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that LanguageExists with non-existing language should return false
        /// </summary>
        [Fact]
        public void LanguageExists_WithNonExistingLanguage_ShouldReturnFalse()
        {
            // Arrange
            var provider = new LanguageProvider();

            // Act
            bool result = provider.LanguageExists("en");

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that GetAvailableLanguages should return empty list initially
        /// </summary>
        [Fact]
        public void GetAvailableLanguages_Initially_ShouldReturnEmptyList()
        {
            // Arrange
            var provider = new LanguageProvider();

            // Act
            var languages = provider.GetAvailableLanguages();

            // Assert
            Assert.Empty(languages);
        }

        /// <summary>
        ///     Tests that multiple languages can be added
        /// </summary>
        [Fact]
        public void AddLanguage_WithMultipleLanguages_ShouldAddAllLanguages()
        {
            // Arrange
            var provider = new LanguageProvider();
            var english = new Lang("en", "English");
            var spanish = new Lang("es", "Spanish");
            var french = new Lang("fr", "French");

            // Act
            provider.AddLanguage(english);
            provider.AddLanguage(spanish);
            provider.AddLanguage(french);

            // Assert
            var languages = provider.GetAvailableLanguages();
            Assert.Equal(3, languages.Count);
            Assert.Contains(english, languages);
            Assert.Contains(spanish, languages);
            Assert.Contains(french, languages);
        }
    }
}

