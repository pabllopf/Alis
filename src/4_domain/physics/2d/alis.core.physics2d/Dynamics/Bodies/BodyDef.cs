// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   BodyDef.cs
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

namespace Alis.Core.Physics2D.Bodies
{
    /// <summary>
    ///     A body definition holds all the data needed to construct a rigid body.
    ///     You can safely re-use body definitions.
    /// </summary>
    public class BodyDef // in C# it has to be a class to have a parameterless constructor
    {
        /// <summary>
        ///     Set this flag to false if this body should never fall asleep. Note that
        ///     this increases CPU usage.
        /// </summary>
        public bool allowSleep;

        /// <summary>
        ///     The world angle of the body in radians.
        /// </summary>
        public float angle;

        /// <summary>
        ///     Angular damping is use to reduce the angular velocity. The damping parameter
        ///     can be larger than 1.0f but the damping effect becomes sensitive to the
        ///     time step when the damping parameter is large.
        /// </summary>
        public float angularDamping;

        // The angular velocity of the body.
        /// <summary>
        ///     The angular velocity
        /// </summary>
        public float angularVelocity;

        /// <summary>
        ///     The awake
        /// </summary>
        public bool awake;

        /// <summary>
        ///     Is this a fast moving body that should be prevented from tunneling through
        ///     other moving bodies? Note that all bodies are prevented from tunneling through
        ///     static bodies.
        ///     @warning You should use this flag sparingly since it increases processing time.
        /// </summary>
        public bool bullet;

        /// <summary>
        ///     The enabled
        /// </summary>
        public bool enabled;

        /// <summary>
        ///     Should this body be prevented from rotating? Useful for characters.
        /// </summary>
        public bool fixedRotation;

        /// <summary>
        ///     The gravity scale
        /// </summary>
        public float gravityScale;

        /// <summary>
        ///     Linear damping is use to reduce the linear velocity. The damping parameter
        ///     can be larger than 1.0f but the damping effect becomes sensitive to the
        ///     time step when the damping parameter is large.
        /// </summary>
        public float linearDamping;

        /// The linear velocity of the body in world co-ordinates.
        public Vector2 linearVelocity;

        /// <summary>
        ///     The world position of the body. Avoid creating bodies at the origin
        ///     since this can lead to many overlapping shapes.
        /// </summary>
        public Vector2 position;

        /// <summary>
        ///     The type
        /// </summary>
        public BodyType type;

        /// <summary>
        ///     Use this to store application specific body data.
        /// </summary>
        public object userData;

        /// <summary>
        ///     This constructor sets the body definition default values.
        /// </summary>
        public BodyDef()
        {
            userData = null;
            position = Vector2.Zero;
            angle = 0.0f;
            linearVelocity = Vector2.Zero;
            angularVelocity = 0.0f;
            linearDamping = 0.0f;
            angularDamping = 0.0f;
            allowSleep = true;
            awake = true;
            fixedRotation = false;
            bullet = false;
            type = BodyType.Static;
            enabled = true;
            gravityScale = 1.0f;
        }
    }
}