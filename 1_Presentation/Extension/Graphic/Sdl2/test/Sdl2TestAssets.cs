// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Sdl2TestAssets.cs
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

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    ///     Helper to locate repository assets from the test output directory
    /// </summary>
    internal static class Sdl2TestAssets
    {
        /// <summary>
        ///     Locates an asset file by walking up from the assembly directory
        /// </summary>
        /// <param name="name">The asset file name</param>
        /// <returns>The full path or null when not found</returns>
        public static string Find(string name)
        {
            string dir = AppContext.BaseDirectory;
            for (int i = 0; i < 8; i++)
            {
                string candidate = Path.Combine(dir, "Assets", name);
                if (File.Exists(candidate))
                {
                    return candidate;
                }
                dir = Path.GetDirectoryName(dir);
                if (dir == null)
                {
                    break;
                }
            }
            return null;
        }
    }
}
