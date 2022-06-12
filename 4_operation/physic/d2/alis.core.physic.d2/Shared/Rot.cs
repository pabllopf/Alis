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

namespace Alis.Core.Physic.D2.Shared
{
    /// <summary>Rotation</summary>
    public struct Rot
    {
        /// Sine and cosine
        public float S,
            C;

        /// <summary>Initialize from an angle in radians</summary>
        /// <param name="angle">Angle in radians</param>
        public Rot(float angle)
        {
            // TODO_ERIN optimize
            S = (float) Math.Sin(angle);
            C = (float) Math.Cos(angle);
        }

        /// <summary>Set using an angle in radians.</summary>
        /// <param name="angle"></param>
        public void Set(float angle)
        {
            //Velcro: Optimization
            if (angle == 0)
            {
                S = 0;
                C = 1;
            }
            else
            {
                // TODO_ERIN optimize
                S = (float) Math.Sin(angle);
                C = (float) Math.Cos(angle);
            }
        }

        /// <summary>Set to the identity rotation</summary>
        public void SetIdentity()
        {
            S = 0.0f;
            C = 1.0f;
        }

        /// <summary>Get the angle in radians</summary>
        public float GetAngle()
        {
            return (float) Math.Atan2(S, C);
        }

        /// <summary>Get the x-axis</summary>
        public Vector2 GetXAxis()
        {
            return new Vector2(C, S);
        }

        /// <summary>Get the y-axis</summary>
        public Vector2 GetYAxis()
        {
            return new Vector2(-S, C);
        }
    }
}