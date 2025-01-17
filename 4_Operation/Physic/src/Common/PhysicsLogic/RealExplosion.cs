// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RealExplosion.cs
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

using System;
using System.Collections.Generic;
using System.Linq;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Common.PhysicsLogic
{
    // Original Code by Steven Lu - see http://www.box2d.org/forum/viewtopic.php?f=3&t=1688
    // Ported to Farseer 3.0 by Nicol�s Hormaz�bal

    /* Methodology:
     * Force applied at a ray is inversely proportional to the square of distance from source
     * AABB is used to query for shapes that may be affected
     * For each RIGID BODY (not shape -- this is an optimization) that is matched, loop through its vertices to determine
     *		the extreme points -- if there is structure that contains outlining polygon, use that as an additional optimization
     * Evenly cast a number of rays against the shape - number roughly proportional to the arc coverage
     *		- Something like every 3 degrees should do the trick although this can be altered depending on the distance (if really close don't need such a high density of rays)
     *		- There should be a minimum number of rays (3-5?) applied to each body so that small bodies far away are still accurately modeled
     *		- Be sure to have the forces of each ray be proportional to the average arc length covered by each.
     * For each ray that actually intersects with the shape (non intersections indicate something blocking the path of explosion):
     *		- Apply the appropriate force dotted with the negative of the collision normal at the collision point
     *		- Optionally apply linear interpolation between aforementioned Normal force and the original explosion force in the direction of ray to simulate "surface friction" of sorts
     */

    /// <summary>
    ///     Creates a realistic explosion based on raycasting. Objects in the open will be affected, but objects behind
    ///     static bodies will not. A body that is half in cover, half in the open will get half the force applied to the end
    ///     in
    ///     the open.
    /// </summary>
    public sealed class RealExplosion : PhysicsLogic
    {
        /// <summary>
        ///     Two degrees: maximum angle from edges to first ray tested
        /// </summary>
        private const float MaxEdgeOffset = Constant.Pi / 90;

        /// <summary>
        ///     The shape data
        /// </summary>
        private readonly List<ShapeData> _data;

        /// <summary>
        ///     The rdc
        /// </summary>
        private readonly RayDataComparer _rdc;

        /// <summary>
        ///     Ratio of arc length to angle from edges to first ray tested.
        ///     Defaults to 1/40.
        /// </summary>
        public readonly float EdgeRatio = 1.0f / 40.0f;

        /// <summary>
        ///     Ignore Explosion if it happens inside a shape.
        ///     Default value is false.
        /// </summary>
        public readonly bool IgnoreWhenInsideShape = false;

        /// <summary>
        ///     Max angle between rays (used when segment is large).
        ///     Defaults to 15 degrees
        /// </summary>
        public readonly float MaxAngle = Constant.Pi / 15;

        /// <summary>
        ///     Maximum number of shapes involved in the explosion.
        ///     Defaults to 100
        /// </summary>
        public readonly int MaxShapes = 100;

        /// <summary>
        ///     How many rays per shape/body/segment.
        ///     Defaults to 5
        /// </summary>
        public readonly int MinRays = 5;

        /// <summary>
        ///     Initializes a new instance of the <see cref="RealExplosion" /> class
        /// </summary>
        /// <param name="world">The world</param>
        public RealExplosion(World world) : base(world)
        {
            _rdc = new RayDataComparer();
            _data = new List<ShapeData>();
        }

        /// <summary>
        ///     Activate the explosion at the specified position.
        /// </summary>
        /// <param name="pos">The position where the explosion happens </param>
        /// <param name="radius">The explosion radius </param>
        /// <param name="maxForce">
        ///     The explosion force at the explosion point (then is inversely proportional to the square of the
        ///     distance)
        /// </param>
        /// <returns>A list of bodies and the amount of force that was applied to them.</returns>
        public Dictionary<Fixture, Vector2F> Activate(Vector2F pos, float radius, float maxForce)
        {
            Aabb aabb;
            aabb.LowerBound = pos + new Vector2F(-radius, -radius);
            aabb.UpperBound = pos + new Vector2F(radius, radius);
            Fixture[] shapes = new Fixture[MaxShapes];

            // More than 5 shapes in an explosion could be possible, but still strange.
            Fixture[] containedShapes = new Fixture[5];
            bool exit = false;

            int shapeCount = 0;
            int containedShapeCount = 0;

            // Query the world for overlapping shapes.
            World.QueryAabb(
                fixture =>
                {
                    if (fixture.TestPoint(ref pos))
                    {
                        if (IgnoreWhenInsideShape)
                        {
                            exit = true;
                            return false;
                        }

                        containedShapes[containedShapeCount++] = fixture;
                    }
                    else
                    {
                        shapes[shapeCount++] = fixture;
                    }

                    // Continue the query.
                    return true;
                }, ref aabb);

            if (exit)
            {
                return new Dictionary<Fixture, Vector2F>();
            }

            Dictionary<Fixture, Vector2F> exploded = new Dictionary<Fixture, Vector2F>(shapeCount + containedShapeCount);

            // Per shape max/min angles for now.
            float[] vals = new float[shapeCount * 2];
            int valIndex = 0;
            for (int i = 0; i < shapeCount; ++i)
            {
                PolygonShape ps;
                if (shapes[i].GetShape is CircleShape cs)
                {
                    // We create a "diamond" approximation of the circle
                    Vertices v = new Vertices();
                    Vector2F vec = Vector2F.Zero + new Vector2F(cs.GetRadius, 0);
                    v.Add(vec);
                    vec = Vector2F.Zero + new Vector2F(0, cs.GetRadius);
                    v.Add(vec);
                    vec = Vector2F.Zero + new Vector2F(-cs.GetRadius, cs.GetRadius);
                    v.Add(vec);
                    vec = Vector2F.Zero + new Vector2F(0, -cs.GetRadius);
                    v.Add(vec);
                    ps = new PolygonShape(v, 0);
                }
                else
                {
                    ps = shapes[i].GetShape as PolygonShape;
                }

                if ((shapes[i].GetBody.GetBodyType == BodyType.Dynamic) && (ps != null))
                {
                    Vector2F toCentroid = shapes[i].GetBody.GetWorldPoint(ps.MassData.Centroid) - pos;
                    float angleToCentroid = (float) Math.Atan2(toCentroid.Y, toCentroid.X);
                    float min = float.MaxValue;
                    float max = float.MinValue;
                    float minAbsolute = 0.0f;
                    float maxAbsolute = 0.0f;

                    for (int j = 0; j < ps.Vertices.Count; ++j)
                    {
                        Vector2F toVertex = shapes[i].GetBody.GetWorldPoint(ps.Vertices[j]) - pos;
                        float newAngle = (float) Math.Atan2(toVertex.Y, toVertex.X);
                        float diff = newAngle - angleToCentroid;

                        diff = (diff - Constant.Pi) % (2 * Constant.Pi);
                        // the minus pi is important. It means cutoff for going other direction is at 180 deg where it needs to be

                        if (diff < 0.0f)
                        {
                            diff += 2 * Constant.Pi; // correction for not handling negs
                        }

                        diff -= Constant.Pi;

                        if (Math.Abs(diff) > Constant.Pi)
                        {
                            continue; // Something's wrong, point not in shape but exists angle diff > 180
                        }

                        if (diff > max)
                        {
                            max = diff;
                            maxAbsolute = newAngle;
                        }

                        if (diff < min)
                        {
                            min = diff;
                            minAbsolute = newAngle;
                        }
                    }

                    vals[valIndex] = minAbsolute;
                    ++valIndex;
                    vals[valIndex] = maxAbsolute;
                    ++valIndex;
                }
            }

            Array.Sort(vals, 0, valIndex, _rdc);
            _data.Clear();
            bool rayMissed = true;

            for (int i = 0; i < valIndex; ++i)
            {
                Fixture fixture = null;
                float midpt;

                int iplus = i == valIndex - 1 ? 0 : i + 1;
                if (Math.Abs(vals[i] - vals[iplus]) < float.Epsilon)
                {
                    continue;
                }

                if (i == valIndex - 1)
                {
                    // the single edgecase
                    midpt = vals[0] + Constant.Pi * 2 + vals[i];
                }
                else
                {
                    midpt = vals[i + 1] + vals[i];
                }

                midpt = midpt / 2;

                Vector2F p1 = pos;
                Vector2F p2 = radius * new Vector2F((float) Math.Cos(midpt), (float) Math.Sin(midpt)) + pos;

                // RaycastOne
                bool hitClosest = false;
                World.RayCast((f, p, n, fr) =>
                {
                    Body body = f.GetBody;

                    if (!IsActiveOn(body))
                    {
                        return 0;
                    }

                    hitClosest = true;
                    fixture = f;
                    return fr;
                }, p1, p2);

                //draws radius points
                if (hitClosest && (fixture.GetBody.GetBodyType == BodyType.Dynamic))
                {
                    if (_data.Any() && (_data.Last().Body == fixture.GetBody) && !rayMissed)
                    {
                        int laPos = _data.Count - 1;
                        ShapeData la = _data[laPos];
                        la.Max = vals[iplus];
                        _data[laPos] = la;
                    }
                    else
                    {
                        // make new
                        ShapeData d;
                        d.Body = fixture.GetBody;
                        d.Min = vals[i];
                        d.Max = vals[iplus];
                        _data.Add(d);
                    }

                    if ((_data.Count > 1)
                        && (i == valIndex - 1)
                        && (_data.Last().Body == _data.First().Body)
                        && (Math.Abs(_data.Last().Max - _data.First().Min) < float.Epsilon))
                    {
                        ShapeData fi = _data[0];
                        fi.Min = _data.Last().Min;
                        _data.RemoveAt(_data.Count - 1);
                        _data[0] = fi;
                        while (_data.First().Min >= _data.First().Max)
                        {
                            fi.Min -= Constant.Pi * 2;
                            _data[0] = fi;
                        }
                    }

                    int lastPos = _data.Count - 1;
                    ShapeData last = _data[lastPos];
                    while ((_data.Count > 0)
                           && (_data.Last().Min >= _data.Last().Max)) // just making sure min<max
                    {
                        last.Min = _data.Last().Min - 2 * Constant.Pi;
                        _data[lastPos] = last;
                    }

                    rayMissed = false;
                }
                else
                {
                    rayMissed = true; // raycast did not find a shape
                }
            }

            for (int i = 0; i < _data.Count; ++i)
            {
                if (!IsActiveOn(_data[i].Body))
                {
                    continue;
                }

                float arclen = _data[i].Max - _data[i].Min;

                float first = Math.Min(MaxEdgeOffset, EdgeRatio * arclen);
                int insertedRays = (int) Math.Ceiling((arclen - 2.0f * first - (MinRays - 1) * MaxAngle) / MaxAngle);

                if (insertedRays < 0)
                {
                    insertedRays = 0;
                }

                float offset = (arclen - first * 2.0f) / ((float) MinRays + insertedRays - 1);

                //Note: This loop can go into infinite as it operates on floats.
                //Added FloatEquals with a large epsilon.
                for (float j = _data[i].Min + first;
                     j < _data[i].Max || MathUtils.FloatEquals(j, _data[i].Max, 0.0001f);
                     j += offset)
                {
                    Vector2F p1 = pos;
                    Vector2F p2 = pos + radius * new Vector2F((float) Math.Cos(j), (float) Math.Sin(j));
                    Vector2F hitpoint = Vector2F.Zero;
                    float minlambda = float.MaxValue;

                    foreach (Fixture f in _data[i].Body.FixtureList)
                    {
                        RayCastInput ri;
                        ri.Point1 = p1;
                        ri.Point2 = p2;
                        ri.MaxFraction = 50f;

                        if (f.RayCast(out RayCastOutput ro, ref ri, 0))
                        {
                            if (minlambda > ro.Fraction)
                            {
                                minlambda = ro.Fraction;
                                hitpoint = ro.Fraction * p2 + (1 - ro.Fraction) * p1;
                            }
                        }

                        // the force that is to be applied for this particular ray.
                        // offset is angular coverage. lambda*length of segment is distance.
                        float impulse = arclen / (MinRays + insertedRays) * maxForce * 180.0f / Constant.Pi * (1.0f - Math.Min(1.0f, minlambda));

                        // We Apply the impulse!!!
                        Vector2F vectImp = Vector2F.Dot(impulse * new Vector2F((float) Math.Cos(j), (float) Math.Sin(j)), -ro.Normal) * new Vector2F((float) Math.Cos(j), (float) Math.Sin(j));
                        _data[i].Body.ApplyLinearImpulse(ref vectImp, ref hitpoint);

                        // We gather the fixtures for returning them
                        if (exploded.ContainsKey(f))
                        {
                            exploded[f] += vectImp;
                        }
                        else
                        {
                            exploded.Add(f, vectImp);
                        }

                        if (minlambda > 1.0f)
                        {
                            hitpoint = p2;
                        }
                    }
                }
            }

            // We check contained shapes
            for (int i = 0; i < containedShapeCount; ++i)
            {
                Fixture fix = containedShapes[i];

                if (!IsActiveOn(fix.GetBody))
                {
                    continue;
                }

                float impulse = MinRays * maxForce * 180.0f / Constant.Pi;
                Vector2F hitPoint;

                if (fix.GetShape is CircleShape circShape)
                {
                    hitPoint = fix.GetBody.GetWorldPoint(circShape.Position);
                }
                else
                {
                    PolygonShape shape = fix.GetShape as PolygonShape;
                    hitPoint = fix.GetBody.GetWorldPoint(shape.MassData.Centroid);
                }

                Vector2F vectImp = impulse * (hitPoint - pos);

                fix.GetBody.ApplyLinearImpulse(ref vectImp, ref hitPoint);

                if (!exploded.ContainsKey(fix))
                {
                    exploded.Add(fix, vectImp);
                }
            }

            return exploded;
        }
    }
}