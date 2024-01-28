// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PolygonError.cs
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

namespace Alis.Core.Physic.Shared
{
    /// <summary>
    ///     The polygon error enum
    /// </summary>
    public enum PolygonError
    {
        /// <summary>There were no errors in the polygon</summary>
        NoError,

        /// <summary>Polygon must have between 3 and Settings.MaxPolygonVertices vertices.</summary>
        InvalidAmountOfVertices,

        /// <summary>Polygon must be simple. This means no overlapping edges.</summary>
        NotSimple,

        /// <summary>Polygon must have a counter clockwise winding.</summary>
        NotCounterClockWise,

        /// <summary>The polygon is concave, it needs to be convex.</summary>
        NotConvex,

        /// <summary>Polygon area is too small.</summary>
        AreaTooSmall,

        /// <summary>The polygon has a side that is too short.</summary>
        SideTooSmall
    }
}