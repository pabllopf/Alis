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

// 1-D constrained system
// m (v2 - v1) = lambda
// v2 + (beta/h) * x1 + gamma * lambda = 0, gamma has units of inverse mass.
// x2 = x1 + h * v2

// 1-D mass-damper-spring system
// m (v2 - v1) + h * d * v2 + h * k * 

// C = norm(p2 - p1) - L
// u = (p2 - p1) / norm(p2 - p1)
// Cdot = dot(u, v2 + cross(w2, r2) - v1 - cross(w1, r1))
// J = [-u -cross(r1, u) u cross(r2, u)]
// K = J * invM * JT
//   = invMass1 + invI1 * cross(r1, u)^2 + invMass2 + invI2 * cross(r2, u)^2

using Alis.Aspect.Logging;
using Alis.Aspect.Math;
using Alis.Aspect.Time;

namespace Alis.Core.Physic.Dynamics.Joints
{
    /// <summary>
    ///     A distance joint constrains two points on two bodies
    ///     to remain at a fixed distance from each other. You can view
    ///     this as a massless, rigid rod.
    /// </summary>
    public class DistanceJoint : Joint
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
        ///     Initializes a new instance of the <see cref="DistanceJoint" /> class
        /// </summary>
        /// <param name="def">The def</param>
        public DistanceJoint(DistanceJointDef def)
            : base(def)
        {
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
        ///     Gets the value of the anchor 1
        /// </summary>
        public override Vector2 Anchor1 => Body1.GetWorldPoint(LocalAnchor1);

        /// <summary>
        ///     Gets the value of the anchor 2
        /// </summary>
        public override Vector2 Anchor2 => Body2.GetWorldPoint(LocalAnchor2);

        /// <summary>
        ///     Gets the reaction force using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The vec</returns>
        public override Vector2 GetReactionForce(float invDt) => invDt * Impulse * U;

        /// <summary>
        ///     Gets the reaction torque using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The float</returns>
        public override float GetReactionTorque(float invDt) => 0.0f;

        /// <summary>
        ///     Inits the velocity constraints using the specified step
        /// </summary>
        /// <param name="step">The step</param>
        internal override void InitVelocityConstraints(TimeStep step)
        {
            Body b1 = Body1;
            Body b2 = Body2;

            // Compute the effective mass matrix.
            Vector2 r1 = Math.Mul(b1.GetXForm().R, LocalAnchor1 - b1.GetLocalCenter());
            Vector2 r2 = Math.Mul(b2.GetXForm().R, LocalAnchor2 - b2.GetLocalCenter());
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
        ///     Describes whether this instance solve position constraints
        /// </summary>
        /// <param name="baumgarte">The baumgarte</param>
        /// <returns>The bool</returns>
        internal override bool SolvePositionConstraints(float baumgarte)
        {
            if (FrequencyHz > 0.0f)
            {
                //There is no possition correction for soft distace constraint.
                return true;
            }

            Body b1 = Body1;
            Body b2 = Body2;

            Vector2 r1 = Math.Mul(b1.GetXForm().R, LocalAnchor1 - b1.GetLocalCenter());
            Vector2 r2 = Math.Mul(b2.GetXForm().R, LocalAnchor2 - b2.GetLocalCenter());

            Vector2 d = b2.Sweep.C + r2 - b1.Sweep.C - r1;

            float length = d.Normalize();
            float c = length - this.length;
            c = Math.Clamp(c, -Settings.MaxLinearCorrection, Settings.MaxLinearCorrection);

            float impulse = -Mass * c;
            U = d;
            Vector2 p = impulse * U;

            b1.Sweep.C -= b1.InvMass * p;
            b1.Sweep.A -= b1.InvI * Vector2.Cross(r1, p);
            b2.Sweep.C += b2.InvMass * p;
            b2.Sweep.A += b2.InvI * Vector2.Cross(r2, p);

            b1.SynchronizeTransform();
            b2.SynchronizeTransform();

            return System.Math.Abs(c) < Settings.LinearSlop;
        }

        /// <summary>
        ///     Solves the velocity constraints using the specified step
        /// </summary>
        /// <param name="step">The step</param>
        internal override void SolveVelocityConstraints(TimeStep step)
        {
            //B2_NOT_USED(step);

            Body b1 = Body1;
            Body b2 = Body2;

            Vector2 r1 = Math.Mul(b1.GetXForm().R, LocalAnchor1 - b1.GetLocalCenter());
            Vector2 r2 = Math.Mul(b2.GetXForm().R, LocalAnchor2 - b2.GetLocalCenter());

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