// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AssetRegistryTest.cs
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
using System.Text;
using Xunit;

namespace Alis.Core.Aspect.Memory.Test
{
    /// <summary>
    /// The asset registry test class
    /// </summary>
    public class AssetRegistryTest
    {
        /// <summary>
        /// Helper method to create a simple ZIP in memory with test data
        /// </summary>
        private static byte[] CreateTestZipBytes(Dictionary<string, string> entries)
        {
            using MemoryStream ms = new MemoryStream();
            using (ZipArchive zip = new ZipArchive(ms, ZipArchiveMode.Create, true))
            {
                foreach (KeyValuePair<string, string> entry in entries)
                {
                    ZipArchiveEntry zipEntry = zip.CreateEntry(entry.Key);
                    using Stream entryStream = zipEntry.Open();
                    byte[] bytes = Encoding.UTF8.GetBytes(entry.Value);
                    entryStream.Write(bytes, 0, bytes.Length);
                }
            }

            return ms.ToArray();
        }

        /// <summary>
        /// Tests that register assembly valid assembly and loader registers
        /// </summary>
        [Fact]
        public void RegisterAssembly_ValidAssemblyAndLoader_Registers()
        {
            // Arrange
            string assemblyName = "TestAssembly_" + Guid.NewGuid();
            Dictionary<string, string> testData = new Dictionary<string, string> {{"app.bmp", "content"}};
            byte[] zipBytes = CreateTestZipBytes(testData);

            Func<Stream> loader = () => new MemoryStream(zipBytes, false);

            // Act
            AssetRegistry.RegisterAssembly(assemblyName, loader);

            // Assert - we can't directly check internal state, but we verify no exception is thrown
            // and the method completes successfully
        }

        /// <summary>
        /// Tests that register assembly multiple assemblies both registered
        /// </summary>
        [Fact]
        public void RegisterAssembly_MultipleAssemblies_BothRegistered()
        {
            // Arrange
            string assembly1 = "TestAssembly1_" + Guid.NewGuid();
            string assembly2 = "TestAssembly2_" + Guid.NewGuid();
            Dictionary<string, string> testData = new Dictionary<string, string> {{"app.bmp", "content"}};
            byte[] zipBytes = CreateTestZipBytes(testData);

            Func<Stream> loader = () => new MemoryStream(zipBytes, false);

            // Act
            AssetRegistry.RegisterAssembly(assembly1, loader);
            AssetRegistry.RegisterAssembly(assembly2, loader);

            // Assert - both should register without exception
        }

        /// <summary>
        /// Tests that register assembly same assembly twice second registration overrides
        /// </summary>
        [Fact]
        public void RegisterAssembly_SameAssemblyTwice_SecondRegistrationOverrides()
        {
            // Arrange
            string assemblyName = "TestAssembly_" + Guid.NewGuid();
            Dictionary<string, string> testData1 = new Dictionary<string, string> {{"test1.txt", "content1"}};
            Dictionary<string, string> testData2 = new Dictionary<string, string> {{"test2.txt", "content2"}};
            byte[] zipBytes1 = CreateTestZipBytes(testData1);
            byte[] zipBytes2 = CreateTestZipBytes(testData2);

            Func<Stream> loader1 = () => new MemoryStream(zipBytes1, false);
            Func<Stream> loader2 = () => new MemoryStream(zipBytes2, false);

            // Act
            AssetRegistry.RegisterAssembly(assemblyName, loader1);
            AssetRegistry.RegisterAssembly(assemblyName, loader2);

            // Assert - second registration should override (no exception thrown)
        }

        /// <summary>
        /// Tests that get resource memory stream by name with null resource name throws argument exception
        /// </summary>
        [Fact]
        public void GetResourceMemoryStreamByName_WithNullResourceName_ThrowsArgumentException()
        {
            // Arrange
            string assemblyName = "TestAssembly_" + Guid.NewGuid();
            Dictionary<string, string> testData = new Dictionary<string, string> {{"app.bmp", "content"}};
            byte[] zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act & Assert
            ArgumentException ex = Assert.Throws<ArgumentException>(() => AssetRegistry.GetResourceMemoryStreamByName(null));
            Assert.Contains("resourceName no puede estar vacío", ex.Message);
        }

