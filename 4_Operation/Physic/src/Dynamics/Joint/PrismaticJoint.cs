// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PrismaticJoint.cs
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

// Linear constraint (point-to-line)
// d = p2 - p1 = x2 + r2 - x1 - r1
// C = dot(perp, d)
// Cdot = dot(d, cross(w1, perp)) + dot(perp, v2 + cross(w2, r2) - v1 - cross(w1, r1))
//      = -dot(perp, v1) - dot(cross(d + r1, perp), w1) + dot(perp, v2) + dot(cross(r2, perp), v2)
// J = [-perp, -cross(d + r1, perp), perp, cross(r2,perp)]
//
// Angular constraint
// C = a2 - a1 + a_initial
// Cdot = w2 - w1
// J = [0 0 -1 0 0 1]
//
// K = J * invM * JT
//
// J = [-a -s1 a s2]
//     [0  -1  0  1]
// a = perp
// s1 = cross(d + r1, a) = cross(p2 - x1, a)
// s2 = cross(r2, a) = cross(p2 - x2, a)


// Motor/Limit linear constraint
// C = dot(ax1, d)
// Cdot = = -dot(ax1, v1) - dot(cross(d + r1, ax1), w1) + dot(ax1, v2) + dot(cross(r2, ax1), v2)
// J = [-ax1 -cross(d+r1,ax1) ax1 cross(r2,ax1)]

// Block Solver
// We develop a block solver that includes the joint limit. This makes the limit stiff (inelastic) even
// when the mass has poor distribution (leading to large torques about the joint anchor points).
//
// The Jacobian has 3 rows:
// J = [-uT -s1 uT s2] // linear
//     [0   -1   0  1] // angular
//     [-vT -a1 vT a2] // limit
//
// u = perp
// v = axis
// s1 = cross(d + r1, u), s2 = cross(r2, u)
// a1 = cross(d + r1, v), a2 = cross(r2, v)

// M * (v2 - v1) = JT * df
// J * v2 = bias
//
// v2 = v1 + invM * JT * df
// J * (v1 + invM * JT * df) = bias
// K * df = bias - J * v1 = -Cdot
// K = J * invM * JT
// Cdot = J * v1 - bias
//
// Now solve for f2.
// df = f2 - f1
// K * (f2 - f1) = -Cdot
// f2 = invK * (-Cdot) + f1
//
// Clamp accumulated limit impulse.
// lower: f2(3) = max(f2(3), 0)
// upper: f2(3) = min(f2(3), 0)
//
// Solve for correct f2(1:2)
// K(1:2, 1:2) * f2(1:2) = -Cdot(1:2) - K(1:2,3) * f2(3) + K(1:2,1:3) * f1
//                       = -Cdot(1:2) - K(1:2,3) * f2(3) + K(1:2,1:2) * f1(1:2) + K(1:2,3) * f1(3)
// K(1:2, 1:2) * f2(1:2) = -Cdot(1:2) - K(1:2,3) * (f2(3) - f1(3)) + K(1:2,1:2) * f1(1:2)
// f2(1:2) = invK(1:2,1:2) * (-Cdot(1:2) - K(1:2,3) * (f2(3) - f1(3))) + f1(1:2)
//
// Now compute impulse to be applied:
// df = f2 - f1

using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Time;
using Alis.Core.Physic.Dynamics.Body;

namespace Alis.Core.Physic.Dynamics.Joint
{
    /// <summary>
    ///     A prismatic joint. This joint provides one degree of freedom: translation
    ///     along an axis fixed in body1. Relative rotation is prevented. You can
    ///     use a joint limit to restrict the range of motion and a joint motor to
    ///     drive the motion or to model joint friction.
    /// </summary>
    public class PrismaticJoint : IJoint
    {
        /// <summary>
        ///     The collide connected
        /// </summary>
        private readonly bool collideConnected;

        /// <summary>
        ///     The node
        /// </summary>
        private readonly JointEdge node1;

        /// <summary>
        ///     The node
        /// </summary>
        private readonly JointEdge node2;

        /// <summary>
        ///     The ref angle
        /// </summary>
        private readonly float refAngle;

        /// <summary>
        ///     The
        /// </summary>
        private float a1;

