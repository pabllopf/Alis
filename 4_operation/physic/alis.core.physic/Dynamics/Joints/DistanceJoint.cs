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

// 1-D constrained system
// m (v2 - v1) = lambda
// v2 + (beta/h) * x1 + gamma * lambda = 0, gamma has units of inverse mass.
// x2 = x1 + h * v2

// 1-D mass-damper-spring system
// m (v2 - v1) + h * d * v2 + h * k * 

// C = norm(p2 - p1) - L
// u = (p2 - p1) / norm(p2 - p1)
// Cdot = dot(u, v2 + cross(w2, r2) - v1 - cross(w1, r1))
// J = [-u -cross(r1, u) u cross(r2, u)]
// K = J * invM * JT
//   = invMass1 + invI1 * cross(r1, u)^2 + invMass2 + invI2 * cross(r2, u)^2

using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Dynamics.Joints
{
    /// <summary>
	/// A distance joint constrains two points on two bodies
	/// to remain at a fixed distance from each other. You can view
	/// this as a massless, rigid rod.
	/// </summary>
	public class DistanceJoint : Joint
	{
		/// <summary>
		/// The local anchor
		/// </summary>
		public Vec2 LocalAnchor1;
		/// <summary>
		/// The local anchor
		/// </summary>
		public Vec2 LocalAnchor2;
		/// <summary>
		/// The 
		/// </summary>
		public Vec2 U;
		/// <summary>
		/// The frequency hz
		/// </summary>
		public float FrequencyHz;
		/// <summary>
		/// The damping ratio
		/// </summary>
		public float DampingRatio;
		/// <summary>
		/// The gamma
		/// </summary>
		public float Gamma;
		/// <summary>
		/// The bias
		/// </summary>
		public float Bias;
		/// <summary>
		/// The impulse
		/// </summary>
		public float Impulse;
		/// <summary>
		/// The mass
		/// </summary>
		public float Mass;		// effective mass for the constraint.
		/// <summary>
		/// The length
		/// </summary>
		public float Length;

		/// <summary>
		/// Gets the value of the anchor 1
		/// </summary>
		public override Vec2 Anchor1
		{
			get { return Body1.GetWorldPoint(LocalAnchor1);}
		}

		/// <summary>
		/// Gets the value of the anchor 2
		/// </summary>
		public override Vec2 Anchor2
		{
			get { return Body2.GetWorldPoint(LocalAnchor2);}
		}

		/// <summary>
		/// Gets the reaction force using the specified inv dt
		/// </summary>
		/// <param name="invDt">The inv dt</param>
		/// <returns>The vec</returns>
		public override Vec2 GetReactionForce(float invDt)
		{
			return (invDt * Impulse) * U;
		}

		/// <summary>
		/// Gets the reaction torque using the specified inv dt
		/// </summary>
		/// <param name="invDt">The inv dt</param>
		/// <returns>The float</returns>
		public override float GetReactionTorque(float invDt)
		{
			return 0.0f;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DistanceJoint"/> class
		/// </summary>
		/// <param name="def">The def</param>
		public DistanceJoint(DistanceJointDef def)
			: base(def)
		{
			LocalAnchor1 = def.LocalAnchor1;
			LocalAnchor2 = def.LocalAnchor2;
			Length = def.Length;
			FrequencyHz = def.FrequencyHz;
			DampingRatio = def.DampingRatio;
			Impulse = 0.0f;
			Gamma = 0.0f;
			Bias = 0.0f;
		}

		/// <summary>
		/// Inits the velocity constraints using the specified step
		/// </summary>
		/// <param name="step">The step</param>
		internal override void InitVelocityConstraints(TimeStep step)
		{
			Body b1 = Body1;
			Body b2 = Body2;

			// Compute the effective mass matrix.
			Vec2 r1 = Math.Mul(b1.GetXForm().R, LocalAnchor1 - b1.GetLocalCenter());
			Vec2 r2 = Math.Mul(b2.GetXForm().R, LocalAnchor2 - b2.GetLocalCenter());
			U = b2._sweep.C + r2 - b1._sweep.C - r1;

			// Handle singularity.
			float length = U.Length();
			if (length > Settings.LinearSlop)
			{
				U *= 1.0f / length;
			}
			else
			{
				U.Set(0.0f, 0.0f);
			}

			float cr1U = Vec2.Cross(r1, U);
			float cr2U = Vec2.Cross(r2, U);
			float invMass = b1._invMass + b1._invI * cr1U * cr1U + b2._invMass + b2._invI * cr2U * cr2U;
			Box2DXDebug.Assert(invMass > Settings.FltEpsilon);
			Mass = 1.0f / invMass;

			if (FrequencyHz > 0.0f)
			{
				float c = length - Length;

				// Frequency
				float omega = 2.0f * Settings.Pi * FrequencyHz;

				// Damping coefficient
				float d = 2.0f * Mass * DampingRatio * omega;

				// Spring stiffness
				float k = Mass * omega * omega;

				// magic formulas
				Gamma = 1.0f / (step.Dt * (d + step.Dt * k));
				Bias = c * step.Dt * k * Gamma;

				Mass = 1.0f / (invMass + Gamma);
			}

			if (step.WarmStarting)
			{
				//Scale the inpulse to support a variable timestep.
				Impulse *= step.DtRatio;
				Vec2 p = Impulse * U;
				b1._linearVelocity -= b1._invMass * p;
				b1._angularVelocity -= b1._invI * Vec2.Cross(r1, p);
				b2._linearVelocity += b2._invMass * p;
				b2._angularVelocity += b2._invI * Vec2.Cross(r2, p);
			}
			else
			{
				Impulse = 0.0f;
			}
		}

		/// <summary>
		/// Describes whether this instance solve position constraints
		/// </summary>
		/// <param name="baumgarte">The baumgarte</param>
		/// <returns>The bool</returns>
		internal override bool SolvePositionConstraints(float baumgarte)
		{
			if (FrequencyHz > 0.0f)
			{
				//There is no possition correction for soft distace constraint.
				return true;
			}

			Body b1 = Body1;
			Body b2 = Body2;

			Vec2 r1 = Math.Mul(b1.GetXForm().R, LocalAnchor1 - b1.GetLocalCenter());
			Vec2 r2 = Math.Mul(b2.GetXForm().R, LocalAnchor2 - b2.GetLocalCenter());

			Vec2 d = b2._sweep.C + r2 - b1._sweep.C - r1;

			float length = d.Normalize();
			float c = length - Length;
			c = Math.Clamp(c, -Settings.MaxLinearCorrection, Settings.MaxLinearCorrection);

			float impulse = -Mass * c;
			U = d;
			Vec2 p = impulse * U;

			b1._sweep.C -= b1._invMass * p;
			b1._sweep.A -= b1._invI * Vec2.Cross(r1, p);
			b2._sweep.C += b2._invMass * p;
			b2._sweep.A += b2._invI * Vec2.Cross(r2, p);

			b1.SynchronizeTransform();
			b2.SynchronizeTransform();

			return System.Math.Abs(c) < Settings.LinearSlop;
		}

		/// <summary>
		/// Solves the velocity constraints using the specified step
		/// </summary>
		/// <param name="step">The step</param>
		internal override void SolveVelocityConstraints(TimeStep step)
		{
			//B2_NOT_USED(step);

			Body b1 = Body1;
			Body b2 = Body2;

			Vec2 r1 = Math.Mul(b1.GetXForm().R, LocalAnchor1 - b1.GetLocalCenter());
			Vec2 r2 = Math.Mul(b2.GetXForm().R, LocalAnchor2 - b2.GetLocalCenter());

			// Cdot = dot(u, v + cross(w, r))
			Vec2 v1 = b1._linearVelocity + Vec2.Cross(b1._angularVelocity, r1);
			Vec2 v2 = b2._linearVelocity + Vec2.Cross(b2._angularVelocity, r2);
			float cdot = Vec2.Dot(U, v2 - v1);
			float impulse = -Mass * (cdot + Bias + Gamma * Impulse);
			Impulse += impulse;

			Vec2 p = impulse * U;
			b1._linearVelocity -= b1._invMass * p;
			b1._angularVelocity -= b1._invI * Vec2.Cross(r1, p);
			b2._linearVelocity += b2._invMass * p;
			b2._angularVelocity += b2._invI * Vec2.Cross(r2, p);
		}
	}
}
