// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Program.cs
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

namespace Alis.Extension.Language.Translator.Sample
{
    /// <summary>
    ///     The program class demonstrating all translation system features
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     Main entry point for the translation system sample
        /// </summary>
        /// <param name="args">The command line arguments</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("=== Alis Translation System Sample ===\n");

            // Create translation manager with default providers
            TranslationManager manager = new TranslationManager();

            // Example 1: Basic Language Setup
            Console.WriteLine("1. Basic Language Setup");
            BasicSetup(manager);

            // Example 2: Language Switching
            Console.WriteLine("\n2. Language Switching");
            LanguageSwitching(manager);

            // Example 3: Parameter Substitution
            Console.WriteLine("\n3. Parameter Substitution");
            ParameterSubstitution(manager);

            // Example 4: Pluralization
            Console.WriteLine("\n4. Pluralization");
            PluralSupport(manager);

            // Example 5: Fallback Languages
            Console.WriteLine("\n5. Fallback Languages");
            FallbackLanguages(manager);

            // Example 6: Observers
            Console.WriteLine("\n6. Observer Pattern");
            ObserverPattern(manager);

            // Example 7: Error Handling
            Console.WriteLine("\n7. Error Handling");
            ErrorHandling(manager);

            Console.WriteLine("\n=== Sample Complete ===");
        }

        /// <summary>
        ///     Example 1: Basic setup with languages and translations
        /// </summary>
        private static void BasicSetup(TranslationManager manager)
        {
            // Add languages
            manager.AddLanguage("English", "en");
            manager.AddLanguage("Spanish", "es");
            manager.AddLanguage("French", "fr");

            // Set current language
            manager.SetLanguage("en");

            // Add translations
            manager.AddTranslation("en", "greeting", "Hello");
            manager.AddTranslation("en", "farewell", "Goodbye");

            manager.AddTranslation("es", "greeting", "Hola");
            manager.AddTranslation("es", "farewell", "Adiós");

            manager.AddTranslation("fr", "greeting", "Bonjour");
            manager.AddTranslation("fr", "farewell", "Au revoir");

            // Display available languages
            Console.WriteLine($"Available languages: {manager.GetAvailableLanguages().Count}");
            foreach (ILanguage lang in manager.GetAvailableLanguages())
            {
                Console.WriteLine($"  - {lang.Code}: {lang.Name}");
            }

            // Display current language
            Console.WriteLine($"\nCurrent language: {manager.Lang.Name} ({manager.Lang.Code})");
            Console.WriteLine($"Greeting: {manager.Translate("greeting")}");
        }

        /// <summary>
        ///     Example 2: Switching between languages
        /// </summary>
        private static void LanguageSwitching(TranslationManager manager)
        {
            // English
            manager.SetLanguage("en");
            Console.WriteLine($"English: {manager.Translate("greeting")}");

            // Spanish
            manager.SetLanguage("es");
            Console.WriteLine($"Spanish: {manager.Translate("greeting")}");

            // French
            manager.SetLanguage("fr");
            Console.WriteLine($"French: {manager.Translate("greeting")}");
        }

        /// <summary>
        ///     Example 3: Parameter substitution
        /// </summary>
        private static void ParameterSubstitution(TranslationManager manager)
        {
            manager.SetLanguage("en");

            // Add template translation
            manager.AddTranslation("en", "welcome", "Welcome {name}! You have {count} messages.");
            manager.AddTranslation("es", "welcome", "¡Bienvenido {name}! Tienes {count} mensajes.");

            // Create parameters
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "name", "Alice" },
                { "count", 5 }
            };

            // Translate with parameters
            Console.WriteLine("English: " + manager.Translate("welcome", parameters));

            manager.SetLanguage("es");
            Console.WriteLine("Spanish: " + manager.Translate("welcome", parameters));
        }

        /// <summary>
        ///     Example 4: Pluralization support
        /// </summary>
        private static void PluralSupport(TranslationManager manager)
        {
            manager.SetLanguage("en");

            // Add plural forms
            manager.AddTranslation("en", "apple[0]", "1 apple");
            manager.AddTranslation("en", "apple[1]", "{count} apples");

            manager.AddTranslation("es", "apple[0]", "1 manzana");
            manager.AddTranslation("es", "apple[1]", "{count} manzanas");

            // Use pluralization
            Console.WriteLine("English:");
            Console.WriteLine($"  Singular: {manager.TranslatePlural("apple", 1)}");
            Console.WriteLine($"  Plural: {manager.TranslatePlural("apple", 5)}");

            manager.SetLanguage("es");
            Console.WriteLine("Spanish:");
            Console.WriteLine($"  Singular: {manager.TranslatePlural("apple", 1)}");
            Console.WriteLine($"  Plural: {manager.TranslatePlural("apple", 5)}");
        }

        /// <summary>
        ///     Example 5: Fallback languages
        /// </summary>
        private static void FallbackLanguages(TranslationManager manager)
        {
            // Add specialized English variants
            manager.AddLanguage("English (US)", "en-US");
            manager.AddLanguage("English (GB)", "en-GB");

            // Add translation only to generic English
            manager.AddTranslation("en", "color", "colour");

            // Set fallback chain
            manager.SetFallbackLanguages("en-US", "en");

            // Try to translate with fallback
            manager.SetLanguage("en-US");
            Console.WriteLine($"en-US (with fallback to en): {manager.Translate("color", "not found")}");
        }

        /// <summary>
        ///     Example 6: Observer pattern
        /// </summary>
        private static void ObserverPattern(TranslationManager manager)
        {
            ConsoleTranslationObserver observer = new ConsoleTranslationObserver();
            manager.Subscribe(observer);

            Console.WriteLine("Changing language to Spanish...");
            manager.SetLanguage("es");

            manager.Unsubscribe(observer);
            Console.WriteLine("Observer unsubscribed");
        }

        /// <summary>
        ///     Example 7: Error handling
        /// </summary>
        private static void ErrorHandling(TranslationManager manager)
        {
            manager.SetLanguage("en");

            // Method 1: Use default value
            string result1 = manager.Translate("nonexistent_key", "Default Value");
            Console.WriteLine($"With default value: {result1}");

            // Method 2: Handle exception
            try
            {
                manager.Translate("another_missing_key");
            }
            catch (TranslationNotFound ex)
            {
                Console.WriteLine($"Caught exception: {ex.Message}");
            }
        }

        /// <summary>
        ///     Console-based implementation of ITranslationObserver
        /// </summary>
        private class ConsoleTranslationObserver : ITranslationObserver
        {
            /// <summary>
            ///     Called when language is changed
            /// </summary>
            public void OnLanguageChanged(ILanguage language)
            {
                Console.WriteLine($"  [Observer] Language changed: {language.Code} - {language.Name}");
            }

            /// <summary>
            ///     Called when translations are updated
            /// </summary>
            public void OnTranslationsUpdated(string languageCode)
            {
                Console.WriteLine($"  [Observer] Translations updated for: {languageCode}");
            }

            /// <summary>
            ///     Called when translation is not found
            /// </summary>
            public void OnTranslationNotFound(string languageCode, string key)
            {
                Console.WriteLine($"  [Observer] Translation not found: {languageCode}/{key}");
            }
        }
    }
}