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

namespace Alis.Core.Aspect.Data
{
    /// <summary>
    ///     The example class
    /// </summary>
    public static class AssetManager
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AssetManager" /> class
        /// </summary>
        static AssetManager()
        {
            Console.WriteLine($"AssetPath={AssetPath}");
        }

        /// <summary>
        ///     The application data
        /// </summary>
        private static readonly string AssetPath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location) ?? string.Empty, "Assets");

        /// <summary>
        ///     Finds the asset name
        /// </summary>
        /// <param name="assetName">The asset name</param>
        /// <returns>The string</returns>
        public static string Find(string assetName) => Path.Combine(AssetPath, assetName);
    }
}