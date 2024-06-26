// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContactType.cs
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

namespace Alis.Core.Physic.Collision.ContactSystem
{
    /// <summary>
    ///     The contact type enum
    /// </summary>
    public enum ContactType : byte
    {
        /// <summary>
        ///     The not supported contact type
        /// </summary>
        NotSupported,
        
        /// <summary>
        ///     The polygon contact type
        /// </summary>
        Polygon,
        
        /// <summary>
        ///     The polygon and circle contact type
        /// </summary>
        PolygonAndCircle,
        
        /// <summary>
        ///     The circle contact type
        /// </summary>
        Circle,
        
        /// <summary>
        ///     The edge and polygon contact type
        /// </summary>
        EdgeAndPolygon,
        
        /// <summary>
        ///     The edge and circle contact type
        /// </summary>
        EdgeAndCircle,
        
        /// <summary>
        ///     The chain and polygon contact type
        /// </summary>
        ChainAndPolygon,
        
        /// <summary>
        ///     The chain and circle contact type
        /// </summary>
        ChainAndCircle
    }
}