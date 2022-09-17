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
using Alis.Core.Physic.Dynamics.Body;

namespace Alis.Core.Physic.Dynamics.Joint
{
    /// <summary>
    ///     The pulley joint is connected to two bodies and two fixed ground points.
    ///     The pulley supports a ratio such that:
    ///     length1 + ratio * length2 constant
    ///     Yes, the force transmitted is scaled by the ratio.
    ///     The pulley also enforces a maximum length limit on both sides. This is
    ///     useful to prevent one side of the pulley hitting the top.
    /// </summary>
    public class PulleyJoint : IJoint
    {
        /// <summary>
        /// The min pulley length
        /// </summary>
        private static readonly float MinPulleyLength1 = 2.0f;
        /// <summary>
        /// The limit state
        /// </summary>
        private LimitState limitState;
        /// <summary>
        /// The ground
        /// </summary>
        private readonly BodyBase ground;
        /// <summary>
        /// The ground anchor
        /// </summary>
        private readonly Vector2 groundAnchor1;
        /// <summary>
        /// The ground anchor
        /// </summary>
        private readonly Vector2 groundAnchor2;
        /// <summary>
        /// The local anchor
        /// </summary>
        private readonly Vector2 localAnchor1;
        /// <summary>
        /// The local anchor
        /// </summary>
        private readonly Vector2 localAnchor2;
        /// <summary>
        /// The 
        /// </summary>
        private Vector2 u1;
        /// <summary>
        /// The 
        /// </summary>
        private Vector2 u2;
        /// <summary>
        /// The constant
        /// </summary>
        private readonly float constant;
        /// <summary>
        /// The max length
        /// </summary>
        private readonly float maxLength1;
        /// <summary>
        /// The max length
        /// </summary>
        private readonly float maxLength2;
        /// <summary>
        /// The pulley mass
        /// </summary>
        private float pulleyMass;
        /// <summary>
        /// The limit mass
        /// </summary>
        private float limitMass1;
        /// <summary>
        /// The limit mass
        /// </summary>
        private float limitMass2;
        /// <summary>
        /// The impulse
        /// </summary>
        private float impulse;
        /// <summary>
        /// The limit impulse
        /// </summary>
        private float limitImpulse1;
        /// <summary>
        /// The limit impulse
        /// </summary>
        private float limitImpulse2;
        /// <summary>
        /// The state
        /// </summary>
        private LimitState state;
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
        /// The ratio
        /// </summary>
        private float ratio;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PulleyJoint" /> class
        /// </summary>
        /// <param name="def">The def</param>
        public PulleyJoint(PulleyJointDef def)
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
            
            ground = Body1.GetWorld().GroundBodyBase;
            groundAnchor1 = def.GroundAnchor1 - Ground.GetXForm().Position;
            groundAnchor2 = def.GroundAnchor2 - Ground.GetXForm().Position;
            localAnchor1 = def.LocalAnchor1;
            localAnchor2 = def.LocalAnchor2;

            Box2DxDebug.Assert(def.Ratio != 0.0f);
            Ratio = def.Ratio;

            constant = def.Length1 + Ratio * def.Length2;

            maxLength1 = Helper.Min(def.MaxLength1, Constant - Ratio * MinPulleyLength);
            maxLength2 = Helper.Min(def.MaxLength2, (Constant - MinPulleyLength) / Ratio);

            Impulse = 0.0f;
            LimitImpulse1 = 0.0f;
            LimitImpulse2 = 0.0f;
        }

        /// <summary>
        ///     The min pulley length
        /// </summary>
        public static float MinPulleyLength => MinPulleyLength1;

        /// <summary>
        ///     The limit state
        /// </summary>
        public LimitState LimitState
        {
            get => limitState;
            set => limitState = value;
        }

        /// <summary>
        ///     The ground
        /// </summary>
        public BodyBase Ground => ground;

        /// <summary>
        ///     The ground anchor
        /// </summary>
        public Vector2 GroundAnchor1 => groundAnchor1;

        /// <summary>
        ///     The ground anchor
        /// </summary>
        public Vector2 GroundAnchor2 => groundAnchor2;

        /// <summary>
        ///     The local anchor
        /// </summary>
        public Vector2 LocalAnchor1 => localAnchor1;

        /// <summary>
        ///     The local anchor
        /// </summary>
        public Vector2 LocalAnchor2 => localAnchor2;

