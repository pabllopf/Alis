// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DistanceJoint.cs
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

using Alis.Aspect.Logging;
using Alis.Aspect.Math;
using Alis.Aspect.Time;
using Alis.Core.Physic.Dynamics.Body;
using System;

namespace Alis.Core.Physic.Dynamics.Joint
{
    /// <summary>
    ///     A distance joint constrains two points on two bodies
    ///     to remain at a fixed distance from each other. You can view
    ///     this as a massless, rigid rod.
    /// 1-D constrained system
    /// m (v2 - v1) = lambda
    /// v2 + (beta/h) * x1 + gamma * lambda = 0, gamma has units of inverse mass.
    /// x2 = x1 + h * v2
    /// 1-D mass-damper-spring system
    /// m (v2 - v1) + h * d * v2 + h * k * 
    /// C = norm(p2 - p1) - L
    /// u = (p2 - p1) / norm(p2 - p1)
    /// Cdot = dot(u, v2 + cross(w2, r2) - v1 - cross(w1, r1))
    /// J = [-u -cross(r1, u) u cross(r2, u)]
    /// K = J * invM * JT
    ///   = invMass1 + invI1 * cross(r1, u)^2 + invMass2 + invI2 * cross(r2, u)^2
    /// </summary>
    public class DistanceJoint : IJoint
    {
        /// <summary>
        ///     The damping ratio
        /// </summary>
        public readonly float DampingRatio;

        /// <summary>
        ///     The frequency hz
        /// </summary>
        public readonly float FrequencyHz;

        /// <summary>
        ///     The length
        /// </summary>
        private readonly float length;

        /// <summary>
        ///     The bias
        /// </summary>
        public float Bias;

        /// <summary>
        ///     The gamma
        /// </summary>
        public float Gamma;

        /// <summary>
        ///     The impulse
        /// </summary>
        public float Impulse;

        /// <summary>
        ///     The local anchor
        /// </summary>
        public Vector2 LocalAnchor1;

        /// <summary>
        ///     The local anchor
        /// </summary>
        public Vector2 LocalAnchor2;

        /// <summary>
        ///     The mass
        /// </summary>
        public float Mass; // effective mass for the constraint.


        /// <summary>
        ///     The vector
        /// </summary>
        public Vector2 U;

        /// <summary>
        /// The type
        /// </summary>
        private JointType type;
        /// <summary>
        /// The prev
        /// </summary>
        private IJoint prev;
        /// <summary>
        /// The next
        /// </summary>
        private IJoint next;
        /// <summary>
        /// The node
        /// </summary>
        private readonly JointEdge node1;
        /// <summary>
        /// The node
        /// </summary>
        private readonly JointEdge node2;
        /// <summary>
        /// The body
        /// </summary>
        private BodyBase body1;
        /// <summary>
        /// The body
        /// </summary>
        private BodyBase body2;
        /// <summary>
        /// The island flag
        /// </summary>
        private bool islandFlag;
        /// <summary>
        /// The collide connected
        /// </summary>
        private readonly bool collideConnected;
        /// <summary>
        /// The local center
        /// </summary>
        private Vector2 localCenter1;
        /// <summary>
        /// The local center
        /// </summary>
        private Vector2 localCenter2;
        /// <summary>
        /// The inv mass
        /// </summary>
        private float invMass1;
        /// <summary>
        /// The inv
        /// </summary>
        private float invI1;
        /// <summary>
        /// The inv mass
        /// </summary>
        private float invMass2;
        /// <summary>
        /// The inv
        /// </summary>
        private float invI2;
        /// <summary>
        /// The user data
        /// </summary>
        private object userData;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DistanceJoint" /> class
        /// </summary>
        /// <param name="def">The def</param>
        public DistanceJoint(DistanceJointDef def)
        {
            type = def.Type;
            prev = null;
            next = null;
            body1 = def.Body1;
            body2 = def.Body2;
            node1 = new JointEdge();
            node2 = new JointEdge();
            collideConnected = def.CollideConnected;
            islandFlag = false;
            UserData = def.UserData;
            
            LocalAnchor1 = def.LocalAnchor1;
            LocalAnchor2 = def.LocalAnchor2;
            length = def.Length;
            FrequencyHz = def.FrequencyHz;
            DampingRatio = def.DampingRatio;
            Impulse = 0.0f;
            Gamma = 0.0f;
            Bias = 0.0f;
        }

        /// <summary>
        /// Gets or sets the value of the type
        /// </summary>
        JointType IJoint.Type
        {
            get => type;
            set => type = value;
        }

