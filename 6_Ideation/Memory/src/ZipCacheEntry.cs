

using System.Collections.Generic;

namespace Alis.Core.Aspect.Memory
{
    /// <summary>
    ///     Caches the raw byte content of an extracted assets.pack archive together with
    ///     pre-built lookup dictionaries that map entry paths and file names to their
    ///     corresponding <see cref="ZipEntryInfo" /> metadata, enabling fast repeated access.
    /// </summary>
    internal class ZipCacheEntry
    {
        /// <summary>
        ///     Gets or sets the complete raw byte content of the assets.pack archive.
        ///     These bytes are shared across all extractions without additional copying.
        /// </summary>
        /// <value>The raw byte array containing the full compressed archive content.</value>
        internal byte[] PackBytes { get; set; }

        /// <summary>
        ///     Gets a dictionary that maps lower-cased full entry paths (using forward slashes)
        ///     to their <see cref="ZipEntryInfo" /> metadata for O(1) exact-path lookups.
        /// </summary>
        /// <value>A dictionary keyed by lower-cased full entry paths with forward-slash separators.</value>
        internal Dictionary<string, ZipEntryInfo> EntriesByFullNameLower { get; } = new();

        /// <summary>
        ///     Gets a dictionary that maps lower-cased file names to a list of
        ///     <see cref="ZipEntryInfo" /> metadata entries, supporting lookups when
        ///     multiple entries share the same file name in different directories.
        /// </summary>
        /// <value>A dictionary keyed by lower-cased file names, each mapping to a list of matching entries.</value>
        internal Dictionary<string, List<ZipEntryInfo>> EntriesByFileNameLower { get; } = new();
    }
}
