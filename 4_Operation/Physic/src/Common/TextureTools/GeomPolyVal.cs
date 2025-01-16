// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GeomPolyVal.cs
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

namespace Alis.Core.Physic.Common.TextureTools
{
    /// <summary>
    ///     The geom poly val class
    /// </summary>
    internal class GeomPolyVal
    {
        /**
         * Associated polygon at coordinate *
         * Key of original sub-polygon *
         */
        public readonly int Key;

        /// <summary>
        ///     The geom
        /// </summary>
        public MarchingSquares.GeomPoly GeomP;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GeomPolyVal" /> class
        /// </summary>
        /// <param name="geomP">The geom</param>
        /// <param name="k">The </param>
        public GeomPolyVal(MarchingSquares.GeomPoly geomP, int k)
        {
            GeomP = geomP;
            Key = k;
        }
    }
}