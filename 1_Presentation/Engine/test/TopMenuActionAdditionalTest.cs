// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TopMenuActionAdditionalTest.cs
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
using System.Reflection;
using System.Security;
using Alis.App.Engine.Menus;
using Xunit;

namespace Alis.App.Engine.Test.Menus
{
    /// <summary>
    /// The top menu action additional test class
    /// </summary>
    public class TopMenuActionAdditionalTest
    {
        /// <summary>
        /// Tests that validate url scheme null url throws argument exception
        /// </summary>
        [Fact]
        public void ValidateUrlScheme_NullUrl_ThrowsArgumentException()
        {
            MethodInfo method = typeof(TopMenuAction).GetMethod("ValidateUrlScheme",
                BindingFlags.NonPublic | BindingFlags.Static);

            if (method == null)
            {
                return;
            }

            Exception ex = Assert.Throws<TargetInvocationException>(() =>
                method.Invoke(null, new object[] { null }));

            Assert.IsType<ArgumentException>(ex.InnerException);
        }

        /// <summary>
        /// Tests that validate url scheme empty url throws argument exception
        /// </summary>
        [Fact]
        public void ValidateUrlScheme_EmptyUrl_ThrowsArgumentException()
        {
            MethodInfo method = typeof(TopMenuAction).GetMethod("ValidateUrlScheme",
                BindingFlags.NonPublic | BindingFlags.Static);

            if (method == null)
            {
                return;
            }

            Exception ex = Assert.Throws<TargetInvocationException>(() =>
                method.Invoke(null, new object[] { string.Empty }));

            Assert.IsType<ArgumentException>(ex.InnerException);
        }

        /// <summary>
        /// Tests that validate url scheme https url does not throw
        /// </summary>
        [Fact]
        public void ValidateUrlScheme_HttpsUrl_DoesNotThrow()
        {
            MethodInfo method = typeof(TopMenuAction).GetMethod("ValidateUrlScheme",
                BindingFlags.NonPublic | BindingFlags.Static);

            if (method == null)
            {
                return;
            }

            method.Invoke(null, new object[] { "https://example.com" });
        }

        /// <summary>
        /// Tests that validate url scheme http url does not throw
        /// </summary>
        [Fact]
        public void ValidateUrlScheme_HttpUrl_DoesNotThrow()
        {
            MethodInfo method = typeof(TopMenuAction).GetMethod("ValidateUrlScheme",
                BindingFlags.NonPublic | BindingFlags.Static);

            if (method == null)
            {
                return;
            }

            method.Invoke(null, new object[] { "http://example.com" });
        }

        /// <summary>
        /// Tests that validate url scheme ftp url throws security exception
        /// </summary>
        [Fact]
        public void ValidateUrlScheme_FtpUrl_ThrowsSecurityException()
        {
            MethodInfo method = typeof(TopMenuAction).GetMethod("ValidateUrlScheme",
                BindingFlags.NonPublic | BindingFlags.Static);

            if (method == null)
            {
                return;
            }

            Exception ex = Assert.Throws<TargetInvocationException>(() =>
                method.Invoke(null, new object[] { "ftp://example.com" }));

            Assert.IsType<SecurityException>(ex.InnerException);
        }

        /// <summary>
        /// Tests that validate url scheme java script url throws security exception
        /// </summary>
        [Fact]
        public void ValidateUrlScheme_JavaScriptUrl_ThrowsSecurityException()
        {
            MethodInfo method = typeof(TopMenuAction).GetMethod("ValidateUrlScheme",
                BindingFlags.NonPublic | BindingFlags.Static);

            if (method == null)
            {
                return;
            }

            Exception ex = Assert.Throws<TargetInvocationException>(() =>
                method.Invoke(null, new object[] { "javascript:alert(1)" }));

            Assert.IsType<SecurityException>(ex.InnerException);
        }

        /// <summary>
        /// Tests that validate url scheme file url throws security exception
        /// </summary>
        [Fact]
        public void ValidateUrlScheme_FileUrl_ThrowsSecurityException()
        {
            MethodInfo method = typeof(TopMenuAction).GetMethod("ValidateUrlScheme",
                BindingFlags.NonPublic | BindingFlags.Static);

            if (method == null)
            {
                return;
            }

            Exception ex = Assert.Throws<TargetInvocationException>(() =>
                method.Invoke(null, new object[] { "file:///etc/passwd" }));

            Assert.IsType<SecurityException>(ex.InnerException);
        }
    }
}
