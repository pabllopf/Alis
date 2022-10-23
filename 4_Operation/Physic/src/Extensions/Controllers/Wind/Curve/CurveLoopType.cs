// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   CurveLoopType.cs
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

using Alis.Core.Systems.Physics2D.Config.Extensions.Controllers.Wind.Curve;

namespace Alis.Core.Physic.Extensions.Controllers.Wind.Curve
{
    /// <summary>
    ///     Defines how the <see cref="Curve" /> value is determined for position before first point or after the end
    ///     point on the <see cref="Curve" />.
    /// </summary>
    public enum CurveLoopType
    {
        /// <summary>
        ///     The value of <see cref="Curve" /> will be evaluated as first point for positions before the beginning and end
        ///     point for positions after the end.
        /// </summary>
        Constant,

        /// <summary>The positions will wrap around from the end to beginning of the <see cref="Curve" /> for determined the value.</summary>
        Cycle,

        /// <summary>
        ///     The positions will wrap around from the end to beginning of the <see cref="Curve" />. The value will be offset
        ///     by the difference between the values of first and end <see cref="CurveKey" /> multiplied by the wrap amount. If the
        ///     position is before the beginning of the <see cref="Curve" /> the difference will be subtracted from its value;
        ///     otherwise the difference will be added.
        /// </summary>
        CycleOffset,

        /// <summary>
        ///     The value at the end of the <see cref="Curve" /> act as an offset from the same side of the
        ///     <see cref="Curve" /> toward the opposite side.
        /// </summary>
        Oscillate,

        /// <summary>The linear interpolation will be performed for determined the value.</summary>
        Linear
    }
}