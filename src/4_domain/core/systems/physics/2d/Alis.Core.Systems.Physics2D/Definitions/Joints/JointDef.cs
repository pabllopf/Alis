// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   JointDef.cs
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

using Alis.Core.Systems.Physics2D.Dynamics;
using Alis.Core.Systems.Physics2D.Dynamics.Joints.Misc;

namespace Alis.Core.Systems.Physics2D.Definitions.Joints
{
    /// <summary>
    ///     The joint def class
    /// </summary>
    /// <seealso cref="IDef" />
    public abstract class JointDef : IDef
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="JointDef" /> class
        /// </summary>
        /// <param name="type">The type</param>
        protected JointDef(JointType type) => Type = type;

        /// <summary>The first attached body.</summary>
        public Body BodyA { get; set; }

        /// <summary>The second attached body.</summary>
        public Body BodyB { get; set; }

        /// <summary>Set this flag to true if the attached bodies should collide.</summary>
        public bool CollideConnected { get; set; }

        /// <summary>The joint type is set automatically for concrete joint types.</summary>
        public JointType Type { get; }

        /// <summary>Use this to attach application specific data.</summary>
        public object UserData { get; set; }

        /// <summary>
        ///     Sets the defaults
        /// </summary>
        public virtual void SetDefaults()
        {
            BodyA = null;
            BodyB = null;
            CollideConnected = false;
            UserData = null;
        }
    }
}