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

using Alis.Core.Aspect.Logging;

namespace Alis.Extension.Language.Translator.Sample
{
    /// <summary>
    ///     The program class
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     Main the args
        /// </summary>
        /// <param name="args">The args</param>
        public static void Main(string[] args)
        {
            TranslationManager manager = new TranslationManager();

            manager.AddLanguage(new Language {Name = "English", Code = "en"});
            manager.AddLanguage(new Language {Name = "Spanish", Code = "es"});

            manager.AddTranslation("en", "hello", "Hello");
            manager.AddTranslation("es", "hello", "Hola");
            manager.AddTranslation("en", "world", "World");
            manager.AddTranslation("es", "world", "Mundo");

            manager.SetLanguage("Spanish", "es");
            Logger.Info($"Current language: {manager.Language.Name} - Language.Code:{manager.Language.Code} Translate result: {manager.Translate("hello")}");

            manager.SetLanguage("English", "en");
            Logger.Info($"Current language: {manager.Language.Name} - Language.Code:{manager.Language.Code} Translate result: {manager.Translate("hello")}");
        }
    }
}