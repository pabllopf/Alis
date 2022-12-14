// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Joint.cs
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

using System;
using System.Diagnostics;
using System.Numerics;
using Alis.Core.Physic.Definitions.Joints;
using Alis.Core.Physic.Dynamics.Joints.Misc;
using Alis.Core.Physic.Dynamics.Solver;

namespace Alis.Core.Physic.Dynamics.Joints
{
    /// <summary>
    ///     The joint class
    /// </summary>
    public abstract class Joint
    {
        /// <summary>
        ///     The joint type
        /// </summary>
        private readonly JointType jointType;

        /// <summary>Indicate if this join is enabled or not. Disabling a joint means it is still in the simulation, but inactive.</summary>
        private Body bodyA;

        /// <summary>
        ///     The body
        /// </summary>
        private Body bodyB;

        /// <summary>
        ///     The breakpoint
        /// </summary>
        private float breakpoint;

        /// <summary>
        ///     The collide connected
        /// </summary>
        private bool collideConnected;

        /// <summary>
        ///     The enabled
        /// </summary>
        private bool enabled;

        /// <summary>
        ///     The user data
        /// </summary>
        private object userData;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Joint" /> class
        /// </summary>
        /// <param name="jointType">The joint type</param>
        protected Joint(JointType jointType)
        {
            this.jointType = jointType;
            breakpoint = float.MaxValue;

            //Connected bodies should not collide by default
            collideConnected = false;
            Enabled = true;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Joint" /> class
        /// </summary>
        /// <param name="bodyA">The body</param>
        /// <param name="bodyB">The body</param>
        /// <param name="jointType">The joint type</param>
        protected Joint(Body bodyA, Body bodyB, JointType jointType) : this(jointType)
        {
            //Can't connect a joint to the same body twice.
            Debug.Assert(bodyA != bodyB);

            BodyA = bodyA;
            BodyB = bodyB;
        }

        /// <summary>Constructor for fixed joint</summary>
        protected Joint(Body body, JointType jointType) : this(jointType) => BodyA = body;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Joint" /> class
        /// </summary>
        /// <param name="def">The def</param>
        protected Joint(JointDef def) : this(def.Type)
        {
            Debug.Assert(def.BodyA != def.BodyB);

            jointType = def.Type;
            BodyA = def.BodyA;
            BodyB = def.BodyB;
            collideConnected = def.CollideConnected;
            IslandFlag = false;
            userData = def.UserData;
        }

        /// <summary>
        ///     The joint edge
        /// </summary>
        internal JointEdge EdgeA { get; } = new JointEdge();

        /// <summary>
        ///     The joint edge
        /// </summary>
        internal JointEdge EdgeB { get; } = new JointEdge();

        /// <summary>
        ///     The island flag
        /// </summary>
        internal bool IslandFlag { get; set; }

        /// <summary>Gets or sets the type of the joint.</summary>
        /// <value>The type of the joint.</value>
        public JointType JointType => jointType;

        /// <summary>
        ///     Gets or sets the value of the enabled
        /// </summary>
        public bool Enabled
        {
            get => enabled;
            set => enabled = value;
        }

        /// <summary>Get the first body attached to this joint.</summary>
        public Body BodyA
        {
            get => bodyA;
            set => bodyA = value;
        }

        /// <summary>Get the second body attached to this joint.</summary>
        public Body BodyB
        {
            get => bodyB;
            set => bodyB = value;
        }

        /// <summary>
        ///     Get the anchor point on bodyA in world coordinates. On some joints, this value indicate the anchor point
        ///     within the world.
        /// </summary>
        public abstract Vector2 WorldAnchorA { get; set; }

        /// <summary>
        ///     Get the anchor point on bodyB in world coordinates. On some joints, this value indicate the anchor point
        ///     within the world.
        /// </summary>
        public abstract Vector2 WorldAnchorB { get; set; }

        /// <summary>Set the user data pointer.</summary>
        /// <value>The data.</value>
        public object UserData
        {
            get => userData;
            set => userData = value;
        }

        /// <summary>Set this flag to true if the attached bodies should collide.</summary>
        public bool CollideConnected
        {
            get => collideConnected;
            set => collideConnected = value;
        }

        /// <summary>
        ///     The Breakpoint simply indicates the maximum Value the JointError can be before it breaks. The default value is
        ///     float.MaxValue, which means it never breaks.
        /// </summary>
        public float Breakpoint
        {
            get => breakpoint;
            set => breakpoint = value;
        }

        /// <summary>Fires when the joint is broken.</summary>
        public event Action<Joint, float> Broke;

        /// <summary>Get the reaction force on body at the joint anchor in Newtons.</summary>
        /// <param name="invDt">The inverse delta time.</param>
        public abstract Vector2 GetReactionForce(float invDt);

        /// <summary>Get the reaction torque on the body at the joint anchor in N*m.</summary>
        /// <param name="invDt">The inverse delta time.</param>
        public abstract float GetReactionTorque(float invDt);

        /// <summary>
        ///     Shift the origin for any points stored in world coordinates.
        /// </summary>
        public virtual void ShiftOrigin(ref Vector2 newOrigin)
        {
        }

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

        /// <summary>Return true if the joint is a fixed type.</summary>
        public bool IsFixedType() =>
            JointType == JointType.FixedRevolute ||
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

            if (Math.Abs(jointErrorSquared) <= breakpoint * breakpoint)
            {
                return;
            }

            Enabled = false;

            Broke?.Invoke(this, (float) Math.Sqrt(jointErrorSquared));
        }

        /// <summary>
        ///     Solves the velocity constraints using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        internal abstract void SolveVelocityConstraints(ref SolverData data);

        /// <summary>Solves the position constraints.</summary>
        /// <param name="data"></param>
        /// <returns>returns true if the position errors are within tolerance.</returns>
        internal abstract bool SolvePositionConstraints(ref SolverData data);

        /// <summary>
        ///     Creates the def
        /// </summary>
        /// <param name="def">The def</param>
        /// <returns>The joint</returns>
        public static Joint Create(JointDef def)
        {
            switch (def.Type)
            {
                case JointType.Distance:
                    return new DistanceJoint((DistanceJointDef) def);
                case JointType.FixedMouse:
                    return new FixedMouseJoint((FixedMouseJointDef) def);
                case JointType.Prismatic:
                    return new PrismaticJoint((PrismaticJointDef) def);
                case JointType.Revolute:
                    return new RevoluteJoint((RevoluteJointDef) def);
                case JointType.Pulley:
                    return new PulleyJoint((PulleyJointDef) def);
                case JointType.Gear:
                    return new GearJoint((GearJointDef) def);
                case JointType.Wheel:
                    return new WheelJoint((WheelJointDef) def);
                case JointType.Weld:
                    return new WeldJoint((WeldJointDef) def);
                case JointType.Friction:
                    return new FrictionJoint((FrictionJointDef) def);
                case JointType.Motor:
                    return new MotorJoint((MotorJointDef) def);
                default:
                    Debug.Assert(false);
                    break;
            }

            return null;
        }
    }
}