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

using Box2D.NetStandard.Common;

namespace Box2D.NetStandard.Dynamics.Joints
{
	/// <summary>
	/// The joint type enum
	/// </summary>
	public enum JointType
	{
		/// <summary>
		/// The unknown joint joint type
		/// </summary>
		UnknownJoint,
		/// <summary>
		/// The revolute joint joint type
		/// </summary>
		RevoluteJoint,
		/// <summary>
		/// The prismatic joint joint type
		/// </summary>
		PrismaticJoint,
		/// <summary>
		/// The distance joint joint type
		/// </summary>
		DistanceJoint,
		/// <summary>
		/// The pulley joint joint type
		/// </summary>
		PulleyJoint,
		/// <summary>
		/// The mouse joint joint type
		/// </summary>
		MouseJoint,
		/// <summary>
		/// The gear joint joint type
		/// </summary>
		GearJoint,
		/// <summary>
		/// The line joint joint type
		/// </summary>
		LineJoint
	}

	/// <summary>
	/// The limit state enum
	/// </summary>
	public enum LimitState
	{
		/// <summary>
		/// The inactive limit limit state
		/// </summary>
		InactiveLimit,
		/// <summary>
		/// The at lower limit limit state
		/// </summary>
		AtLowerLimit,
		/// <summary>
		/// The at upper limit limit state
		/// </summary>
		AtUpperLimit,
		/// <summary>
		/// The equal limits limit state
		/// </summary>
		EqualLimits
	}

	/// <summary>
	/// The jacobian
	/// </summary>
	public struct Jacobian
	{
		/// <summary>
		/// The linear
		/// </summary>
		public Vec2 Linear1;
		/// <summary>
		/// The angular
		/// </summary>
		public float Angular1;
		/// <summary>
		/// The linear
		/// </summary>
		public Vec2 Linear2;
		/// <summary>
		/// The angular
		/// </summary>
		public float Angular2;

		/// <summary>
		/// Sets the zero
		/// </summary>
		public void SetZero()
		{
			Linear1.SetZero(); Angular1 = 0.0f;
			Linear2.SetZero(); Angular2 = 0.0f;
		}

		/// <summary>
		/// Sets the x 1
		/// </summary>
		/// <param name="x1">The </param>
		/// <param name="a1">The </param>
		/// <param name="x2">The </param>
		/// <param name="a2">The </param>
		public void Set(Vec2 x1, float a1, Vec2 x2, float a2)
		{
			Linear1 = x1; Angular1 = a1;
			Linear2 = x2; Angular2 = a2;
		}

		/// <summary>
		/// Computes the x 1
		/// </summary>
		/// <param name="x1">The </param>
		/// <param name="a1">The </param>
		/// <param name="x2">The </param>
		/// <param name="a2">The </param>
		/// <returns>The float</returns>
		public float Compute(Vec2 x1, float a1, Vec2 x2, float a2)
		{
			return Vec2.Dot(Linear1, x1) + Angular1 * a1 + Vec2.Dot(Linear2, x2) + Angular2 * a2;
		}
	}


	/// <summary>
	/// A joint edge is used to connect bodies and joints together
	/// in a joint graph where each body is a node and each joint
	/// is an edge. A joint edge belongs to a doubly linked list
	/// maintained in each attached body. Each joint has two joint
	/// nodes, one for each attached body.
	/// </summary>
	public class JointEdge
	{
		/// <summary>
		/// Provides quick access to the other body attached.
		/// </summary>
		public Body Other;

		/// <summary>
		/// The joint.
		/// </summary>
		public Joint Joint;

		/// <summary>
		/// The previous joint edge in the body's joint list.
		/// </summary>
		public JointEdge Prev;

		/// <summary>
		/// The next joint edge in the body's joint list.
		/// </summary>
		public JointEdge Next;
	}


	/// <summary>
	/// Joint definitions are used to construct joints.
	/// </summary>
	public class JointDef
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="JointDef"/> class
		/// </summary>
		public JointDef()
		{
			Type = JointType.UnknownJoint;
			UserData = null;
			Body1 = null;
			Body2 = null;
			CollideConnected = false;
		}

		/// <summary>
		/// The joint type is set automatically for concrete joint types.
		/// </summary>
		public JointType Type;

		/// <summary>
		/// Use this to attach application specific data to your joints.
		/// </summary>
		public object UserData;

		/// <summary>
		/// The first attached body.
		/// </summary>
		public Body Body1;

		/// <summary>
		/// The second attached body.
		/// </summary>
		public Body Body2;

