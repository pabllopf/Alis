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

namespace Alis.Core.Systems.Physics2D.Shared
{
    /// <summary>Rotation</summary>
    public struct Rot
    {
        /// Sine and cosine
        public float s,
            c;

        /// <summary>Initialize from an angle in radians</summary>
        /// <param name="angle">Angle in radians</param>
        public Rot(float angle)
        {
            // TODO_ERIN optimize
            s = (float) Math.Sin(angle);
            c = (float) Math.Cos(angle);
        }

        /// <summary>Set using an angle in radians.</summary>
        /// <param name="angle"></param>
        public void Set(float angle)
        {
            //Velcro: Optimization
            if (angle == 0)
            {
                s = 0;
                c = 1;
            }
            else
            {
                // TODO_ERIN optimize
                s = (float) Math.Sin(angle);
                c = (float) Math.Cos(angle);
            }
        }

        /// <summary>Set to the identity rotation</summary>
        public void SetIdentity()
        {
            s = 0.0f;
            c = 1.0f;
        }

        /// <summary>Get the angle in radians</summary>
        public float GetAngle() => (float) Math.Atan2(s, c);

        /// <summary>Get the x-axis</summary>
        public Vector2 GetXAxis() => new Vector2(c, s);

        /// <summary>Get the y-axis</summary>
        public Vector2 GetYAxis() => new Vector2(-s, c);
    }
}