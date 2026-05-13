// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AssetRegistry.cs
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
using System.Buffers;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Alis.Core.Aspect.Memory
{
    /// <summary>
    ///     Provides static methods for registering assembly-level embedded asset packages
    ///     (.pack / .zip) and resolving embedded resource paths or in-memory streams by
    ///     resource name. Maintains thread-safe caches for zip indexes and extracted file
    ///     paths to minimize redundant I/O across assemblies.
    /// </summary>
    public static class AssetRegistry
    {
        /// <summary>
        ///     Stores the registered asset loader delegates keyed by assembly name.
        ///     Each delegate, when invoked, returns a <see cref="Stream" /> providing
        ///     access to the assembly's embedded assets.pack content.
        /// </summary>
        private static readonly Dictionary<string, Func<Stream>> RegisteredAssetLoaders = new();

        /// <summary>
        ///     Per-assembly lock objects used to synchronize zip cache operations
        ///     independently, reducing contention compared to a single global lock.
        /// </summary>
        private static readonly ConcurrentDictionary<string, object> _assemblyLocks = new();

        /// <summary>
        ///     Global lock used when modifying shared structures such as
        ///     <see cref="RegisteredAssetLoaders" /> and the master zip cache.
        /// </summary>
        private static readonly object _globalLock = new();

        /// <summary>
        ///     Caches <see cref="ZipCacheEntry" /> instances keyed by assembly name so that
        ///     each assembly's assets.pack is decompressed and indexed only once.
        /// </summary>
        private static readonly Dictionary<string, ZipCacheEntry> _zipCache = new();

        /// <summary>
        ///     Caches the disk paths of previously extracted resources keyed by a composite
        ///     of the assembly name and the normalized resource key, avoiding re-extraction
        ///     when the cached file on disk is still valid.
        /// </summary>
        private static readonly Dictionary<string, string> _extractedPathCache = new();

        /// <summary>
        ///     Gets or sets the assembly name that is currently considered active.
        ///     All resource resolution calls use this assembly unless otherwise specified.
        /// </summary>
        private static string ActiveAssemblyName { get; set; }

        /// <summary>
        ///     Registers an asset loader function for the specified assembly and sets it as
        ///     the active assembly if no other assembly has been activated yet. Any previously
        ///     cached zip data and extracted paths for this assembly are invalidated.
        /// </summary>
        /// <param name="assemblyName">
        ///     The unique name identifying the assembly whose embedded assets.pack is being
        ///     registered. Must not be null or empty.
        /// </param>
        /// <param name="assetLoader">
        ///     A factory delegate that, when invoked, returns a <see cref="Stream" /> pointing
        ///     to the beginning of the assembly's embedded assets.pack content.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if <paramref name="assemblyName" /> is null or <paramref name="assetLoader" /> is null.
        /// </exception>
        [ExcludeFromCodeCoverage]
        public static void RegisterAssembly(string assemblyName, Func<Stream> assetLoader)
        {
            lock (_globalLock)
            {
                RegisteredAssetLoaders[assemblyName] = assetLoader;
                _zipCache.Remove(assemblyName);
                _extractedPathCache.Keys
                    .Where(k => k.StartsWith(assemblyName.ToLowerInvariant() + "|"))
                    .ToList()
                    .ForEach(k => _extractedPathCache.Remove(k));
                if (ActiveAssemblyName == null)
                {
                    ActiveAssemblyName = assemblyName;
                }
            }
        }

        /// <summary>
        ///     Retrieves or creates a per-assembly synchronization object used to guard
        ///     zip cache and extraction operations for the given assembly.
        /// </summary>
        /// <param name="assemblyName">
        ///     The assembly name for which to obtain the lock object.
        /// </param>
        /// <returns>
        ///     An existing or newly created <see cref="object" /> instance that serves
        ///     as the mutex for assembly-specific cache operations.
        /// </returns>
        private static object GetAssemblyLock(string assemblyName)
        {
            return _assemblyLocks.GetOrAdd(assemblyName, _ => new object());
        }

        /// <summary>
        ///     Opens an embedded resource from the active assembly's assets.pack and returns
        ///     its content as a <see cref="MemoryStream" /> positioned at offset zero.
        ///     The resource is located by its logical name using indexed lookup, then
        ///     decompressed into a newly allocated memory buffer.
        /// </summary>
        /// <param name="resourceName">
        ///     The logical name or relative path of the resource to retrieve. Forward and
        ///     backward slashes are normalized; the comparison is case-insensitive. Must
        ///     not be null, empty, or consist only of white-space characters.
        /// </param>
        /// <returns>
        ///     A <see cref="MemoryStream" /> containing the full, uncompressed content of
        ///     the requested resource, with its position set to zero. The caller owns the
        ///     stream and should dispose of it after use.
        /// </returns>
        /// <exception cref="ArgumentException">
        ///     Thrown when <paramref name="resourceName" /> is null, empty, or consists
        ///     only of white-space characters.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        ///     Thrown when no active assembly has been configured via
        ///     <see cref="RegisterAssembly" />, or when the active assembly has no
        ///     registered assets.pack loader.
        /// </exception>
        /// <exception cref="FileNotFoundException">
        ///     Thrown when the assets.pack cache cannot be found for the active assembly,
        ///     or when the specified <paramref name="resourceName" /> does not exist in the
        ///     archive, or when the zip entry is unexpectedly missing (race condition).
        /// </exception>
        [ExcludeFromCodeCoverage]
        public static MemoryStream GetResourceMemoryStreamByName(string resourceName)
        {
            if (string.IsNullOrWhiteSpace(resourceName))
            {
                throw new ArgumentException("resourceName no puede estar vacío.", nameof(resourceName));
            }

            if (ActiveAssemblyName == null)
            {
                throw new InvalidOperationException("No hay una asamblea activa configurada.");
            }

            if (!RegisteredAssetLoaders.ContainsKey(ActiveAssemblyName))
            {
                throw new InvalidOperationException($"La asamblea activa '{ActiveAssemblyName}' no tiene un assets.pack registrado.");
            }

            ZipEntryInfo entryInfo;
            ZipCacheEntry cacheEntry;

            lock (GetAssemblyLock(ActiveAssemblyName))
            {
                EnsureZipCachedForActiveAssembly();

                if (!_zipCache.TryGetValue(ActiveAssemblyName, out cacheEntry))
                {
                    throw new FileNotFoundException("Cache del assets.pack no disponible.");
                }

                entryInfo = FindZipEntryInfo(cacheEntry, resourceName);
                if (entryInfo == null)
                {
                    throw new FileNotFoundException($"Resource '{resourceName}' not found in `assets.pack`.");
                }
            }

            MemoryStream msResult = entryInfo.Length <= int.MaxValue ? new MemoryStream((int) entryInfo.Length) : new MemoryStream();
            ArrayPool<byte> pool = ArrayPool<byte>.Shared;
            byte[] buffer = pool.Rent(81920);
            try
            {
                using MemoryStream packStream = new MemoryStream(cacheEntry.PackBytes, false);
                using ZipArchive zip = new ZipArchive(packStream, ZipArchiveMode.Read, true);
                ZipArchiveEntry zipEntry = zip.GetEntry(entryInfo.FullName);
                if (zipEntry == null)
                {
                    throw new FileNotFoundException($"Resource '{resourceName}' not found in `assets.pack` (race).");
                }

                using Stream entryStream = zipEntry.Open();
                int read;
                while ((read = entryStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    msResult.Write(buffer, 0, read);
                }

                msResult.Position = 0;
                return msResult;
            }
            finally
            {
                pool.Return(buffer);
            }
        }

        /// <summary>
        ///     Extracts an embedded resource from the active assembly's assets.pack to a
        ///     temporary file on disk and returns its full file-system path. Subsequent
        ///     calls for the same resource may return the cached path without re-extracting,
        ///     provided the cached file still matches the archive entry length and timestamp.
        /// </summary>
        /// <param name="resourceName">
        ///     The logical name or relative path of the resource to extract. Forward and
        ///     backward slashes are normalized; the comparison is case-insensitive. Must
        ///     not be null, empty, or consist only of white-space characters.
        /// </param>
        /// <returns>
        ///     The absolute file-system path to a temporary file containing the extracted
        ///     resource content. The caller is responsible for managing the lifetime of
        ///     this file.
        /// </returns>
        /// <exception cref="ArgumentException">
        ///     Thrown when <paramref name="resourceName" /> is null, empty, or consists
        ///     only of white-space characters.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        ///     Thrown when no active assembly has been configured, or when the active
        ///     assembly has no registered assets.pack loader.
        /// </exception>
        /// <exception cref="FileNotFoundException">
        ///     Thrown when the assets.pack cache cannot be found for the active assembly,
        ///     or when the specified <paramref name="resourceName" /> does not exist in the
        ///     archive, or when the zip entry is unexpectedly missing (race condition).
        /// </exception>
        [ExcludeFromCodeCoverage]
        public static string GetResourcePathByName(string resourceName)
        {
            if (string.IsNullOrWhiteSpace(resourceName))
            {
                throw new ArgumentException("resourceName no puede estar vacío.", nameof(resourceName));
            }

            if (ActiveAssemblyName == null)
            {
                throw new InvalidOperationException("No hay una asamblea activa configurada.");
            }

            if (!RegisteredAssetLoaders.ContainsKey(ActiveAssemblyName))
            {
                throw new InvalidOperationException($"La asamblea activa '{ActiveAssemblyName}' no tiene un assets.pack registrado.");
            }

            string normalizedKey = NormalizeResourceKey(resourceName);
            ZipEntryInfo entryInfo;
            ZipCacheEntry cacheEntry;

            lock (GetAssemblyLock(ActiveAssemblyName))
            {
                EnsureZipCachedForActiveAssembly();

                if (!_zipCache.TryGetValue(ActiveAssemblyName, out cacheEntry))
                {
                    throw new FileNotFoundException("Cache del assets.pack no disponible.");
                }

                string compositeKey = ActiveAssemblyName.ToLowerInvariant() + "|" + normalizedKey;
                if (_extractedPathCache.TryGetValue(compositeKey, out string cachedPath) && File.Exists(cachedPath))
                {
                    ZipEntryInfo entryCandidate = FindZipEntryInfo(cacheEntry, resourceName);
                    if (entryCandidate != null)
                    {
                        FileInfo fi = new FileInfo(cachedPath);
                        if ((fi.Length == entryCandidate.Length) && (File.GetLastWriteTimeUtc(cachedPath) == entryCandidate.LastWriteTimeUtc.UtcDateTime))
                        {
                            return cachedPath;
                        }

                        _extractedPathCache.Remove(compositeKey);
                    }
                    else
                    {
                        _extractedPathCache.Remove(compositeKey);
                    }
                }

                entryInfo = FindZipEntryInfo(cacheEntry, resourceName);
                if (entryInfo == null)
                {
                    throw new FileNotFoundException($"Resource '{resourceName}' not found in `assets.pack`.");
                }
            }

            string safeName = MakeSafeTempName(ActiveAssemblyName, normalizedKey);
            string tempFilePath = Path.Combine(Path.GetTempPath(), safeName);

            if (File.Exists(tempFilePath))
            {
                FileInfo fi = new FileInfo(tempFilePath);
                if ((fi.Length == entryInfo.Length) && (File.GetLastWriteTimeUtc(tempFilePath) == entryInfo.LastWriteTimeUtc.UtcDateTime))
                {
                    string compositeKey = ActiveAssemblyName.ToLowerInvariant() + "|" + NormalizeResourceKey(resourceName);
                    _extractedPathCache[compositeKey] = tempFilePath;
                    return tempFilePath;
                }
            }

            ArrayPool<byte> pool2 = ArrayPool<byte>.Shared;
            byte[] buffer2 = pool2.Rent(81920);
            try
            {
                using MemoryStream packStream = new MemoryStream(cacheEntry.PackBytes, false);
                using ZipArchive zip = new ZipArchive(packStream, ZipArchiveMode.Read, true);
                ZipArchiveEntry zipEntry = zip.GetEntry(entryInfo.FullName);
                if (zipEntry == null)
                {
                    throw new FileNotFoundException($"Resource '{resourceName}' not found in `assets.pack` (race).");
                }

                Directory.CreateDirectory(Path.GetDirectoryName(tempFilePath) ?? Path.GetTempPath());
                using (Stream entryStream = zipEntry.Open())
                using (FileStream outFs = new FileStream(tempFilePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    int read;
                    while ((read = entryStream.Read(buffer2, 0, buffer2.Length)) > 0)
                    {
                        outFs.Write(buffer2, 0, read);
                    }
                }

                try
                {
                    File.SetLastWriteTimeUtc(tempFilePath, entryInfo.LastWriteTimeUtc.UtcDateTime);
                }
                catch
                {
                }

                string compositeKey2 = ActiveAssemblyName.ToLowerInvariant() + "|" + NormalizeResourceKey(resourceName);
                _extractedPathCache[compositeKey2] = tempFilePath;

                return tempFilePath;
            }
            finally
            {
                pool2.Return(buffer2);
            }
        }

        /// <summary>
        ///     Normalizes a resource key by replacing backslashes with forward slashes,
        ///     trimming any leading slash, and converting the result to lower-case for
        ///     case-insensitive comparisons.
        /// </summary>
        /// <param name="resourceName">The raw resource key to normalize.</param>
        /// <returns>
        ///     The normalized, lower-cased resource key with forward slashes and no
        ///     leading slash.
        /// </returns>
        private static string NormalizeResourceKey(string resourceName) => resourceName.Replace('\\', '/').TrimStart('/').ToLowerInvariant();

        /// <summary>
        ///     Generates a safe, unique temporary file name for a given resource by combining
        ///     the assembly name and a SHA-256 hash of the normalized resource key, preserving
        ///     the original file extension when it is short and contains no path separators.
        /// </summary>
        /// <param name="assemblyName">The assembly name to use as a prefix for the file name.</param>
        /// <param name="normalizedResourceKey">
        ///     The normalized resource key whose bytes will be hashed to produce the unique
        ///     portion of the file name.
        /// </param>
        /// <returns>
        ///     A string in the format <c>{assemblyName}_{hash}{extension}</c> suitable for
        ///     use as a temporary file name.
        /// </returns>
        [ExcludeFromCodeCoverage]
        private static string MakeSafeTempName(string assemblyName, string normalizedResourceKey)
        {
            string extension = Path.GetExtension(normalizedResourceKey) ?? string.Empty;
            if (extension.Length > 16 || extension.Contains('/') || extension.Contains('\\'))
            {
                extension = string.Empty;
            }

            byte[] keyBytes = Encoding.UTF8.GetBytes(normalizedResourceKey);
            string hash;
            using (SHA256 sha = SHA256.Create())
            {
                hash = ToLowerHex(sha.ComputeHash(keyBytes));
            }

            return string.IsNullOrEmpty(extension)
                ? $"{assemblyName}_{hash}"
                : $"{assemblyName}_{hash}{extension}";
        }

        /// <summary>
        ///     Converts a byte array into a lower-case hexadecimal string representation.
        ///     Returns <see cref="string.Empty" /> when the input is null or empty.
        /// </summary>
        /// <param name="bytes">
        ///     The byte array to convert. When null or zero-length, an empty string is
        ///     returned.
        /// </param>
        /// <returns>
        ///     A lower-case hexadecimal string where each byte is represented by two
        ///     hex characters, or <see cref="string.Empty" /> if the input is null or
        ///     empty.
        /// </returns>
        [ExcludeFromCodeCoverage]
        private static string ToLowerHex(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0)
            {
                return string.Empty;
            }

            StringBuilder sb = new StringBuilder(bytes.Length * 2);
            for (int i = 0; i < bytes.Length; i++)
            {
                sb.Append(bytes[i].ToString("x2"));
            }

            return sb.ToString();
        }

        /// <summary>
        ///     Ensures that the zip cache for the currently active assembly has been
        ///     populated. If the cache is missing, the registered asset loader is invoked
        ///     to read the full assets.pack bytes into memory; then a temporary
        ///     <see cref="ZipArchive" /> is used to build the lookup indexes
        ///     (<c>EntriesByFullNameLower</c> and <c>EntriesByFileNameLower</c>). The
        ///     resulting <see cref="ZipCacheEntry" /> is stored under the active assembly
        ///     name.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        ///     Thrown when the active assembly has no registered assets.pack loader in
        ///     <see cref="RegisteredAssetLoaders" />.
        /// </exception>
        /// <exception cref="FileNotFoundException">
        ///     Thrown when the stream returned by the registered loader is null, indicating
        ///     that the assets.pack resource file was not found in the embedded resources.
        /// </exception>
        [ExcludeFromCodeCoverage]
        private static void EnsureZipCachedForActiveAssembly()
        {
            if (_zipCache.ContainsKey(ActiveAssemblyName))
            {
                return;
            }

            if (!RegisteredAssetLoaders.TryGetValue(ActiveAssemblyName, out Func<Stream> loader))
            {
                throw new InvalidOperationException($"La asamblea activa '{ActiveAssemblyName}' no tiene un assets.pack registrado.");
            }

            using Stream srcStream = loader.Invoke();
            if (srcStream == null)
            {
                throw new FileNotFoundException("Resource file `assets.pack` not found in embedded resources.");
            }

            using MemoryStream mem = new MemoryStream();
            srcStream.CopyTo(mem);
            byte[] bytes = mem.ToArray();

            using MemoryStream indexStream = new MemoryStream(bytes, false);
            using ZipArchive zip = new ZipArchive(indexStream, ZipArchiveMode.Read, true);
            ZipCacheEntry cacheEntry = new ZipCacheEntry {PackBytes = bytes};

            foreach (ZipArchiveEntry e in zip.Entries)
            {
                string fullLower = e.FullName.Replace('\\', '/').ToLowerInvariant();
                ZipEntryInfo info = new ZipEntryInfo
                {
                    FullName = e.FullName,
                    Length = e.Length,
                    LastWriteTimeUtc = e.LastWriteTime
                };
                cacheEntry.EntriesByFullNameLower[fullLower] = info;

                string fileNameLower = Path.GetFileName(e.FullName).ToLowerInvariant();
                if (!cacheEntry.EntriesByFileNameLower.TryGetValue(fileNameLower, out List<ZipEntryInfo> list))
                {
                    list = new List<ZipEntryInfo>();
                    cacheEntry.EntriesByFileNameLower[fileNameLower] = list;
                }

                list.Add(info);
            }

            lock (_globalLock)
            {
                _zipCache[ActiveAssemblyName] = cacheEntry;
            }
        }

        /// <summary>
        ///     Locates a <see cref="ZipEntryInfo" /> within a cached
        ///     <see cref="ZipCacheEntry" /> by the given resource name using a fallback
        ///     strategy: exact full-path match first, then exact file-name match (when
        ///     unambiguous), and finally a partial substring search on the full path.
        /// </summary>
        /// <param name="cacheEntry">
        ///     The <see cref="ZipCacheEntry" /> containing the pre-built lookup
        ///     dictionaries to search through.
        /// </param>
        /// <param name="resourceName">
        ///     The resource name to locate. Names are normalized internally for
        ///     case-insensitive and separator-agnostic comparison.
        /// </param>
        /// <returns>
        ///     The matching <see cref="ZipEntryInfo" /> if found; otherwise,
        ///     <c>null</c>.
        /// </returns>
        [ExcludeFromCodeCoverage]
        private static ZipEntryInfo FindZipEntryInfo(ZipCacheEntry cacheEntry, string resourceName)
        {
            string normalized = NormalizeResourceKey(resourceName);

            if (cacheEntry.EntriesByFullNameLower.TryGetValue(normalized, out ZipEntryInfo exact))
            {
                return exact;
            }

            string fileNameLower = Path.GetFileName(resourceName).ToLowerInvariant();
            if (cacheEntry.EntriesByFileNameLower.TryGetValue(fileNameLower, out List<ZipEntryInfo> list) && (list.Count == 1))
            {
                return list[0];
            }

            ZipEntryInfo match = cacheEntry.EntriesByFullNameLower
                .Values
                .FirstOrDefault(e => e.FullName.Replace('\\', '/').EndsWith(resourceName, StringComparison.OrdinalIgnoreCase) ||
                                     e.FullName.Replace('\\', '/').EndsWith("/" + resourceName, StringComparison.OrdinalIgnoreCase) ||
                                     e.FullName.Replace('\\', '/').IndexOf(resourceName, StringComparison.OrdinalIgnoreCase) >= 0);

            return match;
        }
    }
}