        /// <summary>
        ///     The
        /// </summary>
        public float A2;

        /// <summary>
        ///     The perp
        /// </summary>
        public Vector2 Axis;

        /// <summary>
        ///     The body
        /// </summary>
        private BodyBase body1;

        /// <summary>
        ///     The body
        /// </summary>
        private BodyBase body2;

        /// <summary>
        ///     The impulse
        /// </summary>
        public Vector3 Impulse;

        /// <summary>
        ///     The inv
        /// </summary>
        private float invI1;

        /// <summary>
        ///     The inv
        /// </summary>
        private float invI2;

        /// <summary>
        ///     The inv mass
        /// </summary>
        private float invMass1;

        /// <summary>
        ///     The inv mass
        /// </summary>
        private float invMass2;

        /// <summary>
        ///     The island flag
        /// </summary>
        private bool islandFlag;

        /// <summary>
        ///     The is limit enabled
        /// </summary>
        private bool isLimitEnabled;

        /// <summary>
        ///     The is motor enabled
        /// </summary>
        private bool isMotorEnabled;

        /// <summary>
        ///     The
        /// </summary>
        public Matrix33 K;

        /// <summary>
        ///     The limit state
        /// </summary>
        public LimitState LimitState;

        /// <summary>
        ///     The local anchor
        /// </summary>
        public Vector2 LocalAnchor1;

        /// <summary>
        ///     The local anchor
        /// </summary>
        public Vector2 LocalAnchor2;

        /// <summary>
        ///     The local center
        /// </summary>
        private Vector2 localCenter1;

        /// <summary>
        ///     The local center
        /// </summary>
        private Vector2 localCenter2;

        /// <summary>
        ///     The local axis
        /// </summary>
        public Vector2 LocalXAxis1;

        /// <summary>
        ///     The local axis
        /// </summary>
        public Vector2 LocalYAxis1;

        /// <summary>
        ///     The lower limit
        /// </summary>
        private float lowerLimit;

        /// <summary>
        ///     The max motor force
        /// </summary>
        public float MaxMotorForce;

        /// <summary>
        ///     The motor force
        /// </summary>
        private float motorForce;

        /// <summary>
        ///     The motor mass
        /// </summary>
        public float MotorMass; // effective mass for motor/limit translational constraint.

        /// <summary>
        ///     The motor speed
        /// </summary>
        private float motorSpeedx;

        /// <summary>
        ///     The next
        /// </summary>
        private IJoint next;

        /// <summary>
        ///     The perp
        /// </summary>
        public Vector2 Perp;

        /// <summary>
        ///     The prev
        /// </summary>
        private IJoint prev;

        /// <summary>
        ///     The
        /// </summary>
        private float s1;

        /// <summary>
        ///     The
        /// </summary>
        private float s2;

        /// <summary>
        ///     The type
        /// </summary>
        private JointType type;

        /// <summary>
        ///     The upper limit
        /// </summary>
        private float upperLimit;

        /// <summary>
        ///     The user data
        /// </summary>
        private object userData;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PrismaticJoint" /> class
        /// </summary>
        /// <param name="def">The def</param>
        public PrismaticJoint(PrismaticJointDef def)
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
            LocalXAxis1 = def.LocalAxis1;
            LocalYAxis1 = Vector2.Cross(1.0f, LocalXAxis1);
            refAngle = def.ReferenceAngle;

            Impulse.SetZero();
            MotorMass = 0.0f;
            MotorForce = 0.0f;

            LowerLimit = def.LowerTranslation;
            UpperLimit = def.UpperTranslation;
            MaxMotorForce = Settings.FORCE_INV_SCALE(def.MaxMotorForce);
            motorSpeedx = def.MotorSpeed;
            IsLimitEnabled = def.EnableLimit;
            IsMotorEnabled = def.EnableMotor;
            LimitState = LimitState.InactiveLimit;

            Axis.SetZero();
            Perp.SetZero();
        }

        /// <summary>
        ///     Get the current joint translation, usually in meters.
        /// </summary>
        public float JointTranslation
        {
            get
            {
                BodyBase body1 = Body1;
                BodyBase body2 = Body2;

                Vector2 worldPoint1 = body1.GetWorldPoint(LocalAnchor1);
                Vector2 worldPoint2 = body2.GetWorldPoint(LocalAnchor2);
                Vector2 distance = worldPoint2 - worldPoint1;
                Vector2 worldVector = body1.GetWorldVector(LocalXAxis1);

                return Vector2.Dot(distance, worldVector);
            }
        }

