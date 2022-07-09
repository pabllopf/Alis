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

// p = attached point, m = mouse point
// C = p - m
// Cdot = v
//      = v + cross(w, r)
// J = [I r_skew]
// Identity used:
// w k % (rx i + ry j) = w * (-ry i + rx j)

using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Dynamics.Joints
{
    /// <summary>
	/// A mouse joint is used to make a point on a body track a
	/// specified world point. This a soft constraint with a maximum
	/// force. This allows the constraint to stretch and without
	/// applying huge forces.
	/// </summary>
	public class MouseJoint : Joint
	{
		/// <summary>
		/// The local anchor
		/// </summary>
		public Vec2 _localAnchor;
		/// <summary>
		/// The target
		/// </summary>
		public Vec2 _target;
		/// <summary>
		/// The impulse
		/// </summary>
		public Vec2 _impulse;

		/// <summary>
		/// The mass
		/// </summary>
		public Mat22 _mass;		// effective mass for point-to-point constraint.
		/// <summary>
		/// The 
		/// </summary>
		public Vec2 _C;				// position error
		/// <summary>
		/// The max force
		/// </summary>
		public float _maxForce;
		/// <summary>
		/// The frequency hz
		/// </summary>
		public float _frequencyHz;
		/// <summary>
		/// The damping ratio
		/// </summary>
		public float _dampingRatio;
		/// <summary>
		/// The beta
		/// </summary>
		public float _beta;
		/// <summary>
		/// The gamma
		/// </summary>
		public float _gamma;

		/// <summary>
		/// Gets the value of the anchor 1
		/// </summary>
		public override Vec2 Anchor1
		{
			get { return _target; }
		}

		/// <summary>
		/// Gets the value of the anchor 2
		/// </summary>
		public override Vec2 Anchor2
		{
			get { return _body2.GetWorldPoint(_localAnchor); }
		}

		/// <summary>
		/// Gets the reaction force using the specified inv dt
		/// </summary>
		/// <param name="inv_dt">The inv dt</param>
		/// <returns>The vec</returns>
		public override Vec2 GetReactionForce(float inv_dt)
		{
			return inv_dt * _impulse;
		}

		/// <summary>
		/// Gets the reaction torque using the specified inv dt
		/// </summary>
		/// <param name="inv_dt">The inv dt</param>
		/// <returns>The float</returns>
		public override float GetReactionTorque(float inv_dt)
		{
			return inv_dt * 0.0f;
		}

		/// <summary>
		/// Use this to update the target point.
		/// </summary>
		public void SetTarget(Vec2 target)
		{
			if (_body2.IsSleeping())
			{
				_body2.WakeUp();
			}
			_target = target;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="MouseJoint"/> class
		/// </summary>
		/// <param name="def">The def</param>
		public MouseJoint(MouseJointDef def)
			: base(def)
		{
			_target = def.Target;
			_localAnchor = Math.MulT(_body2.GetXForm(), _target);

			_maxForce = def.MaxForce;
			_impulse.SetZero();

			_frequencyHz = def.FrequencyHz;
			_dampingRatio = def.DampingRatio;

			_beta = 0.0f;
			_gamma = 0.0f;
		}

		/// <summary>
		/// Inits the velocity constraints using the specified step
		/// </summary>
		/// <param name="step">The step</param>
		internal override void InitVelocityConstraints(TimeStep step)
		{
			Body b = _body2;

			float mass = b.GetMass();

			// Frequency
			float omega = 2.0f * Settings.Pi * _frequencyHz;

			// Damping coefficient
			float d = 2.0f * mass * _dampingRatio * omega;

			// Spring stiffness
			float k = mass * (omega * omega);

			// magic formulas
			// gamma has units of inverse mass.
			// beta has units of inverse time.
			Box2DXDebug.Assert(d + step.Dt * k > Settings.FltEpsilon);
			_gamma = 1.0f / (step.Dt * (d + step.Dt * k));
			_beta = step.Dt * k * _gamma;

			// Compute the effective mass matrix.
			Vec2 r = Math.Mul(b.GetXForm().R, _localAnchor - b.GetLocalCenter());

			// K    = [(1/m1 + 1/m2) * eye(2) - skew(r1) * invI1 * skew(r1) - skew(r2) * invI2 * skew(r2)]
			//      = [1/m1+1/m2     0    ] + invI1 * [r1.y*r1.y -r1.x*r1.y] + invI2 * [r1.y*r1.y -r1.x*r1.y]
			//        [    0     1/m1+1/m2]           [-r1.x*r1.y r1.x*r1.x]           [-r1.x*r1.y r1.x*r1.x]
			float invMass = b._invMass;
			float invI = b._invI;

			Mat22 K1 = new Mat22();
			K1.col1.X = invMass; K1.col2.X = 0.0f;
			K1.col1.Y = 0.0f; K1.col2.Y = invMass;

			Mat22 K2 = new Mat22();
			K2.col1.X = invI * r.Y * r.Y; K2.col2.X = -invI * r.X * r.Y;
			K2.col1.Y = -invI * r.X * r.Y; K2.col2.Y = invI * r.X * r.X;

			Mat22 K = K1 + K2;
			K.col1.X += _gamma;
			K.col2.Y += _gamma;

			_mass = K.GetInverse();

			_C = b._sweep.C + r - _target;

			// Cheat with some damping
			b._angularVelocity *= 0.98f;

			// Warm starting.
			_impulse *= step.DtRatio;
			b._linearVelocity += invMass * _impulse;
			b._angularVelocity += invI * Vec2.Cross(r, _impulse);
		}

		/// <summary>
		/// Solves the velocity constraints using the specified step
		/// </summary>
		/// <param name="step">The step</param>
		internal override void SolveVelocityConstraints(TimeStep step)
		{
			Body b = _body2;

			Vec2 r = Math.Mul(b.GetXForm().R, _localAnchor - b.GetLocalCenter());

			// Cdot = v + cross(w, r)
			Vec2 Cdot = b._linearVelocity + Vec2.Cross(b._angularVelocity, r);
			Vec2 impulse = Math.Mul(_mass, -(Cdot + _beta * _C + _gamma * _impulse));

			Vec2 oldImpulse = _impulse;
			_impulse += impulse;
			float maxImpulse = step.Dt * _maxForce;
			if (_impulse.LengthSquared() > maxImpulse * maxImpulse)
			{
				_impulse *= maxImpulse / _impulse.Length();
			}
			impulse = _impulse - oldImpulse;

			b._linearVelocity += b._invMass * impulse;
			b._angularVelocity += b._invI * Vec2.Cross(r, impulse);
		}

		/// <summary>
		/// Describes whether this instance solve position constraints
		/// </summary>
		/// <param name="baumgarte">The baumgarte</param>
		/// <returns>The bool</returns>
		internal override bool SolvePositionConstraints(float baumgarte)
		{
			return true;
		}
	}
}
