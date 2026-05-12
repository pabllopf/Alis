// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Program.cs
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

namespace Alis.Core.Aspect.Memory.Sample
{
    /// <summary>
    ///     The program class
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     Main the args
        /// </summary>
        /// <param name="args">The args</param>
        public static void Main(string[] args)
        {
            LoadAsset("app.bmp");
        }

        /// <summary>
        ///     Loads the asset from the embedded assets.pack registry.
        /// </summary>
        /// <param name="resourceName">The asset resource path.</param>
        public static void LoadAsset(string resourceName)
        {
            Console.WriteLine($"Loading '{resourceName}' from assets.pack in an AOT-safe way...");

            try
            {
                string resourcePath = AssetRegistry.GetResourcePathByName(resourceName);
                Console.WriteLine($"Resolved extracted path: {resourcePath}");

                using (Stream streamPack = AssetRegistry.GetResourceMemoryStreamByName(resourceName))
                {
                    if (streamPack == null)
                    {
                        throw new InvalidOperationException($"Resource '{resourceName}' was not found.");
                    }

                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        streamPack.CopyTo(memoryStream);
                        byte[] assetData = memoryStream.ToArray();

                        Console.WriteLine($"Loaded '{resourceName}' successfully. Size: {assetData.Length} bytes.");
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Asset registry is not ready: {ex.Message}");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Resource lookup failed: {ex.Message}");
            }
        }
    }
}
