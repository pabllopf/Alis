// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Segment.cs
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

using Alis.Core.Aspect.Math;

namespace Alis.Core.Physic.Collisions
{
    /// <summary>
    ///     A line segment.
    /// </summary>
    public struct Segment
    {
        // Collision Detection in Interactive 3D Environments by Gino van den Bergen
        // From Section 3.4.1
        // x = mu1 * p1 + mu2 * p2
        // mu1 + mu2 = 1 && mu1 >= 0 && mu2 >= 0
        // mu1 = 1 - mu2;
        // x = (1 - mu2) * p1 + mu2 * p2
        //   = p1 + mu2 * (p2 - p1)
        // x = s + a * r (s := start, r := end - start)
        // s + a * r = p1 + mu2 * d (d := p2 - p1)
        // -a * r + mu2 * d = b (b := s - p1)
        // [-r d] * [a; mu2] = b
        // Cramer's rule:
        // denom = det[-r d]
        // a = det[b d] / denom
        // mu2 = det[-r b] / denom
        /// <summary>
        ///     Ray cast against this segment with another segment.
        /// </summary>
        public bool TestSegment(out float lambda, out Vector2 normal, Segment segment, float maxLambda)
        {
            lambda = 0f;
            normal = new Vector2();

            Vector2 s = segment.P1;
            Vector2 r = segment.P2 - s;
            Vector2 d = P2 - P1;
            Vector2 n = Vector2.Cross(d, 1.0f);

            float kSlop = 100.0f * Settings.FltEpsilon;
            float denom = -Vector2.Dot(r, n);

            // Cull back facing collision and ignore parallel segments.
            if (denom > kSlop)
            {
                // Does the segment intersect the infinite line associated with this segment?
                Vector2 b = s - P1;
                float a = Vector2.Dot(b, n);

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
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        ///     The starting point.
        /// </summary>
        public Vector2 P1;

        /// <summary>
        ///     The ending point.
        /// </summary>
        public Vector2 P2;
    }
}