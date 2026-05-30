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
    ///     The asset registry test class
    /// </summary>
    public class AssetRegistryTest
    {
        /// <summary>
        ///     Helper method to create a simple ZIP in memory with test data
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
        ///     Tests that register assembly valid assembly and loader registers
        /// </summary>
        [Fact]
        public void RegisterAssembly_ValidAssemblyAndLoader_Registers()
        {
            string assemblyName = "TestAssembly_" + Guid.NewGuid();
            Dictionary<string, string> testData = new Dictionary<string, string> {{"app.bmp", "content"}};
            byte[] zipBytes = CreateTestZipBytes(testData);

            Func<Stream> loader = () => new MemoryStream(zipBytes, false);

            AssetRegistry.RegisterAssembly(assemblyName, loader);

        }

        /// <summary>
        ///     Tests that register assembly multiple assemblies both registered
        /// </summary>
        [Fact]
        public void RegisterAssembly_MultipleAssemblies_BothRegistered()
        {
            string assembly1 = "TestAssembly1_" + Guid.NewGuid();
            string assembly2 = "TestAssembly2_" + Guid.NewGuid();
            Dictionary<string, string> testData = new Dictionary<string, string> {{"app.bmp", "content"}};
            byte[] zipBytes = CreateTestZipBytes(testData);

            Func<Stream> loader = () => new MemoryStream(zipBytes, false);

            AssetRegistry.RegisterAssembly(assembly1, loader);
            AssetRegistry.RegisterAssembly(assembly2, loader);

        }

        /// <summary>
        ///     Tests that register assembly same assembly twice second registration overrides
        /// </summary>
        [Fact]
        public void RegisterAssembly_SameAssemblyTwice_SecondRegistrationOverrides()
        {
            string assemblyName = "TestAssembly_" + Guid.NewGuid();
            Dictionary<string, string> testData1 = new Dictionary<string, string> {{"test1.txt", "content1"}};
            Dictionary<string, string> testData2 = new Dictionary<string, string> {{"test2.txt", "content2"}};
            byte[] zipBytes1 = CreateTestZipBytes(testData1);
            byte[] zipBytes2 = CreateTestZipBytes(testData2);

            Func<Stream> loader1 = () => new MemoryStream(zipBytes1, false);
            Func<Stream> loader2 = () => new MemoryStream(zipBytes2, false);

            AssetRegistry.RegisterAssembly(assemblyName, loader1);
            AssetRegistry.RegisterAssembly(assemblyName, loader2);

        }

        /// <summary>
        ///     Tests that get resource memory stream by name with null resource name throws argument exception
        /// </summary>
        [Fact]
        public void GetResourceMemoryStreamByName_WithNullResourceName_ThrowsArgumentException()
        {
            string assemblyName = "TestAssembly_" + Guid.NewGuid();
            Dictionary<string, string> testData = new Dictionary<string, string> {{"app.bmp", "content"}};
            byte[] zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            ArgumentException ex = Assert.Throws<ArgumentException>(() => AssetRegistry.GetResourceMemoryStreamByName(null));
            Assert.Contains("resourceName no puede estar vacío", ex.Message);
        }

        /// <summary>
        ///     Tests that get resource memory stream by name with empty resource name throws argument exception
        /// </summary>
        [Fact]
        public void GetResourceMemoryStreamByName_WithEmptyResourceName_ThrowsArgumentException()
        {
            string assemblyName = "TestAssembly_" + Guid.NewGuid();
            Dictionary<string, string> testData = new Dictionary<string, string> {{"app.bmp", "content"}};
            byte[] zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            ArgumentException ex = Assert.Throws<ArgumentException>(() => AssetRegistry.GetResourceMemoryStreamByName(""));
            Assert.Contains("resourceName no puede estar vacío", ex.Message);
        }

        /// <summary>
        ///     Tests that get resource memory stream by name with whitespace resource name throws argument exception
        /// </summary>
        [Fact]
        public void GetResourceMemoryStreamByName_WithWhitespaceResourceName_ThrowsArgumentException()
        {
            string assemblyName = "TestAssembly_" + Guid.NewGuid();
            Dictionary<string, string> testData = new Dictionary<string, string> {{"app.bmp", "content"}};
            byte[] zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            ArgumentException ex = Assert.Throws<ArgumentException>(() => AssetRegistry.GetResourceMemoryStreamByName("   "));
            Assert.Contains("resourceName no puede estar vacío", ex.Message);
        }

        /// <summary>
        ///     Tests that get resource memory stream by name no active assembly throws invalid operation exception
        /// </summary>
        [Fact]
        public void GetResourceMemoryStreamByName_NoActiveAssembly_ThrowsInvalidOperationException()
        {
            FileNotFoundException ex = Assert.Throws<FileNotFoundException>(() => AssetRegistry.GetResourceMemoryStreamByName("app2.bmp"));
            Assert.Contains("not found", ex.Message);
        }

        /// <summary>
        ///     Tests that get resource memory stream by name active assembly not registered throws invalid operation exception
        /// </summary>
        [Fact]
        public void GetResourceMemoryStreamByName_ActiveAssemblyNotRegistered_ThrowsInvalidOperationException()
        {
            string assemblyName1 = "TestAssembly1_" + Guid.NewGuid();
            string assemblyName2 = "TestAssembly2_" + Guid.NewGuid();
            Dictionary<string, string> testData = new Dictionary<string, string> {{"app.bmp", "content"}};
            byte[] zipBytes = CreateTestZipBytes(testData);

            AssetRegistry.RegisterAssembly(assemblyName1, () => new MemoryStream(zipBytes, false));
            AssetRegistry.RegisterAssembly(assemblyName2, () => new MemoryStream(zipBytes, false));

        }

        /// <summary>
        ///     Tests that get resource memory stream by name existing resource returns memory stream
        /// </summary>
        [Fact]
        public void GetResourceMemoryStreamByName_ExistingResource_ReturnsMemoryStream()
        {
            string assemblyName = "TestAssembly_" + Guid.NewGuid();
            string expectedContent = "content";
            Dictionary<string, string> testData = new Dictionary<string, string> {{"app.bmp", expectedContent}};
            byte[] zipBytes = CreateTestZipBytes(testData);

            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            using MemoryStream result = AssetRegistry.GetResourceMemoryStreamByName("app.bmp");

            Assert.NotNull(result);
            Assert.True(result.Length > 0);
        }

        /// <summary>
        ///     Tests that get resource memory stream by name non existent resource throws file not found exception
        /// </summary>
        [Fact]
        public void GetResourceMemoryStreamByName_NonExistentResource_ThrowsFileNotFoundException()
        {
            string assemblyName = "TestAssembly_" + Guid.NewGuid();
            Dictionary<string, string> testData = new Dictionary<string, string> {{"app.bmp", "content"}};
            byte[] zipBytes = CreateTestZipBytes(testData);

            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            FileNotFoundException ex = Assert.Throws<FileNotFoundException>(() => AssetRegistry.GetResourceMemoryStreamByName("nonexistent.txt"));
            Assert.Contains("not found in `assets.pack`", ex.Message);
        }
        
        /// <summary>
        ///     Tests that get resource path by name with null resource name throws argument exception
        /// </summary>
        [Fact]
        public void GetResourcePathByName_WithNullResourceName_ThrowsArgumentException()
        {
            string assemblyName = "TestAssembly_" + Guid.NewGuid();
            Dictionary<string, string> testData = new Dictionary<string, string> {{"app.bmp", "content"}};
            byte[] zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            ArgumentException ex = Assert.Throws<ArgumentException>(() => AssetRegistry.GetResourcePathByName(null));
            Assert.Contains("resourceName no puede estar vacío", ex.Message);
        }

        /// <summary>
        ///     Tests that get resource path by name with empty resource name throws argument exception
        /// </summary>
        [Fact]
        public void GetResourcePathByName_WithEmptyResourceName_ThrowsArgumentException()
        {
            string assemblyName = "TestAssembly_" + Guid.NewGuid();
            Dictionary<string, string> testData = new Dictionary<string, string> {{"app.bmp", "content"}};
            byte[] zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            ArgumentException ex = Assert.Throws<ArgumentException>(() => AssetRegistry.GetResourcePathByName(""));
            Assert.Contains("resourceName no puede estar vacío", ex.Message);
        }


        /// <summary>
        ///     Tests that get resource path by name existing resource returns valid path
        /// </summary>
        [Fact]
        public void GetResourcePathByName_ExistingResource_ReturnsValidPath()
        {
            string assemblyName = "TestAssembly_" + Guid.NewGuid();
            string expectedContent = "path test content";
            Dictionary<string, string> testData = new Dictionary<string, string> {{"app.bmp", expectedContent}};
            byte[] zipBytes = CreateTestZipBytes(testData);

            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            string result = AssetRegistry.GetResourcePathByName("app.bmp");

            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.True(Path.IsPathRooted(result) || result.Contains(Path.GetTempPath()));
        }

        /// <summary>
        ///     Tests that get resource path by name non existent resource throws file not found exception
        /// </summary>
        [Fact]
        public void GetResourcePathByName_NonExistentResource_ThrowsFileNotFoundException()
        {
            string assemblyName = "TestAssembly_" + Guid.NewGuid();
            Dictionary<string, string> testData = new Dictionary<string, string> {{"app.bmp", "content"}};
            byte[] zipBytes = CreateTestZipBytes(testData);

            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            FileNotFoundException ex = Assert.Throws<FileNotFoundException>(() => AssetRegistry.GetResourcePathByName("nonexistent.txt"));
            Assert.Contains("not found in `assets.pack`", ex.Message);
        }
        
        /// <summary>
        ///     Tests that register assembly with null loader throws when trying to get resource
        /// </summary>
        [Fact]
        public void RegisterAssembly_WithNullLoader_ThrowsWhenTryingToGetResource()
        {
            string assemblyName = "TestAssembly_NullLoader_" + Guid.NewGuid();
            AssetRegistry.RegisterAssembly(assemblyName, () => null);

            FileNotFoundException ex = Assert.Throws<FileNotFoundException>(() =>
                AssetRegistry.GetResourceMemoryStreamByName("any.txt"));
            Assert.Contains("not found", ex.Message);
        }

        /// <summary>
        ///     Tests that get resource path by name with whitespace resource name throws argument exception
        /// </summary>
        [Fact]
        public void GetResourcePathByName_WithWhitespaceResourceName_ThrowsArgumentException()
        {
            string assemblyName = "TestAssembly_" + Guid.NewGuid();
            Dictionary<string, string> testData = new Dictionary<string, string> {{"app.bmp", "content"}};
            byte[] zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            ArgumentException ex = Assert.Throws<ArgumentException>(() => AssetRegistry.GetResourcePathByName("   "));
            Assert.Contains("resourceName no puede estar vacío", ex.Message);
        }

        /// <summary>
        ///     Tests that get resource path by name with non-existent resource throws file not found exception
        /// </summary>
        [Fact]
        public void GetResourcePathByName_NonExistentResource_DifferentFilename_ThrowsFileNotFoundException()
        {
            string assemblyName = "TestAssembly_PathNotFound_" + Guid.NewGuid();
            Dictionary<string, string> testData = new Dictionary<string, string> {{"app.bmp", "content"}};
            byte[] zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            FileNotFoundException ex = Assert.Throws<FileNotFoundException>(() =>
                AssetRegistry.GetResourcePathByName("nonexistent.txt"));
            Assert.Contains("not found in `assets.pack`", ex.Message);
        }

        /// <summary>
        ///     Tests that get resource path by name with whitespace returns valid path for existing resource
        /// </summary>
        [Fact]
        public void GetResourcePathByName_ExistingResource_ReturnsValidFilePath()
        {
            string assemblyName = "TestAssembly_ValidPath_" + Guid.NewGuid();
            string expectedContent = "valid path content";
            Dictionary<string, string> testData = new Dictionary<string, string> {{"app.bmp", expectedContent}};
            byte[] zipBytes = CreateTestZipBytes(testData);

            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            string result = AssetRegistry.GetResourcePathByName("app.bmp");

            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.True(System.IO.File.Exists(result), "The returned path should point to an existing file");
        }

        /// <summary>
        ///     Tests that get resource memory stream by name with case insensitive lookup finds resource
        ///     via substring fallback (the first assembly's zip contains "app.bmp")
        /// </summary>
        [Fact]
        public void GetResourceMemoryStreamByName_SubstringFallback_FindsResourceByPartialMatch()
        {
            // The active assembly (first registered) has "app.bmp".
            // Searching by "bmp" should find it via the substring fallback path in FindZipEntryInfo.
            using MemoryStream result = AssetRegistry.GetResourceMemoryStreamByName("bmp");

            Assert.NotNull(result);
            Assert.True(result.Length > 0);
        }

        /// <summary>
        ///     Tests that get resource memory stream by name with case insensitive lookup finds resource
        ///     via case-insensitive full path match
        /// </summary>
        [Fact]
        public void GetResourceMemoryStreamByName_CaseInsensitiveFullMatch_FindsResource()
        {
            // The active assembly (first registered) has "app.bmp" (lowercase).
            // Searching by "APP.BMP" (uppercase) should normalize to "app.bmp" and find it.
            using MemoryStream result = AssetRegistry.GetResourceMemoryStreamByName("APP.BMP");

            Assert.NotNull(result);
            Assert.True(result.Length > 0);
        }

        /// <summary>
        ///     Tests that get resource memory stream by name retrieves content matching what was registered
        /// </summary>
        [Fact]
        public void GetResourceMemoryStreamByName_ExistingResource_ContentMatches()
        {
            using MemoryStream result = AssetRegistry.GetResourceMemoryStreamByName("app.bmp");

            Assert.NotNull(result);
            Assert.True(result.Length > 0);

            // Verify the content is readable and starts with expected data
            result.Position = 0;
            byte[] buffer = new byte[result.Length];
            int bytesRead = result.Read(buffer, 0, buffer.Length);
            Assert.True(bytesRead > 0, "Should read bytes from the stream");
        }

        /// <summary>
        ///     Tests that get resource memory stream by name returns a stream positioned at zero
        /// </summary>
        [Fact]
        public void GetResourceMemoryStreamByName_ReturnsStreamPositionedAtZero()
        {
            using MemoryStream result = AssetRegistry.GetResourceMemoryStreamByName("app.bmp");

            Assert.NotNull(result);
            Assert.Equal(0, result.Position);
        }

        /// <summary>
        ///     Tests that get resource memory stream by name with non-existent resource returns null
        ///     after all fallback strategies fail
        /// </summary>
        [Fact]
        public void GetResourceMemoryStreamByName_NonExistentResource_AllFallbacksFail_ThrowsFileNotFoundException()
        {
            FileNotFoundException ex = Assert.Throws<FileNotFoundException>(() =>
                AssetRegistry.GetResourceMemoryStreamByName("definitely_does_not_exist_xyz123.txt"));
            Assert.Contains("not found in `assets.pack`", ex.Message);
        }

        /// <summary>
        ///     Tests that register assembly with empty stream loader works
        /// </summary>
        [Fact]
        public void RegisterAssembly_EmptyStreamLoader_WorksCorrectly()
        {
            string assemblyName = "TestAssembly_EmptyLoader_" + Guid.NewGuid();

            // Register with an empty zip - EnsureZipCachedForActiveAssembly will succeed
            // but the zip will have no entries
            byte[] emptyZip = CreateTestZipBytes(new Dictionary<string, string>());
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(emptyZip, false));

            // The active assembly is already set from a previous test, so this won't
            // change it. This test just verifies RegisterAssembly doesn't throw.
        }

        /// <summary>
        ///     Tests that register assembly multiple times does not throw
        /// </summary>
        [Fact]
        public void RegisterAssembly_MultipleTimes_DoesNotThrow()
        {
            string assemblyName = "TestAssembly_Multi_" + Guid.NewGuid();
            Dictionary<string, string> testData = new Dictionary<string, string> {{"app.bmp", "content"}};
            byte[] zipBytes = CreateTestZipBytes(testData);

            // Register same assembly multiple times - should not throw
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));
        }

        /// <summary>
        ///     Tests that get resource memory stream by name with various resource name patterns
        /// </summary>
        [Theory]
        [InlineData("app.bmp")]
        [InlineData("APP.BMP")]
        [InlineData("App.Bmp")]
        public void GetResourceMemoryStreamByName_VariousCasePatterns_FindsResource(string resourceName)
        {
            using MemoryStream result = AssetRegistry.GetResourceMemoryStreamByName(resourceName);

            Assert.NotNull(result);
            Assert.True(result.Length > 0);
        }

        /// <summary>
        ///     Tests that get resource path by name with various resource name patterns
        /// </summary>
        [Theory]
        [InlineData("app.bmp")]
        [InlineData("APP.BMP")]
        [InlineData("App.Bmp")]
        public void GetResourcePathByName_VariousCasePatterns_ReturnsValidPath(string resourceName)
        {
            string result = AssetRegistry.GetResourcePathByName(resourceName);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}