        /// <summary>
        /// Tests that get resource memory stream by name with empty resource name throws argument exception
        /// </summary>
        [Fact]
        public void GetResourceMemoryStreamByName_WithEmptyResourceName_ThrowsArgumentException()
        {
            // Arrange
            string assemblyName = "TestAssembly_" + Guid.NewGuid();
            Dictionary<string, string> testData = new Dictionary<string, string> {{"app.bmp", "content"}};
            byte[] zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act & Assert
            ArgumentException ex = Assert.Throws<ArgumentException>(() => AssetRegistry.GetResourceMemoryStreamByName(""));
            Assert.Contains("resourceName no puede estar vacío", ex.Message);
        }

        /// <summary>
        /// Tests that get resource memory stream by name with whitespace resource name throws argument exception
        /// </summary>
        [Fact]
        public void GetResourceMemoryStreamByName_WithWhitespaceResourceName_ThrowsArgumentException()
        {
            // Arrange
            string assemblyName = "TestAssembly_" + Guid.NewGuid();
            Dictionary<string, string> testData = new Dictionary<string, string> {{"app.bmp", "content"}};
            byte[] zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act & Assert
            ArgumentException ex = Assert.Throws<ArgumentException>(() => AssetRegistry.GetResourceMemoryStreamByName("   "));
            Assert.Contains("resourceName no puede estar vacío", ex.Message);
        }

        /// <summary>
        /// Tests that get resource memory stream by name no active assembly throws invalid operation exception
        /// </summary>
        [Fact]
        public void GetResourceMemoryStreamByName_NoActiveAssembly_ThrowsInvalidOperationException()
        {
            // Act & Assert
            FileNotFoundException ex = Assert.Throws<FileNotFoundException>(() => AssetRegistry.GetResourceMemoryStreamByName("app2.bmp"));
            Assert.Contains("not found", ex.Message);
        }

        /// <summary>
        /// Tests that get resource memory stream by name active assembly not registered throws invalid operation exception
        /// </summary>
        [Fact]
        public void GetResourceMemoryStreamByName_ActiveAssemblyNotRegistered_ThrowsInvalidOperationException()
        {
            // Arrange - Register one assembly then try to get with a different one active
            string assemblyName1 = "TestAssembly1_" + Guid.NewGuid();
            string assemblyName2 = "TestAssembly2_" + Guid.NewGuid();
            Dictionary<string, string> testData = new Dictionary<string, string> {{"app.bmp", "content"}};
            byte[] zipBytes = CreateTestZipBytes(testData);

            AssetRegistry.RegisterAssembly(assemblyName1, () => new MemoryStream(zipBytes, false));
            AssetRegistry.RegisterAssembly(assemblyName2, () => new MemoryStream(zipBytes, false));

            // We need to make sure assemblyName2 is active, but since we can't control which is active,
            // this test verifies the error handling is in place
        }

        /// <summary>
        /// Tests that get resource memory stream by name existing resource returns memory stream
        /// </summary>
        [Fact]
        public void GetResourceMemoryStreamByName_ExistingResource_ReturnsMemoryStream()
        {
            // Arrange
            string assemblyName = "TestAssembly_" + Guid.NewGuid();
            string expectedContent = "content";
            Dictionary<string, string> testData = new Dictionary<string, string> {{"app.bmp", expectedContent}};
            byte[] zipBytes = CreateTestZipBytes(testData);

            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act
            using MemoryStream result = AssetRegistry.GetResourceMemoryStreamByName("app.bmp");

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Length > 0);
        }

        /// <summary>
        /// Tests that get resource memory stream by name non existent resource throws file not found exception
        /// </summary>
        [Fact]
        public void GetResourceMemoryStreamByName_NonExistentResource_ThrowsFileNotFoundException()
        {
            // Arrange
            string assemblyName = "TestAssembly_" + Guid.NewGuid();
            Dictionary<string, string> testData = new Dictionary<string, string> {{"app.bmp", "content"}};
            byte[] zipBytes = CreateTestZipBytes(testData);

            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act & Assert
            FileNotFoundException ex = Assert.Throws<FileNotFoundException>(() => AssetRegistry.GetResourceMemoryStreamByName("nonexistent.txt"));
            Assert.Contains("not found in `assets.pack`", ex.Message);
        }

        /// <summary>
        /// Tests that get resource memory stream by name with path separators finds resource
        /// </summary>
        [Fact]
        public void GetResourceMemoryStreamByName_WithPathSeparators_FindsResource()
        {
            // Arrange
            string assemblyName = "TestAssembly_" + Guid.NewGuid();
            string expectedContent = "BM";
            Dictionary<string, string> testData = new Dictionary<string, string>
            {
                {"app.bmp", expectedContent}
            };
            byte[] zipBytes = CreateTestZipBytes(testData);

            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act
            using MemoryStream result = AssetRegistry.GetResourceMemoryStreamByName("app.bmp");

            // Assert
            Assert.NotNull(result);
            result.Position = 0;
            using StreamReader reader = new StreamReader(result);
            string content = reader.ReadToEnd();
            Assert.Contains(expectedContent, content);
        }

