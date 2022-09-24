// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:LineJoint.cs
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

using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Time;
using Alis.Core.Physic.Dynamics.Body;

namespace Alis.Core.Physic.Dynamics.Joint
{
    /// <summary>
    ///     A line joint. This joint provides one degree of freedom: translation
    ///     along an axis fixed in body1. You can use a joint limit to restrict
    ///     the range of motion and a joint motor to drive the motion or to
    ///     model joint friction.
    /// </summary>
    public class LineJoint : IJoint
    {
        /// <summary>
        ///     The
        /// </summary>
        public float A1;

        /// <summary>
        ///     The
        /// </summary>
        public float A2;

        /// <summary>
        ///     The perp
        /// </summary>
        public Vector2 Axis;

        /// <summary>
        ///     The enable limit
        /// </summary>
        public bool EnableLimitx;

        /// <summary>
        ///     The enable motor
        /// </summary>
        public bool EnableMotorx;

        /// <summary>
        ///     The impulse
        /// </summary>
        public Vector2 Impulse;

        /// <summary>
        ///     The
        /// </summary>
        public Matrix22 K;

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
        ///     The local axis
        /// </summary>
        public Vector2 LocalXAxis1;

        /// <summary>
        ///     The local axis
        /// </summary>
        public Vector2 LocalYAxis1;

        /// <summary>
        ///     The lower translation
        /// </summary>
        public float LowerTranslation;

        /// <summary>
        ///     The max motor force
        /// </summary>
        public float MaxMotorForce;

        /// <summary>
        ///     The motor impulse
        /// </summary>
        public float MotorImpulse;

        /// <summary>
        ///     The motor mass
        /// </summary>
        public float MotorMass; // effective mass for motor/limit translational constraint.

        /// <summary>
        ///     The motor speed
        /// </summary>
        public float MotorSpeed;

        /// <summary>
        ///     The perp
        /// </summary>
        public Vector2 Perp;

        /// <summary>
        ///     The
        /// </summary>
        public float S1;

        /// <summary>
        ///     The
        /// </summary>
        private float s2;

        /// <summary>
        ///     The upper translation
        /// </summary>
        public float UpperTranslation;

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
        ///     Initializes a new instance of the <see cref="LineJoint" /> class
        /// </summary>
        /// <param name="def">The def</param>
        public LineJoint(LineJointDef def)
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

            Impulse.SetZero();
            MotorMass = 0.0f;
            MotorImpulse = 0.0f;

            LowerTranslation = def.LowerTranslation;
            UpperTranslation = def.UpperTranslation;
            MaxMotorForce = Settings.FORCE_INV_SCALE(def.MaxMotorForce);
            MotorSpeed = def.MotorSpeed;
            EnableLimitx = def.EnableLimit;
            EnableMotorx = def.EnableMotor;
            LimitState = LimitState.InactiveLimit;

            Axis.SetZero();
            Perp.SetZero();
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
        ///     Gets the reaction force using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The vec</returns>
        public Vector2 GetReactionForce(float invDt) => invDt * (Impulse.X * Perp + (MotorImpulse + Impulse.Y) * Axis);

        /// <summary>
        ///     Gets the reaction torque using the specified inv dt
        /// </summary>
        /// <param name="invDt"></param>
        /// <returns>The float</returns>
        public float GetReactionTorque(float invDt) => 0.0f;

        /// <summary>
        ///     Get the current joint translation, usually in meters.
        /// </summary>
        public float GetJointTranslation()
        {
            BodyBase b1 = Body1;
            BodyBase b2 = Body2;

            Vector2 p1 = b1.GetWorldPoint(LocalAnchor1);
            Vector2 p2 = b2.GetWorldPoint(LocalAnchor2);
            Vector2 d = p2 - p1;
            Vector2 axis = b1.GetWorldVector(LocalXAxis1);

            float translation = Vector2.Dot(d, axis);
            return translation;
        }

