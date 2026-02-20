// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FilePickerFilter.cs
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
using System.Linq;

namespace Alis.Extension.Io.FileDialog
{
    /// <summary>
    ///     Represents a file filter for file dialogs with display name and file extensions.
    /// </summary>
    public class FilePickerFilter
    {
        /// <summary>
        ///     Gets or sets the display name of the filter (e.g., "Text Files").
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        ///     Gets or sets the file extensions without dot (e.g., "txt", "pdf").
        /// </summary>
        public List<string> Extensions { get; set; }

        /// <summary>
        ///     Initializes a new instance of the FilePickerFilter class.
        /// </summary>
        /// <param name="displayName">The display name of the filter</param>
        /// <param name="extensions">The file extensions (without dot)</param>
        /// <exception cref="ArgumentNullException">Thrown when displayName or extensions is null</exception>
        /// <exception cref="ArgumentException">Thrown when displayName is empty or extensions list is empty</exception>
        public FilePickerFilter(string displayName, params string[] extensions)
        {
            if (string.IsNullOrWhiteSpace(displayName))
            {
                throw new ArgumentException("Display name cannot be null or empty.", nameof(displayName));
            }

            if (extensions == null || extensions.Length == 0)
            {
                throw new ArgumentException("At least one extension must be provided.", nameof(extensions));
            }

            DisplayName = displayName;
            Extensions = extensions.Select(ext => ext.TrimStart('.')).ToList();
        }

        /// <summary>
        ///     Gets the extensions formatted for the platform (e.g., "*.txt;*.doc").
        /// </summary>
        /// <returns>The formatted extensions string</returns>
        public string GetFormattedExtensions()
        {
            return string.Join(";", Extensions.Select(ext => $"*.{ext}"));
        }

        /// <summary>
        ///     Gets the extensions formatted for macOS UTI format.
        /// </summary>
        /// <returns>The UTI formatted extensions string</returns>
        public string GetUtiFormat()
        {
            return string.Join(",", Extensions);
        }
    }
}

