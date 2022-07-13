// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   MouseJoint.cs
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

// p = attached point, m = mouse point
// C = p - m
// Cdot = v
//      = v + cross(w, r)
// J = [I r_skew]
// Identity used:
// w k % (rx i + ry j) = w * (-ry i + rx j)

using Alis.Aspect.Math;

namespace Alis.Core.Physic.Dynamics.Joints
{
    /// <summary>
    ///     A mouse joint is used to make a point on a body track a
    ///     specified world point. This a soft constraint with a maximum
    ///     force. This allows the constraint to stretch and without
    ///     applying huge forces.
    /// </summary>
    public class MouseJoint : Joint
    {
        /// <summary>
        ///     The target
        /// </summary>
        public Vector2 Target;

        /// <summary>
        ///     Initializes a new instance of the <see cref="MouseJoint" /> class
        /// </summary>
        /// <param name="def">The def</param>
        public MouseJoint(MouseJointDef def)
            : base(def)
        {
            Target = def.Target;
            LocalAnchor = Math.MulT(Body2.GetXForm(), Target);

            MaxForce = def.MaxForce;
            Impulse.SetZero();

            FrequencyHz = def.FrequencyHz;
            DampingRatio = def.DampingRatio;

            Beta = 0.0f;
            Gamma = 0.0f;
        }

        /// <summary>
        ///     The local anchor
        /// </summary>
        public Vector2 LocalAnchor { get; }

        /// <summary>
        ///     The impulse
        /// </summary>
        public Vector2 Impulse { get; set; }

        /// <summary>
        ///     The mass
        /// </summary>
        public Mat22 Mass { get; set; }

        /// <summary>
        ///     The
        /// </summary>
        public Vector2 C { get; set; }

        /// <summary>
        ///     The max force
        /// </summary>
        public float MaxForce { get; }

        /// <summary>
        ///     The frequency hz
        /// </summary>
        public float FrequencyHz { get; }

        /// <summary>
        ///     The damping ratio
        /// </summary>
        public float DampingRatio { get; }

        /// <summary>
        ///     The beta
        /// </summary>
        public float Beta { get; set; }

        /// <summary>
        ///     The gamma
        /// </summary>
        public float Gamma { get; set; }

        /// <summary>
        ///     Gets the value of the anchor 1
        /// </summary>
        public override Vector2 Anchor1 => Target;

        /// <summary>
        ///     Gets the value of the anchor 2
        /// </summary>
        public override Vector2 Anchor2 => Body2.GetWorldPoint(LocalAnchor);

        /// <summary>
        ///     Gets the reaction force using the specified inv dt
        /// </summary>
        /// <param>The inv dt</param>
        /// <param name="invDt"></param>
        /// <returns>The vec</returns>
        public override Vector2 GetReactionForce(float invDt)
        {
            return invDt * Impulse;
        }

        /// <summary>
        ///     Gets the reaction torque using the specified inv dt
        /// </summary>
        /// <param>The inv dt</param>
        /// <param name="invDt"></param>
        /// <returns>The float</returns>
        public override float GetReactionTorque(float invDt)
        {
            return invDt * 0.0f;
        }

        /// <summary>
        ///     Use this to update the target point.
        /// </summary>
        public void SetTarget(Vector2 target)
        {
            if (Body2.IsSleeping())
            {
                Body2.WakeUp();
            }

            Target = target;
        }

        /// <summary>
        ///     Inits the velocity constraints using the specified step
        /// </summary>
        /// <param name="step">The step</param>
        internal override void InitVelocityConstraints(TimeStep step)
        {
            Body body2 = Body2;

            float body2Mass = body2.GetMass();

            // Frequency
            float omega = 2.0f * Settings.Pi * FrequencyHz;

            // Damping coefficient
            float coefficient = 2.0f * body2Mass * DampingRatio * omega;

            // Spring stiffness
            float stiffness = body2Mass * (omega * omega);

            // magic formulas
            // gamma has units of inverse mass.
            // beta has units of inverse time.
            Box2DxDebug.Assert(coefficient + step.Dt * stiffness > Settings.FltEpsilon);
            Gamma = 1.0f / (step.Dt * (coefficient + step.Dt * stiffness));
            Beta = step.Dt * stiffness * Gamma;

            // Compute the effective mass matrix.
            Vector2 effectiveMass = Math.Mul(body2.GetXForm().R, LocalAnchor - body2.GetLocalCenter());

            // K    = [(1/m1 + 1/m2) * eye(2) - skew(r1) * invI1 * skew(r1) - skew(r2) * invI2 * skew(r2)]
            //      = [1/m1+1/m2     0    ] + invI1 * [r1.y*r1.y -r1.x*r1.y] + invI2 * [r1.y*r1.y -r1.x*r1.y]
            //        [    0     1/m1+1/m2]           [-r1.x*r1.y r1.x*r1.x]           [-r1.x*r1.y r1.x*r1.x]
            float invMass = body2.InvMass;
            float invI = body2.InvI;

            Mat22 k1 = new Mat22
            {
                Col1 = new Vector2(invMass, 0.0f),
                Col2 = new Vector2(0.0f, invMass)
            };

            Mat22 k2 = new Mat22
            {
                Col1 = new Vector2(invI * effectiveMass.Y * effectiveMass.Y, -invI * effectiveMass.X * effectiveMass.Y),
                Col2 = new Vector2(-invI * effectiveMass.X * effectiveMass.Y, invI * effectiveMass.X * effectiveMass.X)
            };

            Mat22 k = k1 + k2;
            k.Col1.X += Gamma;
            k.Col2.Y += Gamma;

            Mass = k.GetInverse();

            C = body2.Sweep.C + effectiveMass - Target;

            // Cheat with some damping
            body2.AngularVelocity *= 0.98f;

            // Warm starting.
            Impulse *= step.DtRatio;
            body2.LinearVelocity += invMass * Impulse;
            body2.AngularVelocity += invI * Vector2.Cross(effectiveMass, Impulse);
        }

        /// <summary>
        ///     Solves the velocity constraints using the specified step
        /// </summary>
        /// <param name="step">The step</param>
        internal override void SolveVelocityConstraints(TimeStep step)
        {
            Body b = Body2;

            Vector2 r = Math.Mul(b.GetXForm().R, LocalAnchor - b.GetLocalCenter());

            // Cdot = v + cross(w, r)
            Vector2 cdot = b.LinearVelocity + Vector2.Cross(b.AngularVelocity, r);
            Vector2 impulse = Math.Mul(Mass, -(cdot + Beta * C + Gamma * Impulse));

            Vector2 oldImpulse = Impulse;
            Impulse += impulse;
            float maxImpulse = step.Dt * MaxForce;
            if (Impulse.LengthSquared() > maxImpulse * maxImpulse)
            {
                Impulse *= maxImpulse / Impulse.Length();
            }

            impulse = Impulse - oldImpulse;

            b.LinearVelocity += b.InvMass * impulse;
            b.AngularVelocity += b.InvI * Vector2.Cross(r, impulse);
        }

        /// <summary>
        ///     Describes whether this instance solve position constraints
        /// </summary>
        /// <param name="baumgarte">The baumgarte</param>
        /// <returns>The bool</returns>
        internal override bool SolvePositionConstraints(float baumgarte)
        {
            return true;
        }
    }
}