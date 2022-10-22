// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RevoluteJoint.cs
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

// Point-to-point constraint
// C = p2 - p1
// Cdot = v2 - v1
//      = v2 + cross(w2, r2) - v1 - cross(w1, r1)
// J = [-I -r1_skew I r2_skew ]
// Identity used:
// w k % (rx i + ry j) = w * (-ry i + rx j)

// Motor constraint
// Cdot = w2 - w1
// J = [0 0 -1 0 0 1]
// K = invI1 + invI2

using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Time;
using Alis.Core.Physic.Dynamics.Body;

namespace Alis.Core.Physic.Dynamics.Joint
{
    /// <summary>
    ///     A revolute joint constrains to bodies to share a common point while they
    ///     are free to rotate about the point. The relative rotation about the shared
    ///     point is the joint angle. You can limit the relative rotation with
    ///     a joint limit that specifies a lower and upper angle. You can use a motor
    ///     to drive the relative rotation about the shared point. A maximum motor torque
    ///     is provided so that infinite forces are not generated.
    /// </summary>
    public class RevoluteJoint : IJoint
    {
        /// <summary>
        ///     The collide connected
        /// </summary>
        private readonly bool collideConnected;

        /// <summary>
        ///     The local anchor
        /// </summary>
        private readonly Vector2 localAnchor1;

        /// <summary>
        ///     The local anchor
        /// </summary>
        private readonly Vector2 localAnchor2;

        /// <summary>
        ///     The node
        /// </summary>
        private readonly JointEdge node1;

        /// <summary>
        ///     The node
        /// </summary>
        private readonly JointEdge node2;

        /// <summary>
        ///     The reference angle
        /// </summary>
        private readonly float referenceAngle;

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
        private Vector3 impulse;

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
        ///     The local center
        /// </summary>
        private Vector2 localCenter1;

        /// <summary>
        ///     The local center
        /// </summary>
        private Vector2 localCenter2;

        /// <summary>
        ///     The lower limit
        /// </summary>
        private float lowerLimit;

        /// <summary>
        ///     The mass
        /// </summary>
        private Matrix33 mass;

        /// <summary>
        ///     The max motor torque
        /// </summary>
        private float maxMotorTorque;

        /// <summary>
        ///     The motor mass
        /// </summary>
        private float motorMass;

        /// <summary>
        ///     The motor speed
        /// </summary>
        private float motorSpeed;

        /// <summary>
        ///     The motor torque
        /// </summary>
        private float motorTorque;

        /// <summary>
        ///     The next
        /// </summary>
        private IJoint next;

        /// <summary>
        ///     The prev
        /// </summary>
        private IJoint prev;

        /// <summary>
        ///     The state
        /// </summary>
        private LimitState state;

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
        ///     Initializes a new instance of the <see cref="RevoluteJoint" /> class
        /// </summary>
        /// <param name="def">The def</param>
        public RevoluteJoint(RevoluteJointDef def)
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


            localAnchor1 = def.LocalAnchor1;
            localAnchor2 = def.LocalAnchor2;
            referenceAngle = def.ReferenceAngle;

            Impulse = new Vector3();
            MotorTorque = 0.0f;

            LowerLimit = def.LowerAngle;
            UpperLimit = def.UpperAngle;
            MaxMotorTorque = def.MaxMotorTorque;
            MotorSpeed = def.MotorSpeed;
            IsLimitEnabled = def.EnableLimit;
            IsMotorEnabled = def.EnableMotor;
            State = LimitState.InactiveLimit;
        }

        /// <summary>
        ///     The impulse
        /// </summary>
        private Vector3 Impulse
        {
            get => impulse;
            set => impulse = value;
        }

        /// <summary>
        ///     The mass
        /// </summary>
        private Matrix33 Mass
        {
            get => mass;
            set => mass = value;
        }

        /// <summary>
        ///     The local anchor
        /// </summary>
        public Vector2 LocalAnchor1 => localAnchor1;

        /// <summary>
        ///     The local anchor
        /// </summary>
        public Vector2 LocalAnchor2 => localAnchor2;

