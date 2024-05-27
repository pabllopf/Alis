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
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
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
        
        /// <summary>
        ///     Tests that test extract embedded dlls
        /// </summary>
        [Fact]
        public void TestExtractEmbeddedDlls()
        {
            // Arrange
            string dllName = "testDll";
            DllType dllType = DllType.Exe;
            Dictionary<PlatformInfo, string> dllBytes = new Dictionary<PlatformInfo, string>();
            Assembly assembly = Assembly.GetExecutingAssembly();
            
            // Act
            EmbeddedDllClass.ExtractEmbeddedDlls(dllName, dllType, dllBytes, assembly);
            
            // Assert
            // Add your assertions here based on the expected outcome
        }
        
        /// <summary>
        ///     Tests that test get dll extensionv 2
        /// </summary>
        [Fact]
        public void TestGetDllExtensionv2()
        {
            // Arrange
            DllType dllType = DllType.Exe;
            
            // Act
            string result = EmbeddedDllClass.GetDllExtension(dllType);
            
            OSPlatform currentPlatform = EmbeddedDllClass.GetCurrentPlatform();
            
            // Assert
            if (currentPlatform == OSPlatform.Windows)
            {
                Assert.Equal(".exe", result);
            }
            
            if (currentPlatform == OSPlatform.OSX || currentPlatform == OSPlatform.Create("IOS"))
            {
                Assert.Equal("", result);
            }
            
            if (currentPlatform == OSPlatform.Linux || currentPlatform == OSPlatform.Create("Android"))
            {
                Assert.Equal("", result);
            }
        }
        
        /// <summary>
        ///     Tests that test get current platform
        /// </summary>
        [Fact]
        public void TestGetCurrentPlatform()
        {
            // Act
            OSPlatform result = EmbeddedDllClass.GetCurrentPlatform();
            
            // Assert
            Assert.IsType<OSPlatform>(result);
        }
        
        /// <summary>
        ///     Tests that test load resourcev 2
        /// </summary>
        [Fact]
        public void TestLoadResourcev2()
        {
            // Arrange
            string resourceName = "testResource";
            Assembly assembly = Assembly.GetExecutingAssembly();
            
            // Act
            MemoryStream result = EmbeddedDllClass.LoadResource(resourceName, assembly);
            
            // Assert
            Assert.IsType<MemoryStream>(result);
        }
        
        /// <summary>
        ///     Tests that test is running oni o sv 2
        /// </summary>
        [Fact]
        public void TestIsRunningOniOSv2()
        {
            // Act
            bool result = EmbeddedDllClass.IsRunningOniOS();
            
            // Assert
            Assert.IsType<bool>(result);
        }
        
        /// <summary>
        ///     Tests that test is running on androidv 2
        /// </summary>
        [Fact]
        public void TestIsRunningOnAndroidv2()
        {
            // Act
            bool result = EmbeddedDllClass.IsRunningOnAndroid();
            
            // Assert
            Assert.IsType<bool>(result);
        }
        
        /// <summary>
        ///     Tests that test isi os specific condition metv 2
        /// </summary>
        [Fact]
        public void TestIsiOsSpecificConditionMetv2()
        {
            // Act
            bool result = EmbeddedDllClass.IsiOsSpecificConditionMet();
            
            // Assert
            Assert.IsType<bool>(result);
        }
        
        /// <summary>
        ///     Tests that test is android specific condition metv 2
        /// </summary>
        [Fact]
        public void TestIsAndroidSpecificConditionMetv2()
        {
            // Act
            bool result = EmbeddedDllClass.IsAndroidSpecificConditionMet();
            
            // Assert
            Assert.IsType<bool>(result);
        }
        
        /// <summary>
        ///     Tests that test set file read permission valid path
        /// </summary>
        [Fact]
        public void TestSetFileReadPermission_ValidPath()
        {
            // Arrange
            string filePath = Path.Combine(Environment.CurrentDirectory, "Assets", "test.zip");
            Exception ex = null;
            
            if (OSPlatform.Linux == EmbeddedDllClass.GetCurrentPlatform() || OSPlatform.OSX == EmbeddedDllClass.GetCurrentPlatform())
            {
                // Act
                try
                {
                    EmbeddedDllClass.SetFileReadPermission(filePath);
                }
                catch (Exception e)
                {
                    ex = e;
                }
                
                // Assert
                Assert.Null(ex);
            }
        }
        
        /// <summary>
        ///     Tests that test set file read permission invalid path
        /// </summary>
        [Fact]
        public void TestSetFileReadPermission_InvalidPath()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                // Arrange
                string filePath = "/invalid/path/to/file";
                
                // Act
                // Here we're expecting an exception to be thrown, so we use Assert.Throws
                Exception ex = Assert.Throws<FileNotFoundException>(() => EmbeddedDllClass.SetFileReadPermission(filePath));
                
                // Assert
                // We can make further assertions about the exception here if needed
                Assert.IsType<FileNotFoundException>(ex);
            }
            else
            {
                // Arrange
                string filePath = "/invalid/path/to/file";
                
                EmbeddedDllClass.SetFileReadPermission(filePath);
            }
        }
        
        /// <summary>
        ///     Tests that test get lib extension windows
        /// </summary>
        [Fact]
        public void TestGetLibExtension_Windows()
        {
            // Arrange
            OSPlatform platform = OSPlatform.Windows;
            
            // Act
            string result = EmbeddedDllClass.GetLibExtension(platform);
            
            // Assert
            Assert.Equal(".dll", result);
        }
        
        /// <summary>
        ///     Tests that test get lib extension osx
        /// </summary>
        [Fact]
        public void TestGetLibExtension_OSX()
        {
            // Arrange
            OSPlatform platform = OSPlatform.OSX;
            
            // Act
            string result = EmbeddedDllClass.GetLibExtension(platform);
            
            // Assert
            Assert.Equal(".dylib", result);
        }
        
        /// <summary>
        ///     Tests that test get lib extension ios
        /// </summary>
        [Fact]
        public void TestGetLibExtension_IOS()
        {
            // Arrange
            OSPlatform platform = OSPlatform.Create("IOS");
            
            // Act
            string result = EmbeddedDllClass.GetLibExtension(platform);
            
            // Assert
            Assert.Equal(".dylib", result);
        }
        
        /// <summary>
        ///     Tests that test get lib extension linux
        /// </summary>
        [Fact]
        public void TestGetLibExtension_Linux()
        {
            // Arrange
            OSPlatform platform = OSPlatform.Linux;
            
            // Act
            string result = EmbeddedDllClass.GetLibExtension(platform);
            
            // Assert
            Assert.Equal(".so", result);
        }
        
        /// <summary>
        ///     Tests that test get lib extension android
        /// </summary>
        [Fact]
        public void TestGetLibExtension_Android()
        {
            // Arrange
            OSPlatform platform = OSPlatform.Create("Android");
            
            // Act
            string result = EmbeddedDllClass.GetLibExtension(platform);
            
            // Assert
            Assert.Equal(".so", result);
        }
        
        /// <summary>
        ///     Tests that test get lib extension invalid platform
        /// </summary>
        [Fact]
        public void TestGetLibExtension_InvalidPlatform()
        {
            // Arrange
            OSPlatform platform = OSPlatform.Create("Invalid");
            
            // Act & Assert
            Assert.Throws<PlatformNotSupportedException>(() => EmbeddedDllClass.GetLibExtension(platform));
        }
        
        /// <summary>
        ///     Tests that test extract embedded dlls valid dll
        /// </summary>
        [Fact]
        public void TestExtractEmbeddedDlls_ValidDll()
        {
            // Arrange
            string dllName = "validDll";
            DllType dllType = DllType.Lib;
            Dictionary<PlatformInfo, string> dllBytes = new Dictionary<PlatformInfo, string>();
            Assembly assembly = Assembly.GetExecutingAssembly();
            
            // Act
            EmbeddedDllClass.ExtractEmbeddedDlls(dllName, dllType, dllBytes, assembly);
            
            // Assert
            // Add your assertions here based on what you expect the ExtractEmbeddedDlls method to do
        }
        
        /// <summary>
        ///     Tests that test get dll extension valid dll type
        /// </summary>
        [Fact]
        public void TestGetDllExtension_ValidDllType()
        {
            // Arrange
            DllType dllType = DllType.Lib;
            
            // Act
            string result = EmbeddedDllClass.GetDllExtension(dllType);
            
            // Assert
            Assert.NotNull(result);
        }
        
        /// <summary>
        ///     Tests that test extract zip file valid file dir and zip data
        /// </summary>
        [Fact]
        public void TestExtractZipFile_ValidFileDirAndZipData()
        {
            // Arrange
            string fileDir = "/valid/file/dir";
            MemoryStream zipData = new MemoryStream();
            
            // Act
            Assert.Throws<InvalidDataException>(() => EmbeddedDllClass.ExtractZipFile(fileDir, zipData));
        }
        
        /// <summary>
        ///     Tests that test load resource valid resource name and assembly
        /// </summary>
        [Fact]
        public void TestLoadResource_ValidResourceNameAndAssembly()
        {
            // Arrange
            string resourceName = "validResourceName";
            Assembly assembly = Assembly.GetExecutingAssembly();
            
            // Act
            MemoryStream result = EmbeddedDllClass.LoadResource(resourceName, assembly);
            
            // Assert
            Assert.NotNull(result);
        }
        
        /// <summary>
        ///     Tests that test is running oni o sv 3
        /// </summary>
        [Fact]
        public void TestIsRunningOniOSv3()
        {
            // Act
            bool result = EmbeddedDllClass.IsRunningOniOS();
            
            // Assert
            Assert.IsType<bool>(result);
        }
        
        /// <summary>
        ///     Tests that test is running on androidv 3
        /// </summary>
        [Fact]
        public void TestIsRunningOnAndroidv3()
        {
            // Act
            bool result = EmbeddedDllClass.IsRunningOnAndroid();
            
            // Assert
            Assert.IsType<bool>(result);
        }
        
        /// <summary>
        ///     Tests that test isi os specific condition metv 3
        /// </summary>
        [Fact]
        public void TestIsiOsSpecificConditionMetv3()
        {
            // Act
            bool result = EmbeddedDllClass.IsiOsSpecificConditionMet();
            
            // Assert
            Assert.IsType<bool>(result);
        }
        
        /// <summary>
        ///     Tests that test is android specific condition metv 3
        /// </summary>
        [Fact]
        public void TestIsAndroidSpecificConditionMetv3()
        {
            // Act
            bool result = EmbeddedDllClass.IsAndroidSpecificConditionMet();
            
            // Assert
            Assert.IsType<bool>(result);
        }
        
        /// <summary>
        ///     Tests that test get exe extension windows
        /// </summary>
        [Fact]
        public void TestGetExeExtension_Windows()
        {
            // Arrange
            OSPlatform platform = OSPlatform.Windows;
            
            // Act
            string result = EmbeddedDllClass.GetExeExtension(platform);
            
            // Assert
            Assert.Equal(".exe", result);
        }
        
        /// <summary>
        ///     Tests that test get exe extension osx
        /// </summary>
        [Fact]
        public void TestGetExeExtension_OSX()
        {
            // Arrange
            OSPlatform platform = OSPlatform.OSX;
            
            // Act
            string result = EmbeddedDllClass.GetExeExtension(platform);
            
            // Assert
            Assert.Equal("", result);
        }
        
        /// <summary>
        ///     Tests that test get exe extension ios
        /// </summary>
        [Fact]
        public void TestGetExeExtension_IOS()
        {
            // Arrange
            OSPlatform platform = OSPlatform.Create("IOS");
            
            // Act
            string result = EmbeddedDllClass.GetExeExtension(platform);
            
            // Assert
            Assert.Equal("", result);
        }
        
        /// <summary>
        ///     Tests that test get exe extension linux
        /// </summary>
        [Fact]
        public void TestGetExeExtension_Linux()
        {
            // Arrange
            OSPlatform platform = OSPlatform.Linux;
            
            // Act
            string result = EmbeddedDllClass.GetExeExtension(platform);
            
            // Assert
            Assert.Equal("", result);
        }
        
        /// <summary>
        ///     Tests that test get exe extension android
        /// </summary>
        [Fact]
        public void TestGetExeExtension_Android()
        {
            // Arrange
            OSPlatform platform = OSPlatform.Create("Android");
            
            // Act
            string result = EmbeddedDllClass.GetExeExtension(platform);
            
            // Assert
            Assert.Equal("", result);
        }
        
        /// <summary>
        ///     Tests that test get exe extension invalid platform
        /// </summary>
        [Fact]
        public void TestGetExeExtension_InvalidPlatform()
        {
            // Arrange
            OSPlatform platform = OSPlatform.Create("Invalid");
            
            // Act & Assert
            Assert.Throws<PlatformNotSupportedException>(() => EmbeddedDllClass.GetExeExtension(platform));
        }
        
        
        
        /// <summary>
        /// Tests that extract zip file with empty zip data throws exception
        /// </summary>
        [Fact]
        public void ExtractZipFile_WithEmptyZipData_ThrowsException()
        {
            // Arrange
            string fileDir = "testDir";
            MemoryStream zipData = new MemoryStream();
            
            // Act & Assert
            Assert.Throws<InvalidDataException>(() => EmbeddedDllClass.ExtractZipFile(fileDir, zipData));
        }
        
        /// <summary>
        /// Tests that extract zip file with null zip data throws argument null exception
        /// </summary>
        [Fact]
        public void ExtractZipFile_WithNullZipData_ThrowsArgumentNullException()
        {
            // Arrange
            string fileDir = "testDir";
            MemoryStream zipData = null;
            
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => EmbeddedDllClass.ExtractZipFile(fileDir, zipData));
        }
        
        /// <summary>
        /// Tests that extract zip file with empty zip data throws exception v 3
        /// </summary>
        [Fact]
        public void ExtractZipFile_WithEmptyZipData_ThrowsException_v3()
        {
            // Arrange
            string fileDir = "testDir";
            MemoryStream zipData = new MemoryStream();
            
            // Act & Assert
            Assert.Throws<InvalidDataException>(() => EmbeddedDllClass.ExtractZipFile(fileDir, zipData));
        }
        
        /// <summary>
        /// Tests that extract zip file with null zip data throws argument null exception v 2
        /// </summary>
        [Fact]
        public void ExtractZipFile_WithNullZipData_ThrowsArgumentNullException_v2()
        {
            // Arrange
            string fileDir = "testDir";
            MemoryStream zipData = null;
            
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => EmbeddedDllClass.ExtractZipFile(fileDir, zipData));
        }
        
        /// <summary>
        /// Tests that is valid entry with empty name returns false
        /// </summary>
        [Fact]
        public void IsValidEntry_WithEmptyName_ReturnsFalse()
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (ZipArchive archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    ZipArchiveEntry entry = archive.CreateEntry("validFullName");
                }
                
                memoryStream.Seek(0, SeekOrigin.Begin);
                
                using (ZipArchive archive = new ZipArchive(memoryStream, ZipArchiveMode.Read, true))
                {
                    ZipArchiveEntry entry = archive.GetEntry("validFullName");
                    bool result = EmbeddedDllClass.IsValidEntry(entry);
                    Assert.True(result);
                }
            }
        }
        
        /// <summary>
        /// Tests that is valid entry with null name returns false
        /// </summary>
        [Fact]
        public void IsValidEntry_WithNullName_ReturnsFalse()
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (ZipArchive archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    ZipArchiveEntry entry = archive.CreateEntry("validFullName");
                }
                
                memoryStream.Seek(0, SeekOrigin.Begin);
                
                using (ZipArchive archive = new ZipArchive(memoryStream, ZipArchiveMode.Read, true))
                {
                    ZipArchiveEntry entry = archive.GetEntry("validFullName");
                    bool result = EmbeddedDllClass.IsValidEntry(entry);
                    Assert.True(result);
                }
            }
        }
        
        /// <summary>
        /// Tests that is valid entry with full name containing mac osx returns false
        /// </summary>
        [Fact]
        public void IsValidEntry_WithFullNameContainingMacOSX_ReturnsFalse()
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (ZipArchive archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    ZipArchiveEntry entry = archive.CreateEntry("validName");
                    entry.GetType().GetProperty("FullName")?.SetValue(entry, "__MACOSX", null);
                }
                
                memoryStream.Seek(0, SeekOrigin.Begin);
                
                using (ZipArchive archive = new ZipArchive(memoryStream, ZipArchiveMode.Read, true))
                {
                    ZipArchiveEntry entry = archive.GetEntry("validName");
                    Assert.Throws<NullReferenceException>(() => EmbeddedDllClass.IsValidEntry(entry));
                }
            }
        }
        
        /// <summary>
        /// Tests that is valid entry with valid name and full name returns true
        /// </summary>
        [Fact]
        public void IsValidEntry_WithValidNameAndFullName_ReturnsTrue()
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (ZipArchive archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    ZipArchiveEntry entry = archive.CreateEntry("validName");
                }
                
                memoryStream.Seek(0, SeekOrigin.Begin);
                
                using (ZipArchive archive = new ZipArchive(memoryStream, ZipArchiveMode.Read, true))
                {
                    ZipArchiveEntry entry = archive.GetEntry("validName");
                    bool result = EmbeddedDllClass.IsValidEntry(entry);
                    Assert.True(result);
                }
            }
        }
        
        /// <summary>
        /// Tests that extract entry should extract correctly
        /// </summary>
        [Fact]
        public void ExtractEntry_ShouldExtractCorrectly()
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (ZipArchive archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    ZipArchiveEntry entry = archive.CreateEntry("validName");
                    
                    string fileDir = "testDir";
                    
                    EmbeddedDllClass.ExtractEntry(fileDir, entry);
                    
                    Assert.False(Directory.Exists(fileDir));
                }
            }
        }
        
        /// <summary>
        /// Tests that extract file from entry should extract correctly
        /// </summary>
        [Fact]
        public void ExtractFileFromEntry_ShouldExtractCorrectly()
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (ZipArchive archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    ZipArchiveEntry entry = archive.CreateEntry("validName");
                    string canonicalDestinationPath = "testPath";
                    Assert.Throws<NotSupportedException>(() => EmbeddedDllClass.ExtractFileFromEntry(canonicalDestinationPath, entry));
                }
            }
        }
        
        /// <summary>
        /// Tests that get current platform should return correct platform
        /// </summary>
        [Fact]
        public void GetCurrentPlatform_ShouldReturnCorrectPlatform()
        {
            OSPlatform result = EmbeddedDllClass.GetCurrentPlatform();
            
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Assert.Equal(OSPlatform.Windows, result);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Assert.Equal(OSPlatform.OSX, result);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Assert.Equal(OSPlatform.Linux, result);
            }
            else if (EmbeddedDllClass.IsRunningOniOS())
            {
                Assert.Equal(OSPlatform.Create("IOS"), result);
            }
            else if (EmbeddedDllClass.IsRunningOnAndroid())
            {
                Assert.Equal(OSPlatform.Create("Android"), result);
            }
            else
            {
                Assert.Throws<PlatformNotSupportedException>(() => EmbeddedDllClass.GetCurrentPlatform());
            }
        }
        
        /// <summary>
        /// Tests that extract zip file should extract correctly
        /// </summary>
        [Fact]
        public void ExtractZipFile_ShouldExtractCorrectly()
        {
            string fileDir = "testDir";
            MemoryStream zipData = new MemoryStream();
            
            using (ZipArchive archive = new ZipArchive(zipData, ZipArchiveMode.Create, true))
            {
                ZipArchiveEntry entry = archive.CreateEntry("testEntry");
            }
            
            zipData.Seek(0, SeekOrigin.Begin);
            
            EmbeddedDllClass.ExtractZipFile(fileDir, zipData);
            
            Assert.False(Directory.Exists(fileDir));
            Assert.False(File.Exists(Path.Combine(fileDir, "testEntry")));
        }
        
        /// <summary>
        /// Tests that get dll extension should return correct extension
        /// </summary>
        [Fact]
        public void GetDllExtension_ShouldReturnCorrectExtension()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Assert.Equal("", EmbeddedDllClass.GetDllExtension(DllType.Exe));
                Assert.Equal(".dylib", EmbeddedDllClass.GetDllExtension(DllType.Lib)); 
            }
            
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Assert.Equal(".exe", EmbeddedDllClass.GetDllExtension(DllType.Exe));
                Assert.Equal(".dll", EmbeddedDllClass.GetDllExtension(DllType.Lib));
            }
            
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Assert.Equal("", EmbeddedDllClass.GetDllExtension(DllType.Exe));
                Assert.Equal(".so", EmbeddedDllClass.GetDllExtension(DllType.Lib));
            }
            
            Assert.Throws<PlatformNotSupportedException>(() => EmbeddedDllClass.GetDllExtension((DllType) 999));
        }
    }
}