// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StyleVar.cs
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

namespace Alis.Extension.Graphic.ImGui.Extras.Node
{
    /// <summary>
    ///     The style var enum
    /// </summary>
    public enum StyleVar
    {
        /// <summary>
        ///     The grid spacing style var
        /// </summary>
        GridSpacing = 0,

        /// <summary>
        ///     The node corner rounding style var
        /// </summary>
        NodeCornerRounding = 1,

        /// <summary>
        ///     The node padding horizontal style var
        /// </summary>
        NodePaddingHorizontal = 2,

        /// <summary>
        ///     The node padding vertical style var
        /// </summary>
        NodePaddingVertical = 3,

        /// <summary>
        ///     The node border thickness style var
        /// </summary>
        NodeBorderThickness = 4,

        /// <summary>
        ///     The link thickness style var
        /// </summary>
        LinkThickness = 5,

        /// <summary>
        ///     The link line segments per length style var
        /// </summary>
        LinkLineSegmentsPerLength = 6,

        /// <summary>
        ///     The link hover distance style var
        /// </summary>
        LinkHoverDistance = 7,

        /// <summary>
        ///     The pin circle radius style var
        /// </summary>
        PinCircleRadius = 8,

        /// <summary>
        ///     The pin quad side length style var
        /// </summary>
        PinQuadSideLength = 9,

        /// <summary>
        ///     The pin triangle side length style var
        /// </summary>
        PinTriangleSideLength = 10,

        /// <summary>
        ///     The pin line thickness style var
        /// </summary>
        PinLineThickness = 11,

        /// <summary>
        ///     The pin hover radius style var
        /// </summary>
        PinHoverRadius = 12,

        /// <summary>
        ///     The pin offset style var
        /// </summary>
        PinOffset = 13
    }
}