// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MemoryTranslationProviderTest.cs
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
using System.Linq;
using System.Threading.Tasks;
using Alis.Extension.Language.Translator.Providers;
using Xunit;

namespace Alis.Extension.Language.Translator.Test
{
    /// <summary>
    ///     Tests for the MemoryTranslationProvider class
    /// </summary>
    public class MemoryTranslationProviderTest
    {
        /// <summary>
        ///     Tests that SetTranslationAsync and GetTranslationAsync work correctly
        /// </summary>
        [Fact]
        public async Task SetTranslationAsync_AndGetTranslationAsync_ShouldWorkCorrectly()
        {
            MemoryTranslationProvider provider = new MemoryTranslationProvider();

            await provider.SetTranslationAsync("en", "greeting", "Hello");
            string result = await provider.GetTranslationAsync("en", "greeting");

            Assert.Equal("Hello", result);
        }

        /// <summary>
        ///     Tests that GetTranslationAsync returns null for non-existing translation
        /// </summary>
        [Fact]
        public async Task GetTranslationAsync_WithNonExistingTranslation_ShouldReturnNull()
        {
            MemoryTranslationProvider provider = new MemoryTranslationProvider();

            string result = await provider.GetTranslationAsync("en", "nonexistent");

            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that RemoveTranslationAsync removes translation successfully
        /// </summary>
        [Fact]
        public async Task RemoveTranslationAsync_WithExistingTranslation_ShouldRemoveSuccessfully()
        {
            MemoryTranslationProvider provider = new MemoryTranslationProvider();
            await provider.SetTranslationAsync("en", "greeting", "Hello");

            await provider.RemoveTranslationAsync("en", "greeting");
            string result = await provider.GetTranslationAsync("en", "greeting");

            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that GetKeysAsync returns all keys for a language
        /// </summary>
        [Fact]
        public async Task GetKeysAsync_ShouldReturnAllKeysForLanguage()
        {
            MemoryTranslationProvider provider = new MemoryTranslationProvider();
            await provider.SetTranslationAsync("en", "greeting", "Hello");
            await provider.SetTranslationAsync("en", "farewell", "Goodbye");
            await provider.SetTranslationAsync("es", "greeting", "Hola");

            IEnumerable<string> keys = await provider.GetKeysAsync("en");
            List<string> keysList = keys.ToList();

            Assert.Equal(2, keysList.Count);
            Assert.Contains("greeting", keysList);
            Assert.Contains("farewell", keysList);
        }

        /// <summary>
        ///     Tests that GetKeysAsync returns empty for non-existing language
        /// </summary>
        [Fact]
        public async Task GetKeysAsync_WithNonExistingLanguage_ShouldReturnEmpty()
        {
            MemoryTranslationProvider provider = new MemoryTranslationProvider();

            IEnumerable<string> keys = await provider.GetKeysAsync("en");

            Assert.Empty(keys);
        }

        /// <summary>
        ///     Tests that LoadTranslationsAsync returns all translations
        /// </summary>
        [Fact]
        public async Task LoadTranslationsAsync_ShouldReturnAllTranslations()
        {
            MemoryTranslationProvider provider = new MemoryTranslationProvider();
            await provider.SetTranslationAsync("en", "greeting", "Hello");
            await provider.SetTranslationAsync("es", "greeting", "Hola");

            Dictionary<string, Dictionary<string, string>> translations = await provider.LoadTranslationsAsync();

            Assert.Equal(2, translations.Count);
            Assert.True(translations.ContainsKey("en"));
            Assert.True(translations.ContainsKey("es"));
            Assert.Equal("Hello", translations["en"]["greeting"]);
            Assert.Equal("Hola", translations["es"]["greeting"]);
        }

        /// <summary>
        ///     Tests that SaveTranslationsAsync with null throws exception
        /// </summary>
        [Fact]
        public async Task SaveTranslationsAsync_WithNull_ShouldThrowException()
        {
            MemoryTranslationProvider provider = new MemoryTranslationProvider();

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await provider.SaveTranslationsAsync(null));
        }

        /// <summary>
        ///     Tests that Name property returns correct value
        /// </summary>
        [Fact]
        public void Name_ShouldReturnProviderName()
        {
            MemoryTranslationProvider provider = new MemoryTranslationProvider();

            string name = provider.Name;

            Assert.Equal("MemoryTranslationProvider", name);
        }

        /// <summary>
        ///     Tests that multiple languages can be handled independently
        /// </summary>
        [Fact]
        public async Task SetTranslationAsync_WithMultipleLanguages_ShouldStoreIndependently()
        {
            MemoryTranslationProvider provider = new MemoryTranslationProvider();

            await provider.SetTranslationAsync("en", "greeting", "Hello");
            await provider.SetTranslationAsync("es", "greeting", "Hola");
            await provider.SetTranslationAsync("fr", "greeting", "Bonjour");

            string enValue = await provider.GetTranslationAsync("en", "greeting");
            string esValue = await provider.GetTranslationAsync("es", "greeting");
            string frValue = await provider.GetTranslationAsync("fr", "greeting");

            Assert.Equal("Hello", enValue);
            Assert.Equal("Hola", esValue);
            Assert.Equal("Bonjour", frValue);
        }
    }
}