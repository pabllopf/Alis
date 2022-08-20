// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GearJoint.cs
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

// Gear Joint:
// C0 = (coordinate1 + ratio * coordinate2)_initial
// C = C0 - (cordinate1 + ratio * coordinate2) = 0
// Cdot = -(Cdot1 + ratio * Cdot2)
// J = -[J1 ratio * J2]
// K = J * invM * JT
//   = J1 * invM1 * J1T + ratio * ratio * J2 * invM2 * J2T
//
// Revolute:
// coordinate = rotation
// Cdot = angularVelocity
// J = [0 0 1]
// K = J * invM * JT = invI
//
// Prismatic:
// coordinate = dot(p - pg, ug)
// Cdot = dot(v + cross(w, r), ug)
// J = [ug cross(r, ug)]
// K = J * invM * JT = invMass + invI * cross(r, ug)^2

using Alis.Aspect.Logging;
using Alis.Aspect.Math;
using Alis.Aspect.Time;
using Alis.Core.Physic.Dynamics.Bodys;

namespace Alis.Core.Physic.Dynamics.Joint
{
    /// <summary>
    ///     A gear joint is used to connect two joints together. Either joint
    ///     can be a revolute or prismatic joint. You specify a gear ratio
    ///     to bind the motions together:
    ///     coordinate1 + ratio * coordinate2 = constant
    ///     The ratio can be negative or positive. If one joint is a revolute joint
    ///     and the other joint is a prismatic joint, then the ratio will have units
    ///     of length or units of 1/length.
    ///     @warning The revolute and prismatic joints must be attached to
    ///     fixed bodies (which must be body1 on those joints).
    /// </summary>
    public class GearJoint : IJoint
    {
        /// <summary>
        ///     The
        /// </summary>
        private Jacobian jacobian;

        /// <summary>
        /// The ground
        /// </summary>
        private readonly Body ground1;
        /// <summary>
        /// The ground
        /// </summary>
        private readonly Body ground2;
        /// <summary>
        /// The revolute
        /// </summary>
        private readonly RevoluteJoint revolute1;
        /// <summary>
        /// The prismatic
        /// </summary>
        private readonly PrismaticJoint prismatic1;
        /// <summary>
        /// The revolute
        /// </summary>
        private readonly RevoluteJoint revolute2;
        /// <summary>
        /// The prismatic
        /// </summary>
        private readonly PrismaticJoint prismatic2;
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
        /// The constant
        /// </summary>
        private readonly float constant;
        /// <summary>
        /// The mass
        /// </summary>
        private float mass;
        /// <summary>
        /// The impulse
        /// </summary>
        private float impulse;
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
        /// The ratio
        /// </summary>
        private float ratio;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GearJoint" /> class
        /// </summary>
        /// <param name="def">The def</param>
        public GearJoint(GearJointDef def)
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
            
            JointType type1 = def.Joint1.GetType();
            JointType type2 = def.Joint2.GetType();

            Box2DxDebug.Assert(type1 == JointType.RevoluteJoint || type1 == JointType.PrismaticJoint);
            Box2DxDebug.Assert(type2 == JointType.RevoluteJoint || type2 == JointType.PrismaticJoint);
            Box2DxDebug.Assert(def.Joint1.GetBody1().IsStatic());
            Box2DxDebug.Assert(def.Joint2.GetBody1().IsStatic());

            revolute1 = null;
            prismatic1 = null;
            revolute2 = null;
            prismatic2 = null;

            float coordinate1, coordinate2;

            ground1 = def.Joint1.GetBody1();
            Body1 = def.Joint1.GetBody2();
            if (type1 == JointType.RevoluteJoint)
            {
                revolute1 = (RevoluteJoint) def.Joint1;
                groundAnchor1 = Revolute1.LocalAnchor1;
                localAnchor1 = Revolute1.LocalAnchor2;
                coordinate1 = Revolute1.JointAngleX;
            }
            else
            {
                prismatic1 = (PrismaticJoint) def.Joint1;
                groundAnchor1 = Prismatic1.LocalAnchor1;
                localAnchor1 = Prismatic1.LocalAnchor2;
                coordinate1 = Prismatic1.JointTranslation;
            }

            ground2 = def.Joint2.GetBody1();
            Body2 = def.Joint2.GetBody2();
            if (type2 == JointType.RevoluteJoint)
            {
                revolute2 = (RevoluteJoint) def.Joint2;
                groundAnchor2 = Revolute2.LocalAnchor1;
                localAnchor2 = Revolute2.LocalAnchor2;
                coordinate2 = Revolute2.JointAngleX;
            }
            else
            {
                prismatic2 = (PrismaticJoint) def.Joint2;
                groundAnchor2 = Prismatic2.LocalAnchor1;
                localAnchor2 = Prismatic2.LocalAnchor2;
                coordinate2 = Prismatic2.JointTranslation;
            }

            Ratio = def.Ratio;

            constant = coordinate1 + Ratio * coordinate2;

            Impulse = 0.0f;
        }

        /// <summary>
        ///     The ground
        /// </summary>
        public Body Ground1 => ground1;

        /// <summary>
        ///     The ground
        /// </summary>
        public Body Ground2 => ground2;

        // One of these is NULL.

        /// <summary>
        ///     The revolute
        /// </summary>
        public RevoluteJoint Revolute1 => revolute1;

        /// <summary>
        ///     The prismatic
        /// </summary>
        public PrismaticJoint Prismatic1 => prismatic1;

        // One of these is NULL.

        /// <summary>
        ///     The revolute
        /// </summary>
        public RevoluteJoint Revolute2 => revolute2;

        /// <summary>
        ///     The prismatic
        /// </summary>
        public PrismaticJoint Prismatic2 => prismatic2;

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
        ///     The constant
        /// </summary>
        public float Constant => constant;

