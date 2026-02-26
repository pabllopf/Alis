// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FilePickerPathConverter.cs
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
    ///     Provides path conversion and normalization methods for cross-platform file dialogs.
    /// </summary>
    public static class FilePickerPathConverter
    {
        /// <summary>
        ///     Normalizes a file path by removing trailing whitespace and newlines.
        /// </summary>
        /// <param name="path">The path to normalize</param>
        /// <returns>The normalized path, or null if the input is null or empty</returns>
        public static string NormalizePath(string path)
        {
            Logger.Trace($"Normalizing path: {path}");

            if (string.IsNullOrWhiteSpace(path))
            {
                Logger.Trace("Path is null or whitespace, returning null.");
                return null;
            }

            try
            {
                string normalized = path.Trim();
                Logger.Trace($"Path normalized to: {normalized}");
                return normalized;
            }
            catch (Exception ex)
            {
                Logger.Warning($"Error normalizing path: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        ///     Splits multiple paths separated by newlines (common in Linux/macOS dialog output).
        /// </summary>
        /// <param name="pathsString">The concatenated paths string</param>
        /// <returns>An array of individual paths</returns>
        public static string[] SplitMultiplePaths(string pathsString)
        {
            Logger.Trace("Splitting multiple paths from dialog output.");

            if (string.IsNullOrWhiteSpace(pathsString))
            {
                Logger.Warning("Paths string is null or empty.");
                return Array.Empty<string>();
            }

            try
            {
                string[] paths = pathsString
                    .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(p => NormalizePath(p))
                    .Where(p => !string.IsNullOrEmpty(p))
                    .ToArray();

                Logger.Trace($"Split {paths.Length} path(s) from dialog output.");
                return paths;
            }
            catch (Exception ex)
            {
                Logger.Warning($"Error splitting multiple paths: {ex.Message}");
                return Array.Empty<string>();
            }
        }

        /// <summary>
        ///     Converts Windows-style path separators to platform-specific separators.
        /// </summary>
        /// <param name="path">The path to convert</param>
        /// <returns>The converted path</returns>
        public static string ConvertPathSeparators(string path)
        {
            Logger.Trace($"Converting path separators for: {path}");

            if (string.IsNullOrWhiteSpace(path))
            {
                return path;
            }

            try
            {
                string converted = path.Replace('\\', Path.DirectorySeparatorChar).Replace('/', Path.DirectorySeparatorChar);
                Logger.Trace($"Path separators converted to: {converted}");
                return converted;
            }
            catch (Exception ex)
            {
                Logger.Warning($"Error converting path separators: {ex.Message}");
                return path;
            }
        }

        /// <summary>
        ///     Gets the directory name from a file path.
        /// </summary>
        /// <param name="filePath">The file path</param>
        /// <returns>The directory name, or null if the path is invalid</returns>
        public static string GetDirectoryName(string filePath)
        {
            Logger.Trace($"Getting directory name from path: {filePath}");

            if (string.IsNullOrWhiteSpace(filePath))
            {
                Logger.Warning("File path is null or empty.");
                return null;
            }

            try
            {
                string directory = Path.GetDirectoryName(filePath);
                Logger.Trace($"Directory name: {directory}");
                return directory;
            }
            catch (Exception ex)
            {
                Logger.Warning($"Error getting directory name: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        ///     Gets the file name from a file path.
        /// </summary>
        /// <param name="filePath">The file path</param>
        /// <returns>The file name, or null if the path is invalid</returns>
        public static string GetFileName(string filePath)
        {
            Logger.Trace($"Getting file name from path: {filePath}");

            if (string.IsNullOrWhiteSpace(filePath))
            {
                Logger.Warning("File path is null or empty.");
                return null;
            }

            try
            {
                string fileName = Path.GetFileName(filePath);
                Logger.Trace($"File name: {fileName}");
                return fileName;
            }
            catch (Exception ex)
            {
                Logger.Warning($"Error getting file name: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        ///     Verifies that a path is valid and accessible.
        /// </summary>
        /// <param name="path">The path to verify</param>
        /// <param name="mustExist">Whether the path must exist</param>
        /// <returns>True if the path is valid, false otherwise</returns>
        public static bool IsValidPath(string path, bool mustExist = true)
        {
            Logger.Trace($"Validating path: {path} (mustExist: {mustExist})");

            if (string.IsNullOrWhiteSpace(path))
            {
                Logger.Warning("Path is null or empty.");
                return false;
            }

            try
            {
                if (mustExist)
                {
                    return File.Exists(path) || Directory.Exists(path);
                }

                // Check if the path contains invalid characters
                char[] invalidChars = Path.GetInvalidPathChars();
                bool hasInvalidChars = path.Any(c => invalidChars.Contains(c));

                if (hasInvalidChars)
                {
                    Logger.Warning($"Path contains invalid characters: {path}");
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Logger.Warning($"Error validating path: {ex.Message}");
                return false;
            }
        }
    }
}

