// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Vec2.cs
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
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.Sfml.Render
{
    #region 2D Vectors

    /// <summary>
    ///     <see cref="Vec2" /> is a struct represent a glsl vec2 value
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Vec2
    {
        /// <summary>
        ///     Implicit cast from <see cref="Alis.Core.Aspect.Math.Vector.Vector2F" /> to <see cref="Vec2" />
        /// </summary>
        public static implicit operator Vec2(Vector2F vec) => new Vec2(vec);


        /// <summary>
        ///     Construct the <see cref="Vec2" /> from its coordinates
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        ////////////////////////////////////////////////////////////
        public Vec2(float x, float y)
        {
            X = x;
            Y = y;
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the <see cref="Vec2" /> from a standard SFML <see cref="Alis.Core.Aspect.Math.Vector.Vector2F" />
        /// </summary>
        /// <param name="vec">A standard SFML 2D vector</param>
        ////////////////////////////////////////////////////////////
        public Vec2(Vector2F vec)
        {
            X = vec.X;
            Y = vec.Y;
        }

        /// <summary>Horizontal component of the vector</summary>
        public float X;

        /// <summary>Vertical component of the vector</summary>
        public float Y;
    }

    ////////////////////////////////////////////////////////////

    ////////////////////////////////////////////////////////////

    #endregion

    #region 3D Vectors

    ////////////////////////////////////////////////////////////

    ////////////////////////////////////////////////////////////

    ////////////////////////////////////////////////////////////

    #endregion

    #region 4D Vectors

    ////////////////////////////////////////////////////////////

    ////////////////////////////////////////////////////////////

    ////////////////////////////////////////////////////////////

    #endregion

    #region Matrices

    ////////////////////////////////////////////////////////////

    ////////////////////////////////////////////////////////////

    #endregion
}