		/// <summary>
		/// Set this flag to true if the attached bodies should collide.
		/// </summary>
		public bool CollideConnected;
	}

	/// <summary>
	/// The base joint class. Joints are used to constraint two bodies together in
	/// various fashions. Some joints also feature limits and motors.
	/// </summary>
	public abstract class Joint
	{
		/// <summary>
		/// The type
		/// </summary>
		protected JointType _type;
		/// <summary>
		/// The prev
		/// </summary>
		internal Joint _prev;
		/// <summary>
		/// The next
		/// </summary>
		internal Joint _next;
		/// <summary>
		/// The joint edge
		/// </summary>
		internal JointEdge _node1 = new JointEdge();
		/// <summary>
		/// The joint edge
		/// </summary>
		internal JointEdge _node2 = new JointEdge();
		/// <summary>
		/// The body
		/// </summary>
		internal Body _body1;
		/// <summary>
		/// The body
		/// </summary>
		internal Body _body2;

		/// <summary>
		/// The island flag
		/// </summary>
		internal bool _islandFlag;
		/// <summary>
		/// The collide connected
		/// </summary>
		internal bool _collideConnected;

		/// <summary>
		/// The user data
		/// </summary>
		protected object _userData;

		// Cache here per time step to reduce cache misses.
		/// <summary>
		/// The local center
		/// </summary>
		protected Vec2 _localCenter1, _localCenter2;
		/// <summary>
		/// The inv
		/// </summary>
		protected float _invMass1, _invI1;
		/// <summary>
		/// The inv
		/// </summary>
		protected float _invMass2, _invI2;

		/// <summary>
		/// Get the type of the concrete joint.
		/// </summary>
		public new JointType GetType()
		{
			return _type;
		}

		/// <summary>
		/// Get the first body attached to this joint.
		/// </summary>
		/// <returns></returns>
		public Body GetBody1()
		{
			return _body1;
		}

		/// <summary>
		/// Get the second body attached to this joint.
		/// </summary>
		/// <returns></returns>
		public Body GetBody2()
		{
			return _body2;
		}

		/// <summary>
		/// Get the anchor point on body1 in world coordinates.
		/// </summary>
		/// <returns></returns>
		public abstract Vec2 Anchor1 { get; }

		/// <summary>
		/// Get the anchor point on body2 in world coordinates.
		/// </summary>
		/// <returns></returns>
		public abstract Vec2 Anchor2 { get; }

		/// <summary>
		/// Get the reaction force on body2 at the joint anchor.
		/// </summary>		
		public abstract Vec2 GetReactionForce(float inv_dt);

		/// <summary>
		/// Get the reaction torque on body2.
		/// </summary>		
		public abstract float GetReactionTorque(float inv_dt);

		/// <summary>
		/// Get the next joint the world joint list.
		/// </summary>
		/// <returns></returns>
		public Joint GetNext()
		{
			return _next;
		}

		/// <summary>
		/// Get/Set the user data pointer.
		/// </summary>
		/// <returns></returns>
		public object UserData
		{
			get { return _userData; }
			set { _userData = value; }
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Joint"/> class
		/// </summary>
		/// <param name="def">The def</param>
		protected Joint(JointDef def)
		{
			_type = def.Type;
			_prev = null;
			_next = null;
			_body1 = def.Body1;
			_body2 = def.Body2;
			_collideConnected = def.CollideConnected;
			_islandFlag = false;
			_userData = def.UserData;
		}

		/// <summary>
		/// Creates the def
		/// </summary>
		/// <param name="def">The def</param>
		/// <returns>The joint</returns>
		internal static Joint Create(JointDef def)
		{
			Joint joint = null;

			switch (def.Type)
			{
				case JointType.DistanceJoint:
					{
						joint = new DistanceJoint((DistanceJointDef)def);
					}
					break;
				case JointType.MouseJoint:
					{
						joint = new MouseJoint((MouseJointDef)def);
					}
					break;
				case JointType.PrismaticJoint:
					{
						joint = new PrismaticJoint((PrismaticJointDef)def);
					}
					break;
				case JointType.RevoluteJoint:
					{
						joint = new RevoluteJoint((RevoluteJointDef)def);
					}
					break;
				case JointType.PulleyJoint:
					{
						joint = new PulleyJoint((PulleyJointDef)def);
					}
					break;
				case JointType.GearJoint:
					{
						joint = new GearJoint((GearJointDef)def);
					}
					break;
				case JointType.LineJoint:
					{
						joint = new LineJoint((LineJointDef)def);
					}
					break;
				default:
					Box2DXDebug.Assert(false);
					break;
			}

			return joint;
		}

		/// <summary>
		/// Destroys the joint
		/// </summary>
		/// <param name="joint">The joint</param>
		internal static void Destroy(Joint joint)
		{
			joint = null;
		}

		/// <summary>
		/// Inits the velocity constraints using the specified step
		/// </summary>
		/// <param name="step">The step</param>
		internal abstract void InitVelocityConstraints(TimeStep step);
		/// <summary>
		/// Solves the velocity constraints using the specified step
		/// </summary>
		/// <param name="step">The step</param>
		internal abstract void SolveVelocityConstraints(TimeStep step);

		// This returns true if the position errors are within tolerance.
		/// <summary>
		/// Describes whether this instance solve position constraints
		/// </summary>
		/// <param name="baumgarte">The baumgarte</param>
		/// <returns>The bool</returns>
		internal abstract bool SolvePositionConstraints(float baumgarte);

		/// <summary>
		/// Computes the x form using the specified xf
		/// </summary>
		/// <param name="xf">The xf</param>
		/// <param name="center">The center</param>
		/// <param name="localCenter">The local center</param>
		/// <param name="angle">The angle</param>
		internal void ComputeXForm(ref XForm xf, Vec2 center, Vec2 localCenter, float angle)
		{
			xf.R.Set(angle);
			xf.Position = center - Math.Mul(xf.R, localCenter);
		}
	}
}
