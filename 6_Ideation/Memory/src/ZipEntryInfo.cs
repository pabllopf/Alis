// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ZipEntryInfo.cs
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
        internal string FullName { get; set; } = string.Empty;

        /// <summary>
        ///     Gets or sets the uncompressed size, in bytes, of the zip entry content.
        /// </summary>
        internal long Length { get; set; }

        /// <summary>
        ///     Gets or sets the coordinated universal time (UTC) of the last write operation
        ///     performed on the zip entry within the archive.
        /// </summary>
        internal DateTimeOffset LastWriteTimeUtc { get; set; }
    }
}
