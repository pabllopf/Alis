using System.Collections.Generic;

namespace Alis.Core.Aspect.Memory
{
    /// <summary>
    ///     The zip cache entry class
    /// </summary>
    internal class ZipCacheEntry
    {
        // bytes del paquete (no copiados al crear MemoryStream)
        /// <summary>
        ///     Gets or sets the value of the pack bytes
        /// </summary>
        internal byte[] PackBytes { get; set; }

        // índices ligeros para búsquedas rápidas
        /// <summary>
        ///     Gets or sets the value of the entries by full name lower
        /// </summary>
        internal Dictionary<string, ZipEntryInfo> EntriesByFullNameLower { get; } = new();

        /// <summary>
        ///     Gets or sets the value of the entries by file name lower
        /// </summary>
        internal Dictionary<string, List<ZipEntryInfo>> EntriesByFileNameLower { get; } = new();
    }
}