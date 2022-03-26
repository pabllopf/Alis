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

using Alis.Core.Physics2D.Bodies;

namespace Alis.Core.Physics2D.Joints
{
    /// <summary>
    ///     Joint definitions are used to construct joints.
    /// </summary>
    public class JointDef
    {
        /// <summary>
        ///     The first attached body.
        /// </summary>
        public Body bodyA;

        /// <summary>
        ///     The second attached body.
        /// </summary>
        public Body bodyB;

        /// <summary>
        ///     Set this flag to true if the attached bodies should collide.
        /// </summary>
        public bool collideConnected;

        /// <summary>
        ///     Use this to attach application specific data to your joints.
        /// </summary>
        public object UserData;

        /// <summary>
        ///     Initializes a new instance of the <see cref="JointDef" /> class
        /// </summary>
        public JointDef()
        {
            UserData = null;
            bodyA = null;
            bodyB = null;
            collideConnected = false;
        }
    }
}