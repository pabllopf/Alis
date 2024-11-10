// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ReferenceFace.cs
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

using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Physic.Collision.NarrowPhase
{
    /// <summary>Reference face used for clipping</summary>
    public struct ReferenceFace
    {
        /// <summary>
        ///     The
        /// </summary>
        public int I1 { get; set; }
        
        /// <summary>
        ///     The
        /// </summary>
        public int I2 { get; set; }
        
        /// <summary>
        ///     The
        /// </summary>
        public Vector2 V1 { get; set; }
        
        /// <summary>
        ///     The
        /// </summary>
        public Vector2 V2 { get; set; }
        
        /// <summary>
        ///     The normal
        /// </summary>
        public Vector2 Normal { get; set; }
        
        /// <summary>
        ///     The side normal
        /// </summary>
        public Vector2 SideNormal1 { get; set; }
        
        /// <summary>
        ///     The side offset
        /// </summary>
        public float SideOffset1 { get; set; }
        
        /// <summary>
        ///     The side normal
        /// </summary>
        public Vector2 SideNormal2 { get; set; }
        
        /// <summary>
        ///     The side offset
        /// </summary>
        public float SideOffset2 { get; set; }
    }
}