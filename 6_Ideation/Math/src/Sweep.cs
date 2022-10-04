// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Sweep.cs
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

namespace Alis.Core.Aspect.Math
{
    /// <summary>
    ///     The sweep
    /// </summary>
    public struct Sweep
    {
        /// <summary>
        ///     The local center
        /// </summary>
        public Vector2 LocalCenter; //local center of mass position

        /// <summary>
        ///     The
        /// </summary>
        public Vector2 C0; //local center of mass position

        /// <summary>
        ///     The
        /// </summary>
        public Vector2 C; //local center of mass position

        /// <summary>
        ///     The
        /// </summary>
        public float A0; //world angles

        /// <summary>
        ///     The
        /// </summary>
        public float A; //world angles

        /// <summary>
        ///     The
        /// </summary>
        public float T0; //time interval = [T0,1], where T0 is in [0,1]

        /// <summary>
        ///     Get the interpolated transform at a specific time.
        /// </summary>
        /// <param name="xf">The xf.</param>
        /// <param name="alpha">Alpha is a factor in [0,1], where 0 indicates t0.</param>
        public void GetTransform(out XForm xf, float alpha)
        {
            xf = new XForm();
            xf.Position = (1.0f - alpha) * C0 + alpha * C;
            float angle = (1.0f - alpha) * A0 + alpha * A;
            xf.R.Set(angle);

            // Shift to origin
            xf.Position -= Helper.Mul(xf.R, LocalCenter);
        }

        /// <summary>
        ///     Advance the sweep forward, yielding a new initial state.
        /// </summary>
        /// <param name="t">The new initial time.</param>
        public void Advance(float t)
        {
            if (T0 < t && 1.0f - T0 > Settings.FltEpsilon)
            {
                float alpha = (t - T0) / (1.0f - T0);
                C0 = (1.0f - alpha) * C0 + alpha * C;
                A0 = (1.0f - alpha) * A0 + alpha * A;
                T0 = t;
            }
        }
    }
}