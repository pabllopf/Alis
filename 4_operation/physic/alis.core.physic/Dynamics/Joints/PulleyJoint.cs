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

using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Dynamics.Joints
{
	using Box2DXMath = Math;

    /// <summary>
	/// The pulley joint is connected to two bodies and two fixed ground points.
	/// The pulley supports a ratio such that:
	/// length1 + ratio * length2 constant
	/// Yes, the force transmitted is scaled by the ratio.
	/// The pulley also enforces a maximum length limit on both sides. This is
	/// useful to prevent one side of the pulley hitting the top.
	/// </summary>
	public class PulleyJoint : Joint
	{
		/// <summary>
		/// The min pulley length
		/// </summary>
		public static readonly float MinPulleyLength = 2.0f;

		/// <summary>
		/// The ground
		/// </summary>
		public Body _ground;
		/// <summary>
		/// The ground anchor
		/// </summary>
		public Vec2 _groundAnchor1;
		/// <summary>
		/// The ground anchor
		/// </summary>
		public Vec2 _groundAnchor2;
		/// <summary>
		/// The local anchor
		/// </summary>
		public Vec2 _localAnchor1;
		/// <summary>
		/// The local anchor
		/// </summary>
		public Vec2 _localAnchor2;

		/// <summary>
		/// The 
		/// </summary>
		public Vec2 _u1;
		/// <summary>
		/// The 
		/// </summary>
		public Vec2 _u2;

		/// <summary>
		/// The constant
		/// </summary>
		public float _constant;
		/// <summary>
		/// The ratio
		/// </summary>
		public float _ratio;

		/// <summary>
		/// The max length
		/// </summary>
		public float _maxLength1;
		/// <summary>
		/// The max length
		/// </summary>
		public float _maxLength2;

		// Effective masses
		/// <summary>
		/// The pulley mass
		/// </summary>
		public float _pulleyMass;
		/// <summary>
		/// The limit mass
		/// </summary>
		public float _limitMass1;
		/// <summary>
		/// The limit mass
		/// </summary>
		public float _limitMass2;

		// Impulses for accumulation/warm starting.
		/// <summary>
		/// The impulse
		/// </summary>
		public float _impulse;
		/// <summary>
		/// The limit impulse
		/// </summary>
		public float _limitImpulse1;
		/// <summary>
		/// The limit impulse
		/// </summary>
		public float _limitImpulse2;

		/// <summary>
		/// The state
		/// </summary>
		public LimitState _state;
		/// <summary>
		/// The limit state
		/// </summary>
		public LimitState _limitState1;
		/// <summary>
		/// The limit state
		/// </summary>
		public LimitState _limitState2;

		/// <summary>
		/// Gets the value of the anchor 1
		/// </summary>
		public override Vec2 Anchor1
		{
			get { return _body1.GetWorldPoint(_localAnchor1); }
		}

		/// <summary>
		/// Gets the value of the anchor 2
		/// </summary>
		public override Vec2 Anchor2
		{
			get { return _body2.GetWorldPoint(_localAnchor2); }
		}

		/// <summary>
		/// Gets the reaction force using the specified inv dt
		/// </summary>
		/// <param name="inv_dt">The inv dt</param>
		/// <returns>The vec</returns>
		public override Vec2 GetReactionForce(float inv_dt)
		{
			Vec2 P = _impulse * _u2;
			return inv_dt * P;
		}

		/// <summary>
		/// Gets the reaction torque using the specified inv dt
		/// </summary>
		/// <param name="inv_dt">The inv dt</param>
		/// <returns>The float</returns>
		public override float GetReactionTorque(float inv_dt)
		{
			return 0.0f;
		}

		/// <summary>
		/// Get the first ground anchor.
		/// </summary>
		public Vec2 GroundAnchor1
		{
			get { return _ground.GetXForm().Position + _groundAnchor1; }
		}

		/// <summary>
		/// Get the second ground anchor.
		/// </summary>
		public Vec2 GroundAnchor2
		{
			get { return _ground.GetXForm().Position + _groundAnchor2; }
		}

		/// <summary>
		/// Get the current length of the segment attached to body1.
		/// </summary>
		public float Length1
		{
			get
			{
				Vec2 p = _body1.GetWorldPoint(_localAnchor1);
				Vec2 s = _ground.GetXForm().Position + _groundAnchor1;
				Vec2 d = p - s;
				return d.Length();
			}
		}

		/// <summary>
		/// Get the current length of the segment attached to body2.
		/// </summary>
		public float Length2
		{
			get
			{
				Vec2 p = _body2.GetWorldPoint(_localAnchor2);
				Vec2 s = _ground.GetXForm().Position + _groundAnchor2;
				Vec2 d = p - s;
				return d.Length();
			}
		}

		/// <summary>
		/// Get the pulley ratio.
		/// </summary>
		public float Ratio
		{
			get { return _ratio; }
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="PulleyJoint"/> class
		/// </summary>
		/// <param name="def">The def</param>
		public PulleyJoint(PulleyJointDef def)
			: base(def)
		{
			_ground = _body1.GetWorld().GetGroundBody();
			_groundAnchor1 = def.GroundAnchor1 - _ground.GetXForm().Position;
			_groundAnchor2 = def.GroundAnchor2 - _ground.GetXForm().Position;
			_localAnchor1 = def.LocalAnchor1;
			_localAnchor2 = def.LocalAnchor2;

			Box2DXDebug.Assert(def.Ratio != 0.0f);
			_ratio = def.Ratio;

			_constant = def.Length1 + _ratio * def.Length2;

			_maxLength1 = Math.Min(def.MaxLength1, _constant - _ratio * MinPulleyLength);
			_maxLength2 = Math.Min(def.MaxLength2, (_constant - MinPulleyLength) / _ratio);

			_impulse = 0.0f;
			_limitImpulse1 = 0.0f;
			_limitImpulse2 = 0.0f;
		}

		/// <summary>
		/// Inits the velocity constraints using the specified step
		/// </summary>
		/// <param name="step">The step</param>
		internal override void InitVelocityConstraints(TimeStep step)
		{
			Body b1 = _body1;
			Body b2 = _body2;

			Vec2 r1 = Box2DXMath.Mul(b1.GetXForm().R, _localAnchor1 - b1.GetLocalCenter());
			Vec2 r2 = Box2DXMath.Mul(b2.GetXForm().R, _localAnchor2 - b2.GetLocalCenter());

			Vec2 p1 = b1._sweep.C + r1;
			Vec2 p2 = b2._sweep.C + r2;

			Vec2 s1 = _ground.GetXForm().Position + _groundAnchor1;
			Vec2 s2 = _ground.GetXForm().Position + _groundAnchor2;

			// Get the pulley axes.
			_u1 = p1 - s1;
			_u2 = p2 - s2;

			float length1 = _u1.Length();
			float length2 = _u2.Length();

			if (length1 > Settings.LinearSlop)
			{
				_u1 *= 1.0f / length1;
			}
			else
			{
				_u1.SetZero();
			}

			if (length2 > Settings.LinearSlop)
			{
				_u2 *= 1.0f / length2;
			}
			else
			{
				_u2.SetZero();
			}

			float C = _constant - length1 - _ratio * length2;
			if (C > 0.0f)
			{
				_state = LimitState.InactiveLimit;
				_impulse = 0.0f;
			}
			else
			{
				_state = LimitState.AtUpperLimit;
			}

			if (length1 < _maxLength1)
			{
				_limitState1 = LimitState.InactiveLimit;
				_limitImpulse1 = 0.0f;
			}
			else
			{
				_limitState1 = LimitState.AtUpperLimit;
			}

			if (length2 < _maxLength2)
			{
				_limitState2 = LimitState.InactiveLimit;
				_limitImpulse2 = 0.0f;
			}
			else
			{
				_limitState2 = LimitState.AtUpperLimit;
			}

			// Compute effective mass.
			float cr1u1 = Vec2.Cross(r1, _u1);
			float cr2u2 = Vec2.Cross(r2, _u2);

			_limitMass1 = b1._invMass + b1._invI * cr1u1 * cr1u1;
			_limitMass2 = b2._invMass + b2._invI * cr2u2 * cr2u2;
			_pulleyMass = _limitMass1 + _ratio * _ratio * _limitMass2;
			Box2DXDebug.Assert(_limitMass1 > Settings.FLT_EPSILON);
			Box2DXDebug.Assert(_limitMass2 > Settings.FLT_EPSILON);
			Box2DXDebug.Assert(_pulleyMass > Settings.FLT_EPSILON);
			_limitMass1 = 1.0f / _limitMass1;
			_limitMass2 = 1.0f / _limitMass2;
			_pulleyMass = 1.0f / _pulleyMass;

			if (step.WarmStarting)
			{
				// Scale impulses to support variable time steps.
				_impulse *= step.DtRatio;
				_limitImpulse1 *= step.DtRatio;
				_limitImpulse2 *= step.DtRatio;

				// Warm starting.
				Vec2 P1 = -(_impulse + _limitImpulse1) * _u1;
				Vec2 P2 = (-_ratio * _impulse - _limitImpulse2) * _u2;
				b1._linearVelocity += b1._invMass * P1;
				b1._angularVelocity += b1._invI * Vec2.Cross(r1, P1);
				b2._linearVelocity += b2._invMass * P2;
				b2._angularVelocity += b2._invI * Vec2.Cross(r2, P2);
			}
			else
			{
				_impulse = 0.0f;
				_limitImpulse1 = 0.0f;
				_limitImpulse2 = 0.0f;
			}
		}

		/// <summary>
		/// Solves the velocity constraints using the specified step
		/// </summary>
		/// <param name="step">The step</param>
		internal override void SolveVelocityConstraints(TimeStep step)
		{
			Body b1 = _body1;
			Body b2 = _body2;

			Vec2 r1 = Box2DXMath.Mul(b1.GetXForm().R, _localAnchor1 - b1.GetLocalCenter());
			Vec2 r2 = Box2DXMath.Mul(b2.GetXForm().R, _localAnchor2 - b2.GetLocalCenter());

			if (_state == LimitState.AtUpperLimit)
			{
				Vec2 v1 = b1._linearVelocity + Vec2.Cross(b1._angularVelocity, r1);
				Vec2 v2 = b2._linearVelocity + Vec2.Cross(b2._angularVelocity, r2);

				float Cdot = -Vec2.Dot(_u1, v1) - _ratio * Vec2.Dot(_u2, v2);
				float impulse = _pulleyMass * (-Cdot);
				float oldImpulse = _impulse;
				_impulse = Box2DXMath.Max(0.0f, _impulse + impulse);
				impulse = _impulse - oldImpulse;

				Vec2 P1 = -impulse * _u1;
				Vec2 P2 = -_ratio * impulse * _u2;
				b1._linearVelocity += b1._invMass * P1;
				b1._angularVelocity += b1._invI * Vec2.Cross(r1, P1);
				b2._linearVelocity += b2._invMass * P2;
				b2._angularVelocity += b2._invI * Vec2.Cross(r2, P2);
			}

			if (_limitState1 == LimitState.AtUpperLimit)
			{
				Vec2 v1 = b1._linearVelocity + Vec2.Cross(b1._angularVelocity, r1);

				float Cdot = -Vec2.Dot(_u1, v1);
				float impulse = -_limitMass1 * Cdot;
				float oldImpulse = _limitImpulse1;
				_limitImpulse1 = Box2DXMath.Max(0.0f, _limitImpulse1 + impulse);
				impulse = _limitImpulse1 - oldImpulse;

				Vec2 P1 = -impulse * _u1;
				b1._linearVelocity += b1._invMass * P1;
				b1._angularVelocity += b1._invI * Vec2.Cross(r1, P1);
			}

			if (_limitState2 == LimitState.AtUpperLimit)
			{
				Vec2 v2 = b2._linearVelocity + Vec2.Cross(b2._angularVelocity, r2);

				float Cdot = -Vec2.Dot(_u2, v2);
				float impulse = -_limitMass2 * Cdot;
				float oldImpulse = _limitImpulse2;
				_limitImpulse2 = Box2DXMath.Max(0.0f, _limitImpulse2 + impulse);
				impulse = _limitImpulse2 - oldImpulse;

				Vec2 P2 = -impulse * _u2;
				b2._linearVelocity += b2._invMass * P2;
				b2._angularVelocity += b2._invI * Vec2.Cross(r2, P2);
			}
		}

		/// <summary>
		/// Describes whether this instance solve position constraints
		/// </summary>
		/// <param name="baumgarte">The baumgarte</param>
		/// <returns>The bool</returns>
		internal override bool SolvePositionConstraints(float baumgarte)
		{
			Body b1 = _body1;
			Body b2 = _body2;

			Vec2 s1 = _ground.GetXForm().Position + _groundAnchor1;
			Vec2 s2 = _ground.GetXForm().Position + _groundAnchor2;

			float linearError = 0.0f;

			if (_state == LimitState.AtUpperLimit)
			{
				Vec2 r1 = Box2DXMath.Mul(b1.GetXForm().R, _localAnchor1 - b1.GetLocalCenter());
				Vec2 r2 = Box2DXMath.Mul(b2.GetXForm().R, _localAnchor2 - b2.GetLocalCenter());

				Vec2 p1 = b1._sweep.C + r1;
				Vec2 p2 = b2._sweep.C + r2;

				// Get the pulley axes.
				_u1 = p1 - s1;
				_u2 = p2 - s2;

				float length1 = _u1.Length();
				float length2 = _u2.Length();

				if (length1 > Settings.LinearSlop)
				{
					_u1 *= 1.0f / length1;
				}
				else
				{
					_u1.SetZero();
				}

				if (length2 > Settings.LinearSlop)
				{
					_u2 *= 1.0f / length2;
				}
				else
				{
					_u2.SetZero();
				}

				float C = _constant - length1 - _ratio * length2;
				linearError = Box2DXMath.Max(linearError, -C);

				C = Box2DXMath.Clamp(C + Settings.LinearSlop, -Settings.MaxLinearCorrection, 0.0f);
				float impulse = -_pulleyMass * C;

				Vec2 P1 = -impulse * _u1;
				Vec2 P2 = -_ratio * impulse * _u2;

				b1._sweep.C += b1._invMass * P1;
				b1._sweep.A += b1._invI * Vec2.Cross(r1, P1);
				b2._sweep.C += b2._invMass * P2;
				b2._sweep.A += b2._invI * Vec2.Cross(r2, P2);

				b1.SynchronizeTransform();
				b2.SynchronizeTransform();
			}

			if (_limitState1 == LimitState.AtUpperLimit)
			{
				Vec2 r1 = Box2DXMath.Mul(b1.GetXForm().R, _localAnchor1 - b1.GetLocalCenter());
				Vec2 p1 = b1._sweep.C + r1;

				_u1 = p1 - s1;
				float length1 = _u1.Length();

				if (length1 > Settings.LinearSlop)
				{
					_u1 *= 1.0f / length1;
				}
				else
				{
					_u1.SetZero();
				}

				float C = _maxLength1 - length1;
				linearError = Box2DXMath.Max(linearError, -C);
				C = Box2DXMath.Clamp(C + Settings.LinearSlop, -Settings.MaxLinearCorrection, 0.0f);
				float impulse = -_limitMass1 * C;

				Vec2 P1 = -impulse * _u1;
				b1._sweep.C += b1._invMass * P1;
				b1._sweep.A += b1._invI * Vec2.Cross(r1, P1);

				b1.SynchronizeTransform();
			}

			if (_limitState2 == LimitState.AtUpperLimit)
			{
				Vec2 r2 = Box2DXMath.Mul(b2.GetXForm().R, _localAnchor2 - b2.GetLocalCenter());
				Vec2 p2 = b2._sweep.C + r2;

				_u2 = p2 - s2;
				float length2 = _u2.Length();

				if (length2 > Settings.LinearSlop)
				{
					_u2 *= 1.0f / length2;
				}
				else
				{
					_u2.SetZero();
				}

				float C = _maxLength2 - length2;
				linearError = Box2DXMath.Max(linearError, -C);
				C = Box2DXMath.Clamp(C + Settings.LinearSlop, -Settings.MaxLinearCorrection, 0.0f);
				float impulse = -_limitMass2 * C;

				Vec2 P2 = -impulse * _u2;
				b2._sweep.C += b2._invMass * P2;
				b2._sweep.A += b2._invI * Vec2.Cross(r2, P2);

				b2.SynchronizeTransform();
			}

			return linearError < Settings.LinearSlop;
		}
	}
}
