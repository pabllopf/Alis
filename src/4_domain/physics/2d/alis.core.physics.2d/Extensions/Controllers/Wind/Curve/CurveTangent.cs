// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   CurveTangent.cs
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

namespace Alis.Core.Systems.Physics2D.Extensions.Controllers.Wind.Curve
{
    /// <summary>
    ///     Defines the different tangent types to be calculated for <see cref="CurveKey" /> points in a
    ///     <see cref="Curve" />.
    /// </summary>
    public enum CurveTangent
    {
        /// <summary>The tangent which always has a value equal to zero.</summary>
        Flat,

        /// <summary>
        ///     The tangent which contains a difference between current tangent value and the tangent value from the previous
        ///     <see cref="CurveKey" />.
        /// </summary>
        Linear,

        /// <summary>
        ///     The smoouth tangent which contains the inflection between <see cref="CurveKey.TangentIn" /> and
        ///     <see cref="CurveKey.TangentOut" /> by taking into account the values of both neighbors of the
        ///     <see cref="CurveKey" />.
        /// </summary>
        Smooth
    }
}