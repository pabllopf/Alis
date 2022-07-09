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

using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    ///     A body definition holds all the data needed to construct a rigid body.
    ///     You can safely re-use body definitions.
    /// </summary>
    public struct BodyDef
    {
        /// <summary>
        ///     This constructor sets the body definition default values.
        /// </summary>
        public BodyDef(byte init)
        {
            MassData = new MassData();
            MassData.Center.SetZero();
            MassData.Mass = 0.0f;
            MassData.I = 0.0f;
            UserData = null;
            Position = new Vec2();
            Position.Set(0.0f, 0.0f);
            Angle = 0.0f;
            LinearVelocity = new Vec2(0f, 0f);
            AngularVelocity = 0.0f;
            LinearDamping = 0.0f;
            AngularDamping = 0.0f;
            AllowSleep = true;
            IsSleeping = false;
            FixedRotation = false;
            IsBullet = false;
        }

        /// <summary>
        ///     You can use this to initialized the mass properties of the body.
        ///     If you prefer, you can set the mass properties after the shapes
        ///     have been added using Body.SetMassFromShapes.
        /// </summary>
        public MassData MassData;

        /// <summary>
        ///     Use this to store application specific body data.
        /// </summary>
        public readonly object UserData;

        /// <summary>
        ///     The world position of the body. Avoid creating bodies at the origin
        ///     since this can lead to many overlapping shapes.
        /// </summary>
        public Vec2 Position;

        /// <summary>
        ///     The world angle of the body in radians.
        /// </summary>
        public readonly float Angle;

        /// The linear velocity of the body in world co-ordinates.
        public Vec2 LinearVelocity;

        // The angular velocity of the body.
        /// <summary>
        ///     The angular velocity
        /// </summary>
        public readonly float AngularVelocity;

        /// <summary>
        ///     Linear damping is use to reduce the linear velocity. The damping parameter
        ///     can be larger than 1.0f but the damping effect becomes sensitive to the
        ///     time step when the damping parameter is large.
        /// </summary>
        public readonly float LinearDamping;

        /// <summary>
        ///     Angular damping is use to reduce the angular velocity. The damping parameter
        ///     can be larger than 1.0f but the damping effect becomes sensitive to the
        ///     time step when the damping parameter is large.
        /// </summary>
        public readonly float AngularDamping;

        /// <summary>
        ///     Set this flag to false if this body should never fall asleep. Note that
        ///     this increases CPU usage.
        /// </summary>
        public readonly bool AllowSleep;

        /// <summary>
        ///     Is this body initially sleeping?
        /// </summary>
        public readonly bool IsSleeping;

        /// <summary>
        ///     Should this body be prevented from rotating? Useful for characters.
        /// </summary>
        public readonly bool FixedRotation;

        /// <summary>
        ///     Is this a fast moving body that should be prevented from tunneling through
        ///     other moving bodies? Note that all bodies are prevented from tunneling through
        ///     static bodies.
        ///     @warning You should use this flag sparingly since it increases processing time.
        /// </summary>
        public readonly bool IsBullet;
    }
}