// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TranslationManagerTest.cs
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
using Xunit;

namespace Alis.Core.Aspect.Translation.Test
{
    /// <summary>
    /// The translation manager test class
    /// </summary>
    public class TranslationManagerTest
    {
        /// <summary>
        /// Tests that set language with valid language should set current language
        /// </summary>
        [Fact]
        public void SetLanguage_WithValidLanguage_ShouldSetCurrentLanguage()
        {
            // Arrange
            TranslationManager translationManager = new TranslationManager();
            Language language = new Language {Name = "English", Code = "en"};

            // Act
            translationManager.SetLanguage(language);

            // Assert
            Assert.Equal(language, translationManager.Language);
        }

        /// <summary>
        /// Tests that set language with valid language not in list should add language to list
        /// </summary>
        [Fact]
        public void SetLanguage_WithValidLanguageNotInList_ShouldAddLanguageToList()
        {
            // Arrange
            TranslationManager translationManager = new TranslationManager();
            Language language = new Language {Name = "Spanish", Code = "es"};

            // Act
            translationManager.SetLanguage(language);

            // Assert
            Assert.Contains(language, translationManager.GetAvailableLanguages());
        }

        /// <summary>
        /// Tests that set language with duplicate language should not add duplicate
        /// </summary>
        [Fact]
        public void SetLanguage_WithDuplicateLanguage_ShouldNotAddDuplicate()
        {
            // Arrange
            TranslationManager translationManager = new TranslationManager();
            Language language = new Language {Name = "French", Code = "fr"};

            // Act
            translationManager.SetLanguage(language);
            translationManager.SetLanguage(language); // Add duplicate

            // Assert
            Assert.Single(translationManager.GetAvailableLanguages()); // Only one instance should be in the list
        }

        /// <summary>
        /// Tests that set language with invalid language should throw exception
        /// </summary>
        [Fact]
        public void SetLanguage_WithInvalidLanguage_ShouldThrowException()
        {
            // Arrange
            TranslationManager translationManager = new TranslationManager();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => translationManager.SetLanguage(null));
        }

        /// <summary>
        /// Tests that set language with string name and code should add language to list
        /// </summary>
        [Fact]
        public void SetLanguage_WithStringNameAndCode_ShouldAddLanguageToList()
        {
            // Arrange
            TranslationManager translationManager = new TranslationManager();
            const string name = "German";
            const string code = "de";

            // Act
            translationManager.SetLanguage(name, code);

            // Assert
            Language addedLanguage = translationManager.GetAvailableLanguages().FirstOrDefault(l => l.Code == code);
            Assert.NotNull(addedLanguage);
            Assert.Equal(name, addedLanguage.Name);
        }

        /// <summary>
        /// Tests that translate with valid translation should return translated string
        /// </summary>
        [Fact]
        public void Translate_WithValidTranslation_ShouldReturnTranslatedString()
        {
            // Arrange
            TranslationManager translationManager = new TranslationManager();
            Language language = new Language {Name = "English", Code = "en"};
            translationManager.SetLanguage(language);
            const string key = "greeting";
            const string value = "Hello, World!";
            translationManager.AddTranslation(language, key, value);

            // Act
            string result = translationManager.Translate(key);

            // Assert
            Assert.Equal(value, result);
        }

        /// <summary>
        /// Tests that translate with invalid language should throw exception
        /// </summary>
        [Fact]
        public void Translate_WithInvalidLanguage_ShouldThrowException()
        {
            // Arrange
            TranslationManager translationManager = new TranslationManager();
            Language language = new Language {Name = "English", Code = "en"};
            translationManager.SetLanguage(language);
            const string key = "greeting";

            // Act & Assert
            Assert.Throws<TranslationNotFound>(() => translationManager.Translate(key));
        }


        /// <summary>
        /// Tests that add translation with valid parameters should add translation
        /// </summary>
        [Fact]
        public void AddTranslation_WithValidParameters_ShouldAddTranslation()
        {
            // Arrange
            TranslationManager translationManager = new TranslationManager();
            Language language = new Language {Name = "Spanish", Code = "es"};
            const string key = "farewell";
            const string value = "Adiós";

            // Act
            translationManager.SetLanguage(language);
            translationManager.AddTranslation(language, key, value);

            // Assert
            string translatedValue = translationManager.Translate(key);
            Assert.Equal(value, translatedValue);
        }

        /// <summary>
        /// Tests that add translation with invalid language should throw exception
        /// </summary>
        [Fact]
        public void AddTranslation_WithInvalidLanguage_ShouldThrowException()
        {
            // Arrange
            TranslationManager translationManager = new TranslationManager();
            const string key = "farewell";
            const string value = "Adiós";

            // Act & Assert
            Assert.Throws<LanguageNotFound>(() => translationManager.AddTranslation("fr", key, value));
        }

