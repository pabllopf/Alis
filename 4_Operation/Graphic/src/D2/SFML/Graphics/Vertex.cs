// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Vertex.cs
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

using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math;

namespace Alis.Core.Graphic.D2.SFML.Graphics
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    ///     Define a point with color and texture coordinates
    /// </summary>
    ////////////////////////////////////////////////////////////
    [StructLayout(LayoutKind.Sequential)]
    public struct Vertex
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the vertex from its position
        ///     The vertex color is white and texture coordinates are (0, 0).
        /// </summary>
        /// <param name="position">Vertex position</param>
        ////////////////////////////////////////////////////////////
        public Vertex(Vector2 position) :
            this(position, Color.White, new Vector2(0, 0))
        {
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the vertex from its position and color
        ///     The texture coordinates are (0, 0).
        /// </summary>
        /// <param name="position">Vertex position</param>
        /// <param name="color">Vertex color</param>
        ////////////////////////////////////////////////////////////
        public Vertex(Vector2 position, Color color) :
            this(position, color, new Vector2(0, 0))
        {
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the vertex from its position and texture coordinates
        ///     The vertex color is white.
        /// </summary>
        /// <param name="position">Vertex position</param>
        /// <param name="texCoords">Vertex texture coordinates</param>
        ////////////////////////////////////////////////////////////
        public Vertex(Vector2 position, Vector2 texCoords) :
            this(position, Color.White, texCoords)
        {
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the vertex from its position, color and texture coordinates
        /// </summary>
        /// <param name="position">Vertex position</param>
        /// <param name="color">Vertex color</param>
        /// <param name="texCoords">Vertex texture coordinates</param>
        ////////////////////////////////////////////////////////////
        public Vertex(Vector2 position, Color color, Vector2 texCoords)
        {
            Position = position;
            Color = color;
            TexCoords = texCoords;
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        ////////////////////////////////////////////////////////////
        public override string ToString() => "[Vertex]" +
                                             " Position(" + Position + ")" +
                                             " Color(" + Color + ")" +
                                             " TexCoords(" + TexCoords + ")";

        /// <summary>2D position of the vertex</summary>
        public Vector2 Position;

        /// <summary>Color of the vertex</summary>
        public Color Color;

        /// <summary>Coordinates of the texture's pixel to map to the vertex</summary>
        public Vector2 TexCoords;
    }
}