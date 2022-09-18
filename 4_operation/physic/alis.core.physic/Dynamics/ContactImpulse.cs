// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContactImpulse.cs
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

using Alis.Core.Aspect.Math;

namespace Alis.Core.Physic.Dynamics
{
    /// Contact impulses for reporting. Impulses are used instead of forces because
    /// sub-step forces may approach infinity for rigid body collisions. These
    /// match up one-to-one with the contact points in b2Manifold.
    public class ContactImpulse
    {
        /// <summary>
        ///     The max manifold points
        /// </summary>
        public readonly float[] NormalImpulses = new float[Settings.MaxManifoldPoints];

        /// <summary>
        ///     The max manifold points
        /// </summary>
        public readonly float[] TangentImpulses = new float[Settings.MaxManifoldPoints];
    }
}