        /// <summary>
        ///     Get the current joint translation speed, usually in meters per second.
        /// </summary>
        public float JointSpeed
        {
            get
            {
                BodyBase body1 = Body1;
                BodyBase body2 = Body2;

                Vector2 mul1 = Helper.Mul(body1.GetXForm().R, LocalAnchor1 - body1.GetLocalCenter());
                Vector2 mul2 = Helper.Mul(body2.GetXForm().R, LocalAnchor2 - body2.GetLocalCenter());
                Vector2 point1 = body1.Sweep.C + mul1;
                Vector2 point2 = body2.Sweep.C + mul2;
                Vector2 distance = point2 - point1;
                Vector2 worldVector = body1.GetWorldVector(LocalXAxis1);

                Vector2 body1LinearVelocity = body1.LinearVelocity;
                Vector2 body2LinearVelocity = body2.LinearVelocity;
                float body1AngularVelocity = body1.AngularVelocity;
                float body2AngularVelocity = body2.AngularVelocity;

                return Vector2.Dot(distance, Vector2.Cross(body1AngularVelocity, worldVector)) +
                       Vector2.Dot(worldVector,
                           body2LinearVelocity + Vector2.Cross(body2AngularVelocity, mul2) - body1LinearVelocity -
                           Vector2.Cross(body1AngularVelocity, mul1));
            }
        }

        /// <summary>
        ///     Is the joint limit enabled?
        /// </summary>
        public bool IsLimitEnabled
        {
            get => isLimitEnabled;
            set => isLimitEnabled = value;
        }

        /// <summary>
        ///     Get the lower joint limit, usually in meters.
        /// </summary>
        public float LowerLimit
        {
            get => lowerLimit;
            set => lowerLimit = value;
        }

        /// <summary>
        ///     Get the upper joint limit, usually in meters.
        /// </summary>
        public float UpperLimit
        {
            get => upperLimit;
            set => upperLimit = value;
        }

        /// <summary>
        ///     Is the joint motor enabled?
        /// </summary>
        public bool IsMotorEnabled
        {
            get => isMotorEnabled;
            set => isMotorEnabled = value;
        }

        /// <summary>
        ///     Get\Set the motor speed, usually in meters per second.
        /// </summary>
        public float MotorSpeedx
        {
            get => motorSpeedx;
            set
            {
                Body1.WakeUp();
                Body2.WakeUp();
                motorSpeedx = value;
            }
        }

        /// <summary>
        ///     Get the current motor force, usually in N.
        /// </summary>
        public float MotorForce
        {
            get => motorForce;
            set => motorForce = value;
        }

        /// <summary>
        ///     Gets or sets the value of the type
        /// </summary>
        public JointType Type
        {
            get => type;
            set => type = value;
        }

        /// <summary>
        ///     Gets or sets the value of the prev
        /// </summary>
        public IJoint Prev
        {
            get => prev;
            set => prev = value;
        }

        /// <summary>
        ///     Gets or sets the value of the next
        /// </summary>
        public IJoint Next
        {
            get => next;
            set => next = value;
        }

        /// <summary>
        ///     Gets the value of the node 1
        /// </summary>
        public JointEdge Node1 => node1;

        /// <summary>
        ///     Gets the value of the node 2
        /// </summary>
        public JointEdge Node2 => node2;

        /// <summary>
        ///     Gets or sets the value of the body 1
        /// </summary>
        public BodyBase Body1
        {
            get => body1;
            set => body1 = value;
        }

        /// <summary>
        ///     Gets or sets the value of the body 2
        /// </summary>
        public BodyBase Body2
        {
            get => body2;
            set => body2 = value;
        }

        /// <summary>
        ///     Gets or sets the value of the island flag
        /// </summary>
        public bool IslandFlag
        {
            get => islandFlag;
            set => islandFlag = value;
        }

        /// <summary>
        ///     Gets the value of the collide connected
        /// </summary>
        public bool CollideConnected => collideConnected;

