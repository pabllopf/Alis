// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FixedMouseJoint.cs
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

using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Aspect.Math.Util;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Dynamics.Solver;

namespace Alis.Core.Physic.Dynamics.Joints
{
    /// <summary>
    ///     A mouse joint is used to make a point on a body track a specified world point. This a soft constraint with a
    ///     maximum force. This allows the constraint to stretch and without applying huge forces. NOTE: this joint is not
    ///     documented in the manual because it was developed to be used in the testbed. If you want to learn how to use the
    ///     mouse
    ///     joint, look at the testbed.
    ///     p = attached point, m = mouse point
    ///     C = p - m
    ///     cDot = v
    ///     = v + cross(w, r)
    ///     J = [I r_skew]
    ///     Identity used:
    ///     w k % (rx i + ry j) = w * (-ry i + rx j)
    /// </summary>
    public class FixedMouseJoint : Joint
    {
        /// <summary>
        ///     The beta
        /// </summary>
        private float beta;
        
        /// <summary>
        ///     The
        /// </summary>
        private Vector2 c;
        
        /// <summary>
        ///     The gamma
        /// </summary>
        private float gamma;
        
        // Solver shared
        /// <summary>
        ///     The impulse
        /// </summary>
        private Vector2 impulse;
        
        // Solver temp
        /// <summary>
        ///     The index
        /// </summary>
        private int indexA;
        
        /// <summary>
        ///     The inv ia
        /// </summary>
        private float invIa;
        
        /// <summary>
        ///     The inv mass
        /// </summary>
        private float invMassA;
        
        /// <summary>
        ///     The local center
        /// </summary>
        private Vector2 localCenterA;
        
        /// <summary>
        ///     The mass
        /// </summary>
        private Matrix2X2 mass;
        
        /// <summary>
        ///     The
        /// </summary>
        private Vector2 rA;
        
        /// <summary>
        ///     The target
        /// </summary>
        private Vector2 targetB;
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="FixedMouseJoint" /> class
        /// </summary>
        /// <param name="bodyA">The body</param>
        /// <param name="bodyB">The body</param>
        /// <param name="jointType">The joint type</param>
        /// <param name="collideConnected">The collide connected</param>
        /// <param name="target">The target</param>
        /// <param name="maxForce">The max force</param>
        /// <param name="stiffness">The stiffness</param>
        /// <param name="damping">The damping</param>
        public FixedMouseJoint(
            Body bodyA = null,
            Body bodyB = null,
            JointType jointType = JointType.FixedMouse,
            bool collideConnected = false,
            Vector2 target = default(Vector2),
            float maxForce = 0.0f,
            float stiffness = 0.0f,
            float damping = 0.0f
        ) : base(bodyA, bodyB, jointType, collideConnected)
        {
            targetB = target;
            LocalAnchorA = MathUtils.MulT(BodyB.Xf, targetB);
            Force = maxForce;
            Stiffness = stiffness;
            Damping = damping;
        }
        
        /// <summary>This requires a world target point, tuning parameters, and the time step.</summary>
        /// <param name="body">The body.</param>
        /// <param name="target">The target.</param>
        public FixedMouseJoint(Body body, Vector2 target)
            : base(body, JointType.FixedMouse)
        {
            targetB = target;
            LocalAnchorA = MathUtils.MulT(BodyA.Xf, targetB);
        }
        
        /// <summary>The local anchor point on BodyB</summary>
        internal Vector2 LocalAnchorA { get; set; }
        
        /// <summary>Use this to update the target point.</summary>
        public override Vector2 WorldAnchorA
        {
            get => BodyA.GetWorldPoint(LocalAnchorA);
            set => LocalAnchorA = BodyA.GetLocalPoint(value);
        }
        
        /// <summary>
        ///     Gets or sets the value of the world anchor b
        /// </summary>
        public override Vector2 WorldAnchorB
        {
            get => targetB;
            set
            {
                if (targetB != value)
                {
                    BodyA.Awake = true;
                    targetB = value;
                }
            }
        }
        
        /// <summary>
        ///     The maximum constraint force that can be exerted to move the candidate body. Usually you will express as some
        ///     multiple of the weight (multiplier * mass * gravity). Set/get the maximum force in Newtons.
        /// </summary>
        private float Force { get; }
        
        /// <summary>Set/get the linear stiffness in N/m</summary>
        private float Stiffness { get; }
        