        /// <summary>
        ///     Get the current joint translation speed, usually in meters per second.
        /// </summary>
        public float GetJointSpeed()
        {
            BodyBase b1 = Body1;
            BodyBase b2 = Body2;

            Vector2 r1 = Helper.Mul(b1.GetXForm().R, LocalAnchor1 - b1.GetLocalCenter());
            Vector2 r2 = Helper.Mul(b2.GetXForm().R, LocalAnchor2 - b2.GetLocalCenter());
            Vector2 p1 = b1.Sweep.C + r1;
            Vector2 p2 = b2.Sweep.C + r2;
            Vector2 d = p2 - p1;
            Vector2 axis = b1.GetWorldVector(LocalXAxis1);

            Vector2 v1 = b1.LinearVelocity;
            Vector2 v2 = b2.LinearVelocity;
            float w1 = b1.AngularVelocity;
            float w2 = b2.AngularVelocity;

            float speed = Vector2.Dot(d, Vector2.Cross(w1, axis)) +
                          Vector2.Dot(axis, v2 + Vector2.Cross(w2, r2) - v1 - Vector2.Cross(w1, r1));
            return speed;
        }

        /// <summary>
        ///     Is the joint limit enabled?
        /// </summary>
        public bool IsLimitEnabled() => EnableLimitx;

        /// <summary>
        ///     Enable/disable the joint limit.
        /// </summary>
        public void EnableLimit(bool flag)
        {
            Body1.WakeUp();
            Body2.WakeUp();
            EnableLimitx = flag;
        }

        /// <summary>
        ///     Get the lower joint limit, usually in meters.
        /// </summary>
        public float GetLowerLimit() => LowerTranslation;

        /// <summary>
        ///     Get the upper joint limit, usually in meters.
        /// </summary>
        public float GetUpperLimit() => UpperTranslation;

        /// <summary>
        ///     Set the joint limits, usually in meters.
        /// </summary>
        public void SetLimits(float lower, float upper)
        {
            Box2DxDebug.Assert(lower <= upper);
            Body1.WakeUp();
            Body2.WakeUp();
            LowerTranslation = lower;
            UpperTranslation = upper;
        }

        /// <summary>
        ///     Is the joint motor enabled?
        /// </summary>
        public bool IsMotorEnabled() => EnableMotorx;

        /// <summary>
        ///     Enable/disable the joint motor.
        /// </summary>
        public void EnableMotor(bool flag)
        {
            Body1.WakeUp();
            Body2.WakeUp();
            EnableMotorx = flag;
        }

