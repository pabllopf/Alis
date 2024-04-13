// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VelocityConstraintPoint.cs
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

namespace Alis.Core.Physic.Dynamics.Solver
{
    /// <summary>
    ///     The velocity constraint point class
    /// </summary>
    public sealed class VelocityConstraintPoint
    {
        /// <summary>
        ///     The normal impulse
        /// </summary>
        public float NormalImpulse;
        
        /// <summary>
        ///     The normal mass
        /// </summary>
        public float NormalMass;
        
        /// <summary>
        ///     The
        /// </summary>
        public Vector2 Ra;
        
        /// <summary>
        ///     The
        /// </summary>
        public Vector2 Rb;
        
        /// <summary>
        ///     The tangent impulse
        /// </summary>
        public float TangentImpulse;
        
        /// <summary>
        ///     The tangent mass
        /// </summary>
        public float TangentMass;
        
        /// <summary>
        ///     The velocity bias
        /// </summary>
        public float VelocityBias;
    }
}