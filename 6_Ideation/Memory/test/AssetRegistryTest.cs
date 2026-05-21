

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
        
    }
}