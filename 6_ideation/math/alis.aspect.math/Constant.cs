// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   MathConstants.cs
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
    ///     The math constants class
    /// </summary>
    public static class Constant
    {
        /// <summary>
        ///     The pi
        /// </summary>
        public const float Pi = (float) System.Math.PI;

        /// <summary>
        ///     The pi
        /// </summary>
        public const float TwoPi = Pi * 2.0f; 

        /// <summary>
        ///     The max value
        /// </summary>
        public const float MaxFloat = float.MaxValue;

        /// <summary>
        ///     The epsilon
        /// </summary>
        public const float Epsilon = 1.192092896e-07f;

        /// <summary>
        ///     The euler
        /// </summary>
        public const float Euler = 2.7182818284590452354f;
        
        /// <summary>Represents the mathematical constant e(2.71828175).</summary>
        public const float E = (float) System.Math.E;

        /// <summary>Represents the log base ten of e(0.4342945).</summary>
        public const float Log10E = 0.4342945f;

        /// <summary>Represents the log base two of e(1.442695).</summary>
        public const float Log2E = 1.442695f;

        /// <summary>Represents the value of pi divided by two(1.57079637).</summary>
        public const float PiOver2 = (float) (System.Math.PI / 2.0);

        /// <summary>Represents the value of pi divided by four(0.7853982).</summary>
        public const float PiOver4 = (float) (System.Math.PI / 4.0);

        /// <summary>Represents the value of pi times two(6.28318548). This is an alias of TwoPi.</summary>
        public const float Tau = TwoPi;
    }
}