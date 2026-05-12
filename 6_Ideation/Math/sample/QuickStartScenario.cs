// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:QuickStartScenario.cs
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

namespace Alis.Core.Aspect.Math.Sample
{
    /// <summary>
    ///     Math helper scenario for sample programs.
    /// </summary>
    internal static class QuickStartScenario
    {
        /// <summary>
        ///     Computes squared distance in 2D without square root cost.
        /// </summary>
        /// <param name="from">Start position.</param>
        /// <param name="to">End position.</param>
        /// <returns>The squared distance value.</returns>
        internal static float DistanceSquared(Vector2F from, Vector2F to)
        {
            Vector2F delta = to - from;
            return (delta.X * delta.X) + (delta.Y * delta.Y);
        }
    }
}
