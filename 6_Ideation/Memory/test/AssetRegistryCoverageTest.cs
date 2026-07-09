// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AssetRegistryCoverageTest.cs
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
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Text;
using Xunit;

namespace Alis.Core.Aspect.Memory.Test
{
    /// <summary>
    /// The asset registry coverage test class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    [Collection("AssetRegistryCollection")]
    public class AssetRegistryCoverageTest : IDisposable
    {
        /// <summary>
        /// The static
        /// </summary>
        private static readonly PropertyInfo ActiveAssemblyProp = typeof(AssetRegistry).GetProperty("ActiveAssemblyName",
            BindingFlags.NonPublic | BindingFlags.Static);

        /// <summary>
        /// The static
        /// </summary>
        private static readonly FieldInfo LoadersField = typeof(AssetRegistry).GetField("RegisteredAssetLoaders",
            BindingFlags.NonPublic | BindingFlags.Static);

        /// <summary>
        /// The static
        /// </summary>
        private static readonly FieldInfo ZipCacheField = typeof(AssetRegistry).GetField("_zipCache",
            BindingFlags.NonPublic | BindingFlags.Static);

        /// <summary>
        /// The static
        /// </summary>
        private static readonly FieldInfo PathCacheField = typeof(AssetRegistry).GetField("_extractedPathCache",
            BindingFlags.NonPublic | BindingFlags.Static);

        /// <summary>
        /// The saved assembly
        /// </summary>
        private readonly string _savedAssembly;
        /// <summary>
        /// The saved loaders
        /// </summary>
        private readonly Dictionary<object, object> _savedLoaders = new();
        /// <summary>
        /// The saved zip cache
        /// </summary>
        private readonly Dictionary<object, object> _savedZipCache = new();
        /// <summary>
        /// The saved path cache
        /// </summary>
        private readonly Dictionary<object, object> _savedPathCache = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="AssetRegistryCoverageTest"/> class
        /// </summary>
        public AssetRegistryCoverageTest()
        {
            _savedAssembly = (string)ActiveAssemblyProp.GetValue(null);
            foreach (DictionaryEntry e in GetLoaders()) _savedLoaders[e.Key] = e.Value;
            foreach (DictionaryEntry e in GetZipCache()) _savedZipCache[e.Key] = e.Value;
            foreach (DictionaryEntry e in GetPathCache()) _savedPathCache[e.Key] = e.Value;
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            ActiveAssemblyProp.SetValue(null, _savedAssembly);
            Restore(GetLoaders(), _savedLoaders);
            Restore(GetZipCache(), _savedZipCache);
            Restore(GetPathCache(), _savedPathCache);
        }

        /// <summary>
        /// Restores the target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="saved">The saved</param>
        private static void Restore(IDictionary target, Dictionary<object, object> saved)
        {
            target.Clear();
            foreach (KeyValuePair<object, object> kvp in saved)
                target[kvp.Key] = kvp.Value;
        }

        /// <summary>
        /// Gets the loaders
        /// </summary>
        /// <returns>The dictionary</returns>
        private static IDictionary GetLoaders() => (IDictionary)LoadersField.GetValue(null);
        /// <summary>
        /// Gets the zip cache
        /// </summary>
        /// <returns>The dictionary</returns>
        private static IDictionary GetZipCache() => (IDictionary)ZipCacheField.GetValue(null);
        /// <summary>
        /// Gets the path cache
        /// </summary>
        /// <returns>The dictionary</returns>
        private static IDictionary GetPathCache() => (IDictionary)PathCacheField.GetValue(null);

