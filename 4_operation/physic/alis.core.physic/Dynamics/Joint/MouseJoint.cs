// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MouseJoint.cs
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

// p = attached point, m = mouse point
// C = p - m
// Cdot = v
//      = v + cross(w, r)
// J = [I r_skew]
// Identity used:
// w k % (rx i + ry j) = w * (-ry i + rx j)

using Alis.Aspect.Logging;
using Alis.Aspect.Math;
using Alis.Aspect.Time;

namespace Alis.Core.Physic.Dynamics.Joint
{
    /// <summary>
    ///     A mouse joint is used to make a point on a body track a
    ///     specified world point. This a soft constraint with a maximum
    ///     force. This allows the constraint to stretch and without
    ///     applying huge forces.
    /// </summary>
    public class MouseJoint : IJoint
    {
        /// <summary>
        ///     The target
        /// </summary>
        public Vector2 Target;

        /// <summary>
        /// The local anchor
        /// </summary>
        private readonly Vector2 localAnchor;
        /// <summary>
        /// The impulse
        /// </summary>
        private Vector2 impulse;
        /// <summary>
        /// The mass
        /// </summary>
        private Matrix22 mass;
        /// <summary>
        /// The 
        /// </summary>
        private Vector2 c;
        /// <summary>
        /// The max force
        /// </summary>
        private readonly float maxForce;
        /// <summary>
        /// The frequency hz
        /// </summary>
        private readonly float frequencyHz;
        /// <summary>
        /// The damping ratio
        /// </summary>
        private readonly float dampingRatio;
        /// <summary>
        /// The beta
        /// </summary>
        private float beta;
        /// <summary>
        /// The gamma
        /// </summary>
        private float gamma;
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
        private Body body1;
        /// <summary>
        /// The body
        /// </summary>
        private Body body2;
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
        ///     Initializes a new instance of the <see cref="MouseJoint" /> class
        /// </summary>
        /// <param name="def">The def</param>
        public MouseJoint(MouseJointDef def)
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
            
            Target = def.Target;
            localAnchor = Math.MulT(Body2.GetXForm(), Target);

            maxForce = def.MaxForce;
            Impulse.SetZero();

            frequencyHz = def.FrequencyHz;
            dampingRatio = def.DampingRatio;

            Beta = 0.0f;
            Gamma = 0.0f;
        }

        /// <summary>
        ///     The local anchor
        /// </summary>
        public Vector2 LocalAnchor => localAnchor;

        /// <summary>
        ///     The impulse
        /// </summary>
        public Vector2 Impulse
        {
            get => impulse;
            set => impulse = value;
        }

        /// <summary>
        ///     The mass
        /// </summary>
        public Matrix22 Mass
        {
            get => mass;
            set => mass = value;
        }

        /// <summary>
        ///     The
        /// </summary>
        public Vector2 C
        {
            get => c;
            set => c = value;
        }

        /// <summary>
        ///     The max force
        /// </summary>
        public float MaxForce => maxForce;

        /// <summary>
        ///     The frequency hz
        /// </summary>
        public float FrequencyHz => frequencyHz;

        /// <summary>
        ///     The damping ratio
        /// </summary>
        public float DampingRatio => dampingRatio;

        /// <summary>
        ///     The beta
        /// </summary>
        public float Beta
        {
            get => beta;
            set => beta = value;
        }

        /// <summary>
        ///     The gamma
        /// </summary>
        public float Gamma
        {
            get => gamma;
            set => gamma = value;
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
        public Body Body1
        {
            get => body1;
            set => body1 = value;
        }

        /// <summary>
        /// Gets or sets the value of the body 2
        /// </summary>
        public Body Body2
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
        public Vector2 Anchor1 => Target;

        /// <summary>
        ///     Gets the value of the anchor 2
        /// </summary>
        public Vector2 Anchor2 => Body2.GetWorldPoint(LocalAnchor);

        /// <summary>
        /// Gets or sets the value of the user data
        /// </summary>
        public object UserData
        {
            get => userData;
            set => userData = value;
        }

        /// <summary>
        ///     Gets the reaction force using the specified inv dt
        /// </summary>
        /// <param>The inv dt</param>
        /// <param name="invDt"></param>
        /// <returns>The vec</returns>
        public Vector2 GetReactionForce(float invDt) => invDt * Impulse;

        /// <summary>
        ///     Gets the reaction torque using the specified inv dt
        /// </summary>
        /// <param>The inv dt</param>
        /// <param name="invDt"></param>
        /// <returns>The float</returns>
        public float GetReactionTorque(float invDt) => invDt * 0.0f;

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
        internal void InitVelocityConstraints(TimeStep step)
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

            Matrix22 k1 = new Matrix22
            {
                Col1 = new Vector2(invMass, 0.0f),
                Col2 = new Vector2(0.0f, invMass)
            };

            Matrix22 k2 = new Matrix22
            {
                Col1 = new Vector2(invI * effectiveMass.Y * effectiveMass.Y, -invI * effectiveMass.X * effectiveMass.Y),
                Col2 = new Vector2(-invI * effectiveMass.X * effectiveMass.Y, invI * effectiveMass.X * effectiveMass.X)
            };

            Matrix22 k = k1 + k2;
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
        internal bool SolvePositionConstraints(float baumgarte) => true;
    }
}