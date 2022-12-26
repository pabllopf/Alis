// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Transform.cs
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

using System.Numerics;

namespace Alis.Core.Physic.Shared
{
    /// <summary>
    ///     A transform contains translation and rotation. It is used to represent the position and orientation of rigid
    ///     frames.
    /// </summary>
    public struct Transform
    {
        /// <summary>
        ///     The
        /// </summary>
        public Vector2 P;

        /// <summary>
        ///     The
        /// </summary>
        public Rot Q;

        /// <summary>Initialize using a position vector and a rotation matrix.</summary>
        /// <param name="position">The position.</param>
        /// <param name="rotation">The r.</param>
        public Transform(ref Vector2 position, ref Rot rotation)
        {
            P = position;
            Q = rotation;
        }

        /// <summary>Set this to the identity transform.</summary>
        public void SetIdentity()
        {
            P = Vector2.Zero;
            Q.SetIdentity();
        }

        /// <summary>Set this based on the position and angle.</summary>
        /// <param name="position">The position.</param>
        /// <param name="angle">The angle.</param>
        public void Set(Vector2 position, float angle)
        {
            P = position;
            Q.Set(angle);
        }
    }
}