        /// <summary>
        ///     Gets or sets the value of the local center 1
        /// </summary>
        public Vector2 LocalCenter1
        {
            get => localCenter1;
            set => localCenter1 = value;
        }

        /// <summary>
        ///     Gets or sets the value of the local center 2
        /// </summary>
        public Vector2 LocalCenter2
        {
            get => localCenter2;
            set => localCenter2 = value;
        }

        /// <summary>
        ///     Gets or sets the value of the inv mass 1
        /// </summary>
        public float InvMass1
        {
            get => invMass1;
            set => invMass1 = value;
        }

        /// <summary>
        ///     Gets or sets the value of the inv i 1
        /// </summary>
        public float InvI1
        {
            get => invI1;
            set => invI1 = value;
        }

        /// <summary>
        ///     Gets or sets the value of the inv mass 2
        /// </summary>
        public float InvMass2
        {
            get => invMass2;
            set => invMass2 = value;
        }

        /// <summary>
        ///     Gets or sets the value of the inv i 2
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
        ///     Gets or sets the value of the user data
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
        public Vector2 GetReactionForce(float invDt) => invDt * (Impulse.X * Perp + (MotorForce + Impulse.Z) * Axis);

        /// <summary>
        ///     Gets the reaction torque using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The float</returns>
        public float GetReactionTorque(float invDt) => invDt * Impulse.Y;

        /// <summary>
        ///     Solves the velocity constraints using the specified step
        /// </summary>
        /// <param name="step">The step</param>
        void IJoint.SolveVelocityConstraints(TimeStep step)
        {
            SolveVelocityConstraints(step);
        }

        /// <summary>
        ///     Describes whether this instance solve position constraints
        /// </summary>
        /// <param name="baumgarte">The baumgarte</param>
        /// <returns>The bool</returns>
        bool IJoint.SolvePositionConstraints(float baumgarte) => SolvePositionConstraints(baumgarte);

        /// <summary>
        ///     Inits the velocity constraints using the specified step
        /// </summary>
        /// <param name="step">The step</param>
        void IJoint.InitVelocityConstraints(TimeStep step)
        {
            InitVelocityConstraints(step);
        }

        /// <summary>
        ///     Enable/disable the joint limit.
        /// </summary>
        public void EnableLimit(bool flag)
        {
            Body1.WakeUp();
            Body2.WakeUp();
            IsLimitEnabled = flag;
        }

        /// <summary>
        ///     Set the joint limits, usually in meters.
        /// </summary>
        public void SetLimits(float lower, float upper)
        {
            Box2DxDebug.Assert(lower <= upper);
            Body1.WakeUp();
            Body2.WakeUp();
            LowerLimit = lower;
            UpperLimit = upper;
        }

        /// <summary>
        ///     Enable/disable the joint motor.
        /// </summary>
        public void EnableMotor(bool flag)
        {
            Body1.WakeUp();
            Body2.WakeUp();
            IsMotorEnabled = flag;
        }

        /// <summary>
        ///     Set the maximum motor force, usually in N.
        /// </summary>
        public void SetMaxMotorForce(float force)
        {
            Body1.WakeUp();
            Body2.WakeUp();
            MaxMotorForce = Settings.FORCE_SCALE(1.0f) * force;
        }

