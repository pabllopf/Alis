// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   RealExplosion.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Alis.Core.Aspect.Math;
using Alis.Core.Physic.Collision.RayCast;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Extensions.PhysicsLogics.PhysicsLogicBase;
using Alis.Core.Physic.Shared;
using Alis.Core.Physic.Utilities;
using Alis.Core.Systems.Physics2D.Utilities;
using Vector2 = System.Numerics.Vector2;

namespace Alis.Core.Physic.Extensions.PhysicsLogics.Explosion
{
    // Original Code by Steven Lu - see http://www.box2d.org/forum/viewtopic.php?f=3&t=1688
    // Ported by Nicol�s Hormaz�bal

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
        ///     The shape data
        /// </summary>
        private readonly List<ShapeData> data = new List<ShapeData>();

        /// <summary>
        ///     The rdc
        /// </summary>
        private readonly RayDataComparer rdc;

        /// <summary>Ratio of arc length to angle from edges to first ray tested. Defaults to 1/40.</summary>
        public float EdgeRatio = 1.0f / 40.0f;

        /// <summary>Ignore Explosion if it happens inside a shape. Default value is false.</summary>
        public bool IgnoreWhenInsideShape = false;

        /// <summary>Max angle between rays (used when segment is large). Defaults to 15 degrees</summary>
        public float MaxAngle = MathConstants.Pi / 15;

        /// <summary>Maximum number of shapes involved in the explosion. Defaults to 100</summary>
        public int MaxShapes = 100;

        /// <summary>How many rays per shape/body/segment. Defaults to 5</summary>
        public int MinRays = 5;

        /// <summary>
        ///     Initializes a new instance of the <see cref="RealExplosion" /> class
        /// </summary>
        /// <param name="world">The world</param>
        public RealExplosion(World world)
            : base(world, PhysicsLogicType.Explosion)
        {
            rdc = new RayDataComparer();
            data = new List<ShapeData>();
        }

        /// <summary>Two degrees: maximum angle from edges to first ray tested</summary>
        private const float MaxEdgeOffset = MathConstants.Pi / 90;

