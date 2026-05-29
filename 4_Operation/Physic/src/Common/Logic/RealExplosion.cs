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
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Common.Logic
{
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
        internal const float MaxEdgeOffset = Constant.Pi / 90;

        /// <summary>
        ///     The shape data
        /// </summary>
        internal readonly List<ShapeData> _data;

        /// <summary>
        ///     The rdc
        /// </summary>
        internal readonly RayDataComparer _rdc;

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
        /// <param name="worldPhysic">The world</param>
        public RealExplosion(WorldPhysic worldPhysic) : base(worldPhysic)
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

            Fixture[] containedShapes = new Fixture[5];
            bool exit = false;

            int shapeCount = 0;
            int containedShapeCount = 0;

            WorldPhysic.QueryAabb(
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

                    return true;
                }, ref aabb);

            if (exit)
            {
                return new Dictionary<Fixture, Vector2F>();
            }

            Dictionary<Fixture, Vector2F> exploded = new Dictionary<Fixture, Vector2F>(shapeCount + containedShapeCount);

            float[] vals = new float[shapeCount * 2];
            int valIndex = ComputeShapeAngleBounds(shapes, shapeCount, pos, vals);

            Array.Sort(vals, 0, valIndex, _rdc);
            _data.Clear();

            ProcessRayCastResults(vals, valIndex, pos, radius);

            ApplyExplosionImpulses(pos, radius, maxForce, exploded);

            ApplyContainedShapeImpulses(pos, maxForce, containedShapes, containedShapeCount, exploded);

            return exploded;
        }

        /// <summary>
        ///     Computes the angular bounds for each shape relative to the explosion position.
        /// </summary>
        private static int ComputeShapeAngleBounds(Fixture[] shapes, int shapeCount, Vector2F pos, float[] vals)
        {
            int valIndex = 0;
            for (int i = 0; i < shapeCount; ++i)
            {
                PolygonShape ps = ConvertToPolygonShape(shapes[i]);
                if (ps == null) continue;

                var body = shapes[i].GetBody;
                if (body.GetBodyType != BodyType.Dynamic) continue;

                ComputeAngleBoundsForShape(ps, body, pos, vals, ref valIndex);
            }

            return valIndex;
        }

        private static PolygonShape ConvertToPolygonShape(Fixture fixture)
        {
            if (fixture.GetShape is CircleShape cs)
                return CreatePolygonFromCircle(cs);

            return fixture.GetShape as PolygonShape;
        }

        private static PolygonShape CreatePolygonFromCircle(CircleShape cs)
        {
            var v = new Vertices();
            float r = cs.GetRadius;
            v.Add(new Vector2F(r, 0));
            v.Add(new Vector2F(0, r));
            v.Add(new Vector2F(-r, r));
            v.Add(new Vector2F(0, -r));
            return new PolygonShape(v, 0);
        }

        private static void ComputeAngleBoundsForShape(PolygonShape ps, Body body, Vector2F pos, float[] vals, ref int valIndex)
        {
            Vector2F toCentroid = body.GetWorldPoint(ps.MassData.Centroid) - pos;
            float angleToCentroid = (float)Math.Atan2(toCentroid.Y, toCentroid.X);

            float min = float.MaxValue, max = float.MinValue;
            float minAbsolute = 0.0f, maxAbsolute = 0.0f;

            for (int j = 0; j < ps.Vertices.Count; ++j)
            {
                Vector2F toVertex = body.GetWorldPoint(ps.Vertices[j]) - pos;
                float newAngle = (float)Math.Atan2(toVertex.Y, toVertex.X);
                float diff = NormalizeAngleDifference(newAngle - angleToCentroid);

                if (Math.Abs(diff) > Constant.Pi) continue;

                if (diff > max) { max = diff; maxAbsolute = newAngle; }
                if (diff < min) { min = diff; minAbsolute = newAngle; }
            }

            vals[valIndex++] = minAbsolute;
            vals[valIndex++] = maxAbsolute;
        }

        private static float NormalizeAngleDifference(float diff)
        {
            diff = (diff - Constant.Pi) % (2 * Constant.Pi);
            if (diff < 0.0f) diff += 2 * Constant.Pi;
            diff -= Constant.Pi;
            return diff;
        }

        /// <summary>
        ///     Processes ray cast results to populate the internal shape data list.
        /// </summary>
        private void ProcessRayCastResults(float[] vals, int valIndex, Vector2F pos, float radius)
        {
            bool rayMissed = true;

            for (int i = 0; i < valIndex; ++i)
            {
                if (ShouldSkipAnglePair(vals, i, valIndex)) continue;

                float midpt = ComputeMidpoint(vals, i, valIndex);
                Vector2F p1 = pos;
                Vector2F p2 = radius * new Vector2F((float)Math.Cos(midpt), (float)Math.Sin(midpt)) + pos;

                Fixture fixture = null;
                bool hitClosest = false;

                WorldPhysic.RayCast((f, p, n, fr) =>
                {
                    Body body = f.GetBody;
                    if (!IsActiveOn(body)) return 0;
                    hitClosest = true;
                    fixture = f;
                    return fr;
                }, p1, p2);

                if (hitClosest && fixture.GetBody.GetBodyType == BodyType.Dynamic)
                {
                    ProcessRayHit(vals, i, valIndex, fixture.GetBody, ref rayMissed);
                    rayMissed = false;
                }
                else
                {
                    rayMissed = true;
                }
            }
        }

        private static bool ShouldSkipAnglePair(float[] vals, int i, int valIndex) =>
            Math.Abs(vals[i] - vals[i == valIndex - 1 ? 0 : i + 1]) < float.Epsilon;

        private static float ComputeMidpoint(float[] vals, int i, int valIndex)
        {
            float midpt = i == valIndex - 1
                ? vals[0] + Constant.Pi * 2 + vals[i]
                : vals[i + 1] + vals[i];
            return midpt / 2;
        }

        private void ProcessRayHit(float[] vals, int i, int valIndex, Body body, ref bool rayMissed)
        {
            int iplus = i == valIndex - 1 ? 0 : i + 1;

            if (ListAny(_data) && ListLast(_data).Body == body && !rayMissed)
                UpdateLastShapeData(iplus);
            else
                AddNewShapeData(body, vals[i], vals[iplus]);

            if (i == valIndex - 1)
            {
                MergeCircularData();
                AdjustWrappedData();
            }

            AdjustOverlappingData();
        }

        private void UpdateLastShapeData(float max)
        {
            int laPos = _data.Count - 1;
            ShapeData la = _data[laPos];
            la.Max = max;
            _data[laPos] = la;
        }

        private void AddNewShapeData(Body body, float min, float max)
        {
            ShapeData d = new() { Body = body, Min = min, Max = max };
            _data.Add(d);
        }

        private void MergeCircularData()
        {
            if (_data.Count <= 1) return;
            if (ListLast(_data).Body != ListFirst(_data).Body) return;
            if (Math.Abs(ListLast(_data).Max - ListFirst(_data).Min) >= float.Epsilon) return;

            ShapeData fi = _data[0];
            fi.Min = ListLast(_data).Min;
            _data.RemoveAt(_data.Count - 1);
            _data[0] = fi;

            while (ListFirst(_data).Min >= ListFirst(_data).Max)
            {
                fi.Min -= Constant.Pi * 2;
                _data[0] = fi;
            }
        }

        private void AdjustWrappedData()
        {
            int lastPos = _data.Count - 1;
            ShapeData last = _data[lastPos];
            while ((_data.Count > 0) && (ListLast(_data).Min >= ListLast(_data).Max))
            {
                last.Min = ListLast(_data).Min - 2 * Constant.Pi;
                _data[lastPos] = last;
            }
        }

        private void AdjustOverlappingData()
        {
            int lastPos = _data.Count - 1;
            ShapeData last = _data[lastPos];
            while ((_data.Count > 0) && (ListLast(_data).Min >= ListLast(_data).Max))
            {
                last.Min = ListLast(_data).Min - 2 * Constant.Pi;
                _data[lastPos] = last;
            }
        }

        /// <summary>
        ///     Applies explosion impulses to bodies hit by ray casts.
        /// </summary>
        private void ApplyExplosionImpulses(Vector2F pos, float radius, float maxForce, Dictionary<Fixture, Vector2F> exploded)
        {
            for (int i = 0; i < _data.Count; ++i)
            {
                if (!IsActiveOn(_data[i].Body))
                {
                    continue;
                }

                float arclen = _data[i].Max - _data[i].Min;
                float first = Math.Min(MaxEdgeOffset, EdgeRatio * arclen);
                int insertedRays = (int)Math.Ceiling((arclen - 2.0f * first - (MinRays - 1) * MaxAngle) / MaxAngle);

                if (insertedRays < 0)
                {
                    insertedRays = 0;
                }

                float offset = (arclen - first * 2.0f) / ((float)MinRays + insertedRays - 1);

                for (float j = _data[i].Min + first;
                     j < _data[i].Max || MathUtils.FloatEquals(j, _data[i].Max, 0.0001f);
                     j += offset)
                {
                    Vector2F p1 = pos;
                    Vector2F p2 = pos + radius * new Vector2F((float)Math.Cos(j), (float)Math.Sin(j));
                    Vector2F hitpoint = Vector2F.Zero;
                    float minlambda = float.MaxValue;

                    foreach (Fixture f in _data[i].Body.FixtureList)
                    {
                        RayCastInput ri;
                        ri.Point1 = p1;
                        ri.Point2 = p2;
                        ri.MaxFraction = 50f;

                        if (f.RayCast(out RayCastOutput ro, ref ri, 0) && minlambda > ro.Fraction)
                        {
                            minlambda = ro.Fraction;
                            hitpoint = ro.Fraction * p2 + (1 - ro.Fraction) * p1;
                        }

                        float impulse = arclen / (MinRays + insertedRays) * maxForce * 180.0f / Constant.Pi * (1.0f - Math.Min(1.0f, minlambda));
                        Vector2F vectImp = Vector2F.Dot(impulse * new Vector2F((float)Math.Cos(j), (float)Math.Sin(j)), -ro.Normal) * new Vector2F((float)Math.Cos(j), (float)Math.Sin(j));
                        _data[i].Body.ApplyLinearImpulse(ref vectImp, ref hitpoint);

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
        }

        /// <summary>
        ///     Applies impulses to shapes that contain the explosion origin.
        /// </summary>
        private void ApplyContainedShapeImpulses(Vector2F pos, float maxForce, Fixture[] containedShapes, int containedShapeCount, Dictionary<Fixture, Vector2F> exploded)
        {
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
        }

        /// <summary>
        ///     Lists the any using the specified list
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="list">The list</param>
        /// <returns>The bool</returns>
        internal static bool ListAny<T>(List<T> list) => list.Count > 0;

        /// <summary>
        ///     Lists the first using the specified list
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="list">The list</param>
        /// <returns>The</returns>
        internal static T ListFirst<T>(List<T> list) => list[0];

        /// <summary>
        ///     Lists the last using the specified list
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="list">The list</param>
        /// <returns>The</returns>
        internal static T ListLast<T>(List<T> list) => list[list.Count - 1];
    }
}