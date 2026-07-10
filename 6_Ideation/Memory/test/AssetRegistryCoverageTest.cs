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
    [Collection("AssetRegistryCollection")]
    public class AssetRegistryCoverageTest : IDisposable
    {
        private static readonly PropertyInfo ActiveAssemblyProp = typeof(AssetRegistry).GetProperty("ActiveAssemblyName",
            BindingFlags.NonPublic | BindingFlags.Static);

        private static readonly FieldInfo LoadersField = typeof(AssetRegistry).GetField("RegisteredAssetLoaders",
            BindingFlags.NonPublic | BindingFlags.Static);

        private static readonly FieldInfo ZipCacheField = typeof(AssetRegistry).GetField("_zipCache",
            BindingFlags.NonPublic | BindingFlags.Static);

        private static readonly FieldInfo PathCacheField = typeof(AssetRegistry).GetField("_extractedPathCache",
            BindingFlags.NonPublic | BindingFlags.Static);

        private readonly string _savedAssembly;
        private readonly Dictionary<object, object> _savedLoaders = new();
        private readonly Dictionary<object, object> _savedZipCache = new();
        private readonly Dictionary<object, object> _savedPathCache = new();

        public AssetRegistryCoverageTest()
        {
            _savedAssembly = (string)ActiveAssemblyProp.GetValue(null);
            foreach (DictionaryEntry e in GetLoaders()) _savedLoaders[e.Key] = e.Value;
            foreach (DictionaryEntry e in GetZipCache()) _savedZipCache[e.Key] = e.Value;
            foreach (DictionaryEntry e in GetPathCache()) _savedPathCache[e.Key] = e.Value;
        }

        public void Dispose()
        {
            ActiveAssemblyProp.SetValue(null, _savedAssembly);
            Restore(GetLoaders(), _savedLoaders);
            Restore(GetZipCache(), _savedZipCache);
            Restore(GetPathCache(), _savedPathCache);
        }

        private static void Restore(IDictionary target, Dictionary<object, object> saved)
        {
            target.Clear();
            foreach (KeyValuePair<object, object> kvp in saved)
                target[kvp.Key] = kvp.Value;
        }

        private static IDictionary GetLoaders() => (IDictionary)LoadersField.GetValue(null);
        private static IDictionary GetZipCache() => (IDictionary)ZipCacheField.GetValue(null);
        private static IDictionary GetPathCache() => (IDictionary)PathCacheField.GetValue(null);

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

        private static void SetupAssembly(string assemblyName, byte[] zipBytes)
        {
            ActiveAssemblyProp.SetValue(null, null);
            GetLoaders().Clear();
            GetZipCache().Clear();
            GetPathCache().Clear();
            AssetRegistry.RegisterAssembly(assemblyName, () => new MemoryStream(zipBytes, false));
        }

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

        [Fact]
        public void GetResourceMemoryStreamByName_CacheMissAfterEnsure_ThrowsFileNotFoundException()
        {
            string assemblyName = "CacheMiss_" + Guid.NewGuid();
            byte[] zipBytes = CreateTestZipBytes(new Dictionary<string, string> {{"file.txt", "content"}});
            SetupAssembly(assemblyName, zipBytes);

            AssetRegistry.GetResourceMemoryStreamByName("file.txt")?.Dispose();

            var field = typeof(AssetRegistry).GetField("_zipCache",
                BindingFlags.NonPublic | BindingFlags.Static);
            var original = (IDictionary)field.GetValue(null);
            try
            {
                var wrapper = new CacheMissDict(original, assemblyName);
                field.SetValue(null, wrapper);

                FileNotFoundException ex = Assert.Throws<FileNotFoundException>(() =>
                    AssetRegistry.GetResourceMemoryStreamByName("file.txt"));
                Assert.Contains("Cache del assets.pack no disponible", ex.Message);
            }
            finally
            {
                field.SetValue(null, original);
            }
        }

        [Fact]
        public void GetResourcePathByName_CacheMissAfterEnsure_ThrowsFileNotFoundException()
        {
            string assemblyName = "CacheMissPath_" + Guid.NewGuid();
            byte[] zipBytes = CreateTestZipBytes(new Dictionary<string, string> {{"file.txt", "content"}});
            SetupAssembly(assemblyName, zipBytes);

            AssetRegistry.GetResourcePathByName("file.txt");

            var field = typeof(AssetRegistry).GetField("_zipCache",
                BindingFlags.NonPublic | BindingFlags.Static);
            var original = (IDictionary)field.GetValue(null);
            try
            {
                var wrapper = new CacheMissDict(original, assemblyName);
                field.SetValue(null, wrapper);

                FileNotFoundException ex = Assert.Throws<FileNotFoundException>(() =>
                    AssetRegistry.GetResourcePathByName("file.txt"));
                Assert.Contains("Cache del assets.pack no disponible", ex.Message);
            }
            finally
            {
                field.SetValue(null, original);
            }
        }

        [Fact]
        public void GetResourceMemoryStreamByName_ZipEntryNull_ThrowsFileNotFoundException()
        {
            string assemblyName = "ZipEntryNull_" + Guid.NewGuid();
            byte[] zipBytes = CreateTestZipBytes(new Dictionary<string, string> {{"real.txt", "content"}});
            SetupAssembly(assemblyName, zipBytes);

            AssetRegistry.GetResourceMemoryStreamByName("real.txt")?.Dispose();

            var zipCache = GetZipCache();
            var entry = (ZipCacheEntry)zipCache[assemblyName];

            string originalKey = null;
            foreach (var kvp in entry.EntriesByFullNameLower)
            {
                if (kvp.Value.FullName == "real.txt")
                {
                    originalKey = kvp.Key;
                    break;
                }
            }

            if (entry.EntriesByFullNameLower.TryGetValue("real.txt", out var info))
            {
                info.FullName = "nonexistent.txt";
            }

            try
            {
                FileNotFoundException ex = Assert.Throws<FileNotFoundException>(() =>
                    AssetRegistry.GetResourceMemoryStreamByName("real.txt"));
                Assert.Contains("race", ex.Message);
            }
            finally
            {
                if (info != null)
                {
                    info.FullName = "real.txt";
                }
            }
        }

        [Fact]
        public void TryGetCachedPath_EntryCandidateNull_RemovesCacheEntry()
        {
            string assemblyName = "NullCandidate_" + Guid.NewGuid();
            byte[] zipBytes = CreateTestZipBytes(new Dictionary<string, string> {{"file.txt", "content"}});
            SetupAssembly(assemblyName, zipBytes);

            string path = AssetRegistry.GetResourcePathByName("file.txt");
            Assert.True(File.Exists(path));

            var zipCache = GetZipCache();
            var entry = (ZipCacheEntry)zipCache[assemblyName];
            entry.EntriesByFullNameLower.Clear();
            entry.EntriesByFileNameLower.Clear();

            FileNotFoundException ex = Assert.Throws<FileNotFoundException>(() =>
                AssetRegistry.GetResourcePathByName("file.txt"));
            Assert.Contains("not found in `assets.pack`", ex.Message);

            string compositeKey = assemblyName.ToLowerInvariant() + "|file.txt";
            Assert.False(GetPathCache().Contains(compositeKey));
        }

        [Fact]
        public void EnsureZipCachedForActiveAssembly_LoaderMissing_ThrowsInvalidOperationException()
        {
            string assemblyName = "LoaderMiss_" + Guid.NewGuid();
            byte[] zipBytes = CreateTestZipBytes(new Dictionary<string, string> {{"file.txt", "content"}});
            SetupAssembly(assemblyName, zipBytes);

            AssetRegistry.GetResourceMemoryStreamByName("file.txt")?.Dispose();

            var loadersField = typeof(AssetRegistry).GetField("RegisteredAssetLoaders",
                BindingFlags.NonPublic | BindingFlags.Static);
            var original = (IDictionary)loadersField.GetValue(null);
            try
            {
                var wrapper = new LoaderMissingDict(original, assemblyName);
                loadersField.SetValue(null, wrapper);

                var zipCache = GetZipCache();
                zipCache.Remove(assemblyName);

                InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
                    AssetRegistry.GetResourceMemoryStreamByName("file.txt"));
                Assert.Contains("no tiene un assets.pack registrado", ex.Message);
            }
            finally
            {
                loadersField.SetValue(null, original);
            }
        }

        [Fact]
        public void GetResourceMemoryStreamByName_LengthExceedsMaxInt_CreatesMemoryStreamWithoutCapacity()
        {
            string assemblyName = "BigLen_" + Guid.NewGuid();
            byte[] zipBytes = CreateTestZipBytes(new Dictionary<string, string> {{"file.txt", "content"}});
            SetupAssembly(assemblyName, zipBytes);

            AssetRegistry.GetResourceMemoryStreamByName("file.txt")?.Dispose();

            var zipCache = GetZipCache();
            var entry = (ZipCacheEntry)zipCache[assemblyName];
            var info = entry.EntriesByFullNameLower["file.txt"];
            long originalLength = info.Length;
            info.Length = (long)int.MaxValue + 1;

            try
            {
                using MemoryStream result = AssetRegistry.GetResourceMemoryStreamByName("file.txt");
                Assert.NotNull(result);
                Assert.True(result.Length > 0);
            }
            finally
            {
                info.Length = originalLength;
            }
        }

        private sealed class CacheMissDict : IDictionary
        {
            private readonly IDictionary _inner;
            private readonly string _missKey;

            public CacheMissDict(IDictionary inner, string missKey)
            {
                _inner = inner;
                _missKey = missKey;
            }

            public bool Contains(object key)
            {
                if (key is string s && s == _missKey)
                    return false;
                return _inner.Contains(key);
            }

            public object this[object key]
            {
                get => _inner[key];
                set => _inner[key] = value;
            }

            public bool TryGetValue(string key, out ZipCacheEntry value)
            {
                if (key == _missKey)
                {
                    value = null;
                    return false;
                }
                if (_inner.Contains(key))
                {
                    value = (ZipCacheEntry)_inner[key];
                    return true;
                }
                value = null;
                return false;
            }

            public void Add(object key, object value) => _inner.Add(key, value);
            public void Clear() => _inner.Clear();
            public IDictionaryEnumerator GetEnumerator() => _inner.GetEnumerator();
            public void Remove(object key) => _inner.Remove(key);
            public bool IsFixedSize => _inner.IsFixedSize;
            public bool IsReadOnly => _inner.IsReadOnly;
            public ICollection Keys => _inner.Keys;
            public ICollection Values => _inner.Values;
            IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_inner).GetEnumerator();
            public void CopyTo(Array array, int index) => _inner.CopyTo(array, index);
            public int Count => _inner.Count;
            public bool IsSynchronized => _inner.IsSynchronized;
            public object SyncRoot => _inner.SyncRoot;
        }

        private sealed class LoaderMissingDict : IDictionary
        {
            private readonly IDictionary _inner;
            private readonly string _missKey;

            public LoaderMissingDict(IDictionary inner, string missKey)
            {
                _inner = inner;
                _missKey = missKey;
            }

            public bool Contains(object key)
            {
                if (key is string s && s == _missKey)
                    return true;
                return _inner.Contains(key);
            }

            public object this[object key]
            {
                get => _inner[key];
                set => _inner[key] = value;
            }

            public bool TryGetValue(string key, out Func<Stream> value)
            {
                if (key == _missKey)
                {
                    value = null;
                    return false;
                }
                if (_inner.Contains(key))
                {
                    value = (Func<Stream>)_inner[key];
                    return true;
                }
                value = null;
                return false;
            }

            public void Add(object key, object value) => _inner.Add(key, value);
            public void Clear() => _inner.Clear();
            public IDictionaryEnumerator GetEnumerator() => _inner.GetEnumerator();
            public void Remove(object key) => _inner.Remove(key);
            public bool IsFixedSize => _inner.IsFixedSize;
            public bool IsReadOnly => _inner.IsReadOnly;
            public ICollection Keys => _inner.Keys;
            public ICollection Values => _inner.Values;
            IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_inner).GetEnumerator();
            public void CopyTo(Array array, int index) => _inner.CopyTo(array, index);
            public int Count => _inner.Count;
            public bool IsSynchronized => _inner.IsSynchronized;
            public object SyncRoot => _inner.SyncRoot;
        }
    }
}