        /// <summary>
        /// Gets or sets the value of the prev
        /// </summary>
        IJoint IJoint.Prev
        {
            get => prev;
            set => prev = value;
        }

        /// <summary>
        /// Gets or sets the value of the next
        /// </summary>
        IJoint IJoint.Next
        {
            get => next;
            set => next = value;
        }

        /// <summary>
        /// Gets the value of the node 1
        /// </summary>
        JointEdge IJoint.Node1 => node1;

        /// <summary>
        /// Gets the value of the node 2
        /// </summary>
        JointEdge IJoint.Node2 => node2;

        /// <summary>
        /// Gets or sets the value of the body 1
        /// </summary>
        BodyBase IJoint.Body1
        {
            get => body1;
            set => body1 = value;
        }

        /// <summary>
        /// Gets or sets the value of the body 2
        /// </summary>
        BodyBase IJoint.Body2
        {
            get => body2;
            set => body2 = value;
        }

        /// <summary>
        /// Gets or sets the value of the island flag
        /// </summary>
        bool IJoint.IslandFlag
        {
            get => islandFlag;
            set => islandFlag = value;
        }

        /// <summary>
        /// Gets the value of the collide connected
        /// </summary>
        bool IJoint.CollideConnected => collideConnected;

        /// <summary>
        /// Gets or sets the value of the local center 1
        /// </summary>
        Vector2 IJoint.LocalCenter1
        {
            get => localCenter1;
            set => localCenter1 = value;
        }

        /// <summary>
        /// Gets or sets the value of the local center 2
        /// </summary>
        Vector2 IJoint.LocalCenter2
        {
            get => localCenter2;
            set => localCenter2 = value;
        }

        /// <summary>
        /// Gets or sets the value of the inv mass 1
        /// </summary>
        float IJoint.InvMass1
        {
            get => invMass1;
            set => invMass1 = value;
        }

        /// <summary>
        /// Gets or sets the value of the inv i 1
        /// </summary>
        float IJoint.InvI1
        {
            get => invI1;
            set => invI1 = value;
        }

        /// <summary>
        /// Gets or sets the value of the inv mass 2
        /// </summary>
        float IJoint.InvMass2
        {
            get => invMass2;
            set => invMass2 = value;
        }

        /// <summary>
        /// Gets or sets the value of the inv i 2
        /// </summary>
        float IJoint.InvI2
        {
            get => invI2;
            set => invI2 = value;
        }

        /// <summary>
        ///     Gets the value of the anchor 1
        /// </summary>
        public Vector2 Anchor1 => body1.GetWorldPoint(LocalAnchor1);

        /// <summary>
        ///     Gets the value of the anchor 2
        /// </summary>
        public Vector2 Anchor2 => body2.GetWorldPoint(LocalAnchor2);

        /// <summary>
        ///    Gets the value user data.
        /// </summary>
        public object UserData
        {
            get => userData;
            set => userData = value;
        }

        /// <summary>
        ///     Gets the reaction force using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The vec</returns>
        public Vector2 GetReactionForce(float invDt) => invDt * Impulse * U;

        /// <summary>
        ///     Gets the reaction torque using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The float</returns>
        public float GetReactionTorque(float invDt) => 0.0f;

        /// <summary>
        ///     Inits the velocity constraints using the specified step
        /// </summary>
        /// <param name="step">The step</param>
        internal void InitVelocityConstraints(TimeStep step)
        {
            BodyBase b1 = body1;
            BodyBase b2 = body2;

            // Compute the effective mass matrix.
            Vector2 r1 = Helper.Mul(b1.GetXForm().R, LocalAnchor1 - b1.GetLocalCenter());
            Vector2 r2 = Helper.Mul(b2.GetXForm().R, LocalAnchor2 - b2.GetLocalCenter());
            U = b2.Sweep.C + r2 - b1.Sweep.C - r1;

            // Handle singularity.
            float length = U.Length();
            if (length > Settings.LinearSlop)
            {
                U *= 1.0f / length;
            }
            else
            {
                U.Set(0.0f, 0.0f);
            }

            float cr1U = Vector2.Cross(r1, U);
            float cr2U = Vector2.Cross(r2, U);
            float invMass = b1.InvMass + b1.InvI * cr1U * cr1U + b2.InvMass + b2.InvI * cr2U * cr2U;
            Box2DxDebug.Assert(invMass > Settings.FltEpsilon);
            Mass = 1.0f / invMass;

            if (FrequencyHz > 0.0f)
            {
                float c = length - this.length;

                // Frequency
                float omega = 2.0f * Settings.Pi * FrequencyHz;

                // Damping coefficient
                float d = 2.0f * Mass * DampingRatio * omega;

                // Spring stiffness
                float k = Mass * omega * omega;

                // magic formulas
                Gamma = 1.0f / (step.Dt * (d + step.Dt * k));
                Bias = c * step.Dt * k * Gamma;

                Mass = 1.0f / (invMass + Gamma);
            }

            if (step.WarmStarting)
            {
                //Scale the inpulse to support a variable timestep.
                Impulse *= step.DtRatio;
                Vector2 p = Impulse * U;
                b1.LinearVelocity -= b1.InvMass * p;
                b1.AngularVelocity -= b1.InvI * Vector2.Cross(r1, p);
                b2.LinearVelocity += b2.InvMass * p;
                b2.AngularVelocity += b2.InvI * Vector2.Cross(r2, p);
            }
            else
            {
                Impulse = 0.0f;
            }
        }