        /// <summary>
        ///     Inits the velocity constraints using the specified step
        /// </summary>
        /// <param name="step">The step</param>
        internal void InitVelocityConstraints(TimeStep step)
        {
            BodyBase b1 = Body1;
            BodyBase b2 = Body2;

            // You cannot create a prismatic joint between bodies that
            // both have fixed rotation.
            Box2DxDebug.Assert(b1.InvI > 0.0f || b2.InvI > 0.0f);

            LocalCenter1 = b1.GetLocalCenter();
            LocalCenter2 = b2.GetLocalCenter();

            XForm xf1 = b1.GetXForm();
            XForm xf2 = b2.GetXForm();

            // Compute the effective masses.
            Vector2 r1 = Helper.Mul(xf1.R, LocalAnchor1 - LocalCenter1);
            Vector2 r2 = Helper.Mul(xf2.R, LocalAnchor2 - LocalCenter2);
            Vector2 d = b2.Sweep.C + r2 - b1.Sweep.C - r1;

            InvMass1 = b1.InvMass;
            InvI1 = b1.InvI;
            InvMass2 = b2.InvMass;
            InvI2 = b2.InvI;

            // Compute motor Jacobian and effective mass.
            {
                Axis = Helper.Mul(xf1.R, LocalXAxis1);
                a1 = Vector2.Cross(d + r1, Axis);
                A2 = Vector2.Cross(r2, Axis);

                MotorMass = InvMass1 + InvMass2 + InvI1 * a1 * a1 + InvI2 * A2 * A2;
                Box2DxDebug.Assert(MotorMass > Settings.FltEpsilon);
                MotorMass = 1.0f / MotorMass;
            }

            // Prismatic constraint.
            {
                Perp = Helper.Mul(xf1.R, LocalYAxis1);

                s1 = Vector2.Cross(d + r1, Perp);
                s2 = Vector2.Cross(r2, Perp);

                float m1 = InvMass1, m2 = InvMass2;
                float i1 = InvI1, i2 = InvI2;

                float k11 = m1 + m2 + i1 * s1 * s1 + i2 * s2 * s2;
                float k12 = i1 * s1 + i2 * s2;
                float k13 = i1 * s1 * a1 + i2 * s2 * A2;
                float k22 = i1 + i2;
                float k23 = i1 * a1 + i2 * A2;
                float k33 = m1 + m2 + i1 * a1 * a1 + i2 * A2 * A2;

                K.Col1.Set(k11, k12, k13);
                K.Col2.Set(k12, k22, k23);
                K.Col3.Set(k13, k23, k33);
            }

            // Compute motor and limit terms.
            if (IsLimitEnabled)
            {
                float jointTranslation = Vector2.Dot(Axis, d);
                if (Helper.Abs(UpperLimit - LowerLimit) < 2.0f * Settings.LinearSlop)
                {
                    LimitState = LimitState.EqualLimits;
                }
                else if (jointTranslation <= LowerLimit)
                {
                    if (LimitState != LimitState.AtLowerLimit)
                    {
                        LimitState = LimitState.AtLowerLimit;
                        Impulse.Z = 0.0f;
                    }
                }
                else if (jointTranslation >= UpperLimit)
                {
                    if (LimitState != LimitState.AtUpperLimit)
                    {
                        LimitState = LimitState.AtUpperLimit;
                        Impulse.Z = 0.0f;
                    }
                }
                else
                {
                    LimitState = LimitState.InactiveLimit;
                    Impulse.Z = 0.0f;
                }
            }
            else
            {
                LimitState = LimitState.InactiveLimit;
            }

            if (IsMotorEnabled == false)
            {
                MotorForce = 0.0f;
            }

            if (step.WarmStarting)
            {
                // Account for variable time step.
                Impulse *= step.DtRatio;
                MotorForce *= step.DtRatio;

                Vector2 p = Impulse.X * Perp + (MotorForce + Impulse.Z) * Axis;
                float l1 = Impulse.X * s1 + Impulse.Y + (MotorForce + Impulse.Z) * a1;
                float l2 = Impulse.X * s2 + Impulse.Y + (MotorForce + Impulse.Z) * A2;

                b1.LinearVelocity -= InvMass1 * p;
                b1.AngularVelocity -= InvI1 * l1;

                b2.LinearVelocity += InvMass2 * p;
                b2.AngularVelocity += InvI2 * l2;
            }
            else
            {
                Impulse.SetZero();
                MotorForce = 0.0f;
            }
        }