        /// <summary>Activate the explosion at the specified position.</summary>
        /// <param name="pos">The position where the explosion happens </param>
        /// <param name="radius">The explosion radius </param>
        /// <param name="maxForce">
        ///     The explosion force at the explosion point (then is inversely proportional to the square of the
        ///     distance)
        /// </param>
        /// <returns>A list of bodies and the amount of force that was applied to them.</returns>
        public Dictionary<Fixture, Vector2> Activate(Vector2 pos, float radius, float maxForce)
        {
            Aabb aabb;
            aabb.LowerBound = pos + new Vector2(-radius, -radius);
            aabb.UpperBound = pos + new Vector2(radius, radius);
            Fixture[] shapes = new Fixture[MaxShapes];

            // More than 5 shapes in an explosion could be possible, but still strange.
            Fixture[] containedShapes = new Fixture[5];
            bool exit = false;

            int shapeCount = 0;
            int containedShapeCount = 0;

            // Query the world for overlapping shapes.
            World.TestPointAllFixtures.ForEach(fixture =>
            {
                if (fixture.TestPoint(ref pos))
                {
                    if (IgnoreWhenInsideShape)
                    {
                        exit = true;
                    }
                    else
                    {
                        containedShapes[containedShapeCount++] = fixture;
                    }
                }
                else
                {
                    shapes[shapeCount++] = fixture;
                }
            });

            if (exit)
            {
                return new Dictionary<Fixture, Vector2>();
            }

            Dictionary<Fixture, Vector2> exploded = new Dictionary<Fixture, Vector2>(shapeCount + containedShapeCount);

            // Per shape max/min angles for now.
            float[] vals = new float[shapeCount * 2];
            int valIndex = 0;
            for (int i = 0; i < shapeCount; ++i)
            {
                PolygonShape ps;
                if (shapes[i].Shape is CircleShape cs)
                {
                    // We create a "diamond" approximation of the circle
                    Vertices v = new Vertices();
                    Vector2 vec = Vector2.Zero + new Vector2(cs.RadiusPrivate, 0);
                    v.Add(vec);
                    vec = Vector2.Zero + new Vector2(0, cs.RadiusPrivate);
                    v.Add(vec);
                    vec = Vector2.Zero + new Vector2(-cs.RadiusPrivate, cs.RadiusPrivate);
                    v.Add(vec);
                    vec = Vector2.Zero + new Vector2(0, -cs.RadiusPrivate);
                    v.Add(vec);
                    ps = new PolygonShape(v, 0);
                }
                else
                {
                    ps = shapes[i].Shape as PolygonShape;
                }

                if (shapes[i].Body.BodyType == BodyType.Dynamic && ps != null)
                {
                    Vector2 toCentroid = shapes[i].Body.GetWorldPoint(ps.MassDataPrivate.Centroid) - pos;
                    float angleToCentroid = (float) Math.Atan2(toCentroid.Y, toCentroid.X);
                    float min = float.MaxValue;
                    float max = float.MinValue;
                    float minAbsolute = 0.0f;
                    float maxAbsolute = 0.0f;

                    for (int j = 0; j < ps.VerticesPrivate.Count; ++j)
                    {
                        Vector2 toVertex = shapes[i].Body.GetWorldPoint(ps.VerticesPrivate[j]) - pos;
                        float newAngle = (float) Math.Atan2(toVertex.Y, toVertex.X);
                        float diff = newAngle - angleToCentroid;

                        diff = (diff - MathConstants.Pi) % (2 * MathConstants.Pi);

                        // the minus pi is important. It means cutoff for going other direction is at 180 deg where it needs to be

                        if (diff < 0.0f)
                        {
                            diff += 2 * MathConstants.Pi; // correction for not handling negs
                        }

                        diff -= MathConstants.Pi;

                        if (Math.Abs(diff) > MathConstants.Pi)
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

            Array.Sort(vals, 0, valIndex, rdc);
            data.Clear();
            bool rayMissed = true;

            for (int i = 0; i < valIndex; ++i)
            {
                Fixture fixture = null;
                float midpt;

                int iplus = i == valIndex - 1 ? 0 : i + 1;
                if (vals[i] == vals[iplus])
                {
                    continue;
                }

                if (i == valIndex - 1)
                {
                    // the single edgecase
                    midpt = vals[0] + MathConstants.Pi * 2 + vals[i];
                }
                else
                {
                    midpt = vals[i + 1] + vals[i];
                }

                midpt /= 2;

                Vector2 p1 = pos;
                Vector2 p2 = radius * new Vector2((float) Math.Cos(midpt), (float) Math.Sin(midpt)) + pos;

                // RaycastOne
                bool hitClosest = false;
                World.RayCast((f, p, n, fr) =>
                {
                    Body body = f.Body;

                    if (!IsActiveOn(body))
                    {
                        return 0;
                    }

                    hitClosest = true;
                    fixture = f;
                    return fr;
                }, p1, p2);

                //draws radius points
                if (hitClosest && fixture.Body.BodyType == BodyType.Dynamic)
                {
                    if (data.Any() && data.Last().Body == fixture.Body && !rayMissed)
                    {
                        int laPos = data.Count - 1;
                        ShapeData la = data[laPos];
                        la.Max = vals[iplus];
                        data[laPos] = la;
                    }
                    else
                    {
                        // make new
                        ShapeData d;
                        d.Body = fixture.Body;
                        d.Min = vals[i];
                        d.Max = vals[iplus];
                        data.Add(d);
                    }

                    if (data.Count > 1
                        && i == valIndex - 1
                        && data.Last().Body == data.First().Body
                        && data.Last().Max == data.First().Min)
                    {
                        ShapeData fi = data[0];
                        fi.Min = data.Last().Min;
                        data.RemoveAt(data.Count - 1);
                        data[0] = fi;
                        while (data.First().Min >= data.First().Max)
                        {
                            fi.Min -= MathConstants.Pi * 2;
                            data[0] = fi;
                        }
                    }

                    int lastPos = data.Count - 1;
                    ShapeData last = data[lastPos];
                    while (data.Count > 0
                           && data.Last().Min >= data.Last().Max) // just making sure min<max
                    {
                        last.Min = data.Last().Min - 2 * MathConstants.Pi;
                        data[lastPos] = last;
                    }

                    rayMissed = false;
                }
                else
                {
                    rayMissed = true; // raycast did not find a shape
                }
            }

            for (int i = 0; i < data.Count; ++i)
            {
                if (!IsActiveOn(data[i].Body))
                {
                    continue;
                }

                float arclen = data[i].Max - data[i].Min;

                float first = MathHelper.Min(MaxEdgeOffset, EdgeRatio * arclen);
                int insertedRays = (int) Math.Ceiling((arclen - 2.0f * first - (MinRays - 1) * MaxAngle) / MaxAngle);

                if (insertedRays < 0)
                {
                    insertedRays = 0;
                }

                float offset = (arclen - first * 2.0f) / ((float) MinRays + insertedRays - 1);

                //Note: This loop can go into infinite as it operates on floats.
                //Added FloatEquals with a large epsilon.
                for (float j = data[i].Min + first;
                     j < data[i].Max || MathUtils.FloatEquals(j, data[i].Max, 0.0001f);
                     j += offset)
                {
                    Vector2 p1 = pos;
                    Vector2 p2 = pos + radius * new Vector2((float) Math.Cos(j), (float) Math.Sin(j));
                    Vector2 hitpoint = Vector2.Zero;
                    float minlambda = float.MaxValue;

                    List<Fixture> fl = data[i].Body.FixtureList;
                    for (int x = 0; x < fl.Count; x++)
                    {
                        Fixture f = fl[x];
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
                        float impulse = arclen / (MinRays + insertedRays) * maxForce * 180.0f / MathConstants.Pi *
                                        (1.0f - Math.Min(1.0f, minlambda));

                        // We Apply the impulse!!!
                        Vector2 vectImp =
                            Vector2.Dot(impulse * new Vector2((float) Math.Cos(j), (float) Math.Sin(j)), -ro.Normal) *
                            new Vector2((float) Math.Cos(j), (float) Math.Sin(j));
                        data[i].Body.ApplyLinearImpulse(ref vectImp, ref hitpoint);

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

                if (!IsActiveOn(fix.Body))
                {
                    continue;
                }

                float impulse = MinRays * maxForce * 180.0f / MathConstants.Pi;
                Vector2 hitPoint;

                if (fix.Shape is CircleShape circShape)
                {
                    hitPoint = fix.Body.GetWorldPoint(circShape.Position);
                }
                else
                {
                    PolygonShape shape = fix.Shape as PolygonShape;
                    hitPoint = fix.Body.GetWorldPoint(shape.MassDataPrivate.Centroid);
                }

                Vector2 vectImp = impulse * (hitPoint - pos);

                fix.Body.ApplyLinearImpulse(ref vectImp, ref hitPoint);

                if (!exploded.ContainsKey(fix))
                {
                    exploded.Add(fix, vectImp);
                }
            }

            return exploded;
        }
    }
}