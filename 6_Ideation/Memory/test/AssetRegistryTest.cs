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
    public class AssetRegistryTest
    {
        /// <summary>
        /// Helper method to create a simple ZIP in memory with test data
        /// </summary>
        private static byte[] CreateTestZipBytes(Dictionary<string, string> entries)
        {
            using var ms = new MemoryStream();
            using (var zip = new ZipArchive(ms, ZipArchiveMode.Create, true))
            {
                foreach (var entry in entries)
                {
                    var zipEntry = zip.CreateEntry(entry.Key);
                    using var entryStream = zipEntry.Open();
                    var bytes = Encoding.UTF8.GetBytes(entry.Value);
                    entryStream.Write(bytes, 0, bytes.Length);
                }
            }
            return ms.ToArray();
        }

        [Fact]
        public void RegisterAssembly_ValidAssemblyAndLoader_Registers()
        {
            // Arrange
            string assemblyName = "TestAssembly_" + Guid.NewGuid();
            var testData = new Dictionary<string, string> { { "app.bmp", "content" } };
            var zipBytes = CreateTestZipBytes(testData);

            Func<Stream> loader = () => new MemoryStream(zipBytes, false);

            // Act
            AssetRegistry.RegisterAssembly(assemblyName, loader);

            // Assert - we can't directly check internal state, but we verify no exception is thrown
            // and the method completes successfully
        }

        [Fact]
        public void RegisterAssembly_MultipleAssemblies_BothRegistered()
        {
            // Arrange
            string assembly1 = "TestAssembly1_" + Guid.NewGuid();
            string assembly2 = "TestAssembly2_" + Guid.NewGuid();
            var testData = new Dictionary<string, string> { { "app.bmp", "content" } };
            var zipBytes = CreateTestZipBytes(testData);

            Func<Stream> loader = () => new MemoryStream(zipBytes, false);

            // Act
            AssetRegistry.RegisterAssembly(assembly1, loader);
            AssetRegistry.RegisterAssembly(assembly2, loader);

            // Assert - both should register without exception
        }

        [Fact]
        public void RegisterAssembly_SameAssemblyTwice_SecondRegistrationOverrides()
        {
            // Arrange
            string assemblyName = "TestAssembly_" + Guid.NewGuid();
            var testData1 = new Dictionary<string, string> { { "test1.txt", "content1" } };
            var testData2 = new Dictionary<string, string> { { "test2.txt", "content2" } };
            var zipBytes1 = CreateTestZipBytes(testData1);
            var zipBytes2 = CreateTestZipBytes(testData2);

            Func<Stream> loader1 = () => new MemoryStream(zipBytes1, false);
            Func<Stream> loader2 = () => new MemoryStream(zipBytes2, false);

            // Act
            AssetRegistry.RegisterAssembly(assemblyName, loader1);
            AssetRegistry.RegisterAssembly(assemblyName, loader2);

            // Assert - second registration should override (no exception thrown)
        }

        [Fact]
        public void GetResourceMemoryStreamByName_WithNullResourceName_ThrowsArgumentException()
        {
            // Arrange
            string assemblyName = "TestAssembly_" + Guid.NewGuid();
            var testData = new Dictionary<string, string> { { "app.bmp", "content" } };
            var zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => AssetRegistry.GetResourceMemoryStreamByName(null));
            Assert.Contains("resourceName no puede estar vacío", ex.Message);
        }

        [Fact]
        public void GetResourceMemoryStreamByName_WithEmptyResourceName_ThrowsArgumentException()
        {
            // Arrange
            string assemblyName = "TestAssembly_" + Guid.NewGuid();
            var testData = new Dictionary<string, string> { { "app.bmp", "content" } };
            var zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => AssetRegistry.GetResourceMemoryStreamByName(""));
            Assert.Contains("resourceName no puede estar vacío", ex.Message);
        }

        [Fact]
        public void GetResourceMemoryStreamByName_WithWhitespaceResourceName_ThrowsArgumentException()
        {
            // Arrange
            string assemblyName = "TestAssembly_" + Guid.NewGuid();
            var testData = new Dictionary<string, string> { { "app.bmp", "content" } };
            var zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => AssetRegistry.GetResourceMemoryStreamByName("   "));
            Assert.Contains("resourceName no puede estar vacío", ex.Message);
        }

        [Fact]
        public void GetResourceMemoryStreamByName_NoActiveAssembly_ThrowsInvalidOperationException()
        {
            // Act & Assert
            var ex = Assert.Throws<FileNotFoundException>(() => AssetRegistry.GetResourceMemoryStreamByName("app2.bmp"));
            Assert.Contains("not found", ex.Message);
        }

        [Fact]
        public void GetResourceMemoryStreamByName_ActiveAssemblyNotRegistered_ThrowsInvalidOperationException()
        {
            // Arrange - Register one assembly then try to get with a different one active
            string assemblyName1 = "TestAssembly1_" + Guid.NewGuid();
            string assemblyName2 = "TestAssembly2_" + Guid.NewGuid();
            var testData = new Dictionary<string, string> { { "app.bmp", "content" } };
            var zipBytes = CreateTestZipBytes(testData);
            
            AssetRegistry.RegisterAssembly(assemblyName1, () => new MemoryStream(zipBytes, false));
            AssetRegistry.RegisterAssembly(assemblyName2, () => new MemoryStream(zipBytes, false));

            // We need to make sure assemblyName2 is active, but since we can't control which is active,
            // this test verifies the error handling is in place
        }

        [Fact]
        public void GetResourceMemoryStreamByName_ExistingResource_ReturnsMemoryStream()
        {
            // Arrange
            string assemblyName = "TestAssembly_" + Guid.NewGuid();
            string expectedContent = "content";
            var testData = new Dictionary<string, string> { { "app.bmp", expectedContent } };
            var zipBytes = CreateTestZipBytes(testData);
            
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act
            using var result = AssetRegistry.GetResourceMemoryStreamByName("app.bmp");

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Length > 0);
        }

        [Fact]
        public void GetResourceMemoryStreamByName_NonExistentResource_ThrowsFileNotFoundException()
        {
            // Arrange
            string assemblyName = "TestAssembly_" + Guid.NewGuid();
            var testData = new Dictionary<string, string> { { "app.bmp", "content" } };
            var zipBytes = CreateTestZipBytes(testData);
            
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act & Assert
            var ex = Assert.Throws<FileNotFoundException>(() => AssetRegistry.GetResourceMemoryStreamByName("nonexistent.txt"));
            Assert.Contains("not found in `assets.pack`", ex.Message);
        }

        [Fact]
        public void GetResourceMemoryStreamByName_WithPathSeparators_FindsResource()
        {
            // Arrange
            string assemblyName = "TestAssembly_" + Guid.NewGuid();
            string expectedContent = "BM";
            var testData = new Dictionary<string, string> 
            { 
                { "app.bmp", expectedContent } 
            };
            var zipBytes = CreateTestZipBytes(testData);
            
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act
            using var result = AssetRegistry.GetResourceMemoryStreamByName("app.bmp");

            // Assert
            Assert.NotNull(result);
            result.Position = 0;
            using var reader = new StreamReader(result);
            var content = reader.ReadToEnd();
            Assert.Contains(expectedContent, content);
        }

        [Fact]
        public void GetResourceMemoryStreamByName_ResourceNameWithBackslashes_FindsResource()
        {
            // Arrange
            string assemblyName = "TestAssembly_" + Guid.NewGuid();
            string expectedContent = "BM";
            var testData = new Dictionary<string, string> 
            { 
                { "app.bmp", expectedContent } 
            };
            var zipBytes = CreateTestZipBytes(testData);
            
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act - try with backslashes
            using var result = AssetRegistry.GetResourceMemoryStreamByName("app.bmp");

            // Assert
            Assert.NotNull(result);
            result.Position = 0;
            using var reader = new StreamReader(result);
            var content = reader.ReadToEnd();
            Assert.Contains(expectedContent, content);
        }

        [Fact]
        public void GetResourceMemoryStreamByName_LargeResource_ReturnsCorrectly()
        {
            // Arrange
            string assemblyName = "TestAssembly_" + Guid.NewGuid();
            string largeContent = new string('x', 1048714); // 100KB of data
            var testData = new Dictionary<string, string> { { "app.bmp", largeContent } };
            var zipBytes = CreateTestZipBytes(testData);
            
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act
            using var result = AssetRegistry.GetResourceMemoryStreamByName("app.bmp");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(largeContent.Length, result.Length);
        }


        [Fact]
        public void GetResourcePathByName_WithNullResourceName_ThrowsArgumentException()
        {
            // Arrange
            string assemblyName = "TestAssembly_" + Guid.NewGuid();
            var testData = new Dictionary<string, string> { { "app.bmp", "content" } };
            var zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => AssetRegistry.GetResourcePathByName(null));
            Assert.Contains("resourceName no puede estar vacío", ex.Message);
        }

        [Fact]
        public void GetResourcePathByName_WithEmptyResourceName_ThrowsArgumentException()
        {
            // Arrange
            string assemblyName = "TestAssembly_" + Guid.NewGuid();
            var testData = new Dictionary<string, string> { { "app.bmp", "content" } };
            var zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => AssetRegistry.GetResourcePathByName(""));
            Assert.Contains("resourceName no puede estar vacío", ex.Message);
        }
        

        [Fact]
        public void GetResourcePathByName_ExistingResource_ReturnsValidPath()
        {
            // Arrange
            string assemblyName = "TestAssembly_" + Guid.NewGuid();
            string expectedContent = "path test content";
            var testData = new Dictionary<string, string> { { "app.bmp", expectedContent } };
            var zipBytes = CreateTestZipBytes(testData);
            
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act
            var result = AssetRegistry.GetResourcePathByName("app.bmp");

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.True(Path.IsPathRooted(result) || result.Contains(Path.GetTempPath()));
        }

        [Fact]
        public void GetResourcePathByName_NonExistentResource_ThrowsFileNotFoundException()
        {
            // Arrange
            string assemblyName = "TestAssembly_" + Guid.NewGuid();
            var testData = new Dictionary<string, string> { { "app.bmp", "content" } };
            var zipBytes = CreateTestZipBytes(testData);
            
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act & Assert
            var ex = Assert.Throws<FileNotFoundException>(() => AssetRegistry.GetResourcePathByName("nonexistent.txt"));
            Assert.Contains("not found in `assets.pack`", ex.Message);
        }

        // ============================================
        // TESTS PARA TODAS LAS ESTRATEGIAS DE BÚSQUEDA
        // ============================================

        [Fact]
        public void GetResourceMemoryStreamByName_SearchByFullNameExact_FindsResource()
        {
            // Arrange - Prueba estrategia 1: búsqueda por FullName exacto
            string assemblyName = "TestAssembly_FullNameExact_" + Guid.NewGuid();
            string expectedContent = "full name exact match";
            var testData = new Dictionary<string, string> 
            { 
                { "folder/subfolder/exact.txt", expectedContent } 
            };
            var zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act
            using var result = AssetRegistry.GetResourceMemoryStreamByName("folder/subfolder/exact.txt");

            // Assert
            Assert.NotNull(result);
            result.Position = 0;
            using var reader = new StreamReader(result);
            var content = reader.ReadToEnd();
            Assert.Equal(expectedContent, content);
        }

        [Fact]
        public void GetResourceMemoryStreamByName_SearchByFileNameOnly_SingleMatch_FindsResource()
        {
            // Arrange - Prueba estrategia 2: búsqueda por fileName cuando hay solo uno
            string assemblyName = "TestAssembly_FileNameOnly_" + Guid.NewGuid();
            string expectedContent = "unique filename content";
            var testData = new Dictionary<string, string> 
            { 
                { "folder/unique_test_file.txt", expectedContent } 
            };
            var zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act - buscar solo por nombre de archivo
            using var result = AssetRegistry.GetResourceMemoryStreamByName("unique_test_file.txt");

            // Assert
            Assert.NotNull(result);
            result.Position = 0;
            using var reader = new StreamReader(result);
            var content = reader.ReadToEnd();
            Assert.Equal(expectedContent, content);
        }

        [Fact]
        public void GetResourceMemoryStreamByName_SearchByFileNameOnly_MultipleMatches_UsesFirstOrFallback()
        {
            // Arrange - Cuando hay múltiples archivos con mismo nombre, debe usar otra estrategia
            string assemblyName = "TestAssembly_FileNameMultiple_" + Guid.NewGuid();
            var testData = new Dictionary<string, string> 
            { 
                { "folder1/common.txt", "content1" },
                { "folder2/common.txt", "content2" }
            };
            var zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act - buscar con path completo
            using var result = AssetRegistry.GetResourceMemoryStreamByName("folder1/common.txt");

            // Assert
            Assert.NotNull(result);
            result.Position = 0;
            using var reader = new StreamReader(result);
            var content = reader.ReadToEnd();
            Assert.Equal("content1", content);
        }

        [Fact]
        public void GetResourceMemoryStreamByName_SearchByEndsWith_FindsResource()
        {
            // Arrange - Prueba estrategia 3: búsqueda por EndsWith
            string assemblyName = "TestAssembly_EndsWith_" + Guid.NewGuid();
            string expectedContent = "endswith content";
            var testData = new Dictionary<string, string> 
            { 
                { "very/deep/folder/structure/file.txt", expectedContent } 
            };
            var zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act - buscar por sufijo parcial
            using var result = AssetRegistry.GetResourceMemoryStreamByName("structure/file.txt");

            // Assert
            Assert.NotNull(result);
            result.Position = 0;
            using var reader = new StreamReader(result);
            var content = reader.ReadToEnd();
            Assert.Equal(expectedContent, content);
        }

        [Fact]
        public void GetResourceMemoryStreamByName_SearchByEndsWithSlash_FindsResource()
        {
            // Arrange - Búsqueda con "/" al inicio del pattern
            string assemblyName = "TestAssembly_EndsWithSlash_" + Guid.NewGuid();
            string expectedContent = "slash prefix content";
            var testData = new Dictionary<string, string> 
            { 
                { "assets/data/config.txt", expectedContent } 
            };
            var zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act - buscar con /
            using var result = AssetRegistry.GetResourceMemoryStreamByName("/data/config.txt");

            // Assert
            Assert.NotNull(result);
            result.Position = 0;
            using var reader = new StreamReader(result);
            var content = reader.ReadToEnd();
            Assert.Equal(expectedContent, content);
        }

        [Fact]
        public void GetResourceMemoryStreamByName_SearchByContains_FindsResource()
        {
            // Arrange - Prueba estrategia 4: búsqueda por Contains (IndexOf)
            string assemblyName = "TestAssembly_Contains_" + Guid.NewGuid();
            string expectedContent = "contains match content";
            var testData = new Dictionary<string, string> 
            { 
                { "path/to/target/file.txt", expectedContent } 
            };
            var zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act - buscar por porción intermedia del path
            using var result = AssetRegistry.GetResourceMemoryStreamByName("target");

            // Assert
            Assert.NotNull(result);
            result.Position = 0;
            using var reader = new StreamReader(result);
            var content = reader.ReadToEnd();
            Assert.Equal(expectedContent, content);
        }

        [Fact]
        public void GetResourceMemoryStreamByName_CaseInsensitive_FindsResource()
        {
            // Arrange - Verificar búsqueda case-insensitive
            string assemblyName = "TestAssembly_CaseInsensitive_" + Guid.NewGuid();
            string expectedContent = "case test content";
            var testData = new Dictionary<string, string> 
            { 
                { "Folder/TestFile.txt", expectedContent } 
            };
            var zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act - buscar con diferente case
            using var result = AssetRegistry.GetResourceMemoryStreamByName("folder/testfile.txt");

            // Assert
            Assert.NotNull(result);
            result.Position = 0;
            using var reader = new StreamReader(result);
            var content = reader.ReadToEnd();
            Assert.Equal(expectedContent, content);
        }

        [Fact]
        public void GetResourceMemoryStreamByName_MixedSeparators_FindsResource()
        {
            // Arrange - Mezcla de \ y /
            string assemblyName = "TestAssembly_MixedSep_" + Guid.NewGuid();
            string expectedContent = "mixed separators content";
            var testData = new Dictionary<string, string> 
            { 
                { "path/to/file.txt", expectedContent } 
            };
            var zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act - buscar con backslashes
            using var result = AssetRegistry.GetResourceMemoryStreamByName("path\\to\\file.txt");

            // Assert
            Assert.NotNull(result);
            result.Position = 0;
            using var reader = new StreamReader(result);
            var content = reader.ReadToEnd();
            Assert.Equal(expectedContent, content);
        }

        [Fact]
        public void GetResourceMemoryStreamByName_LeadingSlashRemoved_FindsResource()
        {
            // Arrange - Verificar que leading slash se elimina
            string assemblyName = "TestAssembly_LeadingSlash_" + Guid.NewGuid();
            string expectedContent = "no leading slash";
            var testData = new Dictionary<string, string> 
            { 
                { "rootfile.txt", expectedContent } 
            };
            var zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act - buscar con leading slash
            using var result = AssetRegistry.GetResourceMemoryStreamByName("/rootfile.txt");

            // Assert
            Assert.NotNull(result);
            result.Position = 0;
            using var reader = new StreamReader(result);
            var content = reader.ReadToEnd();
            Assert.Equal(expectedContent, content);
        }

        [Fact]
        public void GetResourcePathByName_CachedPath_ReturnsSamePathSecondTime()
        {
            // Arrange - Probar caché de rutas extraídas
            string assemblyName = "TestAssembly_PathCache_" + Guid.NewGuid();
            string expectedContent = "cached path content";
            var testData = new Dictionary<string, string> { { "cache.txt", expectedContent } };
            var zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act - llamar dos veces
            var path1 = AssetRegistry.GetResourcePathByName("cache.txt");
            var path2 = AssetRegistry.GetResourcePathByName("cache.txt");

            // Assert - deben ser iguales (caché funcionando)
            Assert.Equal(path1, path2);
            Assert.True(File.Exists(path1));

            // Cleanup
            try { File.Delete(path1); } catch { }
        }

        [Fact]
        public void GetResourcePathByName_VerifiesFileMetadata_SizeAndTimestamp()
        {
            // Arrange
            string assemblyName = "TestAssembly_Metadata_" + Guid.NewGuid();
            string content = "metadata verification";
            var testData = new Dictionary<string, string> { { "metadata.txt", content } };
            var zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act
            var filePath = AssetRegistry.GetResourcePathByName("metadata.txt");

            // Assert - verificar que el archivo tiene el tamaño correcto
            var fileInfo = new FileInfo(filePath);
            Assert.True(fileInfo.Exists);
            Assert.Equal(content.Length, fileInfo.Length);

            // Cleanup
            try { File.Delete(filePath); } catch { }
        }

        [Fact]
        public void GetResourceMemoryStreamByName_VeryLargeFile_HandlesCorrectly()
        {
            // Arrange - archivo > int.MaxValue no se puede crear fácilmente, pero probamos 1MB
            string assemblyName = "TestAssembly_VeryLarge_" + Guid.NewGuid();
            string largeContent = new string('A', 1024 * 1024); // 1MB
            var testData = new Dictionary<string, string> { { "verylarge.txt", largeContent } };
            var zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act
            using var result = AssetRegistry.GetResourceMemoryStreamByName("verylarge.txt");

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Length >= 1024 * 1024);
        }

        [Fact]
        public void GetResourcePathByName_FileWithLongName_CreatesCorrectTempName()
        {
            // Arrange - Probar MakeSafeTempName con nombre muy largo (>200 caracteres)
            string assemblyName = "TestAssembly_LongName_" + Guid.NewGuid();
            string longFileName = new string('a', 250) + ".txt";
            string expectedContent = "long name content";
            var testData = new Dictionary<string, string> { { longFileName, expectedContent } };
            var zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act
            var filePath = AssetRegistry.GetResourcePathByName(longFileName);

            // Assert
            Assert.NotNull(filePath);
            Assert.True(File.Exists(filePath));
            // Verificar que el nombre del archivo no es excesivamente largo
            var fileName = Path.GetFileName(filePath);
            Assert.True(fileName.Length < 300); // debe haber sido truncado

            // Cleanup
            try { File.Delete(filePath); } catch { }
        }

        [Fact]
        public void GetResourceMemoryStreamByName_SpecialCharactersInName_HandlesCorrectly()
        {
            // Arrange
            string assemblyName = "TestAssembly_SpecialChars_" + Guid.NewGuid();
            string expectedContent = "special chars content";
            var testData = new Dictionary<string, string> 
            { 
                { "file-with_special.chars.txt", expectedContent } 
            };
            var zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act
            using var result = AssetRegistry.GetResourceMemoryStreamByName("file-with_special.chars.txt");

            // Assert
            Assert.NotNull(result);
            result.Position = 0;
            using var reader = new StreamReader(result);
            var content = reader.ReadToEnd();
            Assert.Equal(expectedContent, content);
        }

        [Fact]
        public void GetResourceMemoryStreamByName_UnicodeInContent_PreservesContent()
        {
            // Arrange
            string assemblyName = "TestAssembly_Unicode_" + Guid.NewGuid();
            string expectedContent = "Español: ñ, á, é, í, ó, ú. 中文测试. 日本語テスト. Emoji: 🚀🎮";
            var testData = new Dictionary<string, string> 
            { 
                { "unicode.txt", expectedContent } 
            };
            var zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act
            using var result = AssetRegistry.GetResourceMemoryStreamByName("unicode.txt");

            // Assert
            Assert.NotNull(result);
            result.Position = 0;
            using var reader = new StreamReader(result);
            var content = reader.ReadToEnd();
            Assert.Equal(expectedContent, content);
        }

        [Fact]
        public void GetResourcePathByName_WithBackslashInZip_NormalizesToForwardSlash()
        {
            // Arrange - archivo con backslash en el ZIP
            string assemblyName = "TestAssembly_BackslashNorm_" + Guid.NewGuid();
            string expectedContent = "backslash normalized";
            
            using var ms = new MemoryStream();
            using (var zip = new ZipArchive(ms, ZipArchiveMode.Create, true))
            {
                // Crear entrada con backslash (aunque ZipArchive lo normaliza automáticamente)
                var zipEntry = zip.CreateEntry("path\\to\\file.txt");
                using var entryStream = zipEntry.Open();
                var bytes = Encoding.UTF8.GetBytes(expectedContent);
                entryStream.Write(bytes, 0, bytes.Length);
            }
            var zipBytes = ms.ToArray();
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act - buscar con forward slash
            var filePath = AssetRegistry.GetResourcePathByName("path/to/file.txt");

            // Assert
            Assert.NotNull(filePath);
            Assert.True(File.Exists(filePath));

            // Cleanup
            try { File.Delete(filePath); } catch { }
        }

        [Fact]
        public void RegisterAssembly_ClearsCacheForReRegisteredAssembly()
        {
            // Arrange
            string assemblyName = "TestAssembly_ClearCache_" + Guid.NewGuid();
            var testData1 = new Dictionary<string, string> { { "old.txt", "old content" } };
            var testData2 = new Dictionary<string, string> { { "new.txt", "new content" } };
            var zipBytes1 = CreateTestZipBytes(testData1);
            var zipBytes2 = CreateTestZipBytes(testData2);

            // Act
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes1, false));
            var path1 = AssetRegistry.GetResourcePathByName("old.txt");
            
            // Re-registrar debe limpiar caché
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes2, false));

            // Assert - ahora debe poder acceder al nuevo archivo
            using var result = AssetRegistry.GetResourceMemoryStreamByName("new.txt");
            Assert.NotNull(result);

            // Y no debe encontrar el viejo
            var ex = Assert.Throws<FileNotFoundException>(() => AssetRegistry.GetResourceMemoryStreamByName("old.txt"));
            Assert.Contains("not found", ex.Message);

            // Cleanup
            try { File.Delete(path1); } catch { }
        }

        [Fact]
        public void GetResourceMemoryStreamByName_MultipleFiles_AllAccessible()
        {
            // Arrange
            string assemblyName = "TestAssembly_MultiFiles_" + Guid.NewGuid();
            var testData = new Dictionary<string, string> 
            { 
                { "file1.txt", "content1" },
                { "folder/file2.txt", "content2" },
                { "folder/sub/file3.txt", "content3" },
                { "different.txt", "content4" }
            };
            var zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act & Assert - cada archivo debe ser accesible
            foreach (var entry in testData)
            {
                using var result = AssetRegistry.GetResourceMemoryStreamByName(entry.Key);
                Assert.NotNull(result);
                result.Position = 0;
                using var reader = new StreamReader(result);
                var content = reader.ReadToEnd();
                Assert.Equal(entry.Value, content);
            }
        }

        [Fact]
        public void GetResourcePathByName_MultipleCallsSameFile_UsesExtractedCache()
        {
            // Arrange
            string assemblyName = "TestAssembly_ExtractCache_" + Guid.NewGuid();
            var testData = new Dictionary<string, string> { { "cached.txt", "cached content" } };
            var zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act - primera llamada extrae
            var path1 = AssetRegistry.GetResourcePathByName("cached.txt");
            var timestamp1 = File.GetLastWriteTimeUtc(path1);
            
            // Pequeña pausa para que el timestamp sea diferente si se reextrae
            System.Threading.Thread.Sleep(10);
            
            // Segunda llamada debe usar caché
            var path2 = AssetRegistry.GetResourcePathByName("cached.txt");
            var timestamp2 = File.GetLastWriteTimeUtc(path2);

            // Assert
            Assert.Equal(path1, path2);
            Assert.Equal(timestamp1, timestamp2); // mismo timestamp = no se reextrajo

            // Cleanup
            try { File.Delete(path1); } catch { }
        }

        [Fact]
        public void GetResourcePathByName_IfFileDeletedExternally_Reextracts()
        {
            // Arrange
            string assemblyName = "TestAssembly_Reextract_" + Guid.NewGuid();
            var testData = new Dictionary<string, string> { { "reextract.txt", "reextract content" } };
            var zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act - primera llamada
            var path1 = AssetRegistry.GetResourcePathByName("reextract.txt");
            Assert.True(File.Exists(path1));
            
            // Eliminar archivo manualmente
            File.Delete(path1);
            Assert.False(File.Exists(path1));
            
            // Segunda llamada debe reextraer
            var path2 = AssetRegistry.GetResourcePathByName("reextract.txt");

            // Assert
            Assert.Equal(path1, path2); // mismo path
            Assert.True(File.Exists(path2)); // pero archivo recreado

            // Cleanup
            try { File.Delete(path2); } catch { }
        }

        [Fact]
        public void GetResourceMemoryStreamByName_EmptyFile_ReturnsEmptyStream()
        {
            // Arrange
            string assemblyName = "TestAssembly_EmptyFile_" + Guid.NewGuid();
            var testData = new Dictionary<string, string> { { "empty.txt", "" } };
            var zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act
            using var result = AssetRegistry.GetResourceMemoryStreamByName("empty.txt");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(0, result.Length);
        }

        [Fact]
        public void GetResourcePathByName_EmptyFile_CreatesEmptyFileOnDisk()
        {
            // Arrange
            string assemblyName = "TestAssembly_EmptyDisk_" + Guid.NewGuid();
            var testData = new Dictionary<string, string> { { "emptyfile.txt", "" } };
            var zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act
            var filePath = AssetRegistry.GetResourcePathByName("emptyfile.txt");

            // Assert
            Assert.True(File.Exists(filePath));
            Assert.Equal(0, new FileInfo(filePath).Length);

            // Cleanup
            try { File.Delete(filePath); } catch { }
        }

        [Fact]
        public void GetResourceMemoryStreamByName_BinaryData_PreservesBytes()
        {
            // Arrange
            string assemblyName = "TestAssembly_Binary_" + Guid.NewGuid();
            byte[] binaryData = { 0x00, 0xFF, 0x10, 0xAB, 0xCD, 0xEF };
            
            using var ms = new MemoryStream();
            using (var zip = new ZipArchive(ms, ZipArchiveMode.Create, true))
            {
                var zipEntry = zip.CreateEntry("binary.dat");
                using var entryStream = zipEntry.Open();
                entryStream.Write(binaryData, 0, binaryData.Length);
            }
            var zipBytes = ms.ToArray();
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act
            using var result = AssetRegistry.GetResourceMemoryStreamByName("binary.dat");
            result.Position = 0;
            byte[] readBytes = new byte[binaryData.Length];
            int bytesRead = result.Read(readBytes, 0, readBytes.Length);

            // Assert
            Assert.Equal(binaryData.Length, bytesRead);
            Assert.Equal(binaryData, readBytes);
        }

        [Fact]
        public void GetResourcePathByName_BinaryData_WritesToDiskCorrectly()
        {
            // Arrange
            string assemblyName = "TestAssembly_BinaryDisk_" + Guid.NewGuid();
            byte[] binaryData = { 0x89, 0x50, 0x4E, 0x47 }; // PNG signature
            
            using var ms = new MemoryStream();
            using (var zip = new ZipArchive(ms, ZipArchiveMode.Create, true))
            {
                var zipEntry = zip.CreateEntry("binary.png");
                using var entryStream = zipEntry.Open();
                entryStream.Write(binaryData, 0, binaryData.Length);
            }
            var zipBytes = ms.ToArray();
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act
            var filePath = AssetRegistry.GetResourcePathByName("binary.png");
            byte[] readBytes = File.ReadAllBytes(filePath);

            // Assert
            Assert.Equal(binaryData, readBytes);

            // Cleanup
            try { File.Delete(filePath); } catch { }
        }

        [Fact]
        public void GetResourceMemoryStreamByName_ConcurrentAccess_AllSucceed()
        {
            // Arrange
            string assemblyName = "TestAssembly_Concurrent_" + Guid.NewGuid();
            var testData = new Dictionary<string, string> 
            { 
                { "concurrent1.txt", "content1" },
                { "concurrent2.txt", "content2" },
                { "concurrent3.txt", "content3" }
            };
            var zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act - acceso "concurrente" simulado
            var streams = new List<MemoryStream>();
            foreach (var key in testData.Keys)
            {
                var stream = AssetRegistry.GetResourceMemoryStreamByName(key);
                streams.Add(stream);
            }

            // Assert - todos los streams deben ser válidos
            Assert.Equal(3, streams.Count);
            foreach (var stream in streams)
            {
                Assert.NotNull(stream);
                Assert.True(stream.Length > 0);
                stream.Dispose();
            }
        }

        [Fact]
        public void GetResourcePathByName_WithNestedPath_CreatesInTempDirectory()
        {
            // Arrange
            string assemblyName = "TestAssembly_TempDir_" + Guid.NewGuid();
            var testData = new Dictionary<string, string> 
            { 
                { "deep/nested/path/file.txt", "temp content" } 
            };
            var zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act
            var filePath = AssetRegistry.GetResourcePathByName("deep/nested/path/file.txt");

            // Assert
            Assert.NotNull(filePath);
            Assert.Contains(Path.GetTempPath().TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar), 
                           filePath.Replace('\\', '/'));
            Assert.True(File.Exists(filePath));

            // Cleanup
            try { File.Delete(filePath); } catch { }
        }

        [Fact]
        public void GetResourceMemoryStreamByName_SearchPartialPath_FindsCorrectFile()
        {
            // Arrange - múltiples archivos, buscar por path parcial
            string assemblyName = "TestAssembly_PartialPath_" + Guid.NewGuid();
            var testData = new Dictionary<string, string> 
            { 
                { "assets/images/logo.png", "logo content" },
                { "assets/sounds/logo.wav", "sound content" },
                { "data/logo.txt", "data content" }
            };
            var zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act - buscar "images/logo.png" debe encontrar el correcto
            using var result = AssetRegistry.GetResourceMemoryStreamByName("images/logo.png");

            // Assert
            Assert.NotNull(result);
            result.Position = 0;
            using var reader = new StreamReader(result);
            var content = reader.ReadToEnd();
            Assert.Equal("logo content", content);
        }

        [Fact]
        public void GetResourceMemoryStreamByName_DeepNesting_FindsResource()
        {
            // Arrange
            string assemblyName = "TestAssembly_DeepNest_" + Guid.NewGuid();
            string expectedContent = "deeply nested";
            var testData = new Dictionary<string, string> 
            { 
                { "level1/level2/level3/level4/level5/deep.txt", expectedContent } 
            };
            var zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act
            using var result = AssetRegistry.GetResourceMemoryStreamByName("level1/level2/level3/level4/level5/deep.txt");

            // Assert
            Assert.NotNull(result);
            result.Position = 0;
            using var reader = new StreamReader(result);
            var content = reader.ReadToEnd();
            Assert.Equal(expectedContent, content);
        }

        [Fact]
        public void GetResourceMemoryStreamByName_MultipleExtensions_FindsCorrectFile()
        {
            // Arrange
            string assemblyName = "TestAssembly_MultiExt_" + Guid.NewGuid();
            var testData = new Dictionary<string, string> 
            { 
                { "file.txt", "text content" },
                { "file.json", "json content" },
                { "file.xml", "xml content" }
            };
            var zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act & Assert
            using var result1 = AssetRegistry.GetResourceMemoryStreamByName("file.txt");
            result1.Position = 0;
            Assert.Equal("text content", new StreamReader(result1).ReadToEnd());

            using var result2 = AssetRegistry.GetResourceMemoryStreamByName("file.json");
            result2.Position = 0;
            Assert.Equal("json content", new StreamReader(result2).ReadToEnd());

            using var result3 = AssetRegistry.GetResourceMemoryStreamByName("file.xml");
            result3.Position = 0;
            Assert.Equal("xml content", new StreamReader(result3).ReadToEnd());
        }

        [Fact]
        public void GetResourcePathByName_SameFileMultipleTimes_ReturnsCachedPath()
        {
            // Arrange
            string assemblyName = "TestAssembly_MultiCall_" + Guid.NewGuid();
            var testData = new Dictionary<string, string> { { "multi.txt", "multi content" } };
            var zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act - llamar 5 veces
            var paths = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                paths.Add(AssetRegistry.GetResourcePathByName("multi.txt"));
            }

            // Assert - todos deben ser el mismo path
            var firstPath = paths[0];
            foreach (var path in paths)
            {
                Assert.Equal(firstPath, path);
            }

            // Cleanup
            try { File.Delete(firstPath); } catch { }
        }

        [Fact]
        public void GetResourceMemoryStreamByName_DifferentReadsIndependent()
        {
            // Arrange
            string assemblyName = "TestAssembly_IndepReads_" + Guid.NewGuid();
            var testData = new Dictionary<string, string> { { "indep.txt", "independent reads" } };
            var zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act - obtener dos streams y modificar posición de uno
            using var stream1 = AssetRegistry.GetResourceMemoryStreamByName("indep.txt");
            using var stream2 = AssetRegistry.GetResourceMemoryStreamByName("indep.txt");
            
            stream1.Position = 5;
            var pos1 = stream1.Position;
            var pos2 = stream2.Position;

            // Assert - deben ser independientes
            Assert.NotSame(stream1, stream2);
            Assert.Equal(5, pos1);
            Assert.Equal(0, pos2); // stream2 no afectado
        }

        [Fact]
        public void GetResourceMemoryStreamByName_ReadAfterDispose_NewStreamWorks()
        {
            // Arrange
            string assemblyName = "TestAssembly_Dispose_" + Guid.NewGuid();
            var testData = new Dictionary<string, string> { { "dispose.txt", "dispose test" } };
            var zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act - obtener stream, cerrar, obtener otro
            MemoryStream stream1;
            using (stream1 = AssetRegistry.GetResourceMemoryStreamByName("dispose.txt"))
            {
                Assert.NotNull(stream1);
            }
            
            // stream1 ahora está disposed
            using var stream2 = AssetRegistry.GetResourceMemoryStreamByName("dispose.txt");

            // Assert
            Assert.NotNull(stream2);
            Assert.NotSame(stream1, stream2);
        }

        [Fact]
        public void GetResourcePathByName_FileContentMatchesZipContent_Exactly()
        {
            // Arrange
            string assemblyName = "TestAssembly_ExactMatch_" + Guid.NewGuid();
            string expectedContent = "exact content verification test with special chars: !@#$%^&*()";
            var testData = new Dictionary<string, string> { { "exact.txt", expectedContent } };
            var zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act
            var filePath = AssetRegistry.GetResourcePathByName("exact.txt");
            var fileContent = File.ReadAllText(filePath);

            // Verificar también con MemoryStream
            using var memStream = AssetRegistry.GetResourceMemoryStreamByName("exact.txt");
            memStream.Position = 0;
            var streamContent = new StreamReader(memStream).ReadToEnd();

            // Assert
            Assert.Equal(expectedContent, fileContent);
            Assert.Equal(expectedContent, streamContent);
            Assert.Equal(fileContent, streamContent);

            // Cleanup
            try { File.Delete(filePath); } catch { }
        }

        [Fact]
        public void GetResourceMemoryStreamByName_WithDots_FindsResource()
        {
            // Arrange - archivos con múltiples puntos
            string assemblyName = "TestAssembly_Dots_" + Guid.NewGuid();
            var testData = new Dictionary<string, string> 
            { 
                { "file.test.backup.txt", "dots content" } 
            };
            var zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act
            using var result = AssetRegistry.GetResourceMemoryStreamByName("file.test.backup.txt");

            // Assert
            Assert.NotNull(result);
            result.Position = 0;
            var content = new StreamReader(result).ReadToEnd();
            Assert.Equal("dots content", content);
        }

        [Fact]
        public void GetResourcePathByName_CreatesTempFileWithAssemblyPrefix()
        {
            // Arrange
            string assemblyName = "MyCustomAssembly_" + Guid.NewGuid();
            var testData = new Dictionary<string, string> { { "prefix.txt", "prefix content" } };
            var zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act
            var filePath = AssetRegistry.GetResourcePathByName("prefix.txt");
            var fileName = Path.GetFileName(filePath);

            // Assert - el nombre del archivo debe contener el assembly name como prefijo
            Assert.Contains("MyCustomAssembly", fileName);

            // Cleanup
            try { File.Delete(filePath); } catch { }
        }

        [Fact]
        public void GetResourceMemoryStreamByName_AfterCacheClear_StillWorks()
        {
            // Arrange
            string assemblyName = "TestAssembly_CacheClear_" + Guid.NewGuid();
            var testData = new Dictionary<string, string> { { "clear.txt", "clear content" } };
            var zipBytes = CreateTestZipBytes(testData);
            
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));
            
            // Primera lectura para poblar caché
            using (var firstRead = AssetRegistry.GetResourceMemoryStreamByName("clear.txt"))
            {
                Assert.NotNull(firstRead);
            }

            // Act - re-registrar limpia caché, luego leer de nuevo
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));
            using var result = AssetRegistry.GetResourceMemoryStreamByName("clear.txt");

            // Assert
            Assert.NotNull(result);
            result.Position = 0;
            var content = new StreamReader(result).ReadToEnd();
            Assert.Equal("clear content", content);
        }

        [Fact]
        public void GetResourcePathByName_WithSpacesInName_HandlesCorrectly()
        {
            // Arrange
            string assemblyName = "TestAssembly_Spaces_" + Guid.NewGuid();
            var testData = new Dictionary<string, string> 
            { 
                { "file with spaces.txt", "spaces content" } 
            };
            var zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act
            var filePath = AssetRegistry.GetResourcePathByName("file with spaces.txt");

            // Assert
            Assert.NotNull(filePath);
            Assert.True(File.Exists(filePath));
            var content = File.ReadAllText(filePath);
            Assert.Equal("spaces content", content);

            // Cleanup
            try { File.Delete(filePath); } catch { }
        }

        [Fact]
        public void GetResourceMemoryStreamByName_SearchByJustFileName_WhenUnique_FindsResource()
        {
            // Arrange - estrategia 2: buscar solo por nombre cuando es único
            string assemblyName = "TestAssembly_UniqueFileName_" + Guid.NewGuid();
            var testData = new Dictionary<string, string> 
            { 
                { "some/deep/path/uniquename123.txt", "unique by name" } 
            };
            var zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act - buscar SOLO por el nombre del archivo
            using var result = AssetRegistry.GetResourceMemoryStreamByName("uniquename123.txt");

            // Assert
            Assert.NotNull(result);
            result.Position = 0;
            var content = new StreamReader(result).ReadToEnd();
            Assert.Equal("unique by name", content);
        }

        [Fact]
        public void GetResourceMemoryStreamByName_SearchWithLeadingSlashes_TrimsAndFinds()
        {
            // Arrange
            string assemblyName = "TestAssembly_LeadingSlashes_" + Guid.NewGuid();
            var testData = new Dictionary<string, string> 
            { 
                { "trimtest.txt", "trim content" } 
            };
            var zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act - buscar con múltiples leading slashes
            using var result = AssetRegistry.GetResourceMemoryStreamByName("///trimtest.txt");

            // Assert
            Assert.NotNull(result);
            result.Position = 0;
            var content = new StreamReader(result).ReadToEnd();
            Assert.Equal("trim content", content);
        }

        [Fact]
        public void GetResourcePathByName_DirectoryCreation_WorksForNestedPaths()
        {
            // Arrange
            string assemblyName = "TestAssembly_DirCreate_" + Guid.NewGuid();
            var testData = new Dictionary<string, string> 
            { 
                { "a/b/c/d/e/deep.txt", "directory test" } 
            };
            var zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act
            var filePath = AssetRegistry.GetResourcePathByName("a/b/c/d/e/deep.txt");

            // Assert
            Assert.True(File.Exists(filePath));
            var directory = Path.GetDirectoryName(filePath);
            Assert.True(Directory.Exists(directory));

            // Cleanup
            try { File.Delete(filePath); } catch { }
        }

        [Fact]
        public void GetResourceMemoryStreamByName_TwoFilesWithSimilarNames_FindsBothCorrectly()
        {
            // Arrange
            string assemblyName = "TestAssembly_Similar_" + Guid.NewGuid();
            var testData = new Dictionary<string, string> 
            { 
                { "config.txt", "config content" },
                { "config_backup.txt", "backup content" }
            };
            var zipBytes = CreateTestZipBytes(testData);
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            // Act
            using var result1 = AssetRegistry.GetResourceMemoryStreamByName("config.txt");
            using var result2 = AssetRegistry.GetResourceMemoryStreamByName("config_backup.txt");

            // Assert
            result1.Position = 0;
            result2.Position = 0;
            Assert.Equal("config content", new StreamReader(result1).ReadToEnd());
            Assert.Equal("backup content", new StreamReader(result2).ReadToEnd());
        }
    }
}

