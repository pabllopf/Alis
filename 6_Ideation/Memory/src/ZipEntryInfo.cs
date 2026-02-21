using System;

namespace Alis.Core.Aspect.Memory
{
    /// <summary>
    ///     The zip entry info class
    /// </summary>
    internal class ZipEntryInfo
    {
        /// <summary>
        ///     Gets or sets the value of the full name
        /// </summary>
        internal string FullName { get; set; } = string.Empty;

        /// <summary>
        ///     Gets or sets the value of the length
        /// </summary>
        internal long Length { get; set; }

        /// <summary>
        ///     Gets or sets the value of the last write time utc
        /// </summary>
        internal DateTimeOffset LastWriteTimeUtc { get; set; }
    }
}