/*
  Box2DX Copyright (c) 2009 Ihar Kalasouski http://code.google.com/p/box2dx
  Box2D original C++ version Copyright (c) 2006-2009 Erin Catto http://www.gphysics.com

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

namespace Alis.Core.Physic.Collision
{
	// Structures and functions used for computing contact points, distance
	// queries, and TOI queries.

	/// <summary>
	/// The collision class
	/// </summary>
	public partial class Collision
	{
		/// <summary>
		/// The uchar max
		/// </summary>
		public static readonly byte NullFeature = Common.Math.UCHAR_MAX;

		/// <summary>
		/// Describes whether test overlap
		/// </summary>
		/// <param name="a">The </param>
		/// <param name="b">The </param>
		/// <returns>The bool</returns>
		public static bool TestOverlap(AABB a, AABB b)
		{
			Vec2 d1, d2;
			d1 = b.LowerBound - a.UpperBound;
			d2 = a.LowerBound - b.UpperBound;

			if (d1.X > 0.0f || d1.Y > 0.0f)
				return false;

			if (d2.X > 0.0f || d2.Y > 0.0f)
				return false;

			return true;
		}

		/// <summary>
		/// Compute the point states given two manifolds. The states pertain to the transition from manifold1
		/// to manifold2. So state1 is either persist or remove while state2 is either add or persist.
		/// </summary>
		public static void GetPointStates(PointState[/*b2_maxManifoldPoints*/] state1, PointState[/*b2_maxManifoldPoints*/] state2,
					  Manifold manifold1, Manifold manifold2)
		{
			for (int i = 0; i < Settings.MaxManifoldPoints; ++i)
			{
				state1[i] = PointState.NullState;
				state2[i] = PointState.NullState;
			}

			// Detect persists and removes.
			for (int i = 0; i < manifold1.PointCount; ++i)
			{
				ContactID id = manifold1.Points[i].ID;

				state1[i] = PointState.RemoveState;

				for (int j = 0; j < manifold2.PointCount; ++j)
				{
					if (manifold2.Points[j].ID.Key == id.Key)
					{
						state1[i] = PointState.PersistState;
						break;
					}
				}
			}

			// Detect persists and adds.
			for (int i = 0; i < manifold2.PointCount; ++i)
			{
				ContactID id = manifold2.Points[i].ID;

				state2[i] = PointState.AddState;

				for (int j = 0; j < manifold1.PointCount; ++j)
				{
					if (manifold1.Points[j].ID.Key == id.Key)
					{
						state2[i] = PointState.PersistState;
						break;
					}
				}
			}
		}

		// Sutherland-Hodgman clipping.
		/// <summary>
		/// Clips the segment to line using the specified v out
		/// </summary>
		/// <param name="vOut">The out</param>
		/// <param name="vIn">The in</param>
		/// <param name="normal">The normal</param>
		/// <param name="offset">The offset</param>
		/// <returns>The num out</returns>
		public static int ClipSegmentToLine(out ClipVertex[/*2*/] vOut, ClipVertex[/*2*/] vIn, Vec2 normal, float offset)
		{
			vOut = new ClipVertex[2];

			// Start with no output points
			int numOut = 0;

			// Calculate the distance of end points to the line
			float distance0 = Vec2.Dot(normal, vIn[0].V) - offset;
			float distance1 = Vec2.Dot(normal, vIn[1].V) - offset;

			// If the points are behind the plane
			if (distance0 <= 0.0f) vOut[numOut++] = vIn[0];
			if (distance1 <= 0.0f) vOut[numOut++] = vIn[1];

			// If the points are on different sides of the plane
			if (distance0 * distance1 < 0.0f)
			{
				// Find intersection point of edge and plane
				float interp = distance0 / (distance0 - distance1);
				vOut[numOut].V = vIn[0].V + interp * (vIn[1].V - vIn[0].V);
				if (distance0 > 0.0f)
				{
					vOut[numOut].ID = vIn[0].ID;
				}
				else
				{
					vOut[numOut].ID = vIn[1].ID;
				}
				++numOut;
			}

			return numOut;
		}
	}
}