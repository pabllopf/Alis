

using System;

namespace Alis.Core.Aspect.Memory
{
    /// <summary>
    ///     Represents metadata about a single entry inside a compressed assets.pack archive,
    ///     including its full path, uncompressed size, and last modification timestamp.
    /// </summary>
    internal class ZipEntryInfo
    {
        /// <summary>
        ///     Gets or sets the full internal path of the zip entry as it appears in the archive.
        ///     Defaults to <see cref="string.Empty" /> when no value has been assigned.
        /// </summary>
        /// <value>The full path of the zip entry within the archive.</value>
        internal string FullName { get; set; } = string.Empty;

        /// <summary>
        ///     Gets or sets the uncompressed size, in bytes, of the zip entry content.
        /// </summary>
        /// <value>The uncompressed size of the entry in bytes.</value>
        internal long Length { get; set; }

        /// <summary>
        ///     Gets or sets the coordinated universal time (UTC) of the last write operation
        ///     performed on the zip entry within the archive.
        /// </summary>
        /// <value>The UTC timestamp of the last modification to the zip entry.</value>
        internal DateTimeOffset LastWriteTimeUtc { get; set; }
    }
}
