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

using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.ImGui.Extras.Node
{
    /// <summary>
    ///     The im nodes style
    /// </summary>
    public unsafe struct ImNodesStyle
    {
        /// <summary>
        ///     The grid spacing
        /// </summary>
        public float GridSpacing;

        /// <summary>
        ///     The node corner rounding
        /// </summary>
        public float NodeCornerRounding;

        /// <summary>
        ///     The node padding
        /// </summary>
        public Vector2 NodePadding;

        /// <summary>
        ///     The node border thickness
        /// </summary>
        public float NodeBorderThickness;

        /// <summary>
        ///     The link thickness
        /// </summary>
        public float LinkThickness;

        /// <summary>
        ///     The link line segments per length
        /// </summary>
        public float LinkLineSegmentsPerLength;

        /// <summary>
        ///     The link hover distance
        /// </summary>
        public float LinkHoverDistance;

        /// <summary>
        ///     The pin circle radius
        /// </summary>
        public float PinCircleRadius;

        /// <summary>
        ///     The pin quad side length
        /// </summary>
        public float PinQuadSideLength;

        /// <summary>
        ///     The pin triangle side length
        /// </summary>
        public float PinTriangleSideLength;

        /// <summary>
        ///     The pin line thickness
        /// </summary>
        public float PinLineThickness;

        /// <summary>
        ///     The pin hover radius
        /// </summary>
        public float PinHoverRadius;

        /// <summary>
        ///     The pin offset
        /// </summary>
        public float PinOffset;

        /// <summary>
        ///     The mini map padding
        /// </summary>
        public Vector2 MiniMapPadding;

        /// <summary>
        ///     The mini map offset
        /// </summary>
        public Vector2 MiniMapOffset;

        /// <summary>
        ///     The flags
        /// </summary>
        public ImNodesStyleFlags Flags;

        /// <summary>
        ///     The colors
        /// </summary>
        public fixed uint Colors[29];
    }
}