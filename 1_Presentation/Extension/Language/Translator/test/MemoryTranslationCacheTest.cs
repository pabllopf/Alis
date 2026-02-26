// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MemoryTranslationCacheTest.cs
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

using Xunit;

namespace Alis.Extension.Language.Translator.Test
{
    /// <summary>
    ///     Tests for the MemoryTranslationCache class
    /// </summary>
    public class MemoryTranslationCacheTest
    {
        /// <summary>
        ///     Tests that Set and TryGetTranslation work correctly
        /// </summary>
        [Fact]
        public void Set_AndTryGetTranslation_ShouldStoreAndRetrieveCorrectly()
        {
            // Arrange
            MemoryTranslationCache cache = new MemoryTranslationCache();
            string value = "Hello";

            // Act
            cache.Set("en", "greeting", value);
            bool found = cache.TryGetTranslation("en", "greeting", out string result);

            // Assert
            Assert.True(found);
            Assert.Equal(value, result);
        }

        /// <summary>
        ///     Tests that TryGetTranslation returns false for non-existing translation
        /// </summary>
        [Fact]
        public void TryGetTranslation_WithNonExistingTranslation_ShouldReturnFalse()
        {
            // Arrange
            MemoryTranslationCache cache = new MemoryTranslationCache();

            // Act
            bool found = cache.TryGetTranslation("en", "greeting", out string result);

            // Assert
            Assert.False(found);
            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that Remove removes translation successfully
        /// </summary>
        [Fact]
        public void Remove_WithExistingTranslation_ShouldRemoveSuccessfully()
        {
            // Arrange
            MemoryTranslationCache cache = new MemoryTranslationCache();
            cache.Set("en", "greeting", "Hello");

            // Act
            bool removed = cache.Remove("en", "greeting");
            bool found = cache.TryGetTranslation("en", "greeting", out _);

            // Assert
            Assert.True(removed);
            Assert.False(found);
        }

        /// <summary>
        ///     Tests that Remove returns false for non-existing translation
        /// </summary>
        [Fact]
        public void Remove_WithNonExistingTranslation_ShouldReturnFalse()
        {
            // Arrange
            MemoryTranslationCache cache = new MemoryTranslationCache();

            // Act
            bool removed = cache.Remove("en", "greeting");

            // Assert
            Assert.False(removed);
        }

        /// <summary>
        ///     Tests that InvalidateLanguage clears all translations for a language
        /// </summary>
        [Fact]
        public void InvalidateLanguage_ShouldClearAllTranslationsForLanguage()
        {
            // Arrange
            MemoryTranslationCache cache = new MemoryTranslationCache();
            cache.Set("en", "greeting", "Hello");
            cache.Set("en", "farewell", "Goodbye");

            // Act
            cache.InvalidateLanguage("en");
            bool found1 = cache.TryGetTranslation("en", "greeting", out _);
            bool found2 = cache.TryGetTranslation("en", "farewell", out _);

            // Assert
            Assert.False(found1);
            Assert.False(found2);
        }

        /// <summary>
        ///     Tests that Clear removes all cached translations
        /// </summary>
        [Fact]
        public void Clear_ShouldRemoveAllCachedTranslations()
        {
            // Arrange
            MemoryTranslationCache cache = new MemoryTranslationCache();
            cache.Set("en", "greeting", "Hello");
            cache.Set("es", "greeting", "Hola");

            // Act
            cache.Clear();
            bool found1 = cache.TryGetTranslation("en", "greeting", out _);
            bool found2 = cache.TryGetTranslation("es", "greeting", out _);

            // Assert
            Assert.False(found1);
            Assert.False(found2);
        }

        /// <summary>
        ///     Tests that multiple languages can be cached independently
        /// </summary>
        [Fact]
        public void Set_WithMultipleLanguages_ShouldStoreIndependently()
        {
            // Arrange
            MemoryTranslationCache cache = new MemoryTranslationCache();

            // Act
            cache.Set("en", "greeting", "Hello");
            cache.Set("es", "greeting", "Hola");
            cache.Set("fr", "greeting", "Bonjour");

            bool enFound = cache.TryGetTranslation("en", "greeting", out string enValue);
            bool esFound = cache.TryGetTranslation("es", "greeting", out string esValue);
            bool frFound = cache.TryGetTranslation("fr", "greeting", out string frValue);

            // Assert
            Assert.True(enFound);
            Assert.Equal("Hello", enValue);
            Assert.True(esFound);
            Assert.Equal("Hola", esValue);
            Assert.True(frFound);
            Assert.Equal("Bonjour", frValue);
        }
    }
}

