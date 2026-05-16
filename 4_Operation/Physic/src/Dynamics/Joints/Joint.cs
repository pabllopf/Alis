// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Joint.cs
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

using System;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Physic.Dynamics.Joints
{
    /// <summary>
    ///     The joint class
    /// </summary>
    public abstract class Joint
    {
        /// <summary>
        ///     The joint edge
        /// </summary>
        internal readonly JointEdge EdgeA = new JointEdge();

        /// <summary>
        ///     The joint edge
        /// </summary>
        internal readonly JointEdge EdgeB = new JointEdge();

        /// <summary>
        ///     The breakpoint
        /// </summary>
        private float _breakpoint;

        /// <summary>
        ///     The breakpoint squared
        /// </summary>
        private double _breakpointSquared;

        /// <summary>
        ///     Indicate if this join is enabled or not. Disabling a joint
        ///     means it is still in the simulation, but inactive.
        /// </summary>
        public bool Enabled = true;

        /// <summary>
        ///     The island flag
        /// </summary>
        internal bool IslandFlag;

        /// <summary>
        ///     Set the user data pointer.
        /// </summary>
        /// <value>The data.</value>
        public object Tag;

        /// <summary>
        ///     The world
        /// </summary>
        internal WorldPhysic WorldPhysicInternal;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Joint" /> class
        /// </summary>
        protected Joint()
        {
            Breakpoint = float.MaxValue;

            //Connected bodies should not collide by default
            CollideConnected = false;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Joint" /> class
        /// </summary>
        /// <param name="bodyA">The body</param>
        /// <param name="bodyB">The body</param>
        protected Joint(Body bodyA, Body bodyB) : this()
        {
            //Can't connect a joint to the same body twice.
            BodyA = bodyA;
            BodyB = bodyB;
        }

        /// <summary>
        ///     Constructor for fixed joint
        /// </summary>
        protected Joint(Body body) : this() => BodyA = body;

        /// <summary>
        ///     Get the parent World of this joint. This is null if the joint is not attached.
        /// </summary>
        public WorldPhysic WorldPhysic => WorldPhysicInternal;

        /// <summary>
        ///     Gets or sets the type of the joint.
        /// </summary>
        /// <value>The type of the joint.</value>
        public JointType JointType { get; protected set; }

        /// <summary>
        ///     Get the first body attached to this joint.
        /// </summary>
        public Body BodyA { get; internal set; }

        /// <summary>
        ///     Get the second body attached to this joint.
        /// </summary>
        public Body BodyB { get; internal set; }

        /// <summary>
        ///     Get the anchor point on bodyA in world coordinates.
        ///     On some joints, this value indicate the anchor point within the world.
        /// </summary>
        public abstract Vector2F WorldAnchorA { get; set; }

        /// <summary>
        ///     Get the anchor point on bodyB in world coordinates.
        ///     On some joints, this value indicate the anchor point within the world.
        /// </summary>
        public abstract Vector2F WorldAnchorB { get; set; }

        /// <summary>
        ///     Set this flag to true if the attached bodies should collide.
        /// </summary>
        public bool CollideConnected { get; set; }

        /// <summary>
        ///     The Breakpoint simply indicates the maximum Value the JointError can be before it breaks.
        ///     The default value is float.MaxValue, which means it never breaks.
        /// </summary>
        public float Breakpoint
        {
            get => _breakpoint;
            set
            {
                _breakpoint = value;
                _breakpointSquared = _breakpoint * _breakpoint;
            }
        }

        /// <summary>
        ///     Fires when the joint is broken.
        /// </summary>
        public event Action<Joint, float> Broke;

        /// <summary>
        ///     Get the reaction force on body at the joint anchor in Newtons.
        /// </summary>
        /// <param name="invDt">The inverse delta time.</param>
        public abstract Vector2F GetReactionForce(float invDt);

        /// <summary>
        ///     Get the reaction torque on the body at the joint anchor in N*m.
        /// </summary>
        /// <param name="invDt">The inverse delta time.</param>
        public abstract float GetReactionTorque(float invDt);

        /// <summary>
        ///     Wakes the bodies
        /// </summary>
        protected void WakeBodies()
        {
            if (BodyA != null)
            {
                BodyA.Awake = true;
            }

            if (BodyB != null)
            {
                BodyB.Awake = true;
            }
        }

        /// <summary>
        ///     Return true if the joint is a fixed type.
        /// </summary>
        public bool IsFixedType() => JointType == JointType.FixedRevolute ||
                                     JointType == JointType.FixedDistance ||
                                     JointType == JointType.FixedPrismatic ||
                                     JointType == JointType.FixedLine ||
                                     JointType == JointType.FixedMouse ||
                                     JointType == JointType.FixedAngle ||
                                     JointType == JointType.FixedFriction;

        /// <summary>
        ///     Inits the velocity constraints using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        internal abstract void InitVelocityConstraints(ref SolverData data);

        /// <summary>
        ///     Validates the inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        internal void Validate(float invDt)
        {
            if (!Enabled)
            {
                return;
            }

            float jointErrorSquared = GetReactionForce(invDt).LengthSquared();

            if (Math.Abs(jointErrorSquared) <= _breakpointSquared)
            {
                return;
            }

            Enabled = false;

            if (Broke != null)
            {
                Broke(this, (float) Math.Sqrt(jointErrorSquared));
            }
        }

        /// <summary>
        ///     Solves the velocity constraints using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        internal abstract void SolveVelocityConstraints(ref SolverData data);

        /// <summary>
        ///     Solves the position constraints.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>returns true if the position errors are within tolerance.</returns>
        internal abstract bool SolvePositionConstraints(ref SolverData data);
    }
}