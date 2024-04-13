// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Profile.cs
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

namespace Alis.Extension.Encode.FFMeg.Encoding.Builders
{
    /// <summary>
    ///     The profile enum
    /// </summary>
    public enum Profile
    {
        /// <summary>
        ///     Automatically pick the appropriate profile
        /// </summary>
        Auto,
        
        /// <summary>
        ///     Maximum compatibility on older devices. Least demanding.
        /// </summary>
        Baseline,
        
        /// <summary>
        ///     Good compatibility even on older devices
        /// </summary>
        Main,
        
        /// <summary>
        ///     Supported by most modern devices
        /// </summary>
        High,
        
        /// <summary>
        ///     Support for 10-bit depth
        /// </summary>
        High10,
        
        /// <summary>
        ///     Support for 4:2:2 chroma subsampling
        /// </summary>
        High442,
        
        /// <summary>
        ///     Support for 4:4:4 chroma subsampling
        /// </summary>
        High444
    }
}