// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AssetManager.cs
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
using System.IO;

namespace Alis.Core.Aspect.Data.Resource
{
    /// <summary>
    ///     The example class
    /// </summary>
    public static class AssetManager
    {
        /// <summary>
        ///     Finds the asset name in the "assets" folder and its subdirectories.
        /// </summary>
        /// <param name="assetName">The asset name.</param>
        /// <returns>The full path of the asset if found; otherwise, an empty string.</returns>
        public static string Find(string assetName)
        {
            ValidateAssetName(assetName);
            string[] assetsDirectory = GetAssetsDirectory();
            string[] files = GetFilesInAssetsDirectory(assetsDirectory, assetName);
            return GetFilePath(files);
        }

        /// <summary>
        ///     Validates the asset name using the specified asset name
        /// </summary>
        /// <param name="assetName">The asset name</param>
        internal static void ValidateAssetName(string assetName)
        {
            ValidateAssetNameIsNotNull(assetName);
            ValidateAssetNameIsNotEmpty(assetName);
            ValidateAssetNameHasNoInvalidChars(assetName);
            ValidateAssetNameHasExtension(assetName);
        }

        /// <summary>
        ///     Validates the asset name is not null using the specified asset name
        /// </summary>
        /// <param name="assetName">The asset name</param>
        /// <exception cref="ArgumentNullException"></exception>
        private static void ValidateAssetNameIsNotNull(string assetName)
        {
            if (assetName == null)
            {
                throw new ArgumentNullException(nameof(assetName));
            }
        }

        /// <summary>
        ///     Validates the asset name is not empty using the specified asset name
        /// </summary>
        /// <param name="assetName">The asset name</param>
        /// <exception cref="ArgumentException">The asset name cannot be empty. </exception>
        private static void ValidateAssetNameIsNotEmpty(string assetName)
        {
            if (string.IsNullOrWhiteSpace(assetName))
            {
                throw new ArgumentException("The asset name cannot be empty.", nameof(assetName));
            }
        }

        /// <summary>
        ///     Validates the asset name has no invalid chars using the specified asset name
        /// </summary>
        /// <param name="assetName">The asset name</param>
        /// <exception cref="ArgumentException">The asset name contains invalid characters. </exception>
        internal static void ValidateAssetNameHasNoInvalidChars(string assetName)
        {
            if (IsInvalidAssetName(assetName))
            {
                throw new ArgumentException("The asset name contains invalid characters.", nameof(assetName));
            }
        }

        /// <summary>
        ///     Checks if the asset name has any invalid characters
        /// </summary>
        /// <param name="assetName">The asset name</param>
        /// <returns>True if the asset name is invalid, false otherwise</returns>
        internal static bool IsInvalidAssetName(string assetName) => assetName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0;

        /// <summary>
        ///     Validates the asset name has extension using the specified asset name
        /// </summary>
        /// <param name="assetName">The asset name</param>
        /// <exception cref="ArgumentException">The asset name must have extension. </exception>
        internal static void ValidateAssetNameHasExtension(string assetName)
        {
            if (!assetName.Contains("."))
            {
                throw new ArgumentException("The asset name must have extension.", nameof(assetName));
            }
        }

        /// <summary>
        ///     Gets the assets directory
        /// </summary>
        /// <returns>The string</returns>
        internal static string[] GetAssetsDirectory()
        {
            string[] baseDirectories =
            {
                Environment.CurrentDirectory,
                //Path.GetDirectoryName(typeof(AssetManager).Assembly.Location),
                AppDomain.CurrentDomain.BaseDirectory
            };

            for (int i = 0; i < baseDirectories.Length; i++)
            {
                if (baseDirectories[i] != null) // Ensure the directory value is not null.
                {
                    baseDirectories[i] = baseDirectories[i].TrimEnd('/', '\\');
                    baseDirectories[i] = Path.Combine(baseDirectories[i], "Assets");
                }
            }


            return baseDirectories;
        }

        /// <summary>
        ///     Gets the files in assets directory using the specified assets directory
        /// </summary>
        /// <param name="assetsDirectory">The assets directory</param>
        /// <param name="assetName">The asset name</param>
        /// <returns>The string array</returns>
        internal static string[] GetFilesInAssetsDirectory(string[] assetsDirectory, string assetName)
        {
            List<string> files = new List<string>();
            foreach (string directory in assetsDirectory)
            {
                if (Directory.Exists(directory))
                {
                    string[] filesInDirectory = Directory.GetFiles(directory, assetName, SearchOption.AllDirectories);
                    foreach (string file in filesInDirectory)
                    {
                        if (!files.Contains(file))
                        {
                            files.Add(file);
                        }
                    }
                }
            }

            return files.ToArray();
        }
        
        /// <summary>
        ///     Gets the file path using the specified files
        /// </summary>
        /// <param name="files">The files</param>
        /// <returns>The string</returns>
        private static string GetFilePath(string[] files) => files.Length >= 1 ? files[0] : string.Empty;
    }
}