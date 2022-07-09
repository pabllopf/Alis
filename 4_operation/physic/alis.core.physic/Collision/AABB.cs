using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Collision
{
    /// <summary>
    /// An axis aligned bounding box.
    /// </summary>
    public struct Aabb
    {
        /// <summary>
        /// The lower vertex.
        /// </summary>
        public Vec2 LowerBound;

        /// <summary>
        /// The upper vertex.
        /// </summary>
        public Vec2 UpperBound;

        /// Verify that the bounds are sorted.
        public bool IsValid
        {
            get
            {
                Vec2 d = UpperBound - LowerBound;
                bool valid = d.X >= 0.0f && d.Y >= 0.0f;
                valid = valid && LowerBound.IsValid && UpperBound.IsValid;
                return valid;
            }
        }

        /// Get the center of the AABB.
        public Vec2 Center
        {
            get { return 0.5f * (LowerBound + UpperBound); }
        }

        /// Get the extents of the AABB (half-widths).
        public Vec2 Extents
        {
            get { return 0.5f * (UpperBound - LowerBound); }
        }

        /// Combine two AABBs into this one.
        public void Combine(Aabb aabb1, Aabb aabb2)
        {
            LowerBound = Common.Math.Min(aabb1.LowerBound, aabb2.LowerBound);
            UpperBound = Common.Math.Max(aabb1.UpperBound, aabb2.UpperBound);
        }

        /// Does this aabb contain the provided AABB.
        public bool Contains(Aabb aabb)
        {
            bool result = LowerBound.X <= aabb.LowerBound.X;
            result = result && LowerBound.Y <= aabb.LowerBound.Y;
            result = result && aabb.UpperBound.X <= UpperBound.X;
            result = result && aabb.UpperBound.Y <= UpperBound.Y;
            return result;
        }

        /// <summary>
        /// hello
        /// </summary>
        /// <param name="output"></param>
        /// <param name="input"></param>
        public void RayCast(out RayCastOutput output, RayCastInput input)
        {
            float tmin = -Settings.FltMax;
            float tmax = Settings.FltMax;

            output = new RayCastOutput();

            output.Hit = false;

            Vec2 p = input.P1;
            Vec2 d = input.P2 - input.P1;
            Vec2 absD = Common.Math.Abs(d);

            Vec2 normal = new Vec2(0);

            for (int i = 0; i < 2; ++i)
            {
                if (absD[i] < Settings.FltEpsilon)
                {
                    // Parallel.
                    if (p[i] < LowerBound[i] || UpperBound[i] < p[i])
                    {
                        return;
                    }
                }
                else
                {
                    float invD = 1.0f / d[i];
                    float t1 = (LowerBound[i] - p[i]) * invD;
                    float t2 = (UpperBound[i] - p[i]) * invD;

                    // Sign of the normal vector.
                    float s = -1.0f;

                    if (t1 > t2)
                    {
                        Common.Math.Swap(ref t1, ref t2);
                        s = 1.0f;
                    }

                    // Push the min up
                    if (t1 > tmin)
                    {
                        normal.SetZero();
                        normal[i] = s;
                        tmin = t1;
                    }

                    // Pull the max down
                    tmax = Common.Math.Min(tmax, t2);

                    if (tmin > tmax)
                    {
                        return;
                    }
                }
            }

            // Does the ray start inside the box?
            // Does the ray intersect beyond the max fraction?
            if (tmin < 0.0f || input.MaxFraction < tmin)
            {
                return;
            }

            // Intersection.
            output.Fraction = tmin;
            output.Normal = normal;
            output.Hit = true;
        }
    }
}