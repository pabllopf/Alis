// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FilePickerValidator.cs
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
using System.IO;
using System.Linq;
using Alis.Core.Aspect.Logging;

namespace Alis.Extension.Io.FileDialog
{
    /// <summary>
    ///     Provides validation methods for file picker operations.
    /// </summary>
    public static class FilePickerValidator
    {
        /// <summary>
        ///     Validates file picker options.
        /// </summary>
        /// <param name="options">The options to validate</param>
        /// <exception cref="ArgumentNullException">Thrown when options is null</exception>
        /// <exception cref="ArgumentException">Thrown when options contain invalid values</exception>
        public static void ValidateOptions(FilePickerOptions options)
        {
            Logger.Trace("Validating FilePickerOptions...");

            if (options == null)
            {
                Logger.Warning("FilePickerOptions is null.");
                throw new ArgumentNullException(nameof(options), "Options cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(options.Title))
            {
                Logger.Warning("FilePickerOptions Title is null or empty.");
                throw new ArgumentException("Title cannot be null or empty.", nameof(options.Title));
            }

            if (!string.IsNullOrWhiteSpace(options.DefaultPath) && !Directory.Exists(options.DefaultPath))
            {
                Logger.Warning($"Default path does not exist: {options.DefaultPath}");
                throw new ArgumentException($"Default path does not exist: {options.DefaultPath}", nameof(options.DefaultPath));
            }

            if (options.DialogType == FileDialogType.SaveFile && options.AllowMultiple)
            {
                Logger.Warning("SaveFile dialog cannot allow multiple selections.");
                throw new ArgumentException("SaveFile dialog cannot allow multiple selections.");
            }

            if (options.DialogType != FileDialogType.SelectFolder && options.AllowDirectories)
            {
                Logger.Warning("AllowDirectories can only be true for SelectFolder dialog type.");
                throw new ArgumentException("AllowDirectories can only be true for SelectFolder dialog type.");
            }

            Logger.Trace("FilePickerOptions validation passed.");
        }

        /// <summary>
        ///     Validates that a file path exists.
        /// </summary>
        /// <param name="filePath">The file path to validate</param>
        /// <returns>True if the file exists, false otherwise</returns>
        public static bool IsValidFilePath(string filePath)
        {
            Logger.Trace($"Validating file path: {filePath}");

            if (string.IsNullOrWhiteSpace(filePath))
            {
                Logger.Warning("File path is null or empty.");
                return false;
            }

            try
            {
                bool exists = File.Exists(filePath);
                if (!exists)
                {
                    Logger.Warning($"File does not exist: {filePath}");
                }

                return exists;
            }
            catch (Exception ex)
            {
                Logger.Warning($"Error validating file path {filePath}: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        ///     Validates that a directory path exists.
        /// </summary>
        /// <param name="directoryPath">The directory path to validate</param>
        /// <returns>True if the directory exists, false otherwise</returns>
        public static bool IsValidDirectoryPath(string directoryPath)
        {
            Logger.Trace($"Validating directory path: {directoryPath}");

            if (string.IsNullOrWhiteSpace(directoryPath))
            {
                Logger.Warning("Directory path is null or empty.");
                return false;
            }

            try
            {
                bool exists = Directory.Exists(directoryPath);
                if (!exists)
                {
                    Logger.Warning($"Directory does not exist: {directoryPath}");
                }

                return exists;
            }
            catch (Exception ex)
            {
                Logger.Warning($"Error validating directory path {directoryPath}: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        ///     Validates that a file extension matches the allowed filters.
        /// </summary>
        /// <param name="filePath">The file path to validate</param>
        /// <param name="options">The picker options with allowed filters</param>
        /// <returns>True if the file extension is allowed, false otherwise</returns>
        public static bool IsFileExtensionAllowed(string filePath, FilePickerOptions options)
        {
            Logger.Trace($"Validating file extension for: {filePath}");

            if (options?.Filters == null || options.Filters.Count == 0)
            {
                Logger.Trace("No filters specified, all extensions allowed.");
                return true;
            }

            if (string.IsNullOrWhiteSpace(filePath))
            {
                Logger.Warning("File path is null or empty.");
                return false;
            }

            try
            {
                string extension = Path.GetExtension(filePath)?.TrimStart('.').ToLower();
                if (string.IsNullOrEmpty(extension))
                {
                    Logger.Warning($"Cannot determine extension for: {filePath}");
                    return false;
                }

                bool isAllowed = options.Filters.Any(f => f.Extensions.Any(ext => ext.Equals(extension, StringComparison.OrdinalIgnoreCase)));
                if (!isAllowed)
                {
                    Logger.Warning($"File extension '{extension}' is not allowed for path: {filePath}");
                }

                return isAllowed;
            }
            catch (Exception ex)
            {
                Logger.Warning($"Error validating file extension for {filePath}: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        ///     Validates that the result matches the dialog options.
        /// </summary>
        /// <param name="result">The result to validate</param>
        /// <param name="options">The picker options</param>
        /// <returns>True if the result is valid, false otherwise</returns>
        public static bool IsResultValid(FilePickerResult result, FilePickerOptions options)
        {
            Logger.Trace("Validating FilePickerResult...");

            if (result == null)
            {
                Logger.Warning("Result is null.");
                return false;
            }

            if (!result.IsSuccess)
            {
                Logger.Trace("Result indicates failure.");
                return true;
            }

            if (result.SelectedPaths == null || result.SelectedPaths.Count == 0)
            {
                Logger.Warning("Result has no selected paths.");
                return false;
            }

            if (!options.AllowMultiple && result.SelectedPaths.Count > 1)
            {
                Logger.Warning("Result has multiple paths but AllowMultiple is false.");
                return false;
            }

            if (options.DialogType == FileDialogType.OpenFile)
            {
                foreach (var path in result.SelectedPaths)
                {
                    if (!IsValidFilePath(path))
                    {
                        return false;
                    }

                    if (!IsFileExtensionAllowed(path, options))
                    {
                        return false;
                    }
                }
            }
            else if (options.DialogType == FileDialogType.SelectFolder)
            {
                foreach (var path in result.SelectedPaths)
                {
                    if (!IsValidDirectoryPath(path))
                    {
                        return false;
                    }
                }
            }

            Logger.Trace("FilePickerResult validation passed.");
            return true;
        }
    }
}