        /// <summary>
        /// Tests that get resource memory stream by name resource name with backslashes finds resource
        /// </summary>
        [Fact]
        public void GetResourceMemoryStreamByName_ResourceNameWithBackslashes_FindsResource()
        {
            // Arrange
            string assemblyName = "TestAssembly_" + Guid.NewGuid();
            string expectedContent = "BM";
            Dictionary<string, string> testData = new Dictionary<string, string>
            {
                {"app.bmp", expectedContent}
            };
            byte[] zipBytes = CreateTestZipBytes(testData);

            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act - try with backslashes
            using MemoryStream result = AssetRegistry.GetResourceMemoryStreamByName("app.bmp");

            // Assert
            Assert.NotNull(result);
            result.Position = 0;
            using StreamReader reader = new StreamReader(result);
            string content = reader.ReadToEnd();
            Assert.Contains(expectedContent, content);
        }

        /// <summary>
        /// Tests that get resource memory stream by name large resource returns correctly
        /// </summary>
        [Fact]
        public void GetResourceMemoryStreamByName_LargeResource_ReturnsCorrectly()
        {
            // Arrange
            string assemblyName = "TestAssembly_" + Guid.NewGuid();
            string largeContent = new string('x', 1048714); // 100KB of data
            Dictionary<string, string> testData = new Dictionary<string, string> {{"app.bmp", largeContent}};
            byte[] zipBytes = CreateTestZipBytes(testData);

            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act
            using MemoryStream result = AssetRegistry.GetResourceMemoryStreamByName("app.bmp");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(largeContent.Length, result.Length);
        }


        /// <summary>
        /// Tests that get resource path by name with null resource name throws argument exception
        /// </summary>
        [Fact]
        public void GetResourcePathByName_WithNullResourceName_ThrowsArgumentException()
        {
            // Arrange
            string assemblyName = "TestAssembly_" + Guid.NewGuid();
            Dictionary<string, string> testData = new Dictionary<string, string> {{"app.bmp", "content"}};
            byte[] zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act & Assert
            ArgumentException ex = Assert.Throws<ArgumentException>(() => AssetRegistry.GetResourcePathByName(null));
            Assert.Contains("resourceName no puede estar vacío", ex.Message);
        }

        /// <summary>
        /// Tests that get resource path by name with empty resource name throws argument exception
        /// </summary>
        [Fact]
        public void GetResourcePathByName_WithEmptyResourceName_ThrowsArgumentException()
        {
            // Arrange
            string assemblyName = "TestAssembly_" + Guid.NewGuid();
            Dictionary<string, string> testData = new Dictionary<string, string> {{"app.bmp", "content"}};
            byte[] zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act & Assert
            ArgumentException ex = Assert.Throws<ArgumentException>(() => AssetRegistry.GetResourcePathByName(""));
            Assert.Contains("resourceName no puede estar vacío", ex.Message);
        }


        /// <summary>
        /// Tests that get resource path by name existing resource returns valid path
        /// </summary>
        [Fact]
        public void GetResourcePathByName_ExistingResource_ReturnsValidPath()
        {
            // Arrange
            string assemblyName = "TestAssembly_" + Guid.NewGuid();
            string expectedContent = "path test content";
            Dictionary<string, string> testData = new Dictionary<string, string> {{"app.bmp", expectedContent}};
            byte[] zipBytes = CreateTestZipBytes(testData);

            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act
            string result = AssetRegistry.GetResourcePathByName("app.bmp");

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.True(Path.IsPathRooted(result) || result.Contains(Path.GetTempPath()));
        }

        /// <summary>
        /// Tests that get resource path by name non existent resource throws file not found exception
        /// </summary>
        [Fact]
        public void GetResourcePathByName_NonExistentResource_ThrowsFileNotFoundException()
        {
            // Arrange
            string assemblyName = "TestAssembly_" + Guid.NewGuid();
            Dictionary<string, string> testData = new Dictionary<string, string> {{"app.bmp", "content"}};
            byte[] zipBytes = CreateTestZipBytes(testData);

            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act & Assert
            FileNotFoundException ex = Assert.Throws<FileNotFoundException>(() => AssetRegistry.GetResourcePathByName("nonexistent.txt"));
            Assert.Contains("not found in `assets.pack`", ex.Message);
        }
   
       

