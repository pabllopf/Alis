// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImNodesStyle.cs
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

using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.Ui.Extras.Node
{
    /// <summary>
    ///     The im nodes style
    /// </summary>
    public struct ImNodesStyle
    {
        /// <summary>
        ///     The grid spacing
        /// </summary>
        public float GridSpacing { get; set; }

        /// <summary>
        ///     The node corner rounding
        /// </summary>
        public float NodeCornerRounding { get; set; }

        /// <summary>
        ///     The node padding
        /// </summary>
        public Vector2F NodePadding { get; set; }

        /// <summary>
        ///     The node border thickness
        /// </summary>
        public float NodeBorderThickness { get; set; }

        /// <summary>
        ///     The link thickness
        /// </summary>
        public float LinkThickness { get; set; }

        /// <summary>
        ///     The link line segments per length
        /// </summary>
        public float LinkLineSegmentsPerLength { get; set; }

        /// <summary>
        ///     The link hover distance
        /// </summary>
        public float LinkHoverDistance { get; set; }

        /// <summary>
        ///     The pin circle radius
        /// </summary>
        public float PinCircleRadius { get; set; }

        /// <summary>
        ///     The pin quad side length
        /// </summary>
        public float PinQuadSideLength { get; set; }

        /// <summary>
        ///     The pin triangle side length
        /// </summary>
        public float PinTriangleSideLength { get; set; }

        /// <summary>
        ///     The pin line thickness
        /// </summary>
        public float PinLineThickness { get; set; }

        /// <summary>
        ///     The pin hover radius
        /// </summary>
        public float PinHoverRadius { get; set; }

        /// <summary>
        ///     The pin offset
        /// </summary>
        public float PinOffset { get; set; }

        /// <summary>
        ///     The mini map padding
        /// </summary>
        public Vector2F MiniMapPadding { get; set; }

        /// <summary>
        ///     The mini map offset
        /// </summary>
        public Vector2F MiniMapOffset { get; set; }

        /// <summary>
        ///     The flags
        /// </summary>
        public ImNodesStyleFlags Flags { get; set; }

        /// <summary>
        ///     The colors
        /// </summary>
        public uint[] Colors;
    }
}