        /// <summary>
        ///     Solves the velocity constraints using the specified step
        /// </summary>
        /// <param name="step">The step</param>
        internal void SolveVelocityConstraints(TimeStep step)
        {
            BodyBase b1 = Body1;
            BodyBase b2 = Body2;

            Vector2 v1 = b1.LinearVelocity;
            float w1 = b1.AngularVelocity;
            Vector2 v2 = b2.LinearVelocity;
            float w2 = b2.AngularVelocity;

            // Solve linear motor constraint.
            if (IsMotorEnabled && LimitState != LimitState.EqualLimits)
            {
                float cdot = Vector2.Dot(Axis, v2 - v1) + A2 * w2 - a1 * w1;
                float impulse = MotorMass * (motorSpeedx - cdot);
                float oldImpulse = MotorForce;
                float maxImpulse = step.Dt * MaxMotorForce;
                MotorForce = Helper.Clamp(MotorForce + impulse, -maxImpulse, maxImpulse);
                impulse = MotorForce - oldImpulse;

                Vector2 p = impulse * Axis;
                float l1 = impulse * a1;
                float l2 = impulse * A2;

                v1 -= InvMass1 * p;
                w1 -= InvI1 * l1;

                v2 += InvMass2 * p;
                w2 += InvI2 * l2;
            }

            Vector2 cdot1;
            cdot1.X = Vector2.Dot(Perp, v2 - v1) + s2 * w2 - s1 * w1;
            cdot1.Y = w2 - w1;

            if (IsLimitEnabled && LimitState != LimitState.InactiveLimit)
            {
                // Solve prismatic and limit constraint in block form.
                float cdot2;
                cdot2 = Vector2.Dot(Axis, v2 - v1) + A2 * w2 - a1 * w1;
                Vector3 cdot = new Vector3(cdot1.X, cdot1.Y, cdot2);

                Vector3 f1 = Impulse;
                Vector3 df = K.Solve33(-cdot);
                Impulse += df;

                if (LimitState == LimitState.AtLowerLimit)
                {
                    Impulse.Z = Helper.Max(Impulse.Z, 0.0f);
                }
                else if (LimitState == LimitState.AtUpperLimit)
                {
                    Impulse.Z = Helper.Min(Impulse.Z, 0.0f);
                }

                // f2(1:2) = invK(1:2,1:2) * (-Cdot(1:2) - K(1:2,3) * (f2(3) - f1(3))) + f1(1:2)
                Vector2 b = -cdot1 - (Impulse.Z - f1.Z) * new Vector2(K.Col3.X, K.Col3.Y);
                Vector2 f2R = K.Solve22(b) + new Vector2(f1.X, f1.Y);
                Impulse.X = f2R.X;
                Impulse.Y = f2R.Y;

                df = Impulse - f1;

                Vector2 p = df.X * Perp + df.Z * Axis;
                float l1 = df.X * s1 + df.Y + df.Z * a1;
                float l2 = df.X * s2 + df.Y + df.Z * A2;

                v1 -= InvMass1 * p;
                w1 -= InvI1 * l1;

                v2 += InvMass2 * p;
                w2 += InvI2 * l2;
            }
            else
            {
                // Limit is inactive, just solve the prismatic constraint in block form.
                Vector2 df = K.Solve22(-cdot1);
                Impulse.X += df.X;
                Impulse.Y += df.Y;

                Vector2 p = df.X * Perp;
                float l1 = df.X * s1 + df.Y;
                float l2 = df.X * s2 + df.Y;

                v1 -= InvMass1 * p;
                w1 -= InvI1 * l1;

                v2 += InvMass2 * p;
                w2 += InvI2 * l2;
            }

            b1.LinearVelocity = v1;
            b1.AngularVelocity = w1;
            b2.LinearVelocity = v2;
            b2.AngularVelocity = w2;
        }

