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

namespace Alis.Core.Physic.Dynamics.Contacts
{
    /// <summary>
    ///     The velocity constraint point class
    /// </summary>
    public sealed class VelocityConstraintPoint
    {
        /// <summary>
        ///     The accumulated impulse along the contact normal.
        /// </summary>
        public float NormalImpulse;

        /// <summary>
        ///     The effective mass in the normal direction.
        /// </summary>
        public float NormalMass;

        /// <summary>
        ///     The vector from body A center of mass to the contact point.
        /// </summary>
        public Vector2F Ra;

        /// <summary>
        ///     The vector from body B center of mass to the contact point.
        /// </summary>
        public Vector2F Rb;

        /// <summary>
        ///     The accumulated impulse along the tangent (friction) direction.
        /// </summary>
        public float TangentImpulse;

        /// <summary>
        ///     The effective mass in the tangent direction.
        /// </summary>
        public float TangentMass;

        /// <summary>
        ///     The velocity bias for restitution (bounce) at this contact point.
        /// </summary>
        public float VelocityBias;
    }
}