using System;
using System.Buffers;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace Alis.Core.Aspect.Memory
{
    /// <summary>
    /// The asset registry class
    /// </summary>
    public static class AssetRegistry
    {
        private static readonly Dictionary<string, Func<Stream>> RegisteredAssetLoaders = new();
        // Lock por ensamblado para reducir contención
        private static readonly ConcurrentDictionary<string, object> _assemblyLocks = new();
        private static readonly object _globalLock = new();

        // Cache del ZIP cargado en memoria por assembly
        private class ZipEntryInfo
        {
            public string FullName { get; set; } = string.Empty;
            public long Length { get; set; }
            public DateTimeOffset LastWriteTimeUtc { get; set; }
        }

        private class ZipCacheEntry
        {
            // bytes del paquete (no copiados al crear MemoryStream)
            public byte[] PackBytes { get; set; }
            // índices ligeros para búsquedas rápidas
            public Dictionary<string, ZipEntryInfo> EntriesByFullNameLower { get; set; } = new();
            public Dictionary<string, List<ZipEntryInfo>> EntriesByFileNameLower { get; set; } = new();
        }

        private static readonly Dictionary<string, ZipCacheEntry> _zipCache = new();
        // Cache de rutas extraídas: key -> ruta en disco
        private static readonly Dictionary<string, string> _extractedPathCache = new();

        private static string ActiveAssemblyName { get; set; } = null;

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

        private static object GetAssemblyLock(string assemblyName)
        {
            return _assemblyLocks.GetOrAdd(assemblyName, _ => new object());
        }

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

            string normalizedKey = NormalizeResourceKey(resourceName);
            ZipEntryInfo entryInfo;
            ZipCacheEntry cacheEntry;

            object asmLock = GetAssemblyLock(ActiveAssemblyName);
            lock (asmLock)
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
                // liberamos el lock antes de leer los bytes
            }

            // Crear un ZipArchive local sobre los bytes cacheados para extraer la entrada
            MemoryStream msResult = entryInfo.Length <= int.MaxValue ? new MemoryStream((int)entryInfo.Length) : new MemoryStream();
            ArrayPool<byte> pool = ArrayPool<byte>.Shared;
            byte[] buffer = pool.Rent(81920);
            try
            {
                using MemoryStream packStream = new MemoryStream(cacheEntry.PackBytes, writable: false);
                using ZipArchive zip = new ZipArchive(packStream, ZipArchiveMode.Read, leaveOpen: true);
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

            object asmLock = GetAssemblyLock(ActiveAssemblyName);
            lock (asmLock)
            {
                EnsureZipCachedForActiveAssembly();

                if (!_zipCache.TryGetValue(ActiveAssemblyName, out cacheEntry))
                {
                    throw new FileNotFoundException("Cache del assets.pack no disponible.");
                }

                // Intentar devolver ruta cacheada si existe y está al día
                string compositeKey = ActiveAssemblyName.ToLowerInvariant() + "|" + normalizedKey;
                if (_extractedPathCache.TryGetValue(compositeKey, out string cachedPath) && File.Exists(cachedPath))
                {
                    ZipEntryInfo entryCandidate = FindZipEntryInfo(cacheEntry, resourceName);
                    if (entryCandidate != null)
                    {
                        FileInfo fi = new FileInfo(cachedPath);
                        if (fi.Length == entryCandidate.Length && File.GetLastWriteTimeUtc(cachedPath) == entryCandidate.LastWriteTimeUtc.UtcDateTime)
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
            } // liberado el lock para la extracción en disco

            // Extraer a disco usando PackBytes sin copiar todo el ZIP
            string safeName = MakeSafeTempName(ActiveAssemblyName, entryInfo.FullName);
            string tempFilePath = Path.Combine(Path.GetTempPath(), safeName);

            // Si ya existe en disco y coincide con el ZIP, devolverlo
            if (File.Exists(tempFilePath))
            {
                FileInfo fi = new FileInfo(tempFilePath);
                if (fi.Length == entryInfo.Length && File.GetLastWriteTimeUtc(tempFilePath) == entryInfo.LastWriteTimeUtc.UtcDateTime)
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
                using MemoryStream packStream = new MemoryStream(cacheEntry.PackBytes, writable: false);
                using ZipArchive zip = new ZipArchive(packStream, ZipArchiveMode.Read, leaveOpen: true);
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

                try { File.SetLastWriteTimeUtc(tempFilePath, entryInfo.LastWriteTimeUtc.UtcDateTime); } catch { }

                string compositeKey2 = ActiveAssemblyName.ToLowerInvariant() + "|" + NormalizeResourceKey(resourceName);
                _extractedPathCache[compositeKey2] = tempFilePath;

                return tempFilePath;
            }
            finally
            {
                pool2.Return(buffer2);
            }
        }

        private static string NormalizeResourceKey(string resourceName)
        {
            return resourceName.Replace('\\', '/').TrimStart('/').ToLowerInvariant();
        }

        private static string MakeSafeTempName(string assemblyName, string entryFullName)
        {
            string fileName = entryFullName.Replace('\\', '_').Replace('/', '_');
            if (fileName.Length > 200)
            {
                fileName = fileName.Substring(fileName.Length - 200);
            }

            return $"{assemblyName}_{fileName}";
        }

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

            // Leer completamente en bytes (una única vez)
            using MemoryStream mem = new MemoryStream();
            srcStream.CopyTo(mem);
            byte[] bytes = mem.ToArray();

            // Indexar mediante un ZipArchive temporal
            using MemoryStream indexStream = new MemoryStream(bytes, writable: false);
            using ZipArchive zip = new ZipArchive(indexStream, ZipArchiveMode.Read, leaveOpen: true);
            ZipCacheEntry cacheEntry = new ZipCacheEntry { PackBytes = bytes };

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

        private static ZipEntryInfo FindZipEntryInfo(ZipCacheEntry cacheEntry, string resourceName)
        {
            string normalized = NormalizeResourceKey(resourceName);

            // 1) Buscar por FullName exacto
            if (cacheEntry.EntriesByFullNameLower.TryGetValue(normalized, out ZipEntryInfo exact))
            {
                return exact;
            }

            // 2) Buscar por file name exacto
            string fileNameLower = Path.GetFileName(resourceName).ToLowerInvariant();
            if (cacheEntry.EntriesByFileNameLower.TryGetValue(fileNameLower, out List<ZipEntryInfo> list) && list.Count == 1)
            {
                return list[0];
            }

            // 3) Buscar por FullName que termine con resourceName (buscando en claves del índice, no en ZipArchive)
            ZipEntryInfo match = cacheEntry.EntriesByFullNameLower
                .Values
                .FirstOrDefault(e => e.FullName.Replace('\\', '/').EndsWith(resourceName, StringComparison.OrdinalIgnoreCase) ||
                                     e.FullName.Replace('\\', '/').EndsWith("/" + resourceName, StringComparison.OrdinalIgnoreCase) ||
                                     e.FullName.Replace('\\', '/').IndexOf(resourceName, StringComparison.OrdinalIgnoreCase) >= 0);

            return match;
        }
    }
}