// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ZipCacheEntry.cs
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

       
#if !NETSTANDARD2_0 && !NET461
         /// <summary>
        ///     Gets a read-only span over the raw byte content of the assets.pack archive,
        ///     providing allocation-free access to the underlying packed data.
        ///     Available on .NET Core 2.1+ / .NET 5+ / .NET Standard 2.1+ targets where
        ///     <see cref="ReadOnlySpan{T}" /> is natively or via <c>System.Memory</c> fully
        ///     supported; omitted on legacy .NET Framework and .NET Standard 2.0 where
        ///     <see cref="ReadOnlySpan{T}" /> usage is constrained.
        /// </summary>
        internal ReadOnlySpan<byte> PackBytesReadOnly => PackBytes;
#endif

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
