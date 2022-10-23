// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   PolygonSet.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

// Changes from the Java version
//   Replaced getPolygons with attribute
// Future possibilities
//   Replace Add(Polygon) with exposed container?
//   Replace entire class with HashSet<Polygon> ?

using System.Collections.Generic;

namespace Alis.Core.Physic.Tools.Triangulation.Delaunay.Polygon
{
    /// <summary>
    ///     The polygon set class
    /// </summary>
    internal class PolygonSet
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PolygonSet" /> class
        /// </summary>
        public PolygonSet()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PolygonSet" /> class
        /// </summary>
        /// <param name="poly">The poly</param>
        public PolygonSet(Polygon poly)
        {
            PolygonsList.Add(poly);
        }

        /// <summary>
        ///     The polygon
        /// </summary>
        protected List<Polygon> PolygonsList { get; set; } = new List<Polygon>();

        /// <summary>
        ///     Gets the value of the polygons
        /// </summary>
        public IEnumerable<Polygon> Polygons
        {
            get => PolygonsList;
            set => PolygonsList = (List<Polygon>) value;
        }

        /// <summary>
        ///     Adds the p
        /// </summary>
        /// <param name="p">The </param>
        public void Add(Polygon p)
        {
            PolygonsList.Add(p);
        }
    }
}