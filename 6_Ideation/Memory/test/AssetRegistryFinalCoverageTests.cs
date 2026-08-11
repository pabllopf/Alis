// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AssetRegistryFinalCoverageTests.cs
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
    ///     Tests targeting the final uncovered lines in AssetRegistry.
    /// </summary>
    [Collection("AssetRegistryCollection")]
    public class AssetRegistryFinalCoverageTests : IDisposable
    {
        /// <summary>
        ///     The active assembly property
        /// </summary>
        private static readonly PropertyInfo ActiveAssemblyProp = typeof(AssetRegistry).GetProperty("ActiveAssemblyName",
            BindingFlags.NonPublic | BindingFlags.Static);

        /// <summary>
        ///     The loaders field
        /// </summary>
        private static readonly FieldInfo LoadersField = typeof(AssetRegistry).GetField("RegisteredAssetLoaders",
            BindingFlags.NonPublic | BindingFlags.Static);

        /// <summary>
        ///     The zip cache field
        /// </summary>
        private static readonly FieldInfo ZipCacheField = typeof(AssetRegistry).GetField("_zipCache",
            BindingFlags.NonPublic | BindingFlags.Static);

        /// <summary>
        ///     The path cache field
        /// </summary>
        private static readonly FieldInfo PathCacheField = typeof(AssetRegistry).GetField("_extractedPathCache",
            BindingFlags.NonPublic | BindingFlags.Static);

        /// <summary>
        ///     The saved assembly
        /// </summary>
        private readonly string _savedAssembly;

        /// <summary>
        ///     The saved loaders
        /// </summary>
        private readonly Dictionary<object, object> _savedLoaders = new();

        /// <summary>
        ///     The saved zip cache
        /// </summary>
        private readonly Dictionary<object, object> _savedZipCache = new();

        /// <summary>
        ///     The saved path cache
        /// </summary>
        private readonly Dictionary<object, object> _savedPathCache = new();

        /// <summary>
        ///     Initializes a new instance of the AssetRegistryFinalCoverageTests class
        /// </summary>
        public AssetRegistryFinalCoverageTests()
        {
            _savedAssembly = (string) ActiveAssemblyProp.GetValue(null);
            foreach (DictionaryEntry e in GetLoaders())
            {
                _savedLoaders[e.Key] = e.Value;
            }

            foreach (DictionaryEntry e in GetZipCache())
            {
                _savedZipCache[e.Key] = e.Value;
            }

            foreach (DictionaryEntry e in GetPathCache())
            {
                _savedPathCache[e.Key] = e.Value;
            }
        }

        /// <summary>
        ///     Disposes this instance restoring all static state
        /// </summary>
        public void Dispose()
        {
            ActiveAssemblyProp.SetValue(null, _savedAssembly);
            Restore(GetLoaders(), _savedLoaders);
            Restore(GetZipCache(), _savedZipCache);
            Restore(GetPathCache(), _savedPathCache);
        }

        /// <summary>
        ///     Restores the target dictionary from the saved values
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="saved">The saved</param>
        private static void Restore(IDictionary target, Dictionary<object, object> saved)
        {
            target.Clear();
            foreach (KeyValuePair<object, object> kvp in saved)
            {
                target[kvp.Key] = kvp.Value;
            }
        }

        /// <summary>
        ///     Gets the loaders dictionary
        /// </summary>
        /// <returns>The dictionary</returns>
        private static IDictionary GetLoaders() => (IDictionary) LoadersField.GetValue(null);

        /// <summary>
        ///     Gets the zip cache dictionary
        /// </summary>
        /// <returns>The dictionary</returns>
        private static IDictionary GetZipCache() => (IDictionary) ZipCacheField.GetValue(null);

        /// <summary>
        ///     Gets the path cache dictionary
        /// </summary>
        /// <returns>The dictionary</returns>
        private static IDictionary GetPathCache() => (IDictionary) PathCacheField.GetValue(null);

        /// <summary>
        ///     Creates test zip bytes from the given entries
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
        ///     Sets up a fresh assembly state with the given zip bytes
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
        ///     Tests that re-registering an assembly removes extracted path cache entries
        ///     with the matching prefix, covering lines 114-116.
        /// </summary>
        [Fact]
        public void RegisterAssembly_WithExtractedPaths_RemovesCachedEntries()
        {
            string assemblyName = "Prefix_" + Guid.NewGuid();
            byte[] zipBytes = CreateTestZipBytes(new Dictionary<string, string> {{"data/file.txt", "hello"}});
            SetupAssembly(assemblyName, zipBytes);

            string first = AssetRegistry.GetResourcePathByName("data/file.txt");
            string second = AssetRegistry.GetResourcePathByName("data/file.txt");
            Assert.Equal(first, second);

            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));

            string third = AssetRegistry.GetResourcePathByName("data/file.txt");
            Assert.True(File.Exists(third));
        }

        /// <summary>
        ///     Tests that GetResourceMemoryStreamByName throws when the active assembly
        ///     has no registered loader, covering lines 185-186.
        /// </summary>
        [Fact]
        public void GetResourceMemoryStream_WithUnregisteredActiveAssembly_ThrowsInvalidOperation()
        {
            string missingName = "Missing_" + Guid.NewGuid();
            ActiveAssemblyProp.SetValue(null, missingName);
            GetLoaders().Clear();
            GetZipCache().Clear();
            GetPathCache().Clear();

            Assert.Throws<InvalidOperationException>(() => AssetRegistry.GetResourceMemoryStreamByName("x.txt"));
        }

        /// <summary>
        ///     Tests that GetResourcePathByName re-extracts when the cached temp file
        ///     length no longer matches the archive entry, covering lines 325-326.
        /// </summary>
        [Fact]
        public void GetResourcePath_WithModifiedCachedFile_ReExtracts()
        {
            string assemblyName = "Stale_" + Guid.NewGuid();
            byte[] zipBytes = CreateTestZipBytes(new Dictionary<string, string> {{"file.txt", "hello"}});
            SetupAssembly(assemblyName, zipBytes);

            string path = AssetRegistry.GetResourcePathByName("file.txt");
            AssetRegistry.GetResourcePathByName("file.txt");

            File.AppendAllText(path, "corruption");

            string reExtracted = AssetRegistry.GetResourcePathByName("file.txt");
            Assert.Equal("hello", File.ReadAllText(reExtracted));
        }

        /// <summary>
        ///     Tests that a resource name with an extension longer than 16 characters
        ///     produces a safe temp name with no extension, covering lines 436-438.
        /// </summary>
        [Fact]
        public void GetResourcePath_WithLongExtension_ExtractsSuccessfully()
        {
            string assemblyName = "LongExt_" + Guid.NewGuid();
            string resourceName = "file.verylongextensionthatexceeds16chars";
            byte[] zipBytes = CreateTestZipBytes(new Dictionary<string, string> {{resourceName, "content"}});
            SetupAssembly(assemblyName, zipBytes);

            string path = AssetRegistry.GetResourcePathByName(resourceName);
            Assert.True(File.Exists(path));
        }

        /// <summary>
        ///     Tests that a loader returning null triggers a FileNotFoundException,
        ///     covering lines 547-548.
        /// </summary>
        [Fact]
        public void GetResourcePath_WithNullLoaderStream_ThrowsFileNotFound()
        {
            string assemblyName = "NullLoader_" + Guid.NewGuid();
            ActiveAssemblyProp.SetValue(null, null);
            GetLoaders().Clear();
            GetZipCache().Clear();
            GetPathCache().Clear();
            AssetRegistry.RegisterAssembly(assemblyName, () => null);

            Assert.Throws<FileNotFoundException>(() => AssetRegistry.GetResourcePathByName("file.txt"));
        }

        /// <summary>
        ///     Tests that GetResourcePathByName throws when the active assembly
        ///     has no registered loader, covering lines 655-656.
        /// </summary>
        [Fact]
        public void GetResourcePath_WithUnregisteredActiveAssembly_ThrowsInvalidOperation()
        {
            string missingName = "Missing_" + Guid.NewGuid();
            ActiveAssemblyProp.SetValue(null, missingName);
            GetLoaders().Clear();
            GetZipCache().Clear();
            GetPathCache().Clear();

            Assert.Throws<InvalidOperationException>(() => AssetRegistry.GetResourcePathByName("x.txt"));
        }
    }
}
