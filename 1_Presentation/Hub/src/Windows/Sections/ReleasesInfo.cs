// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:d.cs
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
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Data.Json;

namespace Alis.App.Hub.Windows.Sections
{
    /// <summary>
    /// The releases info
    /// </summary>
    [Serializable , StructLayout(LayoutKind.Sequential, Pack = 1)]
    public partial struct  ReleasesInfo (
        List<ReleaseElement> releases
    )
    {
            
        /// <summary>
        /// Initializes a new instance of the <see cref="ReleasesInfo"/> class
        /// </summary>
        public ReleasesInfo() : this(
            new List<ReleaseElement>()
        )
        {
        }
            
        /// <summary>
        /// Gets or sets the value of the releases
        /// </summary>
        [JsonNativePropertyName("_Releases_")]
        public List<ReleaseElement> Releases { get; set; } = releases;
    }
}