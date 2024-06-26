// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PulleyJoint.cs
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
using System.Diagnostics.CodeAnalysis;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Config;
using Alis.Core.Physic.Dynamics.Solver;

namespace Alis.Core.Physic.Dynamics.Joints
{
    /// <summary>
    ///     The pulley joint is connected to two bodies and two fixed world points. The pulley supports a ratio such that:
    ///     <![CDATA[length1 + ratio * length2 <= constant]]>
    ///     Yes, the force transmitted is scaled by the ratio. Warning: the pulley joint can get a bit squirrelly by itself.
    ///     They
    ///     often work better when combined with prismatic joints. You should also cover the the anchor points with static
    ///     shapes
    ///     to prevent one side from going to zero length.
    ///     Pulley:
    ///     length1 = norm(p1 - s1)
    ///     length2 = norm(p2 - s2)
    ///     C0 = (length1 + ratio * length2)_initial
    ///     C = C0 - (length1 + ratio * length2)
    ///     u1 = (p1 - s1) / norm(p1 - s1)
    ///     u2 = (p2 - s2) / norm(p2 - s2)
    ///     cDot = -dot(u1, v1 + cross(w1, r1)) - ratio * dot(u2, v2 + cross(w2, r2))
    ///     J = -[u1 cross(r1, u1) ratio * u2  ratio * cross(r2, u2)]
    ///     K = J * invM * JT
    ///     = invMass1 + invI1 * cross(r1, u1)^2 + ratio^2 * (invMass2 + invI2 * cross(r2, u2)^2)
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class PulleyJoint : Joint
    {
        /// <summary>
        ///     The constant
        /// </summary>
        private readonly float constant;
        
        /// <summary>
        ///     The impulse
        /// </summary>
        private float impulse;
        
        // Solver temp
        /// <summary>
        ///     The index
        /// </summary>
        private int indexA;
        
        /// <summary>
        ///     The index
        /// </summary>
        private int indexB;
        
        /// <summary>
        ///     The inv ia
        /// </summary>
        private float invIa;
        
        /// <summary>
        ///     The inv ib
        /// </summary>
        private float invIb;
        
        /// <summary>
        ///     The inv mass
        /// </summary>
        private float invMassA;
        
        /// <summary>
        ///     The inv mass
        /// </summary>
        private float invMassB;
        
        /// <summary>
        ///     The length
        /// </summary>
        private float lengthA;
        
        /// <summary>
        ///     The length
        /// </summary>
        private float lengthB;
        
        // Solver shared
        /// <summary>
        ///     The local anchor
        /// </summary>
        private Vector2 localAnchorA;
        
        /// <summary>
        ///     The local anchor
        /// </summary>
        private Vector2 localAnchorB;
        
        /// <summary>
        ///     The local center
        /// </summary>
        private Vector2 localCenterA;
        
        /// <summary>
        ///     The local center
        /// </summary>
        private Vector2 localCenterB;
        
        /// <summary>
        ///     The mass
        /// </summary>
        private float mass;
        
        /// <summary>
        ///     The
        /// </summary>
        private Vector2 rA;
        
        /// <summary>
        ///     The ratio
        /// </summary>
        private float ratio;
        
        /// <summary>
        ///     The
        /// </summary>
        private Vector2 rB;
        
        /// <summary>
        ///     The
        /// </summary>
        private Vector2 uA;
        
        /// <summary>
        ///     The
        /// </summary>
        private Vector2 uB;
        
        /// <summary>
        ///     The world anchor
        /// </summary>
        private Vector2 worldAnchorA;
        
        /// <summary>
        ///     The world anchor
        /// </summary>
        private Vector2 worldAnchorB;
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="PulleyJoint" /> class
        /// </summary>
        /// <param name="bodyA">The body</param>
        /// <param name="bodyB">The body</param>
        /// <param name="jointType">The joint type</param>
        /// <param name="collideConnected">The collide connected</param>
        /// <param name="groundAnchorA">The ground anchor</param>
        /// <param name="groundAnchorB">The ground anchor</param>
        /// <param name="localAnchorA">The local anchor</param>
        /// <param name="localAnchorB">The local anchor</param>
        /// <param name="lengthA">The length</param>
        /// <param name="lengthB">The length</param>
        /// <param name="ratio">The ratio</param>
        public PulleyJoint(
            Body bodyA = null,
            Body bodyB = null,
            JointType jointType = default(JointType),
            bool collideConnected = true,
            Vector2 groundAnchorA = default(Vector2),
            Vector2 groundAnchorB = default(Vector2),
            Vector2 localAnchorA = default(Vector2),
            Vector2 localAnchorB = default(Vector2),
            float lengthA = 0.0f,
            float lengthB = 0.0f,
            float ratio = 1.0f
        )
            : base(bodyA, bodyB, jointType, collideConnected)
        {
            if (groundAnchorA.Equals(default(Vector2)))
            {
                groundAnchorA = new Vector2(-1.0f, 1.0f);
            }
            
            if (groundAnchorB.Equals(default(Vector2)))
            {
                groundAnchorB = new Vector2(1.0f, 1.0f);
            }
            
            if (localAnchorA.Equals(default(Vector2)))
            {
                localAnchorA = new Vector2(-1.0f, 0.0f);
            }
            
            if (localAnchorB.Equals(default(Vector2)))
            {
                localAnchorB = new Vector2(1.0f, 0.0f);
            }
            
            worldAnchorA = groundAnchorA;
            worldAnchorB = groundAnchorB;
            this.localAnchorA = localAnchorA;
            this.localAnchorB = localAnchorB;
            
            this.lengthA = lengthA;
            this.lengthB = lengthB;
            
            this.ratio = ratio;
            
            constant = lengthA + this.ratio * lengthB;
        }
        
        /// <summary>Constructor for PulleyJoint.</summary>
        /// <param name="bodyA">The first body.</param>
        /// <param name="bodyB">The second body.</param>
        /// <param name="anchorA">The anchor on the first body.</param>
        /// <param name="anchorB">The anchor on the second body.</param>
        /// <param name="worldAnchorA">The world anchor for the first body.</param>
        /// <param name="worldAnchorB">The world anchor for the second body.</param>
        /// <param name="ratio">The ratio.</param>
        /// <param name="useWorldCoordinates">Set to true if you are using world coordinates as anchors.</param>
        public PulleyJoint(Body bodyA, Body bodyB, Vector2 anchorA, Vector2 anchorB, Vector2 worldAnchorA,
            Vector2 worldAnchorB, float ratio, bool useWorldCoordinates = false)
            : base(bodyA, bodyB, JointType.Pulley)
        {
            this.worldAnchorA = worldAnchorA;
            this.worldAnchorB = worldAnchorB;
            
            if (useWorldCoordinates)
            {
                localAnchorA = bodyA.GetLocalPoint(anchorA);
                localAnchorB = bodyB.GetLocalPoint(anchorB);
                
                Vector2 dA = anchorA - worldAnchorA;
                lengthA = dA.Length();
                Vector2 dB = anchorB - worldAnchorB;
                lengthB = dB.Length();
            }
            else
            {
                localAnchorA = anchorA;
                localAnchorB = anchorB;
                
                Vector2 dA = anchorA - bodyA.GetLocalPoint(worldAnchorA);
                lengthA = dA.Length();
                Vector2 dB = anchorB - bodyB.GetLocalPoint(worldAnchorB);
                lengthB = dB.Length();
            }
            
            this.ratio = ratio;
            constant = lengthA + ratio * lengthB;
            impulse = 0.0f;
        }
        
        /// <summary>The local anchor point on BodyA</summary>
        public Vector2 LocalAnchorA
        {
            get => localAnchorA;
            set => localAnchorA = value;
        }
        
        /// <summary>The local anchor point on BodyB</summary>
        public Vector2 LocalAnchorB
        {
            get => localAnchorB;
            set => localAnchorB = value;
        }
        
        /// <summary>Get the first world anchor.</summary>
        public sealed override Vector2 WorldAnchorA
        {
            get => worldAnchorA;
            set => worldAnchorA = value;
        }
        
        /// <summary>Get the second world anchor.</summary>
        public sealed override Vector2 WorldAnchorB
        {
            get => worldAnchorB;
            set => worldAnchorB = value;
        }
        
        /// <summary>Get the current length of the segment attached to BodyA.</summary>
        public float LengthA
        {
            get => lengthA;
            set => lengthA = value;
        }
        
        /// <summary>Get the current length of the segment attached to BodyB.</summary>
        public float LengthB
        {
            get => lengthB;
            set => lengthB = value;
        }
        
        /// <summary>The current length between the anchor point on BodyA and WorldAnchorA</summary>
        public float CurrentLengthA
        {
            get
            {
                Vector2 p = BodyA.GetWorldPoint(localAnchorA);
                Vector2 s = worldAnchorA;
                Vector2 d = p - s;
                return d.Length();
            }
        }
        
        /// <summary>The current length between the anchor point on BodyB and WorldAnchorB</summary>
        public float CurrentLengthB
        {
            get
            {
                Vector2 p = BodyB.GetWorldPoint(localAnchorB);
                Vector2 s = worldAnchorB;
                Vector2 d = p - s;
                return d.Length();
            }
        }
        
        /// <summary>Get the pulley ratio.</summary>
        public float Ratio
        {
            get => ratio;
            set => ratio = value;
        }
        
        /// <summary>
        ///     Shifts the origin using the specified new origin
        /// </summary>
        /// <param name="newOrigin">The new origin</param>
        public override void ShiftOrigin(ref Vector2 newOrigin)
        {
            worldAnchorA -= newOrigin;
            worldAnchorB -= newOrigin;
        }
        
        /// <summary>
        ///     Gets the reaction force using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The vector</returns>
        protected override Vector2 GetReactionForce(float invDt)
        {
            Vector2 p = impulse * uB;
            return invDt * p;
        }
        
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
            indexB = BodyB.IslandIndex;
            localCenterA = BodyA.Sweep.LocalCenter;
            localCenterB = BodyB.Sweep.LocalCenter;
            invMassA = BodyA.InvMass;
            invMassB = BodyB.InvMass;
            invIa = BodyA.InvI;
            invIb = BodyB.InvI;
            
            Vector2 cA = data.Positions[indexA].C;
            float aA = data.Positions[indexA].A;
            Vector2 vA = data.Velocities[indexA].V;
            float wA = data.Velocities[indexA].W;
            
            Vector2 cB = data.Positions[indexB].C;
            float aB = data.Positions[indexB].A;
            Vector2 vB = data.Velocities[indexB].V;
            float wB = data.Velocities[indexB].W;
            
            Rotation qA = new Rotation(aA), qB = new Rotation(aB);
            
            rA = MathUtils.Mul(qA, localAnchorA - localCenterA);
            rB = MathUtils.Mul(qB, localAnchorB - localCenterB);
            
            // Get the pulley axes.
            uA = cA + rA - worldAnchorA;
            uB = cB + rB - worldAnchorB;
            
            float lengthALocal = uA.Length();
            float lengthBLocal = uB.Length();
            
            if (lengthALocal > 10.0f * Settings.LinearSlop)
            {
                uA *= 1.0f / lengthALocal;
            }
            else
            {
                uA = Vector2.Zero;
            }
            
            if (lengthBLocal > 10.0f * Settings.LinearSlop)
            {
                uB *= 1.0f / lengthBLocal;
            }
            else
            {
                uB = Vector2.Zero;
            }
            
            // Compute effective mass.
            float ruA = MathUtils.Cross(rA, uA);
            float ruB = MathUtils.Cross(rB, uB);
            
            float mA = invMassA + invIa * ruA * ruA;
            float mB = invMassB + invIb * ruB * ruB;
            
            mass = mA + ratio * ratio * mB;
            
            if (mass > 0.0f)
            {
                mass = 1.0f / mass;
            }
            
            if (data.Step.WarmStarting)
            {
                // Scale impulses to support variable time steps.
                impulse *= data.Step.DeltaTimeRatio;
                
                // Warm starting.
                Vector2 pa = -impulse * uA;
                Vector2 pb = -ratio * impulse * uB;
                
                vA += invMassA * pa;
                wA += invIa * MathUtils.Cross(rA, pa);
                vB += invMassB * pb;
                wB += invIb * MathUtils.Cross(rB, pb);
            }
            else
            {
                impulse = 0.0f;
            }
            
            data.Velocities[indexA].V = vA;
            data.Velocities[indexA].W = wA;
            data.Velocities[indexB].V = vB;
            data.Velocities[indexB].W = wB;
        }
        