        /// <summary>
        /// Creates the test zip bytes using the specified entries
        /// </summary>
        /// <param name="entries">The entries</param>
        /// <returns>The byte array</returns>
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
        /// Setup the assembly using the specified assembly name
        /// </summary>
        /// <param name="assemblyName">The assembly name</param>
        /// <param name="zipBytes">The zip bytes</param>
        private static void SetupAssembly(string assemblyName, byte[] zipBytes)
        {
            ActiveAssemblyProp.SetValue(null, null);
            GetLoaders().Clear();
            GetZipCache().Clear();
            GetPathCache().Clear();
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));
        }

        /// <summary>
        /// Tests that make safe temp name no extension generates name without extension
        /// </summary>
        [Fact]
        public void MakeSafeTempName_NoExtension_GeneratesNameWithoutExtension()
        {
            MethodInfo method = typeof(AssetRegistry).GetMethod("MakeSafeTempName",
                BindingFlags.NonPublic | BindingFlags.Static);

            string result = (string)method.Invoke(null, new object[] { "TestAssembly", "Makefile" });

            Assert.NotNull(result);
            Assert.StartsWith("TestAssembly_", result);
            Assert.DoesNotContain(".", result.Substring("TestAssembly_".Length));
        }

        /// <summary>
        /// Tests that make safe temp name extension length exactly 16 keeps extension
        /// </summary>
        [Fact]
        public void MakeSafeTempName_ExtensionLengthExactly16_KeepsExtension()
        {
            MethodInfo method = typeof(AssetRegistry).GetMethod("MakeSafeTempName",
                BindingFlags.NonPublic | BindingFlags.Static);

            string ext15 = new string('x', 15);
            string result = (string)method.Invoke(null, new object[] { "TestAssembly", "file." + ext15 });

            Assert.NotNull(result);
            Assert.StartsWith("TestAssembly_", result);
            Assert.EndsWith("." + ext15, result);
        }

        /// <summary>
        /// Tests that get resource memory stream by name duplicate filenames resolves by full path
        /// </summary>
        [Fact]
        public void GetResourceMemoryStreamByName_DuplicateFilenames_ResolvesByFullPath()
        {
            string assemblyName = "DupFile1_" + Guid.NewGuid();
            byte[] zipBytes = CreateTestZipBytes(new Dictionary<string, string>
            {
                {"dir1/data.xml", "content1"},
                {"dir2/data.xml", "content2"}
            });
            SetupAssembly(assemblyName, zipBytes);

            using MemoryStream result = AssetRegistry.GetResourceMemoryStreamByName("dir1/data.xml");
            Assert.NotNull(result);
            Assert.True(result.Length > 0);
        }

        /// <summary>
        /// Tests that get resource memory stream by name duplicate filenames resolves by partial path
        /// </summary>
        [Fact]
        public void GetResourceMemoryStreamByName_DuplicateFilenames_ResolvesByPartialPath()
        {
            string assemblyName = "DupPartial_" + Guid.NewGuid();
            byte[] zipBytes = CreateTestZipBytes(new Dictionary<string, string>
            {
                {"dir1/data.xml", "content1"},
                {"dir2/data.xml", "content2"}
            });
            SetupAssembly(assemblyName, zipBytes);

            using MemoryStream result = AssetRegistry.GetResourceMemoryStreamByName("dir2");
            Assert.NotNull(result);
            Assert.True(result.Length > 0);
        }

        /// <summary>
        /// Tests that get resource memory stream by name resource without extension returns stream
        /// </summary>
        [Fact]
        public void GetResourceMemoryStreamByName_ResourceWithoutExtension_ReturnsStream()
        {
            string assemblyName = "NoExt1_" + Guid.NewGuid();
            byte[] zipBytes = CreateTestZipBytes(new Dictionary<string, string>
            {
                {"Makefile", "all: clean"}
            });
            SetupAssembly(assemblyName, zipBytes);

            using MemoryStream result = AssetRegistry.GetResourceMemoryStreamByName("Makefile");
            Assert.NotNull(result);
            Assert.True(result.Length > 0);

            result.Position = 0;
            byte[] buffer = new byte[result.Length];
            int bytesRead = result.Read(buffer, 0, buffer.Length);
            string content = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            Assert.Equal("all: clean", content);
        }

        /// <summary>
        /// Tests that get resource memory stream by name subdir resource returns content
        /// </summary>
        [Fact]
        public void GetResourceMemoryStreamByName_SubdirResource_ReturnsContent()
        {
            string assemblyName = "Subdir1_" + Guid.NewGuid();
            byte[] zipBytes = CreateTestZipBytes(new Dictionary<string, string>
            {
                {"assets/images/icon.png", "png content"},
                {"assets/sounds/beep.wav", "wav content"}
            });
            SetupAssembly(assemblyName, zipBytes);

            using MemoryStream result = AssetRegistry.GetResourceMemoryStreamByName("assets/sounds/beep.wav");
            Assert.NotNull(result);
            Assert.True(result.Length > 0);
        }

        /// <summary>
        /// Tests that get resource path by name resource without extension returns path
        /// </summary>
        [Fact]
        public void GetResourcePathByName_ResourceWithoutExtension_ReturnsPath()
        {
            string assemblyName = "NoExtPath1_" + Guid.NewGuid();
            byte[] zipBytes = CreateTestZipBytes(new Dictionary<string, string>
            {
                {"README", "This is the readme"}
            });
            SetupAssembly(assemblyName, zipBytes);

            string result = AssetRegistry.GetResourcePathByName("README");
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.True(File.Exists(result));
            Assert.Equal("This is the readme", File.ReadAllText(result));
        }

        /// <summary>
        /// Tests that get resource memory stream by name triple duplicate filenames resolves by full path
        /// </summary>
        [Fact]
        public void GetResourceMemoryStreamByName_TripleDuplicateFilenames_ResolvesByFullPath()
        {
            string assemblyName = "TripleDup1_" + Guid.NewGuid();
            byte[] zipBytes = CreateTestZipBytes(new Dictionary<string, string>
            {
                {"a/config.xml", "a-content"},
                {"b/config.xml", "b-content"},
                {"c/config.xml", "c-content"}
            });
            SetupAssembly(assemblyName, zipBytes);

            using MemoryStream result = AssetRegistry.GetResourceMemoryStreamByName("b/config.xml");
            Assert.NotNull(result);
            Assert.True(result.Length > 0);
        }

        /// <summary>
        /// Tests that get resource memory stream by name partial match via index of finds resource
        /// </summary>
        [Fact]
        public void GetResourceMemoryStreamByName_PartialMatchViaIndexOf_FindsResource()
        {
            string assemblyName = "IndexOf1_" + Guid.NewGuid();
            byte[] zipBytes = CreateTestZipBytes(new Dictionary<string, string>
            {
                {"deeply/nested/path/to/config.ini", "config content"}
            });
            SetupAssembly(assemblyName, zipBytes);

            using MemoryStream result = AssetRegistry.GetResourceMemoryStreamByName("nested/path");
            Assert.NotNull(result);
            Assert.True(result.Length > 0);
        }

        /// <summary>
        /// Tests that ensure zip cached duplicate filenames builds cache correctly
        /// </summary>
        [Fact]
        public void EnsureZipCached_DuplicateFilenames_BuildsCacheCorrectly()
        {
            string assemblyName = "CacheDup1_" + Guid.NewGuid();
            byte[] zipBytes = CreateTestZipBytes(new Dictionary<string, string>
            {
                {"folder1/data.bin", "data1"},
                {"folder2/data.bin", "data2"}
            });
            SetupAssembly(assemblyName, zipBytes);

            string path1 = AssetRegistry.GetResourcePathByName("folder1/data.bin");
            Assert.NotNull(path1);
            Assert.True(File.Exists(path1));
            Assert.Equal("data1", File.ReadAllText(path1));
        }

        /// <summary>
        /// Tests that get resource memory stream by name backslash in resource name finds resource
        /// </summary>
        [Fact]
        public void GetResourceMemoryStreamByName_BackslashInResourceName_FindsResource()
        {
            string assemblyName = "Backslash1_" + Guid.NewGuid();
            byte[] zipBytes = CreateTestZipBytes(new Dictionary<string, string>
            {
                {"dir/file.txt", "content"}
            });
            SetupAssembly(assemblyName, zipBytes);

            using MemoryStream result = AssetRegistry.GetResourceMemoryStreamByName("dir\\file.txt");
            Assert.NotNull(result);
            Assert.True(result.Length > 0);
        }

        /// <summary>
        /// Tests that register assembly clears extracted path cache for assembly
        /// </summary>
        [Fact]
        public void RegisterAssembly_ClearsExtractedPathCacheForAssembly()
        {
            string assemblyName = "ClearCache1_" + Guid.NewGuid();

            byte[] zipBytes = CreateTestZipBytes(new Dictionary<string, string> {{"file.txt", "first version"}});
            SetupAssembly(assemblyName, zipBytes);

            string path = AssetRegistry.GetResourcePathByName("file.txt");
            Assert.True(File.Exists(path));

            byte[] zipBytes2 = CreateTestZipBytes(new Dictionary<string, string> {{"file.txt", "second version"}});
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes2, false));

            string path2 = AssetRegistry.GetResourcePathByName("file.txt");
            Assert.NotNull(path2);
            Assert.True(File.Exists(path2));
            Assert.Equal("second version", File.ReadAllText(path2));
        }
    }
}
