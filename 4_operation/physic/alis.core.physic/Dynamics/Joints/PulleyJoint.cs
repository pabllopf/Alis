// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   PulleyJoint.cs
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

// Pulley:
// length1 = norm(p1 - s1)
// length2 = norm(p2 - s2)
// C0 = (length1 + ratio * length2)_initial
// C = C0 - (length1 + ratio * length2) >= 0
// u1 = (p1 - s1) / norm(p1 - s1)
// u2 = (p2 - s2) / norm(p2 - s2)
// Cdot = -dot(u1, v1 + cross(w1, r1)) - ratio * dot(u2, v2 + cross(w2, r2))
// J = -[u1 cross(r1, u1) ratio * u2  ratio * cross(r2, u2)]
// K = J * invM * JT
//   = invMass1 + invI1 * cross(r1, u1)^2 + ratio^2 * (invMass2 + invI2 * cross(r2, u2)^2)
//
// Limit:
// C = maxLength - length
// u = (p - s) / norm(p - s)
// Cdot = -dot(u, v + cross(w, r))
// K = invMass + invI * cross(r, u)^2
// 0 <= impulse

using Alis.Aspect.Logging;
using Alis.Aspect.Math;
using Alis.Aspect.Time;

namespace Alis.Core.Physic.Dynamics.Joints
{
    using Box2DXMath = Math;

    /// <summary>
    ///     The pulley joint is connected to two bodies and two fixed ground points.
    ///     The pulley supports a ratio such that:
    ///     length1 + ratio * length2 constant
    ///     Yes, the force transmitted is scaled by the ratio.
    ///     The pulley also enforces a maximum length limit on both sides. This is
    ///     useful to prevent one side of the pulley hitting the top.
    /// </summary>
    public class PulleyJoint : Joint
    {

        /// <summary>
        ///     The min pulley length
        /// </summary>
        public static float MinPulleyLength { get; } = 2.0f;

