// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EmbeddedDllClassTest.cs
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
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Data.Dll;
using Xunit;

namespace Alis.Core.Aspect.Data.Test.Dll
{
    /// <summary>
    ///     The embedded dll class test class
    /// </summary>
    public class EmbeddedDllClassTest
    {
        /// <summary>
        ///     Tests that test load resource
        /// </summary>
        [Fact]
        public void TestLoadResource()
        {
            string resourceName = "TestResource";
            Assembly assembly = Assembly.GetExecutingAssembly();

            MemoryStream result = EmbeddedDllClass.LoadResource(resourceName, assembly);

            // Replace with the correct expected result
            MemoryStream expectedResult = new MemoryStream();

            Assert.Equal(expectedResult.ToArray(), result.ToArray());
        }

        /// <summary>
        ///     Tests that test is running oni os
        /// </summary>
        [Fact]
        public void TestIsRunningOniOS()
        {
            bool result = EmbeddedDllClass.IsRunningOniOS();

            // Replace with the correct expected result
            bool expectedResult = false;

            Assert.Equal(expectedResult, result);
        }

        /// <summary>
        ///     Tests that test is running on android
        /// </summary>
        [Fact]
        public void TestIsRunningOnAndroid()
        {
            bool result = EmbeddedDllClass.IsRunningOnAndroid();

            // Replace with the correct expected result
            bool expectedResult = false;

            Assert.Equal(expectedResult, result);
        }

        /// <summary>
        ///     Tests that test isi os specific condition met
        /// </summary>
        [Fact]
        public void TestIsiOsSpecificConditionMet()
        {
            bool result = EmbeddedDllClass.IsiOsSpecificConditionMet();

            // Replace with the correct expected result
            bool expectedResult = false;

            Assert.Equal(expectedResult, result);
        }

        /// <summary>
        ///     Tests that test is android specific condition met
        /// </summary>
        [Fact]
        public void TestIsAndroidSpecificConditionMet()
        {
            bool result = EmbeddedDllClass.IsAndroidSpecificConditionMet();

            // Replace with the correct expected result
            bool expectedResult = false;

            Assert.Equal(expectedResult, result);
        }

        /// <summary>
        ///     Tests that test get dll extension
        /// </summary>
        /// <exception cref="PlatformNotSupportedException">Unsupported platform.</exception>
        [Fact]
        public void TestGetDllExtension()
        {
            // Arrange
            OSPlatform currentPlatform = EmbeddedDllClass.GetCurrentPlatform();
            string expectedExtension;

            if (currentPlatform == OSPlatform.Windows)
            {
                expectedExtension = ".dll";
            }
            else if (currentPlatform == OSPlatform.OSX || currentPlatform == OSPlatform.Create("IOS"))
            {
                expectedExtension = ".dylib";
            }
            else if (currentPlatform == OSPlatform.Linux || currentPlatform == OSPlatform.Create("Android"))
            {
                expectedExtension = ".so";
            }
            else
            {
                throw new PlatformNotSupportedException("Unsupported platform.");
            }

            // Act
            string resultExtension = EmbeddedDllClass.GetDllExtension(DllType.Lib);

            // Assert
            Assert.Equal(expectedExtension, resultExtension);
        }
    }
}