        /// <summary>
        /// Solves the velocity constraints using the specified step
        /// </summary>
        /// <param name="step">The step</param>
        void IJoint.SolveVelocityConstraints(TimeStep step)
        {
            SolveVelocityConstraints(step);
        }

        /// <summary>
        /// Describes whether this instance solve position constraints
        /// </summary>
        /// <param name="baumgarte">The baumgarte</param>
        /// <returns>The bool</returns>
        bool IJoint.SolvePositionConstraints(float baumgarte) => SolvePositionConstraints(baumgarte);

        /// <summary>
        ///     Describes whether this instance solve position constraints
        /// </summary>
        /// <param name="baumgarte">The baumgarte</param>
        /// <returns>The bool</returns>
        internal bool SolvePositionConstraints(float baumgarte)
        {
            if (FrequencyHz > 0.0f)
            {
                //There is no possition correction for soft distace constraint.
                return true;
            }

            BodyBase b1 = body1;
            BodyBase b2 = body2;

            Vector2 r1 = Helper.Mul(b1.GetXForm().R, LocalAnchor1 - b1.GetLocalCenter());
            Vector2 r2 = Helper.Mul(b2.GetXForm().R, LocalAnchor2 - b2.GetLocalCenter());

            Vector2 d = b2.Sweep.C + r2 - b1.Sweep.C - r1;

            float length = d.Normalize();
            float c = length - this.length;
            c = Helper.Clamp(c, -Settings.MaxLinearCorrection, Settings.MaxLinearCorrection);

            float impulse = -Mass * c;
            U = d;
            Vector2 p = impulse * U;

            b1.Sweep.C -= b1.InvMass * p;
            b1.Sweep.A -= b1.InvI * Vector2.Cross(r1, p);
            b2.Sweep.C += b2.InvMass * p;
            b2.Sweep.A += b2.InvI * Vector2.Cross(r2, p);

            b1.SynchronizeTransform();
            b2.SynchronizeTransform();

            return Math.Abs(c) < Settings.LinearSlop;
        }

        /// <summary>
        /// Inits the velocity constraints using the specified step
        /// </summary>
        /// <param name="step">The step</param>
        void IJoint.InitVelocityConstraints(TimeStep step)
        {
            InitVelocityConstraints(step);
        }

        /// <summary>
        ///     Solves the velocity constraints using the specified step
        /// </summary>
        /// <param name="step">The step</param>
        internal void SolveVelocityConstraints(TimeStep step)
        {
            //B2_NOT_USED(step);

            BodyBase b1 = body1;
            BodyBase b2 = body2;

            Vector2 r1 = Helper.Mul(b1.GetXForm().R, LocalAnchor1 - b1.GetLocalCenter());
            Vector2 r2 = Helper.Mul(b2.GetXForm().R, LocalAnchor2 - b2.GetLocalCenter());

            // Cdot = dot(u, v + cross(w, r))
            Vector2 v1 = b1.LinearVelocity + Vector2.Cross(b1.AngularVelocity, r1);
            Vector2 v2 = b2.LinearVelocity + Vector2.Cross(b2.AngularVelocity, r2);
            float cdot = Vector2.Dot(U, v2 - v1);
            float impulse = -Mass * (cdot + Bias + Gamma * Impulse);
            Impulse += impulse;

            Vector2 p = impulse * U;
            b1.LinearVelocity -= b1.InvMass * p;
            b1.AngularVelocity -= b1.InvI * Vector2.Cross(r1, p);
            b2.LinearVelocity += b2.InvMass * p;
            b2.AngularVelocity += b2.InvI * Vector2.Cross(r2, p);
        }
    }
}