        /// <summary>
        ///     The limit state
        /// </summary>
        public LimitState LimitState { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PulleyJoint" /> class
        /// </summary>
        /// <param name="def">The def</param>
        public PulleyJoint(PulleyJointDef def)
            : base(def)
        {
            Ground = Body1.GetWorld().GroundBody;
            GroundAnchor1 = def.GroundAnchor1 - Ground.GetXForm().Position;
            GroundAnchor2 = def.GroundAnchor2 - Ground.GetXForm().Position;
            LocalAnchor1 = def.LocalAnchor1;
            LocalAnchor2 = def.LocalAnchor2;

            Box2DxDebug.Assert(def.Ratio != 0.0f);
            Ratio = def.Ratio;

            Constant = def.Length1 + Ratio * def.Length2;

            MaxLength1 = Math.Min(def.MaxLength1, Constant - Ratio * MinPulleyLength);
            MaxLength2 = Math.Min(def.MaxLength2, (Constant - MinPulleyLength) / Ratio);

            Impulse = 0.0f;
            LimitImpulse1 = 0.0f;
            LimitImpulse2 = 0.0f;
        }

        /// <summary>
        ///     The ground
        /// </summary>
        public Body Ground { get; }

        /// <summary>
        ///     The ground anchor
        /// </summary>
        public Vector2 GroundAnchor1 { get; }

        /// <summary>
        ///     The ground anchor
        /// </summary>
        public Vector2 GroundAnchor2 { get; }

        /// <summary>
        ///     The local anchor
        /// </summary>
        public Vector2 LocalAnchor1 { get; }

        /// <summary>
        ///     The local anchor
        /// </summary>
        public Vector2 LocalAnchor2 { get; }

        /// <summary>
        ///     The
        /// </summary>
        public Vector2 U1 { get; set; }

        /// <summary>
        ///     The
        /// </summary>
        public Vector2 U2 { get; set; }

        /// <summary>
        ///     The constant
        /// </summary>
        public float Constant { get; }

        /// <summary>
        ///     The max length
        /// </summary>
        public float MaxLength1 { get; }

        /// <summary>
        ///     The max length
        /// </summary>
        public float MaxLength2 { get; }

        // Effective masses

        /// <summary>
        ///     The pulley mass
        /// </summary>
        public float PulleyMass { get; set; }

        /// <summary>
        ///     The limit mass
        /// </summary>
        public float LimitMass1 { get; set; }

        /// <summary>
        ///     The limit mass
        /// </summary>
        public float LimitMass2 { get; set; }

        // Impulses for accumulation/warm starting.

        /// <summary>
        ///     The impulse
        /// </summary>
        public float Impulse { get; set; }

        /// <summary>
        ///     The limit impulse
        /// </summary>
        public float LimitImpulse1 { get; set; }

        /// <summary>
        ///     The limit impulse
        /// </summary>
        public float LimitImpulse2 { get; set; }

        /// <summary>
        ///     The state
        /// </summary>
        public LimitState State { get; set; }

        /// <summary>
        ///     Gets the value of the anchor 1
        /// </summary>
        public override Vector2 Anchor1 => Body1.GetWorldPoint(LocalAnchor1);

        /// <summary>
        ///     Gets the value of the anchor 2
        /// </summary>
        public override Vector2 Anchor2 => Body2.GetWorldPoint(LocalAnchor2);

        /// <summary>
        ///     Get the first ground anchor.
        /// </summary>
        public Vector2 GroundAnchorX1 => Ground.GetXForm().Position + GroundAnchor1;

        /// <summary>
        ///     Get the second ground anchor.
        /// </summary>
        public Vector2 GroundAnchorX2 => Ground.GetXForm().Position + GroundAnchor2;

        /// <summary>
        ///     Get the current length of the segment attached to body1.
        /// </summary>
        public float Length1
        {
            get
            {
                Vector2 p = Body1.GetWorldPoint(LocalAnchor1);
                Vector2 s = Ground.GetXForm().Position + GroundAnchor1;
                Vector2 d = p - s;
                return d.Length();
            }
        }

        /// <summary>
        ///     Get the current length of the segment attached to body2.
        /// </summary>
        public float Length2
        {
            get
            {
                Vector2 p = Body2.GetWorldPoint(LocalAnchor2);
                Vector2 s = Ground.GetXForm().Position + GroundAnchor2;
                Vector2 d = p - s;
                return d.Length();
            }
        }

        /// <summary>
        ///     Get the pulley ratio.
        /// </summary>
        public float Ratio { get; set; }

        /// <summary>
        ///     Gets the reaction force using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The vec</returns>
        public override Vector2 GetReactionForce(float invDt)
        {
            Vector2 p = Impulse * U2;
            return invDt * p;
        }

        /// <summary>
        ///     Gets the reaction torque using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The float</returns>
        public override float GetReactionTorque(float invDt)
        {
            return 0.0f;
        }

        /// <summary>
        ///     Inits the velocity constraints using the specified step
        /// </summary>
        /// <param name="step">The step</param>
        internal override void InitVelocityConstraints(TimeStep step)
        {
            Body body1 = Body1;
            Body body2 = Body2;

            Vector2 mulR1 = Box2DXMath.Mul(body1.GetXForm().R, LocalAnchor1 - body1.GetLocalCenter());
            Vector2 mulR2 = Box2DXMath.Mul(body2.GetXForm().R, LocalAnchor2 - body2.GetLocalCenter());

            Vector2 body1SweepC = body1.Sweep.C + mulR1;
            Vector2 body2SweepC = body2.Sweep.C + mulR2;

            Vector2 groundAnchor1 = Ground.GetXForm().Position + GroundAnchor1;
            Vector2 groundAnchor2 = Ground.GetXForm().Position + GroundAnchor2;

            // Get the pulley axes.
            U1 = body1SweepC - groundAnchor1;
            U2 = body2SweepC - groundAnchor2;

            float length1 = U1.Length();
            float length2 = U2.Length();

            if (length1 > Settings.LinearSlop)
            {
                U1 *= 1.0f / length1;
            }
            else
            {
                U1.SetZero();
            }

            if (length2 > Settings.LinearSlop)
            {
                U2 *= 1.0f / length2;
            }
            else
            {
                U2.SetZero();
            }

            float c = Constant - length1 - Ratio * length2;
            if (c > 0.0f)
            {
                State = LimitState.InactiveLimit;
                Impulse = 0.0f;
            }
            else
            {
                State = LimitState.AtUpperLimit;
            }

            if (length1 < MaxLength1)
            {
                LimitState = LimitState.InactiveLimit;
                LimitImpulse1 = 0.0f;
            }
            else
            {
                LimitState = LimitState.AtUpperLimit;
            }

            if (length2 < MaxLength2)
            {
                LimitState = LimitState.InactiveLimit;
                LimitImpulse2 = 0.0f;
            }
            else
            {
                LimitState = LimitState.AtUpperLimit;
            }

            // Compute effective mass.
            float cr1U1 = Vector2.Cross(mulR1, U1);
            float cr2U2 = Vector2.Cross(mulR2, U2);

            LimitMass1 = body1.InvMass + body1.InvI * cr1U1 * cr1U1;
            LimitMass2 = body2.InvMass + body2.InvI * cr2U2 * cr2U2;
            PulleyMass = LimitMass1 + Ratio * Ratio * LimitMass2;
            Box2DxDebug.Assert(LimitMass1 > Settings.FltEpsilon);
            Box2DxDebug.Assert(LimitMass2 > Settings.FltEpsilon);
            Box2DxDebug.Assert(PulleyMass > Settings.FltEpsilon);
            LimitMass1 = 1.0f / LimitMass1;
            LimitMass2 = 1.0f / LimitMass2;
            PulleyMass = 1.0f / PulleyMass;

            if (step.WarmStarting)
            {
                // Scale impulses to support variable time steps.
                Impulse *= step.DtRatio;
                LimitImpulse1 *= step.DtRatio;
                LimitImpulse2 *= step.DtRatio;

                // Warm starting.
                Vector2 p1 = -(Impulse + LimitImpulse1) * U1;
                Vector2 p2 = (-Ratio * Impulse - LimitImpulse2) * U2;
                body1.LinearVelocity += body1.InvMass * p1;
                body1.AngularVelocity += body1.InvI * Vector2.Cross(mulR1, p1);
                body2.LinearVelocity += body2.InvMass * p2;
                body2.AngularVelocity += body2.InvI * Vector2.Cross(mulR2, p2);
            }
            else
            {
                Impulse = 0.0f;
                LimitImpulse1 = 0.0f;
                LimitImpulse2 = 0.0f;
            }
        }

        /// <summary>
        ///     Solves the velocity constraints using the specified step
        /// </summary>
        /// <param name="step">The step</param>
        internal override void SolveVelocityConstraints(TimeStep step)
        {
            Body b1 = Body1;
            Body b2 = Body2;

            Vector2 r1 = Box2DXMath.Mul(b1.GetXForm().R, LocalAnchor1 - b1.GetLocalCenter());
            Vector2 r2 = Box2DXMath.Mul(b2.GetXForm().R, LocalAnchor2 - b2.GetLocalCenter());

            if (State == LimitState.AtUpperLimit)
            {
                Vector2 v1 = b1.LinearVelocity + Vector2.Cross(b1.AngularVelocity, r1);
                Vector2 v2 = b2.LinearVelocity + Vector2.Cross(b2.AngularVelocity, r2);

                float cdot = -Vector2.Dot(U1, v1) - Ratio * Vector2.Dot(U2, v2);
                float impulse = PulleyMass * -cdot;
                float oldImpulse = Impulse;
                Impulse = Box2DXMath.Max(0.0f, Impulse + impulse);
                impulse = Impulse - oldImpulse;

                Vector2 p1 = -impulse * U1;
                Vector2 p2 = -Ratio * impulse * U2;
                b1.LinearVelocity += b1.InvMass * p1;
                b1.AngularVelocity += b1.InvI * Vector2.Cross(r1, p1);
                b2.LinearVelocity += b2.InvMass * p2;
                b2.AngularVelocity += b2.InvI * Vector2.Cross(r2, p2);
            }

            if (LimitState == LimitState.AtUpperLimit)
            {
                Vector2 v1 = b1.LinearVelocity + Vector2.Cross(b1.AngularVelocity, r1);

                float cdot = -Vector2.Dot(U1, v1);
                float impulse = -LimitMass1 * cdot;
                float oldImpulse = LimitImpulse1;
                LimitImpulse1 = Box2DXMath.Max(0.0f, LimitImpulse1 + impulse);
                impulse = LimitImpulse1 - oldImpulse;

                Vector2 p1 = -impulse * U1;
                b1.LinearVelocity += b1.InvMass * p1;
                b1.AngularVelocity += b1.InvI * Vector2.Cross(r1, p1);
            }

            if (LimitState == LimitState.AtUpperLimit)
            {
                Vector2 v2 = b2.LinearVelocity + Vector2.Cross(b2.AngularVelocity, r2);

                float cdot = -Vector2.Dot(U2, v2);
                float impulse = -LimitMass2 * cdot;
                float oldImpulse = LimitImpulse2;
                LimitImpulse2 = Box2DXMath.Max(0.0f, LimitImpulse2 + impulse);
                impulse = LimitImpulse2 - oldImpulse;

                Vector2 p2 = -impulse * U2;
                b2.LinearVelocity += b2.InvMass * p2;
                b2.AngularVelocity += b2.InvI * Vector2.Cross(r2, p2);
            }
        }

        /// <summary>
        ///     Describes whether this instance solve position constraints
        /// </summary>
        /// <param name="baumgarte">The baumgarte</param>
        /// <returns>The bool</returns>
        internal override bool SolvePositionConstraints(float baumgarte)
        {
            Body body1 = Body1;
            Body body2 = Body2;

            Vector2 groundAnchor1 = Ground.GetXForm().Position + GroundAnchor1;
            Vector2 groundAnchor2 = Ground.GetXForm().Position + GroundAnchor2;

            float linearError = 0.0f;

            if (State == LimitState.AtUpperLimit)
            {
                Vector2 mulR1 = Box2DXMath.Mul(body1.GetXForm().R, LocalAnchor1 - body1.GetLocalCenter());
                Vector2 mulR2 = Box2DXMath.Mul(body2.GetXForm().R, LocalAnchor2 - body2.GetLocalCenter());

                Vector2 body1SweepC = body1.Sweep.C + mulR1;
                Vector2 body2SweepC = body2.Sweep.C + mulR2;

                // Get the pulley axes.
                U1 = body1SweepC - groundAnchor1;
                U2 = body2SweepC - groundAnchor2;

                float length1 = U1.Length();
                float length2 = U2.Length();

                if (length1 > Settings.LinearSlop)
                {
                    U1 *= 1.0f / length1;
                }
                else
                {
                    U1.SetZero();
                }

                if (length2 > Settings.LinearSlop)
                {
                    U2 *= 1.0f / length2;
                }
                else
                {
                    U2.SetZero();
                }

                float c = Constant - length1 - Ratio * length2;
                linearError = Box2DXMath.Max(linearError, -c);

                c = Box2DXMath.Clamp(c + Settings.LinearSlop, -Settings.MaxLinearCorrection, 0.0f);
                float impulse = -PulleyMass * c;

                Vector2 p1 = -impulse * U1;
                Vector2 p2 = -Ratio * impulse * U2;

                body1.Sweep.C += body1.InvMass * p1;
                body1.Sweep.A += body1.InvI * Vector2.Cross(mulR1, p1);
                body2.Sweep.C += body2.InvMass * p2;
                body2.Sweep.A += body2.InvI * Vector2.Cross(mulR2, p2);

                body1.SynchronizeTransform();
                body2.SynchronizeTransform();
            }

            if (LimitState == LimitState.AtUpperLimit)
            {
                Vector2 mulR1 = Box2DXMath.Mul(body1.GetXForm().R, LocalAnchor1 - body1.GetLocalCenter());
                Vector2 body1SweepC = body1.Sweep.C + mulR1;

                U1 = body1SweepC - groundAnchor1;
                float length1 = U1.Length();

                if (length1 > Settings.LinearSlop)
                {
                    U1 *= 1.0f / length1;
                }
                else
                {
                    U1.SetZero();
                }

                float c = MaxLength1 - length1;
                linearError = Box2DXMath.Max(linearError, -c);
                c = Box2DXMath.Clamp(c + Settings.LinearSlop, -Settings.MaxLinearCorrection, 0.0f);
                float impulse = -LimitMass1 * c;

                Vector2 p1 = -impulse * U1;
                body1.Sweep.C += body1.InvMass * p1;
                body1.Sweep.A += body1.InvI * Vector2.Cross(mulR1, p1);

                body1.SynchronizeTransform();
            }

            if (LimitState == LimitState.AtUpperLimit)
            {
                Vector2 mulR2 = Box2DXMath.Mul(body2.GetXForm().R, LocalAnchor2 - body2.GetLocalCenter());
                Vector2 body2SweepC = body2.Sweep.C + mulR2;

                U2 = body2SweepC - groundAnchor2;
                float length2 = U2.Length();

                if (length2 > Settings.LinearSlop)
                {
                    U2 *= 1.0f / length2;
                }
                else
                {
                    U2.SetZero();
                }

                float c = MaxLength2 - length2;
                linearError = Box2DXMath.Max(linearError, -c);
                c = Box2DXMath.Clamp(c + Settings.LinearSlop, -Settings.MaxLinearCorrection, 0.0f);
                float impulse = -LimitMass2 * c;

                Vector2 p2 = -impulse * U2;
                body2.Sweep.C += body2.InvMass * p2;
                body2.Sweep.A += body2.InvI * Vector2.Cross(mulR2, p2);

                body2.SynchronizeTransform();
            }

            return linearError < Settings.LinearSlop;
        }
    }
}