        /// <summary>Set/get linear damping in N*s/m</summary>
        private float Damping { get; }
        
        /// <summary>
        ///     Shifts the origin using the specified new origin
        /// </summary>
        /// <param name="newOrigin">The new origin</param>
        public override void ShiftOrigin(ref Vector2 newOrigin)
        {
            targetB -= newOrigin;
        }
        
        /// <summary>
        ///     Gets the reaction force using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The vector</returns>
        protected override Vector2 GetReactionForce(float invDt) => invDt * impulse;
        
        /// <summary>
        ///     Gets the reaction torque using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The float</returns>
        public override float GetReactionTorque(float invDt) => 0.0f;
        
        /// <summary>
        ///     Inits the velocity constraints using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        internal override void InitVelocityConstraints(ref SolverData data)
        {
            indexA = BodyA.IslandIndex;
            localCenterA = BodyA.Sweep.LocalCenter;
            invMassA = BodyA.InvMass;
            invIa = BodyA.InvI;
            
            Vector2 cA = data.Positions[indexA].C;
            float aA = data.Positions[indexA].A;
            Vector2 vA = data.Velocities[indexA].V;
            float wA = data.Velocities[indexA].W;
            
            Rotation qA = new Rotation(aA);
            
            float d = Damping;
            float k = Stiffness;
            
            // magic formulas
            // gamma has units of inverse mass.
            // beta has units of inverse time.
            float h = data.Step.DeltaTime;
            gamma = h * (d + h * k);
            if (gamma != 0.0f)
            {
                gamma = 1.0f / gamma;
            }
            
            beta = h * k * gamma;
            
            // Compute the effective mass matrix.
            rA = MathUtils.Mul(qA, LocalAnchorA - localCenterA);
            
            // K    = [(1/m1 + 1/m2) * eye(2) - skew(r1) * invI1 * skew(r1) - skew(r2) * invI2 * skew(r2)]
            //      = [1/m1+1/m2     0    ] + invI1 * [r1.y*r1.y -r1.x*r1.y] + invI2 * [r1.y*r1.y -r1.x*r1.y]
            //        [    0     1/m1+1/m2]           [-r1.x*r1.y r1.x*r1.x]           [-r1.x*r1.y r1.x*r1.x]
            Matrix2X2 kk = new Matrix2X2(
                invMassA + invIa * rA.Y * rA.Y + gamma,
                -invIa * rA.X * rA.Y,
                -invIa * rA.X * rA.Y,
                invMassA + invIa * rA.X * rA.X + gamma
            );
            
            mass = kk.Inverse;
            
            c = cA + rA - targetB;
            c *= beta;
            
            // Cheat with some damping
            wA *= 0.98f;
            
            if (data.Step.WarmStarting)
            {
                impulse *= data.Step.DeltaTimeRatio;
                vA += invMassA * impulse;
                wA += invIa * MathUtils.Cross(rA, impulse);
            }
            else
            {
                impulse = Vector2.Zero;
            }
            
            data.Velocities[indexA].V = vA;
            data.Velocities[indexA].W = wA;
        }
        
        /// <summary>
        ///     Solves the velocity constraints using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        internal override void SolveVelocityConstraints(ref SolverData data)
        {
            Vector2 vA = data.Velocities[indexA].V;
            float wA = data.Velocities[indexA].W;
            
            // cDot = v + cross(w, r)
            Vector2 cDot = vA + MathUtils.Cross(wA, rA);
            Vector2 impulseLocal = MathUtils.Mul(ref mass, -(cDot + c + gamma * impulse));
            
            Vector2 oldImpulse = impulse;
            impulse += impulseLocal;
            float maxImpulse = data.Step.DeltaTime * Force;
            if (impulse.LengthSquared() > maxImpulse * maxImpulse)
            {
                impulse *= maxImpulse / impulse.Length();
            }
            
            impulseLocal = impulse - oldImpulse;
            
            vA += invMassA * impulseLocal;
            wA += invIa * MathUtils.Cross(rA, impulseLocal);
            
            data.Velocities[indexA].V = vA;
            data.Velocities[indexA].W = wA;
        }
        
        /// <summary>
        ///     Describes whether this instance solve position constraints
        /// </summary>
        /// <param name="data">The data</param>
        /// <returns>The bool</returns>
        internal override bool SolvePositionConstraints(ref SolverData data) => true;
    }
}