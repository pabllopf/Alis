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
using System.Collections.Generic;
using Alis.Extension.Language.Translator.Abstractions;
using Alis.Extension.Language.Translator.Providers;
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
            LanguageProvider provider = new LanguageProvider();
            Lang language = new Lang("en", "English");

            provider.AddLanguage(language);

            Assert.Single(provider.GetAvailableLanguages());
            Assert.Contains(language, provider.GetAvailableLanguages());
        }

        /// <summary>
        ///     Tests that AddLanguage with null language should throw exception
        /// </summary>
        [Fact]
        public void AddLanguage_WithNullLanguage_ShouldThrowException()
        {
            LanguageProvider provider = new LanguageProvider();

            Assert.Throws<ArgumentNullException>(() => provider.AddLanguage(null));
        }

        /// <summary>
        ///     Tests that AddLanguage with duplicate language code should throw exception
        /// </summary>
        [Fact]
        public void AddLanguage_WithDuplicateLanguageCode_ShouldThrowException()
        {
            LanguageProvider provider = new LanguageProvider();
            Lang language1 = new Lang("en", "English");
            Lang language2 = new Lang("en", "English Language");

            provider.AddLanguage(language1);

            Assert.Throws<InvalidOperationException>(() => provider.AddLanguage(language2));
        }

        /// <summary>
        ///     Tests that RemoveLanguage with existing language should remove successfully
        /// </summary>
        [Fact]
        public void RemoveLanguage_WithExistingLanguage_ShouldRemoveSuccessfully()
        {
            LanguageProvider provider = new LanguageProvider();
            Lang language = new Lang("en", "English");
            provider.AddLanguage(language);

            bool result = provider.RemoveLanguage("en");

            Assert.True(result);
            Assert.Empty(provider.GetAvailableLanguages());
        }

        /// <summary>
        ///     Tests that RemoveLanguage with non-existing language should return false
        /// </summary>
        [Fact]
        public void RemoveLanguage_WithNonExistingLanguage_ShouldReturnFalse()
        {
            LanguageProvider provider = new LanguageProvider();

            bool result = provider.RemoveLanguage("en");

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that GetLanguageByCode with existing language should return language
        /// </summary>
        [Fact]
        public void GetLanguageByCode_WithExistingLanguage_ShouldReturnLanguage()
        {
            LanguageProvider provider = new LanguageProvider();
            Lang language = new Lang("en", "English");
            provider.AddLanguage(language);

            ILanguage result = provider.GetLanguageByCode("en");

            Assert.NotNull(result);
            Assert.Equal(language, result);
        }

        /// <summary>
        ///     Tests that GetLanguageByCode with non-existing language should return null
        /// </summary>
        [Fact]
        public void GetLanguageByCode_WithNonExistingLanguage_ShouldReturnNull()
        {
            LanguageProvider provider = new LanguageProvider();

            ILanguage result = provider.GetLanguageByCode("en");

            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that LanguageExists with existing language should return true
        /// </summary>
        [Fact]
        public void LanguageExists_WithExistingLanguage_ShouldReturnTrue()
        {
            LanguageProvider provider = new LanguageProvider();
            Lang language = new Lang("en", "English");
            provider.AddLanguage(language);

            bool result = provider.LanguageExists("en");

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that LanguageExists with non-existing language should return false
        /// </summary>
        [Fact]
        public void LanguageExists_WithNonExistingLanguage_ShouldReturnFalse()
        {
            LanguageProvider provider = new LanguageProvider();

            bool result = provider.LanguageExists("en");

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that GetAvailableLanguages should return empty list initially
        /// </summary>
        [Fact]
        public void GetAvailableLanguages_Initially_ShouldReturnEmptyList()
        {
            LanguageProvider provider = new LanguageProvider();

            IReadOnlyList<ILanguage> languages = provider.GetAvailableLanguages();

            Assert.Empty(languages);
        }

        /// <summary>
        ///     Tests that multiple languages can be added
        /// </summary>
        [Fact]
        public void AddLanguage_WithMultipleLanguages_ShouldAddAllLanguages()
        {
            LanguageProvider provider = new LanguageProvider();
            Lang english = new Lang("en", "English");
            Lang spanish = new Lang("es", "Spanish");
            Lang french = new Lang("fr", "French");

            provider.AddLanguage(english);
            provider.AddLanguage(spanish);
            provider.AddLanguage(french);

            IReadOnlyList<ILanguage> languages = provider.GetAvailableLanguages();
            Assert.Equal(3, languages.Count);
            Assert.Contains(english, languages);
            Assert.Contains(spanish, languages);
            Assert.Contains(french, languages);
        }

        /// <summary>
        ///     Tests that AddLanguage with a language that has a null code throws an exception
        /// </summary>
        [Fact]
        public void AddLanguage_WithNullCode_ShouldThrowException()
        {
            LanguageProvider provider = new LanguageProvider();
            Lang language = new Lang(null, "Test");

            Assert.Throws<ArgumentException>(() => provider.AddLanguage(language));
        }

        /// <summary>
        ///     Tests that RemoveLanguage with null code returns false
        /// </summary>
        [Fact]
        public void RemoveLanguage_WithNullCode_ShouldReturnFalse()
        {
            LanguageProvider provider = new LanguageProvider();

            bool result = provider.RemoveLanguage(null);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that RemoveLanguage with empty code returns false
        /// </summary>
        [Fact]
        public void RemoveLanguage_WithEmptyCode_ShouldReturnFalse()
        {
            LanguageProvider provider = new LanguageProvider();

            bool result = provider.RemoveLanguage(string.Empty);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that GetLanguageByCode with null code returns null
        /// </summary>
        [Fact]
        public void GetLanguageByCode_WithNullCode_ShouldReturnNull()
        {
            LanguageProvider provider = new LanguageProvider();

            ILanguage result = provider.GetLanguageByCode(null);

            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that GetLanguageByCode with empty code returns null
        /// </summary>
        [Fact]
        public void GetLanguageByCode_WithEmptyCode_ShouldReturnNull()
        {
            LanguageProvider provider = new LanguageProvider();

            ILanguage result = provider.GetLanguageByCode(string.Empty);

            Assert.Null(result);
        }
    }
}