using System;
using System.Collections.Generic;
using System.IO;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Common.Decomposition;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition
{
    public class _BayazitScoreFinder
    {
        public static bool Hit;

        private static Vector2F At(int i, Vertices vertices)
        {
            int s = vertices.Count;
            return vertices[i < 0 ? s - 1 - (-i - 1) % s : i % s];
        }

        private static bool Reflex(int i, Vertices vertices) => MathUtils.Area(At(i - 1, vertices), At(i, vertices), At(i + 1, vertices)) < 0;
        private static float SquareDist(Vector2F a, Vector2F b) { float dx = b.X - a.X; float dy = b.Y - a.Y; return dx * dx + dy * dy; }
        private static bool RightOn(Vector2F a, Vector2F b, Vector2F c) => MathUtils.Area(a, b, c) <= 0;
        private static bool LeftOn(Vector2F a, Vector2F b, Vector2F c) => MathUtils.Area(a, b, c) >= 0;

        private static double CalculateVertexScore(int reflexVertex, int candidate, Vertices vertices)
        {
            double score = 1 / (SquareDist(At(reflexVertex, vertices), At(candidate, vertices)) + 1);
            if (Reflex(candidate, vertices))
            {
                if (RightOn(At(candidate - 1, vertices), At(candidate, vertices), At(reflexVertex, vertices)) && LeftOn(At(candidate + 1, vertices), At(candidate, vertices), At(reflexVertex, vertices)))
                {
                    Hit = true;
                    score += 3;
                }
                else
                {
                    score += 2;
                }
            }
            else
            {
                score += 1;
            }
            return score;
        }

        private static int FindBestSplitIndex(int reflexVertex, int lowerIndex, int upperIndex, Vertices vertices)
        {
            while (upperIndex < lowerIndex) upperIndex += vertices.Count;
            double highestScore = 0; int bestIndex = lowerIndex;
            for (int j = lowerIndex; j <= upperIndex; ++j)
            {
                if (BayazitDecomposer.CanSee(reflexVertex, j, vertices))
                {
                    double score = CalculateVertexScore(reflexVertex, j, vertices);
                    if (score > highestScore) { bestIndex = j; highestScore = score; }
                }
            }
            return bestIndex;
        }

        private static bool TryFindSplit(int i, Vertices vertices, out int lowerIndex, out int upperIndex)
        {
            float upperDist; float lowerDist = upperDist = float.MaxValue;
            lowerIndex = 0; upperIndex = 0;
            for (int j = 0; j < vertices.Count; ++j)
            {
                // lower
                if (MathUtils.Area(At(i - 1, vertices), At(i, vertices), At(j, vertices)) > 0 && MathUtils.Area(At(i - 1, vertices), At(i, vertices), At(j - 1, vertices)) <= 0)
                {
                    Vector2F p = LineTools.LineIntersect(At(i - 1, vertices), At(i, vertices), At(j, vertices), At(j - 1, vertices));
                    if (MathUtils.Area(At(i + 1, vertices), At(i, vertices), p) < 0)
                    {
                        float d = SquareDist(At(i, vertices), p);
                        if (d < lowerDist) { lowerDist = d; lowerIndex = j; }
                    }
                }
                // upper
                if (MathUtils.Area(At(i + 1, vertices), At(i, vertices), At(j + 1, vertices)) > 0 && MathUtils.Area(At(i + 1, vertices), At(i, vertices), At(j, vertices)) <= 0)
                {
                    Vector2F p = LineTools.LineIntersect(At(i + 1, vertices), At(i, vertices), At(j, vertices), At(j + 1, vertices));
                    if (MathUtils.Area(At(i - 1, vertices), At(i, vertices), p) > 0)
                    {
                        float d = SquareDist(At(i, vertices), p);
                        if (d < upperDist) { upperDist = d; upperIndex = j; }
                    }
                }
            }
            return lowerDist < float.MaxValue || upperDist < float.MaxValue;
        }

        private static Vertices Copy(int i, int j, Vertices vertices)
        {
            while (j < i) j += vertices.Count;
            Vertices p = new Vertices(j);
            for (; i <= j; ++i) p.Add(At(i, vertices));
            return p;
        }

        public static void Triangulate(Vertices vertices, int depth)
        {
            if (depth > 40) return;
            for (int i = 0; i < vertices.Count; ++i)
            {
                if (Reflex(i, vertices) && TryFindSplit(i, vertices, out int lowerIndex, out int upperIndex))
                {
                    Vertices lowerPoly, upperPoly;
                    if (lowerIndex == (upperIndex + 1) % vertices.Count)
                    {
                        Vector2F p = (LineMid(i, lowerIndex, upperIndex, vertices));
                        lowerPoly = Copy(i, upperIndex, vertices); lowerPoly.Add(p);
                        upperPoly = Copy(lowerIndex, i, vertices); upperPoly.Add(p);
                    }
                    else
                    {
                        int bestIndex = FindBestSplitIndex(i, lowerIndex, upperIndex, vertices);
                        lowerPoly = Copy(i, bestIndex, vertices);
                        upperPoly = Copy(bestIndex, i, vertices);
                    }
                    Triangulate(lowerPoly, depth + 1);
                    Triangulate(upperPoly, depth + 1);
                    return;
                }
            }
        }

        // For the adjacent branch the real code computes midpoint of the two intersection points.
        // We don't need exact geometry to detect score3 because score3 is computed in the else branch.
        private static Vector2F LineMid(int i, int lowerIndex, int upperIndex, Vertices vertices)
        {
            // replicate intersection mids (not important for detection)
            return new Vector2F(At(i, vertices).X, At(i, vertices).Y);
        }
        
    }
}
