// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SecureStringCoverageTest.cs
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

using System.Linq;
using System.Reflection;
using Xunit;

namespace Alis.Extension.Security.Test
{
    /// <summary>
    ///     Targeted coverage tests for <see cref="SecureString" />.
    ///     Covers edge cases in EncryptDecrypt, constructor, SetValue, GetValue.
    /// </summary>
    public class SecureStringCoverageTest
    {
        /// <summary>
        ///     Tests empty string round-trips correctly through encrypt/decrypt.
        ///     The xor loop over an empty buffer exits immediately.
        /// </summary>
        [Fact]
        public void EmptyString_RoundTrips()
        {
            SecureString secureString = new SecureString("");
            Assert.Equal("", secureString.GetValue());
        }

        /// <summary>
        ///     Tests single character string round-trips correctly.
        /// </summary>
        [Fact]
        public void SingleCharacter_RoundTrips()
        {
            SecureString secureString = new SecureString("A");
            Assert.Equal("A", secureString.GetValue());
        }

        /// <summary>
        ///     Tests long string round-trips correctly.
        /// </summary>
        [Fact]
        public void LongString_RoundTrips()
        {
            string longString = new string('X', 10000);
            SecureString secureString = new SecureString(longString);
            Assert.Equal(longString, secureString.GetValue());
        }

        /// <summary>
        ///     Tests string with unicode characters round-trips correctly.
        /// </summary>
        [Fact]
        public void UnicodeString_RoundTrips()
        {
            string unicode = "Hëllö Wörld 🌍 ¡Ñ!";
            SecureString secureString = new SecureString(unicode);
            Assert.Equal(unicode, secureString.GetValue());
        }

        /// <summary>
        ///     Tests string with special characters round-trips correctly.
        /// </summary>
        [Fact]
        public void SpecialCharacters_RoundTrips()
        {
            string special = "\t\r\n\0\\\"'`~!@#$%^&*()_+-=[]{}|;:',.<>?/";
            SecureString secureString = new SecureString(special);
            Assert.Equal(special, secureString.GetValue());
        }

        /// <summary>
        ///     Tests that the internal encrypted value differs from the original plaintext.
        ///     Proves that XOR encryption actually transforms the stored data.
        /// </summary>
        [Fact]
        public void EncryptedValue_DiffersFromPlaintext()
        {
            SecureString secureString = new SecureString("HelloWorld");
            FieldInfo encryptedField = typeof(SecureString).GetField("encryptedValue", BindingFlags.NonPublic | BindingFlags.Instance);
            string encrypted = (string)encryptedField.GetValue(secureString);

            Assert.NotNull(encrypted);
            Assert.NotEqual("HelloWorld", encrypted);
        }

        /// <summary>
        ///     Tests multiple SetValue/GetValue cycles maintain integrity.
        /// </summary>
        [Fact]
        public void MultipleSetValueCycles_MaintainIntegrity()
        {
            SecureString secureString = new SecureString("initial");
            Assert.Equal("initial", secureString.GetValue());

            secureString.SetValue("second");
            Assert.Equal("second", secureString.GetValue());

            secureString.SetValue("third");
            Assert.Equal("third", secureString.GetValue());

            secureString.SetValue("");
            Assert.Equal("", secureString.GetValue());
        }

        /// <summary>
        ///     Tests strings that are already all zeros round-trip correctly.
        /// </summary>
        [Fact]
        public void StringWithNullChars_RoundTrips()
        {
            string nullChars = "\0\0\0\0";
            SecureString secureString = new SecureString(nullChars);
            Assert.Equal(nullChars, secureString.GetValue());
        }

        /// <summary>
        ///     Tests that different instances produce different encrypted values
        ///     for the same plaintext (different random keys).
        /// </summary>
        [Fact]
        public void DifferentInstances_DifferentEncryptedValues()
        {
            SecureString s1 = new SecureString("test");
            SecureString s2 = new SecureString("test");

            FieldInfo encryptedField = typeof(SecureString).GetField("encryptedValue", BindingFlags.NonPublic | BindingFlags.Instance);
            string encrypted1 = (string)encryptedField.GetValue(s1);
            string encrypted2 = (string)encryptedField.GetValue(s2);

            Assert.NotEqual(encrypted1, encrypted2);
        }

        /// <summary>
        ///     Tests that whitespace-only strings round-trip correctly.
        /// </summary>
        [Fact]
        public void WhitespaceString_RoundTrips()
        {
            string whitespace = "   \t  \n  ";
            SecureString secureString = new SecureString(whitespace);
            Assert.Equal(whitespace, secureString.GetValue());
        }

        /// <summary>
        ///     Tests very long unicode string for both correctness and no stack overflow.
        /// </summary>
        [Fact]
        public void VeryLongUnicodeString_RoundTrips()
        {
            string longUnicode = string.Concat(Enumerable.Repeat("日本語のテスト", 2000));
            SecureString secureString = new SecureString(longUnicode);
            Assert.Equal(longUnicode, secureString.GetValue());
        }
    }
}
