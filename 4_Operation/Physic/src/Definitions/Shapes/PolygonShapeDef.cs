// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PolygonShapeDef.cs
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

using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Shared;

namespace Alis.Core.Physic.Definitions.Shapes
{
    /// <summary>
    ///     The polygon shape def class
    /// </summary>
    /// <seealso cref="ShapeDef" />
    public sealed class PolygonShapeDef : ShapeDef
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PolygonShapeDef" /> class
        /// </summary>
        public PolygonShapeDef() : base(ShapeType.Polygon)
        {
            SetDefaults();
        }

        /// <summary>
        ///     Gets or sets the value of the vertices
        /// </summary>
        public Vertices Vertices { get; set; }

        /// <summary>
        ///     Sets the defaults
        /// </summary>
        public override void SetDefaults()
        {
            Vertices = null;
            base.SetDefaults();
        }
    }
}