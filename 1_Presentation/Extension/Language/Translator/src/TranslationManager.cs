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

namespace Alis.Extension.Language.Translator
{
    /// <summary>
    ///     The translation manager class
    /// </summary>
    public class TranslationManager
    {
        /// <summary>
        ///     The language
        /// </summary>
        private readonly List<Lang> languages = new List<Lang>();

        /// <summary>
        ///     The dictionary
        /// </summary>
        private readonly Dictionary<Lang, Dictionary<string, string>> translations = new Dictionary<Lang, Dictionary<string, string>>();

        /// <summary>
        ///     The current language
        /// </summary>
        public Lang Lang { get; private set; }

        /// <summary>
        ///     Sets the language using the specified language
        /// </summary>
        /// <param name="lang">The language</param>
        public void SetLanguage(Lang lang)
        {
            Lang = lang ?? throw new ArgumentNullException("[Language cannot be null]");
            if (!languages.Contains(lang))
            {
                languages.Add(lang);
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

            Lang lang = languages.Find(l => l.Code == localCode);
            if (lang is null)
            {
                Lang langNew = new Lang
                {
                    Name = name,
                    Code = localCode
                };
                languages.Add(langNew);
                Lang = langNew;
            }
            else
            {
                Lang = lang;
            }
        }

        /// <summary>
        ///     Adds the language using the specified language
        /// </summary>
        /// <param name="lang">The language</param>
        public void AddLanguage(Lang lang)
        {
            if (!languages.Contains(lang))
            {
                languages.Add(lang);
            }

            Lang ??= lang;
        }

        /// <summary>
        ///     Translates the key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The string</returns>
        public string Translate(string key)
        {
            if (translations.ContainsKey(Lang) && translations[Lang].ContainsKey(key))
            {
                return translations[Lang][key];
            }

            throw new TranslationNotFound($"[Translation not found for key: {key}]");
        }


        /// <summary>
        ///     Adds the translation using the specified language
        /// </summary>
        /// <param name="lang">The language</param>
        /// <param name="key">The key</param>
        /// <param name="value">The value</param>
        public void AddTranslation(Lang lang, string key, string value)
        {
            if (!translations.ContainsKey(lang))
            {
                translations[lang] = new Dictionary<string, string>();
            }

            translations[lang][key] = value;
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


            Lang lang = languages.Find(l => l.Code == localCode);

            if (lang is null)
            {
                throw new LanguageNotFound($"[Language not found for code: {localCode}]");
            }

            if (!translations.ContainsKey(lang))
            {
                translations[lang] = new Dictionary<string, string>();
            }

            translations[lang][key] = value;
        }


        /// <summary>
        ///     Gets the available languages
        /// </summary>
        /// <returns>A list of language</returns>
        public List<Lang> GetAvailableLanguages() => languages;
    }
}