        /// <summary>
        ///     The
        /// </summary>
        public Vector2 U1
        {
            get => u1;
            set => u1 = value;
        }

        /// <summary>
        ///     The
        /// </summary>
        public Vector2 U2
        {
            get => u2;
            set => u2 = value;
        }

        /// <summary>
        ///     The constant
        /// </summary>
        public float Constant => constant;

        /// <summary>
        ///     The max length
        /// </summary>
        public float MaxLength1 => maxLength1;

        /// <summary>
        ///     The max length
        /// </summary>
        public float MaxLength2 => maxLength2;

        // Effective masses

        /// <summary>
        ///     The pulley mass
        /// </summary>
        public float PulleyMass
        {
            get => pulleyMass;
            set => pulleyMass = value;
        }

        /// <summary>
        ///     The limit mass
        /// </summary>
        public float LimitMass1
        {
            get => limitMass1;
            set => limitMass1 = value;
        }

        /// <summary>
        ///     The limit mass
        /// </summary>
        public float LimitMass2
        {
            get => limitMass2;
            set => limitMass2 = value;
        }

        // Impulses for accumulation/warm starting.

        /// <summary>
        ///     The impulse
        /// </summary>
        public float Impulse
        {
            get => impulse;
            set => impulse = value;
        }

        /// <summary>
        ///     The limit impulse
        /// </summary>
        public float LimitImpulse1
        {
            get => limitImpulse1;
            set => limitImpulse1 = value;
        }

        /// <summary>
        ///     The limit impulse
        /// </summary>
        public float LimitImpulse2
        {
            get => limitImpulse2;
            set => limitImpulse2 = value;
        }

        /// <summary>
        ///     The state
        /// </summary>
        public LimitState State
        {
            get => state;
            set => state = value;
        }

        /// <summary>
        /// Gets or sets the value of the type
        /// </summary>
        public JointType Type
        {
            get => type;
            set => type = value;
        }

        /// <summary>
        /// Gets or sets the value of the prev
        /// </summary>
        public IJoint Prev
        {
            get => prev;
            set => prev = value;
        }

        /// <summary>
        /// Gets or sets the value of the next
        /// </summary>
        public IJoint Next
        {
            get => next;
            set => next = value;
        }

        /// <summary>
        /// Gets the value of the node 1
        /// </summary>
        public JointEdge Node1 => node1;

        /// <summary>
        /// Gets the value of the node 2
        /// </summary>
        public JointEdge Node2 => node2;

        /// <summary>
        /// Gets or sets the value of the body 1
        /// </summary>
        public BodyBase Body1
        {
            get => body1;
            set => body1 = value;
        }

        /// <summary>
        /// Gets or sets the value of the body 2
        /// </summary>
        public BodyBase Body2
        {
            get => body2;
            set => body2 = value;
        }

        /// <summary>
        /// Gets or sets the value of the island flag
        /// </summary>
        public bool IslandFlag
        {
            get => islandFlag;
            set => islandFlag = value;
        }

        /// <summary>
        /// Gets the value of the collide connected
        /// </summary>
        public bool CollideConnected => collideConnected;

        /// <summary>
        /// Gets or sets the value of the local center 1
        /// </summary>
        public Vector2 LocalCenter1
        {
            get => localCenter1;
            set => localCenter1 = value;
        }

        /// <summary>
        /// Gets or sets the value of the local center 2
        /// </summary>
        public Vector2 LocalCenter2
        {
            get => localCenter2;
            set => localCenter2 = value;
        }

        /// <summary>
        /// Gets or sets the value of the inv mass 1
        /// </summary>
        public float InvMass1
        {
            get => invMass1;
            set => invMass1 = value;
        }

        /// <summary>
        /// Gets or sets the value of the inv i 1
        /// </summary>
        public float InvI1
        {
            get => invI1;
            set => invI1 = value;
        }

        /// <summary>
        /// Gets or sets the value of the inv mass 2
        /// </summary>
        public float InvMass2
        {
            get => invMass2;
            set => invMass2 = value;
        }

        /// <summary>
        /// Gets or sets the value of the inv i 2
        /// </summary>
        public float InvI2
        {
            get => invI2;
            set => invI2 = value;
        }

        /// <summary>
        ///     Gets the value of the anchor 1
        /// </summary>
        public  Vector2 Anchor1 => Body1.GetWorldPoint(LocalAnchor1);

