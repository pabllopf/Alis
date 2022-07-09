using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Collision
{
    /// <summary>
    /// A line segment.
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
        /// Ray cast against this segment with another segment.        
        /// </summary>
        public bool TestSegment(out float lambda, out Vec2 normal, Segment segment, float maxLambda)
        {
            lambda = 0f;
            normal = new Vec2();

            Vec2 s = segment.P1;
            Vec2 r = segment.P2 - s;
            Vec2 d = P2 - P1;
            Vec2 n = Vec2.Cross(d, 1.0f);

            float k_slop = 100.0f * Settings.FltEpsilon;
            float denom = -Vec2.Dot(r, n);

            // Cull back facing collision and ignore parallel segments.
            if (denom > k_slop)
            {
                // Does the segment intersect the infinite line associated with this segment?
                Vec2 b = s - P1;
                float a = Vec2.Dot(b, n);

                if (0.0f <= a && a <= maxLambda * denom)
                {
                    float mu2 = -r.X * b.Y + r.Y * b.X;

                    // Does the segment intersect this segment?
                    if (-k_slop * denom <= mu2 && mu2 <= denom * (1.0f + k_slop))
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
        /// The starting point.
        /// </summary>
        public Vec2 P1;

        /// <summary>
        /// The ending point.
        /// </summary>
        public Vec2 P2;
    }
}