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

using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Dynamics.Joints
{
    /// <summary>
	/// A gear joint is used to connect two joints together. Either joint
	/// can be a revolute or prismatic joint. You specify a gear ratio
	/// to bind the motions together:
	/// coordinate1 + ratio * coordinate2 = constant
	/// The ratio can be negative or positive. If one joint is a revolute joint
	/// and the other joint is a prismatic joint, then the ratio will have units
	/// of length or units of 1/length.
	/// @warning The revolute and prismatic joints must be attached to
	/// fixed bodies (which must be body1 on those joints).
	/// </summary>
	public class GearJoint : Joint
	{
        /// <summary>
        /// The ground
        /// </summary>
        public Body Ground1 { get; }

        /// <summary>
        /// The ground
        /// </summary>
        public Body Ground2 { get; }

        // One of these is NULL.

        /// <summary>
        /// The revolute
        /// </summary>
        public RevoluteJoint Revolute1 { get; }

        /// <summary>
        /// The prismatic
        /// </summary>
        public PrismaticJoint Prismatic1 { get; }

        // One of these is NULL.

        /// <summary>
        /// The revolute
        /// </summary>
        public RevoluteJoint Revolute2 { get; }

        /// <summary>
        /// The prismatic
        /// </summary>
        public PrismaticJoint Prismatic2 { get; }

        /// <summary>
        /// The ground anchor
        /// </summary>
        public Vec2 GroundAnchor1 { get; }

        /// <summary>
        /// The ground anchor
        /// </summary>
        public Vec2 GroundAnchor2 { get; }

        /// <summary>
        /// The local anchor
        /// </summary>
        public Vec2 LocalAnchor1 { get; }

        /// <summary>
        /// The local anchor
        /// </summary>
        public Vec2 LocalAnchor2 { get; }

        /// <summary>
		/// The 
		/// </summary>
		public Jacobian Jacobian;

        /// <summary>
        /// The constant
        /// </summary>
        public float Constant { get; }

        // Effective mass

        /// <summary>
        /// The mass
        /// </summary>
        public float Mass { get; set; }

        // Impulse for accumulation/warm starting.

        /// <summary>
        /// The impulse
        /// </summary>
        public float Impulse { get; set; }

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
		/// <param name="inv_dt">The inv dt</param>
		/// <returns>The vec</returns>
		public override Vec2 GetReactionForce(float inv_dt)
		{
			// TODO_ERIN not tested
			Vec2 P = Impulse * Jacobian.Linear2;
			return inv_dt * P;
		}

		/// <summary>
		/// Gets the reaction torque using the specified inv dt
		/// </summary>
		/// <param name="inv_dt">The inv dt</param>
		/// <returns>The float</returns>
		public override float GetReactionTorque(float inv_dt)
		{
			// TODO_ERIN not tested
			Vec2 r = Math.Mul(Body2.GetXForm().R, LocalAnchor2 - Body2.GetLocalCenter());
			Vec2 P = Impulse * Jacobian.Linear2;
			float L = Impulse * Jacobian.Angular2 - Vec2.Cross(r, P);
			return inv_dt * L;
		}

		/// <summary>
		/// Get the gear ratio.
		/// </summary>
		public float Ratio { get; set; }

        /// <summary>
		/// Initializes a new instance of the <see cref="GearJoint"/> class
		/// </summary>
		/// <param name="def">The def</param>
		public GearJoint(GearJointDef def)
			: base(def)
		{
			JointType type1 = def.Joint1.GetType();
			JointType type2 = def.Joint2.GetType();

			Box2DXDebug.Assert(type1 == JointType.RevoluteJoint || type1 == JointType.PrismaticJoint);
			Box2DXDebug.Assert(type2 == JointType.RevoluteJoint || type2 == JointType.PrismaticJoint);
			Box2DXDebug.Assert(def.Joint1.GetBody1().IsStatic());
			Box2DXDebug.Assert(def.Joint2.GetBody1().IsStatic());

			Revolute1 = null;
			Prismatic1 = null;
			Revolute2 = null;
			Prismatic2 = null;

			float coordinate1, coordinate2;

			Ground1 = def.Joint1.GetBody1();
			Body1 = def.Joint1.GetBody2();
			if (type1 == JointType.RevoluteJoint)
			{
				Revolute1 = (RevoluteJoint)def.Joint1;
				GroundAnchor1 = Revolute1.LocalAnchor1;
				LocalAnchor1 = Revolute1.LocalAnchor2;
				coordinate1 = Revolute1.JointAngle;
			}
			else
			{
				Prismatic1 = (PrismaticJoint)def.Joint1;
				GroundAnchor1 = Prismatic1._localAnchor1;
				LocalAnchor1 = Prismatic1._localAnchor2;
				coordinate1 = Prismatic1.JointTranslation;
			}

			Ground2 = def.Joint2.GetBody1();
			Body2 = def.Joint2.GetBody2();
			if (type2 == JointType.RevoluteJoint)
			{
				Revolute2 = (RevoluteJoint)def.Joint2;
				GroundAnchor2 = Revolute2.LocalAnchor1;
				LocalAnchor2 = Revolute2.LocalAnchor2;
				coordinate2 = Revolute2.JointAngle;
			}
			else
			{
				Prismatic2 = (PrismaticJoint)def.Joint2;
				GroundAnchor2 = Prismatic2._localAnchor1;
				LocalAnchor2 = Prismatic2._localAnchor2;
				coordinate2 = Prismatic2.JointTranslation;
			}

			Ratio = def.Ratio;

			Constant = coordinate1 + Ratio * coordinate2;

			Impulse = 0.0f;
		}

		/// <summary>
		/// Inits the velocity constraints using the specified step
		/// </summary>
		/// <param name="step">The step</param>
		internal override void InitVelocityConstraints(TimeStep step)
		{
			Body g1 = Ground1;
			Body g2 = Ground2;
			Body b1 = Body1;
			Body b2 = Body2;

			float K = 0.0f;
			Jacobian.SetZero();

			if (Revolute1!=null)
			{
				Jacobian.Angular1 = -1.0f;
				K += b1._invI;
			}
			else
			{
				Vec2 ug = Math.Mul(g1.GetXForm().R, Prismatic1._localXAxis1);
				Vec2 r = Math.Mul(b1.GetXForm().R, LocalAnchor1 - b1.GetLocalCenter());
				float crug = Vec2.Cross(r, ug);
				Jacobian.Linear1 = -ug;
				Jacobian.Angular1 = -crug;
				K += b1._invMass + b1._invI * crug * crug;
			}

			if (Revolute2!=null)
			{
				Jacobian.Angular2 = -Ratio;
				K += Ratio * Ratio * b2._invI;
			}
			else
			{
				Vec2 ug = Math.Mul(g2.GetXForm().R, Prismatic2._localXAxis1);
				Vec2 r = Math.Mul(b2.GetXForm().R, LocalAnchor2 - b2.GetLocalCenter());
				float crug = Vec2.Cross(r, ug);
				Jacobian.Linear2 = -Ratio * ug;
				Jacobian.Angular2 = -Ratio * crug;
				K += Ratio * Ratio * (b2._invMass + b2._invI * crug * crug);
			}

			// Compute effective mass.
			Box2DXDebug.Assert(K > 0.0f);
			Mass = 1.0f / K;

			if (step.WarmStarting)
			{
				// Warm starting.
				b1._linearVelocity += b1._invMass * Impulse * Jacobian.Linear1;
				b1._angularVelocity += b1._invI * Impulse * Jacobian.Angular1;
				b2._linearVelocity += b2._invMass * Impulse * Jacobian.Linear2;
				b2._angularVelocity += b2._invI * Impulse * Jacobian.Angular2;
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
		internal override void SolveVelocityConstraints(TimeStep step)
		{
			Body b1 = Body1;
			Body b2 = Body2;

			float Cdot = Jacobian.Compute(b1._linearVelocity, b1._angularVelocity, b2._linearVelocity, b2._angularVelocity);

			float impulse = Mass * (-Cdot);
			Impulse += impulse;

			b1._linearVelocity += b1._invMass * impulse * Jacobian.Linear1;
			b1._angularVelocity += b1._invI * impulse * Jacobian.Angular1;
			b2._linearVelocity += b2._invMass * impulse * Jacobian.Linear2;
			b2._angularVelocity += b2._invI * impulse * Jacobian.Angular2;
		}

		/// <summary>
		/// Describes whether this instance solve position constraints
		/// </summary>
		/// <param name="baumgarte">The baumgarte</param>
		/// <returns>The bool</returns>
		internal override bool SolvePositionConstraints(float baumgarte)
		{
			float linearError = 0.0f;

			Body b1 = Body1;
			Body b2 = Body2;

			float coordinate1, coordinate2;
			if (Revolute1 != null)
			{
				coordinate1 = Revolute1.JointAngle;
			}
			else
			{
				coordinate1 = Prismatic1.JointTranslation;
			}

			if (Revolute2 != null)
			{
				coordinate2 = Revolute2.JointAngle;
			}
			else
			{
				coordinate2 = Prismatic2.JointTranslation;
			}

			float C = Constant - (coordinate1 + Ratio * coordinate2);

			float impulse = Mass * (-C);

			b1._sweep.C += b1._invMass * impulse * Jacobian.Linear1;
			b1._sweep.A += b1._invI * impulse * Jacobian.Angular1;
			b2._sweep.C += b2._invMass * impulse * Jacobian.Linear2;
			b2._sweep.A += b2._invI * impulse * Jacobian.Angular2;

			b1.SynchronizeTransform();
			b2.SynchronizeTransform();

			//TODO_ERIN not implemented
			return linearError < Settings.LinearSlop;
		}
	}
}
