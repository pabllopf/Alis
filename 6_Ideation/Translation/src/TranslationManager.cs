// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TranslationManager.cs
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

namespace Alis.Core.Aspect.Translation
{
    /// <summary>
    ///     The translation manager class
    /// </summary>
    public class TranslationManager
    {
        /// <summary>
        ///     The language
        /// </summary>
        private readonly List<Language> languages = new List<Language>();

        /// <summary>
        ///     The dictionary
        /// </summary>
        private readonly Dictionary<Language, Dictionary<string, string>> translations = new Dictionary<Language, Dictionary<string, string>>();

        /// <summary>
        ///     The current language
        /// </summary>
        public Language Language { get; private set; }

        /// <summary>
        ///     Sets the language using the specified language
        /// </summary>
        /// <param name="language">The language</param>
        public void SetLanguage(Language language)
        {
            Language = language ?? throw new ArgumentNullException("[Language cannot be null]");
            if (!languages.Contains(language))
            {
                languages.Add(language);
            }
        }

        /// <summary>
        ///     Sets the language using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="localCode">The local code</param>
        public void SetLanguage(string name, string localCode)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("[Name cannot be null or empty]");
            }

            if (string.IsNullOrEmpty(localCode))
            {
                throw new ArgumentNullException("[Local code cannot be null or empty]");
            }

            Language language = languages.Find(l => l.Code == localCode);
            if (language is null)
            {
                Language languageNew = new Language
                {
                    Name = name,
                    Code = localCode
                };
                languages.Add(languageNew);
                Language = languageNew;
            }
            else
            {
                Language = language;
            }
        }

        /// <summary>
        ///     Adds the language using the specified language
        /// </summary>
        /// <param name="language">The language</param>
        public void AddLanguage(Language language)
        {
            if (!languages.Contains(language))
            {
                languages.Add(language);
            }

            Language ??= language;
        }

        /// <summary>
        ///     Translates the key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The string</returns>
        public string Translate(string key)
        {
            if (translations.ContainsKey(Language) && translations[Language].ContainsKey(key))
            {
                return translations[Language][key];
            }

            throw new TranslationNotFound($"[Translation not found for key: {key}]");
        }


        /// <summary>
        ///     Adds the translation using the specified language
        /// </summary>
        /// <param name="language">The language</param>
        /// <param name="key">The key</param>
        /// <param name="value">The value</param>
        public void AddTranslation(Language language, string key, string value)
        {
            if (!translations.ContainsKey(language))
            {
                translations[language] = new Dictionary<string, string>();
            }

            translations[language][key] = value;
        }

        /// <summary>
        ///     Adds the translation using the specified local code
        /// </summary>
        /// <param name="localCode">The local code</param>
        /// <param name="key">The key</param>
        /// <param name="value">The value</param>
        /// <exception cref="LanguageNotFound">[Language not found for code: {localCode}]</exception>
        public void AddTranslation(string localCode, string key, string value)
        {
            if (string.IsNullOrEmpty(localCode))
            {
                throw new ArgumentNullException("[localCode cannot be null or empty]");
            }

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("[key cannot be null or empty]");
            }

            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("[value code cannot be null or empty]");
            }


            Language language = languages.Find(l => l.Code == localCode);

            if (language is null)
            {
                throw new LanguageNotFound($"[Language not found for code: {localCode}]");
            }

            if (!translations.ContainsKey(language))
            {
                translations[language] = new Dictionary<string, string>();
            }

            translations[language][key] = value;
        }


        /// <summary>
        ///     Gets the available languages
        /// </summary>
        /// <returns>A list of language</returns>
        public List<Language> GetAvailableLanguages() => languages;
    }
}