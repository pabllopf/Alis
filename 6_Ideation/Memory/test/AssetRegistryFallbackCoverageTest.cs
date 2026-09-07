// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AssetRegistryFallbackCoverageTest.cs
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
    ///     Tests targeting the fallback search branch of AssetRegistry.FindZipEntryInfo
    ///     where an unqualified resource name resolves through a suffix match of the
    ///     full archive path.
    /// </summary>
    [Collection("AssetRegistryCollection")]
    public class AssetRegistryFallbackCoverageTest : IDisposable
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
        ///     Initializes a new instance of the AssetRegistryFallbackCoverageTest class
        /// </summary>
        public AssetRegistryFallbackCoverageTest()
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
        ///     Tests that an unqualified resource name resolving to a unique archive entry
        ///     through the file-name index is returned directly, covering the single-entry
        ///     file-name match branch of FindZipEntryInfo.
        /// </summary>
        [Fact]
        public void GetResourceMemoryStreamByName_BareFileNameUnique_ResolvesThroughFileNameIndex()
        {
            string assemblyName = "BareUnique_" + Guid.NewGuid();
            byte[] zipBytes = CreateTestZipBytes(new Dictionary<string, string> {{"dir1/unique.ini", "value"}});
            SetupAssembly(assemblyName, zipBytes);

            using MemoryStream result = AssetRegistry.GetResourceMemoryStreamByName("unique.ini");
            Assert.NotNull(result);
            Assert.True(result.Length > 0);
        }

        /// <summary>
        ///     Tests that when several entries share the same file name, an unqualified
        ///     lookup falls back to the full-path suffix search and resolves the first
        ///     entry whose normalized full name ends with the resource name, covering the
        ///     EndsWith branch of the FindZipEntryInfo fallback loop.
        /// </summary>
        [Fact]
        public void GetResourceMemoryStreamByName_BareFileNameAmbiguous_ResolvesViaEndsWithFallback()
        {
            string assemblyName = "BareAmb_" + Guid.NewGuid();
            byte[] zipBytes = CreateTestZipBytes(new Dictionary<string, string>
            {
                {"dir1/data.xml", "content1"},
                {"dir2/data.xml", "content2"}
            });
            SetupAssembly(assemblyName, zipBytes);

            using MemoryStream result = AssetRegistry.GetResourceMemoryStreamByName("data.xml");
            Assert.NotNull(result);
            Assert.True(result.Length > 0);
        }

        /// <summary>
        ///     Tests that mixing short and long extensions across directories keeps the
        ///     extraction path working for a bare, non-ambiguous file name, exercising the
        ///     fallback loop across entries that do not end with the requested name.
        /// </summary>
        [Fact]
        public void GetResourcePathByName_BareFileNameMixedDirs_ExtractsContent()
        {
            string assemblyName = "BareMix_" + Guid.NewGuid();
            byte[] zipBytes = CreateTestZipBytes(new Dictionary<string, string>
            {
                {"assets/a.png", "image"},
                {"assets/b.jpg", "photo"},
                {"legacy/notes.txt", "notes"}
            });
            SetupAssembly(assemblyName, zipBytes);

            string path = AssetRegistry.GetResourcePathByName("notes.txt");
            Assert.True(File.Exists(path));
            Assert.Equal("notes", File.ReadAllText(path));
        }
    }
}