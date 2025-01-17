// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContactPositionConstraint.cs
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
using Alis.Core.Physic.Collision;

namespace Alis.Core.Physic.Dynamics.Contacts
{
    /// <summary>
    ///     The contact position constraint class
    /// </summary>
    public sealed class ContactPositionConstraint
    {
        /// <summary>
        ///     The max manifold points
        /// </summary>
        public readonly Vector2F[] LocalPoints = new Vector2F[SettingEnv.MaxManifoldPoints];

        /// <summary>
        ///     The index
        /// </summary>
        public int IndexA;

        /// <summary>
        ///     The index
        /// </summary>
        public int IndexB;

        /// <summary>
        ///     The inv ib
        /// </summary>
        public float InvIa, InvIb;

        /// <summary>
        ///     The inv mass
        /// </summary>
        public float InvMassA, InvMassB;

        /// <summary>
        ///     The local center
        /// </summary>
        public Vector2F LocalCenterA, LocalCenterB;

        /// <summary>
        ///     The local normal
        /// </summary>
        public Vector2F LocalNormal;

        /// <summary>
        ///     The local point
        /// </summary>
        public Vector2F LocalPoint;

        /// <summary>
        ///     The point count
        /// </summary>
        public int PointCount;

        /// <summary>
        ///     The radius
        /// </summary>
        public float RadiusA, RadiusB;

        /// <summary>
        ///     The type
        /// </summary>
        public ManifoldType Type;
    }
}