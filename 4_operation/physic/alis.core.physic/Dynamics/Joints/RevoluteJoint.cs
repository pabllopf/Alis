/*
  Box2DX Copyright (c) 2008 Ihar Kalasouski http://code.google.com/p/box2dx
  Box2D original C++ version Copyright (c) 2006-2007 Erin Catto http://www.gphysics.com

  This software is provided 'as-is', without any express or implied
  warranty.  In no event will the authors be held liable for any damages
  arising from the use of this software.

  Permission is granted to anyone to use this software for any purpose,
  including commercial applications, and to alter it and redistribute it
  freely, subject to the following restrictions:

  1. The origin of this software must not be misrepresented; you must not
     claim that you wrote the original software. If you use this software
     in a product, an acknowledgment in the product documentation would be
     appreciated but is not required.
  2. Altered source versions must be plainly marked as such, and must not be
     misrepresented as being the original software.
  3. This notice may not be removed or altered from any source distribution.
*/

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

using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Dynamics.Joints
{
	using Box2DXMath = Math;

    /// <summary>
	/// A revolute joint constrains to bodies to share a common point while they
	/// are free to rotate about the point. The relative rotation about the shared
	/// point is the joint angle. You can limit the relative rotation with
	/// a joint limit that specifies a lower and upper angle. You can use a motor
	/// to drive the relative rotation about the shared point. A maximum motor torque
	/// is provided so that infinite forces are not generated.
	/// </summary>
	public class RevoluteJoint : Joint
	{
        /// <summary>
        /// The local anchor
        /// </summary>
        public Vec2 LocalAnchor1 { get; }

        /// <summary>
        /// The local anchor
        /// </summary>
        public Vec2 LocalAnchor2 { get; }

        /// <summary>
		/// The impulse
		/// </summary>
		public Vec3 _impulse;

        /// <summary>
		/// The mass
		/// </summary>
		public Mat33 _mass; //effective mass for p2p constraint.

        /// <summary>
        /// The motor mass
        /// </summary>
        public float MotorMass { get; set; }

        /// <summary>
        /// The max motor torque
        /// </summary>
        public float MaxMotorTorque { get; set; }

        /// <summary>
		/// The motor speed
		/// </summary>
        private float _motorSpeed;

        /// <summary>
        /// The reference angle
        /// </summary>
        public float ReferenceAngle { get; }

        /// <summary>
        /// The limit state
        /// </summary>
        public LimitState State { get; set; }

        /// <summary>
		/// Gets the value of the anchor 1
		/// </summary>
		public override Vec2 Anchor1 => Body1.GetWorldPoint(LocalAnchor1);

        /// <summary>
		/// Gets the value of the anchor 2
		/// </summary>
		public override Vec2 Anchor2 => Body2.GetWorldPoint(LocalAnchor2);

        /// <summary>
        /// Gets the reaction force using the specified inv dt
        /// </summary>
        /// <param>The inv dt</param>
        /// <param name="inv_dt"></param>
        /// <returns>The vec</returns>
        public override Vec2 GetReactionForce(float inv_dt)
		{
			Vec2 P = new Vec2(_impulse.X, _impulse.Y);
			return inv_dt * P;
		}

        /// <summary>
        /// Gets the reaction torque using the specified inv dt
        /// </summary>
        /// <param>The inv dt</param>
        /// <param name="inv_dt"></param>
        /// <returns>The float</returns>
        public override float GetReactionTorque(float inv_dt)
		{
			return inv_dt * _impulse.Z;
		}

		/// <summary>
		/// Get the current joint angle in radians.
		/// </summary>
		public float JointAngle
		{
			get
			{
				Body b1 = Body1;
				Body b2 = Body2;
				return b2._sweep.A - b1._sweep.A - ReferenceAngle;
			}
		}


		/// <summary>
		/// Get the current joint angle speed in radians per second.
		/// </summary>
		public float JointSpeed
		{
			get
			{
				Body b1 = Body1;
				Body b2 = Body2;
				return b2._angularVelocity - b1._angularVelocity;
			}
		}

		/// <summary>
		/// Is the joint limit enabled?
		/// </summary>
		public bool IsLimitEnabled { get; set; }

        /// <summary>
		/// Enable/disable the joint limit.
		/// </summary>
		public void EnableLimit(bool flag)
		{
			Body1.WakeUp();
			Body2.WakeUp();
			IsLimitEnabled = flag;
		}

		/// <summary>
		/// Get the lower joint limit in radians.
		/// </summary>
		public float LowerLimit { get; set; }

        /// <summary>
		/// Get the upper joint limit in radians.
		/// </summary>
		public float UpperLimit { get; set; }

        /// <summary>
		/// Set the joint limits in radians.
		/// </summary>
		public void SetLimits(float lower, float upper)
		{
			Box2DXDebug.Assert(lower <= upper);
			Body1.WakeUp();
			Body2.WakeUp();
			LowerLimit = lower;
			UpperLimit = upper;
		}

		/// <summary>
		/// Is the joint motor enabled?
		/// </summary>
		public bool IsMotorEnabled { get; set; }

        /// <summary>
		/// Enable/disable the joint motor.
		/// </summary>
		public void EnableMotor(bool flag)
		{
			Body1.WakeUp();
			Body2.WakeUp();
			IsMotorEnabled = flag;
		}

		/// <summary>
		/// Get\Set the motor speed in radians per second.
		/// </summary>
		public float MotorSpeed
		{
			get { return _motorSpeed; }
			set
			{
				Body1.WakeUp();
				Body2.WakeUp();
				_motorSpeed = value;
			}
		}

		/// <summary>
		/// Set the maximum motor torque, usually in N-m.
		/// </summary>
		public void SetMaxMotorTorque(float torque)
		{
			Body1.WakeUp();
			Body2.WakeUp();
			MaxMotorTorque = torque;
		}

		/// <summary>
		/// Get the current motor torque, usually in N-m.
		/// </summary>
		public float MotorTorque { get; set; }

        /// <summary>
		/// Initializes a new instance of the <see cref="RevoluteJoint"/> class
		/// </summary>
		/// <param name="def">The def</param>
		public RevoluteJoint(RevoluteJointDef def)
			: base(def)
		{
			LocalAnchor1 = def.LocalAnchor1;
			LocalAnchor2 = def.LocalAnchor2;
			ReferenceAngle = def.ReferenceAngle;

			_impulse = new Vec3();
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
		/// Inits the velocity constraints using the specified step
		/// </summary>
		/// <param name="step">The step</param>
		internal override void InitVelocityConstraints(TimeStep step)
		{
			Body b1 = Body1;
			Body b2 = Body2;

			if (IsMotorEnabled || IsLimitEnabled)
			{
				// You cannot create a rotation limit between bodies that
				// both have fixed rotation.
				Box2DXDebug.Assert(b1._invI > 0.0f || b2._invI > 0.0f);
			}

			// Compute the effective mass matrix.
			Vec2 r1 = Box2DXMath.Mul(b1.GetXForm().R, LocalAnchor1 - b1.GetLocalCenter());
			Vec2 r2 = Box2DXMath.Mul(b2.GetXForm().R, LocalAnchor2 - b2.GetLocalCenter());

			// J = [-I -r1_skew I r2_skew]
			//     [ 0       -1 0       1]
			// r_skew = [-ry; rx]

			// Matlab
			// K = [ m1+r1y^2*i1+m2+r2y^2*i2,  -r1y*i1*r1x-r2y*i2*r2x,          -r1y*i1-r2y*i2]
			//     [  -r1y*i1*r1x-r2y*i2*r2x, m1+r1x^2*i1+m2+r2x^2*i2,           r1x*i1+r2x*i2]
			//     [          -r1y*i1-r2y*i2,           r1x*i1+r2x*i2,                   i1+i2]

			float m1 = b1._invMass, m2 = b2._invMass;
			float i1 = b1._invI, i2 = b2._invI;


            float col1x = m1 + m2 + r1.Y * r1.Y * i1 + r2.Y * r2.Y * i2;
            float col2x = -r1.Y * r1.X * i1 - r2.Y * r2.X * i2;
            float col3x = -r1.Y * i1 - r2.Y * i2;
            
            float col1y = _mass.Col2.X;
            float col2y = m1 + m2 + r1.X * r1.X * i1 + r2.X * r2.X * i2;
            float col3y = r1.X * i1 + r2.X * i2;
            
            float col1z = _mass.Col3.X;
            float col2z = _mass.Col3.Y;
            float col3z = i1 + i2;

            _mass.Col1 = new Vec3(col1x, col1y, col1z);
            _mass.Col2 = new Vec3(col2x, col2y, col2z);
            _mass.Col3 = new Vec3(col3x, col3y, col3z);
            
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
				float jointAngle = b2._sweep.A - b1._sweep.A - ReferenceAngle;
				if (Box2DXMath.Abs(UpperLimit - LowerLimit) < 2.0f * Settings.AngularSlop)
				{
					State = LimitState.EqualLimits;
				}
				else if (jointAngle <= LowerLimit)
				{
					if (State != LimitState.AtLowerLimit)
					{
						_impulse.Z = 0.0f;
					}
					State = LimitState.AtLowerLimit;
				}
				else if (jointAngle >= UpperLimit)
				{
					if (State != LimitState.AtUpperLimit)
					{
						_impulse.Z = 0.0f;
					}
					State = LimitState.AtUpperLimit;
				}
				else
				{
					State = LimitState.InactiveLimit;
					_impulse.Z = 0.0f;
				}
			}
			else
			{
				State = LimitState.InactiveLimit;
			}

			if (step.WarmStarting)
			{
				// Scale impulses to support a variable time step.
				_impulse *= step.DtRatio;
				MotorTorque *= step.DtRatio;

				Vec2 P = new Vec2(_impulse.X, _impulse.Y);

				b1._linearVelocity -= m1 * P;
				b1._angularVelocity -= i1 * (Vec2.Cross(r1, P) + MotorTorque + _impulse.Z);

				b2._linearVelocity += m2 * P;
				b2._angularVelocity += i2 * (Vec2.Cross(r2, P) + MotorTorque + _impulse.Z);
			}
			else
			{
				_impulse.SetZero();
				MotorTorque = 0.0f;
			}
		}

		/// <summary>
		/// Solves the velocity constraints using the specified step
		/// </summary>
		/// <param name="step">The step</param>
		internal override void SolveVelocityConstraints(TimeStep step)
		{
			Body b1 = Body1;
			Body b2 = Body2;

			Vec2 v1 = b1._linearVelocity;
			float w1 = b1._angularVelocity;
			Vec2 v2 = b2._linearVelocity;
			float w2 = b2._angularVelocity;

			float m1 = b1._invMass, m2 = b2._invMass;
			float i1 = b1._invI, i2 = b2._invI;

			//Solve motor constraint.
			if (IsMotorEnabled && State != LimitState.EqualLimits)
			{
				float Cdot = w2 - w1 - MotorSpeed;
				float impulse = MotorMass * -Cdot;
				float oldImpulse = MotorTorque;
				float maxImpulse = step.Dt * MaxMotorTorque;
				MotorTorque = Box2DXMath.Clamp(MotorTorque + impulse, -maxImpulse, maxImpulse);
				impulse = MotorTorque - oldImpulse;

				w1 -= i1 * impulse;
				w2 += i2 * impulse;
			}

			//Solve limit constraint.
			if (IsLimitEnabled && State != LimitState.InactiveLimit)
			{
				Vec2 r1 = Box2DXMath.Mul(b1.GetXForm().R, LocalAnchor1 - b1.GetLocalCenter());
				Vec2 r2 = Box2DXMath.Mul(b2.GetXForm().R, LocalAnchor2 - b2.GetLocalCenter());

				// Solve point-to-point constraint
				Vec2 Cdot1 = v2 + Vec2.Cross(w2, r2) - v1 - Vec2.Cross(w1, r1);
				float Cdot2 = w2 - w1;
				Vec3 Cdot = new Vec3(Cdot1.X, Cdot1.Y, Cdot2);

				Vec3 impulse = _mass.Solve33(-Cdot);

				if (State == LimitState.EqualLimits)
				{
					_impulse += impulse;
				}
				else if (State == LimitState.AtLowerLimit)
				{
					float newImpulse = _impulse.Z + impulse.Z;
					if (newImpulse < 0.0f)
					{
						Vec2 reduced = _mass.Solve22(-Cdot1);
						impulse.X = reduced.X;
						impulse.Y = reduced.Y;
						impulse.Z = -_impulse.Z;
						_impulse.X += reduced.X;
						_impulse.Y += reduced.Y;
						_impulse.Z = 0.0f;
					}
				}
				else if (State == LimitState.AtUpperLimit)
				{
					float newImpulse = _impulse.Z + impulse.Z;
					if (newImpulse > 0.0f)
					{
						Vec2 reduced = _mass.Solve22(-Cdot1);
						impulse.X = reduced.X;
						impulse.Y = reduced.Y;
						impulse.Z = -_impulse.Z;
						_impulse.X += reduced.X;
						_impulse.Y += reduced.Y;
						_impulse.Z = 0.0f;
					}
				}

				Vec2 P = new Vec2(impulse.X, impulse.Y);

				v1 -= m1 * P;
				w1 -= i1 * (Vec2.Cross(r1, P) + impulse.Z);

				v2 += m2 * P;
				w2 += i2 * (Vec2.Cross(r2, P) + impulse.Z);
			}
			else
			{
				Vec2 r1 = Box2DXMath.Mul(b1.GetXForm().R, LocalAnchor1 - b1.GetLocalCenter());
				Vec2 r2 = Box2DXMath.Mul(b2.GetXForm().R, LocalAnchor2 - b2.GetLocalCenter());

				// Solve point-to-point constraint
				Vec2 Cdot = v2 + Vec2.Cross(w2, r2) - v1 - Vec2.Cross(w1, r1);
				Vec2 impulse = _mass.Solve22(-Cdot);

				_impulse.X += impulse.X;
				_impulse.Y += impulse.Y;

				v1 -= m1 * impulse;
				w1 -= i1 * Vec2.Cross(r1, impulse);

				v2 += m2 * impulse;
				w2 += i2 * Vec2.Cross(r2, impulse);
			}

			b1._linearVelocity = v1;
			b1._angularVelocity = w1;
			b2._linearVelocity = v2;
			b2._angularVelocity = w2;
		}

		/// <summary>
		/// Describes whether this instance solve position constraints
		/// </summary>
		/// <param name="baumgarte">The baumgarte</param>
		/// <returns>The bool</returns>
		internal override bool SolvePositionConstraints(float baumgarte)
		{
			// TODO_ERIN block solve with limit.

			Body b1 = Body1;
			Body b2 = Body2;

			float angularError = 0.0f;
			float positionError = 0.0f;

			// Solve angular limit constraint.
			if (IsLimitEnabled && State !=  LimitState.InactiveLimit)
			{
				float angle = b2._sweep.A - b1._sweep.A - ReferenceAngle;
				float limitImpulse = 0.0f;

				if (State == LimitState.EqualLimits)
				{
					// Prevent large angular corrections
					float C = Box2DXMath.Clamp(angle, -Settings.MaxAngularCorrection, Settings.MaxAngularCorrection);
					limitImpulse = -MotorMass * C;
					angularError = Box2DXMath.Abs(C);
				}
				else if (State == LimitState.AtLowerLimit)
				{
					float C = angle - LowerLimit;
					angularError = -C;

					// Prevent large angular corrections and allow some slop.
					C = Box2DXMath.Clamp(C + Settings.AngularSlop, -Settings.MaxAngularCorrection, 0.0f);
					limitImpulse = -MotorMass * C;
				}
				else if (State == LimitState.AtUpperLimit)
				{
					float C = angle - UpperLimit;
					angularError = C;

					// Prevent large angular corrections and allow some slop.
					C = Box2DXMath.Clamp(C - Settings.AngularSlop, 0.0f, Settings.MaxAngularCorrection);
					limitImpulse = -MotorMass * C;
				}

				b1._sweep.A -= b1._invI * limitImpulse;
				b2._sweep.A += b2._invI * limitImpulse;

				b1.SynchronizeTransform();
				b2.SynchronizeTransform();
			}

			// Solve point-to-point constraint.
			{
				Vec2 r1 = Box2DXMath.Mul(b1.GetXForm().R, LocalAnchor1 - b1.GetLocalCenter());
				Vec2 r2 = Box2DXMath.Mul(b2.GetXForm().R, LocalAnchor2 - b2.GetLocalCenter());

				Vec2 C = b2._sweep.C + r2 - b1._sweep.C - r1;
				positionError = C.Length();

				float invMass1 = b1._invMass, invMass2 = b2._invMass;
				float invI1 = b1._invI, invI2 = b2._invI;

				// Handle large detachment.
				float k_allowedStretch = 10.0f * Settings.LinearSlop;
				if (C.LengthSquared() > k_allowedStretch * k_allowedStretch)
				{
					// Use a particle solution (no rotation).
					Vec2 u = C; u.Normalize();
					float k = invMass1 + invMass2;
					Box2DXDebug.Assert(k > Settings.FltEpsilon);
					float m = 1.0f / k;
					Vec2 impulse = m * -C;
					float k_beta = 0.5f;
					b1._sweep.C -= k_beta * invMass1 * impulse;
					b2._sweep.C += k_beta * invMass2 * impulse;

					C = b2._sweep.C + r2 - b1._sweep.C - r1;
				}

				Mat22 K1 = new Mat22();
				K1.col1.X = invMass1 + invMass2; K1.col2.X = 0.0f;
				K1.col1.Y = 0.0f; K1.col2.Y = invMass1 + invMass2;

				Mat22 K2 = new Mat22();
				K2.col1.X = invI1 * r1.Y * r1.Y; K2.col2.X = -invI1 * r1.X * r1.Y;
				K2.col1.Y = -invI1 * r1.X * r1.Y; K2.col2.Y = invI1 * r1.X * r1.X;

				Mat22 K3 = new Mat22();
				K3.col1.X = invI2 * r2.Y * r2.Y; K3.col2.X = -invI2 * r2.X * r2.Y;
				K3.col1.Y = -invI2 * r2.X * r2.Y; K3.col2.Y = invI2 * r2.X * r2.X;

				Mat22 K = K1 + K2 + K3;
				Vec2 impulse_ = K.Solve(-C);

				b1._sweep.C -= b1._invMass * impulse_;
				b1._sweep.A -= b1._invI * Vec2.Cross(r1, impulse_);

				b2._sweep.C += b2._invMass * impulse_;
				b2._sweep.A += b2._invI * Vec2.Cross(r2, impulse_);

				b1.SynchronizeTransform();
				b2.SynchronizeTransform();
			}

			return positionError <= Settings.LinearSlop && angularError <= Settings.AngularSlop;
		}
	}
}
