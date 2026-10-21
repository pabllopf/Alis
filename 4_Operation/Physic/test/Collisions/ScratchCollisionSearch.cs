using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    /// Temporary scratch search used to discover configurations that reach the uncovered
    /// branches of Collision.cs. Deleted before the final commit.
    /// </summary>
    public class ScratchCollisionSearch
    {
        private static void Log(string file, string message)
        {
            File.AppendAllText(file, message + Environment.NewLine);
        }

        private static float NextUp(float value)
        {
            int bits = BitConverter.SingleToInt32Bits(value);
            return BitConverter.Int32BitsToSingle(bits + 1);
        }

        [Fact]
        public void VerifySeparation2Branch()
        {
            const string file = "/tmp/scratch_sep2verify.txt";
            File.WriteAllText(file, "=== separation2 verification ===" + Environment.NewLine);

            List<string> results = new List<string>();
            int verified = 0;

            float[] angles = { 0.3f, 0.5f, 0.7f, 0.9f, 1.1f, 1.3f, 1.7f, 2.1f, 2.6f, 3.1f };

            foreach (float angle in angles)
            {
                for (int hi = 1; hi <= 4; ++hi)
                {
                    for (int wi = 1; wi <= 4; ++wi)
                    {
                        float hx = hi * 0.25f;
                        float hy = wi * 0.25f;

                        PolygonShape poly = new PolygonShape(PolygonTools.CreateRectangle(hx, hy, Vector2F.Zero, angle), 1.0f);
                        int count = poly.Vertices.Count;

                        for (int px = -8; px <= 8; ++px)
                        {
                            for (int py = -8; py <= 8; ++py)
                            {
                                float cx = px * 0.25f;
                                float cy = py * 0.25f;

                                Vector2F cLocal = new Vector2F(cx, cy);

                                int normalIndex = 0;
                                float separation = -SettingEnv.MaxFloat;
                                for (int i = 0; i < count; ++i)
                                {
                                    Vector2F n = poly.Normals[i];
                                    Vector2F v = poly.Vertices[i];
                                    Vector2F d = cLocal - v;
                                    float s = n.X * d.X + n.Y * d.Y;
                                    if (s > separation)
                                    {
                                        separation = s;
                                        normalIndex = i;
                                    }
                                }

                                if (separation < SettingEnv.Epsilon)
                                {
                                    continue;
                                }

                                int vertIndex1 = normalIndex;
                                int vertIndex2 = vertIndex1 + 1 < count ? vertIndex1 + 1 : 0;
                                Vector2F v1 = poly.Vertices[vertIndex1];
                                Vector2F v2 = poly.Vertices[vertIndex2];

                                float u1 = (cLocal.X - v1.X) * (v2.X - v1.X) + (cLocal.Y - v1.Y) * (v2.Y - v1.Y);
                                float u2 = (cLocal.X - v2.X) * (v1.X - v2.X) + (cLocal.Y - v2.Y) * (v1.Y - v2.Y);
                                if (u1 <= 0.0f || u2 <= 0.0f)
                                {
                                    continue;
                                }

                                Vector2F faceCenter = 0.5f * (v1 + v2);
                                Vector2F value1 = cLocal - faceCenter;
                                Vector2F value2 = poly.Normals[vertIndex1];
                                float separation2 = value1.X * value2.X + value1.Y * value2.Y;

                                if (separation2 <= separation)
                                {
                                    continue;
                                }

                                // The only float in [separation, separation2) is separation itself.
                                float targetRadius = separation;
                                float circleRadius = targetRadius - SettingEnv.PolygonRadius;

                                // Find a circle radius whose float sum lands exactly on the target.
                                float chosen = circleRadius;
                                bool found = false;
                                for (int k = -3; k <= 3; ++k)
                                {
                                    float candidate = circleRadius;
                                    if (k > 0)
                                    {
                                        for (int j = 0; j < k; ++j)
                                        {
                                            candidate = NextUp(candidate);
                                        }
                                    }
                                    else if (k < 0)
                                    {
                                        for (int j = 0; j < -k; ++j)
                                        {
                                            candidate = BitConverter.Int32BitsToSingle(BitConverter.SingleToInt32Bits(candidate) - 1);
                                        }
                                    }

                                    if (SettingEnv.PolygonRadius + candidate == targetRadius)
                                    {
                                        chosen = candidate;
                                        found = true;
                                        break;
                                    }
                                }

                                if (!found)
                                {
                                    continue;
                                }

                                CircleShape circle = new CircleShape(chosen, 1.0f)
                                {
                                    Position = new Vector2F(cx, cy)
                                };

                                ControllerTransform xfA = ControllerTransform.Identity;
                                ControllerTransform xfB = ControllerTransform.Identity;

                                Manifold manifold = new Manifold();
                                Collision.CollidePolygonAndCircle(ref manifold, poly, ref xfA, circle, ref xfB);

                                // Control: slightly larger radius must produce a contact.
                                CircleShape bigger = new CircleShape(NextUp(chosen), 1.0f)
                                {
                                    Position = new Vector2F(cx, cy)
                                };

                                Manifold controlManifold = new Manifold();
                                Collision.CollidePolygonAndCircle(ref controlManifold, poly, ref xfA, bigger, ref xfB);

                                ++verified;
                                results.Add(string.Format(
                                    CultureInfo.InvariantCulture,
                                    "angle={0} hx={1} hy={2} c=({3},{4}) sep={5:R} sep2={6:R} circleR={7:R} radius={8:R} -> type={9} count={10} | control type={11} count={12}",
                                    angle, hx, hy, cx, cy, separation, separation2, chosen,
                                    SettingEnv.PolygonRadius + chosen, manifold.Type, manifold.PointCount,
                                    controlManifold.Type, controlManifold.PointCount));

                                if (verified >= 40)
                                {
                                    break;
                                }
                            }

                            if (verified >= 40)
                            {
                                break;
                            }
                        }

                        if (verified >= 40)
                        {
                            break;
                        }
                    }

                    if (verified >= 40)
                    {
                        break;
                    }
                }

                if (verified >= 40)
                {
                    break;
                }
            }

            Log(file, "verified " + verified);
            foreach (string result in results)
            {
                Log(file, result);
            }
        }
    }
}
