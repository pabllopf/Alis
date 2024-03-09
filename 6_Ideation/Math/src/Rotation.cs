// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Rotation.cs
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
    /// <summary>Rotation</summary>
    public struct Rotation
    {
        /// Sine and cosine
        public float Sine { get; set; }

        /// Sine and cosine
        public float Cosine { get; set; }

        /// <summary>
        ///     The angle
        /// </summary>
        public float Angle;

        /// <summary>Initialize from an angle in radians</summary>
        /// <param name="angle">Angle in radians</param>
        public Rotation(float angle)
        {
            Angle = angle;
            Sine = (float) System.Math.Sin(angle);
            Cosine = (float) System.Math.Cos(angle);
        }

        /// <summary>Set using an angle in radians.</summary>
        /// <param name="angle"></param>
        public void Set(float angle)
        {
            Angle = angle;
            //Velcro: Optimization
            if (MathF.Abs(angle) < float.Epsilon && MathF.Abs(angle) > -float.Epsilon)
            {
                Sine = 0;
                Cosine = 1;
            }
            else
            {
                Sine = (float) System.Math.Sin(angle);
                Cosine = (float) System.Math.Cos(angle);
            }
        }

        /// <summary>Set to the identity rotation</summary>
        public void SetIdentity()
        {
            Sine = 0.0f;
            Cosine = 1.0f;
        }

        /// <summary>Get the angle in radians</summary>
        public float GetAngle() => (float) System.Math.Atan2(Sine, Cosine);

        /// <summary>Get the x-axis</summary>
        public Vector2 GetXAxis() => new Vector2(Cosine, Sine);

        /// <summary>Get the y-axis</summary>
        public Vector2 GetYAxis() => new Vector2(-Sine, Cosine);
    }
}