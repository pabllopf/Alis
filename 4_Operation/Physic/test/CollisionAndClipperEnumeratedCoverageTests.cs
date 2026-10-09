// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CollisionAndClipperEnumeratedCoverageTests.cs
// 
//  --------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Common.PolygonManipulation;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test
{
    /// <summary>
    ///     Deterministic enumeration coverage for the polygon collider local-search/edge paths
    ///     and the clipper's malformed-chain handling.
    /// </summary>
    public class CollisionAndClipperEnumeratedCoverageTests
    {
        /// <summary>
        ///     Enumerates polygon pairs and transforms through <see cref="Collision.CollidePolygons" />
        ///     so the reference-edge local search (improving and terminating neighbours) executes.
        /// </summary>
        [Fact]
        public void CollidePolygons_EnumeratedPairs_ProduceBoundedManifolds()
        {
            PolygonShape[] shapes =
            {
                new PolygonShape(PolygonTools.CreateRectangle(1.0f, 1.0f), 1.0f),
                new PolygonShape(PolygonTools.CreateRectangle(1.5f, 0.5f), 1.0f),
                new PolygonShape(new Vertices(new[] { new Vector2F(0, 0), new Vector2F(2, 0), new Vector2F(0, 1) }), 1.0f),
                new PolygonShape(new Vertices(new[] { new Vector2F(0, 0), new Vector2F(3, 0), new Vector2F(1, 2) }), 1.0f),
                new PolygonShape(new Vertices(new[]
                {
                    new Vector2F(0, 0), new Vector2F(2, 0), new Vector2F(3, 1), new Vector2F(1, 2)
                }), 1.0f)
            };

            ControllerTransform xfA = ControllerTransform.Identity;
            for (int i = 0; i < shapes.Length; ++i)
            {
                for (int j = 0; j < shapes.Length; ++j)
                {
                    for (float dx = -2.0f; dx <= 2.0f; dx += 0.5f)
                    {
                        for (float dy = -2.0f; dy <= 2.0f; dy += 0.5f)
                        {
                            for (float ang = 0.0f; ang < 6.28f; ang += 0.5f)
                            {
                                ControllerTransform xfB = new ControllerTransform(new Vector2F(dx, dy), ang);
                                Manifold manifold = new Manifold();
                                Collision.CollidePolygons(ref manifold, shapes[i], ref xfA, shapes[j], ref xfB);
                                Assert.InRange(manifold.PointCount, 0, SettingEnv.MaxManifoldPoints);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     Enumerates edge/polygon pairs and transforms through <see cref="Collision.CollideEdgeAndPolygon" />
        ///     so the edge collider's primary-axis selection and clipping paths execute.
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_EnumeratedPairs_ProduceBoundedManifolds()
        {
            PolygonShape[] polygons =
            {
                new PolygonShape(PolygonTools.CreateRectangle(1.0f, 1.0f), 1.0f),
                new PolygonShape(PolygonTools.CreateRectangle(2.0f, 0.5f), 1.0f),
                new PolygonShape(new Vertices(new[] { new Vector2F(0, 0), new Vector2F(2, 0), new Vector2F(0, 2) }), 1.0f)
            };
            (Vector2F start, Vector2F end)[] edges =
            {
                (new Vector2F(-1, 0), new Vector2F(1, 0)),
                (new Vector2F(0, -1), new Vector2F(0, 1)),
                (new Vector2F(-1, -1), new Vector2F(1, 1)),
                (new Vector2F(0, 0), new Vector2F(2, 1))
            };

            ControllerTransform xfA = ControllerTransform.Identity;
            for (int e = 0; e < edges.Length; ++e)
            {
                EdgeShape edge = new EdgeShape(edges[e].start, edges[e].end);
                for (int p = 0; p < polygons.Length; ++p)
                {
                    for (float dx = -3.0f; dx <= 3.0f; dx += 0.5f)
                    {
                        for (float dy = -3.0f; dy <= 3.0f; dy += 0.5f)
                        {
                            for (float ang = 0.0f; ang < 6.28f; ang += 0.5f)
                            {
                                ControllerTransform xfB = new ControllerTransform(new Vector2F(dx, dy), ang);
                                Manifold manifold = new Manifold();
                                Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfA, polygons[p], ref xfB);
                                Assert.InRange(manifold.PointCount, 0, SettingEnv.MaxManifoldPoints);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     Enumerates collinear and coincident rectangle clippings so the clipper's
        ///     broken-result and undefined-chain guards execute.
        /// </summary>
        [Fact]
        public void YuPengClipper_EnumeratedCollinearRectangles_ReturnConsistentErrors()
        {
            for (int w = 1; w <= 6; ++w)
            {
                for (int h = 1; h <= 6; ++h)
                {
                    Vertices a = Rectangle(0, 0, w, h);
                    for (int ox = -2; ox <= 2; ++ox)
                    {
                        for (int oy = -2; oy <= 2; ++oy)
                        {
                            Vertices b = Rectangle(ox, oy, w, h);

                            UnionResult union = Run(a, b, PolyClipType.Union);
                            UnionResult intersect = Run(a, b, PolyClipType.Intersect);
                            UnionResult difference = Run(a, b, PolyClipType.Difference);

                            Assert.NotNull(union.Polygons);
                            Assert.NotNull(intersect.Polygons);
                            Assert.NotNull(difference.Polygons);
                            Assert.True(Enum.IsDefined(typeof(PolyClipError), union.Error));
                            Assert.True(Enum.IsDefined(typeof(PolyClipError), intersect.Error));
                            Assert.True(Enum.IsDefined(typeof(PolyClipError), difference.Error));
                        }
                    }
                }
            }
        }

        private static Vertices Rectangle(int x, int y, int w, int h) =>
            new Vertices(new[]
            {
                new Vector2F(x, y), new Vector2F(x + w, y), new Vector2F(x + w, y + h), new Vector2F(x, y + h)
            });

        private static UnionResult Run(Vertices a, Vertices b, PolyClipType type)
        {
            List<Vertices> polygons;
            PolyClipError error;
            switch (type)
            {
                case PolyClipType.Union:
                    polygons = YuPengClipper.Union(a, b, out error);
                    break;
                case PolyClipType.Intersect:
                    polygons = YuPengClipper.Intersect(a, b, out error);
                    break;
                default:
                    polygons = YuPengClipper.Difference(a, b, out error);
                    break;
            }

            return new UnionResult(polygons, error);
        }

        private readonly struct UnionResult
        {
            public readonly List<Vertices> Polygons;
            public readonly PolyClipError Error;

            public UnionResult(List<Vertices> polygons, PolyClipError error)
            {
                Polygons = polygons;
                Error = error;
            }
        }
    }
}
