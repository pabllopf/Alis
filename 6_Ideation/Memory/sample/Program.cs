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
using System.IO.Compression;
using System.Linq;

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
            LoadAsset();
        }
        
        /// <summary>
        /// Loads the asset
        /// </summary>
        public static void LoadAsset()
        {
            Console.WriteLine("Intentando cargar 'asset.pak' de forma AOT-compatible...");
        
            try
            {
                using (Stream streamPack = AssetRegistry.GetResourceMemoryStreamByName("app.bmp"))
                {
                    if (streamPack == null)
                    {
                        throw new InvalidOperationException("Recurso 'app.bmp' no encontrado en el registro de recursos.");
                    }

                    using (var memoryStream = new MemoryStream())
                    {
                        streamPack.CopyTo(memoryStream);
                        byte[] assetData = memoryStream.ToArray();

                        Console.WriteLine($"✅ Recurso 'app.bmp' cargado correctamente. Tamaño: {assetData.Length} bytes.");
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                // Captura la excepción si el recurso no se encontró.
                Console.WriteLine($"❌ Error AOT al cargar recurso: {ex.Message}");
            }
        }
    }
}