        /// <summary>
        ///     Solves the velocity constraints using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        internal override void SolveVelocityConstraints(ref SolverData data)
        {
            Vector2 vA = data.Velocities[indexA].V;
            float wA = data.Velocities[indexA].W;
            Vector2 vB = data.Velocities[indexB].V;
            float wB = data.Velocities[indexB].W;
            
            Vector2 vpA = vA + MathUtils.Cross(wA, rA);
            Vector2 vpB = vB + MathUtils.Cross(wB, rB);
            
            float cDot = -Vector2.Dot(uA, vpA) - ratio * Vector2.Dot(uB, vpB);
            float impulseLocal = -mass * cDot;
            impulse += impulseLocal;
            
            Vector2 pa = -impulseLocal * uA;
            Vector2 pb = -ratio * impulseLocal * uB;
            vA += invMassA * pa;
            wA += invIa * MathUtils.Cross(rA, pa);
            vB += invMassB * pb;
            wB += invIb * MathUtils.Cross(rB, pb);
            
            data.Velocities[indexA].V = vA;
            data.Velocities[indexA].W = wA;
            data.Velocities[indexB].V = vB;
            data.Velocities[indexB].W = wB;
        }
        
        /// <summary>
        ///     Describes whether this instance solve position constraints
        /// </summary>
        /// <param name="data">The data</param>
        /// <returns>The bool</returns>
        internal override bool SolvePositionConstraints(ref SolverData data)
        {
            Vector2 cA = data.Positions[indexA].C;
            float aA = data.Positions[indexA].A;
            Vector2 cB = data.Positions[indexB].C;
            float aB = data.Positions[indexB].A;
            
            Rotation qA = new Rotation(aA), qB = new Rotation(aB);
            
            Vector2 rALocal = MathUtils.Mul(qA, localAnchorA - localCenterA);
            Vector2 rBLocal = MathUtils.Mul(qB, localAnchorB - localCenterB);
            
            // Get the pulley axes.
            Vector2 uALocal = cA + rALocal - worldAnchorA;
            Vector2 uBLocal = cB + rBLocal - worldAnchorB;
            
            float lengthALocal = uALocal.Length();
            float lengthBLocal = uBLocal.Length();
            
            if (lengthALocal > 10.0f * Settings.LinearSlop)
            {
                uALocal *= 1.0f / lengthALocal;
            }
            else
            {
                uALocal = Vector2.Zero;
            }
            
            if (lengthBLocal > 10.0f * Settings.LinearSlop)
            {
                uBLocal *= 1.0f / lengthBLocal;
            }
            else
            {
                uBLocal = Vector2.Zero;
            }
            
            // Compute effective mass.
            float ruA = MathUtils.Cross(rALocal, uALocal);
            float ruB = MathUtils.Cross(rBLocal, uBLocal);
            
            float mA = invMassA + invIa * ruA * ruA;
            float mB = invMassB + invIb * ruB * ruB;
            
            float massLocal = mA + ratio * ratio * mB;
            
            if (massLocal > 0.0f)
            {
                massLocal = 1.0f / massLocal;
            }
            
            float c = constant - lengthALocal - ratio * lengthBLocal;
            float linearError = Math.Abs(c);
            
            float imp = -massLocal * c;
            
            Vector2 pa = -imp * uALocal;
            Vector2 pb = -ratio * imp * uBLocal;
            
            cA += invMassA * pa;
            aA += invIa * MathUtils.Cross(rALocal, pa);
            cB += invMassB * pb;
            aB += invIb * MathUtils.Cross(rBLocal, pb);
            
            data.Positions[indexA].C = cA;
            data.Positions[indexA].A = aA;
            data.Positions[indexB].C = cB;
            data.Positions[indexB].A = aB;
            
            return linearError < Settings.LinearSlop;
        }
    }
}