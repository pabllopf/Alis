// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DummyTest.cs
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
    ///     Tests for Lang and translation exceptions
    /// </summary>
    public class LangAndExceptionTest
    {
        /// <summary>
        ///     Tests that NativeName and CultureCode can be assigned and read
        /// </summary>
        [Fact]
        public void Lang_SetNativeAndCulture_ShouldPersistValues()
        {
            Lang lang = new Lang("en", "English")
            {
                NativeName = "English",
                CultureCode = "en-US"
            };

            Assert.Equal("English", lang.NativeName);
            Assert.Equal("en-US", lang.CultureCode);
        }

        /// <summary>
        ///     Tests that TranslationNotFound message contains the requested key
        /// </summary>
        [Fact]
        public void TranslationNotFound_Constructor_ShouldBuildExpectedMessage()
        {
            TranslationNotFound exception = new TranslationNotFound("menu.play");

            Assert.Contains("menu.play", exception.Message);
        }
    }
}