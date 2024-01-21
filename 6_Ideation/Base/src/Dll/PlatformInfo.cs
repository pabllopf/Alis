// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: PlatformInfo.cs
// 
//  Author: Pablo Perdomo Falcón
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

using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Util;

namespace Alis.Core.Aspect.Base.Dll
{
    /// <summary>
    /// The platform info class
    /// </summary>
    public class PlatformInfo
    {
        /// <summary>
        /// Gets the value of the platform
        /// </summary>
        public OSPlatform Platform { get; }
        
        /// <summary>
        /// Gets the value of the arch
        /// </summary>
        public Architecture Arch { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlatformInfo"/> class
        /// </summary>
        /// <param name="platform">The platform</param>
        /// <param name="arch">The arch</param>
        public PlatformInfo(OSPlatform platform, Architecture arch)
        {
            Platform = platform;
            Arch = arch;
        }
        
        public override bool Equals(object obj)
        {
            if (obj is PlatformInfo other)
            {
                return Platform == other.Platform && Arch == other.Arch;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Platform, Arch);
        }
    }
}