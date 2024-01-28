// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RayCastInput.cs
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

namespace Alis.Core.Physic.Collision.RayCast
{
    /// <summary>Ray-cast input data.</summary>
    public struct RayCastInput
    {
        /// <summary>
        ///     The ray extends from p1 to p1 + maxFraction * (p2 - p1). If you supply a max fraction of 1, the ray extends
        ///     from p1 to p2. A max fraction of 0.5 makes the ray go from p1 and half way to p2.
        /// </summary>
        public float Fraction;

        /// <summary>The starting point of the ray.</summary>
        public Vector2 Point1;

        /// <summary>The ending point of the ray.</summary>
        public Vector2 Point2;
    }
}