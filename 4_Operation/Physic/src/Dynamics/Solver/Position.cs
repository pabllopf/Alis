// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Position.cs
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

namespace Alis.Core.Physic.Dynamics.Solver
{
    /// This is an internal structure.
    public class Position
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Position" /> class
        /// </summary>
        /// <param name="c">The </param>
        /// <param name="a">The </param>
        public Position(Vector2 c, float a)
        {
            C = c;
            A = a;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Position" /> class
        /// </summary>
        public Position()
        {
            C = Vector2.Zero;
            A = 0.0f;
        }

        /// <summary>
        ///     The
        /// </summary>
        public float A { get; set; }

        /// <summary>
        ///     The
        /// </summary>
        public Vector2 C { get; set; }
    }
}