        /// <summary>
        /// Tests that get available languages with no languages should return empty list
        /// </summary>
        [Fact]
        public void GetAvailableLanguages_WithNoLanguages_ShouldReturnEmptyList()
        {
            // Arrange
            TranslationManager translationManager = new TranslationManager();

            // Act
            List<Language> availableLanguages = translationManager.GetAvailableLanguages();

            // Assert
            Assert.Empty(availableLanguages);
        }

        /// <summary>
        /// Tests that get available languages after adding languages should return correct list
        /// </summary>
        [Fact]
        public void GetAvailableLanguages_AfterAddingLanguages_ShouldReturnCorrectList()
        {
            // Arrange
            TranslationManager translationManager = new TranslationManager();
            Language language1 = new Language {Name = "Italian", Code = "it"};
            Language language2 = new Language {Name = "Portuguese", Code = "pt"};

            // Act
            translationManager.AddLanguage(language1);
            translationManager.AddLanguage(language2);

            // Assert
            List<Language> availableLanguages = translationManager.GetAvailableLanguages();
            Assert.Contains(language1, availableLanguages);
            Assert.Contains(language2, availableLanguages);
        }

        /// <summary>
        /// Tests that set language with null language should throw exception
        /// </summary>
        [Fact]
        public void SetLanguage_WithNullLanguage_ShouldThrowException()
        {
            // Arrange
            TranslationManager translationManager = new TranslationManager();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => translationManager.SetLanguage(null));
        }

        /// <summary>
        /// Tests that set language with null name and code should throw exception
        /// </summary>
        [Fact]
        public void SetLanguage_WithNullNameAndCode_ShouldThrowException()
        {
            // Arrange
            TranslationManager translationManager = new TranslationManager();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => translationManager.SetLanguage(null, null));
        }

        /// <summary>
        /// Tests that set language with valid name and code should set language
        /// </summary>
        [Fact]
        public void SetLanguage_WithValidNameAndCode_ShouldSetLanguage()
        {
            // Arrange
            TranslationManager translationManager = new TranslationManager();
            const string name = "German";
            const string code = "de";

            // Act
            translationManager.SetLanguage(name, code);

            // Assert
            Language selectedLanguage = translationManager.Language;
            Assert.NotNull(selectedLanguage);
            Assert.Equal(name, selectedLanguage.Name);
            Assert.Equal(code, selectedLanguage.Code);
        }

        /// <summary>
        /// Tests that set language with existing language should set existing language
        /// </summary>
        [Fact]
        public void SetLanguage_WithExistingLanguage_ShouldSetExistingLanguage()
        {
            // Arrange
            TranslationManager translationManager = new TranslationManager();
            Language existingLanguage = new Language {Name = "Spanish", Code = "es"};
            translationManager.AddLanguage(existingLanguage);

            // Act
            translationManager.SetLanguage(existingLanguage.Name, existingLanguage.Code);

            // Assert
            Language selectedLanguage = translationManager.Language;
            Assert.Equal(existingLanguage, selectedLanguage);
        }

        /// <summary>
        /// Tests that set language with null or empty name should throw exception
        /// </summary>
        [Fact]
        public void SetLanguage_WithNullOrEmptyName_ShouldThrowException()
        {
            // Arrange
            TranslationManager translationManager = new TranslationManager();
            const string code = "fr";

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => translationManager.SetLanguage(null, code));
            Assert.Throws<ArgumentNullException>(() => translationManager.SetLanguage("", code));
        }

        /// <summary>
        /// Tests that set language with null or empty code should throw exception
        /// </summary>
        [Fact]
        public void SetLanguage_WithNullOrEmptyCode_ShouldThrowException()
        {
            // Arrange
            TranslationManager translationManager = new TranslationManager();
            const string name = "French";

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => translationManager.SetLanguage(name, null));
            Assert.Throws<ArgumentNullException>(() => translationManager.SetLanguage(name, ""));
        }

        /// <summary>
        /// Tests that add translation with non existing local code should throw exception
        /// </summary>
        [Fact]
        public void AddTranslation_WithNonExistingLocalCode_ShouldThrowException()
        {
            // Arrange
            TranslationManager translationManager = new TranslationManager();
            const string localCode = "nonexistent";
            const string key = "greeting";
            const string value = "Hello!";

            // Act & Assert
            LanguageNotFound exception = Assert.Throws<LanguageNotFound>(() => translationManager.AddTranslation(localCode, key, value));
            Assert.Equal($"[Language not found for code: {localCode}]", exception.Message);
        }

        /// <summary>
        /// Tests that add translation with null or empty key should throw exception
        /// </summary>
        [Fact]
        public void AddTranslation_WithNullOrEmptyKey_ShouldThrowException()
        {
            // Arrange
            TranslationManager translationManager = new TranslationManager();
            const string localCode = "en";
            const string value = "Hello!";

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => translationManager.AddTranslation(localCode, null, value));
            Assert.Throws<ArgumentNullException>(() => translationManager.AddTranslation(localCode, "", value));
        }
        
        
        /// <summary>
        /// Tests that set language with valid name and local code should set language
        /// </summary>
        [Fact]
        public void SetLanguage_WithValidNameAndLocalCode_ShouldSetLanguage()
        {
            // Arrange
            TranslationManager translationManager = new TranslationManager();
            const string name = "French";
            const string localCode = "fr";

            // Act
            translationManager.SetLanguage(name, localCode);

            // Assert
            Assert.NotNull(translationManager.Language);
            Assert.Equal(name, translationManager.Language.Name);
            Assert.Equal(localCode, translationManager.Language.Code);
            Assert.Contains(translationManager.Language, translationManager.GetAvailableLanguages());
        }

        /// <summary>
        /// Tests that set language with null or empty name 2 params should throw exception
        /// </summary>
        [Fact]
        public void SetLanguage_WithNullOrEmptyName_2_Params_ShouldThrowException()
        {
            // Arrange
            TranslationManager translationManager = new TranslationManager();
            const string localCode = "fr";

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => translationManager.SetLanguage(null, localCode));
            Assert.Throws<ArgumentNullException>(() => translationManager.SetLanguage("", localCode));
        }

        /// <summary>
        /// Tests that set language with null or empty local code should throw exception
        /// </summary>
        [Fact]
        public void SetLanguage_WithNullOrEmptyLocalCode_ShouldThrowException()
        {
            // Arrange
            TranslationManager translationManager = new TranslationManager();
            const string name = "French";

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => translationManager.SetLanguage(name, null));
            Assert.Throws<ArgumentNullException>(() => translationManager.SetLanguage(name, ""));
        }

        /// <summary>
        /// Tests that add translation with invalid local code should throw exception
        /// </summary>
        [Fact]
        public void AddTranslation_WithInvalidLocalCode_ShouldThrowException()
        {
            // Arrange
            TranslationManager translationManager = new TranslationManager();
            string localCode = "invalidCode";
            string key = "greeting";
            string value = "Hello";

            // Act & Assert
            LanguageNotFound exception = Assert.Throws<LanguageNotFound>(() => translationManager.AddTranslation(localCode, key, value));
            Assert.Equal($"[Language not found for code: {localCode}]", exception.Message);
        }

        /// <summary>
        /// Tests that add translation with null or empty key 3 strings should throw exception
        /// </summary>
        [Fact]
        public void AddTranslation_WithNullOrEmptyKey_Strings_ShouldThrowException()
        {
            // Arrange
            TranslationManager translationManager = new TranslationManager();
            const string localCode = "fr";
            const string key = "";
            const string value = "Bonjour";

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => translationManager.AddTranslation(localCode, key, value));
        }

        
        [Fact]
        public void AddTranslation_WithValidData_ShouldAddTranslation()
        {
            // Arrange
            TranslationManager translationManager = new TranslationManager();
            Language language = new Language {Name = "French", Code = "fr"};
            translationManager.AddLanguage(language);
            
            const string localCode = "fr";
            const string key = "greeting";
            const string value = "Bonjour";

            // Act
            translationManager.AddTranslation(localCode, key, value);

            // Assert
            Assert.Contains(translationManager.Language, translationManager.GetAvailableLanguages());
            Assert.Equal(value, translationManager.Translate(key));
        }

        [Fact]
        public void AddTranslation_WithInvalidLocalCode_Strings_ShouldThrowException()
        {
            // Arrange
            TranslationManager translationManager = new TranslationManager();
            string localCode = "invalidCode";
            string key = "greeting";
            string value = "Hello";

            // Act & Assert
            LanguageNotFound exception = Assert.Throws<LanguageNotFound>(() => translationManager.AddTranslation(localCode, key, value));
            Assert.Equal($"[Language not found for code: {localCode}]", exception.Message);
        }

        [Theory]
        [InlineData("", "greeting", "Hello")] 
        [InlineData("fr", "", "Bonjour")]
        [InlineData("fr", "greeting", "")] 
        public void AddTranslation_WithNullOrEmptyParameter_ShouldThrowException(string localCode, string key, string value)
        {
            // Arrange
            TranslationManager translationManager = new TranslationManager();

            // Act & Assert
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => translationManager.AddTranslation(localCode, key, value));
        }
    }
}