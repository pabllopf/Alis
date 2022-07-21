// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   XForm.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

namespace Alis.Aspect.Math
{
    /// <summary>
    ///     A transform contains translation and rotation.
    ///     It is used to represent the position and orientation of rigid frames.
    /// </summary>
    public struct XForm
    {
        /// <summary>
        ///     The position
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        ///     The
        /// </summary>
        public Matrix22 R { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="XForm" /> struct.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="rotation">The rotation.</param>
        private XForm(Vector2 position, Matrix22 rotation)
        {
            Position = position;
            R = rotation;
        }

        /// <summary>
        ///     Set this to the identity transform.
        /// </summary>
        public void SetIdentity()
        {
            Position.SetZero();
            R.SetIdentity();
        }

        /// Set this based on the position and angle.
        public void Set(Vector2 p, float angle)
        {
            Position = p;
            R.Set(angle);
        }

        /// Calculate the angle that the rotation matrix represents.
        public float GetAngle()
        {
            return Math.Atan2(R.Col1.Y, R.Col1.X);
        }

        /// <summary>
        ///     Gets the value of the identity
        /// </summary>
        public static XForm Identity
        {
            get { return new XForm(Vector2.Zero, Matrix22.Identity); }
        }
    }
}