        /// <summary>
        ///     The motor mass
        /// </summary>
        private float MotorMass
        {
            get => motorMass;
            set => motorMass = value;
        }

        /// <summary>
        ///     The max motor torque
        /// </summary>
        private float MaxMotorTorque
        {
            get => maxMotorTorque;
            set => maxMotorTorque = value;
        }

        /// <summary>
        ///     The reference angle
        /// </summary>
        private float ReferenceAngle => referenceAngle;

        /// <summary>
        ///     The limit state
        /// </summary>
        private LimitState State
        {
            get => state;
            set => state = value;
        }

        /// <summary>
        ///     Get the current joint angle in radians.
        /// </summary>
        public float JointAngleX
        {
            get
            {
                BodyBase b1 = Body1;
                BodyBase b2 = Body2;
                return b2.Sweep.A - b1.Sweep.A - ReferenceAngle;
            }
        }


        /// <summary>
        ///     Get the current joint angle speed in radians per second.
        /// </summary>
        public float JointSpeedX
        {
            get
            {
                BodyBase b1 = Body1;
                BodyBase b2 = Body2;
                return b2.AngularVelocity - b1.AngularVelocity;
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
        ///     Get the lower joint limit in radians.
        /// </summary>
        public float LowerLimit
        {
            get => lowerLimit;
            set => lowerLimit = value;
        }

        /// <summary>
        ///     Get the upper joint limit in radians.
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
        ///     Get\Set the motor speed in radians per second.
        /// </summary>
        public float MotorSpeed
        {
            get => motorSpeed;
            set
            {
                Body1.WakeUp();
                Body2.WakeUp();
                motorSpeed = value;
            }
        }

        /// <summary>
        ///     Get the current motor torque, usually in N-m.
        /// </summary>
        public float MotorTorque
        {
            get => motorTorque;
            set => motorTorque = value;
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
        /// <param>The inv dt</param>
        /// <param name="invDt"></param>
        /// <returns>The vec</returns>
        public Vector2 GetReactionForce(float invDt) => invDt * new Vector2(Impulse.X, Impulse.Y);

        /// <summary>
        ///     Gets the reaction torque using the specified inv dt
        /// </summary>
        /// <param>The inv dt</param>
        /// <param name="invDt"></param>
        /// <returns>The float</returns>
        public float GetReactionTorque(float invDt) => invDt * Impulse.Z;

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
        ///     Set the joint limits in radians.
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
        ///     Set the maximum motor torque, usually in N-m.
        /// </summary>
        public void SetMaxMotorTorque(float torque)
        {
            Body1.WakeUp();
            Body2.WakeUp();
            MaxMotorTorque = torque;
        }

        /// <summary>
        ///     Inits the velocity constraints using the specified step
        /// </summary>
        /// <param name="step">The step</param>
        internal void InitVelocityConstraints(TimeStep step)
        {
            BodyBase body1 = Body1;
            BodyBase body2 = Body2;

            if (IsMotorEnabled || IsLimitEnabled)
            {
                // You cannot create a rotation limit between bodies that
                // both have fixed rotation.
                Box2DxDebug.Assert(body1.InvI > 0.0f || body2.InvI > 0.0f);
            }

            // Compute the effective mass matrix.
            Vector2 mulR1 = Helper.Mul(body1.GetXForm().R, LocalAnchor1 - body1.GetLocalCenter());
            Vector2 mulR2 = Helper.Mul(body2.GetXForm().R, LocalAnchor2 - body2.GetLocalCenter());

            // J = [-I -r1_skew I r2_skew]
            //     [ 0       -1 0       1]
            // r_skew = [-ry; rx]

            // Matlab
            // K = [ m1+r1y^2*i1+m2+r2y^2*i2,  -r1y*i1*r1x-r2y*i2*r2x,          -r1y*i1-r2y*i2]
            //     [  -r1y*i1*r1x-r2y*i2*r2x, m1+r1x^2*i1+m2+r2x^2*i2,           r1x*i1+r2x*i2]
            //     [          -r1y*i1-r2y*i2,           r1x*i1+r2x*i2,                   i1+i2]

            float m1 = body1.InvMass, m2 = body2.InvMass;
            float i1 = body1.InvI, i2 = body2.InvI;


            float col1X = m1 + m2 + mulR1.Y * mulR1.Y * i1 + mulR2.Y * mulR2.Y * i2;
            float col2X = -mulR1.Y * mulR1.X * i1 - mulR2.Y * mulR2.X * i2;
            float col3X = -mulR1.Y * i1 - mulR2.Y * i2;

            float col1Y = Mass.Col2.X;
            float col2Y = m1 + m2 + mulR1.X * mulR1.X * i1 + mulR2.X * mulR2.X * i2;
            float col3Y = mulR1.X * i1 + mulR2.X * i2;

            float col1Z = Mass.Col3.X;
            float col2Z = Mass.Col3.Y;
            float col3Z = i1 + i2;

            Mass = new Matrix33(new Vector3(col1X, col1Y, col1Z), new Vector3(col2X, col2Y, col2Z),
                new Vector3(col3X, col3Y, col3Z));

            /*
			_mass.Col1.X = m1 + m2 + r1.Y * r1.Y * i1 + r2.Y * r2.Y * i2;
			_mass.Col2.X = -r1.Y * r1.X * i1 - r2.Y * r2.X * i2;
			_mass.Col3.X = -r1.Y * i1 - r2.Y * i2;
			_mass.Col1.Y = _mass.Col2.X;
			_mass.Col2.Y = m1 + m2 + r1.X * r1.X * i1 + r2.X * r2.X * i2;
			_mass.Col3.Y = r1.X * i1 + r2.X * i2;
			_mass.Col1.Z = _mass.Col3.X;
			_mass.Col2.Z = _mass.Col3.Y;
			_mass.Col3.Z = i1 + i2;
*/
            MotorMass = 1.0f / (i1 + i2);

            if (IsMotorEnabled == false)
            {
                MotorTorque = 0.0f;
            }

            if (IsLimitEnabled)
            {
                float jointAngle = body2.Sweep.A - body1.Sweep.A - ReferenceAngle;
                if (Helper.Abs(UpperLimit - LowerLimit) < 2.0f * Settings.AngularSlop)
                {
                    State = LimitState.EqualLimits;
                }
                else if (jointAngle <= LowerLimit)
                {
                    if (State != LimitState.AtLowerLimit)
                    {
                        Impulse = new Vector3(Impulse.X, Impulse.Y, 0.0f);
                    }

                    State = LimitState.AtLowerLimit;
                }
                else if (jointAngle >= UpperLimit)
                {
                    if (State != LimitState.AtUpperLimit)
                    {
                        Impulse = new Vector3(Impulse.X, Impulse.Y, 0.0f);
                    }

                    State = LimitState.AtUpperLimit;
                }
                else
                {
                    State = LimitState.InactiveLimit;
                    Impulse = new Vector3(Impulse.X, Impulse.Y, 0.0f);
                }
            }
            else
            {
                State = LimitState.InactiveLimit;
            }

            if (step.WarmStarting)
            {
                // Scale impulses to support a variable time step.
                Impulse *= step.DtRatio;
                MotorTorque *= step.DtRatio;

                Vector2 p = new Vector2(Impulse.X, Impulse.Y);

                body1.LinearVelocity -= m1 * p;
                body1.AngularVelocity -= i1 * (Vector2.Cross(mulR1, p) + MotorTorque + Impulse.Z);

                body2.LinearVelocity += m2 * p;
                body2.AngularVelocity += i2 * (Vector2.Cross(mulR2, p) + MotorTorque + Impulse.Z);
            }
            else
            {
                Impulse.SetZero();
                MotorTorque = 0.0f;
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

            float m1 = b1.InvMass, m2 = b2.InvMass;
            float i1 = b1.InvI, i2 = b2.InvI;

            //Solve motor constraint.
            if (IsMotorEnabled && (State != LimitState.EqualLimits))
            {
                float cdot = w2 - w1 - MotorSpeed;
                float impulse = MotorMass * -cdot;
                float oldImpulse = MotorTorque;
                float maxImpulse = step.Dt * MaxMotorTorque;
                MotorTorque = Helper.Clamp(MotorTorque + impulse, -maxImpulse, maxImpulse);
                impulse = MotorTorque - oldImpulse;

                w1 -= i1 * impulse;
                w2 += i2 * impulse;
            }

            //Solve limit constraint.
            if (IsLimitEnabled && (State != LimitState.InactiveLimit))
            {
                Vector2 r1 = Helper.Mul(b1.GetXForm().R, LocalAnchor1 - b1.GetLocalCenter());
                Vector2 r2 = Helper.Mul(b2.GetXForm().R, LocalAnchor2 - b2.GetLocalCenter());

                // Solve point-to-point constraint
                Vector2 cdot1 = v2 + Vector2.Cross(w2, r2) - v1 - Vector2.Cross(w1, r1);
                float cdot2 = w2 - w1;
                Vector3 cdot = new Vector3(cdot1.X, cdot1.Y, cdot2);

                Vector3 impulse = Mass.Solve33(-cdot);

                if (State == LimitState.EqualLimits)
                {
                    Impulse += impulse;
                }
                else if (State == LimitState.AtLowerLimit)
                {
                    float newImpulse = Impulse.Z + impulse.Z;
                    if (newImpulse < 0.0f)
                    {
                        Vector2 reduced = Mass.Solve22(-cdot1);
                        impulse.X = reduced.X;
                        impulse.Y = reduced.Y;
                        impulse.Z = -Impulse.Z;
                        Impulse = new Vector3(reduced.X, reduced.Y, 0.0f);
                    }
                }
                else if (State == LimitState.AtUpperLimit)
                {
                    float newImpulse = Impulse.Z + impulse.Z;
                    if (newImpulse > 0.0f)
                    {
                        Vector2 reduced = Mass.Solve22(-cdot1);
                        impulse.X = reduced.X;
                        impulse.Y = reduced.Y;
                        impulse.Z = -Impulse.Z;
                        Impulse = new Vector3(reduced.X, reduced.Y, 0.0f);
                    }
                }

                Vector2 p = new Vector2(impulse.X, impulse.Y);

                v1 -= m1 * p;
                w1 -= i1 * (Vector2.Cross(r1, p) + impulse.Z);

                v2 += m2 * p;
                w2 += i2 * (Vector2.Cross(r2, p) + impulse.Z);
            }
            else
            {
                Vector2 r1 = Helper.Mul(b1.GetXForm().R, LocalAnchor1 - b1.GetLocalCenter());
                Vector2 r2 = Helper.Mul(b2.GetXForm().R, LocalAnchor2 - b2.GetLocalCenter());

                // Solve point-to-point constraint
                Vector2 cdot = v2 + Vector2.Cross(w2, r2) - v1 - Vector2.Cross(w1, r1);
                Vector2 impulse = Mass.Solve22(-cdot);

                Impulse = new Vector3(impulse.X, impulse.Y, Impulse.Z);

                v1 -= m1 * impulse;
                w1 -= i1 * Vector2.Cross(r1, impulse);

                v2 += m2 * impulse;
                w2 += i2 * Vector2.Cross(r2, impulse);
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
            // TODO_ERIN block solve with limit.

            BodyBase body1 = Body1;
            BodyBase body2 = Body2;

            float angularError = 0.0f;
            float positionError = 0.0f;

            // Solve angular limit constraint.
            if (IsLimitEnabled && (State != LimitState.InactiveLimit))
            {
                float angle = body2.Sweep.A - body1.Sweep.A - ReferenceAngle;
                float limitImpulse = 0.0f;

                if (State == LimitState.EqualLimits)
                {
                    // Prevent large angular corrections
                    float c = Helper.Clamp(angle, -Settings.MaxAngularCorrection, Settings.MaxAngularCorrection);
                    limitImpulse = -MotorMass * c;
                    angularError = Helper.Abs(c);
                }
                else if (State == LimitState.AtLowerLimit)
                {
                    float c = angle - LowerLimit;
                    angularError = -c;

                    // Prevent large angular corrections and allow some slop.
                    c = Helper.Clamp(c + Settings.AngularSlop, -Settings.MaxAngularCorrection, 0.0f);
                    limitImpulse = -MotorMass * c;
                }
                else if (State == LimitState.AtUpperLimit)
                {
                    float c = angle - UpperLimit;
                    angularError = c;

                    // Prevent large angular corrections and allow some slop.
                    c = Helper.Clamp(c - Settings.AngularSlop, 0.0f, Settings.MaxAngularCorrection);
                    limitImpulse = -MotorMass * c;
                }

                body1.Sweep.A -= body1.InvI * limitImpulse;
                body2.Sweep.A += body2.InvI * limitImpulse;

                body1.SynchronizeTransform();
                body2.SynchronizeTransform();
            }

            // Solve point-to-point constraint.
            {
                Vector2 mulR1 = Helper.Mul(body1.GetXForm().R, LocalAnchor1 - body1.GetLocalCenter());
                Vector2 mulR2 = Helper.Mul(body2.GetXForm().R, LocalAnchor2 - body2.GetLocalCenter());

                Vector2 body2SweepC = body2.Sweep.C + mulR2 - body1.Sweep.C - mulR1;
                positionError = body2SweepC.Length();

                float invMass1 = body1.InvMass, invMass2 = body2.InvMass;
                float invI1 = body1.InvI, invI2 = body2.InvI;

                // Handle large detachment.
                float kAllowedStretch = 10.0f * Settings.LinearSlop;
                if (body2SweepC.LengthSquared() > kAllowedStretch * kAllowedStretch)
                {
                    // Use a particle solution (no rotation).
                    Vector2 sweepC = body2SweepC;
                    sweepC.Normalize();
                    float mass12 = invMass1 + invMass2;
                    Box2DxDebug.Assert(mass12 > Settings.FltEpsilon);
                    float divideMass12 = 1.0f / mass12;
                    Vector2 impulseLocal = divideMass12 * -body2SweepC;
                    float kBeta = 0.5f;
                    body1.Sweep.C -= kBeta * invMass1 * impulseLocal;
                    body2.Sweep.C += kBeta * invMass2 * impulseLocal;

                    body2SweepC = body2.Sweep.C + mulR2 - body1.Sweep.C - mulR1;
                }

                Matrix22 k1 = new Matrix22
                {
                    Col1 = new Vector2(invMass1 + invMass2, 0.0f),
                    Col2 = new Vector2(0.0f, invMass1 + invMass2)
                };

                Matrix22 k2 = new Matrix22();
                k2.Col1.X = invI1 * mulR1.Y * mulR1.Y;
                k2.Col2.X = -invI1 * mulR1.X * mulR1.Y;
                k2.Col1.Y = -invI1 * mulR1.X * mulR1.Y;
                k2.Col2.Y = invI1 * mulR1.X * mulR1.X;

                Matrix22 k3 = new Matrix22();
                k3.Col1.X = invI2 * mulR2.Y * mulR2.Y;
                k3.Col2.X = -invI2 * mulR2.X * mulR2.Y;
                k3.Col1.Y = -invI2 * mulR2.X * mulR2.Y;
                k3.Col2.Y = invI2 * mulR2.X * mulR2.X;

                Matrix22 k = k1 + k2 + k3;
                Vector2 impulse = k.Solve(-body2SweepC);

                body1.Sweep.C -= body1.InvMass * impulse;
                body1.Sweep.A -= body1.InvI * Vector2.Cross(mulR1, impulse);

                body2.Sweep.C += body2.InvMass * impulse;
                body2.Sweep.A += body2.InvI * Vector2.Cross(mulR2, impulse);

                body1.SynchronizeTransform();
                body2.SynchronizeTransform();
            }

            return (positionError <= Settings.LinearSlop) && (angularError <= Settings.AngularSlop);
        }
    }
}