        /// <summary>
        ///     Set the motor speed, usually in meters per second.
        /// </summary>
        public void SetMotorSpeed(float speed)
        {
            Body1.WakeUp();
            Body2.WakeUp();
            MotorSpeed = speed;
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
        ///     Get the current motor force, usually in N.
        /// </summary>
        public float GetMotorForce() => MotorImpulse;

        /// <summary>
        ///     Get the motor speed, usually in meters per second.
        /// </summary>
        public float GetMotorSpeed() => MotorSpeed;

        /// <summary>
        ///     Inits the velocity constraints using the specified step
        /// </summary>
        /// <param name="step">The step</param>
        internal void InitVelocityConstraints(TimeStep step)
        {
            BodyBase b1 = Body1;
            BodyBase b2 = Body2;

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
                A1 = Vector2.Cross(d + r1, Axis);
                A2 = Vector2.Cross(r2, Axis);

                MotorMass = InvMass1 + InvMass2 + InvI1 * A1 * A1 + InvI2 * A2 * A2;
                Box2DxDebug.Assert(MotorMass > Settings.FltEpsilon);
                MotorMass = 1.0f / MotorMass;
            }

            // Prismatic constraint.
            {
                Perp = Helper.Mul(xf1.R, LocalYAxis1);

                S1 = Vector2.Cross(d + r1, Perp);
                s2 = Vector2.Cross(r2, Perp);

                float m1 = InvMass1, m2 = InvMass2;
                float i1 = InvI1, i2 = InvI2;

                float k11 = m1 + m2 + i1 * S1 * S1 + i2 * s2 * s2;
                float k12 = i1 * S1 * A1 + i2 * s2 * A2;
                float k22 = m1 + m2 + i1 * A1 * A1 + i2 * A2 * A2;

                K.Col1.Set(k11, k12);
                K.Col2.Set(k12, k22);
            }

            // Compute motor and limit terms.
            if (EnableLimitx)
            {
                float jointTranslation = Vector2.Dot(Axis, d);
                if (Helper.Abs(UpperTranslation - LowerTranslation) < 2.0f * Settings.LinearSlop)
                {
                    LimitState = LimitState.EqualLimits;
                }
                else if (jointTranslation <= LowerTranslation)
                {
                    if (LimitState != LimitState.AtLowerLimit)
                    {
                        LimitState = LimitState.AtLowerLimit;
                        Impulse.Y = 0.0f;
                    }
                }
                else if (jointTranslation >= UpperTranslation)
                {
                    if (LimitState != LimitState.AtUpperLimit)
                    {
                        LimitState = LimitState.AtUpperLimit;
                        Impulse.Y = 0.0f;
                    }
                }
                else
                {
                    LimitState = LimitState.InactiveLimit;
                    Impulse.Y = 0.0f;
                }
            }
            else
            {
                LimitState = LimitState.InactiveLimit;
            }

            if (EnableMotorx == false)
            {
                MotorImpulse = 0.0f;
            }

            if (step.WarmStarting)
            {
                // Account for variable time step.
                Impulse *= step.DtRatio;
                MotorImpulse *= step.DtRatio;

                Vector2 p = Impulse.X * Perp + (MotorImpulse + Impulse.Y) * Axis;
                float l1 = Impulse.X * S1 + (MotorImpulse + Impulse.Y) * A1;
                float l2 = Impulse.X * s2 + (MotorImpulse + Impulse.Y) * A2;

                b1.LinearVelocity -= InvMass1 * p;
                b1.AngularVelocity -= InvI1 * l1;

                b2.LinearVelocity += InvMass2 * p;
                b2.AngularVelocity += InvI2 * l2;
            }
            else
            {
                Impulse.SetZero();
                MotorImpulse = 0.0f;
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

            Vector2 v1 = b1.LinearVelocity;
            float w1 = b1.AngularVelocity;
            Vector2 v2 = b2.LinearVelocity;
            float w2 = b2.AngularVelocity;

            // Solve linear motor constraint.
            if (EnableMotorx && (LimitState != LimitState.EqualLimits))
            {
                float cdot = Vector2.Dot(Axis, v2 - v1) + A2 * w2 - A1 * w1;
                float impulse = MotorMass * (MotorSpeed - cdot);
                float oldImpulse = MotorImpulse;
                float maxImpulse = step.Dt * MaxMotorForce;
                MotorImpulse = Helper.Clamp(MotorImpulse + impulse, -maxImpulse, maxImpulse);
                impulse = MotorImpulse - oldImpulse;

                Vector2 p = impulse * Axis;
                float l1 = impulse * A1;
                float l2 = impulse * A2;

                v1 -= InvMass1 * p;
                w1 -= InvI1 * l1;

                v2 += InvMass2 * p;
                w2 += InvI2 * l2;
            }

            float cdot1 = Vector2.Dot(Perp, v2 - v1) + s2 * w2 - S1 * w1;

            if (EnableLimitx && (LimitState != LimitState.InactiveLimit))
            {
                // Solve prismatic and limit constraint in block form.
                float cdot2 = Vector2.Dot(Axis, v2 - v1) + A2 * w2 - A1 * w1;
                Vector2 cdot = new Vector2(cdot1, cdot2);

                Vector2 f1 = Impulse;
                Vector2 df = K.Solve(-cdot);
                Impulse += df;

                if (LimitState == LimitState.AtLowerLimit)
                {
                    Impulse.Y = Helper.Max(Impulse.Y, 0.0f);
                }
                else if (LimitState == LimitState.AtUpperLimit)
                {
                    Impulse.Y = Helper.Min(Impulse.Y, 0.0f);
                }

                // f2(1) = invK(1,1) * (-Cdot(1) - K(1,2) * (f2(2) - f1(2))) + f1(1)
                float b = -cdot1 - (Impulse.Y - f1.Y) * K.Col2.X;
                float f2R = b / K.Col1.X + f1.X;
                Impulse.X = f2R;

                df = Impulse - f1;

                Vector2 p = df.X * Perp + df.Y * Axis;
                float l1 = df.X * S1 + df.Y * A1;
                float l2 = df.X * s2 + df.Y * A2;

                v1 -= InvMass1 * p;
                w1 -= InvI1 * l1;

                v2 += InvMass2 * p;
                w2 += InvI2 * l2;
            }
            else
            {
                // Limit is inactive, just solve the prismatic constraint in block form.
                float df = -cdot1 / K.Col1.X;
                Impulse.X += df;

                Vector2 p = df * Perp;
                float l1 = df * S1;
                float l2 = df * s2;

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
            BodyBase b1 = Body1;
            BodyBase b2 = Body2;

            Vector2 invMass1 = b1.Sweep.C;
            float a1 = b1.Sweep.A;

            Vector2 invMass2 = b2.Sweep.C;
            float a2 = b2.Sweep.A;

            // Solve linear limit constraint.
            float linearError = 0.0f, angularError = 0.0f;
            bool active = false;
            float clamp = 0.0f;

            Matrix22 mat22 = new Matrix22(a1);
            Matrix22 mat23 = new Matrix22(a2);

            Vector2 r1 = Helper.Mul(mat22, LocalAnchor1 - LocalCenter1);
            Vector2 r2 = Helper.Mul(mat23, LocalAnchor2 - LocalCenter2);
            Vector2 d = invMass2 + r2 - invMass1 - r1;

            if (EnableLimitx)
            {
                Axis = Helper.Mul(mat22, LocalXAxis1);

                A1 = Vector2.Cross(d + r1, Axis);
                A2 = Vector2.Cross(r2, Axis);

                float translation = Vector2.Dot(Axis, d);
                if (Helper.Abs(UpperTranslation - LowerTranslation) < 2.0f * Settings.LinearSlop)
                {
                    // Prevent large angular corrections
                    clamp = Helper.Clamp(translation, -Settings.MaxLinearCorrection, Settings.MaxLinearCorrection);
                    linearError = Helper.Abs(translation);
                    active = true;
                }
                else if (translation <= LowerTranslation)
                {
                    // Prevent large linear corrections and allow some slop.
                    clamp = Helper.Clamp(translation - LowerTranslation + Settings.LinearSlop,
                        -Settings.MaxLinearCorrection, 0.0f);
                    linearError = LowerTranslation - translation;
                    active = true;
                }
                else if (translation >= UpperTranslation)
                {
                    // Prevent large linear corrections and allow some slop.
                    clamp = Helper.Clamp(translation - UpperTranslation - Settings.LinearSlop, 0.0f,
                        Settings.MaxLinearCorrection);
                    linearError = translation - UpperTranslation;
                    active = true;
                }
            }

            Perp = Helper.Mul(mat22, LocalYAxis1);

            S1 = Vector2.Cross(d + r1, Perp);
            s2 = Vector2.Cross(r2, Perp);

            Vector2 impulse;
            float c1;
            c1 = Vector2.Dot(Perp, d);

            linearError = Helper.Max(linearError, Helper.Abs(c1));
            angularError = 0.0f;

            if (active)
            {
                float m1 = InvMass1, m2 = InvMass2;
                float i1 = InvI1, i2 = InvI2;

                float k11 = m1 + m2 + i1 * S1 * S1 + i2 * s2 * s2;
                float k12 = i1 * S1 * A1 + i2 * s2 * A2;
                float k22 = m1 + m2 + i1 * A1 * A1 + i2 * A2 * A2;

                K.Col1.Set(k11, k12);
                K.Col2.Set(k12, k22);

                Vector2 c = new Vector2();
                c.X = c1;
                c.Y = clamp;

                impulse = K.Solve(-c);
            }
            else
            {
                float m1 = InvMass1, m2 = InvMass2;
                float i1 = InvI1, i2 = InvI2;

                float k11 = m1 + m2 + i1 * S1 * S1 + i2 * s2 * s2;

                float impulse1 = -c1 / k11;
                impulse.X = impulse1;
                impulse.Y = 0.0f;
            }

            Vector2 p = impulse.X * Perp + impulse.Y * Axis;
            float l1 = impulse.X * S1 + impulse.Y * A1;
            float l2 = impulse.X * s2 + impulse.Y * A2;

            invMass1 -= InvMass1 * p;
            a1 -= InvI1 * l1;
            invMass2 += InvMass2 * p;
            a2 += InvI2 * l2;

            // TODO_ERIN remove need for this.
            b1.Sweep.C = invMass1;
            b1.Sweep.A = a1;
            b2.Sweep.C = invMass2;
            b2.Sweep.A = a2;
            b1.SynchronizeTransform();
            b2.SynchronizeTransform();

            return (linearError <= Settings.LinearSlop) && (angularError <= Settings.AngularSlop);
        }
    }
}