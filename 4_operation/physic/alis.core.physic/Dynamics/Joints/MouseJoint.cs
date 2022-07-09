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

using Alis.Core.Physic.Common;

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
        public Vec2 _target;

        /// <summary>
        ///     Initializes a new instance of the <see cref="MouseJoint" /> class
        /// </summary>
        /// <param name="def">The def</param>
        public MouseJoint(MouseJointDef def)
            : base(def)
        {
            _target = def.Target;
            LocalAnchor = Math.MulT(Body2.GetXForm(), _target);

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
        public Vec2 LocalAnchor { get; }

        /// <summary>
        ///     The impulse
        /// </summary>
        public Vec2 Impulse { get; set; }

        /// <summary>
        ///     The mass
        /// </summary>
        public Mat22 Mass { get; set; }

        /// <summary>
        ///     The
        /// </summary>
        public Vec2 C { get; set; }

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
        public override Vec2 Anchor1 => _target;

        /// <summary>
        ///     Gets the value of the anchor 2
        /// </summary>
        public override Vec2 Anchor2 => Body2.GetWorldPoint(LocalAnchor);

        /// <summary>
        ///     Gets the reaction force using the specified inv dt
        /// </summary>
        /// <param>The inv dt</param>
        /// <param name="inv_dt"></param>
        /// <returns>The vec</returns>
        public override Vec2 GetReactionForce(float inv_dt)
        {
            return inv_dt * Impulse;
        }

        /// <summary>
        ///     Gets the reaction torque using the specified inv dt
        /// </summary>
        /// <param>The inv dt</param>
        /// <param name="inv_dt"></param>
        /// <returns>The float</returns>
        public override float GetReactionTorque(float inv_dt)
        {
            return inv_dt * 0.0f;
        }

        /// <summary>
        ///     Use this to update the target point.
        /// </summary>
        public void SetTarget(Vec2 target)
        {
            if (Body2.IsSleeping())
            {
                Body2.WakeUp();
            }

            _target = target;
        }

        /// <summary>
        ///     Inits the velocity constraints using the specified step
        /// </summary>
        /// <param name="step">The step</param>
        internal override void InitVelocityConstraints(TimeStep step)
        {
            Body b = Body2;

            float mass = b.GetMass();

            // Frequency
            float omega = 2.0f * Settings.Pi * FrequencyHz;

            // Damping coefficient
            float d = 2.0f * mass * DampingRatio * omega;

            // Spring stiffness
            float k = mass * (omega * omega);

            // magic formulas
            // gamma has units of inverse mass.
            // beta has units of inverse time.
            Box2DXDebug.Assert(d + step.Dt * k > Settings.FltEpsilon);
            Gamma = 1.0f / (step.Dt * (d + step.Dt * k));
            Beta = step.Dt * k * Gamma;

            // Compute the effective mass matrix.
            Vec2 r = Math.Mul(b.GetXForm().R, LocalAnchor - b.GetLocalCenter());

            // K    = [(1/m1 + 1/m2) * eye(2) - skew(r1) * invI1 * skew(r1) - skew(r2) * invI2 * skew(r2)]
            //      = [1/m1+1/m2     0    ] + invI1 * [r1.y*r1.y -r1.x*r1.y] + invI2 * [r1.y*r1.y -r1.x*r1.y]
            //        [    0     1/m1+1/m2]           [-r1.x*r1.y r1.x*r1.x]           [-r1.x*r1.y r1.x*r1.x]
            float invMass = b.InvMass;
            float invI = b.InvI;

            Mat22 K1 = new Mat22();
            K1.col1.X = invMass;
            K1.col2.X = 0.0f;
            K1.col1.Y = 0.0f;
            K1.col2.Y = invMass;

            Mat22 K2 = new Mat22();
            K2.col1.X = invI * r.Y * r.Y;
            K2.col2.X = -invI * r.X * r.Y;
            K2.col1.Y = -invI * r.X * r.Y;
            K2.col2.Y = invI * r.X * r.X;

            Mat22 K = K1 + K2;
            K.col1.X += Gamma;
            K.col2.Y += Gamma;

            Mass = K.GetInverse();

            C = b.Sweep.C + r - _target;

            // Cheat with some damping
            b.AngularVelocity *= 0.98f;

            // Warm starting.
            Impulse *= step.DtRatio;
            b.LinearVelocity += invMass * Impulse;
            b.AngularVelocity += invI * Vec2.Cross(r, Impulse);
        }

        /// <summary>
        ///     Solves the velocity constraints using the specified step
        /// </summary>
        /// <param name="step">The step</param>
        internal override void SolveVelocityConstraints(TimeStep step)
        {
            Body b = Body2;

            Vec2 r = Math.Mul(b.GetXForm().R, LocalAnchor - b.GetLocalCenter());

            // Cdot = v + cross(w, r)
            Vec2 Cdot = b.LinearVelocity + Vec2.Cross(b.AngularVelocity, r);
            Vec2 impulse = Math.Mul(Mass, -(Cdot + Beta * C + Gamma * Impulse));

            Vec2 oldImpulse = Impulse;
            Impulse += impulse;
            float maxImpulse = step.Dt * MaxForce;
            if (Impulse.LengthSquared() > maxImpulse * maxImpulse)
            {
                Impulse *= maxImpulse / Impulse.Length();
            }

            impulse = Impulse - oldImpulse;

            b.LinearVelocity += b.InvMass * impulse;
            b.AngularVelocity += b.InvI * Vec2.Cross(r, impulse);
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