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
using System.Numerics;
using System.Runtime.CompilerServices;
using Alis.Core.Physics2D.Common;
using Alis.Core.Physics2D.Dynamics.Bodies;
using Alis.Core.Physics2D.Dynamics.Joints.Distance;
using Alis.Core.Physics2D.Dynamics.Joints.Friction;
using Alis.Core.Physics2D.Dynamics.Joints.Gear;
using Alis.Core.Physics2D.Dynamics.Joints.Mouse;
using Alis.Core.Physics2D.Dynamics.Joints.Prismatic;
using Alis.Core.Physics2D.Dynamics.Joints.Pulley;
using Alis.Core.Physics2D.Dynamics.Joints.Revolute;
using Alis.Core.Physics2D.Dynamics.Joints.Weld;
using Alis.Core.Physics2D.Dynamics.Joints.Wheel;
using Alis.Core.Physics2D.Dynamics.World;
using Alis.Core.Physics2D.Dynamics.World.Callbacks;

namespace Alis.Core.Physics2D.Dynamics.Joints
{
    /// <summary>
    ///     The base joint class. Joints are used to constraint two bodies together in
    ///     various fashions. Some joints also feature limits and motors.
    /// </summary>
    public abstract class Joint
    {
        /// <summary>
        /// The collideconnected
        /// </summary>
        internal readonly bool m_collideConnected;
        /// <summary>
        /// The joint edge
        /// </summary>
        internal readonly JointEdge m_edgeA = new JointEdge();
        /// <summary>
        /// The joint edge
        /// </summary>
        internal readonly JointEdge m_edgeB = new JointEdge();
        /// <summary>
        /// The bodya
        /// </summary>
        internal Body m_bodyA;
        /// <summary>
        /// The bodyb
        /// </summary>
        internal Body m_bodyB;
        /// <summary>
        /// The invi1
        /// </summary>
        protected float m_invMass1, m_invI1;
        /// <summary>
        /// The invi2
        /// </summary>
        protected float m_invMass2, m_invI2;

        /// <summary>
        /// The islandflag
        /// </summary>
        internal bool m_islandFlag;

        // Cache here per time step to reduce cache misses.
        /// <summary>
        /// The localcenter2
        /// </summary>
        protected Vector2 m_localCenter1, m_localCenter2;
        /// <summary>
        /// The next
        /// </summary>
        internal Joint m_next;
        /// <summary>
        /// The prev
        /// </summary>
        internal Joint m_prev;

        /// <summary>
        /// Initializes a new instance of the <see cref="Joint"/> class
        /// </summary>
        /// <param name="def">The def</param>
        protected Joint(JointDef def)
        {
            m_prev = null;
            m_next = null;
            m_bodyA = def.bodyA;
            m_bodyB = def.bodyB;
            m_collideConnected = def.collideConnected;
            m_islandFlag = false;
            UserData = def.UserData;
        }

        /// <summary>
        ///     Get the anchor point on body1 in world coordinates.
        /// </summary>
        /// <returns></returns>
        public abstract Vector2 GetAnchorA { get; }

        /// <summary>
        ///     Get the anchor point on body2 in world coordinates.
        /// </summary>
        /// <returns></returns>
        public abstract Vector2 GetAnchorB { get; }

        /// <summary>
        ///     Get/Set the user data pointer.
        /// </summary>
        /// <returns></returns>
        public object UserData
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set;
        }

        /// <summary>
        /// Linears the stiffness using the specified stiffness
        /// </summary>
        /// <param name="stiffness">The stiffness</param>
        /// <param name="damping">The damping</param>
        /// <param name="frequencyHz">The frequency hz</param>
        /// <param name="dampingRatio">The damping ratio</param>
        /// <param name="bodyA">The body</param>
        /// <param name="bodyB">The body</param>
        public static void LinearStiffness(
            out float stiffness,
            out float damping,
            in float frequencyHz,
            in float dampingRatio,
            in Body bodyA,
            in Body bodyB)
        {
            float massA = bodyA.GetMass();
            float massB = bodyB.GetMass();
            float mass;

            if (massA > 0.0f && massB > 0.0f)
            {
                mass = massA * massB / (massA + massB);
            }
            else if (massA > 0.0f)
            {
                mass = massA;
            }
            else
            {
                mass = massB;
            }

            float omega = 2.0f * Settings.Pi * frequencyHz;
            stiffness = mass * omega * omega;
            damping = 2.0f * mass * dampingRatio * omega;
        }

