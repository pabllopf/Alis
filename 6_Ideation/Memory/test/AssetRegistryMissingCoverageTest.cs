// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AssetRegistryMissingCoverageTest.cs
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
    ///     Tests targeting specific uncovered branches in AssetRegistry.
    /// </summary>
    [Collection("AssetRegistryCollection")]
    public class AssetRegistryMissingCoverageTest : IDisposable
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
        internal readonly string _savedAssembly;
        /// <summary>
        /// The saved loaders
        /// </summary>
        internal readonly Dictionary<object, object> _savedLoaders = new();
        /// <summary>
        /// The saved zip cache
        /// </summary>
        internal readonly Dictionary<object, object> _savedZipCache = new();
        /// <summary>
        /// The saved path cache
        /// </summary>
        internal readonly Dictionary<object, object> _savedPathCache = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="AssetRegistryMissingCoverageTest"/> class
        /// </summary>
        public AssetRegistryMissingCoverageTest()
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
        ///     Tests that MakeSafeTempName with a very long resource name triggers
        ///     the ArrayPool rental branch (maxByteCount > 256), covering lines 453-455.
        /// </summary>
        [Fact]
        public void MakeSafeTempName_LongResourceName_RentsBuffer()
        {
            string longName = new string('a', 86) + ".txt";
            byte[] zipBytes = CreateTestZipBytes(new Dictionary<string, string> {{longName, "content"}});
            string assemblyName = "LongNameTest_" + Guid.NewGuid();
            SetupAssembly(assemblyName, zipBytes);

            string path = AssetRegistry.GetResourcePathByName(longName);
            Assert.NotNull(path);
            Assert.True(File.Exists(path));
        }

    /// <summary>
    ///     Tests that ToLowerHex(ReadOnlySpan&lt;byte&gt;) with an empty span
    ///     returns empty string, covering lines 497-498.
    /// </summary>
    private delegate string ToLowerHexSpanDelegate(ReadOnlySpan<byte> bytes);

    /// <summary>
    /// Tests that to lower hex empty span returns empty
    /// </summary>
    [Fact]
    public void ToLowerHex_EmptySpan_ReturnsEmpty()
    {
        MethodInfo method = typeof(AssetRegistry).GetMethod("ToLowerHex",
            BindingFlags.NonPublic | BindingFlags.Static,
            null,
            new[] { typeof(ReadOnlySpan<byte>) },
            null);

        if (method == null)
        {
            return;
        }

        ToLowerHexSpanDelegate del = (ToLowerHexSpanDelegate)method.CreateDelegate(typeof(ToLowerHexSpanDelegate));
        string result = del(ReadOnlySpan<byte>.Empty);
        Assert.Equal(string.Empty, result);
    }

        /// <summary>
        ///     Tests that FindZipEntryInfo resolves by unique file name when
        ///     the full path does not match, covering lines 613-614.
        /// </summary>
        [Fact]
        public void FindZipEntryInfo_UniqueFileNameMatch_ReturnsEntry()
        {
            string assemblyName = "UniqueFileName_" + Guid.NewGuid();
            byte[] zipBytes = CreateTestZipBytes(new Dictionary<string, string>
            {
                {"some/path/file.txt", "content"}
            });
            SetupAssembly(assemblyName, zipBytes);

            // Request with a different path but same file name
            using MemoryStream result = AssetRegistry.GetResourceMemoryStreamByName("other/file.txt");
            Assert.NotNull(result);
            Assert.True(result.Length > 0);
        }
    }
}
