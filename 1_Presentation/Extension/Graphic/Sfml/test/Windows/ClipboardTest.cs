// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ClipboardTest.cs
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

using System.Reflection;
using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    ///     Unit tests for the Clipboard class.
    /// </summary>
    public class ClipboardTest
    {
        /// <summary>
        ///     Tests that clipboard is a static class.
        /// </summary>
        [Fact]
        public void Clipboard_IsStaticClass()
        {
            Assert.True(typeof(Clipboard).IsAbstract && typeof(Clipboard).IsSealed);
        }

        /// <summary>
        ///     Tests that contents property exists.
        /// </summary>
        [Fact]
        public void Contents_Property_Exists()
        {
            PropertyInfo property = typeof(Clipboard).GetProperty("Contents");
            Assert.NotNull(property);
        }

        /// <summary>
        ///     Tests that contents property has getter and setter.
        /// </summary>
        [Fact]
        public void Contents_Property_Has_Getter_And_Setter()
        {
            PropertyInfo property = typeof(Clipboard).GetProperty("Contents");
            Assert.NotNull(property);
            Assert.True(property.CanRead);
            Assert.True(property.CanWrite);
        }

        /// <summary>
        ///     Tests that contents property type is string.
        /// </summary>
        [Fact]
        public void Contents_Property_Type_Is_String()
        {
            PropertyInfo property = typeof(Clipboard).GetProperty("Contents");
            Assert.NotNull(property);
            Assert.Equal(typeof(string), property.PropertyType);
        }

        /// <summary>
        ///     Tests that sfClipboard_getUnicodeString dll import method exists.
        /// </summary>
        [Fact]
        public void SfClipboard_getUnicodeString_DllImport_Exists()
        {
            MethodInfo[] methods = typeof(Clipboard).GetMethods(BindingFlags.Static | BindingFlags.NonPublic);
            MethodInfo method = null;
            foreach (MethodInfo mi in methods)
            {
                if (mi.Name.Contains("sfClipboard_getUnicodeString"))
                {
                    method = mi;
                    break;
                }
            }
            Assert.NotNull(method);
            Assert.NotNull(method.GetCustomAttribute<DllImportAttribute>());
        }

        /// <summary>
        ///     Tests that sfClipboard_setUnicodeString dll import method exists.
        /// </summary>
        [Fact]
        public void SfClipboard_setUnicodeString_DllImport_Exists()
        {
            MethodInfo[] methods = typeof(Clipboard).GetMethods(BindingFlags.Static | BindingFlags.NonPublic);
            MethodInfo method = null;
            foreach (MethodInfo mi in methods)
            {
                if (mi.Name.Contains("sfClipboard_setUnicodeString"))
                {
                    method = mi;
                    break;
                }
            }
            Assert.NotNull(method);
            Assert.NotNull(method.GetCustomAttribute<DllImportAttribute>());
        }

        /// <summary>
        ///     Tests that GetContents returns a string.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void GetContents_ReturnsString()
        {
            string result = Clipboard.Contents;
            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that SetContents does not throw.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void SetContents_DoesNotThrow()
        {
            Clipboard.Contents = "test";
        }

        /// <summary>
        ///     Tests that set and get contents round trips correctly.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void SetAndGetContents_RoundTrip()
        {
            const string expected = "Hello, Clipboard!";
            Clipboard.Contents = expected;
            string actual = Clipboard.Contents;
            Assert.Equal(expected, actual);
        }

        /// <summary>
        ///     Tests that set and get contents works with unicode text.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void SetAndGetContents_UnicodeText()
        {
            const string expected = "¡Hola! ñoño 中文 𝄞";
            Clipboard.Contents = expected;
            string actual = Clipboard.Contents;
            Assert.Equal(expected, actual);
        }

        /// <summary>
        ///     Tests that set and get contents works with empty string.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void SetAndGetContents_EmptyString()
        {
            Clipboard.Contents = string.Empty;
            string actual = Clipboard.Contents;
            Assert.Equal(string.Empty, actual);
        }

        /// <summary>
        ///     Tests that set and get contents works with long string.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void SetAndGetContents_LongString()
        {
            string expected = new string('A', 10000);
            Clipboard.Contents = expected;
            string actual = Clipboard.Contents;
            Assert.Equal(expected, actual);
        }
    }
}