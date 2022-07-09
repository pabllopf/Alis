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

namespace Alis.Core.Physic.Collision.Shapes
{
	/// <summary>
	/// The edge shape class
	/// </summary>
	/// <seealso cref="Shape"/>
	public class EdgeShape : Shape
	{
        // Unit vector halfway between m_direction and m_prevEdge.m_direction:

        // Unit vector halfway between m_direction and m_nextEdge.m_direction:

        /// <summary>
		/// The next edge
		/// </summary>
		public EdgeShape NextEdge;
        
		/// <summary>
		/// The prev edge
		/// </summary>
		public EdgeShape PrevEdge;

		/// <summary>
		/// Initializes a new instance of the <see cref="EdgeShape"/> class
		/// </summary>
		public EdgeShape()
		{
			Type = ShapeType.EdgeShape;
			Radius = Settings.PolygonRadius;
		}

		/// <summary>
		/// Disposes this instance
		/// </summary>
		public override void Dispose()
		{
			if (PrevEdge != null)
			{
				PrevEdge.NextEdge = null;
			}

			if (NextEdge != null)
			{
				NextEdge.PrevEdge = null;
			}
		}

		/// <summary>
		/// Sets the v 1
		/// </summary>
		/// <param name="v1">The </param>
		/// <param name="v2">The </param>
		public void Set(Vec2 v1, Vec2 v2)
		{
			Vertex1 = v1;
			Vertex2 = v2;

			DirectionVector = Vertex2 - Vertex1;
			Length = DirectionVector.Normalize();
			NormalVector = Vec2.Cross(DirectionVector, 1.0f);

			Corner1Vector = NormalVector;
			Corner2Vector = -1.0f * NormalVector;
		}

		/// <summary>
		/// Describes whether this instance test point
		/// </summary>
		/// <param name="transform">The transform</param>
		/// <param name="p">The </param>
		/// <returns>The bool</returns>
		public override bool TestPoint(XForm transform, Vec2 p) => false;

        /// <summary>
		/// Tests the segment using the specified transform
		/// </summary>
		/// <param name="transform">The transform</param>
		/// <param name="lambda">The lambda</param>
		/// <param name="normal">The normal</param>
		/// <param name="segment">The segment</param>
		/// <param name="maxLambda">The max lambda</param>
		/// <returns>The segment collide</returns>
		public override SegmentCollide TestSegment(XForm transform, out float lambda, out Vec2 normal, Segment segment, float maxLambda)
		{
			Vec2 r = segment.P2 - segment.P1;
			Vec2 v1 = Math.Mul(transform, Vertex1);
			Vec2 d = Math.Mul(transform, Vertex2) - v1;
			Vec2 n = Vec2.Cross(d, 1.0f);

			float kSlop = 100.0f * Settings.FltEpsilon;
			float denom = -Vec2.Dot(r, n);

			// Cull back facing collision and ignore parallel segments.
			if (denom > kSlop)
			{
				// Does the segment intersect the infinite line associated with this segment?
				Vec2 b = segment.P1 - v1;
				float a = Vec2.Dot(b, n);

				if (0.0f <= a && a <= maxLambda * denom)
				{
					float mu2 = -r.X * b.Y + r.Y * b.X;

					// Does the segment intersect this segment?
					if (-kSlop * denom <= mu2 && mu2 <= denom * (1.0f + kSlop))
					{
						a /= denom;
						n.Normalize();
						lambda = a;
						normal = n;
						return SegmentCollide.HitCollide;
					}
				}
			}

			lambda = 0;
			normal = new Vec2();
			return SegmentCollide.MissCollide;
		}

		/// <summary>
		/// Computes the aabb using the specified aabb
		/// </summary>
		/// <param name="aabb">The aabb</param>
		/// <param name="transform">The transform</param>
		public override void ComputeAabb(out Aabb aabb, XForm transform)
		{
			Vec2 v1 = Math.Mul(transform, Vertex1);
			Vec2 v2 = Math.Mul(transform, Vertex2);

			Vec2 r = new Vec2(Radius, Radius);
			aabb.LowerBound = Math.Min(v1, v2) - r;
			aabb.UpperBound = Math.Max(v1, v2) + r;
		}

		/// <summary>
		/// Computes the mass using the specified mass data
		/// </summary>
		/// <param name="massData">The mass data</param>
		/// <param name="density">The density</param>
		public override void ComputeMass(out MassData massData, float density)
		{
			massData.Mass = 0.0f;
			massData.Center = Vertex1;
			massData.I = 0.0f;
		}

		/// <summary>
		/// Sets the prev edge using the specified edge
		/// </summary>
		/// <param name="edge">The edge</param>
		/// <param name="cornerDir">The corner dir</param>
		/// <param name="convex">The convex</param>
		public void SetPrevEdge(EdgeShape edge, Vec2 cornerDir, bool convex)
		{
			PrevEdge = edge;
			Corner1Vector = cornerDir;
			Corner1IsConvex = convex;
		}

