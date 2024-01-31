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
using System.IO;
using System.Reflection;

namespace Alis.Core.Aspect.Data.Resource
{
    /// <summary>
    ///     The example class
    /// </summary>
    public static class AssetManager
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AssetManager"/> class
        /// </summary>
        static AssetManager()
        {
            AssetPath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location) ?? string.Empty, "Assets");
        }

        /// <summary>
        ///     The application data
        /// </summary>
        public static string AssetPath { get; }

        /// <summary>
        ///     Finds the asset name in the "assets" folder and its subdirectories.
        /// </summary>
        /// <param name="assetName">The asset name.</param>
        /// <returns>The full path of the asset if found; otherwise, an empty string.</returns>
        public static string Find(string assetName)
        {
            // Check if the asset name is null
            if (assetName == null)
            {
                // Throw an exception
                throw new ArgumentNullException(nameof(assetName));
            }
            
            // Check if the asset name is empty
            if (string.IsNullOrWhiteSpace(assetName))
            {
                // Throw an exception
                throw new ArgumentException("The asset name cannot be empty.", nameof(assetName));
            }
            
            // Check if the asset name contains invalid characters
            if (assetName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
            {
                // Throw an exception
                throw new ArgumentException("The asset name contains invalid characters.", nameof(assetName));
            }
            
            // check if file have extension:
            if (!assetName.Contains("."))
            {
                // Throw an exception
                throw new ArgumentException("The asset name must have extension.", nameof(assetName));
            }
            
            // Get the base directory of the project (where the executable is located)
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Construct the full path of the "assets" folder
            string assetsDirectory = Path.Combine(baseDirectory, "Assets");

            // Search for the file in the "assets" folder and its subdirectories
            string[] files = Directory.GetFiles(assetsDirectory, assetName, SearchOption.AllDirectories);

            // Check if there is more than one file with the same name
            if (files.Length > 1)
            {
                // Throw a custom exception
                throw new InvalidOperationException($"Multiple files with the name '{assetName}' were found. Unable to determine the correct file.");
            }

            // Check if the file was found
            if (files.Length == 1)
            {
                // Return the only found file
                return files[0];
            }

            // You can handle the case where the asset is not found in a specific way
            // For example, throwing an exception, logging a message, etc.
            Console.WriteLine($"The asset '{assetName}' was not found in the 'assets' folder or its subdirectories.");
            return string.Empty;
        }
    }
}