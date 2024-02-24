// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Triangle.cs
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
using Alis.Core.Physic.Shared;

namespace Alis.Core.Physic.Tools.Triangulation.EarClip
{
    /// <summary>
    ///     The triangle class
    /// </summary>
    /// <seealso cref="Vertices" />
    public class Triangle : Vertices
    {
        //Constructor automatically fixes orientation to ccw
        /// <summary>
        ///     Initializes a new instance of the <see cref="Triangle" /> class
        /// </summary>
        /// <param name="x1">The </param>
        /// <param name="y1">The </param>
        /// <param name="x2">The </param>
        /// <param name="y2">The </param>
        /// <param name="x3">The </param>
        /// <param name="y3">The </param>
        public Triangle(float x1, float y1, float x2, float y2, float x3, float y3)
        {
            float cross = (x2 - x1) * (y3 - y1) - (x3 - x1) * (y2 - y1);
            if (cross > 0)
            {
                Add(new Vector2(x1, y1));
                Add(new Vector2(x2, y2));
                Add(new Vector2(x3, y3));
            }
            else
            {
                Add(new Vector2(x1, y1));
                Add(new Vector2(x3, y3));
                Add(new Vector2(x2, y2));
            }
        }

        /// <summary>
        ///     Describes whether this instance is inside
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The bool</returns>
        public bool IsInside(float x, float y)
        {
            Vector2 a = this[0];
            Vector2 b = this[1];
            Vector2 c = this[2];

            if ((x < a.X) && (x < b.X) && (x < c.X))
            {
                return false;
            }

            if ((x > a.X) && (x > b.X) && (x > c.X))
            {
                return false;
            }

            if ((y < a.Y) && (y < b.Y) && (y < c.Y))
            {
                return false;
            }

            if ((y > a.Y) && (y > b.Y) && (y > c.Y))
            {
                return false;
            }

            float vx2 = x - a.X;
            float vy2 = y - a.Y;
            float vx1 = b.X - a.X;
            float vy1 = b.Y - a.Y;
            float vx0 = c.X - a.X;
            float vy0 = c.Y - a.Y;

            float dot00 = vx0 * vx0 + vy0 * vy0;
            float dot01 = vx0 * vx1 + vy0 * vy1;
            float dot02 = vx0 * vx2 + vy0 * vy2;
            float dot11 = vx1 * vx1 + vy1 * vy1;
            float dot12 = vx1 * vx2 + vy1 * vy2;
            float invDen = 1.0f / (dot00 * dot11 - dot01 * dot01);
            float u = (dot11 * dot02 - dot01 * dot12) * invDen;
            float v = (dot00 * dot12 - dot01 * dot02) * invDen;

            return (u > 0) && (v > 0) && (u + v < 1);
        }
    }
}