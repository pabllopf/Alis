// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Rot.cs
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

using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Alis.Core.Physics2D
{
    /// <summary>
    ///     The rot
    /// </summary>
    public struct Rot
    {
        /// Sine and cosine
        internal float s;

        /// Sine and cosine
        internal float c;

        /// Initialize from an angle in radians
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal Rot(float angle)
        {
            s = MathF.Sin(angle);
            c = MathF.Cos(angle);
        }

        /// Set using an angle in radians.
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void Set(float angle)
        {
            s = MathF.Sin(angle);
            c = MathF.Cos(angle);
        }

        /// Set to the identity rotation
        private void SetIdentity()
        {
            s = 0.0f;
            c = 1.0f;
        }

        /// Get the angle in radians
        private float GetAngle() => MathF.Atan2(s, c);

        /// Get the x-axis
        private Vector2 GetXAxis() => new Vector2(c, s);

        /// Get the u-axis
        private Vector2 GetYAxis() => new Vector2(-s, c);
    }
}