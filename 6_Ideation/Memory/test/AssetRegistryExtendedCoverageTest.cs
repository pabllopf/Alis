// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AssetRegistryExtendedCoverageTest.cs
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
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Alis.Core.Aspect.Memory.Test
{
    /// <summary>
    ///     Extended coverage tests for AssetRegistry targeting uncovered paths including
    ///     the cache-miss-after-ensure race condition in GetResourceMemoryStreamByName
    ///     and GetResourcePathByName.
    /// </summary>
    [Collection("AssetRegistryCollection")]
    public class AssetRegistryExtendedCoverageTest : IDisposable
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
        /// Initializes a new instance of the <see cref="AssetRegistryExtendedCoverageTest"/> class
        /// </summary>
        public AssetRegistryExtendedCoverageTest()
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
        ///     Tests that GetResourceMemoryStreamByName throws FileNotFoundException when
        ///     the zip cache entry is removed after EnsureZipCachedForActiveAssembly
        ///     populates it (race condition).
        /// </summary>
        [Fact]
        public void GetResourceMemoryStreamByName_CacheMissAfterEnsure_ThrowsFileNotFoundException()
        {
            string assemblyName = "CacheMissMemStream_" + Guid.NewGuid();
            byte[] zipBytes = CreateTestZipBytes(new Dictionary<string, string> {{"file.txt", "content"}});
            SetupAssembly(assemblyName, zipBytes);

            using CancellationTokenSource cts = new CancellationTokenSource();
            bool hit = false;

            Task bgTask = Task.Run(() =>
            {
                while (!cts.IsCancellationRequested)
                {
                    GetZipCache().Remove(assemblyName);
                    Thread.SpinWait(10);
                }
            });

            Stopwatch sw = Stopwatch.StartNew();
            while (!hit && sw.Elapsed < TimeSpan.FromSeconds(5))
            {
                try
                {
                    using MemoryStream result = AssetRegistry.GetResourceMemoryStreamByName("file.txt");
                }
                catch (FileNotFoundException ex) when (ex.Message.Contains("Cache del assets.pack no disponible"))
                {
                    hit = true;
                }
                catch
                {
                }
            }

            cts.Cancel();

            try
            {
                bgTask.Wait(TimeSpan.FromSeconds(1));
            }
            catch
            {
            }

            Assert.True(hit, "Cache miss race condition was triggered for GetResourceMemoryStreamByName");
        }

        /// <summary>
        ///     Tests that GetResourcePathByName throws FileNotFoundException when
        ///     the zip cache entry is removed after EnsureZipCachedForActiveAssembly
        ///     populates it (race condition). This is a more robust version of the
        ///     previously-skipped test.
        /// </summary>
        [Fact]
        public void GetResourcePathByName_CacheMissAfterEnsure_ThrowsFileNotFoundException()
        {
            string assemblyName = "CacheMissPath_" + Guid.NewGuid();
            byte[] zipBytes = CreateTestZipBytes(new Dictionary<string, string> {{"file.txt", "content"}});
            SetupAssembly(assemblyName, zipBytes);

            using CancellationTokenSource cts = new CancellationTokenSource();
            bool hit = false;

            Task bgTask = Task.Run(() =>
            {
                while (!cts.IsCancellationRequested)
                {
                    GetZipCache().Remove(assemblyName);
                    Thread.SpinWait(10);
                }
            });

            Stopwatch sw = Stopwatch.StartNew();
            while (!hit && sw.Elapsed < TimeSpan.FromSeconds(5))
            {
                try
                {
                    AssetRegistry.GetResourcePathByName("file.txt");
                }
                catch (FileNotFoundException ex) when (ex.Message.Contains("Cache del assets.pack no disponible"))
                {
                    hit = true;
                }
                catch
                {
                }
            }

            cts.Cancel();

            try
            {
                bgTask.Wait(TimeSpan.FromSeconds(1));
            }
            catch
            {
            }

            Assert.True(hit, "Cache miss race condition was triggered for GetResourcePathByName");
        }
    }
}
