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

using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Dynamics.Joints
{
    /// <summary>
	/// The base joint class. Joints are used to constraint two bodies together in
	/// various fashions. Some joints also feature limits and motors.
	/// </summary>
	public abstract class Joint
	{
        /// <summary>
        /// The type
        /// </summary>
        protected JointType Type { get; }

        /// <summary>
        /// The prev
        /// </summary>
        internal Joint Prev { get; set; }

        /// <summary>
        /// The next
        /// </summary>
        internal Joint Next { get; set; }

        /// <summary>
        /// The joint edge
        /// </summary>
        internal JointEdge Node1 { get; } = new JointEdge();

        /// <summary>
        /// The joint edge
        /// </summary>
        internal JointEdge Node2 { get; } = new JointEdge();

        /// <summary>
        /// The body
        /// </summary>
        internal Body Body1 { get; set; }

        /// <summary>
        /// The body
        /// </summary>
        internal Body Body2 { get; set; }

        /// <summary>
        /// The island flag
        /// </summary>
        internal bool IslandFlag { get; set; }

        /// <summary>
        /// The collide connected
        /// </summary>
        internal bool CollideConnected { get; }

        // Cache here per time step to reduce cache misses.

        /// <summary>
        /// The local center
        /// </summary>
        protected Vec2 LocalCenter1 { get; set; }

        /// <summary>
        /// The local center
        /// </summary>
        protected Vec2 LocalCenter2 { get; set; }

        /// <summary>
        /// The inv
        /// </summary>
        protected float InvMass1 { get; set; }

        /// <summary>
        /// The inv
        /// </summary>
        protected float InvI1 { get; set; }

        /// <summary>
        /// The inv
        /// </summary>
        protected float InvMass2 { get; set; }

        /// <summary>
        /// The inv
        /// </summary>
        protected float InvI2 { get; set; }

        /// <summary>
		/// Get the type of the concrete joint.
		/// </summary>
		public new JointType GetType() => Type;

        /// <summary>
		/// Get the first body attached to this joint.
		/// </summary>
		/// <returns></returns>
		public Body GetBody1() => Body1;

        /// <summary>
		/// Get the second body attached to this joint.
		/// </summary>
		/// <returns></returns>
		public Body GetBody2() => Body2;

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
			return Next;
		}

		/// <summary>
		/// Get/Set the user data pointer.
		/// </summary>
		/// <returns></returns>
		public object UserData { get; set; }

        /// <summary>
		/// Initializes a new instance of the <see cref="Joint"/> class
		/// </summary>
		/// <param name="def">The def</param>
		protected Joint(JointDef def)
		{
			Type = def.Type;
			Prev = null;
			Next = null;
			Body1 = def.Body1;
			Body2 = def.Body2;
			CollideConnected = def.CollideConnected;
			IslandFlag = false;
			UserData = def.UserData;
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
		internal static void Destroy(Joint joint) => joint = null;

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
