// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Jacobian.cs
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

using Alis.Aspect.Math;

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    ///     The jacobian
    /// </summary>
    public struct Jacobian
    {
        /// <summary>
        ///     The linear
        /// </summary>
        public Vector2 Linear1;

        /// <summary>
        ///     The angular
        /// </summary>
        public float Angular1;

        /// <summary>
        ///     The linear
        /// </summary>
        public Vector2 Linear2;

        /// <summary>
        ///     The angular
        /// </summary>
        public float Angular2;

        /// <summary>
        ///     Sets the zero
        /// </summary>
        public void SetZero()
        {
            Linear1.SetZero();
            Angular1 = 0.0f;
            Linear2.SetZero();
            Angular2 = 0.0f;
        }

        /// <summary>
        ///     Sets the x 1
        /// </summary>
        /// <param name="x1">The </param>
        /// <param name="a1">The </param>
        /// <param name="x2">The </param>
        /// <param name="a2">The </param>
        public void Set(Vector2 x1, float a1, Vector2 x2, float a2)
        {
            Linear1 = x1;
            Angular1 = a1;
            Linear2 = x2;
            Angular2 = a2;
        }

        /// <summary>
        ///     Computes the x 1
        /// </summary>
        /// <param name="x1">The </param>
        /// <param name="a1">The </param>
        /// <param name="x2">The </param>
        /// <param name="a2">The </param>
        /// <returns>The float</returns>
        public float Compute(Vector2 x1, float a1, Vector2 x2, float a2) => Vector2.Dot(Linear1, x1) + Angular1 * a1 + Vector2.Dot(Linear2, x2) + Angular2 * a2;
    }
}