        // Effective mass

        /// <summary>
        ///     The mass
        /// </summary>
        public float Mass
        {
            get => mass;
            set => mass = value;
        }

        // Impulse for accumulation/warm starting.

        /// <summary>
        ///     The impulse
        /// </summary>
        public float Impulse
        {
            get => impulse;
            set => impulse = value;
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
        public Vector2 Anchor1 => Body1.GetWorldPoint(LocalAnchor1);

        /// <summary>
        ///     Gets the value of the anchor 2
        /// </summary>
        public Vector2 Anchor2 => Body2.GetWorldPoint(LocalAnchor2);

        /// <summary>
        /// Gets or sets the value of the user data
        /// </summary>
        public object UserData
        {
            get => userData;
            set => userData = value;
        }

        /// <summary>
        ///     Get the gear ratio.
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
        public Vector2 GetReactionForce(float invDt)
        {
            // TODO_ERIN not tested
            Vector2 p = Impulse * jacobian.Linear2;
            return invDt * p;
        }

        /// <summary>
        ///     Gets the reaction torque using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The float</returns>
        public float GetReactionTorque(float invDt)
        {
            // TODO_ERIN not tested
            Vector2 r = Helper.Mul(Body2.GetXForm().R, LocalAnchor2 - Body2.GetLocalCenter());
            Vector2 p = Impulse * jacobian.Linear2;
            float l = Impulse * jacobian.Angular2 - Vector2.Cross(r, p);
            return invDt * l;
        }

        /// <summary>
        ///     Inits the velocity constraints using the specified step
        /// </summary>
        /// <param name="step">The step</param>
        internal void InitVelocityConstraints(TimeStep step)
        {
            Body g1 = Ground1;
            Body g2 = Ground2;
            Body b1 = Body1;
            Body b2 = Body2;

            float k = 0.0f;
            jacobian.SetZero();

            if (Revolute1 != null)
            {
                jacobian.Angular1 = -1.0f;
                k += b1.InvI;
            }
            else
            {
                Vector2 ug = Helper.Mul(g1.GetXForm().R, Prismatic1.LocalXAxis1);
                Vector2 r = Helper.Mul(b1.GetXForm().R, LocalAnchor1 - b1.GetLocalCenter());
                float crug = Vector2.Cross(r, ug);
                jacobian.Linear1 = -ug;
                jacobian.Angular1 = -crug;
                k += b1.InvMass + b1.InvI * crug * crug;
            }

            if (Revolute2 != null)
            {
                jacobian.Angular2 = -Ratio;
                k += Ratio * Ratio * b2.InvI;
            }
            else
            {
                Vector2 ug = Helper.Mul(g2.GetXForm().R, Prismatic2.LocalXAxis1);
                Vector2 r = Helper.Mul(b2.GetXForm().R, LocalAnchor2 - b2.GetLocalCenter());
                float crug = Vector2.Cross(r, ug);
                jacobian.Linear2 = -Ratio * ug;
                jacobian.Angular2 = -Ratio * crug;
                k += Ratio * Ratio * (b2.InvMass + b2.InvI * crug * crug);
            }

            // Compute effective mass.
            Box2DxDebug.Assert(k > 0.0f);
            Mass = 1.0f / k;

            if (step.WarmStarting)
            {
                // Warm starting.
                b1.LinearVelocity += b1.InvMass * Impulse * jacobian.Linear1;
                b1.AngularVelocity += b1.InvI * Impulse * jacobian.Angular1;
                b2.LinearVelocity += b2.InvMass * Impulse * jacobian.Linear2;
                b2.AngularVelocity += b2.InvI * Impulse * jacobian.Angular2;
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
            Body b1 = Body1;
            Body b2 = Body2;

            float cdot = jacobian.Compute(b1.LinearVelocity, b1.AngularVelocity, b2.LinearVelocity,
                b2.AngularVelocity);

            float impulse = Mass * -cdot;
            Impulse += impulse;

            b1.LinearVelocity += b1.InvMass * impulse * jacobian.Linear1;
            b1.AngularVelocity += b1.InvI * impulse * jacobian.Angular1;
            b2.LinearVelocity += b2.InvMass * impulse * jacobian.Linear2;
            b2.AngularVelocity += b2.InvI * impulse * jacobian.Angular2;
        }

        /// <summary>
        ///     Describes whether this instance solve position constraints
        /// </summary>
        /// <param name="baumgarte">The baumgarte</param>
        /// <returns>The bool</returns>
        internal bool SolvePositionConstraints(float baumgarte)
        {
            float linearError = 0.0f;

            Body b1 = Body1;
            Body b2 = Body2;

            float coordinate1, coordinate2;
            if (Revolute1 != null)
            {
                coordinate1 = Revolute1.JointAngleX;
            }
            else
            {
                coordinate1 = Prismatic1.JointTranslation;
            }

            if (Revolute2 != null)
            {
                coordinate2 = Revolute2.JointAngleX;
            }
            else
            {
                coordinate2 = Prismatic2.JointTranslation;
            }

            float c = Constant - (coordinate1 + Ratio * coordinate2);

            float impulse = Mass * -c;

            b1.Sweep.C += b1.InvMass * impulse * jacobian.Linear1;
            b1.Sweep.A += b1.InvI * impulse * jacobian.Angular1;
            b2.Sweep.C += b2.InvMass * impulse * jacobian.Linear2;
            b2.Sweep.A += b2.InvI * impulse * jacobian.Angular2;

            b1.SynchronizeTransform();
            b2.SynchronizeTransform();

            //TODO_ERIN not implemented
            return linearError < Settings.LinearSlop;
        }
    }
}