        /// <summary>
        /// Angulars the stiffness using the specified stiffness
        /// </summary>
        /// <param name="stiffness">The stiffness</param>
        /// <param name="damping">The damping</param>
        /// <param name="frequencyHz">The frequency hz</param>
        /// <param name="dampingRatio">The damping ratio</param>
        /// <param name="bodyA">The body</param>
        /// <param name="bodyB">The body</param>
        public static void AngularStiffness(
            out float stiffness,
            out float damping,
            in float frequencyHz,
            in float dampingRatio,
            in Body bodyA,
            in Body bodyB)
        {
            float IA = bodyA.GetInertia();
            float IB = bodyB.GetInertia();
            float I;

            if (IA > 0.0f && IB > 0.0f)
            {
                I = IA * IB / (IA + IB);
            }
            else if (IA > 0.0f)
            {
                I = IA;
            }
            else
            {
                I = IB;
            }

            float omega = 2.0f * Settings.Pi * frequencyHz;
            stiffness = I * omega * omega;
            damping = 2.0f * I * dampingRatio * omega;
        }

        /// <summary>
        ///     Get the first body attached to this joint.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Body GetBodyA() => m_bodyA;

        /// <summary>
        ///     Get the second body attached to this joint.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Body GetBodyB() => m_bodyB;

        /// <summary>
        ///     Get the reaction force on body2 at the joint anchor.
        /// </summary>
        public abstract Vector2 GetReactionForce(float inv_dt);

        /// <summary>
        ///     Get the reaction torque on body2.
        /// </summary>
        public abstract float GetReactionTorque(float inv_dt);

        /// <summary>
        ///     Get the next joint the world joint list.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Joint GetNext() => m_next;

        /// <summary>
        /// Creates the def
        /// </summary>
        /// <param name="def">The def</param>
        /// <exception cref="NotImplementedException">JointDef '{def.GetType().Name}' is not implemented.</exception>
        /// <returns>The joint</returns>
        internal static Joint Create(JointDef def)
        {
            return def switch
            {
                DistanceJointDef d => new DistanceJoint(d),
                MouseJointDef d => new MouseJoint(d),
                PrismaticJointDef d => new PrismaticJoint(d),
                RevoluteJointDef d => new RevoluteJoint(d),
                PulleyJointDef d => new PulleyJoint(d),
                GearJointDef d => new GearJoint(d),
                WheelJointDef d => new WheelJoint(d),
                WeldJointDef d => new WeldJoint(d),
                FrictionJointDef d => new FrictionJoint(d),
                _ => throw new NotImplementedException($"JointDef '{def.GetType().Name}' is not implemented.")
            };
        }

        /// <summary>
        /// Inits the velocity constraints using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        internal abstract void InitVelocityConstraints(in SolverData data);
        /// <summary>
        /// Solves the velocity constraints using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        internal abstract void SolveVelocityConstraints(in SolverData data);

        // This returns true if the position errors are within tolerance.
        /// <summary>
        /// Describes whether this instance solve position constraints
        /// </summary>
        /// <param name="data">The data</param>
        /// <returns>The bool</returns>
        internal abstract bool SolvePositionConstraints(in SolverData data);

        /// <summary>
        /// Computes the x form using the specified xf
        /// </summary>
        /// <param name="xf">The xf</param>
        /// <param name="center">The center</param>
        /// <param name="localCenter">The local center</param>
        /// <param name="angle">The angle</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void ComputeXForm(ref Transform xf, Vector2 center, Vector2 localCenter, float angle)
        {
            xf.q = Matrex.CreateRotation(angle); // Actually about twice as fast to use our own function
            xf.p = center - Vector2.Transform(localCenter, xf.q); // Math.Mul(xf.q, localCenter);
        }

        /// <summary>
        /// Draws the draw
        /// </summary>
        /// <param name="draw">The draw</param>
        public void Draw(DebugDraw draw)
        {
            Transform xf1 = m_bodyA.GetTransform();
            Transform xf2 = m_bodyB.GetTransform();
            Vector2 x1 = xf1.p;
            Vector2 x2 = xf2.p;
            Vector2 p1 = GetAnchorA;
            Vector2 p2 = GetAnchorB;

            Color color = new Color(0.5f, 0.8f, 0.8f);

            switch (this)
            {
                case DistanceJoint j:
                    draw.DrawSegment(p1, p2, color);
                    break;
                case PulleyJoint pulley:
                {
                    Vector2 s1 = pulley.GroundAnchorA;
                    Vector2 s2 = pulley.GroundAnchorB;
                    draw.DrawSegment(s1, p1, color);
                    draw.DrawSegment(s2, p2, color);
                    draw.DrawSegment(s1, s2, color);
                }
                    break;

                case MouseJoint j:
                {
                    Color c = new Color();
                    c.Set(0.0f, 1.0f, 0.0f);
                    draw.DrawPoint(p1, 4.0f, c);
                    draw.DrawPoint(p2, 4.0f, c);

                    c.Set(0.8f, 0.8f, 0.8f);
                    draw.DrawSegment(p1, p2, c);
                }
                    break;

                default:
                    draw.DrawSegment(x1, p1, color);
                    draw.DrawSegment(p1, p2, color);
                    draw.DrawSegment(x2, p2, color);
                    break;
            }
        }
    }
}