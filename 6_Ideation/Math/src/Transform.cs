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

using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Aspect.Math
{
    /// <summary>
    ///     A transform contains translation and rotation. It is used to represent the position and orientation of rigid
    ///     frames.
    /// </summary>
    public class Transform
    {
        /// <summary>
        ///     The
        /// </summary>
        public Vector2 Position;

        /// <summary>
        ///     The scale
        /// </summary>
        public Vector2 Scale;

        /// <summary>
        ///     The
        /// </summary>
        public Rotation Rotation;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Transform" /> class
        /// </summary>
        /// <param name="position">The position</param>
        /// <param name="rotation">The rotation</param>
        /// <param name="scale">The scale</param>
        public Transform(Vector2 position, Rotation rotation, Vector2 scale)
        {
            Position = position;
            Rotation = rotation;
            Scale = scale;
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Transform"/> class
        /// </summary>
        public Transform()
        {
            Position = new Vector2(0, 0);
            Rotation = new Rotation(0);
            Scale = new Vector2(1, 1);
        }

        /// <summary>Set this to the identity transform.</summary>
        public void SetIdentity()
        {
            Position = Vector2.Zero;
            Rotation.SetIdentity();
        }

        /// <summary>Set this based on the position and angle.</summary>
        /// <param name="position">The position.</param>
        /// <param name="angle">The angle.</param>
        public void Set(Vector2 position, float angle)
        {
            Position = position;
            Rotation.Set(angle);
        }
    }
}