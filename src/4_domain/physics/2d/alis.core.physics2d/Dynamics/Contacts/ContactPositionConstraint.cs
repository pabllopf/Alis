// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   ContactPositionConstraint.cs
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

using System.Numerics;
using Alis.Core.Physics2D.Collision;
using Alis.Core.Physics2D.Common;

namespace Alis.Core.Physics2D.Dynamics.Contacts
{
    /// <summary>
    /// The contact position constraint class
    /// </summary>
    internal class ContactPositionConstraint
    {
        /// <summary>
        /// The index
        /// </summary>
        internal int indexA;
        /// <summary>
        /// The index
        /// </summary>
        internal int indexB;
        /// <summary>
        /// The inv ia
        /// </summary>
        internal float invIA;
        /// <summary>
        /// The inv ib
        /// </summary>
        internal float invIB;
        /// <summary>
        /// The inv mass
        /// </summary>
        internal float invMassA;
        /// <summary>
        /// The inv mass
        /// </summary>
        internal float invMassB;
        /// <summary>
        /// The local center
        /// </summary>
        internal Vector2 localCenterA;
        /// <summary>
        /// The local center
        /// </summary>
        internal Vector2 localCenterB;
        /// <summary>
        /// The local normal
        /// </summary>
        internal Vector2 localNormal;
        /// <summary>
        /// The local point
        /// </summary>
        internal Vector2 localPoint;
        /// <summary>
        /// The max manifold points
        /// </summary>
        internal Vector2[] localPoints = new Vector2[Settings.MaxManifoldPoints];
        /// <summary>
        /// The point count
        /// </summary>
        internal int pointCount;
        /// <summary>
        /// The radius
        /// </summary>
        internal float radiusA;
        /// <summary>
        /// The radius
        /// </summary>
        internal float radiusB;
        /// <summary>
        /// The type
        /// </summary>
        internal ManifoldType type;
    }
}