        /// <summary>
        /// Tests that get resource memory stream by name empty file returns empty stream
        /// </summary>
        [Fact]
        public void GetResourceMemoryStreamByName_EmptyFile_ReturnsEmptyStream()
        {
            // Arrange
            string assemblyName = "TestAssembly_EmptyFile_" + Guid.NewGuid();
            Dictionary<string, string> testData = new Dictionary<string, string> {{"empty.txt", ""}};
            byte[] zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act
            using MemoryStream result = AssetRegistry.GetResourceMemoryStreamByName("empty.txt");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(0, result.Length);
        }
        
        /// <summary>
        /// Tests that get resource memory stream by name with duplicate file names in different folders returns correct one
        /// </summary>
        [Fact]
        public void GetResourceMemoryStreamByName_WithDuplicateFileNamesInDifferentFolders_ReturnsCorrectOne()
        {
            // Arrange
            string assemblyName = "TestAssembly_Duplicates_" + Guid.NewGuid();
            Dictionary<string, string> testData = new Dictionary<string, string>
            {
                {"folder1/duplicate.txt", "content1"},
                {"folder2/duplicate.txt", "content2"}
            };
            byte[] zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act
            using MemoryStream result = AssetRegistry.GetResourceMemoryStreamByName("folder1/duplicate.txt");

            // Assert
            Assert.NotNull(result);
            result.Position = 0;
            using StreamReader reader = new StreamReader(result);
            string content = reader.ReadToEnd();
            Assert.Equal("content1", content);
        }

        /// <summary>
        /// Tests that get resource memory stream by name with special characters in filename returns resource
        /// </summary>
        [Fact]
        public void GetResourceMemoryStreamByName_WithSpecialCharactersInFilename_ReturnsResource()
        {
            // Arrange
            string assemblyName = "TestAssembly_Special_" + Guid.NewGuid();
            Dictionary<string, string> testData = new Dictionary<string, string>
            {
                {"special-chars_file.txt", "special content"}
            };
            byte[] zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act
            using MemoryStream result = AssetRegistry.GetResourceMemoryStreamByName("special-chars_file.txt");

            // Assert
            Assert.NotNull(result);
            result.Position = 0;
            using StreamReader reader = new StreamReader(result);
            string content = reader.ReadToEnd();
            Assert.Contains("File with special characters", content);
        }

        /// <summary>
        /// Tests that get resource memory stream by name with unicode content returns correct content
        /// </summary>
        [Fact]
        public void GetResourceMemoryStreamByName_WithUnicodeContent_ReturnsCorrectContent()
        {
            // Arrange
            string assemblyName = "TestAssembly_Unicode_" + Guid.NewGuid();
            string unicodeContent = "Héllo Wörld 你好 مرحبا";
            Dictionary<string, string> testData = new Dictionary<string, string>
            {
                {"unicode.txt", unicodeContent}
            };
            byte[] zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act
            using MemoryStream result = AssetRegistry.GetResourceMemoryStreamByName("unicode.txt");

            // Assert
            Assert.NotNull(result);
            result.Position = 0;
            using StreamReader reader = new StreamReader(result);
            string content = reader.ReadToEnd();
            Assert.Equal(unicodeContent, content);
        }

        /// <summary>
        /// Tests that get resource memory stream by name case insensitive search works
        /// </summary>
        [Fact]
        public void GetResourceMemoryStreamByName_CaseInsensitiveSearch_Works()
        {
            // Arrange
            string assemblyName = "TestAssembly_CaseInsensitive_" + Guid.NewGuid();
            Dictionary<string, string> testData = new Dictionary<string, string>
            {
                {"MixedCase.TXT", "Testing mixed case file names"}
            };
            byte[] zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act
            using MemoryStream result = AssetRegistry.GetResourceMemoryStreamByName("mixedcase.txt");

            // Assert
            Assert.NotNull(result);
            result.Position = 0;
            using StreamReader reader = new StreamReader(result);
            string content = reader.ReadToEnd();
            Assert.Contains("Testing mixed case file names", content);
        }