        /// <summary>
        ///     Describes whether this instance solve position constraints
        /// </summary>
        /// <param name="baumgarte">The baumgarte</param>
        /// <returns>The bool</returns>
        internal bool SolvePositionConstraints(float baumgarte)
        {
            BodyBase body1 = Body1;
            BodyBase body2 = Body2;

            Vector2 body1SweepC = body1.Sweep.C;
            float body1SweepA = body1.Sweep.A;

            Vector2 body2SweepC = body2.Sweep.C;
            float body2SweepA = body2.Sweep.A;

            // Solve linear limit constraint.
            float linearError = 0.0f;
            float angularError;
            bool active = false;
            float c2 = 0.0f;

            Matrix22 mat22R1 = new Matrix22(body1SweepA);
            Matrix22 mat22R2 = new Matrix22(body2SweepA);

            Vector2 r1 = Helper.Mul(mat22R1, LocalAnchor1 - LocalCenter1);
            Vector2 r2 = Helper.Mul(mat22R2, LocalAnchor2 - LocalCenter2);
            Vector2 distance = body2SweepC + r2 - body1SweepC - r1;

            if (IsLimitEnabled)
            {
                Axis = Helper.Mul(mat22R1, LocalXAxis1);

                a1 = Vector2.Cross(distance + r1, Axis);
                A2 = Vector2.Cross(r2, Axis);

                float translation = Vector2.Dot(Axis, distance);
                if (Helper.Abs(UpperLimit - LowerLimit) < 2.0f * Settings.LinearSlop)
                {
                    // Prevent large angular corrections
                    c2 = Helper.Clamp(translation, -Settings.MaxLinearCorrection, Settings.MaxLinearCorrection);
                    linearError = Helper.Abs(translation);
                    active = true;
                }
                else if (translation <= LowerLimit)
                {
                    // Prevent large linear corrections and allow some slop.
                    c2 = Helper.Clamp(translation - LowerLimit + Settings.LinearSlop,
                        -Settings.MaxLinearCorrection, 0.0f);
                    linearError = LowerLimit - translation;
                    active = true;
                }
                else if (translation >= UpperLimit)
                {
                    // Prevent large linear corrections and allow some slop.
                    c2 = Helper.Clamp(translation - UpperLimit - Settings.LinearSlop, 0.0f,
                        Settings.MaxLinearCorrection);
                    linearError = translation - UpperLimit;
                    active = true;
                }
            }

            Perp = Helper.Mul(mat22R1, LocalYAxis1);

            s1 = Vector2.Cross(distance + r1, Perp);
            s2 = Vector2.Cross(r2, Perp);

            Vector3 impulse;
            Vector2 c1 = new Vector2();
            c1.X = Vector2.Dot(Perp, distance);
            c1.Y = body2SweepA - body1SweepA - refAngle;

            linearError = Helper.Max(linearError, Helper.Abs(c1.X));
            angularError = Helper.Abs(c1.Y);

            if (active)
            {
                float m1 = InvMass1, m2 = InvMass2;
                float i1 = InvI1, i2 = InvI2;

                float k11 = m1 + m2 + i1 * s1 * s1 + i2 * s2 * s2;
                float k12 = i1 * s1 + i2 * s2;
                float k13 = i1 * s1 * a1 + i2 * s2 * A2;
                float k22 = i1 + i2;
                float k23 = i1 * a1 + i2 * A2;
                float k33 = m1 + m2 + i1 * a1 * a1 + i2 * A2 * A2;

                K.Col1.Set(k11, k12, k13);
                K.Col2.Set(k12, k22, k23);
                K.Col3.Set(k13, k23, k33);

                Vector3 c = new Vector3();
                c.X = c1.X;
                c.Y = c1.Y;
                c.Z = c2;

                impulse = K.Solve33(-c);
            }
            else
            {
                float m1 = InvMass1, m2 = InvMass2;
                float i1 = InvI1, i2 = InvI2;

                float k11 = m1 + m2 + i1 * s1 * s1 + i2 * s2 * s2;
                float k12 = i1 * s1 + i2 * s2;
                float k22 = i1 + i2;

                K.Col1.Set(k11, k12, 0.0f);
                K.Col2.Set(k12, k22, 0.0f);

                Vector2 impulse1 = K.Solve22(-c1);
                impulse.X = impulse1.X;
                impulse.Y = impulse1.Y;
                impulse.Z = 0.0f;
            }

            Vector2 p = impulse.X * Perp + impulse.Z * Axis;
            float l1 = impulse.X * s1 + impulse.Y + impulse.Z * a1;
            float l2 = impulse.X * s2 + impulse.Y + impulse.Z * A2;

            body1SweepC -= InvMass1 * p;
            body1SweepA -= InvI1 * l1;
            body2SweepC += InvMass2 * p;
            body2SweepA += InvI2 * l2;

            // TODO_ERIN remove need for this.
            body1.Sweep.C = body1SweepC;
            body1.Sweep.A = body1SweepA;
            body2.Sweep.C = body2SweepC;
            body2.Sweep.A = body2SweepA;
            body1.SynchronizeTransform();
            body2.SynchronizeTransform();

            return linearError <= Settings.LinearSlop && angularError <= Settings.AngularSlop;
        }
    }
}