		/// <summary>
		/// Sets the next edge using the specified edge
		/// </summary>
		/// <param name="edge">The edge</param>
		/// <param name="cornerDir">The corner dir</param>
		/// <param name="convex">The convex</param>
		public void SetNextEdge(EdgeShape edge, Vec2 cornerDir, bool convex)
		{
			NextEdge = edge;
			Corner2Vector = cornerDir;
			Corner2IsConvex = convex;
		}

		/// <summary>
		/// Computes the submerged area using the specified normal
		/// </summary>
		/// <param name="normal">The normal</param>
		/// <param name="offset">The offset</param>
		/// <param name="xf">The xf</param>
		/// <param name="c">The </param>
		/// <returns>The float</returns>
		public override float ComputeSubmergedArea(Vec2 normal, float offset, XForm xf, out Vec2 c)
		{
			//Note that v0 is independent of any details of the specific edge
			//We are relying on v0 being consistent between multiple edges of the same body
			Vec2 v0 = offset * normal;
			//b2Vec2 v0 = xf.position + (offset - b2Dot(normal, xf.position)) * normal;

			Vec2 v1 = Math.Mul(xf, Vertex1);
			Vec2 v2 = Math.Mul(xf, Vertex2);

			float d1 = Vec2.Dot(normal, v1) - offset;
			float d2 = Vec2.Dot(normal, v2) - offset;

			if (d1 > 0.0f)
            {
                if (d2 > 0.0f)
				{
					c = new Vec2();
					return 0.0f;
				}

                v1 = -d2 / (d1 - d2) * v1 + d1 / (d1 - d2) * v2;
            }
			else
			{
				if (d2 > 0.0f)
				{
					v2 = -d2 / (d1 - d2) * v1 + d1 / (d1 - d2) * v2;
				}
            }

			// v0,v1,v2 represents a fully submerged triangle
			float kInv3 = 1.0f / 3.0f;

			// Area weighted centroid
			c = kInv3 * (v0 + v1 + v2);

			Vec2 e1 = v1 - v0;
			Vec2 e2 = v2 - v0;

			return 0.5f * Vec2.Cross(e1, e2);
		}

		/// <summary>
		/// Gets the value of the length
		/// </summary>
		public float Length { get; set; }

        /// <summary>
		/// Gets the value of the vertex 1
		/// </summary>
		public Vec2 Vertex1 { get; set; }

        /// <summary>
		/// Gets the value of the vertex 2
		/// </summary>
		public Vec2 Vertex2 { get; set; }

        /// <summary>
		/// Gets the value of the normal vector
		/// </summary>
		public Vec2 NormalVector { get; set; }

        /// <summary>
		/// Gets the value of the direction vector
		/// </summary>
		public Vec2 DirectionVector { get; set; }

        /// <summary>
		/// Gets the value of the corner 1 vector
		/// </summary>
		public Vec2 Corner1Vector { get; set; }

        /// <summary>
		/// Gets the value of the corner 2 vector
		/// </summary>
		public Vec2 Corner2Vector { get; set; }

        /// <summary>
		/// Gets the support using the specified d
		/// </summary>
		/// <param name="d">The </param>
		/// <returns>The int</returns>
		public override int GetSupport(Vec2 d) => Vec2.Dot(Vertex1, d) > Vec2.Dot(Vertex2, d) ? 0 : 1;

        /// <summary>
		/// Gets the support vertex using the specified d
		/// </summary>
		/// <param name="d">The </param>
		/// <returns>The vec</returns>
		public override Vec2 GetSupportVertex(Vec2 d) => Vec2.Dot(Vertex1, d) > Vec2.Dot(Vertex2, d) ? Vertex1 : Vertex2;

        /// <summary>
		/// Gets the vertex using the specified index
		/// </summary>
		/// <param name="index">The index</param>
		/// <returns>The vec</returns>
		public override Vec2 GetVertex(int index)
		{
			Box2DXDebug.Assert(0 <= index && index < 2);
			return index == 0 ? Vertex1 : Vertex2;
        }

		/// <summary>
		/// Gets the value of the corner 1 is convex
		/// </summary>
		public bool Corner1IsConvex { get; set; }

        /// <summary>
		/// Gets the value of the corner 2 is convex
		/// </summary>
		public bool Corner2IsConvex { get; set; }

        /// <summary>
		/// Computes the sweep radius using the specified pivot
		/// </summary>
		/// <param name="pivot">The pivot</param>
		/// <returns>The float</returns>
		public override float ComputeSweepRadius(Vec2 pivot)
		{
			float ds1 = Vec2.DistanceSquared(Vertex1, pivot);
			float ds2 = Vec2.DistanceSquared(Vertex2, pivot);
			return Math.Sqrt(Math.Max(ds1, ds2));
		}
	}
}