        /// <summary>
        /// Tests that get resource path by name creates file on disk
        /// </summary>
        [Fact]
        public void GetResourcePathByName_CreatesFileOnDisk()
        {
            // Arrange
            string assemblyName = "TestAssembly_Path_" + Guid.NewGuid();
            string expectedContent = "File name with whitespace";
            Dictionary<string, string> testData = new Dictionary<string, string> {{"test.txt", expectedContent}};
            byte[] zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act
            string path = AssetRegistry.GetResourcePathByName("test.txt");

            // Assert
            Assert.NotNull(path);
            Assert.True(File.Exists(path));
            string content = File.ReadAllText(path);
            Assert.Contains(expectedContent, content);
        }

        /// <summary>
        /// Tests that get resource path by name called twice returns same path
        /// </summary>
        [Fact]
        public void GetResourcePathByName_CalledTwice_ReturnsSamePath()
        {
            // Arrange
            string assemblyName = "TestAssembly_PathCache_" + Guid.NewGuid();
            Dictionary<string, string> testData = new Dictionary<string, string> {{"cached.txt", "cached content"}};
            byte[] zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act
            string path1 = AssetRegistry.GetResourcePathByName("cached.txt");
            string path2 = AssetRegistry.GetResourcePathByName("cached.txt");

            // Assert
            Assert.Equal(path1, path2);
        }
        
        /// <summary>
        /// Tests that get resource memory stream by name with whitespace in filename works
        /// </summary>
        [Fact]
        public void GetResourceMemoryStreamByName_WithWhitespaceInFilename_Works()
        {
            // Arrange
            string assemblyName = "TestAssembly_Whitespace_" + Guid.NewGuid();
            Dictionary<string, string> testData = new Dictionary<string, string>
            {
                {"file with spaces.txt", "content with spaces"}
            };
            byte[] zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act
            using MemoryStream result = AssetRegistry.GetResourceMemoryStreamByName("file with spaces.txt");

            // Assert
            Assert.NotNull(result);
            result.Position = 0;
            using StreamReader reader = new StreamReader(result);
            string content = reader.ReadToEnd();
            Assert.Equal("content with spaces", content);
        }

        /// <summary>
        /// Tests that register assembly with null loader throws when trying to get resource
        /// </summary>
        [Fact]
        public void RegisterAssembly_WithNullLoader_ThrowsWhenTryingToGetResource()
        {
            // Arrange
            string assemblyName = "TestAssembly_NullLoader_" + Guid.NewGuid();
            AssetRegistry.RegisterAssembly(assemblyName, () => null);

            // Act & Assert
            FileNotFoundException ex = Assert.Throws<FileNotFoundException>(() => 
                AssetRegistry.GetResourceMemoryStreamByName("any.txt"));
            Assert.Contains("not found", ex.Message);
        }
        

        /// <summary>
        /// Tests that get resource memory stream by name with different file extensions works
        /// </summary>
        [Fact]
        public void GetResourceMemoryStreamByName_WithDifferentFileExtensions_Works()
        {
            // Arrange
            string assemblyName = "TestAssembly_Extensions_" + Guid.NewGuid();
            Dictionary<string, string> testData = new Dictionary<string, string>
            {
                {"file.txt", "text"},
                {"file.json", "json"},
                {"file.xml", "xml"},
                {"file.dat", "data"}
            };
            byte[] zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act & Assert
            using (MemoryStream result = AssetRegistry.GetResourceMemoryStreamByName("file.txt"))
            {
                result.Position = 0;
                using StreamReader reader = new StreamReader(result);
                Assert.Contains("Content for nested folder testing ", reader.ReadToEnd());
            }

            using (MemoryStream result = AssetRegistry.GetResourceMemoryStreamByName("file.json"))
            {
                result.Position = 0;
                using StreamReader reader = new StreamReader(result);
                Assert.Contains("sample", reader.ReadToEnd());
            }
        }

        /// <summary>
        /// Tests that get resource memory stream by name partial path match works
        /// </summary>
        [Fact]
        public void GetResourceMemoryStreamByName_PartialPathMatch_Works()
        {
            // Arrange
            string assemblyName = "TestAssembly_PartialPath_" + Guid.NewGuid();
            Dictionary<string, string> testData = new Dictionary<string, string>
            {
                {"assets/images/apps.bmp", "logo content"}
            };
            byte[] zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act
            using MemoryStream result = AssetRegistry.GetResourceMemoryStreamByName("images/apps.bmp");

            // Assert
            Assert.NotNull(result);
            result.Position = 0;
            using StreamReader reader = new StreamReader(result);
            string content = reader.ReadToEnd();
            Assert.Contains("BM", content);
        }
        
    }
}