        /// <summary>
        ///     Gets the value of the anchor 2
        /// </summary>
        public  Vector2 Anchor2 => Body2.GetWorldPoint(LocalAnchor2);

        /// <summary>
        /// Gets or sets the value of the user data
        /// </summary>
        public object UserData
        {
            get => userData;
            set => userData = value;
        }

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
        public float Ratio
        {
            get => ratio;
            set => ratio = value;
        }

        /// <summary>
        ///     Gets the reaction force using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The vec</returns>
        public  Vector2 GetReactionForce(float invDt)
        {
            Vector2 p = Impulse * U2;
            return invDt * p;
        }

        /// <summary>
        ///     Gets the reaction torque using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The float</returns>
        public  float GetReactionTorque(float invDt) => 0.0f;

        /// <summary>
        ///     Inits the velocity constraints using the specified step
        /// </summary>
        /// <param name="step">The step</param>
        internal  void InitVelocityConstraints(TimeStep step)
        {
            BodyBase body1 = Body1;
            BodyBase body2 = Body2;

            Vector2 mulR1 = Helper.Mul(body1.GetXForm().R, LocalAnchor1 - body1.GetLocalCenter());
            Vector2 mulR2 = Helper.Mul(body2.GetXForm().R, LocalAnchor2 - body2.GetLocalCenter());

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
            BodyBase b1 = Body1;
            BodyBase b2 = Body2;

            Vector2 r1 = Helper.Mul(b1.GetXForm().R, LocalAnchor1 - b1.GetLocalCenter());
            Vector2 r2 = Helper.Mul(b2.GetXForm().R, LocalAnchor2 - b2.GetLocalCenter());

            if (State == LimitState.AtUpperLimit)
            {
                Vector2 v1 = b1.LinearVelocity + Vector2.Cross(b1.AngularVelocity, r1);
                Vector2 v2 = b2.LinearVelocity + Vector2.Cross(b2.AngularVelocity, r2);

                float cdot = -Vector2.Dot(U1, v1) - Ratio * Vector2.Dot(U2, v2);
                float impulse = PulleyMass * -cdot;
                float oldImpulse = Impulse;
                Impulse = Helper.Max(0.0f, Impulse + impulse);
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
                LimitImpulse1 = Helper.Max(0.0f, LimitImpulse1 + impulse);
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
                LimitImpulse2 = Helper.Max(0.0f, LimitImpulse2 + impulse);
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
        internal  bool SolvePositionConstraints(float baumgarte)
        {
            BodyBase body1 = Body1;
            BodyBase body2 = Body2;

            Vector2 groundAnchor1 = Ground.GetXForm().Position + GroundAnchor1;
            Vector2 groundAnchor2 = Ground.GetXForm().Position + GroundAnchor2;

            float linearError = 0.0f;

            if (State == LimitState.AtUpperLimit)
            {
                Vector2 mulR1 = Helper.Mul(body1.GetXForm().R, LocalAnchor1 - body1.GetLocalCenter());
                Vector2 mulR2 = Helper.Mul(body2.GetXForm().R, LocalAnchor2 - body2.GetLocalCenter());

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
                linearError = Helper.Max(linearError, -c);

                c = Helper.Clamp(c + Settings.LinearSlop, -Settings.MaxLinearCorrection, 0.0f);
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
                Vector2 mulR1 = Helper.Mul(body1.GetXForm().R, LocalAnchor1 - body1.GetLocalCenter());
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
                linearError = Helper.Max(linearError, -c);
                c = Helper.Clamp(c + Settings.LinearSlop, -Settings.MaxLinearCorrection, 0.0f);
                float impulse = -LimitMass1 * c;

                Vector2 p1 = -impulse * U1;
                body1.Sweep.C += body1.InvMass * p1;
                body1.Sweep.A += body1.InvI * Vector2.Cross(mulR1, p1);

                body1.SynchronizeTransform();
            }

            if (LimitState == LimitState.AtUpperLimit)
            {
                Vector2 mulR2 = Helper.Mul(body2.GetXForm().R, LocalAnchor2 - body2.GetLocalCenter());
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
                linearError = Helper.Max(linearError, -c);
                c = Helper.Clamp(c + Settings.LinearSlop, -Settings.MaxLinearCorrection, 0.0f);
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